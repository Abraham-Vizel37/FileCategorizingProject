using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FileCategorizingProject
{
    public abstract class FileType
    {
        protected string Name;
        protected string Extension;

        protected List<string> Categories = new List<string> { };
        protected List<string> SubCategories = new List<string> { };
        protected LogicChainFactory _logicChainFactory;
        protected FileTypeCategorizer _FileTypeCategorizer;

        public FileType(string name, string extension)
        {
            Name = name;
            Extension = extension;
            _FileTypeCategorizer = new FileTypeCategorizer(new AllFileTypesCategorizer());
            _FileTypeCategorizer.Categorize(this);
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

        public void addCategory(string newCategory)
        {
            Categories.Add(newCategory);
        }
        public void addSubCategory(string newSubCategory)
        {
            SubCategories.Add(newSubCategory);
        }
    }

    public class ExeFileType : FileType
    {
        public ExeFileType(string name, string extension) : base(name, extension)
        {
            Name = name;
            Extension = extension;
        }
    }
    public class PdfFileType : FileType
    {
        public PdfFileType(string name, string extension) : base(name, extension)
        {
            Name = name;
            Extension = extension;
        }
    }
    public class DocFileType : FileType
    {
        public DocFileType(string name, string extension) : base(name, extension)
        {
            Name = name;
            Extension = extension;           
        }
    }
}
