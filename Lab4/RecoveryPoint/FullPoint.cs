using System.IO;

namespace Backups
{
    class FullPoint : RecoveryPoint
    {
        public FullPoint(string fileFullPoint)
        {
            type_ = 1;
            name_ = fileFullPoint;
            if (!File.Exists(fileFullPoint))
                throw new System.Exception(fileFullPoint + " does not exist");


            string text = File.ReadAllText(fileFullPoint);
            int pos = text.IndexOf('\n');
            date_ = long.Parse(text.Substring(0, pos));
            text = text.Substring(pos + 1);

            while (text.Length > 0)
            {
                FileInfo fi = new FileInfo();
                
                pos = text.IndexOf((char)2);
                fi.name = text.Substring(0, pos);
                text = text.Substring(pos + 1);

                pos = text.IndexOf((char)3);
                fi.size = int.Parse(text.Substring(0, pos));
                text = text.Substring(pos + 1);

                fi.date = date_;

                files_.Add(fi.name, fi);
            }

        }
    }
}
