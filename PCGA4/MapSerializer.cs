using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using PCGA4.MapElements;

namespace PCGA4
{
    public class MapSerializer

    {
        public Map _Map { get; set; }

        public MapSerializer(Map targetMap)
        {
            this._Map = targetMap;
        }

        public void Save()
        {
            XmlSerializer x = new XmlSerializer(typeof(Map));
            XmlWriterSettings settings = new XmlWriterSettings();
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            settings.OmitXmlDeclaration = true;
            settings.Indent = true;

            
            XmlWriter writer = XmlWriter.Create("map.xml", settings);

            x.Serialize(writer, this._Map, ns);
        }
    }
}
