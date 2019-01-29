using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCategorizingProject
{
    public class FileTypeCategorizer
    {
        private ICategorizeFile _Categorizer;

        public FileTypeCategorizer(ICategorizeFile categorizer)
        {
            _Categorizer = categorizer;
        }

        public void Categorize(FileType file)
        {
            if (!_Categorizer.Equals(null) || !file.Equals(null))
            {
                _Categorizer.Categorize(file);
            }
            else
            {
                Console.WriteLine("\nThere is no fileType assigned to the Categorizer.");
            }
            
        }
    }

    public class ExeFileTypeCategorizer : ExeCategoryLogic, ICategorizeFile
    {
        public void Categorize(FileType file)
        {
            if (AFollowedByB(file.getName()))
            {
                categories.Add("ab");
                if (ContainsC(file.getName()))
                {
                    subCategories.Add("c");
                }
            }
            if (ContainsG(file.getName()))
            {
                categories.Add("g");
                if (AFollowedByB(file.getName()))
                {
                    subCategories.Add("ba");
                }
                if (ContainsZ(file.getName()))
                {
                    subCategories.Add("z");
                }
            }
            file.setCategories(categories);
            file.setSubCategories(subCategories);

        }
    }
    public class PdfFileTypeCategorizer : PdfCategoryLogic, ICategorizeFile
    {
        public void Categorize(FileType file)
        {
            if (BFollowedByA(file.getName()))
            {
                categories.Add("ab");
            }
            if (ContainsC(file.getName()))
            {
                categories.Add("c");
                if (AFollowedByB(file.getName()))
                {
                    subCategories.Add("ba");
                }
            }
            if (BFollowedByA(file.getName()) || ContainsC(file.getName()))
                if (ContainsZ(file.getName()))
                    subCategories.Add("z");

            file.setCategories(categories);
            file.setSubCategories(subCategories);
        }
    }
    public class DocFileTypeCategorizer : DocCategoryLogic, ICategorizeFile
    {
        public void Categorize(FileType file)
        {
            if (BFollowedByA(file.getName()))
            {
                categories.Add("cb");
                if (ContainsG(file.getName()))
                {
                    subCategories.Add("g");
                }
            }
            if (ContainsG(file.getName()))
            {
                categories.Add("g");
                if (GFollowedByB(file.getName()))
                {
                    subCategories.Add("gb");
                }
                if (ContainsZ(file.getName()))
                {
                    subCategories.Add("c");
                }
            }
            file.setCategories(categories);
            file.setSubCategories(subCategories);
        }
    }
}
