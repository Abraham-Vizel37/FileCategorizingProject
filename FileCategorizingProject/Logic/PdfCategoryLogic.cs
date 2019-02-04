using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCategorizingProject
{
    public class PdfCategorizeBFollowedByA : BFollowedByALink, ICategory
    {
        public PdfCategorizeBFollowedByA()
        {
            Logic = this;
            Category = this;
        }

        public string GetCategory()
        {
            return "ab";
        }
    }
    public class PdfCategorizeContainsC : ContainsCLink, ICategory
    {
        public PdfCategorizeContainsC()
        {
            Logic = this;
            Category = this;
        }

        public string GetCategory()
        {
            return "c";
        }
    }
    public class PdfSubCategorizeAFollowedByB : AFollowedByBLink, ISubCategory
    {
        public PdfSubCategorizeAFollowedByB()
        {
            Logic = this;
            SubCategory = this;
        }

        public string GetSubCategory()
        {
            return "ba";
        }
    }
    public class PdfSubCategorizeContainsZ: SimpleLogicLink, ISubCategory
    {
        public PdfSubCategorizeContainsZ()
        {
            Logic = this;
            SubCategory = this;
        }

        public override bool DoLogic(FileInfo file)
        {
            return ((file.GetCategories().Contains("ab") || (file.GetCategories().Contains("c")) && ContainsZ(file.GetName())));
        }

        public string GetSubCategory()
        {
            return "z";
        }
    }
}
