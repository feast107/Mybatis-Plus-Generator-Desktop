using System.Collections.ObjectModel;
using Mybatis_Plus_Generator.Core.Interfaces;
using Mybatis_Plus_Generator.Definition.Abstractions;

namespace Mybatis_Plus_Generator.Core.Services
{
    internal class ConfigureService : IConfigureService
    {
        private readonly ITemplateService templateService;
        public ConfigureService(ITemplateService templateService)
        {
            this.templateService = templateService;
        }

        public ObservableCollection<ConfigRecord> Records { get; } = new ();

        public ConfigRecord CreateRecord(string name)
        {
            var record = Records.FirstOrDefault(x => x.ConfigName == name);
            if(record != null)
            {
                return record;
            }
            var pt = templateService.PrimaryTemplate;
            var tmp = Instantiate(pt, pt.Name ?? "");
            record = new ConfigRecord()
            {
                ConfigName = name,
                FixedConfig = tmp,
                Configs = { tmp }
            };
            
            Records.Add(record);
            return record;
        }

        public ConfigInfo Instantiate(TemplateInfo template, string name)
        {
            return new ConfigInfo()
            {
                TemplateInfo = template,
                ConfigName = name,
                ConfigItems = template.Fields.Aggregate(new ObservableCollection<ConfigItemInfo>(), (o, e) =>
                {
                    o.Add(new ConfigItemInfo()
                    {
                        TemplateInfo = e,
                    });
                    return o;
                })
            };
        }
    }
}
