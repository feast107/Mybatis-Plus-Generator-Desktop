using Mybatis_Plus_Generator.Definition.Abstractions;
using System.Windows;

namespace Mybatis_Plus_Generator.Converters
{
    internal class SwitchAddConverter : EnumToVisibilityConverter<ConfigItemInfo.SwitchCondition>
    {
        protected override Visibility Condition(ConfigItemInfo.SwitchCondition condition)
        {
            return condition switch
            {
                ConfigItemInfo.SwitchCondition.ShowAdd => Visibility.Visible,
                _ => Visibility.Collapsed
            };
        }
    }

    internal class SwitchRemoveConverter : EnumToVisibilityConverter<ConfigItemInfo.SwitchCondition>
    {
        protected override Visibility Condition(ConfigItemInfo.SwitchCondition condition)
        {
            return condition switch
            {
                ConfigItemInfo.SwitchCondition.ShowRemove => Visibility.Visible,
                _ => Visibility.Collapsed
            };
        }
    }
    internal class SwitchNoneConverter : EnumToVisibilityConverter<ConfigItemInfo.SwitchCondition>
    {
        protected override Visibility Condition(ConfigItemInfo.SwitchCondition condition)
        {
            return condition switch
            {
                ConfigItemInfo.SwitchCondition.None => Visibility.Visible,
                _ => Visibility.Collapsed
            };
        }
    }
}
