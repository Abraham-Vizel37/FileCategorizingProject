using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCategorizingProject
{
    public interface ICategorize
    {
        void Categorize(string fileName, List<string> categories, List<string> subCategories);
    }

}
