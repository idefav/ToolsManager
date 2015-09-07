using System.Drawing;

namespace ToolsManager.Interface
{
    public interface ITool
    {
        bool Run();

        Bitmap GetAppIcon();
    }
}
