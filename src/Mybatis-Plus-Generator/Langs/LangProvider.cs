using System.ComponentModel;
using System.Dynamic;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Mybatis_Plus_Generator.Langs;

public class LangProvider : INotifyPropertyChanged 
{
    internal static LangProvider Instance { get; } = Application.Current.TryFindResource(nameof(Langs)) as LangProvider ?? default!;

    private static string? CultureInfoStr;

    public static CultureInfo? Culture
    {
        get => Lang.Culture;
        set
        {
            if (value == null) return;
            if (Equals(CultureInfoStr, value.EnglishName)) return;
            Lang.Culture = value;
            CultureInfoStr = value.EnglishName;

            Instance.UpdateLangs();
        }
    }

    public static string? GetLang(string key)
    {
        return Lang.ResourceManager.GetString(key, Culture);
    }

    public static void SetLang(DependencyObject dependencyObject, DependencyProperty dependencyProperty, string key)
    {
        BindingOperations.SetBinding(dependencyObject, dependencyProperty, new Binding(key)
        {
            Source = Instance,
            Mode = BindingMode.OneWay
        });
    }

	private void UpdateLangs()
    {
		OnPropertyChanged(nameof(Accept));
		OnPropertyChanged(nameof(addConnectionProperty));
		OnPropertyChanged(nameof(addExclude));
		OnPropertyChanged(nameof(addFieldPrefix));
		OnPropertyChanged(nameof(addFieldSuffix));
		OnPropertyChanged(nameof(addInclude));
		OnPropertyChanged(nameof(addTablePrefix));
		OnPropertyChanged(nameof(addTableSuffix));
		OnPropertyChanged(nameof(author));
		OnPropertyChanged(nameof(beforeOutputFile));
		OnPropertyChanged(nameof(Builder));
		OnPropertyChanged(nameof(Cancel));
		OnPropertyChanged(nameof(Can_not_delete_fixed_config));
		OnPropertyChanged(nameof(commentDate));
		OnPropertyChanged(nameof(Config_name_exists));
		OnPropertyChanged(nameof(ConfigName));
		OnPropertyChanged(nameof(controller));
		OnPropertyChanged(nameof(controllerTemplate));
		OnPropertyChanged(nameof(customFile));
		OnPropertyChanged(nameof(customMap));
		OnPropertyChanged(nameof(databaseQueryClass));
		OnPropertyChanged(nameof(DataSourceConfig));
		OnPropertyChanged(nameof(dateType));
		OnPropertyChanged(nameof(dbQuery));
		OnPropertyChanged(nameof(disable));
		OnPropertyChanged(nameof(disableOpenDir));
		OnPropertyChanged(nameof(disableServiceInterface));
		OnPropertyChanged(nameof(disableSqlFilter));
		OnPropertyChanged(nameof(enableCapitalMode));
		OnPropertyChanged(nameof(enableKotlin));
		OnPropertyChanged(nameof(enableSkipView));
		OnPropertyChanged(nameof(enableSpringdoc));
		OnPropertyChanged(nameof(enableSwagger));
		OnPropertyChanged(nameof(entity));
		OnPropertyChanged(nameof(entityTemplate));
		OnPropertyChanged(nameof(fieldPrefix));
		OnPropertyChanged(nameof(fieldSuffixList));
		OnPropertyChanged(nameof(fileOverride));
		OnPropertyChanged(nameof(GlobalConfig));
		OnPropertyChanged(nameof(include));
		OnPropertyChanged(nameof(InjectionConfig));
		OnPropertyChanged(nameof(key));
		OnPropertyChanged(nameof(LangComment));
		OnPropertyChanged(nameof(Language));
		OnPropertyChanged(nameof(mapper));
		OnPropertyChanged(nameof(mapperTemplate));
		OnPropertyChanged(nameof(moduleName));
		OnPropertyChanged(nameof(OK));
		OnPropertyChanged(nameof(outputDir));
		OnPropertyChanged(nameof(PackageConfig));
		OnPropertyChanged(nameof(parent));
		OnPropertyChanged(nameof(password));
		OnPropertyChanged(nameof(pathInfo));
		OnPropertyChanged(nameof(Please_provide_config_name));
		OnPropertyChanged(nameof(service));
		OnPropertyChanged(nameof(serviceImpl));
		OnPropertyChanged(nameof(serviceImplTemplate));
		OnPropertyChanged(nameof(serviceTemplate));
		OnPropertyChanged(nameof(StrategyConfig));
		OnPropertyChanged(nameof(tablePrefixList));
		OnPropertyChanged(nameof(tableSuffixList));
		OnPropertyChanged(nameof(TemplateConfig));
		OnPropertyChanged(nameof(typeConvert));
		OnPropertyChanged(nameof(typeConvertHandler));
		OnPropertyChanged(nameof(url));
		OnPropertyChanged(nameof(username));
		OnPropertyChanged(nameof(value));
		OnPropertyChanged(nameof(xml));
		OnPropertyChanged(nameof(xmlTemplate));
    }

    /// <summary>
    ///   Accept
    /// </summary>
	public string Accept => Lang.Accept;

    /// <summary>
    ///   addConnectionProperty
    /// </summary>
	public string addConnectionProperty => Lang.addConnectionProperty;

    /// <summary>
    ///   addExclude
    /// </summary>
	public string addExclude => Lang.addExclude;

    /// <summary>
    ///   addFieldPrefix
    /// </summary>
	public string addFieldPrefix => Lang.addFieldPrefix;

    /// <summary>
    ///   addFieldSuffix
    /// </summary>
	public string addFieldSuffix => Lang.addFieldSuffix;

    /// <summary>
    ///   addInclude
    /// </summary>
	public string addInclude => Lang.addInclude;

    /// <summary>
    ///   addTablePrefix
    /// </summary>
	public string addTablePrefix => Lang.addTablePrefix;

    /// <summary>
    ///   addTableSuffix
    /// </summary>
	public string addTableSuffix => Lang.addTableSuffix;

    /// <summary>
    ///   author
    /// </summary>
	public string author => Lang.author;

    /// <summary>
    ///   beforeOutputFile
    /// </summary>
	public string beforeOutputFile => Lang.beforeOutputFile;

    /// <summary>
    ///   Builder
    /// </summary>
	public string Builder => Lang.Builder;

    /// <summary>
    ///   Cancel
    /// </summary>
	public string Cancel => Lang.Cancel;

    /// <summary>
    ///   Can_not_delete_fixed_config
    /// </summary>
	public string Can_not_delete_fixed_config => Lang.Can_not_delete_fixed_config;

    /// <summary>
    ///   commentDate
    /// </summary>
	public string commentDate => Lang.commentDate;

    /// <summary>
    ///   Config_name_exists
    /// </summary>
	public string Config_name_exists => Lang.Config_name_exists;

    /// <summary>
    ///   ConfigName
    /// </summary>
	public string ConfigName => Lang.ConfigName;

    /// <summary>
    ///   controller
    /// </summary>
	public string controller => Lang.controller;

    /// <summary>
    ///   controllerTemplate
    /// </summary>
	public string controllerTemplate => Lang.controllerTemplate;

    /// <summary>
    ///   customFile
    /// </summary>
	public string customFile => Lang.customFile;

    /// <summary>
    ///   customMap
    /// </summary>
	public string customMap => Lang.customMap;

    /// <summary>
    ///   databaseQueryClass
    /// </summary>
	public string databaseQueryClass => Lang.databaseQueryClass;

    /// <summary>
    ///   DataSourceConfig
    /// </summary>
	public string DataSourceConfig => Lang.DataSourceConfig;

    /// <summary>
    ///   dateType
    /// </summary>
	public string dateType => Lang.dateType;

    /// <summary>
    ///   dbQuery
    /// </summary>
	public string dbQuery => Lang.dbQuery;

    /// <summary>
    ///   disable
    /// </summary>
	public string disable => Lang.disable;

    /// <summary>
    ///   disableOpenDir
    /// </summary>
	public string disableOpenDir => Lang.disableOpenDir;

    /// <summary>
    ///   disableServiceInterface
    /// </summary>
	public string disableServiceInterface => Lang.disableServiceInterface;

    /// <summary>
    ///   disableSqlFilter
    /// </summary>
	public string disableSqlFilter => Lang.disableSqlFilter;

    /// <summary>
    ///   enableCapitalMode
    /// </summary>
	public string enableCapitalMode => Lang.enableCapitalMode;

    /// <summary>
    ///   enableKotlin
    /// </summary>
	public string enableKotlin => Lang.enableKotlin;

    /// <summary>
    ///   enableSkipView
    /// </summary>
	public string enableSkipView => Lang.enableSkipView;

    /// <summary>
    ///   enableSpringdoc
    /// </summary>
	public string enableSpringdoc => Lang.enableSpringdoc;

    /// <summary>
    ///   enableSwagger
    /// </summary>
	public string enableSwagger => Lang.enableSwagger;

    /// <summary>
    ///   entity
    /// </summary>
	public string entity => Lang.entity;

    /// <summary>
    ///   entityTemplate
    /// </summary>
	public string entityTemplate => Lang.entityTemplate;

    /// <summary>
    ///   fieldPrefix
    /// </summary>
	public string fieldPrefix => Lang.fieldPrefix;

    /// <summary>
    ///   fieldSuffixList
    /// </summary>
	public string fieldSuffixList => Lang.fieldSuffixList;

    /// <summary>
    ///   fileOverride
    /// </summary>
	public string fileOverride => Lang.fileOverride;

    /// <summary>
    ///   GlobalConfig
    /// </summary>
	public string GlobalConfig => Lang.GlobalConfig;

    /// <summary>
    ///   include
    /// </summary>
	public string include => Lang.include;

    /// <summary>
    ///   InjectionConfig
    /// </summary>
	public string InjectionConfig => Lang.InjectionConfig;

    /// <summary>
    ///   key
    /// </summary>
	public string key => Lang.key;

    /// <summary>
    ///   LangComment
    /// </summary>
	public string LangComment => Lang.LangComment;

    /// <summary>
    ///   Language
    /// </summary>
	public string Language => Lang.Language;

    /// <summary>
    ///   mapper
    /// </summary>
	public string mapper => Lang.mapper;

    /// <summary>
    ///   mapperTemplate
    /// </summary>
	public string mapperTemplate => Lang.mapperTemplate;

    /// <summary>
    ///   moduleName
    /// </summary>
	public string moduleName => Lang.moduleName;

    /// <summary>
    ///   OK
    /// </summary>
	public string OK => Lang.OK;

    /// <summary>
    ///   outputDir
    /// </summary>
	public string outputDir => Lang.outputDir;

    /// <summary>
    ///   PackageConfig
    /// </summary>
	public string PackageConfig => Lang.PackageConfig;

    /// <summary>
    ///   parent
    /// </summary>
	public string parent => Lang.parent;

    /// <summary>
    ///   password
    /// </summary>
	public string password => Lang.password;

    /// <summary>
    ///   pathInfo
    /// </summary>
	public string pathInfo => Lang.pathInfo;

    /// <summary>
    ///   Please_provide_config_name
    /// </summary>
	public string Please_provide_config_name => Lang.Please_provide_config_name;

    /// <summary>
    ///   service
    /// </summary>
	public string service => Lang.service;

    /// <summary>
    ///   serviceImpl
    /// </summary>
	public string serviceImpl => Lang.serviceImpl;

    /// <summary>
    ///   serviceImplTemplate
    /// </summary>
	public string serviceImplTemplate => Lang.serviceImplTemplate;

    /// <summary>
    ///   serviceTemplate
    /// </summary>
	public string serviceTemplate => Lang.serviceTemplate;

    /// <summary>
    ///   StrategyConfig
    /// </summary>
	public string StrategyConfig => Lang.StrategyConfig;

    /// <summary>
    ///   tablePrefixList
    /// </summary>
	public string tablePrefixList => Lang.tablePrefixList;

    /// <summary>
    ///   tableSuffixList
    /// </summary>
	public string tableSuffixList => Lang.tableSuffixList;

    /// <summary>
    ///   TemplateConfig
    /// </summary>
	public string TemplateConfig => Lang.TemplateConfig;

    /// <summary>
    ///   typeConvert
    /// </summary>
	public string typeConvert => Lang.typeConvert;

    /// <summary>
    ///   typeConvertHandler
    /// </summary>
	public string typeConvertHandler => Lang.typeConvertHandler;

    /// <summary>
    ///   url
    /// </summary>
	public string url => Lang.url;

    /// <summary>
    ///   username
    /// </summary>
	public string username => Lang.username;

    /// <summary>
    ///   value
    /// </summary>
	public string value => Lang.value;

    /// <summary>
    ///   xml
    /// </summary>
	public string xml => Lang.xml;

    /// <summary>
    ///   xmlTemplate
    /// </summary>
	public string xmlTemplate => Lang.xmlTemplate;


    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public class LangKeys
{
    /// <summary>
    ///   Accept
    /// </summary>
	public static string Accept = nameof(Accept);

    /// <summary>
    ///   addConnectionProperty
    /// </summary>
	public static string addConnectionProperty = nameof(addConnectionProperty);

    /// <summary>
    ///   addExclude
    /// </summary>
	public static string addExclude = nameof(addExclude);

    /// <summary>
    ///   addFieldPrefix
    /// </summary>
	public static string addFieldPrefix = nameof(addFieldPrefix);

    /// <summary>
    ///   addFieldSuffix
    /// </summary>
	public static string addFieldSuffix = nameof(addFieldSuffix);

    /// <summary>
    ///   addInclude
    /// </summary>
	public static string addInclude = nameof(addInclude);

    /// <summary>
    ///   addTablePrefix
    /// </summary>
	public static string addTablePrefix = nameof(addTablePrefix);

    /// <summary>
    ///   addTableSuffix
    /// </summary>
	public static string addTableSuffix = nameof(addTableSuffix);

    /// <summary>
    ///   author
    /// </summary>
	public static string author = nameof(author);

    /// <summary>
    ///   beforeOutputFile
    /// </summary>
	public static string beforeOutputFile = nameof(beforeOutputFile);

    /// <summary>
    ///   Builder
    /// </summary>
	public static string Builder = nameof(Builder);

    /// <summary>
    ///   Cancel
    /// </summary>
	public static string Cancel = nameof(Cancel);

    /// <summary>
    ///   Can_not_delete_fixed_config
    /// </summary>
	public static string Can_not_delete_fixed_config = nameof(Can_not_delete_fixed_config);

    /// <summary>
    ///   commentDate
    /// </summary>
	public static string commentDate = nameof(commentDate);

    /// <summary>
    ///   Config_name_exists
    /// </summary>
	public static string Config_name_exists = nameof(Config_name_exists);

    /// <summary>
    ///   ConfigName
    /// </summary>
	public static string ConfigName = nameof(ConfigName);

    /// <summary>
    ///   controller
    /// </summary>
	public static string controller = nameof(controller);

    /// <summary>
    ///   controllerTemplate
    /// </summary>
	public static string controllerTemplate = nameof(controllerTemplate);

    /// <summary>
    ///   customFile
    /// </summary>
	public static string customFile = nameof(customFile);

    /// <summary>
    ///   customMap
    /// </summary>
	public static string customMap = nameof(customMap);

    /// <summary>
    ///   databaseQueryClass
    /// </summary>
	public static string databaseQueryClass = nameof(databaseQueryClass);

    /// <summary>
    ///   DataSourceConfig
    /// </summary>
	public static string DataSourceConfig = nameof(DataSourceConfig);

    /// <summary>
    ///   dateType
    /// </summary>
	public static string dateType = nameof(dateType);

    /// <summary>
    ///   dbQuery
    /// </summary>
	public static string dbQuery = nameof(dbQuery);

    /// <summary>
    ///   disable
    /// </summary>
	public static string disable = nameof(disable);

    /// <summary>
    ///   disableOpenDir
    /// </summary>
	public static string disableOpenDir = nameof(disableOpenDir);

    /// <summary>
    ///   disableServiceInterface
    /// </summary>
	public static string disableServiceInterface = nameof(disableServiceInterface);

    /// <summary>
    ///   disableSqlFilter
    /// </summary>
	public static string disableSqlFilter = nameof(disableSqlFilter);

    /// <summary>
    ///   enableCapitalMode
    /// </summary>
	public static string enableCapitalMode = nameof(enableCapitalMode);

    /// <summary>
    ///   enableKotlin
    /// </summary>
	public static string enableKotlin = nameof(enableKotlin);

    /// <summary>
    ///   enableSkipView
    /// </summary>
	public static string enableSkipView = nameof(enableSkipView);

    /// <summary>
    ///   enableSpringdoc
    /// </summary>
	public static string enableSpringdoc = nameof(enableSpringdoc);

    /// <summary>
    ///   enableSwagger
    /// </summary>
	public static string enableSwagger = nameof(enableSwagger);

    /// <summary>
    ///   entity
    /// </summary>
	public static string entity = nameof(entity);

    /// <summary>
    ///   entityTemplate
    /// </summary>
	public static string entityTemplate = nameof(entityTemplate);

    /// <summary>
    ///   fieldPrefix
    /// </summary>
	public static string fieldPrefix = nameof(fieldPrefix);

    /// <summary>
    ///   fieldSuffixList
    /// </summary>
	public static string fieldSuffixList = nameof(fieldSuffixList);

    /// <summary>
    ///   fileOverride
    /// </summary>
	public static string fileOverride = nameof(fileOverride);

    /// <summary>
    ///   GlobalConfig
    /// </summary>
	public static string GlobalConfig = nameof(GlobalConfig);

    /// <summary>
    ///   include
    /// </summary>
	public static string include = nameof(include);

    /// <summary>
    ///   InjectionConfig
    /// </summary>
	public static string InjectionConfig = nameof(InjectionConfig);

    /// <summary>
    ///   key
    /// </summary>
	public static string key = nameof(key);

    /// <summary>
    ///   LangComment
    /// </summary>
	public static string LangComment = nameof(LangComment);

    /// <summary>
    ///   Language
    /// </summary>
	public static string Language = nameof(Language);

    /// <summary>
    ///   mapper
    /// </summary>
	public static string mapper = nameof(mapper);

    /// <summary>
    ///   mapperTemplate
    /// </summary>
	public static string mapperTemplate = nameof(mapperTemplate);

    /// <summary>
    ///   moduleName
    /// </summary>
	public static string moduleName = nameof(moduleName);

    /// <summary>
    ///   OK
    /// </summary>
	public static string OK = nameof(OK);

    /// <summary>
    ///   outputDir
    /// </summary>
	public static string outputDir = nameof(outputDir);

    /// <summary>
    ///   PackageConfig
    /// </summary>
	public static string PackageConfig = nameof(PackageConfig);

    /// <summary>
    ///   parent
    /// </summary>
	public static string parent = nameof(parent);

    /// <summary>
    ///   password
    /// </summary>
	public static string password = nameof(password);

    /// <summary>
    ///   pathInfo
    /// </summary>
	public static string pathInfo = nameof(pathInfo);

    /// <summary>
    ///   Please_provide_config_name
    /// </summary>
	public static string Please_provide_config_name = nameof(Please_provide_config_name);

    /// <summary>
    ///   service
    /// </summary>
	public static string service = nameof(service);

    /// <summary>
    ///   serviceImpl
    /// </summary>
	public static string serviceImpl = nameof(serviceImpl);

    /// <summary>
    ///   serviceImplTemplate
    /// </summary>
	public static string serviceImplTemplate = nameof(serviceImplTemplate);

    /// <summary>
    ///   serviceTemplate
    /// </summary>
	public static string serviceTemplate = nameof(serviceTemplate);

    /// <summary>
    ///   StrategyConfig
    /// </summary>
	public static string StrategyConfig = nameof(StrategyConfig);

    /// <summary>
    ///   tablePrefixList
    /// </summary>
	public static string tablePrefixList = nameof(tablePrefixList);

    /// <summary>
    ///   tableSuffixList
    /// </summary>
	public static string tableSuffixList = nameof(tableSuffixList);

    /// <summary>
    ///   TemplateConfig
    /// </summary>
	public static string TemplateConfig = nameof(TemplateConfig);

    /// <summary>
    ///   typeConvert
    /// </summary>
	public static string typeConvert = nameof(typeConvert);

    /// <summary>
    ///   typeConvertHandler
    /// </summary>
	public static string typeConvertHandler = nameof(typeConvertHandler);

    /// <summary>
    ///   url
    /// </summary>
	public static string url = nameof(url);

    /// <summary>
    ///   username
    /// </summary>
	public static string username = nameof(username);

    /// <summary>
    ///   value
    /// </summary>
	public static string value = nameof(value);

    /// <summary>
    ///   xml
    /// </summary>
	public static string xml = nameof(xml);

    /// <summary>
    ///   xmlTemplate
    /// </summary>
	public static string xmlTemplate = nameof(xmlTemplate);

}
