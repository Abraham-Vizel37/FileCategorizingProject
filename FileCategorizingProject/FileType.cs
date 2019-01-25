using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCategorizingProject
{


    public class FileType
    {
        protected string Name;
        protected string Extension;
        protected List<string> Categories = new List<string> { };
        protected List<string> SubCategories = new List<string> { };
        private ICategorize _CategorizeType;

        public FileType(string name, string extension)
        {
            Name = name;
            Extension = extension;
        }

        public string getName()
        {
            return Name;
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
                Console.WriteLine("\nThere is no fileType assigned to Categorize.");
            }
        }

    }

    public class ExeFile : FileType
    {
        public ExeFile(string name, string extension) : base(name, extension)
        {
            Name = name;
            Extension = extension;
            setCategorizeType(new ExeCategories());
            Categorize();
        }
    }
    public class PdfFile : FileType
    {
        public PdfFile(string name, string extension) : base(name, extension)
        {
            Name = name;
            Extension = extension;
            setCategorizeType(new PdfCategories());
            Categorize();

        }
    }
    public class DocFile : FileType
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
