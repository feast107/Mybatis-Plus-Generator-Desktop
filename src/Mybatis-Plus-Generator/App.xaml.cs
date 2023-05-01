using Mybatis_Plus_Generator.Core.Extensions;
using Mybatis_Plus_Generator.Extension;
using Mybatis_Plus_Generator.Langs;
using System.Globalization;
using System.Windows;
using System.Windows.Markup;

namespace Mybatis_Plus_Generator;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public App()
    {
        
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        Core.Core.Services.AddDefaultService();
        Core.Core.Services.AddViewModels();
        Core.Core.Build();
    }
}