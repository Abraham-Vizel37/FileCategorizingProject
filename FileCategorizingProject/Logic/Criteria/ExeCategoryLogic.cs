using FileCategorizingProject.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCategorizingProject
{
    public class ExeCategorizeAFollowedByB : AFollowedByBLink
    {
        public override void AddCategory(FileInfo file)
        {
            file.AddCategory("ab");
        }

        public override bool Logic(FileInfo file)
        {
            return AFollowedByB(file.GetName());
        }
    }
    public class ExeCategorizeContainsG : ContainsGLink
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
    public class ExeSubCategorizeAFollowedByB : SimpleLogicLink
    {
        public override void AddCategory(FileInfo file)
        {
            file.AddSubCategory("ba");
        }

        public override bool Logic(FileInfo file)
        {
            return (file.GetCategories().Contains("ab") && file.GetCategories().Contains("g"));
        }
    }
    public class ExeSubCategorizeContainsC : ContainsCLink
    {
        public override void AddCategory(FileInfo file)
        {
            file.AddSubCategory("c");
        }

        public override bool Logic(FileInfo file)
        {
            return ContainsC(file.GetName());
        }
    }
    public class ExeSubCategorizeContainsZ : ContainsZLink
    {
        public override void AddCategory(FileInfo file)
        {
            file.AddSubCategory("z");
        }

        public override bool Logic(FileInfo file)
        {
            return (file.GetCategories().Contains("g")) && ContainsZ(file.GetName());
        }
    }
}
