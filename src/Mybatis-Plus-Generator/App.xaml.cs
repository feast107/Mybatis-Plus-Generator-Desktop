using Microsoft.Extensions.DependencyInjection;
using Mybatis_Plus_Generator.ViewModels;
using System.Windows;
using Mybatis_Plus_Generator.Core.Extensions;

namespace Mybatis_Plus_Generator;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public App()
    {
        Core.Core.Services.AddDefaultService();
        Core.Core.Services.AddTransient<ConfigItemInfoViewModel>();
        Core.Core.Services.AddTransient<ConfigInfoViewModel>();
        Core.Core.Services.AddTransient<ConfigRecordViewModel>();
        Core.Core.Services.AddTransient<ConfigPageViewModel>();
        Core.Core.Build();
    }
}