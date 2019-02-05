using FileCategorizingProject.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCategorizingProject
{
    public class PdfCategorizeBFollowedByA : BFollowedByALink
    {
        public override void AddCategory(FileInfo file)
        {
            file.AddCategory("ab");
        }

        public override bool Logic(FileInfo file)
        {
            return BFollowedByA(file.GetName());
        }
    }
    public class PdfCategorizeContainsC : ContainsCLink
    {
        public override void AddCategory(FileInfo file)
        {
            file.AddCategory("c");
        }

        public override bool Logic(FileInfo file)
        {
            return ContainsC(file.GetName());
        }
    }
    public class PdfSubCategorizeAFollowedByB : AFollowedByBLink
    {
        public override void AddCategory(FileInfo file)
        {
            file.AddSubCategory("ba");
        }

        public override bool Logic(FileInfo file)
        {
            return AFollowedByB(file.GetName());
        }
    }
    public class PdfSubCategorizeContainsZ: ContainsZLink
    {
        public override void AddCategory(FileInfo file)
        {
            file.AddSubCategory("z");
        }

        public override bool Logic(FileInfo file)
        {
            return ((file.GetCategories().Contains("ab") || (file.GetCategories().Contains("c")) && ContainsZ(file.GetName())));
        }
    }
}
