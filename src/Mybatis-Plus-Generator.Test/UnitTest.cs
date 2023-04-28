using Microsoft.Extensions.DependencyInjection;
using Mybatis_Plus_Generator.Core.Extensions;
using Mybatis_Plus_Generator.Core.Interfaces;
using Mybatis_Plus_Generator.Extension;

namespace Mybatis_Plus_Generator.Test
{
    public class Tests
    {
        private ITemplateService TemplateService { get; set; }
        private IConfigureService ConfigureService { get; set; }
        private IGenerateService GenerateService { get; set; }
        [SetUp]
        public void Setup()
        {
            Core.Core.Services.AddDefaultService();
            Core.Core.Services.AddViewModels();
            Core.Core.Build();
            TemplateService = Core.Core.Provider.GetRequiredService<ITemplateService>();
            ConfigureService = Core.Core.Provider.GetRequiredService<IConfigureService>();
            GenerateService = Core.Core.Provider.GetRequiredService<IGenerateService>();
        }

        [Test]
        public void Test1()
        {
            Assert.NotNull(GenerateService);
        }

        [Test]
        public void AnotherTest()
        {
            Assert.NotNull(ConfigureService);
        }
    }
}