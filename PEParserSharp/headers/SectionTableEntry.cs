﻿/*
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
namespace PEParserSharp.Headers;

using AsciiString = PEParserSharp.Types.AsciiString;
using HeaderDefinition = PEParserSharp.Types.HeaderDefinition;
using ByteArray = PEParserSharp.ByteArray;
using DWORD = PEParserSharp.Types.DWORD;
using SectionCharacteristics = PEParserSharp.Types.SectionCharacteristics;
using WORD = PEParserSharp.Types.WORD;

public class SectionTableEntry : Header
{

	// more info here: http://msdn.microsoft.com/en-us/library/ms809762.aspx

	public const int ENTRY_SIZE = 40;

	public readonly AsciiString NAME;
	public readonly DWORD VIRTUAL_SIZE;
	public readonly DWORD VIRTUAL_ADDRESS;
	public readonly DWORD SIZE_OF_RAW_DATA;
	public readonly DWORD POINTER_TO_RAW_DATA;
	public readonly DWORD POINTER_TO_RELOCATIONS;
	public readonly DWORD POINTER_TO_LINE_NUMBERS;
	public readonly WORD NUMBER_OF_RELOCATIONS;
	public readonly WORD NUMBER_OF_LINE_NUMBERS;
	public readonly SectionCharacteristics CHARACTERISTICS;

	public SectionTableEntry(ByteArray bytes, int entryNumber, int offset, int size)
	{

		H(new HeaderDefinition("Section table entry: " + entryNumber));

		this.NAME = H(new AsciiString(bytes, 8, "name"));
		this.VIRTUAL_SIZE = H(new DWORD(bytes.ReadUInt(4), "virtual size"));
		this.VIRTUAL_ADDRESS = H(new DWORD(bytes.ReadUInt(4), "virtual address"));

		this.SIZE_OF_RAW_DATA = H(new DWORD(bytes.ReadUInt(4), "size of raw data"));
		this.POINTER_TO_RAW_DATA = H(new DWORD(bytes.ReadUInt(4), "pointer to raw data"));
		this.POINTER_TO_RELOCATIONS = H(new DWORD(bytes.ReadUInt(4), "pointer to relocations"));
		this.POINTER_TO_LINE_NUMBERS = H(new DWORD(bytes.ReadUInt(4), "pointer to line numbers"));

		this.NUMBER_OF_RELOCATIONS = H(new WORD(bytes.ReadUShort(2), "number of relocations"));
		this.NUMBER_OF_LINE_NUMBERS = H(new WORD(bytes.ReadUShort(2), "number of line numbers"));
		this.CHARACTERISTICS = H(new SectionCharacteristics(bytes.ReadUInt(4), "characteristics"));
	}
}