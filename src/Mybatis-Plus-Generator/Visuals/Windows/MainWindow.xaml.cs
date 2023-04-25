using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;
using System.Windows;
using java.util;
using Mybatis_Plus_Generator.Core;
using Mybatis_Plus_Generator.Core.Extensions;
using Mybatis_Plus_Generator.ViewModels;

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
            var dataContext = new ExpandoObject();
            dynamic obj = dataContext;
            var dc = new ObservableCollection<ConfigViewModel>();
            foreach (var pair in ConfigExporter.ExportBuildersFunc())
            {
                dc.Add(new ConfigViewModel()
                {
                    ConfigName = pair.Key,
                    Configs = pair.Value.Aggregate(new Dictionary<string, dynamic>(), (o, c) =>
                    {
                        o.Add(c.Key, new ExpandoObject());
                        return o;
                    })
                });
            }
            this.DataContext = dc;
        }
    }
}
