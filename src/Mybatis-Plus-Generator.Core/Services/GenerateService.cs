using Mybatis_Plus_Generator.Core.Interfaces;
using Mybatis_Plus_Generator.Definition.Abstractions;

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

    public Task<bool> Generate(TConfigRecord record)
    {
        throw new NotImplementedException();
        record.Configs.Aggregate(
            templateService.GeneratorConstructor.Invoke( new []{Config(record.FixedConfig!)}), (o, e) => o);
    }

    private object Config(TConfigInfo configInfo)
    {
        var builder = configInfo.ConfigItems.FirstOrDefault(x => x.TemplateInfo.IsCtor);
        object config;
        if (builder == null)
        {
            var ctorArgs = builder!.Args.Select(x=>(object)x).ToArray();
            config = builder.SelectMethod.Invoke(null, ctorArgs)!;
        }
        else
        {
            config = Activator.CreateInstance(configInfo.TemplateInfo!.ConfigType!)!;
        }
        return Config(config, configInfo);
    }

    private object Config(object config, TConfigInfo configInfo)
    {
        return configInfo.ConfigItems.Aggregate(config,Config);
    }

    private object Config(object config, ConfigItemInfo item)
    {
        if (!item.IsEnable) return config;
        item.SelectMethod.Invoke(config, item.SelectMethod.GetParameters().Length == 0
            ? null
            : item.Args!
                .Select(x => (object?)x.ArgValue)
                .ToArray());
        return config;
    }
}