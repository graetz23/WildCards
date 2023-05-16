//
// WildCards is distributed under the MIT License (MIT); this file is part of.
//
// Copyright (c) 2018-2022 Christian (graetz23@gmail.com)
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

namespace WildCards
{
    public static class Tags
    {
        // Current used
        public static string[] UsedTags = { Tags.Thousand, Tags.Hundred, Tags.Fifty, Tags.Ten, Tags.Five, Tags.One };

        // Colors
        public const string cnst_Spade = "Spade";
        public static string Spade { get { return cnst_Spade; } }

        public const string cnst_Cross = "Cross";
        public static string Cross { get { return cnst_Cross; } }

        public const string cnst_Heart = "Heart";
        public static string Heart { get { return cnst_Heart; } }

        public const string cnst_Diamond = "Diamond";
        public static string Diamond { get { return cnst_Diamond; } }

        // Cards and some for Jetons: One, Five, and Ten.
        public const string cnst_Ace = "Ace";
        public static string Ace { get { return cnst_Ace; } }
        
        public const string cnst_King = "King";
        public static string King { get { return cnst_King; } }
        
        public const string cnst_Queen = "Queen";
        public static string Queen { get { return cnst_Queen; } }
        
        public const string cnst_Jack = "Jack";
        public static string Jack { get { return cnst_Jack; } }
        
        public const string cnst_Ten = "Ten";
        public static string Ten { get { return cnst_Ten; } }

        public const string cnst_Nine = "Nine";
        public static string Nine { get { return cnst_Nine; } }
        
        public const string cnst_Eight = "Eight";
        public static string Eight { get { return cnst_Eight; } }
        
        public const string cnst_Seven = "Seven";
        public static string Seven { get { return cnst_Seven; } }
        
        public const string cnst_Six = "Six";
        public static string Six { get { return cnst_Six; } }

        public const string cnst_Five = "Five";
        public static string Five { get { return cnst_Five; } }
        
        public const string cnst_Four = "Four";
        public static string Four { get { return cnst_Four; } }

        public const string cnst_Three = "Three";
        public static string Three { get { return cnst_Three; } }
        
        public const string cnst_Two = "Two";
        public static string Two { get { return cnst_Two; } }
        
        public const string cnst_One = "One";
        public static string One { get { return cnst_One; } }

        public const string cnst_Zero = "Zero";
        public static string Zero { get { return cnst_Zero; } }

        public const string cnst_Joker = "Joker"; // acts like zero
        public static string Joker { get { return cnst_Joker; } }
        
        // Jetons
        public const string cnst_Twenty = "Twenty";
        public static string Twenty { get { return cnst_Twenty; } }

        public const string cnst_Fifty = "Fifty";
        public static string Fifty { get { return cnst_Fifty; } }

        public const string cnst_Hundred = "Hundred";
        public static string Hundred { get { return cnst_Hundred; } }

        public const string cnst_Thousand = "Thousand";
        public static string Thousand { get { return cnst_Thousand; } }

        public static string shorten(string tag)
        {
            string id = null;
            switch (tag)
            {
                // Colors
                case cnst_Spade:
                    id = "S";
                    break;
                case cnst_Cross:
                    id = "C";
                    break;
                case cnst_Heart:
                    id = "H";
                    break;
                case cnst_Diamond:
                    id = "D";
                    break;
                // Cards and some for Jetons: One, Five, and Ten.
                case cnst_Ace:
                    id = "A";
                    break;
                case cnst_King:
                    id = "K";
                    break;
                case cnst_Queen:
                    id = "Q";
                    break;
                case cnst_Jack:
                    id = "J";
                    break;
                case cnst_Ten:
                    id = "T";
                    break;
                case cnst_Nine:
                    id = "9";
                    break;
                case cnst_Eight:
                    id = "8";
                    break;
                case cnst_Seven:
                    id = "7";
                    break;
                case cnst_Six:
                    id = "6";
                    break;
                case cnst_Five:
                    id = "5";
                    break;
                case cnst_Four:
                    id = "4";
                    break;
                case cnst_Three:
                    id = "3";
                    break;
                case cnst_Two:
                    id = "2";
                    break;
                case cnst_One:
                    id = "1";
                    break;
                case cnst_Zero:
                    id = "0";
                    break;
                case cnst_Joker:
                    id = "0";
                    break;
                // Jetons only
                case cnst_Twenty:
                    id = "20";
                    break;
                case cnst_Fifty:
                    id = "50";
                    break;
                case cnst_Hundred:
                    id = "100";
                    break;
                case cnst_Thousand:
                    id = "1000";
                    break;
            } // switch
            return id;
        } // method

        public static int value(string tag)
        {
            int val = -1; // invalid
            switch (tag)
            {
                // Colors
                case cnst_Spade:
                    val = 400;
                    break;
                case "S":
                    val = 400;
                    break;
                case cnst_Cross:
                    val = 300;
                    break;
                case "C":
                    val = 300;
                    break;
                case cnst_Heart:
                    val = 200;
                    break;
                case "H":
                    val = 200;
                    break;
                case cnst_Diamond:
                    val = 100;
                    break;
                case "D":
                    val = 100;
                    break;
                // Cards and some for Jetons: One, Five, and Ten.
                case cnst_Ace:
                    val = 50;
                    break;
                case "A":
                    val = 50;
                    break;
                case cnst_King:
                    val = 40;
                    break;
                case "K":
                    val = 40;
                    break;
                case cnst_Queen:
                    val = 30;
                    break;
                case "Q":
                    val = 30;
                    break;
                case cnst_Jack:
                    val = 20;
                    break;
                case "J":
                    val = 20;
                    break;
                case cnst_Ten:
                    val = 10;
                    break;
                case "T":
                    val = 10;
                    break;
                case cnst_Nine:
                    val = 9;
                    break;
                case "9":
                    val = 9;
                    break;
                case cnst_Eight:
                    val = 8;
                    break;
                case "8":
                    val = 8;
                    break;
                case cnst_Seven:
                    val = 7;
                    break;
                case "7":
                    val = 7;
                    break;
                case cnst_Six:
                    val = 6;
                    break;
                case "6":
                    val = 6;
                    break;
                case cnst_Five:
                    val = 5;
                    break;
                case "5":
                    val = 5;
                    break;
                case cnst_Four:
                    val = 4;
                    break;
                case "4":
                    val = 4;
                    break;
                case cnst_Three:
                    val = 3;
                    break;
                case "3":
                    val = 3;
                    break;
                case cnst_Two:
                    val = 2;
                    break;
                case "2":
                    val = 2;
                    break;
                case cnst_One:
                    val = 1;
                    break;
                case "1":
                    val = 1;
                    break;
                case cnst_Zero:
                    val = 0;
                    break;
                case cnst_Joker:
                    val = 0;
                    break;
                case "0":
                    val = 0;
                    break;
                // Jetons only
                case cnst_Twenty:
                    val = 20;
                    break;
                case "20":
                    val = 20;
                    break;
                case cnst_Fifty:
                    val = 50;
                    break;
                case "50":
                    val = 50;
                    break;
                case cnst_Hundred:
                    val = 100;
                    break;
                case "100":
                    val = 100;
                    break;
                case cnst_Thousand:
                    val = 1000;
                    break;
                case "1000":
                    val = 1000;
                    break;
            } // switch
            return val;
        } // method

    } // class
} // namespace
