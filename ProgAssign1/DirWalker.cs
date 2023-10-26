using System;
using System.Collections.Generic;
using System.IO;

namespace Assignment1
{
    public class DirWalker
    {
        public List<string> Walk(string path)
        {
            List<string> files = new List<string>();

            try
            {
                foreach (string file in Directory.GetFiles(path))
                {
                    files.Add(file);
                }

                foreach (string subDir in Directory.GetDirectories(path))
                {
                    files.AddRange(Walk(subDir));
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Unauthorized access to {path}: {ex.Message}");
            }
            catch (PathTooLongException ex)
            {
                Console.WriteLine($"Path too long while processing {path}: {ex.Message}");
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine($"Directory not found while processing {path}: {ex.Message}");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"File not found while processing {path}: {ex.Message}");
            }
            catch (DriveNotFoundException ex)
            {
                Console.WriteLine($"Drive not found while processing {path}: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while processing {path}: {ex.Message}");
            }

            return files;
        }
    }
}
