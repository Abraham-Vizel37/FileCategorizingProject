using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCategorizingProject
{
    public abstract class CategorizingLogicLinks : IChainCategorization
    {
        protected IChainCategorization NextChain;

        public void SetNextChain(IChainCategorization chain)
        {
            NextChain = chain;
        }

        public void Categorize(FileInfo file)
        {
            if (Logic(file))
            {
                AddCategory(file);
            }
            if (NextChain != null)
                NextChain.Categorize(file);
        }

        public abstract bool Logic(FileInfo file);
        public abstract void AddCategory(FileInfo file);
       
    }
}
