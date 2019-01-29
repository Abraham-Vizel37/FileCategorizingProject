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
        protected FileTypeCategorizer _FileTypeCategorizer;

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
        public void setCategories(List<string> categories)
        {
            Categories = categories;
        }
        public void setSubCategories(List<string> subCategories)
        {
            SubCategories = subCategories;
        }
    }

    public class ExeFileType : FileType
    {
        public ExeFileType(string name, string extension) : base(name, extension)
        {
            Name = name;
            Extension = extension;
            _FileTypeCategorizer = new FileTypeCategorizer(new ExeFileTypeCategorizer());
            _FileTypeCategorizer.Categorize(this);

        }
    }
    public class PdfFileType : FileType
    {
        public PdfFileType(string name, string extension) : base(name, extension)
        {
            Name = name;
            Extension = extension;
            _FileTypeCategorizer = new FileTypeCategorizer(new PdfFileTypeCategorizer());
            _FileTypeCategorizer.Categorize(this);
        }
    }
    public class DocFileType : FileType
    {
        public DocFileType(string name, string extension) : base(name, extension)
        {
            Name = name;
            Extension = extension;
            _FileTypeCategorizer = new FileTypeCategorizer(new DocFileTypeCategorizer());
            _FileTypeCategorizer.Categorize(this);
        }
    }
}
