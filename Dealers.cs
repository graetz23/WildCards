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
    namespace Persons
    {
        using Cards;
        using Tables;
        using Exceptions;
        using WildCards.Rules;

        public class Dealer
        {
            protected StateMachine _stateMachine = null;

            protected Deck _deck = null;

            protected Table _table = null;

            Shuffler _shuffler = null;

            public Dealer(Deck deck)
            {
                if (_deck == null)
                    throw new NotExistent(GetType() + " - given deck is null");
                _deck = deck;
                _shuffler = ShufflerFactory.buildHandwise();
            } // method

            /// <summary>
            /// Gets or sets the stack.
            /// </summary>
            /// <value>The stack.</value>
            public Stack Stack
            {
                get
                {
                    return _deck.Stack;
                } // method
                set
                {
                    if (value == null)
                        throw new NotExistent(GetType() + " - given stack is null");
                    _deck.Stack = value;
                } // method
            } // method

            public void next()
            {
                _stateMachine.next();
            } // method

            /// <summary>
            /// Shuffling the Stack of cards.
            /// </summary>
            /// <remarks>
            /// Each created Dealer objects shuffles its Stack rndomly.
            /// </remarks>
            public virtual void shuffling()
            {
                if (_shuffler == null)
                    throw new NotExistent(GetType() + " - internal shuffler is null");
                if (_deck == null)
                    throw new NotExistent(GetType() + " - internal deck is null");
                if (_deck.Stack == null)
                    throw new NotExistent(GetType() + " - internal stack is null");
                _shuffler.shuffle(_deck).shuffle(_deck).shuffle(_deck);
            } // method

            /// <summary>
            /// Pop a Card object.
            /// </summary>
            public Card pop()
            {
                if (_deck == null)
                    throw new NotExistent(GetType() + " - internal deck is null");
                if (_deck.Stack == null)
                    throw new NotExistent(GetType() + " - internal stack is null");
                return _deck.Stack.pop();
            } // method

            /// <summary>
            /// Push the specified card to Dealer's stack.
            /// </summary>
            /// <param name="card">Card.</param>
            public void push(Card card)
            {
                if (_deck == null)
                    throw new NotExistent(GetType() + " - internal deck is null");
                if (_deck.Stack == null)
                    throw new NotExistent(GetType() + " - internal stack is null");
                _deck.Stack.push(card);
            } // method

            /// <summary>
            /// Register the specified table.
            /// </summary>
            /// <param name="table">Table.</param>
            public void register(Table table)
            {
                if (table == null)
                    throw new NotExistent(GetType() + " - given stack is null!");
                _table = table;
            } // method

        } // class

        public class TexasHoldEmDealer : Dealer
        {
            public TexasHoldEmDealer() : base(new Deck52())
            {
                _stateMachine = new Rules.TexasHoldEm.Poker();
            } // method

        } // class

    } // namespace
} // namespace

