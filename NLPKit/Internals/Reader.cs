using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace NLPKit.Internals
{
    public class Reader
    {
        static Regex STRING_START = new Regex("[uU]?[rR]?(\"\"\"|\'\'\'|\"|\')");

        static Regex READ_INT = new Regex("-?\\d+");

        static Regex READ_NUMBER_VALUE = new Regex("-?(\\d*)([.]?\\d*)?");

        public static (string, int) ReadString(string s, int start_position)
        {
            var matches = STRING_START.Matches(s, start_position);
            if (matches.Count == 0)
                throw new ReadException("open quote: " + start_position);

            if (matches.Count == 1)
                throw new ReadException("close quote missing: " + start_position);

            int position = matches[1].Index + 1;
            return (s.Substring(start_position + 1, matches[1].Index - start_position - 1), position);
        }

        public static (int, int) ReadInt(string s, int start_position)
        {
            var matches = READ_INT.Matches(s, start_position);
            if (matches.Count == 0)
                throw new ReadException("Integer " + start_position);

            int position = 0;
            string val = "";
            foreach (Match item in matches)
            {
                if (string.IsNullOrWhiteSpace(item.Value))
                    continue;

                position = item.Index + 1;
                val = item.Value;
                break;
            }
            
            return (Convert.ToInt32(val), position);
        }

        public static (float, int) ReadNumber(string s, int start_position)
        {
            var matches = READ_NUMBER_VALUE.Matches(s, start_position);
            if (matches.Count == 0)
                throw new ReadException("Number " + start_position);

            int position = 0;
            string val = "";
            foreach (Match item in matches)
            {
                if (string.IsNullOrWhiteSpace(item.Value))
                    continue;

                position = item.Index + 1;
                val = item.Value;
                break;
            }

            return (Convert.ToSingle(val), position);
        }
    }
}
