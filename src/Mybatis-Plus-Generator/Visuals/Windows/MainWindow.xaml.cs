using Mybatis_Plus_Generator.Core.Extensions;
using Mybatis_Plus_Generator.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Mybatis_Plus_Generator.Core.Interfaces;

namespace Mybatis_Plus_Generator.Visuals.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Core.Core.Services.AddDefaultService();
            Core.Core.Services.AddScoped<ConfigPageViewModel>();
            Core.Core.Build();
            var dc = new ConfigPageViewModel();
            ConfigExporter.ExportConfigs();
            var templateService = Core.Core.Provider.GetRequiredService<ITemplateService>();
            dc.Templates = templateService.ConfigTemplates;
            this.DataContext = dc;
        }
    }
}
