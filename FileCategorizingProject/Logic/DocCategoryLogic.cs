using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCategorizingProject
{
    public class DocCategorizeBFollowedByA : BFollowedByALink
    {
        public override void Categorize(FileType file)
        {
            if (BFollowedByA(file.getName()))
            {
                file.addCategory("cb");
            }
            if (_NextChain != null)
                _NextChain.Categorize(file);
        }
    }
    public class DocCategorizeContainsG : ContainsGLink
    {
        public override void Categorize(FileType file)
        {
            if (ContainsG(file.getName()))
            {
                file.addCategory("g");
            }
            if (_NextChain != null)
                _NextChain.Categorize(file);
        }
    }
    public class DocSubCategorizeGFollowedByB : GFollowedByBLink
    {
        public override void Categorize(FileType file)
        {
            if (GFollowedByB(file.getName()))
            {
                file.addSubCategory("gb");
            }
            if (_NextChain != null)
                _NextChain.Categorize(file);
        }
    }
    public class DocSubCategorizeContainsG: ContainsGLink
    {
        public override void Categorize(FileType file)
        {
            if (ContainsG(file.getName()))
            {
                file.addSubCategory("g");
            }
            if (_NextChain != null)
                _NextChain.Categorize(file);
        }
    }
    public class DocSubCategorizeContainsZ : CategorizingLogicLinks
    {
        public override void Categorize(FileType file)
        {
            if (ContainsZ(file.getName()))
            {
                file.addSubCategory("c");
            }
            if (_NextChain != null)
                _NextChain.Categorize(file);
        }
    }
}
