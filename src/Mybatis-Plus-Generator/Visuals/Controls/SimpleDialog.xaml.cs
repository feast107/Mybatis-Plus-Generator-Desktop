using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mybatis_Plus_Generator.Visuals.Controls;

/// <summary>
/// SimpleDialog.xaml 的交互逻辑
/// </summary>
public partial class SimpleDialog : UserControl
{
    public static async Task<object?> Show(string content, string host)
    {
        return await DialogHost.Show(new SimpleDialog(content), host);
    }
    public SimpleDialog(string text)
    {
        InitializeComponent();
        this.Text.Tag = text;
    }
}