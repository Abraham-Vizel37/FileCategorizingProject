using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCategorizingProject
{
    public class LogicChainFactory
    {
        private string _extension;
        private IChainCategoryLogic _Categories;
        private IChainCategoryLogic _SubCategories;

        public LogicChainFactory(FileType file)
        {
            _extension = file.getExtension();
            setCategoryChain();
            setSubCategoryChain();
        }

        private void setCategoryChain()
        {
            switch (_extension)
            {
                case ".exe":
                case ".txt":
                    _Categories = new ExeCategorizeAFollowedByB();
                    _Categories.SetNextChain(new ExeCategorizeContainsG());
                    break;
                case ".pdf":
                case ".bmp":
                    _Categories = new PdfCategorizeBFollowedByA();
                    _Categories.SetNextChain(new PdfCategorizeContainsC());
                    break;
                case ".docx":
                    _Categories = new DocCategorizeBFollowedByA();
                    _Categories.SetNextChain(new DocCategorizeContainsG());
                    break;
                default:
                    break;
                    
            }
        }
        private void setSubCategoryChain()
        {
            switch (_extension)
            {
                case ".exe":
                case ".txt":
                    _SubCategories = new ExeSubCategorizeContainsC();
                    _SubCategories = new ExeSubCategorizeAFollowedByB();
                    _SubCategories.SetNextChain(new ExeSubCategorizeContainsZ());
                    break;
                case ".pdf":
                case ".bmp":
                    _SubCategories = new PdfSubCategorizeAFolloedByB();
                    _SubCategories.SetNextChain(new PdfSubCategorizeContainsZ());
                    break;
                case ".docx":
                    _SubCategories = new DocSubCategorizeContainsG();
                    _SubCategories.SetNextChain(new DocSubCategorizeGFollowedByB());
                    _SubCategories.SetNextChain(new DocSubCategorizeContainsZ());
                    break;
                default:
                    break;
            }
        }

        public IChainCategoryLogic getCategoryChain()
        {
            return _Categories;
        }
        public IChainCategoryLogic getSubCategoryChain()
        {
            return _SubCategories;
        }
    }
}
