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
            _logicChainFactory = new LogicChainFactory();
            _logicChainFactory.ProcessFile(this);
            SetCategories();
            SetSubCategories();            
        }

        public string GetName()
        {
            return Name;
        }
        public string GetExtension()
        {
            return Extension;
        }

        public List<string> GetCategories()
        {
            return Categories;
        }
        public List<string> GetSubCategories()
        {
            return SubCategories;
        }

        public void SetCategories()
        {            
            _logicChainFactory.GetCategoryChain().Categorize(this);
        }
        public void SetSubCategories()
        {
            _logicChainFactory.GetSubCategoryChain().Categorize(this);
        }

        public void AddCategory(string newCategory)
        {
            Categories.Add(newCategory);
        }
        public void AddSubCategory(string newSubCategory)
        {
            SubCategories.Add(newSubCategory);
        }
    }
}
