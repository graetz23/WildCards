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
    /// <summary>
    /// Players ot Dealers (Croupies).
    /// </summary>
    namespace Persons
    {
        using Cards;
        using Rules;
        using Tables;
        using Currency;
        using Exceptions;
        using System.Collections.Generic;

        public class Player
        {
            protected StateMachine _stateMachine = null;

            protected Set _staple = null; // for Jeton objects

            protected Stack _hand = null; // for Card objects

            protected Table _table = null; // for commanding StateMachine and playing Cards

            public Player(int maxNoOfCards)
            {
                _staple = new Set();
                if (maxNoOfCards < 1)
                    throw new NotValid(GetType() + " - given maximum number of Cards is smaller than 1!");
                _hand = new Stack(maxNoOfCards);
            } // method

            public void next()
            {
                _stateMachine.next();
            } // method

            /// <summary>
            /// Pop Card instance.
            /// </summary>
            public Card pop()
            {
                return _hand.pop();
            } // method

            /// <summary>
            /// Push the specified card to hand.
            /// </summary>
            /// <param name="card">Card.</param>
            public void push(Card card)
            {
                _hand.push(card);
            } // method

            /// <summary>
            /// Register the specified table.
            /// </summary>
            /// <param name="table">Table.</param>
            public void register(Table table)
            {
                if (table == null)
                    throw new NotExistent(GetType() + " - given dealer is null!");
                _table = table;
            } // method

        } // class

        public class TexasHoldEmPlayer : Player
        {

            public TexasHoldEmPlayer(int maxNoOfCards) : base(maxNoOfCards)
            {
                _stateMachine = new Rules.TexasHoldEm.Poker();
            } // method

        } // class

    } // namespace
} // namespace
