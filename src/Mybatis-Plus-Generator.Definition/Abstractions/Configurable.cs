using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Mybatis_Plus_Generator.Definition.Abstractions
{
    public abstract partial class Configurable : ObservableObject
    {
        [ObservableProperty] private string? field;
        [ObservableProperty] private Type? valueType;
        [ObservableProperty] private string? value;
        public abstract bool AllowMultiple { get; protected set; }
    }
}
