using System.Collections.Generic;
using System.IO;

namespace Backups
{
    class RecoveryPoint
    {
        protected Dictionary<string, FileInfo> files_ = new Dictionary<string, FileInfo>();
        protected RecoveryPoint depend_ = null;
        protected long date_ = 0;
        protected int type_ = 0;
        protected string name_ = "";
        public List<string> Files()
        {
            List<string> result = new List<string>();
            foreach (var file in files_.Keys)
            {
                result.Add(file);
            }
            return result;
        }

        public RecoveryPoint GetDepend()
        {
            return depend_;
        }
        public FileInfo GetFile(string filename)
        {
            return files_[filename];
        }

        public long GetDate()
        {
            return date_;
        }

        public int GetType()
        {
            return type_;
        }

        public string GetName()
        {
            return name_;
        }

        public void ToFull()
        {
            string FileName = name_;
            File.Delete(FileName);
            string text = GetDate() + "\n";

            foreach (var file in Files())
            {
                text += file + (char)2;
                text += GetFile(file).size.ToString() + (char)3;
            }
            type_ = 1;
            File.WriteAllText(FileName, text);
        }
    }
}
