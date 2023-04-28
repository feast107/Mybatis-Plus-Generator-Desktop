using System.Collections.ObjectModel;
using com.baomidou.mybatisplus.generator.config;
using Microsoft.Extensions.DependencyInjection;
using Mybatis_Plus_Generator.Core.Interfaces;
using Mybatis_Plus_Generator.Definition.Abstractions;

namespace Mybatis_Plus_Generator.Core.Services;

internal class ConfigureService<TConfigRecord,TConfigInfo, TConfigItemInfo> 
    : IConfigureService<TConfigRecord,TConfigInfo, TConfigItemInfo>
    where TConfigRecord : ConfigRecord<TConfigInfo, TConfigItemInfo>
    where TConfigItemInfo : ConfigItemInfo
    where TConfigInfo : ConfigInfo<TConfigItemInfo>
{
    private readonly ITemplateService templateService;
    public ConfigureService(ITemplateService templateService)
    {
        this.templateService = templateService;
    }
    
    public ObservableCollection<TConfigRecord> Records { get; } = new();

    public object?[]? ResolveArgs(TConfigItemInfo configItemInfo)
    {
        var index = 0;
        return !configItemInfo.HasParam
            ? null
            : configItemInfo.SelectMethod
                .GetParameters()
                .Aggregate(new List<object>(), (l, p) =>
                {
                    l.Add(configItemInfo.Args[index++].TransformArg());
                    return l;
                })
                .ToArray();
    }

    public object Apply(object config, TConfigInfo info)
    {
        throw new NotImplementedException();
    }

    public TConfigRecord CreateRecord(string name)
    {
        var record = Records.FirstOrDefault(x => x.ConfigName == name);
        if(record != null)
        {
            return record;
        }
        var pt = templateService.PrimaryTemplate;
        var tmp = Instantiate(pt, pt.Name ?? "");
        record = Core.Provider.GetRequiredService<TConfigRecord>();
        record.ConfigName = name;
        record.FixedConfig = tmp;
        record.Configs = new ObservableCollection<TConfigInfo>() { tmp };
        Records.Add(record);
        return record;
    }

    public TConfigInfo Instantiate(TemplateInfo template, string name)
    {
        var config = Core.Provider.GetRequiredService<TConfigInfo>();
        config.TemplateInfo = template;
        config.ConfigName = name;
        config.ConfigItems = template.Fields.Aggregate(new ObservableCollection<TConfigItemInfo>(), (o, e) =>
        {
            var info = Core.Provider.GetRequiredService<TConfigItemInfo>();
            info.TemplateItemInfo = e;
            info.SelectMethod = e.Methods[0];
            o.Add(info);
            return o;
        });
        return config;
    }
}