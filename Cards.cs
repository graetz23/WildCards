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
using System.Collections;
using System.Collections.Generic;

/************************************** 80 ************************************/

namespace WildCards
{
    /// <summary>
    /// Using the namespace Exceptions for throwing errors, failures, etc.
    /// </summary>
    using Exceptions;

    /************************************** 80 ************************************/

    namespace Cards
    {
        /// <summary>
        /// Typedef for a - generic - List of Card objects.
        /// </summary>
        using List_Card = List<Card>;

        /// <summary>
        /// The base class for a playing card.
        /// </summary>
        /// <remarks>
        /// The decorator design pattern in applied.
        /// </remarks>
        /// <example>
        /// To build a card object of a French Deck:
        /// <code>
        /// Card card = new Card( new Spade( new Ace( ) ) );
        /// </code>
        /// </example>
        public class Card : IEquatable<Card>, IComparable<Card>
        {
            /// <summary>
            /// Member variable to represent the decorated object.
            /// </summary>
            protected Card _card = null;

            /// <summary>
            /// The identifier (ID) of the playing card object.
            /// </summary>
            protected string _id = null;

            /// <summary>
            /// The integer value of the playing card.
            /// </summary>
            /// <remarks>
            /// It used for calculations on worthness
            /// and playing strategy
            /// </remarks>
            protected int _value = 0;

            /// <summary>
            /// A part of the unique XML tag of the object.
            /// </summary>
            protected string _xTag = "Card";

            /// <summary>
            /// Initializes a new instance of the <see cref="WildCards.Cards.Card"/> class.
            /// </summary>
            public Card() { } // method

            /// <summary>
            /// Initializes a new instance of the <see cref="WildCards.Cards.Card"/> class.
            /// </summary>
            /// <param name="card">Card.</param>
            /// <exception cref="WildCards.">
            /// Throws a not found excpetion, if the given object is null.
            /// </exception>
            public Card(Card card)
            {
                if (card == null)
                    throw new NotExistent(GetType() + " - given card object is null");
                _card = card;
            } // method

            /// <summary>
            /// Create a copy this instance recursively.
            /// </summary>
            public virtual Card Clone
            {
                get
                {
                    if (_card == null)
                        throw new NotExistent(GetType() + " - internal card object is null");
                    return new Card(_card.Clone);
                } // method
            } // method

            /// <summary>
            /// The value of the playing card.
            /// </summary>
            /// <value>The value of the playing card.</value>
            public int Value
            {
                get
                {
                    int value = gen_value();
                    return value % 100; // 407 => 7
                } // method
            } // method

            /// <summary>
            /// Generates and returns the color of the playing card.
            /// </summary>
            /// <remarks>
            /// 4 = Spades, 3 = Cross, 2 = Heart, and 1 = Diamond.
            /// </remarks>
            /// <value>The color of the playing card.</value>
            public int Color
            {
                get
                {
                    int value = gen_value();
                    int color = value / 100; // 407 => 4
                    return color;
                } // method 
            } // method

            /// <summary>
            /// Generates and returns the ID of the playing card.
            /// </summary>
            /// <value>The identifier or the playing card.</value>
            public string ID
            {
                get
                {
                    return gen_id();
                } // method
            } // method

            /// <summary>
            /// Generates and returns the XML tag of the playing Card.
            /// </summary>
            /// <value>The XML tag of the playing card.</value>
            public string XTag
            {
                get
                {
                    if (_card != null)
                        return _xTag + _card.XTag;
                    else
                        return _xTag;
                } // method 
            } // method

            /// <summary>
            /// Returns the XML tag of the playing card object.
            /// </summary>
            /// <returns>The XML tag of the playing card or object, respectively.</returns>
            public virtual string XML
            {
                get
                {
                    return "<" + XTag + " />" + Environment.NewLine;
                } // method
            } // method

            /// <summary>
            /// Returns the identifier of the playing card object.
            /// </summary>
            /// <returns>The identifier of the playing card.</returns>
            protected virtual string gen_id()
            {
                if (_card != null)
                    return _id + _card.gen_id();
                else
                    return _id;
            } // method

            /// <summary>
            /// Returns the integer value of the playing card object.
            /// </summary>
            /// <remarks>
            /// The value is used for calculations on worthness and
            /// playing strateges.
            /// </remarks>
            /// <returns>The integer value of the playing card.</returns>
            protected virtual int gen_value()
            {
                if (_card != null)
                    return _value + _card.gen_value();
                else
                    return _value;
            } // method

            /// <summary>
            /// Calls - recursively - the method until an ending element of
            /// the Decorator design pattern is reached. The ending element
            /// returns itself.
            /// </summary>
            /// <remarks>
            /// The ending element is identified by a null pointer to the
            /// stored Card object.
            /// reference to null.
            /// </remarks>
            /// <returns>The decorated object or iteself.</returns>
            public virtual Card getInstance()
            {
                if (_card != null)
                {
                    return _card.getInstance();
                }
                else
                {
                    return this;
                } // if
            } // method

            /// <summary>
            /// Determines whether the specified <see cref="WildCards.Cards.Card"/> is equal to the current <see cref="WildCards.Cards.Card"/>.
            /// </summary>
            /// <param name="other">The <see cref="WildCards.Cards.Card"/> to compare with the current <see cref="WildCards.Cards.Card"/>.</param>
            /// <returns><c>true</c> if the specified <see cref="WildCards.Cards.Card"/> is equal to the current
            /// <see cref="WildCards.Cards.Card"/>; otherwise, <c>false</c>.</returns>
            public bool Equals(Card other)
            {
                if (ReferenceEquals(null, other))
                {
                    return false;
                } // if
                if (ReferenceEquals(this, other))
                {
                    return true;
                } // if
                bool result = ID.Equals(other.ID) && Value.Equals(other.Value) && Color.Equals(other.Color);
                return result;
            } // method

            /// <summary>
            /// Determines whether the specified <see cref="System.Object"/> is equal to the current <see cref="WildCards.Cards.Card"/>.
            /// </summary>
            /// <param name="o">The <see cref="System.Object"/> to compare with the current <see cref="WildCards.Cards.Card"/>.</param>
            /// <returns><c>true</c> if the specified <see cref="System.Object"/> is equal to the current
            /// <see cref="WildCards.Cards.Card"/>; otherwise, <c>false</c>.</returns>
            public override bool Equals(Object obj)
            {
                if (ReferenceEquals(null, obj))
                {
                    return false;
                } // if
                if (ReferenceEquals(this, obj))
                {
                    return true;
                } // if
                return obj.GetType() == GetType() && Equals((Card)obj);
            } // method

            /// <summary>
            /// Serves as a hash function for a <see cref="WildCards.Cards.Card"/> object.
            /// </summary>
            /// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures such as a
            /// hash table.</returns>
            public override int GetHashCode()
            {
                unchecked
                {
                    return ID.GetHashCode() ^ Value.GetHashCode() ^ Color.GetHashCode();
                } // method
            } // method

            /// <param name="left">Left.</param>
            /// <param name="right">Right.</param>
            public static bool operator ==(Card obj1, Card obj2)
            {
                if (ReferenceEquals(obj1, obj2))
                {
                    return true;
                }
                if (ReferenceEquals(obj1, null))
                {
                    return false;
                }
                if (ReferenceEquals(obj2, null))
                {
                    return false;
                }
                bool result = obj1.ID.Equals(obj2.ID) && obj1.Value.Equals(obj2.Value) && obj1.Color.Equals(obj2.Color);
                return result;
            } // method

            /// <param name="left">Left.</param>
            /// <param name="right">Right.</param>
            public static bool operator !=(Card left, Card right)
            {
                return !(left == right);
            } // method

            /// <summary>
            /// Methods serves the overloading of comparing operators by generating a result.
            /// </summary>
            /// <returns>The result of comparing one card to another card.</returns>
            /// <param name="other">Other.</param>
            public int CompareTo(Card other)
            {
                if (other == null)
                    throw new NotExistent(GetType() + ".CompareTo - given other card is null!");
                int result = 0;
                int value_Card = this.Value;
                int value_otherCard = other.Value;
                int color = this.Color;
                int color_other = other.Color;
                if (value_Card > value_otherCard)
                {
                    result = 1;
                }
                else if (value_Card < value_otherCard)
                {
                    result = -1;
                }
                else
                {
                    if (color > color_other)
                    {
                        result = 1;
                    }
                    else if (color < color_other)
                    {
                        result = -1;
                    }
                    else
                    {
                        result = 0; // never reached in a normal deck
                    } // if
                } // if
                return result;
            } // method

            /// <param name="left">Left.</param>
            /// <param name="right">Right.</param>
            public static bool operator >(Card left, Card right)
            {
                //if (left == null)
                //    throw new NotExistent("Card.operator > - left is null!");
                //if (right == null)
                //    throw new NotExistent("Card.operator > - right is null!");
                return left.CompareTo(right) > 0;
            } // method

            /// <param name="left">Left.</param>
            /// <param name="right">Right.</param>
            public static bool operator >=(Card left, Card right)
            {
                //if (left == null)
                //    throw new NotExistent("Card.operator >= - left is null!");
                //if (right == null)
                //    throw new NotExistent("Card.operator >= - right is null!");
                return left.CompareTo(right) >= 0;
            } // method

            /// <param name="left">Left.</param>
            /// <param name="right">Right.</param>
            public static bool operator <(Card left, Card right)
            {
                //if (left == null)
                //    throw new NotExistent("Card.operator < - left is null!");
                //if (right == null)
                //    throw new NotExistent("Card.operator < - right is null!");
                return left.CompareTo(right) < 0;
            } // method

            /// <param name="left">Left.</param>
            /// <param name="right">Right.</param>
            public static bool operator <=(Card left, Card right)
            {
                //if (left == null)
                //    throw new NotExistent("Card.operator <= - left is null!");
                //if (right == null)
                //    throw new NotExistent("Card.operator <= - right is null!");
                return left.CompareTo(right) <= 0;
            } // method

        } // class

        /************************************** 80 ************************************/

        /// <summary>
        /// A deck of playing cards.
        /// </summary>
        /// <remarks>
        /// The deck has a Stack object (List<Card> object) and manages to push
        /// Card objects on top of the Stack or to pop Card objects from top of
        /// the Stack. The Stack bject can be retrieved directly - it is not copied.
        /// This is useful if one wants to iterate over all Card objects.
        /// </remarks>
        public class Stack : IEnumerable<Card>
        {
            /// <summary>
            /// The maximum number of cards in this deck.
            /// </summary>
            protected int _maximumNoOfCards = 0;

            /// <summary>
            /// The list of card objects.
            /// </summary>
            protected List<Card> _stack = null;

            public Stack(int maximumNoOfCards)
            {
                if (maximumNoOfCards <= 0)
                    throw new NotValid(GetType() + " - given number of cards is not valid: " + maximumNoOfCards);
                _maximumNoOfCards = maximumNoOfCards;
                _stack = new List<Card>(_maximumNoOfCards); // reserve some memory ahead
            } // method

            public Stack(Stack stack)
            {
                if (stack == null)
                    throw new NotValid(GetType() + " - given stack is null");
                if (stack.Count <= 0)
                    throw new NotValid(GetType() + " - given stack is empty");
                _maximumNoOfCards = stack.Count;
                _stack = new List<Card>(_maximumNoOfCards); // reserve some memory ahead
                _stack.AddRange(stack);
            } // method

            /// <summary>
            /// Getter for the number of Card objects of this deck.
            /// </summary>
            /// <value>Number of Card objects of this deck.</value>
            public int Count
            {
                get
                {
                    if (_stack == null)
                        throw new Error(GetType() + " - internal stack ist null");
                    return _stack.Count;
                }
            } // method

            /// <summary>
            /// Sort this instance.
            /// </summary>
            /// <remarks>
            /// The Card objects get sorted List's functionality.
            /// </remarks>
            public void sort()
            {
                if (_stack == null)
                    throw new Error(GetType() + " - internal stack ist null");
                _stack.Sort();
            } // method

            /// <summary>
            /// Getter for the internal Stack object.
            /// </summary>
            /// <value>The stack.</value>
            public List<Card> Cards
            {
                get
                {
                    if (_stack == null)
                        throw new Error(GetType() + " - internalt stack ist null");
                    return _stack;
                }
                set
                {
                    if (_stack == null)
                        throw new Error(GetType() + " - internalt stack ist null");
                    _stack = value;
                }
            } // method

            /// <summary>
            /// Returns the maximum number of Card objects.
            /// </summary>
            /// <value>The maximum number of Card objects.</value>
            public int Maximum { get { return _maximumNoOfCards; } } // method

            /// <summary>
            /// Add the specified card.
            /// </summary>
            /// <param name="card">Card.</param>
            public void add(Card card)
            {
                if (_stack == null)
                    throw new Error(GetType() + " - internal stack of Card objects is null");
                if (card == null)
                    throw new Error(GetType() + " - given Card objects is null");
                _stack.Add(card);
            } // method

            /// <summary>
            /// Pop a Card object from top of the card stack and remove it.
            /// </summary>
            public Card pop()
            {
                Card card = null;
                if (_stack == null)
                    throw new Error(GetType() + " - internal stack of Card objects is null");
                int top = _stack.Count - 1; // top of the stack
                card = _stack[top]; // from top
                if (card == null)
                    throw new NotExistent(GetType() + " - card object is null");
                _stack.RemoveAt(top); // remove from top
                return card;
            } // method

            /// <summary>
            /// Pop a number of Card objects from the card stack, add those to
            /// a new Stack objectm and remove those in the current Stack object.
            /// </summary>
            /// <param name="noOfCards">The number of Card objects to pop in  a new Stack object.</param>
            public Stack pop(int noOfCards)
            {
                Stack stack = null;
                if (noOfCards <= 0)
                    throw new NotPossible(GetType() + " - given number of cards is not possible: " + noOfCards);
                if (_stack == null)
                    throw new Error(GetType() + " - internal stack of Card objects is null");
                if (noOfCards > _stack.Count)
                    throw new NotPossible(GetType() + " - given number of cards is larger: " + noOfCards +
                      " than those of card stack: " + _stack.Count);
                stack = new Stack(noOfCards);
                for (int i = 0; i < noOfCards; i++)
                {
                    Card card = pop(); // get and remove a card object
                    stack.add(card);
                } // loop
                return stack;
            } // method

            /// <summary>
            /// Push a Card object to the top of the card stack.
            /// </summary>
            /// <param name="card">Adds a Card object at the bottom of the stack</param>
            public void push(Card card)
            {
                if (card == null)
                    throw new NotExistent(GetType() + " - the given card is null");
                if (_stack == null)
                    throw new Error(GetType() + " - internal stack of Card objects is null");
                if (_stack.Count > _maximumNoOfCards)
                    throw new NotPossible(GetType() + " - the stack of the deck is full: " + _maximumNoOfCards);
                _stack.Add(card); // on top
            } // method

            /// <summary>
            /// Push a number of Card ojects to the top of the card stack.
            /// </summary>
            /// <param name="stack">Stack.</param>
            public void push(Stack stack)
            {
                if (stack == null)
                    throw new NotExistent(GetType() + " - given stack of Card objects is null");
                if (_stack == null)
                    throw new Error(GetType() + " - internal stack of Card objects is null");
                int noOfCards = stack.Count;
                if (noOfCards <= 0)
                    throw new NotPossible(GetType() + " - given stack is empty: " + noOfCards);
                int top = noOfCards - 1;
                for (int i = 0; i < noOfCards; i++)
                {
                    int pos = top - i;
                    Card card = stack.removeAt(pos); // get and remove a card object
                    _stack.Add(card);
                } // loop
            } // method

            /// <summary>
            /// Removes at index.
            /// </summary>
            /// <param name="index">Index.</param>
            public Card removeAt(int index)
            {
                Card card = null;
                if (_stack == null)
                    throw new Error(GetType() + " - internal stack of Card objects is null");
                if (index < 0)
                    throw new NotValid(GetType() + " - given index: " + index + " is negativ");
                if (index >= _stack.Count)
                    throw new NotValid(GetType() + " - given index: " + index + " is too large for: " + _stack.Count);
                card = _stack[index];
                _stack.RemoveAt(index);
                return card;
            } // method

            public void clear()
            {
                if (_stack == null)
                    throw new Error(GetType() + " - internal stack of Card objects is null");
                _stack.Clear();
            }

            /// <summary>
            /// Gets the <see cref="WildCards.Cards.Card"/> with the specified i.
            /// </summary>
            /// <param name="i">The index.</param>
            public Card this[int i]
            {
                get
                {
                    Card card = null;
                    if (i < 0)
                        throw new NotValid(GetType() + " - given index i : " + i + " is negativ");
                    if (i >= _stack.Count)
                        throw new NotValid(GetType() + " - given index i : " + i + " is too large for: " + _stack.Count);
                    card = _stack[i];
                    return card;
                } // method
            } // method

            /// <summary>
            /// Get enumerator to iterate over Card objects.
            /// </summary>
            /// <returns>The enumerator.</returns>
            public IEnumerator<Card> GetEnumerator()
            {
                foreach (Card card in _stack)
                {
                    yield return card;
                } // loop
            } // method

            /// <summary>
            /// Gets the enumerator.
            /// </summary>
            /// <returns>The enumerator.</returns>
            IEnumerator<Card> IEnumerable<Card>.GetEnumerator()
            {
                return GetEnumerator();
            } // method

            /// <summary>
            /// Gets the enumerator.
            /// </summary>
            /// <returns>The enumerator.</returns>
            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            } // method

        } // class

        /// <summary>
        /// A - fresh - Deck of playing Card objects.
        /// </summary>
        public class Deck
        {

            /// <summary>
            /// The internal STack of Cards that is get and set.
            /// </summary>
            protected Stack _stack = null;

            /// <summary>
            /// Initializes a new instance of the <see cref="WildCards.Cards.Deck"/> class.
            /// </summary>
            /// <param name="maxNoOfCards">Max no of cards.</param>
            public Deck(int maxNoOfCards)
            {
                _stack = new Stack(maxNoOfCards);
            } // method

            /// <summary>
            /// Gets or sets the stack.
            /// </summary>
            /// <value>The stack.</value>
            public Stack Stack
            {
                get
                {
                    return _stack;
                } // method
                set
                {
                    _stack = value;
                } // method
            } // method

            /// <summary>
            /// Gets the count.
            /// </summary>
            /// <value>The count.</value>
            public int Count
            {
                get
                {
                    int count = 0;
                    if (_stack != null)
                        count = _stack.Count;
                    return count;
                } // method
            } // method

        } // class

        /// <summary>
        /// Deck of 32 playing cards - skat.
        /// </summary>
        public class Deck32 : Deck
        {
            public Deck32() : base(32)
            {
            } // method
        } // class

        /// <summary>
        /// Deck of 52 playing cards - poker.
        /// </summary>
        public class Deck52 : Deck
        {
            public Deck52() : base(52)
            {
            } // method
        } // class

        /************************************** 80 ************************************/

        /// <summary>
        /// Static class for building complete playing card decks.
        /// </summary>
        public static class DeckFactory
        {
            public static Deck buildFrench32()
            {
                Deck deck = new Deck32();
                Stack stack = deck.Stack;
                // spades
                stack.push(CardFactory.build("SA"));
                stack.push(CardFactory.build("SK"));
                stack.push(CardFactory.build("SQ"));
                stack.push(CardFactory.build("SJ"));
                stack.push(CardFactory.build("ST"));
                stack.push(CardFactory.build("S9"));
                stack.push(CardFactory.build("S8"));
                stack.push(CardFactory.build("S7"));
                // cross
                stack.push(CardFactory.build("CA"));
                stack.push(CardFactory.build("CK"));
                stack.push(CardFactory.build("CQ"));
                stack.push(CardFactory.build("CJ"));
                stack.push(CardFactory.build("CT"));
                stack.push(CardFactory.build("C9"));
                stack.push(CardFactory.build("C8"));
                stack.push(CardFactory.build("C7"));
                // hearts
                stack.push(CardFactory.build("HA"));
                stack.push(CardFactory.build("HK"));
                stack.push(CardFactory.build("HQ"));
                stack.push(CardFactory.build("HJ"));
                stack.push(CardFactory.build("HT"));
                stack.push(CardFactory.build("H9"));
                stack.push(CardFactory.build("H8"));
                stack.push(CardFactory.build("H7"));
                // diamonds
                stack.push(CardFactory.build("DA"));
                stack.push(CardFactory.build("DQ"));
                stack.push(CardFactory.build("DD"));
                stack.push(CardFactory.build("DJ"));
                stack.push(CardFactory.build("DT"));
                stack.push(CardFactory.build("D9"));
                stack.push(CardFactory.build("D8"));
                stack.push(CardFactory.build("D7"));
                // verify
                int noOfCards = stack.Count;
                if (noOfCards != 32)
                    throw new NotValid("DeckFactory - number of generated Card ojects is not 32!");
                deck.Stack = stack; // not really necessary
                return deck;
            } // method

            public static Deck buildFrench52()
            {
                Deck deck = new Deck52();
                Stack stack = deck.Stack;
                // spades
                stack.push(CardFactory.build("SA"));
                stack.push(CardFactory.build("SK"));
                stack.push(CardFactory.build("SQ"));
                stack.push(CardFactory.build("SJ"));
                stack.push(CardFactory.build("ST"));
                stack.push(CardFactory.build("S9"));
                stack.push(CardFactory.build("S8"));
                stack.push(CardFactory.build("S7"));
                stack.push(CardFactory.build("S6"));
                stack.push(CardFactory.build("S5"));
                stack.push(CardFactory.build("S4"));
                stack.push(CardFactory.build("S3"));
                stack.push(CardFactory.build("S2"));
                // cross
                stack.push(CardFactory.build("CA"));
                stack.push(CardFactory.build("CK"));
                stack.push(CardFactory.build("CQ"));
                stack.push(CardFactory.build("CJ"));
                stack.push(CardFactory.build("CT"));
                stack.push(CardFactory.build("C9"));
                stack.push(CardFactory.build("C8"));
                stack.push(CardFactory.build("C7"));
                stack.push(CardFactory.build("C6"));
                stack.push(CardFactory.build("C5"));
                stack.push(CardFactory.build("C4"));
                stack.push(CardFactory.build("C3"));
                stack.push(CardFactory.build("C2"));
                // hearts
                stack.push(CardFactory.build("HA"));
                stack.push(CardFactory.build("HK"));
                stack.push(CardFactory.build("HQ"));
                stack.push(CardFactory.build("HJ"));
                stack.push(CardFactory.build("HT"));
                stack.push(CardFactory.build("H9"));
                stack.push(CardFactory.build("H8"));
                stack.push(CardFactory.build("H7"));
                stack.push(CardFactory.build("H6"));
                stack.push(CardFactory.build("H5"));
                stack.push(CardFactory.build("H4"));
                stack.push(CardFactory.build("H3"));
                stack.push(CardFactory.build("H2"));
                // diamonds
                stack.push(CardFactory.build("DA"));
                stack.push(CardFactory.build("DK"));
                stack.push(CardFactory.build("DQ"));
                stack.push(CardFactory.build("DJ"));
                stack.push(CardFactory.build("DT"));
                stack.push(CardFactory.build("D9"));
                stack.push(CardFactory.build("D8"));
                stack.push(CardFactory.build("D7"));
                stack.push(CardFactory.build("D6"));
                stack.push(CardFactory.build("D5"));
                stack.push(CardFactory.build("D4"));
                stack.push(CardFactory.build("D3"));
                stack.push(CardFactory.build("D2"));
                // verify
                int noOfCards = stack.Count;
                if (noOfCards != 52)
                    throw new NotValid("DeckFactory - number of generated Card ojects is not 52!");
                deck.Stack = stack; // not really necessary
                return deck;
            } // method

        } // class

        /************************************** 80 ************************************/

        /// <summary>
        /// Namespace for a French deck of playing cards.
        /// </summary>
        /// <remarks>
        /// The colors of the deck are: Spade, Cross, Heart, Diamond. 
        /// </remarks>
        namespace French
        {

            /// <summary>
            /// Class denotes the color "spades" in the French deck.
            /// </summary>
            /// <remarks>
            /// The decorator design pattern in applied.
            /// </remarks>
            /// <example>
            /// To build a card object of a French deck:
            /// <code>
            /// Card card = new Card( new Spade( new Ace( ) ) );
            /// </code>
            /// </example>
            public class Spade : Card
            {

                /// <summary>
                /// The constructor sets the member for identification and value.
                /// </summary>
                /// <param name="card">Card.</param>
                /// <remarks>
                /// The values for colors are modulo to 100.
                /// </remarks>
                public Spade(Card card) : base(card)
                {
                    _id = Tags.shorten(Tags.Spade);
                    _value = Tags.value(Tags.Spade);
                    _xTag = Tags.Spade;
                } // method

                /// <summary>
                /// Copy this instance.
                /// </summary>
                public override Card Clone
                {
                    get
                    {
                        if (_card == null)
                            throw new NotExistent(GetType() + " - internal card object is null");
                        return new Spade(_card.Clone);
                    } // method
                } // method

            } // class

            /// <summary>
            /// Class denotes the color "cross" in the French deck.
            /// </summary>
            /// <remarks>
            /// The decorator design pattern in applied.
            /// </remarks>
            /// <example>
            /// To build a card object of a French deck:
            /// <code>
            /// Card card = new Card( new Cross( new Ace( ) ) );
            /// </code>
            /// </example>
            public class Cross : Card
            {

                /// <summary>
                /// The constructor sets the member for identification and value.
                /// </summary>
                /// <param name="card">Card.</param>
                /// <remarks>
                /// The values for colors are modulo to 100.
                /// </remarks>
                public Cross(Card card) : base(card)
                {
                    _id = Tags.shorten(Tags.Cross);
                    _value = Tags.value(Tags.Cross);
                    _xTag = Tags.Cross;
                } // method

                /// <summary>
                /// Copy this instance.
                /// </summary>
                public override Card Clone
                {
                    get
                    {
                        if (_card == null)
                            throw new NotExistent(GetType() + " - internal card object is null");
                        return new Cross(_card.Clone);
                    } // method
                } // method

            } // class

            /// <summary>
            /// Class denotes the color "hearts" in the French deck.
            /// </summary>
            /// <remarks>
            /// The decorator design pattern in applied.
            /// </remarks>
            /// <example>
            /// To build a card object of a French deck:
            /// <code>
            /// Card card = new Card( new Heart( new Ace( ) ) );
            /// </code>
            /// </example>
            public class Heart : Card
            {

                /// <summary>
                /// The constructor sets the member for identification and value.
                /// </summary>
                /// <param name="card">Card.</param>
                /// <remarks>
                /// The values for colors are modulo to 100.
                /// </remarks>
                public Heart(Card card) : base(card)
                {
                    _id = Tags.shorten(Tags.Heart);
                    _value = Tags.value(Tags.Heart);
                    _xTag = Tags.Heart;
                } // method

                /// <summary>
                /// Copy this instance.
                /// </summary>
                public override Card Clone
                {
                    get
                    {
                        if (_card == null)
                            throw new NotExistent(GetType() + " - internal card object is null");
                        return new Heart(_card.Clone);
                    } // method
                } // method

            } // class

            /// <summary>
            /// Class denotes the color "diamonds" in the French deck.
            /// </summary>
            /// <remarks>
            /// The decorator design pattern in applied.
            /// </remarks>
            /// <example>
            /// To build a card object of a French deck:
            /// <code>
            /// Card card = new Card( new Diamond( new Ace( ) ) );
            /// </code>
            /// </example>
            public class Diamond : Card
            {

                /// <summary>
                /// The constructor sets the member for identification and value.
                /// </summary>
                /// <param name="card">Card.</param>
                /// <remarks>
                /// The values for colors are modulo to 100.
                /// </remarks>
                public Diamond(Card card) : base(card)
                {
                    _id = Tags.shorten(Tags.Diamond);
                    _value = Tags.value(Tags.Diamond);
                    _xTag = Tags.Diamond;
                } // method

                /// <summary>
                /// Copy this instance.
                /// </summary>
                public override Card Clone
                {
                    get
                    {
                        if (_card == null)
                            throw new NotExistent(GetType() + " - internal card object is null");
                        return new Diamond(_card.Clone);
                    } // method
                } // method

            } // class

        } // namespace

        /// <summary>
        /// The namespace values keeps classes representing all possible
        /// values of playing cards.
        /// </summary>
        /// <remarks>
        /// Each class sets the identifier as string and a value as integer.
        /// The values are like: 2,3,..,8,9,10 for numbered palying cards,
        /// and 20, 30, 40, and 50 for jack, dame, king, and ace.
        /// </remarks>
        namespace Values
        {

            /// <summary>
            /// Class denotes the playing card ace. 
            /// </summary>
            /// <remarks>
            /// The decorator design pattern in applied.
            /// </remarks>
            /// <example>
            /// To build a card object of a French deck:
            /// <code>
            /// Card card = new Card( new Spade( new Ace( ) ) );
            /// </code>
            /// </example>
            public class Ace : Card
            {

                /// <summary>
                /// Initializes a new instance of the <see cref="WildCards.Cards.Values.Ace"/> class.
                /// </summary>
                /// <param name="card">Card.</param>
                public Ace() : base()
                {
                    _id = Tags.shorten(Tags.Ace);
                    _value = Tags.value(Tags.Ace);
                    _xTag = Tags.Ace;
                } // method

                /// <summary>
                /// Copy this instance.
                /// </summary>
                public override Card Clone
                {
                    get
                    {
                        return new Ace();
                    } // method
                } // method

            } // class

            /// <summary>
            /// Class denotes the playing card king. 
            /// </summary>
            /// <remarks>
            /// The decorator design pattern in applied.
            /// </remarks>
            /// <example>
            /// To build a card object of a French deck:
            /// <code>
            /// Card card = new Card( new Spade( new King( ) ) );
            /// </code>
            /// </example>
            public class King : Card
            {

                /// <summary>
                /// Initializes a new instance of the <see cref="WildCards.Cards.Values.King"/> class.
                /// </summary>
                public King() : base()
                {
                    _id = Tags.shorten(Tags.King);
                    _value = Tags.value(Tags.King);
                    _xTag = Tags.King;
                } // method

                /// <summary>
                /// Copy this instance.
                /// </summary>
                public override Card Clone
                {
                    get
                    {
                        return new King();
                    } // method
                } // method

            } // class

            /// <summary>
            /// Class denotes the playing card queen. 
            /// </summary>
            /// <remarks>
            /// The decorator design pattern in applied.
            /// </remarks>
            /// <example>
            /// To build a card object of a French deck:
            /// <code>
            /// Card card = new Card( new Spade( new Queen( ) ) );
            /// </code>
            /// </example>
            public class Queen : Card
            {

                /// <summary>
                /// Initializes a new instance of the <see cref="WildCards.Cards.Values.Queen"/> class.
                /// </summary>
                /// <param name="card">Card.</param>
                public Queen() : base()
                {
                    _id = Tags.shorten(Tags.Queen);
                    _value = Tags.value(Tags.Queen);
                    _xTag = Tags.Queen;
                } // method

                /// <summary>
                /// Copy this instance.
                /// </summary>
                public override Card Clone
                {
                    get
                    {
                        return new Queen();
                    } // method
                } // method

            } // class

            /// <summary>
            /// Class denotes the playing card jack. 
            /// </summary>
            /// <remarks>
            /// The decorator design pattern in applied.
            /// </remarks>
            /// <example>
            /// To build a card object of a French deck:
            /// <code>
            /// Card card = new Card( new Spade( new Jack( ) ) );
            /// </code>
            /// </example>
            public class Jack : Card
            {

                /// <summary>
                /// Initializes a new instance of the <see cref="WildCards.Cards.Values.Jack"/> class.
                /// </summary>
                /// <param name="card">Card.</param>
                public Jack() : base()
                {
                    _id = Tags.shorten(Tags.Jack);
                    _value = Tags.value(Tags.Jack);
                    _xTag = Tags.Jack;
                } // method

                /// <summary>
                /// Copy this instance.
                /// </summary>
                public override Card Clone
                {
                    get
                    {
                        return new Jack();
                    } // method
                } // method

            } // class

            /// <summary>
            /// Class denotes the playing card ten. 
            /// </summary>
            /// <remarks>
            /// The decorator design pattern in applied.
            /// </remarks>
            /// <example>
            /// To build a card object of a French deck:
            /// <code>
            /// Card card = new Card( new Spade( new Ten( ) ) );
            /// </code>
            /// </example>
            public class Ten : Card
            {

                /// <summary>
                /// Initializes a new instance of the <see cref="WildCards.Cards.Values.Ten"/> class.
                /// </summary>
                /// <param name="card">Card.</param>
                public Ten() : base()
                {
                    _id = Tags.shorten(Tags.Ten);
                    _value = Tags.value(Tags.Ten);
                    _xTag = Tags.Ten;
                } // method

                /// <summary>
                /// Copy this instance.
                /// </summary>
                public override Card Clone
                {
                    get
                    {
                        return new Ten();
                    } // method
                } // method

            } // class

            /// <summary>
            /// Class denotes the playing card nine. 
            /// </summary>
            /// <remarks>
            /// The decorator design pattern in applied.
            /// </remarks>
            /// <example>
            /// To build a card object of a French deck:
            /// <code>
            /// Card card = new Card( new Spade( new Nine( ) ) );
            /// </code>
            /// </example>
            public class Nine : Card
            {

                /// <summary>
                /// Initializes a new instance of the <see cref="WildCards.Cards.Values.Nine"/> class.
                /// </summary>
                /// <param name="card">Card.</param>
                public Nine() : base()
                {
                    _id = Tags.shorten(Tags.Nine);
                    _value = Tags.value(Tags.Nine);
                    _xTag = Tags.Nine;
                } // method

                /// <summary>
                /// Copy this instance.
                /// </summary>
                public override Card Clone
                {
                    get
                    {
                        return new Nine();
                    } // method
                } // method

            } // class

            /// <summary>
            /// Class denotes the playing card eight. 
            /// </summary>
            /// <remarks>
            /// The decorator design pattern in applied.
            /// </remarks>
            /// <example>
            /// To build a card object of a French deck:
            /// <code>
            /// Card card = new Card( new Spade( new Eight( ) ) );
            /// </code>
            /// </example>
            public class Eight : Card
            {

                /// <summary>
                /// Initializes a new instance of the <see cref="WildCards.Cards.Values.Eight"/> class.
                /// </summary>
                /// <param name="card">Card.</param>
                public Eight() : base()
                {
                    _id = Tags.shorten(Tags.Eight);
                    _value = Tags.value(Tags.Eight);
                    _xTag = Tags.Eight;
                } // method

                /// <summary>
                /// Copy this instance.
                /// </summary>
                public override Card Clone
                {
                    get
                    {
                        return new Eight();
                    } // method
                } // method

            } // class

            /// <summary>
            /// Class denotes the playing card seven. 
            /// </summary>
            /// <remarks>
            /// The decorator design pattern in applied.
            /// </remarks>
            /// <example>
            /// To build a card object of a French deck:
            /// <code>
            /// Card card = new Card( new Spade( new Seven( ) ) );
            /// </code>
            /// </example>
            public class Seven : Card
            {

                /// <summary>
                /// Initializes a new instance of the <see cref="WildCards.Cards.Values.Seven"/> class.
                /// </summary>
                /// <param name="card">Card.</param>
                public Seven() : base()
                {
                    _id = Tags.shorten(Tags.Seven);
                    _value = Tags.value(Tags.Seven);
                    _xTag = Tags.Seven;
                } // method

                /// <summary>
                /// Copy this instance.
                /// </summary>
                public override Card Clone
                {
                    get
                    {
                        return new Seven();
                    } // method
                } // method

            } // class

            /// <summary>
            /// Class denotes the playing card six. 
            /// </summary>
            /// <remarks>
            /// The decorator design pattern in applied.
            /// </remarks>
            /// <example>
            /// To build a card object of a French deck:
            /// <code>
            /// Card card = new Card( new Spade( new Six( ) ) );
            /// </code>
            /// </example>
            public class Six : Card
            {

                /// <summary>
                /// Initializes a new instance of the <see cref="WildCards.Cards.Values.Six"/> class.
                /// </summary>
                /// <param name="card">Card.</param>
                public Six() : base()
                {
                    _id = Tags.shorten(Tags.Six);
                    _value = Tags.value(Tags.Six);
                    _xTag = Tags.Six;
                } // method

                /// <summary>
                /// Copy this instance.
                /// </summary>
                public override Card Clone
                {
                    get
                    {
                        return new Six();
                    } // method
                } // method

            } // class

            /// <summary>
            /// Class denotes the playing card five. 
            /// </summary>
            /// <remarks>
            /// The decorator design pattern in applied.
            /// </remarks>
            /// <example>
            /// To build a card object of a French deck:
            /// <code>
            /// Card card = new Card( new Spade( new Five( ) ) );
            /// </code>
            /// </example>
            public class Five : Card
            {

                /// <summary>
                /// Initializes a new instance of the <see cref="WildCards.Cards.Values.Five"/> class.
                /// </summary>
                /// <param name="card">Card.</param>
                public Five() : base()
                {
                    _id = Tags.shorten(Tags.Five);
                    _value = Tags.value(Tags.Five);
                    _xTag = Tags.Five;
                } // method

                /// <summary>
                /// Copy this instance.
                /// </summary>
                public override Card Clone
                {
                    get
                    {
                        return new Five();
                    } // method
                } // method

            } // class

            /// <summary>
            /// Class denotes the playing card four. 
            /// </summary>
            /// <remarks>
            /// The decorator design pattern in applied.
            /// </remarks>
            /// <example>
            /// To build a card object of a French deck:
            /// <code>
            /// Card card = new Card( new Spade( new Four( ) ) );
            /// </code>
            /// </example>
            public class Four : Card
            {

                /// <summary>
                /// Initializes a new instance of the <see cref="WildCards.Cards.Values.Four"/> class.
                /// </summary>
                /// <param name="card">Card.</param>
                public Four() : base()
                {
                    _id = Tags.shorten(Tags.Four);
                    _value = Tags.value(Tags.Four);
                    _xTag = Tags.Four;
                } // method

                /// <summary>
                /// Copy this instance.
                /// </summary>
                public override Card Clone
                {
                    get
                    {
                        return new Four();
                    } // method
                } // method

            } // class

            /// <summary>
            /// Class denotes the playing card three. 
            /// </summary>
            /// <remarks>
            /// The decorator design pattern in applied.
            /// </remarks>
            /// <example>
            /// To build a card object of a French deck:
            /// <code>
            /// Card card = new Card( new Spade( new Three( ) ) );
            /// </code>
            /// </example>
            public class Three : Card
            {

                /// <summary>
                /// Initializes a new instance of the <see cref="WildCards.Cards.Values.Three"/> class.
                /// </summary>
                /// <param name="card">Card.</param>
                public Three() : base()
                {
                    _id = Tags.shorten(Tags.Three);
                    _value = Tags.value(Tags.Three);
                    _xTag = Tags.Three;
                } // method

                /// <summary>
                /// Copy this instance.
                /// </summary>
                public override Card Clone
                {
                    get
                    {
                        return new Three();
                    } // method
                } // method

            } // class

            /// <summary>
            /// Class denotes the playing card two. 
            /// </summary>
            /// <remarks>
            /// The decorator design pattern in applied.
            /// </remarks>
            /// <example>
            /// To build a card object of a French deck:
            /// <code>
            /// Card card = new Card( new Spade( new Two( ) ) );
            /// </code>
            /// </example>
            public class Two : Card
            {

                /// <summary>
                /// Initializes a new instance of the <see cref="WildCards.Cards.Values.Two"/> class.
                /// </summary>
                /// <param name="card">Card.</param>
                public Two() : base()
                {
                    _id = Tags.shorten(Tags.Two);
                    _value = Tags.value(Tags.Two);
                    _xTag = Tags.Two;
                } // method

                /// <summary>
                /// Copy this instance.
                /// </summary>
                public override Card Clone
                {
                    get
                    {
                        return new Two();
                    } // method
                } // method

            } // class

            /// <summary>
            /// Class denotes the playing card joker. 
            /// </summary>
            /// <remarks>
            /// The decorator design pattern in applied.
            /// </remarks>
            /// <example>
            /// To build a card object of a French deck:
            /// <code>
            /// Card card = new Card( new Spade( new Joker( ) ) );
            /// </code>
            /// </example>
            public class Joker : Card
            {

                /// <summary>
                /// Initializes a new instance of the <see cref="WildCards.Cards.Values.Joker"/> class.
                /// </summary>
                /// <param name="card">Card.</param>
                public Joker() : base()
                {
                    _id = Tags.shorten(Tags.Joker);
                    _value = Tags.value(Tags.Joker);
                    _xTag = Tags.Joker;
                } // method

                /// <summary>
                /// Copy this instance.
                /// </summary>
                public override Card Clone
                {
                    get
                    {
                        return new Joker();
                    } // method
                } // method

            } // class

        } // namespace
        /************************************** 80 ************************************/

        /// <summary>
        /// Static factory keeping the possible pattern of Card objects and
        /// copies from those patterns new Card objects  on demand.
        /// </summary>
        public static class CardFactory
        {
            /// <summary>
            /// A Cache that is initialized in first built.
            /// </summary>
            private static Dictionary<string, Card> _patternsCache = null;

            /// <summary>
            /// All possible patterns of Card objects that the factory can produce.
            /// </summary>
            /// <remarks>
            /// We apply the prototype design pattern here.
            /// </remarks>
            private static Card[] _cardPrototypes = {
                new Card ( new French.Spade ( new Values.Ace())),
                new Card ( new French.Spade ( new Values.King())),
                new Card ( new French.Spade ( new Values.Queen())),
                new Card ( new French.Spade ( new Values.Jack())),
                new Card ( new French.Spade ( new Values.Ten())),
                new Card ( new French.Spade ( new Values.Nine())),
                new Card ( new French.Spade ( new Values.Eight())),
                new Card ( new French.Spade ( new Values.Seven())),
                new Card ( new French.Spade ( new Values.Six())),
                new Card ( new French.Spade ( new Values.Five())),
                new Card ( new French.Spade ( new Values.Four())),
                new Card ( new French.Spade ( new Values.Three())),
                new Card ( new French.Spade ( new Values.Two())),
                new Card ( new French.Spade ( new Values.Joker())),
                new Card ( new French.Cross ( new Values.Ace())),
                new Card ( new French.Cross ( new Values.King())),
                new Card ( new French.Cross ( new Values.Queen())),
                new Card ( new French.Cross ( new Values.Jack())),
                new Card ( new French.Cross ( new Values.Ten())),
                new Card ( new French.Cross ( new Values.Nine())),
                new Card ( new French.Cross ( new Values.Eight())),
                new Card ( new French.Cross ( new Values.Seven())),
                new Card ( new French.Cross ( new Values.Six())),
                new Card ( new French.Cross ( new Values.Five())),
                new Card ( new French.Cross ( new Values.Four())),
                new Card ( new French.Cross ( new Values.Three())),
                new Card ( new French.Cross ( new Values.Two())),
                new Card ( new French.Cross ( new Values.Joker())),
                new Card ( new French.Heart ( new Values.Ace())),
                new Card ( new French.Heart ( new Values.King())),
                new Card ( new French.Heart ( new Values.Queen())),
                new Card ( new French.Heart ( new Values.Jack())),
                new Card ( new French.Heart ( new Values.Ten())),
                new Card ( new French.Heart ( new Values.Nine())),
                new Card ( new French.Heart ( new Values.Eight())),
                new Card ( new French.Heart ( new Values.Seven())),
                new Card ( new French.Heart ( new Values.Six())),
                new Card ( new French.Heart ( new Values.Five())),
                new Card ( new French.Heart ( new Values.Four())),
                new Card ( new French.Heart ( new Values.Three())),
                new Card ( new French.Heart ( new Values.Two())),
                new Card ( new French.Heart ( new Values.Joker())),
                new Card ( new French.Diamond ( new Values.Ace())),
                new Card ( new French.Diamond ( new Values.King())),
                new Card ( new French.Diamond ( new Values.Queen())),
                new Card ( new French.Diamond ( new Values.Jack())),
                new Card ( new French.Diamond ( new Values.Ten())),
                new Card ( new French.Diamond ( new Values.Nine())),
                new Card ( new French.Diamond ( new Values.Eight())),
                new Card ( new French.Diamond ( new Values.Seven())),
                new Card ( new French.Diamond ( new Values.Six())),
                new Card ( new French.Diamond ( new Values.Five())),
                new Card ( new French.Diamond ( new Values.Four())),
                new Card ( new French.Diamond ( new Values.Three())),
                new Card ( new French.Diamond ( new Values.Two())),
                new Card ( new French.Diamond ( new Values.Joker()))
            }; // arr

            /// <summary>
            /// Build a Card object from a pattern for a certain identifer (ID).
            /// </summary>
            /// <remarks>By first call a cache is build.</remarks>
            /// <returns>a new Card object.</returns>
            /// <param name="id">Identifier.</param>
            public static Card build(string id)
            {
                Card card = null;
                if (_patternsCache == null)
                {
                    _patternsCache = new Dictionary<string, Card>();
                    foreach (Card prototype in _cardPrototypes)
                    {
                        string key = prototype.ID; // upper case
                        Card clone = prototype.Clone;
                        _patternsCache.Add(key, prototype);
                    } // loop
                } // if
                string ID = id.ToUpper(); // upper case
                if (_patternsCache.ContainsKey(ID))
                {
                    card = _patternsCache[ID];
                } // if
                if (card == null)
                    throw new NotFound($"CardFactory - cant not build a Card object for given ID: {id}");
                return card;
            } // method

            /// <summary>
            /// Build a Card object from a pattern by an xTag (XML tag).
            /// </summary>
            /// <returns>a new Card object.</returns>
            /// <param name="xTag">XML tag.</param>
            public static Card build_xTag(string xTag)
            {
                Card card = null;
                foreach (Card pattern in _cardPrototypes)
                {
                    if (xTag == pattern.XTag)
                    {
                        card = pattern.Clone; // clone from pattern          
                    } // if
                } // loop
                if (card == null)
                    throw new NotPossible("CardFactory - building a Card object for xTag: " + xTag + " is not possible!");
                return card;
            } // method

        } // class

    } // namespace
    /************************************** 80 ************************************/
} // namespace
/************************************** 80 ************************************/
