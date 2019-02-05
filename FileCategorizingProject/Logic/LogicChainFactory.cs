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
        private IChainCategorization _categories;
        private IChainCategorization _subCategories;
        private List<IChainCategorization> _categoryLinks = new List<IChainCategorization> { };
        private List<IChainCategorization> _subCategoryLinks = new List<IChainCategorization> { };

        public FileInfo ProcessFile(FileInfo file)
        {
            _extension = file.GetExtension();
            SetCategoryChain();
            SetSubCategoryChain();
            return file;
        }

        private void SetCategoryChain()
        {
            switch (_extension)
            {
                case ".exe":
                case ".txt":
                    _categories = new ExeCategorizeAFollowedByB();
                    _categoryLinks.Add(new ExeCategorizeContainsG());
                    break;
                case ".pdf":
                case ".bmp":
                    _categories = new PdfCategorizeBFollowedByA();
                    _categoryLinks.Add(new PdfCategorizeContainsC());                    
                    break;
                case ".docx":
                    _categories = new DocCategorizeBFollowedByA();
                    _categoryLinks.Add(new DocCategorizeContainsG());                   
                    break;
                default:
                    break;                    
            }

            if (_categoryLinks.Count > 0)
            {
                for(int i = 0; i < _categoryLinks.Count()-1; i++)
                {
                    _categoryLinks[i].SetNextChain(_categoryLinks[i + 1]);
                }
                _categories.SetNextChain(_categoryLinks[0]);
            }

        }
        private void SetSubCategoryChain()
        {
            switch (_extension)
            {
                case ".exe":
                case ".txt":
                    _subCategories = new ExeSubCategorizeContainsC();
                    _subCategoryLinks.Add(new ExeSubCategorizeAFollowedByB());
                    _subCategoryLinks.Add(new ExeSubCategorizeContainsZ());
                    break;
                case ".pdf":
                case ".bmp":
                    _subCategories = new PdfSubCategorizeAFollowedByB();
                    _subCategoryLinks.Add(new PdfSubCategorizeContainsZ());                    
                    break;
                case ".docx":
                    _subCategories = new DocSubCategorizeContainsG();
                    _subCategoryLinks.Add(new DocSubCategorizeGFollowedByB());
                    _subCategoryLinks.Add(new DocSubCategorizeContainsZ());
                    break;
                default:
                    break;
            }
            if (_subCategoryLinks.Count != 0)
            {
                for (int i = 0; i < _subCategoryLinks.Count()-1; i++)
                {                    
                    _subCategoryLinks[i].SetNextChain(_subCategoryLinks[i + 1]);
                }
                _subCategories.SetNextChain(_subCategoryLinks[0]);
            }
        }

        public IChainCategorization GetCategoryChain()
        {
            return _categories;
        }
        public IChainCategorization GetSubCategoryChain()
        {
            return _subCategories;
        }
    }
}
