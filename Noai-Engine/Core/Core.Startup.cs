using System;
using System.Collections.Generic;
using System.Text;


namespace Core.Startup
{
     class CoreStartup
    {
        public void ProjectFolderInit()
        {
            string DocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string TargetFolderPath = Path.Combine(DocumentsPath, "Noai Projects");

            try 

            {
                Directory.CreateDirectory(TargetFolderPath);

                System.Diagnostics.Debug.WriteLine($"Folder ready at: {TargetFolderPath}");
            }

            catch (Exception ex)

            {
                System.Diagnostics.Debug.WriteLine($"Failed to create folder: {ex.Message}");
            }
        }

        //Find Projects by name in Noai Projects Folder
        public List<string> Projects_NameOnly()
        {
            //getpath
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string targetFolderPath = Path.Combine(documentsPath, "Noai Projects");

            List<string> filePaths = new List<string>();

            // Directory Existence check
            if (Directory.Exists(targetFolderPath))
            {
                try
                {
                    // subfolder scan
                    var files = Directory.EnumerateFiles(
                        targetFolderPath,
                        "*.nproject",
                        SearchOption.AllDirectories
                    );

                    filePaths.AddRange(files);

                    Console.WriteLine(files);
                }
                catch (UnauthorizedAccessException ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Permission denied: {ex.Message}");
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error scanning folder: {ex.Message}");
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("The 'Noai Projects' folder does not exist yet.");
            }

            return filePaths;
        }

        

    }
}
