using System.Threading.Tasks;
using System.Windows.Controls;
using MaterialDesignThemes.Wpf;

namespace Mybatis_Plus_Generator.Visuals.Controls.Dialogs;

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