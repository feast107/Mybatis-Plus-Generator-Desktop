using Mybatis_Plus_Generator.Definition.Abstractions;
using System.Collections.ObjectModel;
using System.Reflection;

namespace Mybatis_Plus_Generator.Core.Interfaces;

/// <summary>
/// 模板服务
/// </summary>
public interface ITemplateService
{
    /// <summary>
    /// 生成器的构造函数
    /// </summary>
    ConstructorInfo GeneratorConstructor { get; }
    /// <summary>
    /// 首要模板信息
    /// </summary>
    TemplateInfo PrimaryTemplate { get; }
    /// <summary>
    /// 可选的模板信息
    /// </summary>
    ObservableCollection<TemplateInfo> AdditionalTemplates { get; }
}