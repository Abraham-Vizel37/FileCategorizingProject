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
            List<File> files = new List<File> { };
            string dir = @"C:\Users\avizel\Documents\Visual Studio 2015\Projects\File Categorizing Project\File Categorizing Project\files";
            var fileNames = from names
                            in Directory.GetFiles(dir)
                            select Path.GetFileName(names);


            foreach (string fileName in fileNames)
            {
                files.Add(getFileNameInfo(fileName));
            }

            foreach (File p in files)
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

        static File getFileNameInfo(string file)
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

    public interface ICategorize
    {
        void Categorize(string fileName, List<string> categories, List<string> subCategories);
    }
    public class CategoryCriteria
    {
        public bool AFollowedByB(string FileName)
        {
            return FollowedBy(FileName, 'a', 'b');
        }

        public bool BFollowedByA(string FileName)
        {
            return FollowedBy(FileName, 'b', 'a');
        }

        public bool GFollowedByB(string FileName)
        {
            return FollowedBy(FileName, 'g', 'b');
        }

        public bool ContainsC(string FileName)
        {
            return Contains(FileName, 'c');
        }

        public bool ContainsG(string FileName)
        {
            return Contains(FileName, 'g');
        }

        public bool ContainsZ(string FileName)
        {
            return Contains(FileName, 'z');
        }

        public bool Contains(string FileName, char first)
        {
            return FileName.Contains(first);
        }

        public bool FollowedBy(string FileName, char first, char second)
        {
            if (FileName.Contains(first))
            {
                return FileName.Substring(FileName.IndexOf(first)).Contains(second);
            }
            return false;
        }
    }

    public class ExeCategories : CategoryCriteria, ICategorize
    {
        public void Categorize(string fileName, List<string> categories, List<string> subCategories)
        {
            if (AFollowedByB(fileName))
            {
                categories.Add("ab");
                if (ContainsC(fileName))
                {
                    subCategories.Add("c");
                }
            }
            if (ContainsG(fileName))
            {
                categories.Add("g");
                if (AFollowedByB(fileName))
                {
                    subCategories.Add("ba");
                }
                if (ContainsZ(fileName))
                {
                    subCategories.Add("z");
                }
            }
        }
    }
    public class PdfCategories : CategoryCriteria, ICategorize
    {
        public void Categorize(string fileName, List<string> categories, List<string> subCategories)
        {
            if (BFollowedByA(fileName))
            {
                categories.Add("ab");
            }
            if (ContainsC(fileName))
            {
                categories.Add("c");
                if (AFollowedByB(fileName))
                {
                    subCategories.Add("ba");
                }
            }
            if (BFollowedByA(fileName) || ContainsC(fileName))
                if (ContainsZ(fileName))
                    subCategories.Add("z");
        }
    }
    public class DocCategories : CategoryCriteria, ICategorize
    {
        public void Categorize(string fileName, List<string> categories, List<string> subCategories)
        {
            if (BFollowedByA(fileName))
            {
                categories.Add("cb");
                if (ContainsG(fileName))
                {
                    subCategories.Add("g");
                }
            }
            if (ContainsG(fileName))
            {
                categories.Add("g");
                if (GFollowedByB(fileName))
                {
                    subCategories.Add("gb");
                }
                if (ContainsZ(fileName))
                {
                    subCategories.Add("c");
                }
            }
        }
    }

    public class File
    {
        protected string Name;
        protected string Extension;
        protected List<string> Categories = new List<string> { };
        protected List<string> SubCategories = new List<string> { };

        private ICategorize _CategorizeType;

        public File(string name, string extension)
        {
            Name = name;
            Extension = extension;
        }

        public string getName()
        {
            return Name;
        }

        public void setExtension(string extension)
        {
            Extension = extension;
        }

        public string getExtension()
        {
            return Extension;
        }

        public List<string> getCategories()
        {
            return Categories;
        }

        public List<string> getSubCategories()
        {
            return SubCategories;
        }


        protected void setCategorizeType(ICategorize CategorizeType)
        {
            _CategorizeType = CategorizeType;
        }
        protected void Categorize()
        {
            if (!_CategorizeType.Equals(null))
            {
                _CategorizeType.Categorize(Name, Categories, SubCategories);
            }
            else
            {
                Console.WriteLine("There is no fileType assigned to Categorize.");
            }
        }

    }

    public class ExeFile : File
    {
        public ExeFile(string name, string extension) : base(name, extension)
        {
            Name = name;
            Extension = extension;
            setCategorizeType(new ExeCategories());
            Categorize();
        }
    }
    public class PdfFile : File
    {
        public PdfFile(string name, string extension) : base(name, extension)
        {
            Name = name;
            Extension = extension;
            setCategorizeType(new PdfCategories());
            Categorize();

        }
    }
    public class DocFile : File
    {
        public DocFile(string name, string extension) : base(name, extension)
        {
            Name = name;
            Extension = extension;
            setCategorizeType(new DocCategories());
            Categorize();

        }
    }
}
