using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace PCGA4.MapElements
{
    [XmlType("image")]
    public class Image
    {
        [XmlAttribute("source")]
        public string Source = "graphics.png";
        [XmlAttribute("width")]
        public string Width = "320";
        [XmlAttribute("height")]
        public string Height = "1184";

        public Image () { }
    }
}
