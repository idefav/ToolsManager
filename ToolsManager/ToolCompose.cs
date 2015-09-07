using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using ToolsManager.Interface;

namespace ToolsManager
{
    [Serializable]
    public class UpdateEventArgs : EventArgs
    {
        public Lazy<ITool, IToolModel>[] Data { get; set; }

        public UpdateEventArgs(Lazy<ITool, IToolModel>[] _data)
        {
            Data = _data;
        }
    }

    [Serializable]
    public class ToolCompose : MarshalByRefObject
    {
        public delegate void UpdateHandler(object sender,UpdateEventArgs updateEventArgs);

        public event UpdateHandler UpdateEvent;

        public void OnUpdate()
        {
            if (UpdateEvent != null)
            {
                UpdateEvent(this,new UpdateEventArgs(Tests));
            }
        }

        [ImportMany(AllowRecomposition = true)]
        public Lazy<ITool, IToolModel>[] Tests { get; set; }

        public CompositionContainer Container;
        public ToolCompose()
        {
            Compose();
        }

        public void Compose()
        {


            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "", "Api");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            //var catelog = new DirectoryCatalog(path, "*.dll");
            AggregateCatalog catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AutoRefreshDirectoryCatalog(path, "*.dll", true, () =>
             {
                 Container.ComposeParts(this);
                 OnUpdate();
                 return true;
             }));
            Container = new CompositionContainer(catalog);
            Container.ComposeParts(this);
        }
    }
}
