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

namespace Mybatis_Plus_Generator.Visuals.Controls
{
    /// <summary>
    /// ConfigItem.xaml 的交互逻辑
    /// </summary>
    public partial class ConfigItem : UserControl
    {
        public ConfigItem()
        {
            InitializeComponent();
        }

        private void UIElement_OnPreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Handled) return;
            e.Handled = true;
            var eventArg = new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta)
            {
                RoutedEvent = MouseWheelEvent,
                Source = sender
            };
            (((Control)sender).Parent as UIElement)?.RaiseEvent(eventArg);
        }
    }
}
