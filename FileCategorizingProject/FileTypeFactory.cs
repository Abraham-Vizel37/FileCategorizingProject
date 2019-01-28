using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCategorizingProject
{
    class FileTypeFactory
    {
        private string _Name;
        private string _Extension;

        public FileTypeFactory(string name)
        {
            _Name = FindFileName(name);
            _Extension = FindExtention(name);
        }

        public FileType getFileType()
        {
            switch (_Extension)
            {
                case ".exe":
                case ".txt":
                    return new ExeFileType(_Name, _Extension);

                case ".pdf":
                case ".bmp":
                    return new PdfFileType(_Name, _Extension);

                case ".docx":
                    return new DocFileType(_Name, _Extension);
                default:
                    return null;
            }
        }

        private string FindExtention(string fileName)
        {
            return fileName.Substring(fileName.IndexOf('.'));
        }

        private string FindFileName(string fileName)
        {
            return fileName.Substring(0, fileName.IndexOf('.'));
        }
    }
}
