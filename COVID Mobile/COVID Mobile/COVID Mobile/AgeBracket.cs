using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVID_Mobile
{
    class AgeBracket
    {
        private int underTwenty;
        private int twentyToNine;
        private int thirtyToNine;
        private int fortyToNine;
        private int fiftyToNine;
        private int sixtyToNine;
        private int seventyToNine;
        private int overSeventyNine;
        private int unknown;

        public int UnderTwenty
        {
            get
            {
                return underTwenty;
            }
            set
            {
                underTwenty = value;
            }
        }
        public int TwentyToNine
        {
            get
            {
                return twentyToNine;
            }
            set
            {
                twentyToNine = value;
            }
        }
        public int ThirtyToNine
        {
            get
            {
                return thirtyToNine;
            }
            set
            {
                thirtyToNine = value;
            }
        }
        public int FortyToNine
        {
            get
            {
                return fortyToNine;
            }
            set
            {
                fortyToNine = value;
            }
        }
        public int FiftyToNine
        {
            get
            {
                return fiftyToNine;
            }
            set
            {
                fiftyToNine = value;
            }
        }
        public int SixtyToNine
        {
            get
            {
                return sixtyToNine;
            }
            set
            {
                sixtyToNine = value;
            }
        }
        public int SeventyToNine
        {
            get
            {
                return seventyToNine;
            }
            set
            {
                seventyToNine = value;
            }
        }
        public int OverSeventyNine
        {
            get
            {
                return overSeventyNine;
            }
            set
            {
                overSeventyNine = value;
            }
        }
        public int Unknown
        {
            get
            {
                return unknown;
            }
            set
            {
                unknown = value;
            }
        }

        public AgeBracket()
        {
            UnderTwenty = 0;
            TwentyToNine = 0;
            ThirtyToNine = 0;
            FortyToNine = 0;
            FiftyToNine = 0;
            SixtyToNine = 0;
            SeventyToNine = 0;
            OverSeventyNine = 0;
            Unknown = 0;
        }
        public AgeBracket(int _unTwenty, int _twentyToNine, int _thirtyToNine, int _fortyToNine,
            int _fiftyToNine, int _sixtyToNine, int _seventyToNine, int _ovSeventy, int _unknown)
        {
            UnderTwenty = _unTwenty;
            TwentyToNine = _twentyToNine;
            ThirtyToNine = _thirtyToNine;
            FortyToNine = _fortyToNine;
            FiftyToNine = _fiftyToNine;
            SixtyToNine = _sixtyToNine;
            SeventyToNine = _seventyToNine;
            OverSeventyNine = _ovSeventy;
            Unknown = _unknown;
        }
        public int TotalCount()
        {
            return underTwenty + twentyToNine + thirtyToNine + fortyToNine + fiftyToNine + sixtyToNine + seventyToNine + overSeventyNine + unknown;
        }
        public override string ToString()
        {
            return $"\n\tUnder 20: {UnderTwenty}\n\t20-29 : {TwentyToNine}\n\t30-39: {ThirtyToNine}\n\t40-49: {FortyToNine}" +
                $"\n\t50-59: {FiftyToNine}\n\t60-69: {SixtyToNine}\n\t70-79: {SeventyToNine}\n\t>79: {OverSeventyNine}\n\tUnknown: {Unknown}";
        }
        public string ToCSV()
        {
            return $"{UnderTwenty},{TwentyToNine},{ThirtyToNine},{FortyToNine}, {FiftyToNine}, {SixtyToNine}, {SeventyToNine}, {OverSeventyNine}, {Unknown}";
        }
        public static AgeBracket BuildBracket(string prompt, string rateName)
        {
            Utility.TextColor(ConsoleColor.Cyan, prompt);
            int unTwen = Utility.GatherInt($"[{rateName}] Under 20: ");
            int twenNine = Utility.GatherInt($"[{rateName}] Twenty to Twenty Nine: ");
            int thirNine = Utility.GatherInt($"[{rateName}] Thirty to Thirty Nine: ");
            int fortNine = Utility.GatherInt($"[{rateName}] Forty to Forty Nine: ");
            int fiftyNine = Utility.GatherInt($"[{rateName}] Fifty to Fifty Nine: ");
            int sixtyNine = Utility.GatherInt($"[{rateName}] Sixty to Sixty Nine: ");
            int sevNine = Utility.GatherInt($"[{rateName}] Seventy to Seventy Nine: ");
            int ovSevNine = Utility.GatherInt($"[{rateName}] Over Seventy Nine: ");
            int unknown = Utility.GatherInt($"[{rateName}] Unknown: ");
            return new AgeBracket(unTwen, twenNine, thirNine, fortNine, fiftyNine, sixtyNine, sevNine, ovSevNine, unknown);
        }
    }
}