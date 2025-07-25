using System;
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
/// The <code>unsigned byte</code> type
/// 
/// @author Lukas Eder
/// @author Ed Schaller
/// </summary>
public sealed class UByte : UNumber, IComparable<UByte>
{

    /// <summary>
    /// Cached values
    /// </summary>
    private static readonly UByte[] VALUES = MakeValues();

    /// <summary>
    /// A constant holding the minimum value an <code>unsigned byte</code> can
    /// have, 0.
    /// </summary>
    public const short MIN_VALUE = 0x00;

    /// <summary>
    /// A constant holding the maximum value an <code>unsigned byte</code> can
    /// have, 2<sup>8</sup>-1.
    /// </summary>
    public const short MAX_VALUE = 0xff;

    public sbyte ByteValue => (sbyte)value;

    /// <summary>
    /// The value modelling the content of this <code>unsigned byte</code>
    /// </summary>
    private readonly short value;

    /// <summary>
    /// Generate a cached value for each byte value.
    /// </summary>
    /// <returns> Array of cached values for UByte. </returns>
    private static UByte[] MakeValues()
    {
        var ret = new UByte[256];

        for (int i = sbyte.MinValue; i <= sbyte.MaxValue; i++)
        {
            ret[i & MAX_VALUE] = new UByte((sbyte)i);
        }
        return ret;
    }

    /// <summary>
    /// Get an instance of an <code>unsigned byte</code>
    /// </summary>
    /// <exception cref="NumberFormatException"> If <code>value</code> does not contain a
    ///             parsable <code>unsigned byte</code>. </exception>
    //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
    //ORIGINAL LINE: public static UByte valueOf(String value) throws NumberFormatException
    public static UByte ValueOf(string value) => ValueOfUnchecked(RangeCheck(short.Parse(value)));

    /// <summary>
    /// Get an instance of an <code>unsigned byte</code> by masking it with
    /// <code>0xFF</code> i.e. <code>(byte) -1</code> becomes
    /// <code>(ubyte) 255</code>
    /// </summary>
    public static UByte ValueOf(sbyte value) => ValueOfUnchecked((short)(value & MAX_VALUE));

    /// <summary>
    /// Get the value of a short without checking the value.
    /// </summary>
    //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
    //ORIGINAL LINE: private static UByte valueOfUnchecked(short value) throws NumberFormatException
    private static UByte ValueOfUnchecked(short value) => VALUES[value & MAX_VALUE];

    /// <summary>
    /// Get an instance of an <code>unsigned byte</code>
    /// </summary>
    /// <exception cref="NumberFormatException"> If <code>value</code> is not in the range
    ///             of an <code>unsigned byte</code> </exception>
    //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
    //ORIGINAL LINE: public static UByte valueOf(short value) throws NumberFormatException
    public static UByte ValueOf(short value) => ValueOfUnchecked(RangeCheck(value));

    /// <summary>
    /// Get an instance of an <code>unsigned byte</code>
    /// </summary>
    /// <exception cref="NumberFormatException"> If <code>value</code> is not in the range
    ///             of an <code>unsigned byte</code> </exception>
    //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
    //ORIGINAL LINE: public static UByte valueOf(int value) throws NumberFormatException
    public static UByte ValueOf(int value) => ValueOfUnchecked(RangeCheck(value));

    /// <summary>
    /// Get an instance of an <code>unsigned byte</code>
    /// </summary>
    /// <exception cref="NumberFormatException"> If <code>value</code> is not in the range
    ///             of an <code>unsigned byte</code> </exception>
    //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
    //ORIGINAL LINE: public static UByte valueOf(long value) throws NumberFormatException
    public static UByte ValueOf(long value) => ValueOfUnchecked(RangeCheck(value));

    /// <summary>
    /// Create an <code>unsigned byte</code>
    /// </summary>
    /// <exception cref="NumberFormatException"> If <code>value</code> is not in the range
    ///             of an <code>unsigned byte</code> </exception>
    //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
    //ORIGINAL LINE: private UByte(long value) throws NumberFormatException
    private UByte(long value) => this.value = RangeCheck(value);

    /// <summary>
    /// Create an <code>unsigned byte</code>
    /// </summary>
    /// <exception cref="NumberFormatException"> If <code>value</code> is not in the range
    ///             of an <code>unsigned byte</code> </exception>
    //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
    //ORIGINAL LINE: private UByte(int value) throws NumberFormatException
    private UByte(int value) => this.value = RangeCheck(value);

    /// <summary>
    /// Create an <code>unsigned byte</code>
    /// </summary>
    /// <exception cref="NumberFormatException"> If <code>value</code> is not in the range
    ///             of an <code>unsigned byte</code> </exception>
    //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
    //ORIGINAL LINE: private UByte(short value) throws NumberFormatException
    private UByte(short value) => this.value = RangeCheck(value);

    /// <summary>
    /// Create an <code>unsigned byte</code> by masking it with <code>0xFF</code>
    /// i.e. <code>(byte) -1</code> becomes <code>(ubyte) 255</code>
    /// </summary>
    private UByte(sbyte value) => this.value = (short)(value & MAX_VALUE);

    /// <summary>
    /// Create an <code>unsigned byte</code>
    /// </summary>
    /// <exception cref="NumberFormatException"> If <code>value</code> does not contain a
    ///             parsable <code>unsigned byte</code>. </exception>
    //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
    //ORIGINAL LINE: private UByte(String value) throws NumberFormatException
    private UByte(string value) => this.value = RangeCheck(short.Parse(value));

    /// <summary>
    /// Throw exception if value out of range (short version)
    /// </summary>
    /// <param name="value"> Value to check </param>
    /// <returns> value if it is in range </returns>
    /// <exception cref="NumberFormatException"> if value is out of range </exception>
    //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
    //ORIGINAL LINE: private static short rangeCheck(short value) throws NumberFormatException
    private static short RangeCheck(short value) => value < MIN_VALUE || value > MAX_VALUE ? throw new System.FormatException("Value is out of range : " + value) : value;

    /// <summary>
    /// Throw exception if value out of range (int version)
    /// </summary>
    /// <param name="value"> Value to check </param>
    /// <returns> value if it is in range </returns>
    /// <exception cref="NumberFormatException"> if value is out of range </exception>
    //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
    //ORIGINAL LINE: private static short rangeCheck(int value) throws NumberFormatException
    private static short RangeCheck(int value) => value < MIN_VALUE || value > MAX_VALUE ? throw new System.FormatException("Value is out of range : " + value) : (short)value;

    /// <summary>
    /// Throw exception if value out of range (long version)
    /// </summary>
    /// <param name="value"> Value to check </param>
    /// <returns> value if it is in range </returns>
    /// <exception cref="NumberFormatException"> if value is out of range </exception>
    //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
    //ORIGINAL LINE: private static short rangeCheck(long value) throws NumberFormatException
    private static short RangeCheck(long value) => value < MIN_VALUE || value > MAX_VALUE ? throw new System.FormatException("Value is out of range : " + value) : (short)value;

    /// <summary>
    /// Replace version read through deserialization with cached version. Note
    /// that this does not use the <seealso cref="ValueOfUnchecked(short)"/> as we have no
    /// guarantee that the value from the stream is valid.
    /// </summary>
    /// <returns> cached instance of this object's value </returns>
    /// <exception cref="ObjectStreamException"> </exception>
    //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
    //ORIGINAL LINE: private Object readResolve() throws java.io.ObjectStreamException
    private object ReadResolve() => ValueOf(this.value);

    public override int intValue => this.value;

    public override long longValue => this.value;

    public override float floatValue => this.value;

    public override double doubleValue => this.value;

    public override int GetHashCode() => Convert.ToInt16(this.value).GetHashCode();

    public override bool Equals(object obj)
    {
        if (object.ReferenceEquals(this, obj))
        {
            return true;
        }
        if (obj is UByte u)
        {
            return this.value == u.value;
        }

        return false;
    }

    public override string ToString() => Convert.ToInt16(this.value).ToString();

    public override string ToHexString() => this.value.ToString("x");

    public int CompareTo(UByte o) => value < o.value ? -1 : this.value == o.value ? 0 : 1;

    public override BigInteger ToBigInteger() => this.value;
}