using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ProjectCleaner.CommonUtils
{
    public static class Helper
    {
        #region [ Public Properties ]

        public static Dictionary<string, bool> ExcludedFolders { get; set; }
        public static Dictionary<string, bool> ExcludedFiles { get; set; }

        public static List<string> SelectedFoldersInTreeView { get; set; }
        public static List<string> SelectedFilesInTreeView { get; set; }

        public static bool GotException { get; set; }
        public static bool FolderExist { get; set; }

        #endregion

        #region [ Public Helper Methods ]

        public static string GetAppDataXMLPath()
        {
            return AppDomain.CurrentDomain.BaseDirectory + AppConstants.APP_DATA_XML;
        }

        public static bool IsDirectoryExist(string sourceDirectory)
        {
            DirectoryInfo diSource = new DirectoryInfo(sourceDirectory);

            if (Directory.Exists(diSource.FullName) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void Copy(string sourceDirectory, string targetDirectory)
        {
            DirectoryInfo diSource = new DirectoryInfo(sourceDirectory);
            DirectoryInfo diTarget = new DirectoryInfo(targetDirectory);

            StartCopy(diSource, diTarget);
        }

        public static void StartCopy(DirectoryInfo source, DirectoryInfo target)
        {
            try
            {
                // Check if the target directory exists; if not, create it.
                if (Directory.Exists(target.FullName) == true)
                {
                    Directory.Delete(target.FullName, true);
                }

                Directory.CreateDirectory(target.FullName);

                // Copy each file into the new directory.
                foreach (FileInfo fi in source.GetFiles())
                {
                    if (!Helper.SelectedFilesInTreeView.Contains(fi.FullName) && !fi.Name.Contains(AppConstants.OUTPUT_DIRECTORY))
                    {
                        fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
                    }
                }

                // Copy each subdirectory using recursion.
                foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
                {
                    if (!diSourceSubDir.Name.Contains(AppConstants.OUTPUT_DIRECTORY) && !Helper.SelectedFoldersInTreeView.Contains(diSourceSubDir.FullName))
                    {
                        DirectoryInfo nextTargetSubDir = target.CreateSubdirectory(diSourceSubDir.Name);

                        StartCopy(diSourceSubDir, nextTargetSubDir);
                    }
                }
            }
            catch (Exception ex)
            {
                // Code to log exception
                Log.CaptureException(ex);
                Log.LogFileWrite();
            }
        }

        public static void ZipFiles(string path)
        {
            try
            {
                if (!File.Exists(path + AppConstants.OUTPUT_FILE_EXTENSION))
                {
                    ZipFile.CreateFromDirectory(path, path + AppConstants.OUTPUT_FILE_EXTENSION);
                }
                else
                {
                    string time = DateTime.Now.ToString("dd-MM-yyyy-hhmmss");
                    ZipFile.CreateFromDirectory(path, path + "-" + time + AppConstants.OUTPUT_FILE_EXTENSION);
                }
            }
            catch (Exception ex)
            {
                // code to log exception
                Log.CaptureException(ex);
                Log.LogFileWrite();
            }
        }

        #endregion
    }
}
