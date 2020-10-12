using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace programme_mailleux
{
    class Program
    {
        static void Main(string[] args)
        {

            string mainPath = args[0];
            string[] subdirectories = Directory.GetDirectories(mainPath);

            foreach(string directory in subdirectories)
            {
                var dir = new DirectoryInfo(directory);
                string[] files = Directory.GetFiles(directory);

                var dirName = dir.Name;
                string mainPhoto = "";
                string picto = "";
                List<String> otherPhotos = new List<String>{};
                string otherPhotosConc = "";

                foreach(string fileName in files){
                    // main photo 
                    if (fileName.EndsWith("photo-00.jpg"))
                    {
                        mainPhoto = $"{Path.GetFileNameWithoutExtension(fileName)}.jpeg";
                    }

                    // picto 
                    else if (fileName.EndsWith("picto.jpg"))
                    {
                        picto = $"{Path.GetFileNameWithoutExtension(fileName)}.jpeg";
                    }

                    // autres 
                    else if (fileName.EndsWith(".jpg"))
                    {
                        otherPhotos.Add($"{Path.GetFileNameWithoutExtension(fileName)}.jpeg");
                    } 
                }
                otherPhotosConc = String.Join(";", otherPhotos);

                using (System.IO.StreamWriter file = new System.IO.StreamWriter($@"{mainPath}/liens_photos.txt", true))
                {
                    file.WriteLine(dirName);
                    file.WriteLine(mainPhoto);
                    file.WriteLine(picto);
                    file.WriteLine(otherPhotosConc);
                    file.WriteLine("");
                    file.WriteLine("");
                }
            }
        }
    }
}
