﻿using ReleaseLib.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ReleaseLib
{
    public class Settings
    {
        public readonly List<Country> Countries = BuildDictionary("Countries", Resources.Countries);

        private static List<Country> BuildDictionary(string Name, string Contents)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Country>), new XmlRootAttribute(Name));
            StringReader stringReader = new StringReader(Contents.ToString());
            return (List<Country>)serializer.Deserialize(stringReader);
        }
    }
}
