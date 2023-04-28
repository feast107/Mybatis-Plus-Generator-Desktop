using Microsoft.Extensions.DependencyInjection;
using Mybatis_Plus_Generator.ViewModels;
using System.Windows;
using Mybatis_Plus_Generator.Core.Extensions;
using Mybatis_Plus_Generator.Extension;

namespace Mybatis_Plus_Generator;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public App()
    {
        Core.Core.Services.AddDefaultService();
        Core.Core.Services.AddViewModels();
        Core.Core.Build();
    }
}