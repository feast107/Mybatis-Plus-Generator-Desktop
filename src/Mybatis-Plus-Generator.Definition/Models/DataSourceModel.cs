using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Mybatis_Plus_Generator.Definition.Models
{
    public partial class DataSourceModel : ObservableObject
    {
        [ObservableProperty] private string? dbUrl;
        [ObservableProperty] private string? dbUser;
        [ObservableProperty] private string? dbPassword;
        [ObservableProperty] private string? schema;
        [ObservableProperty] private string? dbQuery;
        [ObservableProperty] private string? typeConvert;
        [ObservableProperty] private string? keyWordsHandler;
        [ObservableProperty] private ObservableCollection<KeyValuePair<string, string>> connectionProperties = new();
    }
}
