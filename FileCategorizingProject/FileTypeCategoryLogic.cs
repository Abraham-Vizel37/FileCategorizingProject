using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCategorizingProject
{
    public abstract class CoreCategoryLogic
    {
        public List<string> categories = new List<string> { };
        public List<string> subCategories = new List<string> { };
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


}
