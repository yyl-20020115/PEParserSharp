using System.Text;

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
namespace PEParserSharp.Types;

using UInteger = PEParserSharp.Bytes.UInteger;
using ByteArray = PEParserSharp.ByteArray;
using Header = PEParserSharp.Headers.Header;
using SectionTableEntry = PEParserSharp.Headers.SectionTableEntry;
using DirEntry = PEParserSharp.Misc.DirEntry;

/// <summary>
/// 8 bytes each </summary>
public class ImageDataDir(ByteArray bytes, DirEntry entry) : ByteDefinition<UInteger>(entry.Description)
{

	private readonly DirEntry entry = entry;

	private TInteger virtualAddress = new TInteger(bytes.ReadUInt(4), "Virtual Address");
	private TInteger size = new TInteger(bytes.ReadUInt(4), "Size");

	private SectionTableEntry section;
	public Header data;

    public virtual DirEntry Type => this.entry;

    public override UInteger Get => this.virtualAddress.Get;

    public virtual UInteger Size => this.size.Get;

    public override void Format(StringBuilder b) => b.Append(DescriptiveName).Append(": ").Append(System.Environment.NewLine).Append("\t").Append("address: ").Append(this.virtualAddress).Append(" (0x").Append(this.virtualAddress.Get.ToHexString()).Append(")").Append(System.Environment.NewLine).Append("\t").Append("size: ").Append(this.size.Get).Append(" (0x").Append(this.size.Get.ToHexString()).Append(")").Append(System.Environment.NewLine);

    public virtual SectionTableEntry Section
    {
        set => this.section = value;
        get => this.section;
    }

}