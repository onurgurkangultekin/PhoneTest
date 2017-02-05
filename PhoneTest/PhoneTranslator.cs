using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace PhoneTest
{
    public static class PhoneTranslator
    {
        public static string ToNumber(string raw)
        {
            if (string.IsNullOrWhiteSpace(raw))
            {
                return string.Empty;
            }
            else
                raw = raw.ToUpperInvariant();

            var newNumber = new StringBuilder();
            foreach (var c in raw)
            {
                if (" -0123456789".Contains(c))
                {
                    newNumber.Append(c);
                }
                else
                {
                    int? result = translateToNumber(c);
                    if (result != null)
                        newNumber.Append(result);
                }
            }
            return newNumber.ToString();
        }

        



        private static int? translateToNumber(char c)
        {
            if ("ABC".contains(c))
                return 2;
            else if ("DEF".contains(c))
                return 3;
            else if ("GHI".contains(c))
                return 4;
            else if ("JKL".contains(c))
                return 5;
            else if ("MNO".contains(c))
                return 6;
            else if ("PQRS".contains(c))
                return 7;
            else if ("TUV".contains(c))
                return 8;
            else if ("WXYZ".contains(c))
                return 9;
            return null;
        }

        private static bool contains(this string keyString, char c)
        {
            return keyString.IndexOf(c) >= 0;
        }
    }
}