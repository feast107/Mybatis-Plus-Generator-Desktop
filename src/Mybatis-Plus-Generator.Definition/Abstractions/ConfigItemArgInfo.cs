using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Mybatis_Plus_Generator.Definition.Abstractions;

public partial class ConfigItemArgInfo : ObservableObject
{
    [ObservableProperty] private Type argType = null!;
    [ObservableProperty] private string argValue = string.Empty;
    [ObservableProperty] private string argName = string.Empty;

    public object TransformArg()
    {
        return argValue;
    }
}