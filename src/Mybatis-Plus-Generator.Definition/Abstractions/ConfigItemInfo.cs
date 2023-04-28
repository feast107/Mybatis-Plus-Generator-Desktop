using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

namespace Mybatis_Plus_Generator.Definition.Abstractions
{
    public partial class ConfigItemInfo : ObservableObject
    {
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

        private MethodBase ChangeSelectMethod(MethodBase method)
        {
            SetProperty(ref selectMethod, method);
            var param = method.GetParameters();
            Args = param.Aggregate(new ObservableCollection<ConfigItemArgInfo>(), (o, c) =>
            {
                o.Add(new ConfigItemArgInfo()
                {
                    ArgName = c.Name,
                    ArgType = c.ParameterType,
                });
                return o;
            });
            return method;
        }

        public MethodBase SelectMethod
        {
            get => selectMethod ??= ChangeSelectMethod(TemplateInfo!.Methods[0]);
            set => ChangeSelectMethod(value);
        }

        private MethodBase? selectMethod;
        
        [ObservableProperty] private ObservableCollection<ConfigItemArgInfo>? args;
    }
}
