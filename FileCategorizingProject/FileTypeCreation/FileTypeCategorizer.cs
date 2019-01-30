using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCategorizingProject
{
    public class FileTypeCategorizer
    {
        private ICategorizeFile _Categorizer;

        public FileTypeCategorizer(ICategorizeFile categorizer)
        {
            _Categorizer = categorizer;
        }

        public void Categorize(FileType file)
        {
            if (!_Categorizer.Equals(null) || !file.Equals(null))
            {
                _Categorizer.Categorize(file, new LogicChainFactory(file).getCategoryChain());
                _Categorizer.SubCategorize(file, new LogicChainFactory(file).getSubCategoryChain());
            }
            else
            {
                Console.WriteLine("\nThere is no fileType assigned to the Categorizer.");
            }
            
        }
    }

    public class AllFileTypesCategorizer : ICategorizeFile
    {
        public void Categorize(FileType file, IChainCategoryLogic _Categories)
        {
            _Categories.Categorize(file);
        }
        public void SubCategorize(FileType file, IChainCategoryLogic _SubCategories)
        {
            _SubCategories.Categorize(file);
        }
    }
}
