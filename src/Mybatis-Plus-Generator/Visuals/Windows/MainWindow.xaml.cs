using Mybatis_Plus_Generator.Core.Extensions;
using Mybatis_Plus_Generator.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using MaterialDesignThemes.Wpf;
using Microsoft.Extensions.DependencyInjection;
using Mybatis_Plus_Generator.Core.Interfaces;
using Mybatis_Plus_Generator.Visuals.Controls;
using MaterialDesignColors;
using Mybatis_Plus_Generator.Extension;

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
            Core.Core.Services.AddTransient<ConfigPageViewModel>();
            Core.Core.Build();
            var dc = Core.Core.Provider.GetRequiredService<ConfigPageViewModel>();
            ConfigExporter.ExportConfigs();
            var templateService = Core.Core.Provider.GetRequiredService<ITemplateService>();
            var configureService = Core.Core.Provider.GetRequiredService<IConfigureService>();
            dc.Records = configureService.Records;
            if (configureService.Records.Count == 0)
            {
                dc.Current = configureService.CreateRecord("默认配置");
            }
            dc.Templates = templateService.AdditionalTemplates;
            Page.DataContext = dc;

            Color.FromRgb(12, 174, 135).SetTheme();
        }
    }
}
