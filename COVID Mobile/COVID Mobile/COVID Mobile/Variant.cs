using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;


namespace COVID_Mobile
{
    class Variant
    {
        //static string file = "variants.json";
        //public static List<string> variants = new List<string>();

        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = name != "" ? value : "[Naming Error -- Variant]";
            }
        }
        public Variant(string _name)
        {
            Name = _name;

        }
        public override string ToString()
        {
            return $"{name}";
        }
        //public static void AddVariant()
        //{
        //    variants.Add(Utility.GatherString("\nWhat is the new Variant name?: "));
        //}
        //public static void RemoveVariant()
        //{
        //    if (variants.Count < 1)
        //    {
        //        Utility.TextColor(ConsoleColor.Yellow, "\n- No Variants to Remove -");
        //        System.Threading.Thread.Sleep(1000);
        //        return;
        //    }
        //    int select = VariantMenu("Variant List", variants);
        //    variants.Remove(variants[select - 1]);
        //}
        public static int VariantMenu(string title, List<string> selections)
        {
            int index = 1;
            Utility.TextColor(ConsoleColor.Cyan, $"\n* * * {title} * * *\n");
            foreach (string variant in selections)
            {
                Utility.TextColor(ConsoleColor.White, $"{index}. {variant.ToString()}");
                index++;
            }
            return Utility.ValidateNum(1, selections.Count);
        }
        //public static void LoadJson()
        //{
        //    if (File.Exists(file))
        //    {
        //        StreamReader reader = new StreamReader(file);
        //        string listRead = reader.ReadToEnd();
        //        variants = JsonConvert.DeserializeObject<List<string>>(listRead);
        //        reader.Close();
        //    }
        //}
        //public static void SaveJson()
        //{
        //    string listSerial = JsonConvert.SerializeObject(variants);
        //    StreamWriter writer = new StreamWriter(file);
        //    writer.Write(listSerial);
        //    writer.Close();
        //}
        //public static void WriteCustomVariant()
        //{
        //    string dataName = Utility.GatherString("New File Name: ");
        //    StreamWriter writer = new StreamWriter($"{dataName}.csv");

        //    foreach (string variant in variants)
        //    {
        //        writer.WriteLine(variant.ToString());
        //    }
        //    writer.Flush();
        //    writer.Close();
        //}
    }

}