﻿using System;
using System.Collections.Generic;

/*
 * Copyright 2012 dorkbox, llc
 */
namespace PEParserSharp.Headers.Flags;


using UInteger = Bytes.UInteger;

public sealed class SectionCharacteristicsType
{

	public static readonly SectionCharacteristicsType IMAGE_SCN_MEM_WRITE = new SectionCharacteristicsType("IMAGE_SCN_MEM_WRITE", InnerEnum.IMAGE_SCN_MEM_WRITE, "80000000", "The section can be written to.");

	private static readonly List<SectionCharacteristicsType> valueList = new List<SectionCharacteristicsType>();

	static SectionCharacteristicsType()
	{
		valueList.Add(IMAGE_SCN_MEM_WRITE);
	}

	public enum InnerEnum
	{
		IMAGE_SCN_MEM_WRITE
	}

	public readonly InnerEnum innerEnumValue;
	private readonly string nameValue;
	private readonly int ordinalValue;
	private static int nextOrdinal = 0;


	private readonly string hexValue;
	private readonly string description;

	internal SectionCharacteristicsType(string name, InnerEnum innerEnum, string hexValue, string description)
	{
		this.hexValue = hexValue;
		this.description = description;

		nameValue = name;
		ordinalValue = nextOrdinal++;
		innerEnumValue = innerEnum;
	}

	public static SectionCharacteristicsType[] Get(PEParserSharp.Bytes.UInteger key)
	{
		IList<SectionCharacteristicsType> chars = new List<SectionCharacteristicsType>(0);
		long keyAsLong = key.LongValue;

		foreach (SectionCharacteristicsType c in Values())
		{
			long mask = Convert.ToInt64(c.hexValue, 16);
			if ((keyAsLong & mask) != 0)
			{
				chars.Add(c);
			}
		}

		return ((List<SectionCharacteristicsType>)chars).ToArray();
	}

    public string Description => this.description;


    public static SectionCharacteristicsType[] Values()
	{
		return [.. valueList];
	}

    public int Ordinal => ordinalValue;

    public override string ToString() => nameValue;

    public static SectionCharacteristicsType ValueOf(string name)
	{
		foreach (SectionCharacteristicsType enumInstance in SectionCharacteristicsType.valueList)
		{
			if (enumInstance.nameValue == name)
			{
				return enumInstance;
			}
		}
		throw new System.ArgumentException(name);
	}
}