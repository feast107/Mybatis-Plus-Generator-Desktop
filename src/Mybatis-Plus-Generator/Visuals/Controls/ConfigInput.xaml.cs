using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Mybatis_Plus_Generator.Definition.Abstractions;

namespace Mybatis_Plus_Generator.Visuals.Controls
{
    /// <summary>
    /// ConfigInput.xaml 的交互逻辑
    /// </summary>
    public partial class ConfigInput : UserControl
    {
        public ConfigInput()
        {
            InitializeComponent();
        }

        private void PasswordBox_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is not ConfigItemArgInfo argInfo || sender is not PasswordBox control) return;
            argInfo.ArgValue = control.Password;
        }
    }
}
