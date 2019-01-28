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

        private ICategorize _CategorizerType;

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

        protected void setCategorizerType(ICategorize CategorizerType)
        {
            _CategorizerType = CategorizerType;
        }
        protected void Categorize()
        {
            if (!_CategorizerType.Equals(null))
            {
                _CategorizerType.Categorize(Name, Categories, SubCategories);
            }
            else
            {
                Console.WriteLine("\nThere is no fileType assigned to Categorize.");
            }
        }
    }

    public class ExeFileType : FileType
    {
        public ExeFileType(string name, string extension) : base(name, extension)
        {
            Name = name;
            Extension = extension;
            setCategorizerType(new ExeFileTypeCategorizer());
            Categorize();
        }
    }
    public class PdfFileType : FileType
    {
        public PdfFileType(string name, string extension) : base(name, extension)
        {
            Name = name;
            Extension = extension;
            setCategorizerType(new PdfFileTypeCategorizer());
            Categorize();

        }
    }
    public class DocFileType : FileType
    {
        public DocFileType(string name, string extension) : base(name, extension)
        {
            Name = name;
            Extension = extension;
            setCategorizerType(new DocFileTypeCategorizer());
            Categorize();

        }
    }
}
