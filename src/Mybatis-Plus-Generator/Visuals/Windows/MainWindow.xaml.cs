using Mybatis_Plus_Generator.Core.Extensions;
using Mybatis_Plus_Generator.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Media;
using MaterialDesignThemes.Wpf;
using Microsoft.Extensions.DependencyInjection;
using Mybatis_Plus_Generator.Core.Interfaces;
using Mybatis_Plus_Generator.Visuals.Controls;
using MaterialDesignColors;
using Mybatis_Plus_Generator.Definition.Abstractions;
using Mybatis_Plus_Generator.Extension;
using IConfigureService =
    Mybatis_Plus_Generator.Core.Interfaces.IConfigureService<
        Mybatis_Plus_Generator.ViewModels.ConfigRecordViewModel,
        Mybatis_Plus_Generator.ViewModels.ConfigInfoViewModel,
        Mybatis_Plus_Generator.ViewModels.ConfigItemInfoViewModel>;

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
            Core.Core.Services.AddTransient<ConfigItemInfoViewModel>();
            Core.Core.Services.AddTransient<ConfigInfoViewModel>();
            Core.Core.Services.AddTransient<ConfigRecordViewModel>();
            Core.Core.Services.AddTransient<ConfigPageViewModel>();
            Core.Core.Build();
            var templateService = Core.Core.Provider.GetRequiredService<ITemplateService>();
            var configureService = Core.Core.Provider.GetRequiredService<IConfigureService>();
            var dc = Core.Core.Provider.GetRequiredService<ConfigPageViewModel>();
            this.DataContext = dc;
            dc.Records = configureService.Records;
            if (configureService.Records.Count == 0)
            {
                dc.Current = configureService.CreateRecord("默认配置");
            }
            dc.Templates = templateService.AdditionalTemplates;
            Color.FromRgb(12, 174, 135).SetTheme();
        }
    }
}
