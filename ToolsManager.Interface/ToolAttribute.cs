using System;
using System.ComponentModel.Composition;

namespace ToolsManager.Interface
{
    [Serializable]
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ToolAttribute : ExportAttribute, IToolModel
    {
        public ToolAttribute() : base(typeof(ITool)) { }
        public string Name { get; set; }

        public string Version { get; set; }
        public string Author { get; set; }
        public string Company { get; set; }
        public string Time { get; set; }
        public string Description { get; set; }

        public string Guid { get; set; }
    }
}
