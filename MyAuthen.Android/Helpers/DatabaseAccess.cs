using System;
using System.IO;
using Android.App;
using Android.Util;

namespace MyAuthen.Droid.Helpers
{
    public class DatabaseAccess
    {

        public static string GetDatabasePath(string filename)
        {

            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            string dbPath = Path.Combine(path, filename);

            try
            {
                if (!File.Exists(dbPath))
                {
                    using (var br = new BinaryReader(Application.Context.Assets.Open(filename)))
                    {
                        using (var bw = new BinaryWriter(new FileStream(dbPath, FileMode.Create)))
                        {
                            byte[] buffer = new byte[2048];
                            int length = 0;
                            while ((length = br.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                bw.Write(buffer, 0, length);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Log.Info("codemobiles", e.Message);
            }

            return Path.Combine(path, filename);
        }


    }
}
