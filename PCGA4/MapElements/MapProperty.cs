using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace PCGA4
{
    [XmlType("property")]
    public class MapProperty
    {
        [XmlAttribute]
        public string name;
        [XmlAttribute]
        public string value;

        public MapProperty()
        {
            name = "";
            value = "";
        }

        public MapProperty(string _name, string _value)
        {
            this.name = _name;
            this.value = _value;
        }
    }
}
