using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PEPlugin;
using PEPlugin.Pmx;
using MetasequoiaFileFormat;

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
                return "Export Metasequoia Object Zip";
            }
        }
        public void Export(IPXPmx pmx, string path, IPERunArgs args)
        {
            MetasequoiaObject mqo = new MetasequoiaObject();
            mqo.MQX = new MetasequoiaXML();



            mqo.Write(path);
        }
    }
}
