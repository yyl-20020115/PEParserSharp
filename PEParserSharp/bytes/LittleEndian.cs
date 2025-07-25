using System;
using System.IO;
using System.Numerics;

/*
 * Copyright 2014 dorkbox, llc
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
namespace PEParserSharp.Bytes;


/// <summary>
/// This is intel/amd/arm arch!
/// <p/>
/// arm is technically bi-endian
/// <p/>
/// Network byte order IS big endian, as is Java.
/// </summary>
public static class LittleEndian
{
    // the following are ALL in Little-Endian (byte[0] is LEAST significant)

    /// <summary>
    /// CHAR to and from bytes
    /// </summary>
    public static class Char
    {
        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @SuppressWarnings("fallthrough") public static char from(final byte[] bytes, final int offset, final int byteNum)
        public static char From(in sbyte[] bytes, in int offset, in int byteNum)
        {
            var number = char.MinValue;

            switch (byteNum)
            {
                case 2:
                    number |= (char)((bytes[offset + 1] & 0xFF) << 8);
                    goto case 1;
                case 1:
                    number |= (char)((bytes[offset + 0] & 0xFF) << 0);
                    break;
            }

            return number;
        }

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @SuppressWarnings("fallthrough") public static char from(final byte[] bytes)
        public static char From(in sbyte[] bytes)
        {
            var number = char.MinValue;

            switch (bytes.Length)
            {
                default:
                    goto case 2;
                case 2:
                    number |= (char)((bytes[1] & 0xFF) << 8);
                    goto case 1;
                case 1:
                    number |= (char)((bytes[0] & 0xFF) << 0);
                    break;
            }

            return number;
        }

        public static char From(in sbyte b0, in sbyte b1) => (char)((b1 & 0xFF) << 8 | (b0 & 0xFF) << 0);

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: public static char from(final java.io.InputStream inputStream) throws java.io.IOException
        public static char From(in Stream inputStream) => From((sbyte)inputStream.ReadByte(), (sbyte)inputStream.ReadByte());

        public static sbyte[] ToBytes(in char x) => [(sbyte)(x >> 0), (sbyte)(x >> 8)];

        public static void ToBytes(in char x, in sbyte[] bytes, in int offset)
        {
            bytes[offset + 1] = (sbyte)(x >> 8);
            bytes[offset + 0] = (sbyte)(x >> 0);
        }

        public static void ToBytes(in char x, in sbyte[] bytes)
        {
            bytes[1] = (sbyte)(x >> 8);
            bytes[0] = (sbyte)(x >> 0);
        }
    }


    /// <summary>
    /// UNSIGNED CHAR to and from bytes
    /// </summary>
    public static class UChar
    {
        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @SuppressWarnings("fallthrough") public static UShort from(final byte[] bytes, final int offset, final int bytenum)
        public static Bytes.UShort From(in sbyte[] bytes, in int offset, in int bytenum)
        {
            var number = char.MinValue;

            switch (bytenum)
            {
                case 2:
                    number |= (char)((bytes[offset + 1] & 0xFF) << 8);
                    goto case 1;
                case 1:
                    number |= (char)((bytes[offset + 0] & 0xFF) << 0);
                    break;
            }

            return Bytes.UShort.ValueOf(number);
        }

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @SuppressWarnings("fallthrough") public static UShort from(final byte[] bytes)
        public static Bytes.UShort From(in sbyte[] bytes)
        {
            short number = 0;

            switch (bytes.Length)
            {
                default:
                    goto case 2;
                case 2:
                    number |= (short)((bytes[1] & 0xFF) << 8);
                    goto case 1;
                case 1:
                    number |= (short)((bytes[0] & 0xFF) << 0);
                    break;
            }

            return Bytes.UShort.ValueOf(number);
        }

        public static Bytes.UShort From(in sbyte b0, in sbyte b1) => Bytes.UShort.ValueOf((short)((b1 & 0xFF) << 8) | ((b0 & 0xFF) << 0));

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: public static UShort from(final java.io.InputStream inputStream) throws java.io.IOException
        public static Bytes.UShort From(in Stream inputStream) => From((sbyte)inputStream.ReadByte(), (sbyte)inputStream.ReadByte());

        public static sbyte[] ToBytes(Bytes.UShort x)
        {
            int num = x.IntValue;

            return [(sbyte)(num & 0x00FF >> 0), (sbyte)((num & 0xFF00) >> 8)];
        }

        public static void ToBytes(in Bytes.UShort x, in sbyte[] bytes, in int offset)
        {
            int num = x.IntValue;

            bytes[offset + 1] = (sbyte)((num & 0xFF00) >> 8);
            bytes[offset + 0] = (sbyte)(num & 0x00FF >> 0);
        }

        public static void ToBytes(in Bytes.UShort x, in sbyte[] bytes)
        {
            int num = x.IntValue;

            bytes[1] = (sbyte)((num & 0xFF00) >> 8);
            bytes[0] = (sbyte)(num & 0x00FF >> 0);
        }
    }

    /// <summary>
    /// SHORT to and from bytes
    /// </summary>
    public static class Short
    {
        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @SuppressWarnings("fallthrough") public static short from(final byte[] bytes, final int offset, final int bytenum)
        public static short From(in sbyte[] bytes, in int offset, in int bytenum)
        {
            short number = 0;

            switch (bytenum)
            {
                case 2:
                    number |= (short)((bytes[offset + 1] & 0xFF) << 8);
                    goto case 1;
                case 1:
                    number |= (short)((bytes[offset + 0] & 0xFF) << 0);
                    break;
            }

            return number;
        }

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @SuppressWarnings("fallthrough") public static short from(final byte[] bytes)
        public static short From(in sbyte[] bytes)
        {
            short number = 0;

            switch (bytes.Length)
            {
                default:
                    goto case 2;
                case 2:
                    number |= (short)((bytes[1] & 0xFF) << 8);
                    goto case 1;
                case 1:
                    number |= (short)((bytes[0] & 0xFF) << 0);
                    break;
            }

            return number;
        }

        public static short From(in sbyte b0, in sbyte b1) => (short)(((b1 & 0xFF) << 8) | ((b0 & 0xFF) << 0));

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: public static short from(final java.io.InputStream inputStream) throws java.io.IOException
        public static short From(in Stream inputStream) => From((sbyte)inputStream.ReadByte(), (sbyte)inputStream.ReadByte());

        public static sbyte[] ToBytes(in short x) => [(sbyte)(x >> 0), (sbyte)(x >> 8)];

        public static void ToBytes(in short x, in sbyte[] bytes, in int offset)
        {
            bytes[offset + 1] = (sbyte)(x >> 8);
            bytes[offset + 0] = (sbyte)(x >> 0);
        }

        public static void ToBytes(in short x, in sbyte[] bytes)
        {
            bytes[1] = (sbyte)(x >> 8);
            bytes[0] = (sbyte)(x >> 0);
        }
    }


    /// <summary>
    /// UNSIGNED SHORT to and from bytes
    /// </summary>
    public static class UShort
    {
        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @SuppressWarnings("fallthrough") public static UShort from(final byte[] bytes, final int offset, final int bytenum)
        public static Bytes.UShort From(in sbyte[] bytes, in int offset, in int bytenum)
        {
            short number = 0;

            switch (bytenum)
            {
                case 2:
                    number |= (short)((bytes[offset + 1] & 0xFF) << 8);
                    goto case 1;
                case 1:
                    number |= (short)((bytes[offset + 0] & 0xFF) << 0);
                    break;
            }

            return Bytes.UShort.ValueOf(number);
        }

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @SuppressWarnings("fallthrough") public static UShort from(final byte[] bytes)
        public static Bytes.UShort From(in sbyte[] bytes)
        {
            short number = 0;

            switch (bytes.Length)
            {
                default:
                    goto case 2;
                case 2:
                    number |= (short)((bytes[1] & 0xFF) << 8);
                    goto case 1;
                case 1:
                    number |= (short)((bytes[0] & 0xFF) << 0);
                    break;
            }

            return Bytes.UShort.ValueOf(number);
        }

        public static Bytes.UShort From(in sbyte b0, in sbyte b1)
        => Bytes.UShort.ValueOf((short)((b1 & 0xFF) << 8 | (b0 & 0xFF) << 0));

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: public static UShort from(final java.io.InputStream inputStream) throws java.io.IOException
        public static Bytes.UShort From(in Stream inputStream) => From((sbyte)inputStream.ReadByte(), (sbyte)inputStream.ReadByte());
        public static sbyte[] ToBytes(in Bytes.UShort x)
        {
            int num = x.IntValue;

            return new sbyte[] { (sbyte)(num & 0x00FF >> 0), (sbyte)((num & 0xFF00) >> 8) };
        }

        public static void ToBytes(in Bytes.UShort x, in sbyte[] bytes, in int offset)
        {
            int num = x.IntValue;

            bytes[offset + 1] = (sbyte)((num & 0xFF00) >> 8);
            bytes[offset + 0] = (sbyte)(num & 0x00FF >> 0);
        }

        public static void ToBytes(in Bytes.UShort x, in sbyte[] bytes)
        {
            int num = x.IntValue;

            bytes[1] = (sbyte)((num & 0xFF00) >> 8);
            bytes[0] = (sbyte)(num & 0x00FF >> 0);
        }

    }

    /// <summary>
    /// INT to and from bytes
    /// </summary>
    public static class Int
    {
        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @SuppressWarnings("fallthrough") public static int from(final byte[] bytes, final int offset, final int bytenum)
        public static int From(in sbyte[] bytes, in int offset, in int bytenum)
        {
            int number = 0;

            switch (bytenum)
            {
                case 4:
                    number |= (bytes[offset + 3] & 0xFF) << 24;
                    goto case 3;
                case 3:
                    number |= (bytes[offset + 2] & 0xFF) << 16;
                    goto case 2;
                case 2:
                    number |= (bytes[offset + 1] & 0xFF) << 8;
                    goto case 1;
                case 1:
                    number |= (bytes[offset + 0] & 0xFF) << 0;
                    break;
            }

            return number;
        }

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @SuppressWarnings("fallthrough") public static int from(final byte[] bytes)
        public static int From(in sbyte[] bytes)
        {
            int number = 0;

            switch (bytes.Length)
            {
                default:
                    goto case 4;
                case 4:
                    number |= (bytes[3] & 0xFF) << 24;
                    goto case 3;
                case 3:
                    number |= (bytes[2] & 0xFF) << 16;
                    goto case 2;
                case 2:
                    number |= (bytes[1] & 0xFF) << 8;
                    goto case 1;
                case 1:
                    number |= (bytes[0] & 0xFF) << 0;
                    break;
            }

            return number;
        }

        public static int From(in sbyte b0, in sbyte b1, in sbyte b2, in sbyte b3) => ((b3 & 0xFF) << 24) | (b2 & 0xFF) << 16 | (b1 & 0xFF) << 8 | (b0 & 0xFF) << 0;

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: public static int from(final java.io.InputStream inputStream) throws java.io.IOException
        public static int From(in Stream inputStream) => From((sbyte)inputStream.ReadByte(), (sbyte)inputStream.ReadByte(), (sbyte)inputStream.ReadByte(), (sbyte)inputStream.ReadByte());

        public static sbyte[] ToBytes(in int x) => [(sbyte)(x >> 0), (sbyte)(x >> 8), (sbyte)(x >> 16), (sbyte)(x >> 24)];

        public static void ToBytes(in int x, in sbyte[] bytes, in int offset)
        {
            bytes[offset + 3] = (sbyte)(x >> 24);
            bytes[offset + 2] = (sbyte)(x >> 16);
            bytes[offset + 1] = (sbyte)(x >> 8);
            bytes[offset + 0] = (sbyte)(x >> 0);
        }

        public static void ToBytes(in int x, in sbyte[] bytes)
        {
            bytes[3] = (sbyte)(x >> 24);
            bytes[2] = (sbyte)(x >> 16);
            bytes[1] = (sbyte)(x >> 8);
            bytes[0] = (sbyte)(x >> 0);
        }

    }

    /// <summary>
    /// UNSIGNED INT to and from bytes
    /// </summary>
    public static class UInt
    {
        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @SuppressWarnings("fallthrough") public static UInteger from(final byte[] bytes, final int offset, final int bytenum)
        public static UInteger From(in sbyte[] bytes, in int offset, in int bytenum)
        {
            int number = 0;

            switch (bytenum)
            {
                case 4:
                    number |= (bytes[offset + 3] & 0xFF) << 24;
                    goto case 3;
                case 3:
                    number |= (bytes[offset + 2] & 0xFF) << 16;
                    goto case 2;
                case 2:
                    number |= (bytes[offset + 1] & 0xFF) << 8;
                    goto case 1;
                case 1:
                    number |= (bytes[offset + 0] & 0xFF) << 0;
                    break;
            }

            return UInteger.ValueOf(number);
        }

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @SuppressWarnings("fallthrough") public static UInteger from(final byte[] bytes)
        public static UInteger From(in sbyte[] bytes)
        {
            int number = 0;

            switch (bytes.Length)
            {
                default:
                    goto case 4;
                case 4:
                    number |= (bytes[3] & 0xFF) << 24;
                    goto case 3;
                case 3:
                    number |= (bytes[2] & 0xFF) << 16;
                    goto case 2;
                case 2:
                    number |= (bytes[1] & 0xFF) << 8;
                    goto case 1;
                case 1:
                    number |= (bytes[0] & 0xFF) << 0;
                    break;
            }

            return UInteger.ValueOf(number);
        }

        public static UInteger From(in sbyte b0, in sbyte b1, in sbyte b2, in sbyte b3)
        {
            int number = (b3 & 0xFF) << 24 | (b2 & 0xFF) << 16 | (b1 & 0xFF) << 8 | (b0 & 0xFF) << 0;

            return UInteger.ValueOf(number);
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: public static UInteger from(final java.io.InputStream inputStream) throws java.io.IOException
        public static UInteger From(in Stream inputStream)
        => From((sbyte)inputStream.ReadByte(), (sbyte)inputStream.ReadByte(), (sbyte)inputStream.ReadByte(), (sbyte)inputStream.ReadByte());

        public static sbyte[] ToBytes(in UInteger x)
        {
            long num = x.LongValue;

            return [(sbyte)(num & 0x000000FFL >> 0), (sbyte)((num & 0x0000FF00L) >> 8), (sbyte)((num & 0x00FF0000L) >> 16), (sbyte)((num & 0xFF000000L) >> 24)];
        }

        public static void ToBytes(in UInteger x, in sbyte[] bytes, in int offset)
        {
            long num = x.LongValue;

            bytes[offset + 3] = (sbyte)((num & 0xFF000000L) >> 24);
            bytes[offset + 2] = (sbyte)((num & 0x00FF0000L) >> 16);
            bytes[offset + 1] = (sbyte)((num & 0x0000FF00L) >> 8);
            bytes[offset + 0] = (sbyte)(num & 0x000000FFL >> 0);
        }


        public static void ToBytes(in UInteger x, in sbyte[] bytes)
        {
            long num = x.LongValue;

            bytes[3] = (sbyte)((num & 0xFF000000L) >> 24);
            bytes[2] = (sbyte)((num & 0x00FF0000L) >> 16);
            bytes[1] = (sbyte)((num & 0x0000FF00L) >> 8);
            bytes[0] = (sbyte)(num & 0x000000FFL >> 0);
        }
    }

    public static class Long
    {
        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @SuppressWarnings("fallthrough") public static long from(final byte[] bytes, final int offset, final int bytenum)
        public static long From(in sbyte[] bytes, in int offset, in int bytenum)
        {
            long number = 0;

            switch (bytenum)
            {
                case 8:
                    number |= (long)(bytes[offset + 7] & 0xFF) << 56;
                    goto case 7;
                case 7:
                    number |= (long)(bytes[offset + 6] & 0xFF) << 48;
                    goto case 6;
                case 6:
                    number |= (long)(bytes[offset + 5] & 0xFF) << 40;
                    goto case 5;
                case 5:
                    number |= (long)(bytes[offset + 4] & 0xFF) << 32;
                    goto case 4;
                case 4:
                    number |= (long)(bytes[offset + 3] & 0xFF) << 24;
                    goto case 3;
                case 3:
                    number |= (long)(bytes[offset + 2] & 0xFF) << 16;
                    goto case 2;
                case 2:
                    number |= (long)(bytes[offset + 1] & 0xFF) << 8;
                    goto case 1;
                case 1:
                    number |= (long)(bytes[offset + 0] & 0xFF) << 0;
                    break;
            }

            return number;
        }

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @SuppressWarnings("fallthrough") public static long from(final byte[] bytes)
        public static long From(in sbyte[] bytes)
        {
            long number = 0L;

            switch (bytes.Length)
            {
                default:
                    goto case 8;
                case 8:
                    number |= (long)(bytes[7] & 0xFF) << 56;
                    goto case 7;
                case 7:
                    number |= (long)(bytes[6] & 0xFF) << 48;
                    goto case 6;
                case 6:
                    number |= (long)(bytes[5] & 0xFF) << 40;
                    goto case 5;
                case 5:
                    number |= (long)(bytes[4] & 0xFF) << 32;
                    goto case 4;
                case 4:
                    number |= (long)(bytes[3] & 0xFF) << 24;
                    goto case 3;
                case 3:
                    number |= (long)(bytes[2] & 0xFF) << 16;
                    goto case 2;
                case 2:
                    number |= (long)(bytes[1] & 0xFF) << 8;
                    goto case 1;
                case 1:
                    number |= (long)(bytes[0] & 0xFF) << 0;
                    break;
            }

            return number;
        }

        public static long From(in sbyte b0, in sbyte b1, in sbyte b2, in sbyte b3, in sbyte b4, in sbyte b5, in sbyte b6, in sbyte b7)
        => (long)(b7 & 0xFF) << 56 | (long)(b6 & 0xFF) << 48 | (long)(b5 & 0xFF) << 40 | (long)(b4 & 0xFF) << 32 | (long)(b3 & 0xFF) << 24 | (long)(b2 & 0xFF) << 16 | (long)(b1 & 0xFF) << 8 | (long)(b0 & 0xFF) << 0;

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: public static long from(final java.io.InputStream inputStream) throws java.io.IOException
        public static long From(in Stream inputStream)
        => From((sbyte)inputStream.ReadByte(), (sbyte)inputStream.ReadByte(), (sbyte)inputStream.ReadByte(), (sbyte)inputStream.ReadByte(), (sbyte)inputStream.ReadByte(), (sbyte)inputStream.ReadByte(), (sbyte)inputStream.ReadByte(), (sbyte)inputStream.ReadByte());

        public static sbyte[] ToBytes(in long x)
        => new sbyte[] { (sbyte)(x >> 0), (sbyte)(x >> 8), (sbyte)(x >> 16), (sbyte)(x >> 24), (sbyte)(x >> 32), (sbyte)(x >> 40), (sbyte)(x >> 48), (sbyte)(x >> 56) };

        public static void ToBytes(in long x, in sbyte[] bytes, in int offset)
        {
            bytes[offset + 7] = (sbyte)(x >> 56);
            bytes[offset + 6] = (sbyte)(x >> 48);
            bytes[offset + 5] = (sbyte)(x >> 40);
            bytes[offset + 4] = (sbyte)(x >> 32);
            bytes[offset + 3] = (sbyte)(x >> 24);
            bytes[offset + 2] = (sbyte)(x >> 16);
            bytes[offset + 1] = (sbyte)(x >> 8);
            bytes[offset + 0] = (sbyte)(x >> 0);
        }

        public static void ToBytes(in long x, in sbyte[] bytes)
        {
            bytes[7] = (sbyte)(x >> 56);
            bytes[6] = (sbyte)(x >> 48);
            bytes[5] = (sbyte)(x >> 40);
            bytes[4] = (sbyte)(x >> 32);
            bytes[3] = (sbyte)(x >> 24);
            bytes[2] = (sbyte)(x >> 16);
            bytes[1] = (sbyte)(x >> 8);
            bytes[0] = (sbyte)(x >> 0);
        }

    }

    /// <summary>
    /// UNSIGNED LONG to and from bytes
    /// </summary>
    public static class ULong
    {
        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @SuppressWarnings("fallthrough") public static ULong from(final byte[] bytes, final int offset, final int bytenum)
        public static Bytes.ULong From(in sbyte[] bytes, in int offset, in int bytenum)
        {
            long number = 0;

            switch (bytenum)
            {
                case 8:
                    number |= (long)(bytes[offset + 7] & 0xFF) << 56;
                    goto case 7;
                case 7:
                    number |= (long)(bytes[offset + 6] & 0xFF) << 48;
                    goto case 6;
                case 6:
                    number |= (long)(bytes[offset + 5] & 0xFF) << 40;
                    goto case 5;
                case 5:
                    number |= (long)(bytes[offset + 4] & 0xFF) << 32;
                    goto case 4;
                case 4:
                    number |= (long)(bytes[offset + 3] & 0xFF) << 24;
                    goto case 3;
                case 3:
                    number |= (long)(bytes[offset + 2] & 0xFF) << 16;
                    goto case 2;
                case 2:
                    number |= (long)(bytes[offset + 1] & 0xFF) << 8;
                    goto case 1;
                case 1:
                    number |= (long)(bytes[offset + 0] & 0xFF) << 0;
                    break;
            }

            return Bytes.ULong.ValueOf(number);
        }

        public static Bytes.ULong From(in sbyte[] bytes)
        {
            BigInteger @ulong = new BigInteger(Array.ConvertAll(bytes, x => unchecked((byte)(x))));
            return Bytes.ULong.ValueOf(@ulong);
        }

        public static Bytes.ULong From(in sbyte b0, in sbyte b1, in sbyte b2, in sbyte b3, in sbyte b4, in sbyte b5, in sbyte b6, in sbyte b7)
        {
            sbyte[] bytes = [b7, b6, b5, b4, b3, b2, b1, b0];
            BigInteger @ulong = new BigInteger(Array.ConvertAll(bytes, x => unchecked((byte)(x))));
            return Bytes.ULong.ValueOf(@ulong);
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: public static ULong from(final java.io.InputStream inputStream) throws java.io.IOException
        public static Bytes.ULong From(in Stream inputStream)
        => From((sbyte)inputStream.ReadByte(), (sbyte)inputStream.ReadByte(), (sbyte)inputStream.ReadByte(), (sbyte)inputStream.ReadByte(), (sbyte)inputStream.ReadByte(), (sbyte)inputStream.ReadByte(), (sbyte)inputStream.ReadByte(), (sbyte)inputStream.ReadByte());

        public static sbyte[] ToBytes(in Bytes.ULong x)
        {
            sbyte[] bytes = new sbyte[8];
            int offset = 0;

            sbyte[] temp_byte = Array.ConvertAll(x.ToBigInteger().ToByteArray(), b => unchecked((sbyte)(b)));
            int array_count = temp_byte.Length - 1;

            for (int i = 7; i >= 0; i--)
            {
                if (array_count >= 0)
                {
                    bytes[offset] = temp_byte[array_count];
                }
                else
                {
                    bytes[offset] = (sbyte)0x0;
                }

                offset++;
                array_count--;
            }

            return bytes;
        }

        public static void ToBytes(in Bytes.ULong x, in sbyte[] bytes, in int offset)
        {
            //JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
            //ORIGINAL LINE: final byte[] bytes1 = toBytes(x);
            sbyte[] bytes1 = ToBytes(x);
            int length = bytes.Length;
            int pos = 8;

            while (length > 0)
            {
                bytes[pos--] = bytes1[offset + length--];
            }
        }

        public static void ToBytes(in Bytes.ULong x, in sbyte[] bytes)
        {
            //JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
            //ORIGINAL LINE: final byte[] bytes1 = toBytes(x);
            sbyte[] bytes1 = ToBytes(x);
            int length = bytes.Length;
            int pos = 8;

            while (length > 0)
            {
                bytes[pos--] = bytes1[length--];
            }
        }

    }
}