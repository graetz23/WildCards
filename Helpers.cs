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
using System;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;

namespace WildCards
{
    /// <summary>
    /// Static class and methods for helping out by minor functionality.
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// Compare two strings
        /// </summary>
        /// <remarks>This is ALWAYS NON CASE SENSITIVE comapare</remarks>
        /// <param name="a">some string</param>
        /// <param name="b">another string</param>
        /// <returns>true if symbols are in same sequence - non-case sensitive</returns>
        public static bool compare(string a, string b)
        {
            return _stringComparer.Compare(a, b) == 0;
        } // method
        private static StringComparer _stringComparer = StringComparer.OrdinalIgnoreCase; // check non case sensitive

        /// <summary>
        /// Computes a MD5 hash of a key.
        /// </summary>
        /// <param name="key">the given input of the hash.</param>
        /// <returns>the corresponding MD5 hash for the given key.</returns>
        public static string computeHash(string key)
        {
            string hash = null;
            byte[] data = _hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(key));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
                sBuilder.Append(data[i].ToString("x2"));
            hash = sBuilder.ToString();
            return hash;
        } // method
        private static HashAlgorithm _hashAlgorithm = MD5.Create();

        /// <summary>
        /// Generates an integer random number between 1 and maximum.
        /// </summary>
        /// <remarks>32 signed integer in C#: -2147483648 to 2147483647</remarks>
        /// <returns>a positve random integer value without zero</returns>
        public static int genRandom()
        {
            return Statics.Random.Next(1, Statics.Max);
        } // method

        /// <summary>
        /// Generates a - quasi - UUID using a random on an MD5.
        /// </summary>
        /// <remarks>UUID version 5 and MD5 look the same.</remarks>
        /// <returns>a quasi UUID of version 5</returns>
        public static string genUUID()
        {
            return computeHash(genRandom().ToString());
        } // method

    } // class

} // namespace
