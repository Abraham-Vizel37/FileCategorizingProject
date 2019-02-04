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
        protected ILogic Logic;
        protected ICategory Category;
        protected ISubCategory SubCategory;


        public void SetNextChain(IChainCategorization chain)
        {
            NextChain = chain;
        }

        public void Categorize(FileInfo file)
        {
            if (Logic.DoLogic(file))
            {
                if (Category != null)
                {
                    file.AddCategory(Category.GetCategory());
                }
                else if (SubCategory != null)
                {
                    file.AddSubCategory(SubCategory.GetSubCategory());
                }                
            }
            if (NextChain != null)
                NextChain.Categorize(file);
        }      
    }

    public abstract class SimpleLogicLink : CategorizingLogicLinks, ILogic
    {
        public abstract bool DoLogic(FileInfo file);

        public bool ContainsZ(string fileName) => Contains(fileName, 'z');
        public bool Contains(string fileName, char first) => fileName.Contains(first);
        public bool FollowedBy(string fileName, char first, char second) => fileName.Contains(first) ? fileName.Substring(fileName.IndexOf(first)).Contains(second) : false;
    }

    public abstract class AFollowedByBLink : SimpleLogicLink, ILogic
    {
        public override bool DoLogic(FileInfo file)
        {
            return AFollowedByB(file.GetName());
        }

        public bool AFollowedByB(string fileName) => FollowedBy(fileName, 'a', 'b');        
    }
    public abstract class BFollowedByALink : SimpleLogicLink, ILogic
    {
        public override bool DoLogic(FileInfo file)
        {
            return BFollowedByA(file.GetName());
        }

        public bool BFollowedByA(string fileName) => FollowedBy(fileName, 'b', 'a');
    }
    public abstract class GFollowedByBLink : SimpleLogicLink, ILogic
    {
        public override bool DoLogic(FileInfo file)
        {
            return GFollowedByB(file.GetName());
        }

        public bool GFollowedByB(string fileName) => FollowedBy(fileName, 'g', 'b');
    }

    public abstract class ContainsCLink : SimpleLogicLink, ILogic
    {
        public override bool DoLogic(FileInfo file)
        {
            return ContainsC(file.GetName());
        }

        public bool ContainsC(string fileName) => Contains(fileName, 'c');
    }
    public abstract class ContainsGLink : SimpleLogicLink, ILogic
    {
        public override bool DoLogic(FileInfo file)
        {
            return ContainsG(file.GetName());
        }

        public bool ContainsG(string fileName) => Contains(fileName, 'g');
    }
    public abstract class ContainsZLink : SimpleLogicLink, ILogic
    {
        public override bool DoLogic(FileInfo file)
        {
            return ContainsZ(file.GetName());
        }

        public bool ContainsZ(string fileName) => Contains(fileName, 'z');
    }

}
