using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;


namespace COVID_Mobile
{
    class COVID
    {
        public List<COVID> covidList = new List<COVID>();
        //static string file = "COVID.json";
        private string note;

        public DateTimeOffset Date { get; set; }

        public string VariantProp { get; set; }
        public Place LocationProp { get; set; }
        public AgeBracket Infection { get; set; }
        public AgeBracket Morbidity { get; set; }
        public string Note
        {
            get
            {
                return note;
            }
            set
            {
                if (string.IsNullOrEmpty(value)) { value = "[No Recorded Note]"; }
                note = value;
            }
        }
        public COVID()
        {
        }
        public COVID(DateTimeOffset _date, string _variant, Place _location, AgeBracket _infection, AgeBracket _morbidity, string _note)
        {
            Date = _date;
            VariantProp = _variant;
            LocationProp = _location;
            Infection = _infection;
            Morbidity = _morbidity;
            Note = _note;
        }

        public override string ToString()
        {
            return $"\n\tDate: {Date}\n\tVariant: {VariantProp}\n\tLocation: {LocationProp}\n   Infection:{Infection}\n   Morbidity:{Morbidity}\n  Note:\n\t{Note}\n";
        }
        //public static void AddData()
        //{
        //    if (Variant.variants.Count == 0 || Location.locations.Count == 0)
        //    {
        //        Utility.TextColor(ConsoleColor.Red, "Required parameter(s) is missing [LOCATIONS or VARIANTS]");
        //        Utility.ReturnMenu();
        //        System.Threading.Thread.Sleep(2000);
        //    }
        //    else
        //    {
        //        while (true)
        //        {
        //            if (!Utility.BoolCollect("Start Entry?")) { Utility.ReturnMenu(); }
        //            COVID covid = new COVID();
        //                  //covid.Date = Utility.GatherDate("Enter Date of COVID record (mm/dd/yyyy): ");
        //                 // TODO TOARRAY
        //                // covid.VariantProp = Variant.variants[Variant.VariantMenu("Variants", Variant.variants) - 1];
        //               // TODO TOARRAY
        //              //covid.LocationProp = Location.locations[Location.LocationMenu("Locations", Location.locations) - 1];
        //             //covid.infection = AgeBracket.BuildBracket("Add Infection Rates", "INFECTION");
        //            //covid.morbidity = AgeBracket.BuildBracket("Add Morbidity Rates", "MORBIDITY");
        //            if (Utility.BoolCollect("Want to save result?"))
        //            {
        //                covidList.Add(covid);
        //                break;
        //            }
        //        }
        //    }

        //}
        //public static void EditRemoveEntry()
        //{
        //    string[] covidMenu = new string[0];
        //    foreach (COVID covid in covidList)
        //    {
        //        Array.Resize(ref covidMenu, 1);
        //        covidMenu[covidMenu.Length - 1] = covid.date.ToString();
        //    }
        //    int select = Utility.MenuBuild("COVID Cases", covidMenu);
        //    covidList.Remove(covidList[select - 1]);
        //    Utility.TextColor(ConsoleColor.Green, " - - Removed - -");
        //    System.Threading.Thread.Sleep(700);
        //}
        //public static void LoadJson()
        //{
        //    if (File.Exists(file))
        //    {
        //        StreamReader reader = new StreamReader(file);
        //        string listRead = reader.ReadToEnd();
        //        covidList = JsonConvert.DeserializeObject<List<COVID>>(listRead);
        //        reader.Close();
        //    }
        //}
        //public static void SaveJson()
        //{
        //    string listSerial = JsonConvert.SerializeObject(covidList);
        //    StreamWriter writer = new StreamWriter(file);
        //    writer.Write(listSerial);
        //    writer.Close();
        //}
        //public static void WriteCustomCOVID()
        //{
        //    string dataName = Utility.GatherString("New File Name: ");
        //    StreamWriter writer = new StreamWriter($"{dataName}.csv");
        //    writer.WriteLine("Date, Variant, City, State, Infection (Under 20), Infection (20-29), Infection (30-39), " +
        //        "Infection (40-49), Infection (50-59), Infection (60-69), Infection (70-79), Infection (Over 79)," +
        //        "Morbidity (Under 20), Morbidity (20-29), Morbidity (30-39), Morbidity (40-49), Morbidity (50-59)," +
        //        "Morbidity (60-69), Morbidity (70-79), Morbidity (Over 79)");
        //    foreach (COVID covid in covidList)
        //    {
        //        writer.WriteLine($"{covid.Date}, {covid.VariantProp}, {covid.LocationProp}, {covid.Infection.ToCSV()}, {covid.Morbidity.ToCSV()}");
        //    }
        //    writer.Flush();
        //    writer.Close();
        //}
        public static void LoadAllDataJson()
        {
            //LoadJson();
            //Variant.LoadJson();
            //Location.LoadJson();
        }



    }
}
