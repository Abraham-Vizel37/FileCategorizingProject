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
                if(Category!=null)
                file.addCategory(Category.GetCategory());
                else
                {
                    file.addSubCategory(SubCategory.GetSubCategory());
                }
            }
            if (NextChain != null)
                NextChain.Categorize(file);
        }


        public bool ContainsZ(string fileName) => Contains(fileName, 'z');
        public bool Contains(string fileName, char first) => fileName.Contains(first);
        public bool FollowedBy(string fileName, char first, char second) => fileName.Contains(first) ? fileName.Substring(fileName.IndexOf(first)).Contains(second) : false;


    }

    public abstract class LogicClass : CategorizingLogicLinks, ILogic
    {
        public abstract bool DoLogic(FileInfo file);

    }

    public abstract class AFollowedByBLink : LogicClass, ILogic
    {
        public override bool DoLogic(FileInfo file)
        {
            return AFollowedByB(file.getName());
        }

        public bool AFollowedByB(string fileName) => FollowedBy(fileName, 'a', 'b');
        
    }
    public abstract class BFollowedByALink : LogicClass, ILogic
    {
        public override bool DoLogic(FileInfo file)
        {
            return BFollowedByA(file.getName());
        }

        public bool BFollowedByA(string fileName) => FollowedBy(fileName, 'b', 'a');
    }
    public abstract class GFollowedByBLink : LogicClass, ILogic
    {
        public override bool DoLogic(FileInfo file)
        {
            return GFollowedByB(file.getName());
        }

        public bool GFollowedByB(string fileName) => FollowedBy(fileName, 'g', 'b');
    }
    public abstract class ContainsCLink : LogicClass, ILogic
    {
        public override bool DoLogic(FileInfo file)
        {
            return ContainsC(file.getName());
        }

        public bool ContainsC(string fileName) => Contains(fileName, 'c');
    }
    public abstract class ContainsGLink : LogicClass, ILogic
    {
        public override bool DoLogic(FileInfo file)
        {
            return ContainsG(file.getName());

        }
        public bool ContainsG(string fileName) => Contains(fileName, 'g');
    }


}
