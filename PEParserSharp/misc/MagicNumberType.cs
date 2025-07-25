using System.Collections.Generic;

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
namespace PEParserSharp.Misc;

using UShort = PEParserSharp.Bytes.UShort;

public sealed class MagicNumberType
{
	public static readonly MagicNumberType NONE = new ("NONE", InnerEnum.NONE, "", "ERROR, unable to recognize magic number");
	public static readonly MagicNumberType PE32 = new ("PE32", InnerEnum.PE32, "10B", "PE32, normal executable file");
	public static readonly MagicNumberType PE32_PLUS = new ("PE32_PLUS", InnerEnum.PE32_PLUS, "20B", "PE32+ executable");
	public static readonly MagicNumberType ROM = new ("ROM", InnerEnum.ROM, "107", "ROM image");

	private static readonly List<MagicNumberType> valueList = new List<MagicNumberType>();

	static MagicNumberType()
	{
		valueList.Add(NONE);
		valueList.Add(PE32);
		valueList.Add(PE32_PLUS);
		valueList.Add(ROM);
	}

	public enum InnerEnum : int
	{
		NONE,
		PE32,
		PE32_PLUS,
		ROM
	}

	public readonly InnerEnum innerEnumValue;
	private readonly string nameValue;
	private readonly int ordinalValue;
	private static int nextOrdinal = 0;

	private readonly string hexValue;
	private readonly string description;

	internal MagicNumberType(string name, InnerEnum innerEnum, string hexValue, string description)
	{
		this.hexValue = hexValue.ToLower();
		this.description = description;

		nameValue = name;
		ordinalValue = nextOrdinal++;
		innerEnumValue = innerEnum;
	}

	public static MagicNumberType Get(PEParserSharp.Bytes.UShort value)
	{
		string key = value.ToHexString();

		foreach (MagicNumberType mt in Values)
		{
			if (key.Equals(mt.hexValue))
			{
				return mt;
			}
		}

		return NONE;
	}

    public string Description => this.description;

    public static MagicNumberType[] Values => [.. valueList];

    public int Ordinal => ordinalValue;

    public override string ToString() => nameValue;

    public static MagicNumberType ValueOf(string name)
	{
		foreach (MagicNumberType enumInstance in MagicNumberType.valueList)
		{
			if (enumInstance.nameValue == name)
			{
				return enumInstance;
			}
		}
		throw new System.ArgumentException(name);
	}
}