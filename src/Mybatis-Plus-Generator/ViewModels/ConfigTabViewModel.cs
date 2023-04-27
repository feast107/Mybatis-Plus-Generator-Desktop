﻿using CommunityToolkit.Mvvm.ComponentModel;
using Mybatis_Plus_Generator.Definition.Abstractions;
using System.Collections.ObjectModel;

namespace Mybatis_Plus_Generator.ViewModels
{
    public partial class ConfigTabViewModel : ConfigRecord
    {
        /// <summary>
        /// 配置类型
        /// </summary>
        [ObservableProperty] private string? configType;

        [ObservableProperty] private ObservableCollection<ConfigInfo> configs = new();


    }
}
