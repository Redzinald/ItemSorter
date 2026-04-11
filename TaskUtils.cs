using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SortItemsToFolders
{
    internal class TaskUtils
    {
        public static void SortFiles(string path, List<string> selectedCategories, Action<int, int>? onProgress = null)
        {
            string[] files = Directory.GetFiles(path);
            int totalFiles = files.Length;
            int currentFile = 0;
            foreach (string file in files)
            {
                string extention = Path.GetExtension(file).ToLower();
                string categoryName = extention switch
                {
                    ".jpg" or ".jpeg" or ".png" => "Images",
                    ".doc" or ".docx" or ".pdf" or ".csv" or ".ppt" or ".pptx" or ".txt" or ".xls" => "Documents",
                    ".mp3" or ".wav" or ".mov" => "Audio",
                    ".mp4" or ".avi" or ".mkv" => "Videos",
                    _ => "Others"
                };

                if (selectedCategories.Contains(categoryName))
                {
                    string destinationFolder = Path.Combine(path, categoryName);
                    
                    if (!Directory.Exists(destinationFolder))
                    {
                        Directory.CreateDirectory(destinationFolder);
                    }
                    
                    string destinationPath = Path.Combine(destinationFolder, Path.GetFileName(file));
                    if (!File.Exists(destinationPath))
                        File.Move(file, destinationPath);
                }
                currentFile++;
                onProgress?.Invoke(currentFile, totalFiles);
            }
        }
        public static void SortFilesWithRename(string path, List<string> selectedCategories, Action<int, int>? onProgress, TextBox textbox2, TextBox textbox3, TextBox textbox4, TextBox textbox5, TextBox textbox6)
        {
            string[] files = Directory.GetFiles(path);
            int totalFiles = files.Length;
            int currentFile = 0;
            foreach (string file in files)
            {
                string extention = Path.GetExtension(file).ToLower();
                (string originalCategory, string customCategoryName) = extention switch
                {
                    ".jpg" or ".jpeg" or ".png" => ("Images", string.IsNullOrWhiteSpace(textbox2.Text) ? "Images" : textbox2.Text),
                    ".doc" or ".docx" or ".pdf" or ".csv" or ".ppt" or ".pptx" or ".txt" or ".xls" => ("Documents", string.IsNullOrWhiteSpace(textbox3.Text) ? "Documents" : textbox3.Text),
                    ".mp3" or ".wav" or ".mov" => ("Audio", string.IsNullOrWhiteSpace(textbox6.Text) ? "Audio" : textbox6.Text),
                    ".mp4" or ".avi" or ".mkv" => ("Videos", string.IsNullOrWhiteSpace(textbox5.Text) ? "Videos" : textbox5.Text),
                    _ => ("Others", string.IsNullOrWhiteSpace(textbox4.Text) ? "Others" : textbox4.Text)
                };

                if (selectedCategories.Contains(originalCategory))
                {
             
                    string destinationFolder = Path.Combine(path, customCategoryName);

                    if (!Directory.Exists(destinationFolder))
                    {
                        Directory.CreateDirectory(destinationFolder);
                    }

                    string destinationPath = Path.Combine(destinationFolder, Path.GetFileName(file));
                    if (!File.Exists(destinationPath))
                        File.Move(file, destinationPath);
                }
                currentFile++;
                onProgress?.Invoke(currentFile, totalFiles);
            }
        }


        public static void ReverseSortFiles(string path, List<string> selectedCategories, Action<int, int>? onProgress = null)
        {
            string[] subdirectories = Directory.GetDirectories(path);
            int totalFiles = 0;
            List<string> foldersToProcess = new List<string>();

            foreach (string subdirectory in subdirectories)
            {
                string folderName = Path.GetFileName(subdirectory);

                if ((folderName == "Images" || folderName == "Documents" || folderName == "Audio" || folderName == "Videos" || folderName == "Others") && selectedCategories.Contains(folderName))
                {
                    foldersToProcess.Add(subdirectory);
                    totalFiles += Directory.GetFiles(subdirectory).Length;
                }
            }
            int currentFile = 0;
            if (totalFiles == 0)
            {
                onProgress?.Invoke(0, 0);
            }

            foreach (string folder in foldersToProcess)
            {
                currentFile = ReverseSort(folder, currentFile, totalFiles, onProgress);
            }
        }

        public static void ReverseSortFilesWithRename(string path, List<string> selectedCategories, Action<int, int>? onProgress, TextBox textbox2, TextBox textbox3, TextBox textbox4, TextBox textbox5, TextBox textbox6)
        {
            string[] subdirectories = Directory.GetDirectories(path);
            int totalFiles = 0;
            List<string> foldersToProcess = new List<string>();

            List<string> targetFolderNames = new List<string>();

            if (selectedCategories.Contains("Images"))
                targetFolderNames.Add(string.IsNullOrWhiteSpace(textbox2.Text) ? "Images" : textbox2.Text);
            
            if (selectedCategories.Contains("Documents"))
                targetFolderNames.Add(string.IsNullOrWhiteSpace(textbox3.Text) ? "Documents" : textbox3.Text);
            
            if (selectedCategories.Contains("Others"))
                targetFolderNames.Add(string.IsNullOrWhiteSpace(textbox4.Text) ? "Others" : textbox4.Text);
            
            if (selectedCategories.Contains("Videos"))
                targetFolderNames.Add(string.IsNullOrWhiteSpace(textbox5.Text) ? "Videos" : textbox5.Text);
            
            if (selectedCategories.Contains("Audio"))
                targetFolderNames.Add(string.IsNullOrWhiteSpace(textbox6.Text) ? "Audio" : textbox6.Text);

            foreach (string subdirectory in subdirectories)
            {
                string folderName = Path.GetFileName(subdirectory);
                if (targetFolderNames.Contains(folderName))
                {
                    foldersToProcess.Add(subdirectory);
                    totalFiles += Directory.GetFiles(subdirectory).Length;
                }
            }

            int currentFile = 0;
            if (totalFiles == 0)
            {
                onProgress?.Invoke(0, 0);
            }

            foreach (string folder in foldersToProcess)
            {
                currentFile = ReverseSort(folder, currentFile, totalFiles, onProgress);
            }
        }

        public static int ReverseSort(string path, int currentFile, int totalFiles, Action<int, int>? onProgress)
        { 
            string parentFolder = Directory.GetParent(path)?.FullName ?? string.Empty;
            string[] files = Directory.GetFiles(path);

            foreach (string file in files)
            {
                string fileName = Path.GetFileNameWithoutExtension(file);
                string extension = Path.GetExtension(file);

                string destinationPath = Path.Combine(parentFolder, fileName + extension);

                int counter = 1;

                while (File.Exists(destinationPath))
                {
                    destinationPath = Path.Combine(parentFolder, $"{fileName} ({counter}){extension}");
                    counter++;
                }

                File.Move(file, destinationPath);

                currentFile++;
                onProgress?.Invoke(currentFile, totalFiles);
            }

            Directory.Delete(path);
            
            return currentFile;
        }

        public static void SortCustomFiles(string path, string customFolderName, string[] customExtensions, Action<int, int> onProgress = null)
        {
            if (string.IsNullOrWhiteSpace(customFolderName) || customExtensions == null || customExtensions.Length == 0)
                return;

            string[] files = Directory.GetFiles(path);
            int totalFiles = files.Length;
            int currentFile = 0;

            var validExtensions = customExtensions.Select(e => e.StartsWith(".") ? e.ToLower() : "." + e.ToLower()).ToList();

            foreach (string file in files)
            {
                string extension = Path.GetExtension(file).ToLower();

                if (validExtensions.Contains(extension))
                {
                    string destinationFolder = Path.Combine(path, customFolderName);

                    if (!Directory.Exists(destinationFolder))
                    {
                        Directory.CreateDirectory(destinationFolder);
                    }

                    string destinationPath = Path.Combine(destinationFolder, Path.GetFileName(file));
                    if (!File.Exists(destinationPath))
                    {
                        File.Move(file, destinationPath);
                    }
                }

                currentFile++;
                if (onProgress != null)
                {
                    onProgress.Invoke(currentFile, totalFiles);
                }
            }
        }

        public static void ReverseSortCustomFiles(string path, string customFolderName, Action<int, int> onProgress = null)
        {
            if (string.IsNullOrWhiteSpace(customFolderName))
                return;

            string destinationFolder = Path.Combine(path, customFolderName);

            if (Directory.Exists(destinationFolder))
            {
                int totalFiles = Directory.GetFiles(destinationFolder).Length;

                if (totalFiles == 0)
                {
                    if (onProgress != null)
                    {
                        onProgress.Invoke(0, 0);
                    }
                    Directory.Delete(destinationFolder);
                    return;
                }
                ReverseSort(destinationFolder, 0, totalFiles, onProgress);
            }
            else
            {
                if (onProgress != null)
                {
                    onProgress.Invoke(0, 0);
                }
            }
        }
    }
}