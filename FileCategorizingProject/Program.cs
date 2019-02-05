using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FileCategorizingProject
{
    class Program
    {
        static void Main(string[] args)
        {
            List<FileInfo> files = new List<FileInfo> { };
            string dir = @"C:\Users\avizel\Documents\Visual Studio 2015\Projects\File Categorizing Project\File Categorizing Project\files";
            var fileNames = from names
                            in Directory.GetFiles(dir)
                            select Path.GetFileName(names);
            
            foreach (string fileName in fileNames)
            {
                files.Add(new FileInfoFactory(fileName).GetFileType());
            }

            foreach (FileInfo p in files)
            {
                Console.Write(p.getName() + "\t| " + p.getExtension() + "\t| ");
                for (int i = 0; i < p.getCategories().Count(); i++)
                {
                    if (i == p.getCategories().Count() - 1)
                    {
                        Console.Write(p.getCategories()[i]);
                    }
                    else
                    {
                        Console.Write(p.getCategories()[i] + ",");
                    }
                    
                }
                Console.Write("\t| ");
                for (int i = 0; i < p.getSubCategories().Count(); i++)
                {
                    if (i == p.getSubCategories().Count()-1)
                    {
                        Console.Write(p.getSubCategories()[i]);
                    }
                    else
                    {
                        Console.Write(p.getSubCategories()[i] + ",");
                    }
                }
                Console.Write("\n");
            }
            Console.ReadLine();
        }
    }
}
