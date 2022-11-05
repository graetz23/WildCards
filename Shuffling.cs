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
    using WildCards.Cards.Shuffling;

    /************************************** 80 ************************************/

    namespace Cards
    {
        /// <summary>
        /// Keeping shuffling behaviours that are applied by a Shuffler.
        /// </summary>
        namespace Shuffling
        {

            /// <summary>
            /// Typedefs used in this namespace.
            /// </summary>
            using Behaviours = List<Behaviour>;

            /// <summary>
            /// Base class for a shulling behaviour of a shuffler.
            /// </summary>
            public abstract class Behaviour
            {

                /// <summary>
                /// The general number of shufflings per behaviour.
                /// </summary>
                protected readonly int _shufflings = 12;

                /// <summary>
                /// Abstract method for specializing the kind of shulling.
                /// </summary>
                /// <remarks>
                /// The Strategy design pattern is applied.
                /// </remarks>
                /// <param name="Stack">The Stack keeping all Card objects.</param>
                /// <returns>The shuffled Stack keeping all Card objects</returns>
                public abstract void shuffle(Stack stack); // method

            } // class

            /// <summary>
            /// A hand wise shuffling behaviour.
            /// </summary>
            /// <remarks>
            /// The Strategy design pattern is applied.</remarks>
            public class HandWise : Behaviour
            {

                /// <summary>
                /// Cards are hand wise shuffled in random stack sizes
                /// as a specialized kind of shulling.
                /// </summary>
                /// <remarks>The Strategy design pattern is applied.</remarks>
                /// <param name="Stack">The Stack keeping all Card objects.</param>
                /// <returns>The shuffled Stack keeping all Card objects</returns>
                public override void shuffle(Stack stack)
                {
                    Random random = Statics.Random;
                    int shufflings = _shufflings;
                    int maximum = stack.Count;
                    int handSize = maximum / 4;
                    for (int s = 0; s < shufflings; s++)
                    {
                        int stackSize = random.Next(3, handSize);
                        Stack leftHand = new Stack(maximum);
                        Stack rightHand = new Stack(handSize);
                        for (int c = 1; c <= maximum; c++)
                        {
                            rightHand.add(stack[stack.Count - 1]);
                            stack.removeAt(stack.Count - 1);
                            if (c % stackSize == 0)
                            {
                                int stackCountInner = rightHand.Count;
                                for (int t = 0; t < stackCountInner; t++)
                                {
                                    leftHand.add(rightHand[rightHand.Count - 1]);
                                    rightHand.removeAt(rightHand.Count - 1);
                                } // loop
                            } // if
                        } // loop
                        int rightHandCountOutter = rightHand.Count;
                        for (int t = 0; t < rightHandCountOutter; t++)
                        {
                            leftHand.add(rightHand[rightHand.Count - 1]);
                            rightHand.removeAt(rightHand.Count - 1);
                        } // loop
                          // stack.Clear (); 
                        foreach (Card card in leftHand)
                        {
                            stack.add(card);
                        } // loop
                        leftHand.clear();
                        rightHand.clear();
                    } // loop
                } // method

            } // class

            /// <summary>
            /// A half stacked shuffling behaviour.
            /// </summary>
            public class HalfStacked : Behaviour
            {

                /// <summary>
                /// Card are half stacked and stapled as a specialized kind of shulling.
                /// </summary>
                /// <remarks>The Strategy design pattern is applied.</remarks>
                /// <param name="Stack">The Stack keeping all Card objects.</param>
                /// <returns>The shuffled Stack keeping all Card objects</returns>
                public override void shuffle(Stack stack)
                {
                    int shufflings = _shufflings;
                    int maximum = stack.Count;
                    int half = maximum / 2; // must be even thou
                    Stack leftHand = new Stack(half);
                    Stack rightHand = new Stack(half);
                    for (int i = 1; i < shufflings; i++)
                    {
                        int cnt_cards = 0;
                        foreach (Card card in stack)
                        {
                            if (cnt_cards % 2 == 0)
                                leftHand.add(card);
                            else
                                rightHand.add(card);
                            cnt_cards++;
                        } // loop
                        stack.clear();
                        foreach (Card card in leftHand)
                        {
                            stack.add(card);
                        } // loop
                        leftHand.clear();
                        foreach (Card card in rightHand)
                        {
                            stack.add(card);
                        } // loop
                        rightHand.clear();
                    } // loop
                } // method

            } // class

            /// <summary>
            /// A table spreaded shuffling behaviour.
            /// </summary>
            /// <remarks>
            /// The Strategy design pattern is applied.
            /// </remarks>
            public class TableSpreaded : Behaviour
            {

                /// <summary>
                /// Cards are spread over the table as a specialized kind of shulling.
                /// </summary>
                /// <remarks>The Strategy design pattern is applied.</remarks>
                /// <param name="Stack">The Stack keeping all Card objects.</param>
                /// <returns>The shuffled Stack keeping all Card objects</returns>
                public override void shuffle(Stack stack)
                {
                    Random random = Statics.Random;
                    int shufflings = _shufflings;
                    int maximum = stack.Count;
                    Stack table = new Stack(maximum);
                    for (int i = 0; i < shufflings; i++)
                    {
                        for (int c = 0; c < maximum; c++)
                        {
                            int last = stack.Count - 1;
                            int pos = random.Next(0, last);
                            Card card = stack.removeAt(pos);
                            table.add(card);
                        } // loop
                        stack.clear();
                        foreach (Card card in table)
                        {
                            stack.add(card);
                        } // loop
                        table.clear();
                    } // loop
                } // method

            } // class

            /// <summary>
            /// Up side down shuffling of cards.
            /// </summary>
            /// <remarks>
            /// The Strategy design pattern is applied.
            /// </remarks>
            public class UpSideDown : Behaviour
            {

                /// <summary>
                /// Cards are shuffled up side down as a specialized kind of shulling.
                /// </summary>
                /// <remarks>The Strategy design pattern is applied.</remarks>
                /// <param name="Stack">The Stack keeping all Card objects.</param>
                /// <returns>The shuffled Stack keeping all Card objects</returns>
                /// <param name="stack">Stack.</param>
                public override void shuffle(Stack stack)
                {
                    int maximum = stack.Count;
                    Stack leftHand = new Stack(maximum);
                    for (int c = 0; c < maximum; c++)
                    {
                        int last = stack.Count - 1;
                        Card card = stack.removeAt(last);
                        leftHand.add(card);
                    } // loop
                    stack.clear();
                    foreach (Card card in leftHand)
                    {
                        stack.add(card);
                    } // loop
                } // method

            } // class

            /// <summary>
            /// A stacked shuffling behaviour.
            /// </summary>
            public class Stacked : Behaviour
            {

                /// <summary>
                /// Card are stacked and stapled as a specialized kind of shuffling.
                /// </summary>
                /// <remarks>The Strategy design pattern is applied.</remarks>
                /// <param name="Stack">The Stack keeping all Card objects.</param>
                /// <returns>The shuffled Stack keeping all Card objects</returns>
                public override void shuffle(Stack stack)
                {
                    int shufflings = _shufflings;
                    int maximum = stack.Count;
                    int size = Statics.Random.Next(12, maximum);
                    for (int i = 1; i < shufflings; i++)
                    {
                        Stack leftHand = stack.pop(size); // a number of cards from top
                        Stack rightHand = new Stack(stack); // the left ones 

                        stack.clear();
                        foreach (Card card in rightHand)
                        {
                            stack.add(card);
                        } // loop
                        rightHand.clear();
                        foreach (Card card in leftHand)
                        {
                            stack.add(card);
                        } // loop
                        leftHand.clear();
                    } // loop
                } // method

            } // class

            /// <summary>
            /// Fake kind of shuffling of cards.
            /// </summary>
            /// <remarks>
            /// The Strategy design pattern is applied.
            /// </remarks>
            public class Faked : Behaviour
            {

                /// <summary>
                /// Cards are NOT shuffled as a FAKED kind of shuffling.
                /// </summary>
                /// <remarks>The Strategy design pattern is applied.</remarks>
                /// <param name="Stack">The Stack keeping all Card objects.</param>
                /// <returns>The shuffled Stack keeping all Card objects</returns>
                /// <param name="stack">Stack.</param>
                public override void shuffle(Stack stack)
                {
                } // method

            } // class

            public static class Factory
            {

                /// <summary>
                /// The max no of available behaviours.
                /// </summary>
                private static int _maxNoOfAvailableBehaviours = 6;

                private static int _min_noOfBehaviours = 32;
                private static int _max_noOfBehaviours = 144;

                /// <summary>
                /// Builds a random number of 12 to 144 randomly
                /// selected shuffling behaiours.
                /// </summary>
                /// <returns>
                /// A random number of randomly selected shuffling behaviours.
                /// </returns>
                public static Behaviours buildRandomly()
                {
                    int noOfBehaviours = Statics.Random.Next(_min_noOfBehaviours, _max_noOfBehaviours);
                    Behaviours behaviours = buildRandomly(noOfBehaviours);
                    return behaviours;
                } // method

                /// <summary>
                /// Builds randomly a given number of shuffling behaviours.
                /// </summary>
                /// <returns>A list of random shuffling behaviours.</returns>
                /// <param name="noOfBehaviours">No of behaviours.</param>
                public static Behaviours buildRandomly(int noOfBehaviours)
                {
                    Random random = Statics.Random;
                    if (noOfBehaviours < 1)
                        throw new NotPossible("Shuffling.Factory - given no of behaviours is smaller than 1!");
                    Behaviours behaviours = new Behaviours(noOfBehaviours);
                    for (int b = 0; b < noOfBehaviours; b++)
                    {
                        int kind = random.Next(0, _maxNoOfAvailableBehaviours);
                        Behaviour behaviour = buildBy(kind);
                        behaviours.Add(behaviour);
                    } // loop
                    return behaviours;
                } // method

                /// <summary>
                /// Builds a random number of 12 to 144 randomly
                /// selected handwise or halfstacked shuffling behaiours.
                /// </summary>
                /// <returns>
                /// A random number of randomly selected shuffling behaviours.
                /// </returns>
                public static Behaviours buildHandwise()
                {
                    int noOfBehaviours = Statics.Random.Next(_min_noOfBehaviours, _max_noOfBehaviours);
                    Behaviours behaviours = buildHanded(noOfBehaviours);
                    return behaviours;
                } // method

                /// <summary>
                /// Builds handwise and halfstacked shuffling behaviours.
                /// </summary>
                /// <returns>The handed.</returns>
                /// <param name="noOfBehaviours">No of behaviours.</param>
                public static Behaviours buildHanded(int noOfBehaviours)
                {
                    Random random = Statics.Random;
                    if (noOfBehaviours < 1)
                        throw new NotPossible("Shuffling.Factory - given no of behaviours is smaller than 1!");
                    Behaviours behaviours = new Behaviours(noOfBehaviours);
                    for (int b = 0; b < noOfBehaviours; b++)
                    {
                        int kind = random.Next(1, 4);
                        Behaviour behaviour = buildBy(kind);
                        behaviours.Add(behaviour);
                    }
                    return behaviours;
                } // method

                /// <summary>
                /// Build the specified kind of shuffling behaviour.
                /// </summary>
                /// <remarks>
                /// Private method for randomly building a behaviour.
                /// </remarks>
                /// <param name="kind">Shall be 0 to 4.</param>
                private static Behaviour buildBy(int kind)
                {
                    Behaviour behaviour = null;
                    switch (kind)
                    {
                        case 0:
                            behaviour = new Faked();
                            break;
                        case 1:
                            behaviour = new HandWise();
                            break;
                        case 2:
                            behaviour = new Stacked();
                            break;
                        case 3:
                            behaviour = new HalfStacked();
                            break;
                        case 4:
                            behaviour = new TableSpreaded();
                            break;
                        case 5:
                            behaviour = new UpSideDown();
                            break;
                        default:
                            throw new NotValid("Shuffling.Factory - given kind: " + kind + " is not valid!");
                    } // switch
                    return behaviour;
                } // method

            } // class

        } // namespace

        /// <summary>
        /// Classical card shuffling from one hand to another.
        /// </summary>
        public class Shuffler
        {
            /// <summary>
            /// All shuffling behaviours that are applied to the given Deck.
            /// </summary>
            private List<Shuffling.Behaviour> _behaviours = null;

            /// <summary>
            /// Initializes a new instance of the <see cref="WildCards.Cards.Shufflers.Shuffler"/> class.
            /// </summary>
            public Shuffler()
            {
                _behaviours = new List<Shuffling.Behaviour>();
            } // method

            /// <summary>
            /// Add a specified behaviour.
            /// </summary>
            /// <param name="behaviour">A shuffling Behaviour.</param>
            public void add(Shuffling.Behaviour behaviour)
            {
                if (behaviour == null)
                    throw new NotExistent($"{GetType()} - given behaviour is null");
                _behaviours.Add(behaviour);
            } // method

            /// <summary>
            /// Shuffles the stack by all added behaviours of the Shuffler.
            /// </summary>
            /// <param name="stack">Stack.</param>
            public Shuffler shuffle(Stack stack)
            {
                if (stack == null)
                    throw new NotExistent($"{GetType()} - given stack is null");
                foreach (Shuffling.Behaviour behaviour in _behaviours)
                {
                    behaviour.shuffle(stack);
                } // loop
                return this;
            } // method

            /// <summary>
            /// Shuffles the deck by all added behaviours of the Shuffler.
            /// </summary>
            /// <param name="deck">Deck.</param>
            public Shuffler shuffle(Deck deck)
            {
                if (deck == null)
                    throw new NotExistent($"{GetType()} - given deck is null");
                shuffle(deck.Stack);
                return this;
            } // method

        } // class

        public static class ShufflerFactory
        {
            public static Shuffler buildRandomly()
            {
                Shuffler shuffler = new Shuffler();
                List<Behaviour> behaviours = Factory.buildRandomly();
                foreach (Behaviour behaviour in behaviours)
                {
                    shuffler.add(behaviour);
                } // loop
                return shuffler;
            } // method

            public static Shuffler buildHandwise()
            {
                Shuffler shuffler = new Shuffler();
                List<Behaviour> behaviours = Factory.buildHandwise();
                foreach (Behaviour behaviour in behaviours)
                {
                    shuffler.add(behaviour);
                } // loop
                return shuffler;
            } // method

        } // class

    } // namespace
    /************************************** 80 ************************************/
} // namespace
/************************************** 80 ************************************/
