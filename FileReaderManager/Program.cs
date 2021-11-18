using System;
using System.IO;

namespace FileReaderManager
{
    class Program
    {
        private static int total = 0;
        private static readonly string workingDirectory = Environment.CurrentDirectory;
        private static readonly string projDir = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

        static void Main(string[] args)
        {
            ReadFile("A.txt");
            Console.WriteLine("Total is " + total.ToString());
        }

        static void ReadFile(string fileName)
        {
            try
            {
                string path = Path.Combine(projDir, @"Data", fileName);
                using (var sr = new StreamReader(path))
                {
                    String line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] data = line.Split(',');
                        for (int i = 0; i < data.Length; i++)
                        {
                            var currentElement = data[i];
                            if (int.TryParse(data[i], out int value))
                            {
                                total += value;
                            }
                            else
                            {
                                ReadFile(currentElement);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
