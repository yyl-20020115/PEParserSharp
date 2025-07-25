//====================================================================================================
//The Free Edition of Java to C# Converter limits conversion output to 100 lines per file.

//To purchase the Premium Edition, visit our website:
//https://www.tangiblesoftwaresolutions.com/order/order-java-to-csharp.html
//====================================================================================================

using System.Collections.Generic;

/*
 * Copyright 2012 dorkbox, llc
 */
namespace PEParserSharp.Headers;


using DirEntry = PEParserSharp.Misc.DirEntry;
using ByteArray = PEParserSharp.ByteArray;
using MagicNumberType = PEParserSharp.Misc.MagicNumberType;
using PEParserSharp.Types;
using DWORD = PEParserSharp.Types.DWORD;
using HeaderDefinition = PEParserSharp.Types.HeaderDefinition;
using ImageBase = PEParserSharp.Types.ImageBase;
using ImageBase_Wide = PEParserSharp.Types.ImageBase_Wide;
using ImageDataDir = PEParserSharp.Types.ImageDataDir;
using ImageDataDirExtra = PEParserSharp.Types.ImageDataDirExtra;
using MagicNumber = PEParserSharp.Types.MagicNumber;
using DWORD_WIDE = PEParserSharp.Types.DWORD_WIDE;
using RVA = PEParserSharp.Types.RVA;
using DllCharacteristics = PEParserSharp.Types.DllCharacteristics;
using Subsystem = PEParserSharp.Types.Subsystem;
using WORD = PEParserSharp.Types.WORD;
using UInteger = PEParserSharp.Bytes.UInteger;
using ULong = PEParserSharp.Bytes.ULong;

public class OptionalHeader : Header
{

	// see: http://msdn.microsoft.com/en-us/library/ms809762.aspx

	public IList<ImageDataDir> tables = [];

	//
	// Standard fields.
	//
	public readonly MagicNumber MAGIC_NUMBER;
	public readonly WORD MAJOR_LINKER_VERSION;
	public readonly WORD MINOR_LINKER_VERSION;
	public readonly DWORD SIZE_OF_CODE;
	public readonly DWORD SIZE_OF_INIT_DATA;
	public readonly DWORD SIZE_OF_UNINIT_DATA;
	public readonly DWORD ADDR_OF_ENTRY_POINT;
	public readonly DWORD BASE_OF_CODE;
	public readonly DWORD BASE_OF_DATA;

	private bool IS_32_BIT;

	//
	// NT additional fields.
	//
	public readonly ByteDefinition IMAGE_BASE;
	public readonly DWORD SECTION_ALIGNMENT;
	public readonly DWORD FILE_ALIGNMENT;
	public readonly WORD MAJOR_OS_VERSION;
	public readonly WORD MINOR_OS_VERSION;
	public readonly WORD MAJOR_IMAGE_VERSION;
	public readonly WORD MINOR_IMAGE_VERSION;
	public readonly WORD MAJOR_SUBSYSTEM_VERSION;
	public readonly WORD MINOR_SUBSYSTEM_VERSION;
	public readonly DWORD WIN32_VERSION_VALUE;
	public readonly DWORD SIZE_OF_IMAGE;
	public readonly DWORD SIZE_OF_HEADERS;
	public readonly DWORD CHECKSUM;
	public readonly Subsystem SUBSYSTEM;
	public readonly DllCharacteristics DLL_CHARACTERISTICS;
	public readonly ByteDefinition SIZE_OF_STACK_RESERVE;
	public readonly ByteDefinition SIZE_OF_STACK_COMMIT;
	public readonly ByteDefinition SIZE_OF_HEAP_RESERVE;
	public readonly ByteDefinition SIZE_OF_HEAP_COMMIT;
	public readonly DWORD LOADER_FLAGS;
	public readonly RVA NUMBER_OF_RVA_AND_SIZES;


	public readonly ImageDataDir EXPORT_TABLE;
	public readonly ImageDataDir IMPORT_TABLE;
	public readonly ImageDataDir RESOURCE_TABLE;
	public readonly ImageDataDir EXCEPTION_TABLE;
	public readonly ImageDataDir CERTIFICATE_TABLE;
	public readonly ImageDataDir BASE_RELOCATION_TABLE;

	public readonly ImageDataDir DEBUG;
	public readonly ImageDataDir COPYRIGHT;
	public readonly ImageDataDir GLOBAL_PTR;
	public readonly ImageDataDir TLS_TABLE;
	public readonly ImageDataDir LOAD_CONFIG_TABLE;

	public readonly ImageDataDirExtra BOUND_IMPORT;
	public readonly ImageDataDirExtra IAT;
	public readonly ImageDataDirExtra DELAY_IMPORT_DESCRIPTOR;
	public readonly ImageDataDirExtra CLR_RUNTIME_HEADER;

	public OptionalHeader(ByteArray bytes)
	{
		// the header length is variable.

		//
		// Standard fields.
		//
		H(new HeaderDefinition("Standard fields"));
		bytes.Mark();

		this.MAGIC_NUMBER = H(new MagicNumber(bytes.ReadUShort(2), "magic number"));
		this.MAJOR_LINKER_VERSION = H(new WORD(bytes.ReadUShort(1), "major linker version"));
		this.MINOR_LINKER_VERSION = H(new WORD(bytes.ReadUShort(1), "minor linker version"));
		this.SIZE_OF_CODE = H(new DWORD(bytes.ReadUInt(4), "size of code"));
		this.SIZE_OF_INIT_DATA = H(new DWORD(bytes.ReadUInt(4), "size of initialized data"));
		this.SIZE_OF_UNINIT_DATA = H(new DWORD(bytes.ReadUInt(4), "size of unitialized data"));
		this.ADDR_OF_ENTRY_POINT = H(new DWORD(bytes.ReadUInt(4), "address of entry point"));
		this.BASE_OF_CODE = H(new DWORD(bytes.ReadUInt(4), "address of base of code"));
		this.BASE_OF_DATA = H(new DWORD(bytes.ReadUInt(4), "address of base of data"));

		this.IS_32_BIT = this.MAGIC_NUMBER.Get == MagicNumberType.PE32;

		bytes.Reset();
		if (this.IS_32_BIT)
		{
			bytes.Skip(28);
		}
		else
		{
			bytes.Skip(24);
		}


		//
		// Standard fields.
		//
		H(new HeaderDefinition("Windows specific fields"));

		if (this.IS_32_BIT)
		{
			this.IMAGE_BASE = H(new ImageBase(bytes.ReadUInt(4), "image base"));
		}
		else
		{
			this.IMAGE_BASE = H(new ImageBase_Wide(bytes.ReadULong(8), "image base"));
		}

		this.SECTION_ALIGNMENT = H(new DWORD(bytes.ReadUInt(4), "section alignment in bytes"));
		this.FILE_ALIGNMENT = H(new DWORD(bytes.ReadUInt(4), "file alignment in bytes"));

		this.MAJOR_OS_VERSION = H(new WORD(bytes.ReadUShort(2), "major operating system version"));
		this.MINOR_OS_VERSION = H(new WORD(bytes.ReadUShort(2), "minor operating system version"));
		this.MAJOR_IMAGE_VERSION = H(new WORD(bytes.ReadUShort(2), "major image version"));
		this.MINOR_IMAGE_VERSION = H(new WORD(bytes.ReadUShort(2), "minor image version"));
		this.MAJOR_SUBSYSTEM_VERSION = H(new WORD(bytes.ReadUShort(2), "major subsystem version"));
		this.MINOR_SUBSYSTEM_VERSION = H(new WORD(bytes.ReadUShort(2), "minor subsystem version"));

		this.WIN32_VERSION_VALUE = H(new DWORD(bytes.ReadUInt(4), "win32 version value (reserved, must be zero)"));
		this.SIZE_OF_IMAGE = H(new DWORD(bytes.ReadUInt(4), "size of image in bytes"));
		this.SIZE_OF_HEADERS = H(new DWORD(bytes.ReadUInt(4), "size of headers (MS DOS stub, PE header, and section headers)"));
		this.CHECKSUM = H(new DWORD(bytes.ReadUInt(4), "checksum"));
		this.SUBSYSTEM = H(new Subsystem(bytes.ReadUShort(2), "subsystem"));
		this.DLL_CHARACTERISTICS = H(new DllCharacteristics(bytes.ReadUShort(2), "dll characteristics"));

		if (this.IS_32_BIT)
		{
			this.SIZE_OF_STACK_RESERVE = H(new DWORD(bytes.ReadUInt(4), "size of stack reserve"));
			this.SIZE_OF_STACK_COMMIT = H(new DWORD(bytes.ReadUInt(4), "size of stack commit"));
			this.SIZE_OF_HEAP_RESERVE = H(new DWORD(bytes.ReadUInt(4), "size of heap reserve"));
			this.SIZE_OF_HEAP_COMMIT = H(new DWORD(bytes.ReadUInt(4), "size of heap commit"));
		}
		else
		{
			this.SIZE_OF_STACK_RESERVE = H(new DWORD_WIDE(bytes.ReadULong(8), "size of stack reserve"));
			this.SIZE_OF_STACK_COMMIT = H(new DWORD_WIDE(bytes.ReadULong(8), "size of stack commit"));
			this.SIZE_OF_HEAP_RESERVE = H(new DWORD_WIDE(bytes.ReadULong(8), "size of heap reserve"));
			this.SIZE_OF_HEAP_COMMIT = H(new DWORD_WIDE(bytes.ReadULong(8), "size of heap commit"));
		}

		this.LOADER_FLAGS = H(new DWORD(bytes.ReadUInt(4), "loader flags (reserved, must be zero)"));
		this.NUMBER_OF_RVA_AND_SIZES = H(new RVA(bytes.ReadUInt(4), "number of rva and sizes"));


		bytes.Reset();
		if (this.IS_32_BIT)
		{
			bytes.Skip(96);
		}
		else
		{
			bytes.Skip(112);
		}

		//
		// Data directories
		//
		H(new HeaderDefinition("Data Directories"));
		this.EXPORT_TABLE = Table(H(new ImageDataDir(bytes, DirEntry.EXPORT)));
		this.IMPORT_TABLE = Table(H(new ImageDataDir(bytes, DirEntry.IMPORT)));
		this.RESOURCE_TABLE = Table(H(new ImageDataDir(bytes, DirEntry.RESOURCE)));
		this.EXCEPTION_TABLE = Table(H(new ImageDataDir(bytes, DirEntry.EXCEPTION)));
		this.CERTIFICATE_TABLE = Table(H(new ImageDataDir(bytes, DirEntry.SECURITY)));
		this.BASE_RELOCATION_TABLE = Table(H(new ImageDataDir(bytes, DirEntry.BASERELOC)));

		this.DEBUG = Table(H(new ImageDataDir(bytes, DirEntry.DEBUG)));
		this.COPYRIGHT = Table(H(new ImageDataDir(bytes, DirEntry.COPYRIGHT)));
		this.GLOBAL_PTR = Table(H(new ImageDataDir(bytes, DirEntry.GLOBALPTR)));
		this.TLS_TABLE = Table(H(new ImageDataDir(bytes, DirEntry.TLS)));
		this.LOAD_CONFIG_TABLE = Table(H(new ImageDataDir(bytes, DirEntry.LOAD_CONFIG)));

		this.BOUND_IMPORT = H(new ImageDataDirExtra(bytes, "bound import"));
		this.IAT = H(new ImageDataDirExtra(bytes, "IAT"));
		this.DELAY_IMPORT_DESCRIPTOR = H(new ImageDataDirExtra(bytes, "delay import descriptor"));
		this.CLR_RUNTIME_HEADER = H(new ImageDataDirExtra(bytes, "COM+ runtime header"));

		// reserved 8 bytes!!
		bytes.Skip(8);
	}

	private T Table<T>(T obj) where T : ImageDataDir
	{
		this.tables.Add(obj);
		return obj;
	}
}