using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BMWCompetencyTest.Helpers
{
    public class FolderLister
    {
        public static List<string> GetAllFiles(string rootFolder)
        {
            if (!Directory.Exists(rootFolder))
            {
                throw new Exception("Root folder does not exist");
            }

            string[] filesAndFolders = Directory.GetFiles(rootFolder, "*.*", SearchOption.TopDirectoryOnly);
            filesAndFolders = filesAndFolders.Concat(Directory.GetDirectories(rootFolder)).ToArray();

            return filesAndFolders.ToList();
        }
    }
}
