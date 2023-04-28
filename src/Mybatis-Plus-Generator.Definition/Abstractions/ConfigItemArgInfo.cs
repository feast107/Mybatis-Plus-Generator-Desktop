using System;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Mybatis_Plus_Generator.Definition.Abstractions;

public partial class ConfigItemArgInfo : ObservableObject
{
    [ObservableProperty] private Type argType = null!;
    [ObservableProperty] private string argValue = string.Empty;
    [ObservableProperty] private string argName = string.Empty;

    public bool IsPassword => ArgName == "password";

    [RelayCommand]
    private void OnEdit(string str)
    {
        Debugger.Break();
    }
    public object TransformArg()
    {
        return argValue;
    }
}