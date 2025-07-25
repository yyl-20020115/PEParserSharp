using System;
using System.IO;

/*
 * Copyright 2012 dorkbox, llc
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
namespace PEParserSharp;

using LittleEndian = Bytes.LittleEndian;
using UByte = Bytes.UByte;
using UInteger = Bytes.UInteger;
using ULong = Bytes.ULong;
using UShort = Bytes.UShort;


public class ByteArray : MemoryStream
{
	public ByteArray(byte[] bytes) : base(bytes, 0, bytes.Length, false, true)
	{
		this.buffer = Array.ConvertAll(this.GetBuffer(), x => unchecked((sbyte)(x)));
	}

	public ByteArray(sbyte[] bytes) : base(Array.ConvertAll(bytes, x => unchecked((byte)(x))), 0, bytes.Length, false, true)
	{
		this.buffer = bytes;
	}

    public virtual string ReadAsciiString(int length) =>
        // pos is incremented by the copybytes method
        (StringHelper.NewString(CopyBytes(length), System.Text.Encoding.ASCII)).Trim();

    private int Pos
	{
		get => (int)this.Position;
		set => base.Position = value;
	}

    private sbyte[] buffer;

	public virtual ULong ReadULong(int length)
	{
		var result = LittleEndian.ULong.From(this.buffer, this.Pos, length);
		this.Pos += length;
		return result;
	}

	public virtual UInteger ReadUInt(int length)
	{
		UInteger result = LittleEndian.UInt.From(this.buffer, this.Pos, length);
		this.Pos += length;
		return result;
	}

	public virtual UShort ReadUShort(int length)
	{
		var result = LittleEndian.UShort.From(this.buffer, this.Pos, length);
		this.Pos += length;
		return result;
	}

	public virtual UByte ReadUByte()
	{
		var b = UByte.ValueOf(this.buffer[this.Pos]);
		this.Pos++;
		return b;
	}

    public virtual sbyte ReadRaw(int offset) => this.buffer[this.Pos + offset];

    public virtual sbyte[] CopyBytes(int length)
	{
		var data = new byte[length];
		base.Read(data, 0, length);
		return Array.ConvertAll(data, x => unchecked((sbyte)(x)));
	}

	private int marker = 0;

    public virtual void Mark() => marker = this.Pos;

    public virtual void Seek(int position) => this.Pos = position;

    public new virtual int Position => this.Pos;

    public virtual int Marked => this.marker;

    public void Reset() => this.Pos = marker;

    public void Skip(int v) => this.Pos += v;
}