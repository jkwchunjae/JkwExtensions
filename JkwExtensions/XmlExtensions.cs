using System;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace JkwExtensions
{
    public static class XmlExtensions
    {
        public static bool HasElement(this XElement xElement, string elementName)
        {
            return xElement.Elements(elementName).Any();
        }

        public static bool HasAttribute(this XElement xElement, string attributeName)
        {
            return xElement.Attributes(attributeName).Any();
        }

        public static int ToInt(this XAttribute xAttribute, int defaultValue = 0)
        {
            return xAttribute?.Value.ToInt(defaultValue) ?? defaultValue;
        }

        public static long ToLong(this XAttribute xAttribute, long defaultValue = 0L)
        {
            return xAttribute?.Value.ToLong(defaultValue) ?? defaultValue;
        }

        public static double ToDouble(this XAttribute xAttribute, double defaultValue = 0.0)
        {
            return xAttribute?.Value.ToDouble(defaultValue) ?? defaultValue;
        }

        public static bool ToBoolean(this XAttribute xAttribute, bool defaultValue = false)
        {
            return xAttribute?.Value.ToBoolean(defaultValue) ?? defaultValue;
        }

        public static string TryGetValue(this XAttribute xAttribute, string defaultValue = "")
        {
            return xAttribute?.Value ?? defaultValue;
        }

        public static int GetInt(this XElement xmlNode, string attributeName, int defalutValue = 0)
        {
            int changedValue = defalutValue;
            if (xmlNode.NodeType != XmlNodeType.Element)
                throw new ArgumentException("only can used for xml Node!");
            else if (xmlNode.Attribute(attributeName) == null)
                return changedValue;

            Int32.TryParse(xmlNode.Attribute(attributeName).Value, out changedValue);
            return changedValue;
        }

        public static bool GetBool(this XElement xmlNode, string attributeName, bool defaultValue = false)
        {
            bool changedValue = defaultValue;
            if (xmlNode.NodeType != XmlNodeType.Element)
                throw new ArgumentException("only can used for xml Node!");
            else if (xmlNode.Attribute(attributeName) == null)
                return changedValue;

            bool.TryParse(xmlNode.Attribute(attributeName).Value, out changedValue);
            return changedValue;
        }

        public static string GetString(this XElement xmlNode, string attributeName, string defaultValue = "")
        {
            string changedValue = defaultValue;
            if (xmlNode.NodeType != XmlNodeType.Element)
                throw new ArgumentException("only can used for xml Node!");
            else if (xmlNode.Attribute(attributeName) == null)
                return changedValue;

            return xmlNode.Attribute(attributeName).Value.ToString();
        }

        public static float GetFloat(this XElement xmlNode, string attributeName, float defaultValue = 0)
        {
            float changedValue = defaultValue;
            if (xmlNode.NodeType != XmlNodeType.Element)
                throw new ArgumentException("only can used for xml Node!");
            else if (xmlNode.Attribute(attributeName) == null)
                return changedValue;

            float.TryParse(xmlNode.Attribute(attributeName).Value.ToString(), out changedValue);
            return changedValue;
        }

        public static float GetLong(this XElement xmlNode, string attributeName, long defaultValue = 0)
        {
            long changedValue = defaultValue;
            if (xmlNode.NodeType != XmlNodeType.Element)
                throw new ArgumentException("only can used for xml Node!");
            else if (xmlNode.Attribute(attributeName) == null)
                return changedValue;

            long.TryParse(xmlNode.Attribute(attributeName).Value.ToString(), out changedValue);
            return changedValue;
        }
    }

}
