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
  namespace Tables
  {

    using Cards;
    using Dealers;
    using Players;
    using Exceptions;

    /// <summary>
    /// Takes Cards, registers Players register can see.
    /// </summary>
    public class Table
    {
      protected string _excHead = "Table.";

      /// <summary>
      /// The Dealer of this table.
      /// </summary>
      protected Dealer _dealer = null;

      protected List<Player> _players = null;

      protected int _maxNoOfCards = -1;

      protected Stack _stack = null;

      public Table ( int maxNoOfCards )
      {
        string excMsg = _excHead + "Table - ";
        if (maxNoOfCards < 1)
          throw new NotValid (excMsg + "given maximum number of Cards is smaller than 1!");
        _maxNoOfCards = maxNoOfCards;
        _stack = new Stack (_maxNoOfCards);
        _players = new List<Player>( );
      } // method

      /// <summary>
      /// Register the specified dealer.
      /// </summary>
      /// <param name="dealer">Dealer.</param>
      void register( Dealer dealer ) {
        string excMsg = _excHead + "register - ";
        if (dealer == null)
          throw new NotExistent (excMsg + "given dealer is null!");
        _dealer = dealer;
        dealer.register (this);
      } // method

      /// <summary>
      /// Register the specified player.
      /// </summary>
      /// <param name="player">Player.</param>
      void register( Player player ) {
        string excMsg = _excHead + "register - ";
        if (player == null)
          throw new NotExistent (excMsg + "given dealer is null!");
        _players.Add ( player );
        player.register (this);
      } // method

    } // class

  } // namespace
} // namespace
