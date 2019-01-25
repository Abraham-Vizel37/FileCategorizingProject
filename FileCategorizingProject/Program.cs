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
                files.Add(getFileNameInfo(fileName));
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

        static FileType getFileNameInfo(string file)
        {
            string fileExtension = FindExt(file);
            string fileName = FindFileName(file);
            if (fileExtension == ".exe" || fileExtension == ".txt")
            {
                return new ExeFile(fileName, fileExtension);
            }
            else if (fileExtension == ".pdf" || fileExtension == ".bmp")
            {
                return new PdfFile(fileName, fileExtension);
            }
            else if (fileExtension == ".docx")
            {
                return new DocFile(fileName, fileExtension);
            }
            else
            {
                return null;
            }
        }

        static string FindExt(string file)
        {
            return file.Substring(file.IndexOf('.'));
        }
        static string FindFileName(string file)
        {
            return file.Substring(0, file.IndexOf('.'));
        }
    }
}
