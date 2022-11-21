using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataCounterCommon
{
    public class PluginLoader
    {
        private static List<T> GetPlugins<T>(string filename)
        {
            List<T> ret = new List<T>();
            if (File.Exists(filename))
            {
                Type typeT = typeof(T);
                Assembly ass = Assembly.LoadFrom(filename);
                foreach (Type type in ass.GetTypes())
                {
                    if (!type.IsClass || type.IsNotPublic) continue;
                    if (typeT.IsAssignableFrom(type))
                    {
                        T plugin = (T)Activator.CreateInstance(type);
                        ret.Add(plugin);
                    }
                }
            }
            return ret;
        }

        private static List<T> GetPluginsInDirectory<T>(string directory)
        {
            List<T> ret = new List<T>();
            string[] dlls = Directory.GetFiles(directory, "*.dll");
            foreach (string dll in dlls)
            {
                List<T> dll_plugins = GetPlugins<T>(Path.GetFullPath(dll));
                ret.AddRange(dll_plugins);
            }
            return ret;
        }

        public static List<ICounterInput> GetInterfacePlugins(string directory)
        {
            return GetPluginsInDirectory<ICounterInput>(directory);
        }
    }
}
