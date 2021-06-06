using System;
using System.IO;
using System.Collections.Generic;

namespace Backups
{
    class Backup
    {
        private static string name_;
        Dictionary<string, RecoveryPoint> points_ = new Dictionary<string, RecoveryPoint>();
        Dictionary<string, RecoveryPoint> files_ = new Dictionary<string, RecoveryPoint>();
        private MainCleaner cleaner_;
        public Backup(string name, MainCleaner cl = null)
        {
            if (!Directory.Exists(name))
                Directory.CreateDirectory(name);
            name_ = name;
            cleaner_ = cl;
        }
        public void AddFullPoint(string name, List<string> files)
        {
            string FileName = name_ + "/" + name + ".mrp";
            if (File.Exists(FileName))
                throw new Exception(name + ": this point already exist");

            DateTime date = DateTime.Now;
            string text = date.Ticks + "\n";

            foreach (var file in files)
            {
                if (!File.Exists(file))
                    throw new Exception(file + ": this file does not exist");

                text += file + (char)2;
                text += File.ReadAllText(file).Length.ToString() + (char)3;
            }

            File.WriteAllText(FileName, text);
            points_.Add(name, new FullPoint(FileName));
            Clean();
            FileUpdate();
        }

        public void AddIncrementPoint(string name, RecoveryPoint point, List<string> files)
        {
            string FileName = name_ + "/" + name + ".mrp";
            if (File.Exists(FileName))
                throw new Exception(name + ": this point already exist");
            
            DateTime date = DateTime.Now;
            string text = date.Ticks + "\n";

            text += point.GetType() + point.GetName() + '\n';

            List<string> oldFiles = point.Files();

            foreach (var file in files)
            {
                if (!File.Exists(file))
                    throw new Exception(file + ": this file does not exist");

                text += file + (char)2;
                text += File.ReadAllText(file).Length.ToString() + (char)3;
            }

            File.WriteAllText(FileName, text);
            points_.Add(name, new IncrementPoint(FileName));
            Clean();
            FileUpdate();
        }
        private void FileUpdate()
        {
            files_ = new Dictionary<string, RecoveryPoint>();
            foreach (var point in points_.Values)
            {
                List<string> thisFile = point.Files();

                foreach (var fi in thisFile)
                {
                    if (files_.ContainsKey(fi))
                    {
                        if (files_[fi].GetDate() < point.GetDate())//           Если дата уже созданного файла меньше, то обнавляем инфу о файле
                            files_[fi] = point;
                    }
                    else
                    {
                        files_[fi] = point;
                    }
                }
            }
        }
        public List<string> GetFiles()
        {
            List<string> result = new List<string>();

            foreach (var file in files_.Keys)
            {
                result.Add(file);
            }

            return result;
        }

        public FileInfo GetFile(string name)
        {
            if (!files_.ContainsKey(name))
                throw new Exception(name_ + ": not contais a file " + name);
            return files_[name].GetFile(name);
        }

        public List<string> GetPoints()
        {
            List<string> result = new List<string>();

            foreach (var file in points_.Keys)
            {
                result.Add(file);
            }

            return result;
        }

        public RecoveryPoint GetPoint(string name)
        {
            if (!points_.ContainsKey(name))
                throw new Exception(name_ + ": not contais a point " + name);
            return points_[name];
        }

        private void Clean()
        {
            foreach (var point in points_.Values)
            {
                cleaner_.Correct(point);
            }
        }
    }
}
