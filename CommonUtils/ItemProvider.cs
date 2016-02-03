using ProjectCleaner.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ProjectCleaner.CommonUtils
{
    public class ItemProvider
    {
        #region [ Static Provider Methods]

        public static List<Item> GetItems(string path, bool isParentChecked)
        {
            var items = new List<Item>();

            if (Directory.Exists(path))
            {
                var dirInfo = new DirectoryInfo(path);

                try
                {
                    foreach (var directory in dirInfo.GetDirectories())
                    {
                        if (directory != null)
                        {
                            bool dirChecked = false;

                            if (isParentChecked == true)
                            {
                                dirChecked = true;
                            }

                            if (Helper.ExcludedFolders.ContainsKey(directory.Name))
                            {
                                bool value = false;
                                Helper.ExcludedFolders.TryGetValue(directory.Name, out value);
                                dirChecked = value;
                            }

                            var item = new DirectoryItem
                            {
                                Name = directory.Name,
                                Path = directory.FullName,
                                Selected = false,
                                Items = GetItems(directory.FullName, dirChecked)
                            };

                            item.Selected = dirChecked;

                            items.Add(item);
                        }
                    }

                    foreach (var file in dirInfo.GetFiles())
                    {
                        if (file != null)
                        {
                            var item = new FileItem
                            {
                                Name = file.Name,
                                Selected = false,
                                Path = file.FullName
                            };

                            if (isParentChecked == true)
                            {
                                item.Selected = true;
                            }

                            if (Helper.ExcludedFiles.ContainsKey(file.Extension))
                            {
                                bool value = false;
                                Helper.ExcludedFiles.TryGetValue(file.Extension.ToLower(), out value);
                                item.Selected = value;
                            }

                            items.Add(item);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Helper.GotException = true;
                    Log.CaptureException(ex);
                }

                Helper.FolderExist = true;
            }
            else
            {
                Helper.FolderExist = false;
            }

            return items;
        }

        #endregion
    }
}
