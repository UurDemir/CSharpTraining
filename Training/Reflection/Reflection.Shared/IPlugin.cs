using System;

namespace Reflection.Shared
{
    public interface IPlugin
    {
        public string PluginName { get; }
        public string Data { get; set; }
        string PluginDescription { get; }

        void Invoke();
        void Invoke(string parameter);
    }
}
