using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCategorizingProject
{
    public class ExeCategorizeAFollowedByB : AFollowedByBLink, ICategory
    {
        public ExeCategorizeAFollowedByB()
        {
            Logic = this;
            Category = this;
        }

        public string GetCategory()
        {
            return "ab";
        }
    }
    public class ExeCategorizeContainsG : ContainsGLink, ICategory
    {
        public ExeCategorizeContainsG()
        {
            Logic = this;
            Category = this;
        }

        public string GetCategory()
        {
            return "g";
        }
    }
    public class ExeSubCategorizeAFollowedByB : SimpleLogicLink, ISubCategory
    {
        public ExeSubCategorizeAFollowedByB()
        {
            Logic = this;
            SubCategory = this;
        }

        public override bool DoLogic(FileInfo file)
        {
            return (file.GetCategories().Contains("ab") && file.GetCategories().Contains("g"));
        }

        public string GetSubCategory()
        {
            return "ba" ;
        }
    }
    public class ExeSubCategorizeContainsC : ContainsCLink, ISubCategory
    {
        public ExeSubCategorizeContainsC()
        {
            Logic = this;
            SubCategory = this;
        }

        public string GetSubCategory()
        {
            return "c";
        }
    }
    public class ExeSubCategorizeContainsZ : SimpleLogicLink, ISubCategory
    {
        public ExeSubCategorizeContainsZ()
        {
            Logic = this;
            SubCategory = this;
        }

        public override bool DoLogic(FileInfo file)
        {
            return (file.GetCategories().Contains("g")) && ContainsZ(file.GetName());
        }

        public string GetSubCategory()
        {
            return "z";
        }    
    }
}
