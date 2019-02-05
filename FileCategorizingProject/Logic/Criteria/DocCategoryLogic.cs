using FileCategorizingProject.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCategorizingProject
{
    public class DocCategorizeBFollowedByA : BFollowedByALink
    {
        public override void AddCategory(FileInfo file)
        {
            file.AddCategory("cb");
        }

        public override bool Logic(FileInfo file)
        {
            return BFollowedByA(file.GetName());
        }
    }
    public class DocCategorizeContainsG : ContainsGLink
    {
        public override void AddCategory(FileInfo file)
        {
            file.AddCategory("g");
        }

        public override bool Logic(FileInfo file)
        {
            return ContainsG(file.GetName());
        }

    }
    public class DocSubCategorizeGFollowedByB : GFollowedByBLink
    {
        public override void AddCategory(FileInfo file)
        {
            file.AddSubCategory("gb");
        }

        public override bool Logic(FileInfo file)
        {
            return GFollowedByB(file.GetName());
        }
    }
    public class DocSubCategorizeContainsG : SimpleLogicLink
    {
        public override void AddCategory(FileInfo file)
        {
            file.AddSubCategory("g");
        }

        public override bool Logic(FileInfo file)
        {
            return (file.GetCategories().Contains("g") && file.GetCategories().Contains("cb"));
        }
    }
    public class DocSubCategorizeContainsZ : ContainsZLink
    {
        public override void AddCategory(FileInfo file)
        {
            file.AddSubCategory("c");
        }

        public override bool Logic(FileInfo file)
        {
            return ((file.GetCategories().Contains("cb") || (file.GetCategories().Contains("g")) && ContainsZ(file.GetName())));
        }

    }
}
