using System;
using System.IO;

namespace ToolsManager
{
    public class PluginProxy<T>
    {
        private static PluginProxy<T> instance;
        public bool ShadowCopy { get; set; }

        public string ShadowCopyDirectories { get; set; }

        public static PluginProxy<T> CreateInstance(bool shadowCopy = true, string shadowCopyDirectories = null)
        {
            if (instance == null)
            {
                instance = new PluginProxy<T>(shadowCopy, shadowCopyDirectories);
            }
            return instance;
        }

        private PluginProxy(bool shadowCopy = true, string shadowCopyDirectories = null)
        {
            ShadowCopy = shadowCopy;
            ShadowCopyDirectories = shadowCopyDirectories;
        }

        public static PluginProxy<T> Instance
        {
            get { return instance; }
        }

        private AppDomain pluginDomain = null;
        private T pluginProvider;

        public T Provider
        {
            get
            {
                if (pluginDomain == null)
                {
                    Guid guid = Guid.NewGuid();
                    //string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Api");
                    AppDomainSetup setup = new AppDomainSetup();
                    setup.ApplicationName = guid.ToString();
                    setup.ApplicationBase = AppDomain.CurrentDomain.BaseDirectory;
                    setup.PrivateBinPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "private");
                    setup.CachePath = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData,Environment.SpecialFolderOption.Create),
                        AppDomain.CurrentDomain.FriendlyName, "Cache");
                    //DirectoryInfo di = new DirectoryInfo(path);
                    setup.ShadowCopyFiles = ShadowCopy ? "true" : "false";
                    if (ShadowCopy)
                    {
                        if (!string.IsNullOrEmpty(ShadowCopyDirectories))
                        {
                            if (Directory.Exists(ShadowCopyDirectories))
                            {
                                setup.ShadowCopyDirectories = ShadowCopyDirectories;
                                
                            }
                            else
                            {
                                setup.ShadowCopyDirectories = setup.ApplicationBase;
                            }
                                
                        }
                        else
                        {
                            setup.ShadowCopyDirectories = setup.ApplicationBase;
                        }


                    }

                    //setup.ShadowCopyDirectories = setup.ApplicationBase;
                    pluginDomain = AppDomain.CreateDomain("AppDomain" + guid, null, setup);
                    Type pluginProviderType = typeof(T);
                    pluginProvider = (T)pluginDomain.CreateInstanceAndUnwrap(pluginProviderType.Assembly.FullName, pluginProviderType.FullName);
                    //pluginProvider.Compose();
                }
                return pluginProvider;
            }
        }

        public void Unload()
        {
            if (pluginDomain != null)
            {
                AppDomain.Unload(pluginDomain);
                pluginDomain = null;
            }
        }
    }
}
