using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCategorizingProject
{
    public interface IChainCategorization
    {
        void SetNextChain(IChainCategorization chain);
        void Categorize(FileInfo file);
    }

    public interface ILogic
    {
        bool DoLogic(FileInfo file);
    }

    public interface ICategory
    {
        string GetCategory();
    }

    public interface ISubCategory
    {
        string GetSubCategory();
    }
}
