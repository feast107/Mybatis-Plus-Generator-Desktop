using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;
using Mybatis_Plus_Generator.Langs;

namespace Mybatis_Plus_Generator.Extension;

public class LangExtension : MarkupExtension
{
    private readonly DependencyObject proxy;
    private static readonly ExpandoObject Target = new();

    public LangExtension()
    {
        proxy = new DependencyObject();
        Source = LangProvider.Instance;
        var ps = typeof(LangProvider);
        LangProvider.Instance.PropertyChanged += (o, e) =>
        {
            ((IDictionary<string, object>)Target!)[e.PropertyName!] =
                typeof(LangProvider)
                    .GetProperty(e.PropertyName!)!
                    .GetValue(o)!;
        };
    }

    public LangExtension(string key) : this()
    {
        Key = key;
    }

    public static readonly DependencyProperty KeyProperty = DependencyProperty.RegisterAttached(
        nameof(Key), typeof(object), typeof(LangExtension), new PropertyMetadata(default));

    public object? Key
    {
        get => proxy.GetValue(KeyProperty);
        set => proxy.SetValue(KeyProperty, value);
    }

    public PropertyPath? Binding { get; set; }

    private static readonly DependencyProperty TargetPropertyProperty = DependencyProperty.RegisterAttached(
        "TargetProperty", typeof(DependencyProperty), typeof(LangExtension),
        new PropertyMetadata(default(DependencyProperty)));

    private static void SetTargetProperty(DependencyObject element, DependencyProperty value)
        => element.SetValue(TargetPropertyProperty, value);

    private static DependencyProperty GetTargetProperty(DependencyObject element)
        => (DependencyProperty)element.GetValue(TargetPropertyProperty);

    public BindingMode Mode { get; set; }

    public required IValueConverter Converter { get; set; }

    public required object ConverterParameter { get; set; }

    public object Source { get; set; }

    public override object? ProvideValue(IServiceProvider serviceProvider)
    {
        if (serviceProvider.GetService(typeof(IProvideValueTarget)) is not IProvideValueTarget provideValueTarget)
            return this;
        if (provideValueTarget.TargetObject.GetType().FullName == "System.Windows.SharedDp") return this;
        if (provideValueTarget.TargetObject is not DependencyObject targetObject) return this;
        if (provideValueTarget.TargetProperty is not DependencyProperty targetProperty) return this;

        switch (Key)
        {
            case string key:
            {
                var binding = CreateLangBinding(key);
                BindingOperations.SetBinding(targetObject, targetProperty, binding);
                return binding.ProvideValue(serviceProvider);
            }
            case Binding keyBinding when targetObject is FrameworkElement element:
            {
                if (element.DataContext != null)
                {
                    return SetLangBinding(element, 
                            targetProperty, 
                            keyBinding.Path, 
                            element.DataContext)?
                        .ProvideValue(serviceProvider);
                }

                SetTargetProperty(element, targetProperty);
                element.DataContextChanged += LangExtension_DataContextChanged;

                break;
            }
            case Binding keyBinding when targetObject is FrameworkContentElement element:
            {
                if (element.DataContext != null)
                {
                    return SetLangBinding(element, targetProperty, keyBinding.Path, element.DataContext)!
                        .ProvideValue(serviceProvider);
                }

                SetTargetProperty(element, targetProperty);
                element.DataContextChanged += LangExtension_DataContextChanged;

                break;
            }
        }

        return string.Empty;
    }

    private void LangExtension_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        switch (sender)
        {
            case FrameworkElement element:
            {
                element.DataContextChanged -= LangExtension_DataContextChanged;
                if (Key is not Binding keyBinding) return;

                var targetProperty = GetTargetProperty(element);
                SetTargetProperty(element, null!);
                SetLangBinding(element, targetProperty, keyBinding.Path, element.DataContext);
                break;
            }
            case FrameworkContentElement element:
            {
                element.DataContextChanged -= LangExtension_DataContextChanged;
                if (Key is not Binding keyBinding) return;

                var targetProperty = GetTargetProperty(element);
                SetTargetProperty(element, null!);
                SetLangBinding(element, targetProperty, keyBinding.Path, element.DataContext);
                break;
            }
        }
    }

    private BindingBase? SetLangBinding(
        DependencyObject targetObject,
        DependencyProperty? targetProperty,
        PropertyPath path, object dataContext)
    {
        if (targetProperty == null) 
            return null;

        BindingOperations.SetBinding(targetObject, targetProperty, new Binding
        {
            Path = path,
            Source = dataContext,
            Mode = BindingMode.OneWay,
        });

        var key = targetObject.GetValue(targetProperty) as string;
        if (string.IsNullOrEmpty(key)) 
            return null;

        var binding = CreateLangBinding(key);
        BindingOperations.SetBinding(targetObject, targetProperty, binding);
        return binding;
    }

    private BindingBase CreateLangBinding(string key) => new Binding(key)
    {
        Converter = Converter,
        ConverterParameter = ConverterParameter,
        UpdateSourceTrigger = UpdateSourceTrigger.Explicit,
        Source = TryFind(Target, key),
        Mode = BindingMode.OneWay
    };

    private static object TryFind(IDictionary<string, object?> target, string key)
    {
        if (!target.ContainsKey(key))
        {
            target[key] = key;
        }
        return target;
    }
}
