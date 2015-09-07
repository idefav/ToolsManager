using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using ToolsManager.Interface;

namespace ToolsManager
{
    public class Common
    {
        public static Lazy<ITool, IToolModel>[] Tests;
    }
}
