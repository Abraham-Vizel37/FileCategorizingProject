using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCategorizingProject
{
    class FileInfoFactory
    {
        private string _name;
        private string _extension;

        public FileInfo GetFileInfo(string name)
        {
            _name = FindFileName(name);
            _extension = FindExtention(name);
            return new FileInfo(_name, _extension);
        }

        private string FindExtention(string fileName)
        {
            return fileName.Substring(fileName.LastIndexOf('.'));
        }

        private string FindFileName(string fileName)
        {
            return fileName.Substring(0, fileName.LastIndexOf('.'));
        }
    }
}
