using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCategorizingProject.Logic
{
    public abstract class SimpleLogicLink : CategorizingLogicLinks
    {
        public bool Contains(string fileName, char first) => fileName.Contains(first);
        public bool FollowedBy(string fileName, char first, char second) => fileName.Contains(first) ? fileName.Substring(fileName.IndexOf(first)).Contains(second) : false;
    }

    public abstract class AFollowedByBLink : SimpleLogicLink
    {
        public bool AFollowedByB(string fileName) => FollowedBy(fileName, 'a', 'b');
    }
    public abstract class BFollowedByALink : SimpleLogicLink
    {
        public bool BFollowedByA(string fileName) => FollowedBy(fileName, 'b', 'a');
    }
    public abstract class GFollowedByBLink : SimpleLogicLink
    {
        public bool GFollowedByB(string fileName) => FollowedBy(fileName, 'g', 'b');
    }
    public abstract class ContainsCLink : SimpleLogicLink
    {
        public bool ContainsC(string fileName) => Contains(fileName, 'c');
    }
    public abstract class ContainsGLink : SimpleLogicLink
    {
        public bool ContainsG(string fileName) => Contains(fileName, 'g');
    }
    public abstract class ContainsZLink : SimpleLogicLink
    {
        public bool ContainsZ(string fileName) => Contains(fileName, 'z');
    }
}
