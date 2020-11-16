


using System;

namespace laba_14_Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
          SerializableClass militaryPlane = new SerializableClass(123, 2000);
            militaryPlane.pass = 4;
            Console.WriteLine("оригинальный объект - "+militaryPlane.ToString());
            CustomSerializer customSerializer = new CustomSerializer();

            customSerializer.MyJSONSerializer(militaryPlane);
            var jsonRestored = customSerializer.MyJSONDeserializer(militaryPlane);
            Console.WriteLine(("восстановленый json объект - " + jsonRestored.ToString()));

            customSerializer.MyXMLSerializer(militaryPlane);
            var xmlRestored = customSerializer.MyXMLDeserializer(militaryPlane);
            Console.WriteLine(("восстановленый xml объект - " + xmlRestored.ToString()));


            customSerializer.MyBINSerializer(militaryPlane);
            var binRestored = customSerializer.MyBINDeserializer(militaryPlane);
            Console.WriteLine(("восстановленый bin объект - " + binRestored.ToString()));

            customSerializer.MySOAPSerializer(militaryPlane);
            var soapRestored = customSerializer.MySOAPDeserializer(militaryPlane);
            Console.WriteLine(("восстановленый soap объект - " + soapRestored.ToString()));

            Server server = new Server();
            server.ServerStart();
            



        }
    }
}
