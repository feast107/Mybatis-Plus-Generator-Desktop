using MaterialDesignThemes.Wpf;
using Microsoft.Extensions.DependencyInjection;
using Mybatis_Plus_Generator.Core.Extensions;
using Mybatis_Plus_Generator.Core.Interfaces;
using Mybatis_Plus_Generator.Extension;
using Mybatis_Plus_Generator.ViewModels;
using System.Windows;
using System.Windows.Media;


namespace Mybatis_Plus_Generator.Visuals.Windows;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        Color.FromRgb(12, 174, 165)
            .SetTheme();
        Loaded += OnLoaded;
    }

    private void OnLoaded(object sender, RoutedEventArgs e)
    {
        var templateService = Core.Core.Provider.GetRequiredService<ITemplateService>();
        var configureService = Core.Core.Provider.GetRequiredService<IConfigureService>();
        var dc = Core.Core.Provider.GetRequiredService<ConfigPageViewModel>();
        DataContext = dc;
        dc.Records = configureService.Records;
        dc.Templates = templateService.AdditionalTemplates;
    }
}