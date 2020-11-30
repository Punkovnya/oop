
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Xml.XPath;
using System.Xml.Linq;
using System.Linq;

namespace laba_14_Serialization
{
    public interface ISerializable
    {
        
        public abstract void MyJSONSerializer<T>(T obj);
        public abstract void MyXMLSerializer<T>(T obj);
        public abstract void MyBINSerializer<T>(T obj);
        public abstract void MySOAPSerializer<T>(T obj);

        //____________________________________________________\\

        public abstract SerializableClass MyXMLDeserializer<T>(T obj);
        public abstract SerializableClass MyBINDeserializer<T>(T obj);
        public abstract SerializableClass MyJSONDeserializer<T>(T obj);
        public abstract SerializableClass MySOAPDeserializer<T>(T obj);

    }
    class CustomSerializer:ISerializable
    {
        public void MyJSONSerializer<T>(T obj) 
        {
                File.WriteAllText("jsonObj.json", JsonSerializer.Serialize<T>(obj));      
        }
        public SerializableClass MyJSONDeserializer<T>(T obj)
        {
            var restortedObj = JsonSerializer.Deserialize<T>(File.ReadAllText("jsonObj.json")) as SerializableClass;
            return restortedObj;
        }
        public void MyXMLSerializer<T>(T obj) {
            Type type = obj.GetType();
            XmlSerializer xmlSerializer = new XmlSerializer(type);
            using (FileStream fs = new FileStream("xmlObj.xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, obj);
                fs.Close();
            }
            
        }
        public SerializableClass MyXMLDeserializer<T>(T obj) {
            Type type = obj.GetType();
            XmlSerializer xmlSerializer = new XmlSerializer(type);
            using (FileStream fs = new FileStream("xmlObj.xml", FileMode.OpenOrCreate))
            {
                var restObj = xmlSerializer.Deserialize(fs) as SerializableClass;
                fs.Close();
                return (restObj);
            }
        }

        public SerializableClass MyBINDeserializer<T>(T obj) {
            Type type = obj.GetType();
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("binObj.bin", FileMode.OpenOrCreate))
            {
                var restObj = binaryFormatter.Deserialize(fs) as SerializableClass;
                fs.Close();
                return restObj;
            }
            
        }
        public void MyBINSerializer<T>(T obj) {
            Type type = obj.GetType();
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("binObj.bin", FileMode.OpenOrCreate))
            {
                binaryFormatter.Serialize(fs, obj);
                fs.Close();
            }
        }

        
        public string MyJSONToServerSerializer<T>(T obj)
        {
            return JsonSerializer.Serialize<T>(obj);
        }

        public SerializableClass MySOAPDeserializer<T>(T obj)
        {
            Type type = obj.GetType();
            SoapFormatter soapFormatter = new SoapFormatter();
            using (FileStream fs = new FileStream("soapObj.soap", FileMode.OpenOrCreate))
            {
                var restObj = soapFormatter.Deserialize(fs) as SerializableClass;
                fs.Close();
                return restObj;
            }

        }
        public void MySOAPSerializer<T>(T obj)
        {
            Type type = obj.GetType();
            SoapFormatter soapFormatter = new SoapFormatter();
            using (FileStream fs = new FileStream("soapObj.soap", FileMode.OpenOrCreate))
            {
                soapFormatter.Serialize(fs, obj);
                fs.Close();
            }
        }
        public CustomSerializer() {}


        static  public void Xpath()
        {
            XPathDocument xmldoc = new XPathDocument("xmlObj.xml");
            Console.WriteLine("HERE");
            foreach (XPathItem x in xmldoc.CreateNavigator().Select("//SerializableClass/Id"))
                Console.WriteLine(x.Value);
            Console.WriteLine();
            
            using (FileStream fs = new FileStream("xmlObj.xml", FileMode.OpenOrCreate))
            {
                XDocument xdoc = XDocument.Load(fs);
                XElement root = xdoc.Element("SerializableClass");
             
                root.Add(new XElement("HumanPilot",
                            new XElement("WeightOfMen", "100"),
                            new XElement("Name", "Valera"),
                            new XElement("Sex", "Man"),
                            new XElement("Age", "20")));
                xdoc.Save("xmlObjNew.xml");

            }

        }
    }
    
}



