using System;
using System.IO;
using System.Runtime.InteropServices;

namespace PrintDirectory
{
  internal class Program
  {
    static void PrintDir(DirectoryInfo dir, string indent, bool lastDir)
    {
      Console.Write(indent);
      if (lastDir)
      {
        Console.Write("└─");
        indent += "  ";
      }
      else
      {
        Console.Write("├─");
        indent += "│ ";
      }
      Console.WriteLine(dir.Name);

      DirectoryInfo[] dirs = dir.GetDirectories();
      for (int i = 0; i < dirs.Length; i++)
      {
        PrintDir(dirs[i], indent , i == dirs.Length -1);
        FileInfo[] files = dir.GetFiles();
        foreach (var file in files)
        {
          Console.WriteLine(indent + "│ " + "---" + file.Name);
        }
      }
    }
    
    public static void Main(string[] args)
    {
      PrintDir(new DirectoryInfo(@"C:\Users\Dell\Desktop\IT\repos\SharpBasicHomework1\SharpBasicGB\Lesson 6"), "", true);
    }
  }
}