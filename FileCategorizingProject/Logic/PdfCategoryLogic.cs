using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCategorizingProject
{
    public class PdfCategorizeBFollowedByA : BFollowedByALink
    {
        public override void Categorize(FileInfo file)
        {
            if (BFollowedByA(file.getName()))
            {
                file.addCategory("ab");
            }
            if (NextChain != null)
                NextChain.Categorize(file);
        }
    }
    public class PdfCategorizeContainsC : ContainsCLink
    {
        public override void Categorize(FileInfo file)
        {
            if (ContainsC(file.getName()))
            {
                file.addCategory("c");
            }
            if (NextChain != null)
                NextChain.Categorize(file);
        }
    }
    public class PdfSubCategorizeAFolloedByB : AFollowedByBLink
    {
        public override void Categorize(FileInfo file)
        {
            if (AFollowedByB(file.getName()))
            {
                file.addSubCategory("ba");
            }
            if (NextChain != null)
                NextChain.Categorize(file);
        }
    }
    public class PdfSubCategorizeContainsZ: CategorizingLogicLinks
    {
        public override void Categorize(FileInfo file)
        {
            if (ContainsZ(file.getName()))
            {
                file.addSubCategory("z");
            }
            if (NextChain != null)
                NextChain.Categorize(file);
        }
    }
}
