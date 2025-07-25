using System;

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
namespace PEParserSharp.Headers.Resources;

using ByteArray = PEParserSharp.ByteArray;
using Header = PEParserSharp.Headers.Header;
using SectionTableEntry = PEParserSharp.Headers.SectionTableEntry;
using DWORD = PEParserSharp.Types.DWORD;

/// <param name="section"> - necessary to know this section for when computing the location of the resource data! </param>
public class ResourceDataEntry(ByteArray bytes, SectionTableEntry section) : Header
{

	public readonly DWORD OFFSET_TO_DATA = new DWORD(bytes.ReadUInt(4), "offsetToData"); // The address of a unit of resource data in the Resource Data area.
	public readonly DWORD SIZE = new DWORD(bytes.ReadUInt(4), "Size");
	public readonly DWORD CODE_PAGE = new DWORD(bytes.ReadUInt(4), "CodePage");
	public readonly DWORD RESERVED = new DWORD(bytes.ReadUInt(4), "Reserved");

	private readonly SectionTableEntry section = section;

    public virtual sbyte[] GetData(ByteArray bytes)
	{
		// this is where to get the data from the ABSOLUTE position in the file!
		long dataOffset = this.section.POINTER_TO_RAW_DATA.Get.LongValue + this.OFFSET_TO_DATA.Get.LongValue - this.section.VIRTUAL_ADDRESS.Get.LongValue;

		if (dataOffset > int.MaxValue)
		{
			throw new Exception("Unable to set offset to more than 2gb!");
		}

		//String asHex = Integer.toHexString(dataOffset);
		int saved = bytes.Position;
		bytes.Seek((int) dataOffset);

		long bytesToCopyLong = this.SIZE.Get.LongValue;
		if (bytesToCopyLong > int.MaxValue)
		{
			throw new Exception("Unable to copy more than 2gb of bytes!");
		}

		var copyBytes = bytes.CopyBytes((int)bytesToCopyLong);
		bytes.Seek(saved);
		return copyBytes;
	}
}