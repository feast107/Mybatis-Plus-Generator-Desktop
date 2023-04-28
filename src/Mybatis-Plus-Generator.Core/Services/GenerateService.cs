using System.Reflection;
using com.baomidou.mybatisplus.generator;
using Mybatis_Plus_Generator.Core.Interfaces;
using Mybatis_Plus_Generator.Definition.Abstractions;
using Mybatis_Plus_Generator.Definition.Extensions;

namespace Mybatis_Plus_Generator.Core.Services;

internal class GenerateService<TConfigRecord, TConfigInfo, TConfigItemInfo>
    : IGenerateService<TConfigRecord, TConfigInfo, TConfigItemInfo>
    where TConfigRecord : ConfigRecord<TConfigInfo, TConfigItemInfo>
    where TConfigInfo : ConfigInfo<TConfigItemInfo>
    where TConfigItemInfo : ConfigItemInfo
{
    private readonly ITemplateService templateService;
    private readonly IConfigureService<TConfigRecord,TConfigInfo,TConfigItemInfo> configureService;

    public GenerateService(ITemplateService templateService, 
        IConfigureService<TConfigRecord, TConfigInfo, TConfigItemInfo> configureService)
    {
        this.templateService = templateService;
        this.configureService = configureService;
    }

    public async Task Generate(TConfigRecord record)
    {
        (record
            .Configs
            .Aggregate(
                templateService
                    .GeneratorConstructor
                    .Invoke(Generate(record.FixedConfig).AsParameter()),
                (generator, info) =>
                {
                    var config = Generate(info);
                    templateService.GetConfigMethod(info.ConfigType);
                    return generator;
                }) as AutoGenerator)!
            .execute();
        await Task.CompletedTask;
    }

    /// <summary>
    /// 创建一个配置项
    /// </summary>
    /// <param name="configInfo"></param>
    /// <returns></returns>
    private object Generate(TConfigInfo configInfo)
    {
        var builder = configInfo.ConfigItems.FirstOrDefault(x => x.TemplateItemInfo.IsCtor);
        var config = builder != null 
            //有条件构造
            ? (builder.SelectMethod as ConstructorInfo)!.Invoke(configureService.ResolveArgs(builder))! 
            //无条件构造
            : Activator.CreateInstance(configInfo.TemplateInfo.ConfigType)!;
        return Config(config, configInfo);
    }

    /// <summary>
    /// 配置整项
    /// </summary>
    /// <param name="config"></param>
    /// <param name="info"></param>
    /// <returns></returns>
    private object Config(object config, TConfigInfo info) => info.ConfigItems.Aggregate(config, Config);

    /// <summary>
    /// 配置单项
    /// </summary>
    /// <param name="config"></param>
    /// <param name="info"></param>
    /// <returns></returns>
    private object Config(object config, TConfigItemInfo info)
    {
        if (!info.IsEnable) return config;//不启用该项配置
        info.SelectMethod.Invoke(config, info.HasParam
            ? null //无参
            : configureService.ResolveArgs(info)); //解析参数
        return config;
    }
}