using Newtonsoft.Json;
using Reflection.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Reflection.Main;

class Program
{
    static void Main(string[] args)
    {
        //RunPluginTutorial();
        RunUnknownTypeTutorial();
    }

    private static void RunUnknownTypeTutorial()
    {
        object obj = new InformationContainer
        {
            Age = 26,
            Name = "Mehmet",
            Placeholder = "Hold the Door !",
        };

        Type type = obj.GetType();

        //// Properties - Unknown
        HandleUnknownPropertiesAndFields(type, obj);
        Console.WriteLine(new string('-', 32));

        //// Properties - Known
        HandleKnownPropertiesAndFields(type, obj, "MyField");
        Console.WriteLine(new string('-', 32));
        HandleKnownPropertiesAndFields(type, obj, "Name");
        Console.WriteLine(new string('-', 32));
        HandleKnownPropertiesAndFields(type, obj, "CompanyName");
        Console.WriteLine(new string('-', 32));
        HandleKnownPropertiesAndFields(type, obj, "Age");
        Console.WriteLine(new string('-', 32));
        HandleKnownPropertiesAndFields(type, obj, "Placeholder");
        Console.WriteLine(new string('-', 32));

        // Methods - Known
        HandleMethods(type, obj);


        Console.WriteLine(JsonConvert.SerializeObject(obj));

    }

    private static void HandleMethods(Type type, object obj)
    {
        MethodInfo[] methods = type.GetMethods();

        foreach (MethodInfo method in methods)
        {
            Console.WriteLine($"Method Name : {method.Name}");

            Type returnType = method.ReturnType;
            Console.WriteLine($"Method ReturnType : {returnType.Name}");


            ParameterInfo[] parameters = method.GetParameters();
            Console.WriteLine($"Method Parameters : {string.Join(',', parameters.Select(p => $"{p.Name},{p.ParameterType.Name}"))}");

        }
        Console.WriteLine(new string('-', 32));

        MethodInfo methodInfo = type.GetMethod("WriteToScreen", Array.Empty<Type>());
        Console.WriteLine($"Method Name : {methodInfo.Name}");
        methodInfo.Invoke(obj, null);


        MethodInfo methodInfoOverload = type.GetMethod("WriteToScreen", new Type[] { typeof(string)});
        Console.WriteLine($"Method Name : {methodInfoOverload.Name} Overload");
        methodInfoOverload.Invoke(obj, new[] { "Mehmet" });


        MethodInfo sumMethodInfo = type.GetMethod("Sum");
        Console.WriteLine($"Method Name : {sumMethodInfo.Name} Overload");
        object result = sumMethodInfo.Invoke(obj, new object[] { 12 });
        Console.WriteLine($"Sum Method Result : {result}");
        Console.WriteLine(new string('-', 32));

    }

    private static void HandleKnownPropertiesAndFields(Type type, object obj, string propertyOrFieldName)
    {
        Console.WriteLine("HandleKnownPropertiesAndFields");

        PropertyInfo property = type.GetProperty(propertyOrFieldName);

        if (property is not null)
        {

            Console.WriteLine($"Property Name : {property.Name}");

            object propertyValue = property.GetValue(obj);

            Console.WriteLine($"Property Value : {propertyValue}");

            if (property.CanWrite)
            {
                if (property.PropertyType == typeof(int))
                {
                    property.SetValue(obj, 30);
                }
                else
                {
                    property.SetValue(obj, propertyValue + "2");
                }

                object newPropertyValue = property.GetValue(obj);

                Console.WriteLine($"New Property Value : {newPropertyValue}");
            }

            DisplayAttribute displayAttribute = property.GetCustomAttribute<DisplayAttribute>();

            if (displayAttribute is not null)
            {
                Console.WriteLine($"Display attribute value : {displayAttribute.Name}");
            }
        }

        FieldInfo field = type.GetField(propertyOrFieldName);

        if (field is not null)
        {
            Console.WriteLine($"Field Name : {field.Name}");

            object propertyValue = field.GetValue(obj);

            Console.WriteLine($"Field Value : {propertyValue}");

            if (field.FieldType == typeof(int))
            {
                field.SetValue(obj, 30);
            }
            else
            {
                field.SetValue(obj, propertyValue + "2");
            }

            object newPropertyValue = field.GetValue(obj);

            Console.WriteLine($"New Field Value : {newPropertyValue}");

            DisplayAttribute displayAttribute = field.GetCustomAttribute<DisplayAttribute>();

            if (displayAttribute is not null)
            {
                Console.WriteLine($"Display attribute value : {displayAttribute.Name}");
            }
        }
    }

    private static void HandleUnknownPropertiesAndFields(Type type, object obj)
    {
        Console.WriteLine("HandleUnknownPropertiesAndFields");
        PropertyInfo[] properties = type.GetProperties();

        foreach (PropertyInfo property in properties)
        {
            Console.WriteLine($"Property Name : {property.Name}");

            object propertyValue = property.GetValue(obj);

            Console.WriteLine($"Property Value : {propertyValue}");

            if (property.CanWrite)
            {
                if (property.PropertyType == typeof(int))
                {
                    property.SetValue(obj, 30);
                }
                else
                {
                    property.SetValue(obj, propertyValue + "2");
                }

                object newPropertyValue = property.GetValue(obj);

                Console.WriteLine($"New Property Value : {newPropertyValue}");
            }

            DisplayAttribute displayAttribute = property.GetCustomAttribute<DisplayAttribute>();

            if (displayAttribute is not null)
            {
                Console.WriteLine($"Display attribute value : {displayAttribute.Name}");
            }

        }

        FieldInfo[] fields = type.GetFields();

        foreach (FieldInfo field in fields)
        {
            Console.WriteLine($"Field Name : {field.Name}");

            object propertyValue = field.GetValue(obj);

            Console.WriteLine($"Field Value : {propertyValue}");

            if (field.FieldType == typeof(int))
            {
                field.SetValue(obj, 30);
            }
            else
            {
                field.SetValue(obj, propertyValue + "2");
            }

            object newPropertyValue = field.GetValue(obj);

            Console.WriteLine($"New Field Value : {newPropertyValue}");

            DisplayAttribute displayAttribute = field.GetCustomAttribute<DisplayAttribute>();

            if (displayAttribute is not null)
            {
                Console.WriteLine($"Display attribute value : {displayAttribute.Name}");
            }

        }
    }

    private static void RunPluginTutorial()
    {
        string pluginSourcePath = @"C:\Projects\Tutorial\CSharpTraining\Training\Reflection\Reflection.Main\Plugins";

        string[] pluginDlls = Directory.GetFiles(pluginSourcePath);

        List<IPlugin> plugins = new();

        foreach (string path in pluginDlls)
        {
            Assembly pluginAssembly = Assembly.LoadFrom(path);
            var assemblyPlugins = pluginAssembly.GetTypes().Where(type => typeof(IPlugin).IsAssignableFrom(type)).Select(type => Activator.CreateInstance(type) as IPlugin);

            plugins.AddRange(assemblyPlugins);
        }

        Console.WriteLine("Available Plugins : ");
        Console.WriteLine();
        Console.WriteLine();

        foreach (IPlugin plugin in plugins)
        {
            Console.WriteLine("Name : " + plugin.PluginName);
            Console.WriteLine("Description : " + plugin.PluginDescription);
            Console.WriteLine();
        }

        Console.WriteLine(new string('-', 32));


        foreach (IPlugin plugin in plugins)
        {
            Console.WriteLine("Name : " + plugin.PluginName);
            plugin.Invoke();

            Console.WriteLine(new string('-', 32));
        }


        foreach (IPlugin plugin in plugins)
        {
            Console.WriteLine("Name : " + plugin.PluginName);
            Console.WriteLine("Lütfen veri giriniz.");

            string data = Console.ReadLine();
            plugin.Data = data;
            plugin.Invoke();

            Console.WriteLine(new string('-', 32));
        }


        foreach (IPlugin plugin in plugins)
        {
            Console.WriteLine("Name : " + plugin.PluginName);
            Console.WriteLine("Lütfen veri giriniz.");

            string data = Console.ReadLine();
            plugin.Invoke(data);

            Console.WriteLine(new string('-', 32));
        }
    }
}