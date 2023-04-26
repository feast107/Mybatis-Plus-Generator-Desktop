using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Reflection;

namespace Mybatis_Plus_Generator.Definition.Abstractions
{
    public partial class TemplateItemInfo : ObservableObject
    {
        [ObservableProperty] private string? fieldName;
        [ObservableProperty] bool allowMultiple;
        [ObservableProperty] private ObservableCollection<MethodInfo> methods = new();
    }
}
