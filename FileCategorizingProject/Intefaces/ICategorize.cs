using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCategorizingProject
{
    public interface ICategorizeFile
    {
        void Categorize(FileType file, IChainCategoryLogic _Categories);
        void SubCategorize(FileType file, IChainCategoryLogic _SubCategories);
    }

    public interface IChainCategoryLogic
    {
        void SetNextChain(IChainCategoryLogic chain);
        void Categorize(FileType file);
    }
}
