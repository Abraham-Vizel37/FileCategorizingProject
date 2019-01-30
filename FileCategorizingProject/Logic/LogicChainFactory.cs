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
        private IChainCategoryLogic _categories;
        private IChainCategoryLogic _subCategories;

        public LogicChainFactory(FileInfo file)
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
                    _categories = new ExeCategorizeAFollowedByB();
                    _categories.SetNextChain(new ExeCategorizeContainsG());
                    break;
                case ".pdf":
                case ".bmp":
                    _categories = new PdfCategorizeBFollowedByA();
                    _categories.SetNextChain(new PdfCategorizeContainsC());
                    break;
                case ".docx":
                    _categories = new DocCategorizeBFollowedByA();
                    _categories.SetNextChain(new DocCategorizeContainsG());
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
                    _subCategories = new ExeSubCategorizeContainsC();
                    _subCategories = new ExeSubCategorizeAFollowedByB();
                    _subCategories.SetNextChain(new ExeSubCategorizeContainsZ());
                    break;
                case ".pdf":
                case ".bmp":
                    _subCategories = new PdfSubCategorizeAFolloedByB();
                    _subCategories.SetNextChain(new PdfSubCategorizeContainsZ());
                    break;
                case ".docx":
                    _subCategories = new DocSubCategorizeContainsG();
                    _subCategories.SetNextChain(new DocSubCategorizeGFollowedByB());
                    _subCategories.SetNextChain(new DocSubCategorizeContainsZ());
                    break;
                default:
                    break;
            }
        }

        public IChainCategoryLogic getCategoryChain()
        {
            return _categories;
        }
        public IChainCategoryLogic getSubCategoryChain()
        {
            return _subCategories;
        }
    }
}
