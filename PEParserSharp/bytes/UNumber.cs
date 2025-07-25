﻿using System.Numerics;

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

public abstract class Number
{
    //public abstract byte byteValue();
    public abstract double DoubleValue { get; }
    public abstract float FloatValue { get; }
    public abstract int IntValue { get; }

    public abstract long LongValue { get; }
    //public abstract short shortValue();
}

/// <summary>
/// A base type for unsigned numbers.
/// 
/// @author Lukas Eder
/// </summary>
public abstract class UNumber : Number
{
    /// <summary>
    /// Converts this number to a hex string representation
    /// </summary>
    public abstract string ToHexString();

    /// <summary>
    /// Get this number as a <seealso cref="System.Numerics.BigInteger"/>. This is a convenience method for
    /// calling <code>new BigInteger(toString())</code>
    /// </summary>
    public virtual BigInteger ToBigInteger() => BigInteger.Parse(ToString());
}