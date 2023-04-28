using System;
using System.Windows.Media;

namespace Mybatis_Plus_Generator.Converters;

internal struct Xyz
{
    public double X { get; }
    public double Y { get; }
    public double Z { get; }

    public Xyz(double x, double y, double z)
    {
        X = x;
        Y = y;
        Z = z;
    }
}
internal struct Lab
{
    public double L { get; }
    public double A { get; }
    public double B { get; }

    public Lab(double l, double a, double b)
    {
        L = l;
        A = a;
        B = b;
    }
}

internal class LabConstants
{
    public const double Kn = 18;

    public const double WhitePointX = 0.95047;
    public const double WhitePointY = 1;
    public const double WhitePointZ = 1.08883;

    public static readonly double eCubedRoot = Math.Pow(e, 1.0 / 3);
    public const double k = 24389 / 27.0;
    public const double e = 216 / 24389.0;
}
internal static class LabConverter
{
    public static Lab ToLab(this Color c)
    {
        var xyz = c.ToXyz();
        return xyz.ToLab();
    }

    public static Lab ToLab(this Xyz xyz)
    {
        double xyz_lab(double v)
        {
            if (v > LabConstants.e)
                return Math.Pow(v, 1 / 3.0);
            else
                return (v * LabConstants.k + 16) / 116;
        }

        var fx = xyz_lab(xyz.X / LabConstants.WhitePointX);
        var fy = xyz_lab(xyz.Y / LabConstants.WhitePointY);
        var fz = xyz_lab(xyz.Z / LabConstants.WhitePointZ);

        var l = 116 * fy - 16;
        var a = 500 * (fx - fy);
        var b = 200 * (fy - fz);
        return new Lab(l, a, b);
    }

    public static Color ToColor(this Lab lab)
    {
        var xyz = lab.ToXyz();

        return xyz.ToColor();
    }
}