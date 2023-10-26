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
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine($"Unauthorized access to ");
            }
            catch (PathTooLongException)
            {
                Console.WriteLine($"Path too long while processing ");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine($"Directory not found while processing");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"File not found while processing ");
            }
            catch (DriveNotFoundException)
            {
                Console.WriteLine($"Drive not found while processing ");
            }
            catch (Exception)
            {
                Console.WriteLine($"Error while processing ");
            }

            return files;
        }
    }
}
