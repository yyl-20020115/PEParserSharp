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
namespace PEParserSharp.Headers;

using ByteArray = PEParserSharp.ByteArray;
using CoffCharacteristics = PEParserSharp.Types.CoffCharacteristics;
using DWORD = PEParserSharp.Types.DWORD;
using MachineType = PEParserSharp.Types.MachineType;
using TimeDate = PEParserSharp.Types.TimeDate;
using WORD = PEParserSharp.Types.WORD;

public class COFFFileHeader : Header
{

	// see: http://msdn.microsoft.com/en-us/library/ms809762.aspx

	public const int HEADER_SIZE = 20;

	/// <summary>
	/// The CPU that this file is intended for </summary>
	public readonly MachineType Machine;

	/// <summary>
	/// The number of sections in the file. </summary>
	public readonly WORD NumberOfSections;

	/// <summary>
	/// The time that the linker (or compiler for an OBJ file) produced this file. This field holds the number of seconds since December
	/// 31st, 1969, at 4:00 P.M. (PST)
	/// </summary>
	public readonly TimeDate TimeDateStamp;

	/// <summary>
	/// The file offset of the COFF symbol table. This field is only used in OBJ files and PE files with COFF debug information. PE files
	/// support multiple debug formats, so debuggers should refer to the IMAGE_DIRECTORY_ENTRY_DEBUG entry in the data directory (defined
	/// later).
	/// </summary>
	public readonly DWORD PointerToSymbolTable;

	/// <summary>
	/// The number of symbols in the COFF symbol table. See above. </summary>
	public readonly DWORD NumberOfSymbols;

	/// <summary>
	/// The size of an optional header that can follow this structure. In OBJs, the field is 0. In executables, it is the size of the
	/// IMAGE_OPTIONAL_HEADER structure that follows this structure.
	/// </summary>
	public readonly WORD SizeOfOptionalHeader;

	/// <summary>
	/// Flags with information about the file. </summary>
	public readonly CoffCharacteristics Characteristics;

	public COFFFileHeader(ByteArray bytes)
	{
		this.Machine = H(new MachineType(bytes.ReadUShort(2), "machine type"));
		this.NumberOfSections = H(new WORD(bytes.ReadUShort(2), "number of sections"));
		this.TimeDateStamp = H(new TimeDate(bytes.ReadUInt(4), "time date stamp"));
		this.PointerToSymbolTable = H(new DWORD(bytes.ReadUInt(4), "pointer to symbol table"));
		this.NumberOfSymbols = H(new DWORD(bytes.ReadUInt(4), "number of symbols"));
		this.SizeOfOptionalHeader = H(new WORD(bytes.ReadUShort(2), "size of optional header"));
		this.Characteristics = H(new CoffCharacteristics(bytes.ReadUShort(2), "characteristics"));
	}
}