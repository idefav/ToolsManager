using System;
using System.ComponentModel.Composition.Hosting;
using System.IO;

namespace ToolsManager
{
    public class AutoRefreshDirectoryCatalog : DirectoryCatalog
    {
        public bool NotifyOnDirectoryChanged { get; private set; }
        public AutoRefreshDirectoryCatalog(string path)
            : this(path, false)
        { }
        public AutoRefreshDirectoryCatalog(string path,
            bool notifyOnDirectoryChanged)
            : base(path)
        {
            this.NotifyOnDirectoryChanged = notifyOnDirectoryChanged;
            if (notifyOnDirectoryChanged)
            {
                FileSystemWatcher fsw = new FileSystemWatcher(path, "*.dll");
                fsw.EnableRaisingEvents = true;
                fsw.Created += (s, e) => { Refresh(); };
                fsw.Changed += (s, e) => { Refresh(); };
                fsw.Deleted += (s, e) => { Refresh(); };
                
            }
        }

        public AutoRefreshDirectoryCatalog(string path, string searchPattern,Func<bool> func=null ) : this(path, searchPattern, false,func)
        {
            
        }

        public AutoRefreshDirectoryCatalog(string path, string searchPattern, bool notifyOnDirectoryChanged,Func<bool> func=null ):base(path,searchPattern)
        {
            this.NotifyOnDirectoryChanged = notifyOnDirectoryChanged;
            if (notifyOnDirectoryChanged)
            {
                FileSystemWatcher fsw = new FileSystemWatcher(path,searchPattern);
                fsw.EnableRaisingEvents = true;
                fsw.Created += (s, e) =>
                {
                    
                    Refresh();
                    if (func != null)
                    {
                        func();
                    }
                };
                fsw.Changed += (s, e) =>
                {
                    
                    Refresh();
                    if (func != null)
                    {
                        func();
                    }
                };
                fsw.Deleted += (s, e) =>
                {
                    
                    Refresh();
                    if (func != null)
                    {
                        func();
                    }
                };
            }
        }
    }
}
