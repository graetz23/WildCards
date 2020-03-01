//
// WildCards is distributed under the MIT License (MIT); this file is part of.
//
// Copyright (c) 2018-2020 Christian (graetz23@gmail.com)
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

namespace WildCards
{
  /// <summary>
  /// Players ot Dealers (Croupies).
  /// </summary>
  namespace Players
  {
    using Cards;
    using Tables;
    using Dealers;
    using Exceptions;

    public class Player
    {
      protected string _excHead = "Player.";

      protected Stack _hand = null;

      protected Table _table = null;

      public Player (int maxNoOfCards)
      {
        string excMsg = _excHead + "Player - ";
        if (maxNoOfCards < 1)
          throw new NotValid (excMsg + "given maximum number of Cards is smaller than 1!");
        _hand = new Stack (maxNoOfCards);
      } // method

      /// <summary>
      /// Pop Card instance.
      /// </summary>
      public Card pop() {
        return _hand.pop ();
      } // method

      /// <summary>
      /// Push the specified card to hand.
      /// </summary>
      /// <param name="card">Card.</param>
      public void push( Card card ) {
        _hand.push (card);
      } // method

      /// <summary>
      /// Register the specified table.
      /// </summary>
      /// <param name="table">Table.</param>
      public void register( Table table ) {
        string excMsg = _excHead + "register - ";
        if (table == null)
          throw new NotExistent (excMsg + "given dealer is null!");
        _table = table;
      } // method

    } // class
  } // namespace
} // namespace
