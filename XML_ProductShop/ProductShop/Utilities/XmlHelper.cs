using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProductShop.Utilities
{
    public class XmlHelper
    {
        public static T Deserialize<T>(string inputXml, string rootName)
             where T : class
        {
            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute(rootName);
            XmlSerializer serializer = new XmlSerializer(typeof(T), xmlRootAttribute);
            using StringReader strReader = new StringReader(inputXml);
            object? deserializedObject = serializer.Deserialize(strReader);
            if (deserializedObject == null)
                return null;

            return (T)deserializedObject;
        }


        public static T Deserialize<T>(Stream inputXmlStream, string rootName)
            where T : class
        {
            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute(rootName);
            XmlSerializer serializer = new XmlSerializer(typeof(T), xmlRootAttribute);

            object? deserializedObject = serializer.Deserialize(inputXmlStream);
            if (deserializedObject == null)
                return null;

            return (T)deserializedObject;
        }

        public static string Serialize<T>(T obj, string rootName, Dictionary<string, string>? nameSpaces = null)
        {
            StringBuilder result = new StringBuilder();
            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);
            XmlSerializerNamespaces xmlNameSpaces = new XmlSerializerNamespaces();
            if (nameSpaces == null)
            {
                xmlNameSpaces.Add(string.Empty, string.Empty);
            }
            else
            {
                foreach (KeyValuePair<string, string> kvp in nameSpaces)
                {
                    xmlNameSpaces.Add(kvp.Key, kvp.Value);
                }
            }
            using StringWriter stringWriter = new StringWriter(result);


            xmlSerializer.Serialize(stringWriter, obj, xmlNameSpaces);
            return result.ToString().TrimEnd();
        }


        public static void Serialize<T>(T obj, string rootName, Stream outputStream, Dictionary<string, string>? nameSpaces = null)
        {
            // StringBuilder result = new StringBuilder();
            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);
            XmlSerializerNamespaces xmlNameSpaces = new XmlSerializerNamespaces();
            if (nameSpaces == null)
            {
                xmlNameSpaces.Add(string.Empty, string.Empty);
            }
            else
            {
                foreach (KeyValuePair<string, string> kvp in nameSpaces)
                {
                    xmlNameSpaces.Add(kvp.Key, kvp.Value);
                }
            }
            // using StringWriter stringWriter = new StringWriter(result);

            xmlSerializer.Serialize(outputStream, obj, xmlNameSpaces);

        }


    }
}
