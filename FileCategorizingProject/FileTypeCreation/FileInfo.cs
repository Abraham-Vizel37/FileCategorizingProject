using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FileCategorizingProject
{
    public class FileInfo
    {
        protected string Name;
        protected string Extension;

        protected List<string> Categories = new List<string> { };
        protected List<string> SubCategories = new List<string> { };
        protected LogicChainFactory _logicChainFactory;

        public FileInfo(string name, string extension)
        {
            Name = name;
            Extension = extension;
            _logicChainFactory = new LogicChainFactory(this);
            setCategories();
            setSubCategories();            
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

        public void setCategories()
        {            
            _logicChainFactory.getCategoryChain().Categorize(this);
        }
        public void setSubCategories()
        {
            _logicChainFactory.getSubCategoryChain().Categorize(this);
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
}
