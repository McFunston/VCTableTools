using System;
using System.IO;
using System.Xml.Serialization;
namespace VisualCronTableTools.Tools.XML
{
	public static class FindResponseDeserializer
	{

		public static FindResponse Deserialize(string xml)
		{
            XmlSerializer serializer = new XmlSerializer(typeof(FindResponse));
			TextReader reader = new StringReader(xml);

            FindResponse findResponse = (FindResponse)serializer.Deserialize(reader);
			return findResponse;
        }
	}
}

