using System.IO;

namespace Backups
{
    class IncrementPoint : RecoveryPoint
    {
        public IncrementPoint(string fileIncrementPoint)
        {
            type_ = 2;
            name_ = fileIncrementPoint;
            if (!File.Exists(fileIncrementPoint))
                throw new System.Exception(fileIncrementPoint + " does not exist");

            string text = File.ReadAllText(fileIncrementPoint);
            int pos = text.IndexOf('\n');
            if (pos < 1)
                throw new PointException();
            date_ = long.Parse(text.Substring(0, pos));
            text = text.Substring(pos + 1);

            pos = text.IndexOf('\n');
            if (pos < 1)
                throw new PointException();

            if (text[0] == '1') // FullType
            {
                depend_ = new FullPoint(text.Substring(1, pos - 1));
                text = text.Substring(pos + 1);
            }
            else if (text[0] == '2') // IncrementType
            {
                depend_ = new IncrementPoint(text.Substring(1, pos - 1));
                text = text.Substring(pos + 1);
            }
            else
                throw new PointException();

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
