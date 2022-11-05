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

/************************************** 80 ************************************/
namespace WildCards
{
  /************************************** 80 ************************************/
  namespace Exceptions
  {
    /************************************** 80 ************************************/

    /// <summary>
    /// The base exception class of the namespace.
    /// </summary>
    /// <remarks>
    /// Any exception can be caught by this class.
    /// </remarks>
    /// <example>
    /// The used patterns are:
    /// <code>
    /// try {
    ///   throw new Error( "error message" );
    /// } catch( WildCards.Exception e ) {
    ///   System.Console.WriteLine( e.Message );
    ///   // do something special depending on type 
    ///   // or just print the stack trace:
    ///   System.Console.WriteLine( e.StackTrace );
    /// } // try
    /// </code>
    /// </example>
    public class Exception : System.Exception
    {
      public Exception () : base ("WildCards.")
      {
      }
      // method
      public Exception (string msg) : base ("WildCards."+msg)
      { 
      }
      // method
      public Exception (string msg, Exception e) : base ("WildCards."+msg, e)
      {
      }
      // method
    }
    // method

    public class Error : WildCards.Exceptions.Exception
    {
      public Error () : base (" - ERROR!")
      {
      }
      // method
      public Error (string msg) : base (msg+" - ERROR!")
      {
      }
      // method
      public Error (string msg, Exception e) : base (msg+" - ERROR!", e)
      {
      }
      // method
    }
    // method

    public class Failure : WildCards.Exceptions.Exception
    {
      public Failure () : base (" - FAILURE!")
      {
      }
      // method
      public Failure (string msg) : base (msg+" - FAILURE!")
      {
      }
      // method
      public Failure (string msg, Exception e) : base (msg+" - FAILURE!", e)
      {
      }
      // method
    }
    // method

    public class NotExistent : WildCards.Exceptions.Exception
    {
      public NotExistent () : base (" - NOT_EXISTENT!")
      {
      }
      // method
      public NotExistent (string msg) : base (msg+" - NOT_EXISTENT!")
      {
      }
      // method
      public NotExistent (string msg, Exception e) : base (msg+" - NOT_EXISTENT!", e)
      {
      }
      // method
    }
    // method

    public class NotFound : WildCards.Exceptions.Exception
    {
      public NotFound () : base (" - NOT_FOUND!")
      {
      }
      // method
      public NotFound (string msg) : base (msg+" - NOT_FOUND!")
      {
      }
      // method
      public NotFound (string msg, Exception e) : base (msg+" - NOT_FOUND!", e)
      {
      }
      // method
    }
    // method

    public class NotPossible : WildCards.Exceptions.Exception
    {
      public NotPossible () : base (" - NOT_POSSIBLE!")
      {
      }
      // method
      public NotPossible (string msg) : base (msg+" - NOT_POSSIBLE!")
      {
      }
      // method
      public NotPossible (string msg, Exception e) : base (msg+" - NOT_POSSIBLE!", e)
      {
      }
      // method
    }
    // method
    
    public class NotValid : WildCards.Exceptions.Exception
    {
      public NotValid () : base (" - NOT_VALID!")
      {
      }
      // method
      public NotValid (string msg) : base (msg+" - NOT_VALID!")
      {
      }
      // method
      public NotValid (string msg, Exception e) : base (msg+" - NOT_VALID!", e)
      {
      }
      // method
    }
    // method
    /************************************** 80 ************************************/

    public class Types
    {
      public Types ()
      {
      } // method
    } // class

  } // namespace

} // namespace

