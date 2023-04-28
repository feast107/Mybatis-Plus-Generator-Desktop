using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Reflection;

namespace Mybatis_Plus_Generator.Definition.Abstractions
{
    public partial class ConfigItemInfo : ObservableObject
    {
        public partial class ConfigItemArgInfo : ObservableObject
        {
            [ObservableProperty] private Type argType;
            [ObservableProperty] private string argValue;
            [ObservableProperty] private string argName;
        }

        public enum SwitchCondition
        {
            ShowAdd,
            ShowRemove,
            None
        }

        /// <summary>
        /// 关联模板
        /// </summary>
        [ObservableProperty] private TemplateItemInfo? templateInfo;

        [ObservableProperty] private bool isEnable = true;

        [ObservableProperty] private bool isGenerated = false;

        public MethodBase SelectMethod
        {
            get => selectMethod??= TemplateInfo.Methods[0];
            set => SetProperty(ref selectMethod, value);
        }
        private MethodBase? selectMethod;

        
        public ObservableCollection<ConfigItemArgInfo> Args => throw new NotImplementedException();
        private ObservableCollection<ConfigItemArgInfo>? args;
    }
}
