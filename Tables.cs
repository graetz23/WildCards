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
using System.Collections.Generic;

namespace WildCards
{
    namespace Tables
    {
        using Cards;
        using Rules;
        using Persons;
        using Exceptions;
        using Players = List<Persons.Player>;
        using Stacks = Dictionary<Persons.Player, Cards.Stack>;

        /// <summary>
        /// Takes Cards, registers Players, register a Dealer, and can see.
        /// </summary>
        public class Table
        {
            protected StateMachine _stateMachine = null;

            /// <summary>
            /// The Dealer of this table.
            /// </summary>
            protected Dealer _dealer = null;

            /// <summary>
            /// The registered player of this table
            /// </summary>
            protected Players _players = null;

            protected Stack _foldStack = null;

            protected Stack _placeStack = null;

            public Table()
            {
            } // method

            public Table(Dealer dealer, Players players)
            {
                register(dealer);
                foreach (Player player in players)
                    register(player);
            } // method

            /// <summary>
            /// Register the specified dealer.
            /// </summary>
            /// <param name="dealer">The Dealer object of this Table object.</param>
            protected virtual void register(Dealer dealer)
            {
                if (dealer == null)
                    throw new NotExistent(GetType() + " - given dealer is null");
                _dealer = dealer;
                dealer.register(this);
            } // method

            /// <summary>
            /// Register the specified player.
            /// </summary>
            /// <param name="player">Another Player object of this Table object.</param>
            protected virtual void register(Player player)
            {
                if (player == null)
                    throw new NotExistent(GetType() + " - given dealer is null");
                if (_players == null)
                    _players = new Players();
                _players.Add(player);
                player.register(this);
            } // method

            public void next()
            {
                _stateMachine.next();
                _dealer.next();
                foreach(Player player in _players)
                {
                    player.next();
                } // loop
            } // method

            protected virtual void fold( Card card )
            {
                _foldStack.add(card);
            } // method

            protected virtual void place(Card card)
            {
                _placeStack.add(card);
            } // method

        } // class

        public class TexasHoldEmTable : Table
        {
            protected const int _maxFolded = 2;
            protected const int _maxPlaced = 5;

            public TexasHoldEmTable(Dealer dealer, Players players) : base(dealer, players)
            {
                _stateMachine = new Rules.TexasHoldEm.Poker();

                // max 2 cards folded by 1 card after the Flop + 1 after the River
                _foldStack = new Stack(_maxFolded); // only two can be folded on to the Table object by a texas hold em dealer
                
                // max 5 cards placed by 3 cards as the Flop + 1 as the River + 1 as the Turn
                _placeStack = new Stack(_maxPlaced); // only five can be placed on the Table object by a texas hold em dealer
            } // method

            /// <summary>
            /// Register a teaxs hold em poker dealer.
            /// </summary>
            /// <param name="dealer">The Dealer object of this Table object.</param>
            protected override void register(Dealer dealer)
            {
                base.register(dealer);
                if (!(dealer is TexasHoldEmDealer))
                    throw new NotValid(GetType() + " - given is not a texas hold em dealer");
            } // method

            /// <summary>
            /// Register the a texas hold em player.
            /// </summary>
            /// <param name="player">Another Player object of this Table object.</param>
            protected override void register(Player player)
            {
                base.register(player);
                if (!(player is TexasHoldEmPlayer))
                    throw new NotExistent(GetType() + " - given is not a texas hold em player");
            } // method

            protected override void fold(Card card)
            {
                if (_foldStack.Count > _maxFolded)
                    throw new NotPossible($"{GetType()} - more than {_maxFolded} are folded on the Table by the Dealer");
                base.fold(card); // call method in super class
            } // method

            protected override void place(Card card)
            {
                if (_placeStack.Count > _maxFolded)
                    throw new NotPossible($"{GetType()} - more than {_maxPlaced} are folded on the Table by the Dealer");
                base.place(card); // call method in super class
            } // method



        } // class

    } // namespace
} // namespace
