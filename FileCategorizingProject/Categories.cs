using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCategorizingProject
{
    public class CategoryCriteria
    {
        public bool AFollowedByB( string fileName)
        {
            return FollowedBy(fileName, 'a', 'b');
        }

        public bool BFollowedByA(string fileName)
        {
            return FollowedBy(fileName, 'b', 'a');
        }

        public bool GFollowedByB(string fileName)
        {
            return FollowedBy(fileName, 'g', 'b');
        }

        public bool ContainsC(string fileName)
        {
            return Contains(fileName, 'c');
        }

        public bool ContainsG(string fileName)
        {
            return Contains(fileName, 'g');
        }

        public bool ContainsZ(string fileName)
        {
            return Contains(fileName, 'z');
        }

        public bool Contains(string fileName, char first)
        {
            return fileName.Contains(first);
        }

        public bool FollowedBy(string fileName, char first, char second)
        {
            if (fileName.Contains(first))
            {
                return fileName.Substring(fileName.IndexOf(first)).Contains(second);
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
