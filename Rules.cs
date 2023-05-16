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
using System.Linq;
using WildCards.Exceptions;

namespace WildCards
{
    namespace Rules
    {
        using States = Dictionary<State, Transition>;
        using Transitions = Dictionary<string, State>;

        public class State
        {
            protected string _name = null;
            
            private Transitions _transitions = new Transitions();
            
            public State(string name) { _name = name; } // method
            
            public string NAME { get { return _name; } } // method
            
            public Transitions TRANSITIONS { get { return _transitions; } } // method
            
            public State add(Transition transition) { TRANSITIONS.Add(transition.STATE.NAME, transition.STATE); return this; }
            
            protected State changeTo(string name = null)
            {
                State state = null;
                if (name == null)
                {
                    KeyValuePair<string, State> keyValuePair = TRANSITIONS.First();
                    state = keyValuePair.Value;
                }
                else
                {
                    if (!TRANSITIONS.ContainsKey(name))
                    {
                        throw new NotExistent($"{GetType()} - requested state is not transitable");
                    } // if
                    state = TRANSITIONS[name];
                } // if
                return state;
            } // method

            public virtual State next(string name = null) { return changeTo(name); } // method

        } // class

        public class Transition
        {
            protected string _name = null;
            public string NAME { get { return STATE.NAME; } } // method
            private State _state = null;
            public State STATE { get { return _state; } } // method
            public void set(State state) { _state = state; } // method
            public Transition() { } // method
            public Transition(State state) { set(state); } // method
        } // class

        /// <summary>
        /// The common state machine.
        /// </summary>
        public class StateMachine
        {
            protected State _current = null;
            public State CURRENT { get { return _current; } set { _current = value; } }
            public void next()
            {
                CURRENT = CURRENT.next();
            } // method
        } // class

        namespace TexasHoldEm
        {
            // State Machine for Texas Hold Em Poker
            // 0. (Idle)* -> 0 or -> 1
            // 1. (Shuffle)* -> 2
            // 2. (Dealer gives 2 cards to each Player)1 -> 3
            // 3. (Player raise the pot and call)* -> 4
            // 4. (Dealer places the Flop on the Table)1 -> 5
            // 5. (Player raise the pot and call)* -> 6
            // 6. (Dealer places the River on the Table)1 -> 7
            // 7. (Player raise the pot and call)* -> 8
            // 8. (Dealer places the Turn on the Table)1 -> 9
            // 9. (Player raise the pot and call)* -> 10
            //10. (Rating the winner and splitting the pot)* -> 11
            //11. (All cards are returned)1 -> 0

            public static class Tags
            {
                public const string Idling = "Idling";
                public const string Shuffling = "Shuffling";
                public const string Dealing = "Dealing";
                public const string Betting_onDealing = "Betting_onDealing";
                public const string Flop = "Flop";
                public const string Betting_onFlop = "Betting_onFlop";
                public const string River = "River";
                public const string Betting_onRiver = "Betting_onRiver";
                public const string Turn = "Turn";
                public const string Betting_onTurn = "Betting_onTurn";
                public const string Finishing = "Finishing";
                public const string Returning = "Returning";
            } // class

            internal class Idling : State
            {
                public Idling(string name = Tags.Idling) : base(name) { }
                public override State next(string name = Tags.Shuffling)
                {
                    return base.next(name); // not Tags.Idling which is first, instead Tags.Shuffling
                } // method
            } // class
            internal class Shuffling : State { public Shuffling(string name = Tags.Shuffling) : base(name) { } } // class
            internal class Dealing : State { public Dealing(string name = Tags.Dealing) : base(name) { } } // class
            internal class Betting : State { public Betting(string name) : base(name) { } } // class
            internal class Flop : State { public Flop(string name = Tags.Flop) : base(name) { } } // class
            internal class River : State { public River(string name = Tags.River) : base(name) { } } // class
            internal class Turn : State { public Turn(string name = Tags.Turn) : base(name) { } } // class
            internal class Finishing : State { public Finishing(string name = Tags.Finishing) : base(name) { } } // class
            internal class Returning : State { public Returning(string name = Tags.Returning) : base(name) { } } // class


            /// <summary>
            /// The rules - or state machine - for Texas Hold Em Poker.
            /// </summary>
            public class Poker : StateMachine
            {
                public Poker()
                {
                    // creating the states
                    Idling idling = new Idling();
                    Shuffling shuffling = new Shuffling();
                    Dealing dealing = new Dealing();
                    Flop flop = new Flop();
                    River river = new River();
                    Turn turn = new Turn();
                    Finishing finishing = new Finishing();
                    Returning returning = new Returning();

                    // creating the transitions .. and the state machine thou
                    idling.add(new Transition(idling));
                    idling.add(new Transition(shuffling.add(new Transition(dealing))));
                    dealing.add(new Transition(new Betting(Tags.Betting_onDealing).add(new Transition(flop))));
                    flop.add(new Transition(new Betting(Tags.Betting_onFlop).add(new Transition(river))));
                    river.add(new Transition(new Betting(Tags.Betting_onRiver).add(new Transition(turn))));
                    turn.add(new Transition(new Betting(Tags.Betting_onTurn).add(new Transition(finishing))));
                    finishing.add(new Transition(returning.add(new Transition(idling))));

                    // setting initial state
                    CURRENT = idling;
                } // method

            } // class

        } // namespace
    } // namespace
} // namespace
