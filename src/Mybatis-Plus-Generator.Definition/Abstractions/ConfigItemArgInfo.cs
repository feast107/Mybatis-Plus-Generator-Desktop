using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

namespace Mybatis_Plus_Generator.Definition.Abstractions;

public partial class ConfigItemArgInfo : ObservableObject
{
    public ConfigItemArgInfo()
    {
        PropertyChanged += (_, e) =>
        {
            switch (e.PropertyName)
            {
                case nameof(ArgType):
                    switch (ArgType)
                    {
                        case { IsInterface: true }:
                            Candidates = Assembly
                                .GetAssembly(ArgType)
                                .ExportedTypes
                                .Aggregate(new ObservableCollection<Type>(),
                                    (o, c) =>
                                    {
                                        if (!c.IsClass || !ArgType.IsAssignableFrom(c)) return o;
                                        o.Add(c);
                                        return o;
                                    });
                            break;
                    }
                    break;
            }
        };
    }
    

    public object ArgValue
    {
        get => argValue ??= string.Empty;
        set => SetProperty(ref argValue, value);
    }
    private object? argValue;

    [ObservableProperty] private Type argType = null!;
    [ObservableProperty] private string argName = string.Empty;
    [ObservableProperty] private ObservableCollection<Type>? candidates;

    public bool IsPassword => ArgName == "password";

    public object TransformArg()
    {
        return argValue;
    }
}