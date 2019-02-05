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

            FileInfoFactory fileInfoFactory = new FileInfoFactory();

            foreach (string fileName in fileNames)
            {
                files.Add(fileInfoFactory.GetFileInfo(fileName));
            }
            

            foreach (FileInfo p in files)
            {
                Console.Write(p.GetName() + "\t| " + p.GetExtension() + "\t| ");
                for (int i = 0; i < p.GetCategories().Count(); i++)
                {
                    if (i == p.GetCategories().Count() - 1)
                    {
                        Console.Write(p.GetCategories()[i]);
                    }
                    else
                    {
                        Console.Write(p.GetCategories()[i] + ",");
                    }
                    
                }
                Console.Write("\t| ");
                for (int i = 0; i < p.GetSubCategories().Count(); i++)
                {
                    if (i == p.GetSubCategories().Count()-1)
                    {
                        Console.Write(p.GetSubCategories()[i]);
                    }
                    else
                    {
                        Console.Write(p.GetSubCategories()[i] + ",");
                    }
                }
                Console.Write("\n");
            }

            Console.ReadLine();
        }
    }
}
