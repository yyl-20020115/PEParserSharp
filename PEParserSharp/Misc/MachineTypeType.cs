﻿using System.Collections.Generic;

/*
 * Copyright 2012 dorkbox, llc
 */
namespace PEParserSharp.Misc;

using UShort = PEParserSharp.Bytes.UShort;

public sealed class MachineTypeType
{

	public static readonly MachineTypeType NONE = new ("NONE", InnerEnum.NONE, "", "No specified machine type");
	public static readonly MachineTypeType IMAGE_FILE_MACHINE_UNKNOWN = new ("IMAGE_FILE_MACHINE_UNKNOWN", InnerEnum.IMAGE_FILE_MACHINE_UNKNOWN, "0", "the contents of this field are assumed to be applicable for any machine type");
	public static readonly MachineTypeType IMAGE_FILE_MACHINE_AM33 = new ("IMAGE_FILE_MACHINE_AM33", InnerEnum.IMAGE_FILE_MACHINE_AM33, "1d3", "Matsushita AM33");
	public static readonly MachineTypeType IMAGE_FILE_MACHINE_AMD64 = new ("IMAGE_FILE_MACHINE_AMD64", InnerEnum.IMAGE_FILE_MACHINE_AMD64, "8664", "x64");
	public static readonly MachineTypeType IMAGE_FILE_MACHINE_ARM = new ("IMAGE_FILE_MACHINE_ARM", InnerEnum.IMAGE_FILE_MACHINE_ARM, "1c0", "ARM little endian");
	public static readonly MachineTypeType IMAGE_FILE_MACHINE_ARMV7 = new ("IMAGE_FILE_MACHINE_ARMV7", InnerEnum.IMAGE_FILE_MACHINE_ARMV7, "1c4", "ARMv7 (or higher) Thumb mode only");
	public static readonly MachineTypeType IMAGE_FILE_MACHINE_EBC = new ("IMAGE_FILE_MACHINE_EBC", InnerEnum.IMAGE_FILE_MACHINE_EBC, "ebc", "EFI byte code");
	public static readonly MachineTypeType IMAGE_FILE_MACHINE_I386 = new ("IMAGE_FILE_MACHINE_I386", InnerEnum.IMAGE_FILE_MACHINE_I386, "14c", "Intel 386 or later processors and compatible processors");
	public static readonly MachineTypeType IMAGE_FILE_MACHINE_IA64 = new ("IMAGE_FILE_MACHINE_IA64", InnerEnum.IMAGE_FILE_MACHINE_IA64, "200", "Intel Itanium processor family");
	public static readonly MachineTypeType IMAGE_FILE_MACHINE_M32R = new ("IMAGE_FILE_MACHINE_M32R", InnerEnum.IMAGE_FILE_MACHINE_M32R, "9041", "Mitsubishi M32R little endian");
	public static readonly MachineTypeType IMAGE_FILE_MACHINE_MIPS16 = new ("IMAGE_FILE_MACHINE_MIPS16", InnerEnum.IMAGE_FILE_MACHINE_MIPS16, "266", "MIPS16");
	public static readonly MachineTypeType IMAGE_FILE_MACHINE_MIPSFPU = new ("IMAGE_FILE_MACHINE_MIPSFPU", InnerEnum.IMAGE_FILE_MACHINE_MIPSFPU, "366", "MIPS with FPU");
	public static readonly MachineTypeType IMAGE_FILE_MACHINE_MIPSFPU16 = new ("IMAGE_FILE_MACHINE_MIPSFPU16", InnerEnum.IMAGE_FILE_MACHINE_MIPSFPU16, "466", "MIPS16 with FPU");
	public static readonly MachineTypeType IMAGE_FILE_MACHINE_POWERPC = new ("IMAGE_FILE_MACHINE_POWERPC", InnerEnum.IMAGE_FILE_MACHINE_POWERPC, "1f0", "Power PC little endian");
	public static readonly MachineTypeType IMAGE_FILE_MACHINE_POWERPCFP = new ("IMAGE_FILE_MACHINE_POWERPCFP", InnerEnum.IMAGE_FILE_MACHINE_POWERPCFP, "1f1", "Power PC with floating point support");
	public static readonly MachineTypeType IMAGE_FILE_MACHINE_R4000 = new ("IMAGE_FILE_MACHINE_R4000", InnerEnum.IMAGE_FILE_MACHINE_R4000, "166", "MIPS little endian");
	public static readonly MachineTypeType IMAGE_FILE_MACHINE_SH3 = new ("IMAGE_FILE_MACHINE_SH3", InnerEnum.IMAGE_FILE_MACHINE_SH3, "1a2", "Hitachi SH3");
	public static readonly MachineTypeType IMAGE_FILE_MACHINE_SH3DSP = new ("IMAGE_FILE_MACHINE_SH3DSP", InnerEnum.IMAGE_FILE_MACHINE_SH3DSP, "1a3", "Hitachi SH3 DSP");
	public static readonly MachineTypeType IMAGE_FILE_MACHINE_SH4 = new ("IMAGE_FILE_MACHINE_SH4", InnerEnum.IMAGE_FILE_MACHINE_SH4, "1a6", "Hitachi SH4");
	public static readonly MachineTypeType IMAGE_FILE_MACHINE_SH5 = new ("IMAGE_FILE_MACHINE_SH5", InnerEnum.IMAGE_FILE_MACHINE_SH5, "1a8", "Hitachi SH5");
	public static readonly MachineTypeType IMAGE_FILE_MACHINE_THUMB = new ("IMAGE_FILE_MACHINE_THUMB", InnerEnum.IMAGE_FILE_MACHINE_THUMB, "1c2", "ARM or Thumb (\"interworking\")");
	public static readonly MachineTypeType IMAGE_FILE_MACHINE_WCEMIPSV2 = new ("IMAGE_FILE_MACHINE_WCEMIPSV2", InnerEnum.IMAGE_FILE_MACHINE_WCEMIPSV2, "169", "MIPS little-endian WCE v2");

    private static readonly List<MachineTypeType> valueList = [];

	static MachineTypeType()
	{
		valueList.Add(NONE);
		valueList.Add(IMAGE_FILE_MACHINE_UNKNOWN);
		valueList.Add(IMAGE_FILE_MACHINE_AM33);
		valueList.Add(IMAGE_FILE_MACHINE_AMD64);
		valueList.Add(IMAGE_FILE_MACHINE_ARM);
		valueList.Add(IMAGE_FILE_MACHINE_ARMV7);
		valueList.Add(IMAGE_FILE_MACHINE_EBC);
		valueList.Add(IMAGE_FILE_MACHINE_I386);
		valueList.Add(IMAGE_FILE_MACHINE_IA64);
		valueList.Add(IMAGE_FILE_MACHINE_M32R);
		valueList.Add(IMAGE_FILE_MACHINE_MIPS16);
		valueList.Add(IMAGE_FILE_MACHINE_MIPSFPU);
		valueList.Add(IMAGE_FILE_MACHINE_MIPSFPU16);
		valueList.Add(IMAGE_FILE_MACHINE_POWERPC);
		valueList.Add(IMAGE_FILE_MACHINE_POWERPCFP);
		valueList.Add(IMAGE_FILE_MACHINE_R4000);
		valueList.Add(IMAGE_FILE_MACHINE_SH3);
		valueList.Add(IMAGE_FILE_MACHINE_SH3DSP);
		valueList.Add(IMAGE_FILE_MACHINE_SH4);
		valueList.Add(IMAGE_FILE_MACHINE_SH5);
		valueList.Add(IMAGE_FILE_MACHINE_THUMB);
		valueList.Add(IMAGE_FILE_MACHINE_WCEMIPSV2);
	}

	public enum InnerEnum : int
	{
		NONE,
		IMAGE_FILE_MACHINE_UNKNOWN,
		IMAGE_FILE_MACHINE_AM33,
		IMAGE_FILE_MACHINE_AMD64,
		IMAGE_FILE_MACHINE_ARM,
		IMAGE_FILE_MACHINE_ARMV7,
		IMAGE_FILE_MACHINE_EBC,
		IMAGE_FILE_MACHINE_I386,
		IMAGE_FILE_MACHINE_IA64,
		IMAGE_FILE_MACHINE_M32R,
		IMAGE_FILE_MACHINE_MIPS16,
		IMAGE_FILE_MACHINE_MIPSFPU,
		IMAGE_FILE_MACHINE_MIPSFPU16,
		IMAGE_FILE_MACHINE_POWERPC,
		IMAGE_FILE_MACHINE_POWERPCFP,
		IMAGE_FILE_MACHINE_R4000,
		IMAGE_FILE_MACHINE_SH3,
		IMAGE_FILE_MACHINE_SH3DSP,
		IMAGE_FILE_MACHINE_SH4,
		IMAGE_FILE_MACHINE_SH5,
		IMAGE_FILE_MACHINE_THUMB,
		IMAGE_FILE_MACHINE_WCEMIPSV2
	}

	public readonly InnerEnum innerEnumValue;
	private readonly string nameValue;
	private readonly int ordinalValue;
	private static int nextOrdinal = 0;

	private readonly string hexValue;
	private readonly string description;

	internal MachineTypeType(string name, InnerEnum innerEnum, string hexValue, string description)
	{
		this.hexValue = hexValue;
		this.description = description;

		nameValue = name;
		ordinalValue = nextOrdinal++;
		innerEnumValue = innerEnum;
	}

	public static MachineTypeType Get(PEParserSharp.Bytes.UShort value)
	{
		string key = value.ToHexString();

		foreach (MachineTypeType mt in values())
		{
			if (key.Equals(mt.hexValue))
			{
				return mt;
			}
		}

		return NONE;
	}

    public string Description => this.description;

    public static MachineTypeType[] values() => valueList.ToArray();

    public int Ordinal => ordinalValue;

    public override string ToString() => nameValue;

    public static MachineTypeType ValueOf(string name)
	{
		foreach (MachineTypeType enumInstance in MachineTypeType.valueList)
		{
			if (enumInstance.nameValue == name)
			{
				return enumInstance;
			}
		}
		throw new System.ArgumentException(name);
	}
}