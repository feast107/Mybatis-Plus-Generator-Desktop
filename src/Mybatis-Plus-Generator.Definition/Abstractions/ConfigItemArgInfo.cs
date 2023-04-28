using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

namespace Mybatis_Plus_Generator.Definition.Abstractions;

public partial class ConfigItemArgInfo : ObservableObject
{
    public Type ArgType
    {
        get => argType;
        set
        {
            argType = value;
            switch (value)
            {
                case { IsInterface: true }:
                    Candidates = Assembly
                        .GetAssembly(value)
                        .ExportedTypes
                        .Aggregate(new ObservableCollection<Type>(),
                            (o, c) =>
                            {
                                if (!c.IsClass || !value.IsAssignableFrom(c)) return o;
                                o.Add(c);
                                return o;
                            });
                    break;
            }
        }
    }
    private Type argType = null!;

    public object ArgValue
    {
        get => argValue;
        set => SetProperty(ref argValue, value);
    }
    private object? argValue;
    [ObservableProperty] private string argName = string.Empty;
    [ObservableProperty] private ObservableCollection<Type>? candidates;

    public bool IsPassword => ArgName == "password";

    public object TransformArg()
    {
        return argValue;
    }
}