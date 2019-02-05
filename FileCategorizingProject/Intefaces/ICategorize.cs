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
}
