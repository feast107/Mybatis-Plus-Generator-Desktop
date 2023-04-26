using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Mybatis_Plus_Generator.Definition.Abstractions
{
    public abstract partial class ConfigInfo : ObservableObject
    {
        [ObservableProperty] private TemplateInfo? templateInfo;

    }
}
