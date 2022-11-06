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
using System.Collections.Generic;

namespace WildCards
{

    using Exceptions;
    using Cards;
    using Cards.French;
    using Cards.Values;
    using Behaviours = List<Cards.Shuffling.Behaviour>;
    using WildCards.Currency;

    class MainClass
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("WildCards ..");
                Console.WriteLine();

                Deck deck = DeckFactory.buildFrench52();
                Stack stack = deck.Stack;

                Console.WriteLine("Fresh deck:");
                Console.WriteLine();
                foreach (Card card in stack)
                {
                    Console.Write(card.ID + " ");
                } // loop
                Console.WriteLine();

                Console.WriteLine();
                Console.WriteLine("Shuffled deck:");
                Console.WriteLine();

                Shuffler shuffler = ShufflerFactory.buildHandwise();
                shuffler.shuffle(stack).shuffle(stack).shuffle(stack);

                foreach (Card card in stack)
                {
                    Console.Write(card.ID + " ");
                } // loop
                Console.WriteLine();

                Console.WriteLine();
                Console.WriteLine("Sorted deck:");
                Console.WriteLine();

                stack.sort();

                foreach (Card card in stack)
                {
                    Console.Write(card.ID + " ");
                } // loop
                Console.WriteLine();

                Console.WriteLine();

                Console.WriteLine();
                Console.WriteLine("Jetons:");
                Console.WriteLine();

                Currency.Bank bank = new Currency.Bank();
                Console.WriteLine($"The bank keeps: {bank.sumUp()}");
                bank.hasIntegrity();
                Console.WriteLine();

                List<Currency.Jeton> jetons = bank.change(9999);
                bool areRegisterd = bank.registered(jetons);
                int dollar = bank.change(jetons);
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Message);
            } // try

#if DEBUG
            Console.WriteLine($"<press any key to exit>");
            Console.ReadKey();
#endif

        } // method
    } // class
} // namespace
