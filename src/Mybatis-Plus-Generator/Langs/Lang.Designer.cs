﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mybatis_Plus_Generator.Langs {
    using System;
    
    
    /// <summary>
    ///   一个强类型的资源类，用于查找本地化的字符串等。
    /// </summary>
    // 此类是由 StronglyTypedResourceBuilder
    // 类通过类似于 ResGen 或 Visual Studio 的工具自动生成的。
    // 若要添加或移除成员，请编辑 .ResX 文件，然后重新运行 ResGen
    // (以 /str 作为命令选项)，或重新生成 VS 项目。
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Lang {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Lang() {
        }
        
        /// <summary>
        ///   返回此类使用的缓存的 ResourceManager 实例。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Mybatis_Plus_Generator.Langs.Lang", typeof(Lang).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   重写当前线程的 CurrentUICulture 属性，对
        ///   使用此强类型资源类的所有资源查找执行重写。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   查找类似 数据源配置 的本地化字符串。
        /// </summary>
        public static string DataSourceConfig {
            get {
                return ResourceManager.GetString("DataSourceConfig", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 全局配置 的本地化字符串。
        /// </summary>
        public static string GlobalConfig {
            get {
                return ResourceManager.GetString("GlobalConfig", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 注入配置 的本地化字符串。
        /// </summary>
        public static string InjectionConfig {
            get {
                return ResourceManager.GetString("InjectionConfig", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 查找 {0} 的本地化内容 的本地化字符串。
        /// </summary>
        public static string LangComment {
            get {
                return ResourceManager.GetString("LangComment", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 中文 的本地化字符串。
        /// </summary>
        public static string Language {
            get {
                return ResourceManager.GetString("Language", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 包配置 的本地化字符串。
        /// </summary>
        public static string PackageConfig {
            get {
                return ResourceManager.GetString("PackageConfig", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 策略配置 的本地化字符串。
        /// </summary>
        public static string StrategyConfig {
            get {
                return ResourceManager.GetString("StrategyConfig", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 模板配置 的本地化字符串。
        /// </summary>
        public static string TemplateConfig {
            get {
                return ResourceManager.GetString("TemplateConfig", resourceCulture);
            }
        }
    }
}
