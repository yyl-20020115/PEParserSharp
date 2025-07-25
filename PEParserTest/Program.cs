using PEParserSharp;
using System;
using System.IO;
using System.Linq;

namespace PEParserTest;

public class Program
{
    public static void Main(string[] args)
    {
        var imageresDll = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "SystemResources", "imageres.dll.mun");
        if (!File.Exists(imageresDll))
        {
            imageresDll = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "imageres.dll");
        }

        Console.WriteLine($"Dumping info about: {imageresDll}\n");

        var pe = new PeFile(imageresDll);

        Console.WriteLine(pe.Info);

        Console.WriteLine($"Loading icons from: {imageresDll}\n");

        var icons = pe.ExtractIcons(256, [3, 35, 109]); // Folder, Disk, This PC
        
        Console.WriteLine(string.Join(Environment.NewLine, icons.Select(ic => $"Index: {ic.Name}, Format: {ic.IconType}, ByteSize: {ic.IconData.Length}")));

        Console.ReadKey();
    }
}
