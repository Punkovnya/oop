using System;
using System.Linq;

namespace laba_9_delegates
{
    static class StringOperation
    {
        public static string DelDot(string str)
        {
            char[] ArrStr = str.ToCharArray();
            for (int i = 0; i < str.Length; i++)
                if (str[i] == '.')
                    ArrStr[i] = ' ';
            str = new string(ArrStr);
            return str;
        }
        public static string NewLetter(string str)
        {
            char[] ArrStr = str.ToCharArray();
            for (int i = 0; i < str.Length; i++)
                if(str[i]=='a')
                    ArrStr[i] = 'A';
              
               
            str = new string(ArrStr);
            return str;
        }
        public static string TwoProb(string str)
        {
            char[] ArrStr = str.ToCharArray();
            for (int i = 1; i < str.Length; i++)
                if (str[i-1] == ' '&& str[i] == ' ')
                    ArrStr[i] = ';';


            str = new string(ArrStr);
            return str;
        }
        public static string DelEquals(string str)
        {
            char[] ArrStr = str.ToCharArray();
            for (int i = 1; i < str.Length; i++)
                if (str[i - 1] == str[i])
                    ArrStr[i] = '*';


            str = new string(ArrStr);
            return str;
        }
    }
    public class GameObject
    {
       public int Health { get; set; }
       public int Level { get; set; }
        public string Name { get; set; }
        public string Weapon { get; set; }
        public delegate void damage();
        public delegate void GameEvent();
        public event GameEvent CheckDmg;
        public event GameEvent CheckRestore;
        public event GameEvent CheckWeapon;
        public void Damage()
        {
            
            Health=Health-10;
            CheckDmg();
        }
        public void Lvl()
        {
            Level = Level + 1;
        }
        public void Restore()
        {
            
            Health = Health + 10;
            CheckRestore();
        }
        public void GiveWpn(string wpn)
        {
            Weapon = wpn;
            CheckWeapon();
        }
        public void CheckHealth()
        {
            Console.WriteLine($"Текущее здоровье {Name}-{Health}");
        }
        public void CheckLevel()
        {
            Console.WriteLine($"Текущий уровень {Name}-{Level}");
        }
        public void CheckWpn()
        {
            Console.WriteLine($"Оружие персонажа {Name}-{Weapon}");
        }
        public GameObject(int Health,int Level, string Name)
        {
            this.Health = Health;
            this.Name = Name;
            this.Level = Level;
        }



    }
    
    class Program
    {
       // delegate int Operation(int x, int y);

        public delegate void LvlUp();
        static void LevelUp()
        {
            Console.WriteLine("Повышен уровень");
        }
        static void NewLocation()
        {
            Console.WriteLine("Новая локация");
        }
        static void Dmg()
        {
            Console.WriteLine("Урон в 10 единиц здоровья");
        }
        static void Restore()
        {
            Console.WriteLine("Вылечено 10 единиц здоровья");
        }
        static void Main(string[] args)

        {
            //Operation operation = (x, y) => x + y;
            //Console.WriteLine(operation(10, 20));
            
            
            GameObject ork = new GameObject(40, 1, "Ork");
            GameObject  elf = new GameObject(30, 2, "Elf");
            LvlUp LvlUp;
            LvlUp = NewLocation;
            LvlUp += LevelUp;
            LvlUp += ork.CheckLevel;
            ork.CheckDmg += ork.CheckHealth;
            ork.CheckDmg += Dmg;
            ork.CheckRestore += ork.CheckHealth;
            ork.CheckRestore += Restore;
            ork.CheckWeapon += ork.CheckWpn;
            ork.CheckWeapon += ork.CheckLevel;
            ork.Damage();
            ork.Restore();
            ork.GiveWpn("Sword");
            ork.Lvl();
            LvlUp();
            elf.CheckDmg += Dmg;
            elf.CheckDmg += elf.CheckHealth;
            elf.Damage();
            elf.Lvl();
            LvlUp -= ork.CheckLevel;
            LvlUp += elf.CheckLevel;
            LvlUp();
            Func<string, string> func = StringOperation.DelDot;
            Console.WriteLine(func("asfdg.ssssgfs.aer.asfgs.aa.."));
            Func<string, string> func2 = StringOperation.NewLetter;
            func2 += StringOperation.TwoProb;
            func2 += StringOperation.DelEquals;
            Console.WriteLine(func2(func("asfdg.ssssssdgfs.aer.asfgs.aa..")));


        }

       
    }
}
