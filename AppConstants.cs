using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectCleaner.CommonUtils
{
    public static class AppConstants
    {
        public const string MISSING_NODES = "Folders or FileExtensions node is missing in the AppData.xml file. Please re-check the file (or) delete the file and re-run the application.";

        public const string OUTPUT_DIRECTORY = "APC_";

        public const string ANOTHER_INSTANCE_RUNNING = "Another instance of Avanade projet cleaner is already running";

        public const string LOGFILENAME = "APC_ErrorLog.txt";
        public const string EXPLORER = "explorer.exe";

        public const string INFO = "Info";
        public const string ERROR_INFO = "Error info";
        public const string LOG_WRITTEN = "Log has been written at User's temp folder";
        public const string LOG_ERROR = "Could not Write log file in Temp Folder";

        public const string APP_DATA_XML = "AppData.xml";
        public const string OUTPUT_FILE_EXTENSION = ".zip";

        public const string TRUE = "true";

        public const string SOURCE_CONTROL_BINDINGS = "Source Control Bindings";

        public const string PLEASE_WAIT_TREE = "Please wait while the tree is loaded...";
        public const string PLEASE_WAIT_FOLDER = "Please wait while the folder is cleaned..";
        public const string PLEASE_WAIT_FILES = "Please wait while the files are compressed..";
        public const string DIR_ERROR = "Selected directory does not exist (or) there is some error while trying to access this directory. Please try a different directory.";
        public const string NO_FOLDER_NAMES = "No Folder Names are specified in the AppData.xml file.";
        public const string NO_FILE_EXTENSIONS = "No File Extensions specified in the AppData.xml file.";
        public const string CLEAN_SUCCESS = "Directory cleaned successfully.. Do you want to open the output folder?";
        public const string NO_SOURCE_DIR = "Source directory does not exist. Please choose another directory..!!";
        public const string SELECT_FOLDER = "Please select a folder for cleaning...";

        public static class MessageTypes
        {
            public const string Error = "Error";
            public const string Information = "Information";
            public const string Warning = "Warning";
            public const string OK = "OK";
        }

        public static class AppDataNodesAttributes
        {
            public const string Folders = "Folders";
            public const string FileExtensions = "FileExtensions";
            public const string Name = "name";
            public const string Extension = "extension";
            public const string Checked = "checked";
        }
    }
}
