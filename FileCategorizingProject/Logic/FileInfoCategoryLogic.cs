using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCategorizingProject
{
    public abstract class CategorizingLogicLinks : IChainCategoryLogic
    {
        protected IChainCategoryLogic NextChain;

        public void SetNextChain(IChainCategoryLogic chain)
        {
            NextChain = chain;
        }

        public abstract void Categorize(FileInfo file);

        public bool ContainsZ(string fileName) => Contains(fileName, 'z');
        public bool Contains(string fileName, char first) => fileName.Contains(first);
        public bool FollowedBy(string fileName, char first, char second) => fileName.Contains(first) ? fileName.Substring(fileName.IndexOf(first)).Contains(second) : false;
    }

    public abstract class AFollowedByBLink : CategorizingLogicLinks, IChainCategoryLogic
    {
        public bool AFollowedByB(string fileName) => FollowedBy(fileName, 'a', 'b');
    }
    public abstract class BFollowedByALink : CategorizingLogicLinks, IChainCategoryLogic
    {
        public bool BFollowedByA(string fileName) => FollowedBy(fileName, 'b', 'a');
    }
    public abstract class GFollowedByBLink : CategorizingLogicLinks, IChainCategoryLogic
    {
        public bool GFollowedByB(string fileName) => FollowedBy(fileName, 'g', 'b');
    }
    public abstract class ContainsCLink : CategorizingLogicLinks, IChainCategoryLogic
    {
        public bool ContainsC(string fileName) => Contains(fileName, 'c');
    }
    public abstract class ContainsGLink : CategorizingLogicLinks, IChainCategoryLogic
    {
        public bool ContainsG(string fileName) => Contains(fileName, 'g');
    }


}
