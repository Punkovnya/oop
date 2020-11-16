using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace laba_14_Serialization
{
    [Serializable]
    public class SerializableClass
    {
       
            public SerializableClass(int Id, int Weight)
            {
                this.Weight = Weight;
                this.Id = Id;
                
            }
        public SerializableClass()
        {
        }
        [XmlIgnore]
        [NonSerialized] public int pass;

        /* public int Pass
         {
             get{
                 return pass;
             }
             set
             {
                 pass = value;
             }
         }*/
        public  override string ToString()
            {
                return($"Вес военного самолета - {Weight}  , его Id  - {Id}, количество пассажиров - {pass}");
            }

            public int Id { get; set; }
           
            private int weight;
            
            public int Weight
            {
                get
                {
                    return weight;
                }
                set
                {
                    weight = value;
                }
            }

        
    }
}
