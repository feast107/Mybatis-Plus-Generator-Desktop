using CommunityToolkit.Mvvm.ComponentModel;
using Mybatis_Plus_Generator.Definition.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using CommunityToolkit.Mvvm.Input;

namespace Mybatis_Plus_Generator.Definition.Abstractions;

#region 用 String 读写
public partial class ConfigItemArgInfo
{
    public bool IsPassword => ArgName == "password";
}
#endregion

#region 用 List 读写
public partial class ConfigItemArgInfo
{
    public partial class StringArg : ObservableObject
    {
        public bool IsGenerated { get; init; }
        [ObservableProperty] private string? argValue;

        public required string ArgName
        {
            get => argName!;
            init => argName = value.Replace("List","");
        }
        private readonly string? argName;
    }
    public ObservableCollection<StringArg>? ArgAsList
    {
        get => ArgMode is ArgModes.List
            ? (ObservableCollection<StringArg>)(ArgValue ??= new ObservableCollection<StringArg>()
            {
                new() { ArgName = ArgName }
            })
            : null;
        set
        {
            ArgValue = value;
            OnPropertyChanged();
        }
    }

    [RelayCommand]
    private void AddListArg()
    {
        ArgAsList?.Add(new StringArg() { IsGenerated = true, ArgName = ArgName });
    }

    [RelayCommand]
    private void RemoveListArg(StringArg arg)
    {
        ArgAsList?.Remove(arg);
    }
}
#endregion

#region 用 Type 读写
public partial class ConfigItemArgInfo
{
    [ObservableProperty] private ObservableCollection<Type>? candidates;

    public object? ArgAsType
    {
        get => argAsType;
        set
        {
            if (value is not Type type)
            {
                argAsType = null;
                ArgValue = null;
            }
            else ArgValue = Activator.CreateInstance(type);
            OnPropertyChanged();
        }
    }

    private Type? argAsType;
}
#endregion

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
                                .Where(x => x.IsClass 
                                            && !x.IsAbstract 
                                            && ArgType.IsAssignableFrom(x)
                                            && x.GetConstructors().Any(c=>c.GetParameters().Length == 0))
                                .Aggregate(new ObservableCollection<Type>(),
                                    (o, c) =>
                                    {
                                        o.Add(c);
                                        return o;
                                    });
                            break;
                    }
                    break;
            }
        };
    }

    [ObservableProperty] private object? argValue;
    [ObservableProperty] private Type argType = null!;
    [ObservableProperty] private string argName = string.Empty;

    public ArgModes ArgMode => ArgType switch
    {
        { FullName: $"{nameof(System)}.{nameof(String)}[]", IsInterface: false } => ArgModes.List,
        { FullName: $"{nameof(System)}.{nameof(String)}" } => IsPassword
            ? ArgModes.Password
            : ArgModes.Plain,
        { IsInterface: true } => ArgType.FullName
            is "java.util.List" or "java.util.Map"
            ? ArgModes.List
            : ArgModes.Interface,
        _ => ArgModes.None
    };

    public object TransformArg()
    {
        return argValue;
    }
}