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
    public class ExeSubCategorizeAFollowedByB : LogicClass, ISubCategory
    {
        public ExeSubCategorizeAFollowedByB()
        {
            Logic = this;
            SubCategory = this;
        }

        public override bool DoLogic(FileInfo file)
        {
            return (file.getCategories().Contains("ab") && file.getCategories().Contains("g"));
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
    public class ExeSubCategorizeContainsZ : LogicClass, ISubCategory
    {
        public ExeSubCategorizeContainsZ()
        {
            Logic = this;
            SubCategory = this;
        }

        public override bool DoLogic(FileInfo file)
        {
            return (file.getCategories().Contains("g") && ContainsZ(file.getName()));
        }

        public string GetSubCategory()
        {
            return "z";
        }

    }
}
