using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace LicenseHelper
{
    public static class XmlExtensions
    {
        public static XmlDocument CutNode(this XmlDocument doc, string nodeName)
        {
            try
            {
                if (doc.GetElementsByTagName(nodeName).Count > 0)
                {
                    var node = doc.GetElementsByTagName(nodeName)[0];
                    node.ParentNode.RemoveChild(node);
                }
                else
                {
                    Console.WriteLine($"'{nodeName}' tag does not exist");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return doc;
        }
        public static XDocument ToXDocument(this XmlDocument document)
        {
            return document.ToXDocument(LoadOptions.None);
        }
        public static XDocument ToXDocument(this XmlDocument document, LoadOptions options)
        {
            using (var reader = new XmlNodeReader(document))
            {
                return XDocument.Load(reader, options);
            }
        }
        public static T DeserializeObject<T>(string xml)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var tr = new StringReader(xml))
            {
                return (T)serializer.Deserialize(tr);
            }
        }
        public static XElement FindKeyElementByAttributeName(this List<XElement> elements, string keyName)
        {
            var keyElement = elements.Where(e => (string)e.Attribute("key") == keyName).FirstOrDefault();
            return keyElement;
        }
        public static T GetAs<T>(this XElement elem, T defaultValue = default(T))
        {
            T ret = defaultValue;

            if (elem != null && !string.IsNullOrEmpty(elem.Value))
            {
                // Cast to Return Data Type
                // NOTE: ChangeType can not cast to a Nullable type
                ret = (T)Convert.ChangeType(elem.Value, typeof(T));
            }

            return ret;
        }
        public static T GetAs<T>(this XAttribute attr, T defaultValue = default(T))
        {
            try
            {
                T ret = defaultValue;

                if (attr != null && !string.IsNullOrEmpty(attr.Value))
                {
                    // Cast to Return Data Type
                    // NOTE: ChangeType can not cast to a Nullable type
                    ret = (T)Convert.ChangeType(attr.Value, typeof(T));
                }

                return ret;
            }
            catch (FormatException e)
            {
                var installDate = DateTime.ParseExact(attr.Value, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                return (T)Convert.ChangeType(installDate, typeof(T)); ;
            }

        }
    }
}
