﻿using System;
using System.Numerics;

/// <summary>
/// Copyright (c) 2011-2013, Lukas Eder, lukas.eder@gmail.com
/// All rights reserved.
/// 
/// This software is licensed to you under the Apache License, Version 2.0
/// (the "License"); You may obtain a copy of the License at
/// 
///   http://www.apache.org/licenses/LICENSE-2.0
/// 
/// Redistribution and use in source and binary forms, with or without
/// modification, are permitted provided that the following conditions are met:
/// 
/// . Redistributions of source code must retain the above copyright notice, this
///   list of conditions and the following disclaimer.
/// 
/// . Redistributions in binary form must reproduce the above copyright notice,
///   this list of conditions and the following disclaimer in the documentation
///   and/or other materials provided with the distribution.
/// 
/// . Neither the name "jOOU" nor the names of its contributors may be
///   used to endorse or promote products derived from this software without
///   specific prior written permission.
/// 
/// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
/// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
/// IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE
/// ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE
/// LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR
/// CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF
/// SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS
/// INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN
/// CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
/// ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
/// POSSIBILITY OF SUCH DAMAGE.
/// </summary>
namespace PEParserSharp.Bytes;


/// <summary>
/// The <code>unsigned long</code> type
/// 
/// @author Lukas Eder
/// </summary>
public sealed class ULong : UNumber, IComparable<ULong>
{

    /// <summary>
    /// A constant holding the minimum value an <code>unsigned long</code> can
    /// have, 0.
    /// </summary>
    public static readonly BigInteger MIN_VALUE = BigInteger.Zero;

    /// <summary>
    /// A constant holding the maximum value an <code>unsigned long</code> can
    /// have, 2<sup>64</sup>-1.
    /// </summary>
    public static readonly BigInteger MAX_VALUE = BigInteger.Parse("18446744073709551615");

    /// <summary>
    /// A constant holding the maximum value + 1 an <code>signed long</code> can
    /// have, 2<sup>63</sup>.
    /// </summary>
    public static readonly BigInteger MAX_VALUE_LONG = BigInteger.Parse("9223372036854775808");

    /// <summary>
    /// The value modelling the content of this <code>unsigned long</code>
    /// </summary>
    private readonly BigInteger value;

    /// <summary>
    /// Create an <code>unsigned long</code>
    /// </summary>
    /// <exception cref="NumberFormatException"> If <code>value</code> does not contain a
    ///             parsable <code>unsigned long</code>. </exception>
    //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
    //ORIGINAL LINE: public static ULong valueOf(String value) throws NumberFormatException
    public static ULong ValueOf(string value) => new ULong(value);

    /// <summary>
    /// Create an <code>unsigned long</code> by masking it with
    /// <code>0xFFFFFFFFFFFFFFFF</code> i.e. <code>(long) -1</code> becomes
    /// <code>(uint) 18446744073709551615</code>
    /// </summary>
    public static ULong ValueOf(long value) => new (value);

    /// <summary>
    /// Create an <code>unsigned long</code>
    /// </summary>
    /// <exception cref="NumberFormatException"> If <code>value</code> is not in the range
    ///             of an <code>unsigned long</code> </exception>
    //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
    //ORIGINAL LINE: public static ULong valueOf(java.math.BigInteger value) throws NumberFormatException
    public static ULong ValueOf(BigInteger value) => new (value);

    /// <summary>
    /// Create an <code>unsigned long</code>
    /// </summary>
    /// <exception cref="NumberFormatException"> If <code>value</code> is not in the range
    ///             of an <code>unsigned long</code> </exception>
    //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
    //ORIGINAL LINE: private ULong(java.math.BigInteger value) throws NumberFormatException
    private ULong(BigInteger value)
    {
        this.value = value;
        RangeCheck();
    }

    /// <summary>
    /// Create an <code>unsigned long</code> by masking it with
    /// <code>0xFFFFFFFFFFFFFFFF</code> i.e. <code>(long) -1</code> becomes
    /// <code>(uint) 18446744073709551615</code>
    /// </summary>
    private ULong(long value)
    {
        this.value = value >= 0 ? (BigInteger)value : value & long.MaxValue + MAX_VALUE_LONG;
    }

    /// <summary>
    /// Create an <code>unsigned long</code>
    /// </summary>
    /// <exception cref="NumberFormatException"> If <code>value</code> does not contain a
    ///             parsable <code>unsigned long</code>. </exception>
    //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
    //ORIGINAL LINE: private ULong(String value) throws NumberFormatException
    private ULong(string value)
    {
        this.value = BigInteger.Parse(value);
        RangeCheck();
    }

    //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
    //ORIGINAL LINE: private void rangeCheck() throws NumberFormatException
    private void RangeCheck()
    {
        if (this.value.CompareTo(MIN_VALUE) < 0 || this.value.CompareTo(MAX_VALUE) > 0)
        {
            throw new System.FormatException("Value is out of range : " + this.value);
        }
    }

    public override int IntValue => (int)(uint)(this.value & uint.MaxValue);

    public override long LongValue => (long)this.value;

    public override float FloatValue => (float)this.value;

    public override double DoubleValue => (double)this.value;

    public override int GetHashCode() => this.value.GetHashCode();

    public override bool Equals(object obj)
    {
        if (object.ReferenceEquals(this, obj))
        {
            return true;
        }

        if (obj is ULong u)
        {
            return this.value.Equals(u.value);
        }

        return false;
    }

    /// <summary>
    /// Get this number as a <seealso cref="System.Numerics.BigInteger"/>. This is a convenience method for
    /// calling <code>new BigInteger(toString())</code>
    /// </summary>
    public override BigInteger ToBigInteger() => this.value;

    public override string ToString() => this.value.ToString();

    public override string ToHexString() => Convert.ToHexString(this.value.ToByteArray());

    public int CompareTo(ULong o) => this.value.CompareTo(o.value);
}