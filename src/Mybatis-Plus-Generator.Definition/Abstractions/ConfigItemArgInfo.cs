using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Mybatis_Plus_Generator.Definition.Abstractions;

public partial class ConfigItemArgInfo : ObservableObject
{
    [ObservableProperty] private Type? argType;
    [ObservableProperty] private string? argValue;
    [ObservableProperty] private string? argName;
}