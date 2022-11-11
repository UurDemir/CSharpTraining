using Reflection.Shared;
using System;

namespace Reflection.Math;

public class MathPlugin : IPlugin
{
    public string PluginName => "Math Plugin";

    public string Data { get; set; }

    public string PluginDescription => "Sayıyı kendisi ile çarpar.";

    public void Invoke()
    {
        if (string.IsNullOrEmpty(Data))
        {
            Console.WriteLine("Data sağlanmadı");
            return;
        }

        Invoke(Data);
    }

    public void Invoke(string parameter)
    {
        int number = int.Parse(parameter);

        int result = number * number;

        Console.WriteLine("Plugin Sonucu : " + result);
    }
}