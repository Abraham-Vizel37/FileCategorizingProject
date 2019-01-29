using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCategorizingProject
{
    public interface ICategorizeFile
    {
        void Categorize(FileType file);
    }

    public interface ICategorizeLogicChain
    {
        List<string> ComputeLogic(string fileName);
    }

}
