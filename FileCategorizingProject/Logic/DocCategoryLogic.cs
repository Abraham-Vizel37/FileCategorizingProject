using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCategorizingProject
{
    public class DocCategorizeBFollowedByA : BFollowedByALink
    {
        public override void Categorize(FileInfo file)
        {
            if (BFollowedByA(file.getName()))
            {
                file.addCategory("cb");
            }
            if (NextChain != null)
                NextChain.Categorize(file);
        }
    }
    public class DocCategorizeContainsG : ContainsGLink
    {
        public override void Categorize(FileInfo file)
        {
            if (ContainsG(file.getName()))
            {
                file.addCategory("g");
            }
            if (NextChain != null)
                NextChain.Categorize(file);
        }
    }
    public class DocSubCategorizeGFollowedByB : GFollowedByBLink
    {
        public override void Categorize(FileInfo file)
        {
            if (GFollowedByB(file.getName()))
            {
                file.addSubCategory("gb");
            }
            if (NextChain != null)
                NextChain.Categorize(file);
        }
    }
    public class DocSubCategorizeContainsG: ContainsGLink
    {
        public override void Categorize(FileInfo file)
        {
            if (ContainsG(file.getName()))
            {
                file.addSubCategory("g");
            }
            if (NextChain != null)
                NextChain.Categorize(file);
        }
    }
    public class DocSubCategorizeContainsZ : CategorizingLogicLinks
    {
        public override void Categorize(FileInfo file)
        {
            if (ContainsZ(file.getName()))
            {
                file.addSubCategory("c");
            }
            if (NextChain != null)
                NextChain.Categorize(file);
        }
    }
}
