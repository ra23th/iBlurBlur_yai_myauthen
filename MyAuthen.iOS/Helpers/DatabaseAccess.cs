using System;
using System.IO;
using Foundation;

namespace MyAuthen.iOS.Helpers
{
    public class DatabaseAccess
    {
        public static string GetDatabasePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string dbPath = Path.Combine(path, "..", "Documents", filename);
            if (!File.Exists(dbPath))
            {
                var bundlePath = NSBundle.MainBundle.PathForResource(filename, null);
                File.Copy(bundlePath, dbPath);
            }
            Console.WriteLine(dbPath);
            return dbPath;
        }
    }
}
