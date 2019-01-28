using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCategorizingProject
{

    public abstract class CoreCategoryLogic
    {
        public bool ContainsZ(string fileName) => Contains(fileName, 'z');
        public bool Contains(string fileName, char first) => fileName.Contains(first);
        public bool FollowedBy(string fileName, char first, char second) => fileName.Contains(first) ? fileName.Substring(fileName.IndexOf(first)).Contains(second) : false;
    }
    public abstract class ExeCategoryLogic : CoreCategoryLogic
    {
        public bool AFollowedByB(string fileName) => FollowedBy(fileName, 'a', 'b');
        public bool ContainsC(string fileName) => Contains(fileName, 'c');
        public bool ContainsG(string fileName) => Contains(fileName, 'g');
    }
    public abstract class PdfCategoryLogic : CoreCategoryLogic
    {
        public bool AFollowedByB(string fileName) => FollowedBy(fileName, 'a', 'b');
        public bool BFollowedByA(string fileName) => FollowedBy(fileName, 'b', 'a');
        public bool ContainsC(string fileName) => Contains(fileName, 'c');
    }
    public abstract class DocCategoryLogic : CoreCategoryLogic
    {
        public bool BFollowedByA(string fileName) => FollowedBy(fileName, 'b', 'a');
        public bool GFollowedByB(string fileName) => FollowedBy(fileName, 'g', 'b');
        public bool ContainsG(string fileName) => Contains(fileName, 'g');
    }


    public class ExeFileTypeCategorizer : ExeCategoryLogic, ICategorize
    {
        public void Categorize(string fileName, List<string> categories, List<string> subCategories)
        {
            if (AFollowedByB(fileName))
            {
                categories.Add("ab");
                if (ContainsC(fileName))
                {
                    subCategories.Add("c");
                }
            }
            if (ContainsG(fileName))
            {
                categories.Add("g");
                if (AFollowedByB(fileName))
                {
                    subCategories.Add("ba");
                }
                if (ContainsZ(fileName))
                {
                    subCategories.Add("z");
                }
            }
        }
    }
    public class PdfFileTypeCategorizer : PdfCategoryLogic, ICategorize
    {
        public void Categorize(string fileName, List<string> categories, List<string> subCategories)
        {
            if (BFollowedByA(fileName))
            {
                categories.Add("ab");
            }
            if (ContainsC(fileName))
            {
                categories.Add("c");
                if (AFollowedByB(fileName))
                {
                    subCategories.Add("ba");
                }
            }
            if (BFollowedByA(fileName) || ContainsC(fileName))
                if (ContainsZ(fileName))
                    subCategories.Add("z");
        }
    }
    public class DocFileTypeCategorizer : DocCategoryLogic, ICategorize
    {
        public void Categorize(string fileName, List<string> categories, List<string> subCategories)
        {
            if (BFollowedByA(fileName))
            {
                categories.Add("cb");
                if (ContainsG(fileName))
                {
                    subCategories.Add("g");
                }
            }
            if (ContainsG(fileName))
            {
                categories.Add("g");
                if (GFollowedByB(fileName))
                {
                    subCategories.Add("gb");
                }
                if (ContainsZ(fileName))
                {
                    subCategories.Add("c");
                }
            }
        }
    }
}
