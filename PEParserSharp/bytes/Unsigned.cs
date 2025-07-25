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
/// A utility class for static access to unsigned number functionality.
/// <para>
/// It essentially contains factory methods for unsigned number wrappers. In
/// future versions, it will also contain some arithmetic methods, handling
/// regular arithmetic and bitwise operations
/// 
/// @author Lukas Eder
/// </para>
/// </summary>
public sealed class Unsigned
{

    /// <summary>
    /// Create an <code>unsigned byte</code>
    /// </summary>
    /// <exception cref="NumberFormatException"> If <code>value</code> does not contain a
    ///             parsable <code>unsigned byte</code>. </exception>
    /// <seealso cref="UByte.valueOf(String)"/>
    //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
    //ORIGINAL LINE: public static UByte ubyte(String value) throws NumberFormatException
    public static UByte Ubyte(string value) => string.ReferenceEquals(value, null) ? null : UByte.ValueOf(value);

    /// <summary>
    /// Create an <code>unsigned byte</code> by masking it with <code>0xFF</code>
    /// i.e. <code>(byte) -1</code> becomes <code>(ubyte) 255</code>
    /// </summary>
    /// <seealso cref="UByte.valueOf(byte)"/>
    public static UByte Ubyte(sbyte value) => UByte.ValueOf(value);

    /// <summary>
    /// Create an <code>unsigned byte</code>
    /// </summary>
    /// <exception cref="NumberFormatException"> If <code>value</code> is not in the range
    ///             of an <code>unsigned byte</code> </exception>
    /// <seealso cref="UByte.ValueOf(short)"/>
    //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
    //ORIGINAL LINE: public static UByte ubyte(short value) throws NumberFormatException
    public static UByte Ubyte(short value) => UByte.ValueOf(value);

    /// <summary>
    /// Create an <code>unsigned byte</code>
    /// </summary>
    /// <exception cref="NumberFormatException"> If <code>value</code> is not in the range
    ///             of an <code>unsigned byte</code> </exception>
    /// <seealso cref="UByte.ValueOf(short)"/>
    //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
    //ORIGINAL LINE: public static UByte ubyte(int value) throws NumberFormatException
    public static UByte Ubyte(int value) => UByte.ValueOf(value);

    /// <summary>
    /// Create an <code>unsigned byte</code>
    /// </summary>
    /// <exception cref="NumberFormatException"> If <code>value</code> is not in the range
    ///             of an <code>unsigned byte</code> </exception>
    /// <seealso cref="UByte.ValueOf(short)"/>
    //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
    //ORIGINAL LINE: public static UByte ubyte(long value) throws NumberFormatException
    public static UByte Ubyte(long value) => UByte.ValueOf(value);

    /// <summary>
    /// Create an <code>unsigned short</code>
    /// </summary>
    /// <exception cref="NumberFormatException"> If <code>value</code> does not contain a
    ///             parsable <code>unsigned short</code>. </exception>
    /// <seealso cref="UShort.valueOf(String)"/>
    //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
    //ORIGINAL LINE: public static UShort ushort(String value) throws NumberFormatException
    public static UShort Ushort(string value) => value is null ? null : UShort.ValueOf(value);

    /// <summary>
    /// Create an <code>unsigned short</code> by masking it with
    /// <code>0xFFFF</code> i.e. <code>(short) -1</code> becomes
    /// <code>(ushort) 65535</code>
    /// </summary>
    /// <seealso cref="UShort.ValueOf(short)"/>
    public static UShort Ushort(short value) => UShort.ValueOf(value);

    /// <summary>
    /// Create an <code>unsigned short</code>
    /// </summary>
    /// <exception cref="NumberFormatException"> If <code>value</code> is not in the range
    ///             of an <code>unsigned short</code> </exception>
    /// <seealso cref="UShort.ValueOf(int)"/>
    //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
    //ORIGINAL LINE: public static UShort ushort(int value) throws NumberFormatException
    public static UShort Ushort(int value) => UShort.ValueOf(value);

    /// <summary>
    /// Create an <code>unsigned int</code>
    /// </summary>
    /// <exception cref="NumberFormatException"> If <code>value</code> does not contain a
    ///             parsable <code>unsigned int</code>. </exception>
    /// <seealso cref="UInteger.valueOf(String)"/>
    //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
    //ORIGINAL LINE: public static UInteger uint(String value) throws NumberFormatException
    public static UInteger Uint(string value) => string.ReferenceEquals(value, null) ? null : UInteger.ValueOf(value);

    /// <summary>
    /// Create an <code>unsigned int</code> by masking it with
    /// <code>0xFFFFFFFF</code> i.e. <code>(int) -1</code> becomes
    /// <code>(uint) 4294967295</code>
    /// </summary>
    /// <seealso cref="UInteger.ValueOf(int)"/>
    public static UInteger Uint(int value) => UInteger.ValueOf(value);

    /// <summary>
    /// Create an <code>unsigned int</code>
    /// </summary>
    /// <exception cref="NumberFormatException"> If <code>value</code> is not in the range
    ///             of an <code>unsigned int</code> </exception>
    /// <seealso cref="UInteger.ValueOf(long)"/>
    //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
    //ORIGINAL LINE: public static UInteger uint(long value) throws NumberFormatException
    public static UInteger Uint(long value) => UInteger.ValueOf(value);

    /// <summary>
    /// Create an <code>unsigned long</code>
    /// </summary>
    /// <exception cref="NumberFormatException"> If <code>value</code> does not contain a
    ///             parsable <code>unsigned long</code>. </exception>
    /// <seealso cref="ULong.valueOf(String)"/>
    //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
    //ORIGINAL LINE: public static ULong ulong(String value) throws NumberFormatException
    public static ULong Ulong(string value) => string.ReferenceEquals(value, null) ? null : ULong.ValueOf(value);

    /// <summary>
    /// Create an <code>unsigned long</code> by masking it with
    /// <code>0xFFFFFFFFFFFFFFFF</code> i.e. <code>(long) -1</code> becomes
    /// <code>(uint) 18446744073709551615</code>
    /// </summary>
    /// <seealso cref="ULong.ValueOf(long)"/>
    public static ULong Ulong(long value) => ULong.ValueOf(value);

    /// <summary>
    /// Create an <code>unsigned long</code>
    /// </summary>
    /// <exception cref="NumberFormatException"> If <code>value</code> is not in the range
    ///             of an <code>unsigned long</code> </exception>
    /// <seealso cref="ULong.ValueOf(BigInteger)"/>
    //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
    //ORIGINAL LINE: public static ULong ulong(java.math.BigInteger value) throws NumberFormatException
    public static ULong Ulong(BigInteger value) => ULong.ValueOf(value);

    /// <summary>
    /// No instances
    /// </summary>
    private Unsigned()
    {
    }
}