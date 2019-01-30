using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCategorizingProject
{
    public class ExeCategorizeAFollowedByB : AFollowedByBLink
    {
        public override void Categorize(FileInfo file)
        {
            if (AFollowedByB(file.getName()))
            {
                file.addCategory("ab");
            }
            if (NextChain!=null)
                NextChain.Categorize(file);
        }
    }
    public class ExeCategorizeContainsG : ContainsGLink
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
    public class ExeSubCategorizeAFollowedByB : AFollowedByBLink
    {
        public override void Categorize(FileInfo file)
        {
            if (file.getCategories().Contains("ab"))
            {
                if (file.getCategories().Contains("g"))
                {
                    file.addSubCategory("ba");
                }
            }
            if (NextChain != null)
                NextChain.Categorize(file);
        }
    }
    public class ExeSubCategorizeContainsC : ContainsCLink
    {
        public override void Categorize(FileInfo file)
        {
            if (ContainsC(file.getName()))
            {
                file.addSubCategory("c");
            }
            if (NextChain != null)
                NextChain.Categorize(file);
        }
    }
    public class ExeSubCategorizeContainsZ : CategorizingLogicLinks
    {
        public override void Categorize(FileInfo file)
        {
            if (file.getCategories().Contains("g"))
            {
                if (ContainsZ(file.getName()))
                {
                    file.addSubCategory("z");
                }
            }
            if (NextChain != null)
                NextChain.Categorize(file);
        }
    }
}
