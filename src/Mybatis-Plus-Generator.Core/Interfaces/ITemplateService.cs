using Mybatis_Plus_Generator.Definition.Abstractions;
using System.Collections.ObjectModel;

namespace Mybatis_Plus_Generator.Core.Interfaces
{
    /// <summary>
    /// 模板服务
    /// </summary>
    public interface ITemplateService
    {
        ObservableCollection<TemplateInfo> ConfigTemplates { get; }
    }
}
