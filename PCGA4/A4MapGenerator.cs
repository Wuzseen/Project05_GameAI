using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCGA4.MapElements;

namespace PCGA4
{
    public class Generator
    {
        public MapSerializer MapSerializer
        { 
            get; 
            private set; 
        }

        public String Name
        {
            get;
            private set;
        }

        public Generator (string name)
        {
            Name = name;
            Map m = new Map(Name);
            MapSerializer = new MapSerializer(m);
            MapSerializer.Save();
        }
    }

    public class A4MapGenerator
    {
        public static Random RNG; // sshhhh, a global...

        static void Main (string[] args)
        {
            Console.WriteLine("Enter in Seed");
            RNG = new Random(int.Parse(Console.ReadLine()));
            Generator g = new Generator("GeneratedMap");
            Console.WriteLine("Finished. Enter to exit");
            Console.ReadLine(); // wait to exit
        }
    }
}
