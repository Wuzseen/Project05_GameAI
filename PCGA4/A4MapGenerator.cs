﻿using System;
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

    class A4MapGenerator
    {
        static void Main (string[] args)
        {
            Generator g = new Generator("GeneratedMap");
            Console.ReadLine(); // wait to exit
        }
    }
}
