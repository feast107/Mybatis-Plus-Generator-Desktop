using System.Collections.ObjectModel;
using Mybatis_Plus_Generator.Definition.Abstractions;

namespace Mybatis_Plus_Generator.Core.Interfaces;

public interface IConfigureService<TConfigRecord,out TConfigInfo,in TConfigItemInfo>
    where TConfigRecord : ConfigRecord<TConfigInfo, TConfigItemInfo>
    where TConfigInfo : ConfigInfo<TConfigItemInfo>
    where TConfigItemInfo : ConfigItemInfo
{
    /// <summary>
    /// 解析参数
    /// </summary>
    /// <param name="configInfo">配置信息</param>
    /// <returns></returns>
    object?[]? ResolveArgs(TConfigItemInfo configInfo);
    /// <summary>
    /// 所有的配置记录
    /// </summary>
    ObservableCollection<TConfigRecord> Records { get; }
    /// <summary>
    /// 创建一个配置
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    TConfigRecord CreateRecord(string name);
    /// <summary>
    /// 实例化一个模板
    /// </summary>
    /// <param name="template"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    TConfigInfo Instantiate(TemplateInfo template, string name);
}