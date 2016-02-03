using ProjectCleaner.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ProjectCleaner.CommonUtils
{
    public static class VSUnbind
    {
        #region [ Public Methods ]

        public static void Unbind(string path)
        {
            try
            {
                string errorMessage = string.Empty;

                var sccFilesToDelete = new List<string>();
                var projFilesToModify = new List<string>();
                var slnFilesToModify = new List<string>();

                if (path.Length < 1)
                {
                    errorMessage += "ERROR: No folder specified";
                    errorMessage += "SYNTAX: VSUnbindSourceControl <folder>";
                    errorMessage += "Stopping.";
                    return;
                }

                string folder = path.Trim();
                if (folder.Length < 1)
                {
                    errorMessage += "ERROR: empty folder name";
                    errorMessage += "Stopping.";
                    return;
                }

                if (!Directory.Exists(folder))
                {
                    errorMessage += "ERROR: Folder does not exist";
                    errorMessage += "Stopping.";
                    return;
                }

                var files = new List<string>(Directory.GetFiles(folder, "*.*", SearchOption.AllDirectories));

                foreach (var filename in files)
                {
                    string normalized_filename = filename.ToLower();
                    if (normalized_filename.Contains(".") && normalized_filename.EndsWith("proj") && !normalized_filename.EndsWith("vdproj"))
                    {
                        projFilesToModify.Add(filename);
                    }
                    else if (normalized_filename.EndsWith(".sln"))
                    {
                        slnFilesToModify.Add(filename);
                    }
                    else if (normalized_filename.EndsWith(".vssscc") || normalized_filename.EndsWith(".vspscc"))
                    {
                        sccFilesToDelete.Add(filename);
                    }
                    else
                    {
                        // do nothing
                    }
                }

                if ((projFilesToModify.Count + slnFilesToModify.Count + sccFilesToDelete.Count < 1))
                {
                    errorMessage += "No files to modify or delete. Exiting.";
                    return;
                }

                foreach (var file in slnFilesToModify)
                {
                    ModifySolutionFile(file);
                }

                foreach (var file in projFilesToModify)
                {
                    ModifyProjectFile(file);
                }

                foreach (var file in sccFilesToDelete)
                {
                    DeleteFile(file);
                }

                if (!errorMessage.Equals(string.Empty))
                {
                    DialogBox.ShowError(errorMessage);
                    errorMessage = string.Empty;
                }
            }
            catch (Exception ex)
            {
                Log.CaptureException(ex);
            }
        }

        public static void ModifySolutionFile(string filename)
        {
            try
            {

                // Remove the read-only flag
                var original_attr = File.GetAttributes(filename);
                File.SetAttributes(filename, FileAttributes.Normal);

                var output_lines = new List<string>();

                bool in_sourcecontrol_section = false;
                var lines = File.ReadAllLines(filename);
                foreach (string line in lines)
                {
                    var trimmedLine = line.Trim();

                    // lines can contain separators which interferes with the regex
                    // escape them to prevent regex from having problems
                    trimmedLine = Uri.EscapeDataString(trimmedLine);


                    if (trimmedLine.StartsWith("GlobalSection(SourceCodeControl)")
                        || trimmedLine.StartsWith("GlobalSection(TeamFoundationVersionControl)")
                        || System.Text.RegularExpressions.Regex.IsMatch(trimmedLine, "GlobalSection(.*Version.*Control)", System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                    {
                        // this means we are starting a Source Control Section
                        // do not copy the line to output
                        in_sourcecontrol_section = true;
                    }
                    else if (in_sourcecontrol_section && trimmedLine.StartsWith("EndGlobalSection"))
                    {
                        // This means we were Source Control section and now see the ending marker
                        // do not copy the line containing the ending marker 
                        in_sourcecontrol_section = false;
                    }
                    else if (trimmedLine.StartsWith("Scc"))
                    {
                        // These lines should be ignored completely no matter where they are seen
                    }
                    else
                    {
                        // No handle every other line
                        // Basically as long as we are not in a source control section
                        // then that line can be copied to output

                        if (!in_sourcecontrol_section)
                        {
                            output_lines.Add(line);
                        }
                    }
                }

                // Write the file back out
                File.WriteAllLines(filename, output_lines);

                // Restore the original file attributes
                File.SetAttributes(filename, original_attr);
            }
            catch (Exception ex)
            {
                Log.CaptureException(ex);
            }
        }

        public static void ModifyProjectFile(string filename)
        {
            try
            {

                // Load the Project file
                var doc = System.Xml.Linq.XDocument.Load(filename);

                // Modify the Source Control Elements
                RemoveSCCElementsAttributes(doc.Root);

                // Remove the read-only flag
                var original_attr = File.GetAttributes(filename);
                File.SetAttributes(filename, FileAttributes.Normal);

                // Write out the XML
                using (var writer = new System.Xml.XmlTextWriter(filename, Encoding.UTF8))
                {
                    writer.Formatting = System.Xml.Formatting.Indented;
                    doc.Save(writer);
                    writer.Close();
                }

                // Restore the original file attributes
                File.SetAttributes(filename, original_attr);
            }
            catch (Exception ex)
            {
                Log.CaptureException(ex);
            }
        }


        public static void DeleteFile(string filename)
        {
            try
            {
                File.SetAttributes(filename, FileAttributes.Normal);
                File.Delete(filename);
            }
            catch (Exception ex)
            {
                Log.CaptureException(ex);
            }
        }

        #endregion

        #region [ Private Methods ]

        private static void RemoveSCCElementsAttributes(System.Xml.Linq.XElement el)
        {
            try
            {
                el.Elements().ToList().RemoveAll(x => x.Name.LocalName.StartsWith("Scc"));

                el.Attributes().ToList().RemoveAll(x => x.Name.LocalName.StartsWith("Scc"));

                foreach (var child in el.Elements())
                {
                    RemoveSCCElementsAttributes(child);
                }
            }
            catch (Exception ex)
            {
                Log.CaptureException(ex);
            }
        }

        #endregion
    }
}
