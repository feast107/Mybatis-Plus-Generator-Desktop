using CommunityToolkit.Mvvm.ComponentModel;
using Mybatis_Plus_Generator.Definition.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using CommunityToolkit.Mvvm.Input;

namespace Mybatis_Plus_Generator.Definition.Abstractions;

#region 用 string 读写
public partial class ConfigItemArgInfo
{
    public bool IsPassword => ArgName == "password";
}
#endregion

#region 用 ObservableCollection 读写
public partial class ConfigItemArgInfo
{
    public partial class StringArg : ObservableObject
    {
        public bool IsGenerated { get; init; }
        [ObservableProperty] private string? argValue;
    }
    public ObservableCollection<StringArg>? ArgAsList
    {
        get => ArgMode is ArgModes.List
            ? (ObservableCollection<StringArg>)(ArgValue ??= new ObservableCollection<StringArg>()
            {
                new ()
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
        ArgAsList?.Add(new StringArg() { IsGenerated = true });
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

    [ObservableProperty] private object? argValue;
    [ObservableProperty] private Type argType = null!;
    [ObservableProperty] private string argName = string.Empty;

    public ArgModes ArgMode => this switch
    {
        { ArgType.FullName: $"{nameof(System)}.{nameof(String)}" } => IsPassword 
            ? ArgModes.Password 
            : ArgModes.Plain,
        { ArgType.IsInterface : true } => ArgType.FullName
            is not "java.util.List"
            and not "java.util.Map"
            ? ArgModes.Interface
            : ArgModes.List,
        _ => ArgModes.None
    };

    public object TransformArg()
    {
        return argValue;
    }
}