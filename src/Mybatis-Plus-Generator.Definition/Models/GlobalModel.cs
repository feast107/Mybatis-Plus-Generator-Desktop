using System;
using System.Collections.Generic;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Mybatis_Plus_Generator.Definition.Models
{
    public partial class GlobalModel : ObservableObject
    {
        [ObservableProperty] private string? outputDir;
        [ObservableProperty] private string? author;
        [ObservableProperty] private bool enableKotlin;
        [ObservableProperty] private bool enableSwagger = true;
        [ObservableProperty] private bool enableSpringDoc = true;
        [ObservableProperty] private int dateType;
        [ObservableProperty] private string commentDate = "yyyy-MM-dd";
    }
}
