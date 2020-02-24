using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PEPlugin;
using PEPlugin.Pmx;
using MetasequoiaObject;

namespace MqozExporter
{
    public class MqozExporter : IPEExportPlugin
    {
        public string Ext
        {
            get
            {
                return ".mqoz";
            }
        }
        public string Caption
        {
            get
            {
                return "Zipped Metasequoia Object";
            }
        }
        public void Export(IPXPmx pmx, string path, IPERunArgs args)
        {

        }
    }
}
