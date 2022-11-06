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
        // Colors
        public static string Spade { get { return "Spade"; } }
        public static string Cross { get { return "Cross"; } }
        public static string Heart { get { return "Heart"; } }
        public static string Diamond { get { return "Diamond"; } }
        // Cards and some for Jetons: One, Five, and Ten.
        public static string Ace { get { return "Ace"; } }
        public static string King { get { return "King"; } }
        public static string Queen { get { return "Queen"; } }
        public static string Jack { get { return "Jack"; } }
        public static string Ten { get { return "Ten"; } }
        public static string Nine { get { return "Nine"; } }
        public static string Eight { get { return "Eight"; } }
        public static string Seven { get { return "Seven"; } }
        public static string Six { get { return "Six"; } }
        public static string Five { get { return "Five"; } }
        public static string Four { get { return "Four"; } }
        public static string Three { get { return "Three"; } }
        public static string Two { get { return "Two"; } }
        public static string One { get { return "One"; } }
        public static string Joker { get { return "Joker"; } }
        // Jetons
        public static string Twenty { get { return "Twenty"; } }
        public static string Fifty { get { return "Fifty"; } }
        public static string Hundred { get { return "Hundred"; } }
        public static string Thousand { get { return "Thousand"; } }

        public static string shorten(string tag)
        {
            string id = null;
            switch (tag.ToLower())
            {
                // Colors
                case "spade":
                    id = "S";
                    break;
                case "cross":
                    id = "C";
                    break;
                case "heart":
                    id = "H";
                    break;
                case "diamond":
                    id = "D";
                    break;
                // Cards and some for Jetons: One, Five, and Ten.
                case "ace":
                    id = "A";
                    break;
                case "king":
                    id = "K";
                    break;
                case "queen":
                    id = "Q";
                    break;
                case "jack":
                    id = "J";
                    break;
                case "ten":
                    id = "T";
                    break;
                case "nine":
                    id = "9";
                    break;
                case "eight":
                    id = "8";
                    break;
                case "seven":
                    id = "7";
                    break;
                case "six":
                    id = "6";
                    break;
                case "five":
                    id = "5";
                    break;
                case "four":
                    id = "4";
                    break;
                case "three":
                    id = "3";
                    break;
                case "two":
                    id = "2";
                    break;
                case "one":
                    id = "1";
                    break;
                case "joker":
                    id = "0";
                    break;
                // Jetons only
                case "twenty":
                    id = "20";
                    break;
                case "fifty":
                    id = "50";
                    break;
                case "hundred":
                    id = "100";
                    break;
                case "thousand":
                    id = "1000";
                    break;
            } // switch
            return id;
        } // method

        public static int value(string tag)
        {
            int val = -1; // invalid
            switch (tag.ToLower())
            {
                // Colors
                case "spade":
                    val = 400;
                    break;
                case "s":
                    val = 400;
                    break;
                case "cross":
                    val = 300;
                    break;
                case "c":
                    val = 300;
                    break;
                case "heart":
                    val = 200;
                    break;
                case "h":
                    val = 200;
                    break;
                case "diamond":
                    val = 100;
                    break;
                case "d":
                    val = 100;
                    break;
                // Cards and some for Jetons: One, Five, and Ten.
                case "ace":
                    val = 50;
                    break;
                case "a":
                    val = 50;
                    break;
                case "king":
                    val = 40;
                    break;
                case "k":
                    val = 40;
                    break;
                case "queen":
                    val = 30;
                    break;
                case "q":
                    val = 30;
                    break;
                case "jack":
                    val = 20;
                    break;
                case "j":
                    val = 20;
                    break;
                case "ten":
                    val = 10;
                    break;
                case "t":
                    val = 10;
                    break;
                case "nine":
                    val = 9;
                    break;
                case "9":
                    val = 9;
                    break;
                case "eight":
                    val = 8;
                    break;
                case "8":
                    val = 8;
                    break;
                case "seven":
                    val = 7;
                    break;
                case "7":
                    val = 7;
                    break;
                case "six":
                    val = 6;
                    break;
                case "6":
                    val = 6;
                    break;
                case "five":
                    val = 5;
                    break;
                case "5":
                    val = 5;
                    break;
                case "four":
                    val = 4;
                    break;
                case "4":
                    val = 4;
                    break;
                case "three":
                    val = 3;
                    break;
                case "3":
                    val = 3;
                    break;
                case "two":
                    val = 2;
                    break;
                case "2":
                    val = 2;
                    break;
                case "one":
                    val = 1;
                    break;
                case "1":
                    val = 1;
                    break;
                case "joker":
                    val = 0;
                    break;
                case "0":
                    val = 0;
                    break;
                // Jetons only
                case "twenty":
                    val = 20;
                    break;
                case "20":
                    val = 20;
                    break;
                case "fifty":
                    val = 50;
                    break;
                case "50":
                    val = 50;
                    break;
                case "hundred":
                    val = 100;
                    break;
                case "100":
                    val = 100;
                    break;
                case "thousand":
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
