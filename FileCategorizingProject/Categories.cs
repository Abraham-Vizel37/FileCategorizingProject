using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCategorizingProject
{
        public class CategoryCriteria
    {
        public bool AFollowedByB(string FileName)
        {
            return FollowedBy(FileName, 'a', 'b');
        }

        public bool BFollowedByA(string FileName)
        {
            return FollowedBy(FileName, 'b', 'a');
        }

        public bool GFollowedByB(string FileName)
        {
            return FollowedBy(FileName, 'g', 'b');
        }

        public bool ContainsC(string FileName)
        {
            return Contains(FileName, 'c');
        }

        public bool ContainsG(string FileName)
        {
            return Contains(FileName, 'g');
        }

        public bool ContainsZ(string FileName)
        {
            return Contains(FileName, 'z');
        }

        public bool Contains(string FileName, char first)
        {
            return FileName.Contains(first);
        }

        public bool FollowedBy(string FileName, char first, char second)
        {
            if (FileName.Contains(first))
            {
                return FileName.Substring(FileName.IndexOf(first)).Contains(second);
            }
            return false;
        }
    }

    public class ExeCategories : CategoryCriteria, ICategorize
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
    public class PdfCategories : CategoryCriteria, ICategorize
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
    public class DocCategories : CategoryCriteria, ICategorize
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
