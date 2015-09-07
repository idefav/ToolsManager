namespace ToolsManager.Interface
{
    
   public interface IToolModel
    {
        /// <summary>
        /// 软件名称
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 版本
        /// </summary>
        string Version { get; }

        /// <summary>
        /// 作者
        /// </summary>
        string Author { get; }

        /// <summary>
        /// 公司
        /// </summary>
        string Company { get; }

        /// <summary>
        /// 时间
        /// </summary>
        string Time { get; }

        /// <summary>
        /// 描述
        /// </summary>
        string Description { get; }

        string Guid { get; }
    }
}
