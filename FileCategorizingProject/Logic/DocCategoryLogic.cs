using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCategorizingProject
{
    public class DocCategorizeBFollowedByA : BFollowedByALink, ICategory
    {
        public DocCategorizeBFollowedByA()
        {
            Logic = this;
            Category = this;
        }

        public string GetCategory()
        {
            return "cb";
        }
    }
    public class DocCategorizeContainsG : ContainsGLink, ICategory
    {
        public DocCategorizeContainsG()
        {
            Logic = this;
            Category = this;
        }

        public string GetCategory()
        {
            return "g";
        }
    }
    public class DocSubCategorizeGFollowedByB : GFollowedByBLink, ISubCategory
    {
        public DocSubCategorizeGFollowedByB()
        {
            Logic = this;
            SubCategory = this;
        }

        public string GetSubCategory()
        {
            return "gb";
        }
    }
    public class DocSubCategorizeContainsG : SimpleLogicLink, ISubCategory
    {
        public DocSubCategorizeContainsG()
        {
            Logic = this;
            SubCategory = this;
        }

        public override bool DoLogic(FileInfo file)
        {
            return (file.GetCategories().Contains("g") && file.GetCategories().Contains("cb"));
        }

        public string GetSubCategory()
        {
            return "g";
        }
    }
    public class DocSubCategorizeContainsZ : SimpleLogicLink, ISubCategory
    {
        public DocSubCategorizeContainsZ()
        {
            Logic = this;
            SubCategory = this;
        }

        public override bool DoLogic(FileInfo file)
        {
            return ((file.GetCategories().Contains("cb") || (file.GetCategories().Contains("g")) && ContainsZ(file.GetName())));
        }

        public string GetSubCategory()
        {
            return "c";
        }
    }
}
