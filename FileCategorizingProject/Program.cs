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
            List<FileType> files = new List<FileType> { };
            string dir = @"C:\Users\avizel\Documents\Visual Studio 2015\Projects\File Categorizing Project\File Categorizing Project\files";
            var fileNames = from names
                            in Directory.GetFiles(dir)
                            select Path.GetFileName(names);
            
            foreach (string fileName in fileNames)
            {
                files.Add(new FileTypeFactory(fileName).getFileType());
            }

            foreach (FileType p in files)
            {
                Console.Write(p.getName() + "\t| " + p.getExtension() + "\t| ");
                for (int i = 0; i < p.getCategories().Count(); i++)
                {
                    Console.Write(p.getCategories()[i] + ",");
                }
                Console.Write("\t| ");
                for (int i = 0; i < p.getSubCategories().Count(); i++)
                {
                    Console.Write(p.getSubCategories()[i] + ",");
                }
                Console.Write("\n");
            }
            Console.ReadLine();
        }
    }
}
