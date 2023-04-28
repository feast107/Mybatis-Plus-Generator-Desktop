namespace Mybatis_Plus_Generator.Definition.Extensions
{
    public static class ObjectExtension
    {
        public static object[]? AsParameter(this object? param)
        {
            return param == null ? null : new [] { param };
        }
    }
}
