using System;
using System.IO;

namespace deSnap
{
    internal class Program
    {
        // 1. Create a simple configuration class for the games
        class GameProfile
        {
            public string FolderPath { get; set; }
            public string FilePrefix { get; set; }
            public string OutputPrefix { get; set; }
        }

        static void Main(string[] args)
        {
            string docsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string desktopDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "deSnap");

            // 2. Define the games using an array so it's trivial to add more later
            GameProfile[] games = new GameProfile[]
            {
                new GameProfile {
                    FolderPath = Path.Combine(docsPath, @"Rockstar Games\GTA V\Profiles"),
                    FilePrefix = "PGTA5*",
                    OutputPrefix = "GTAV"
                },
                new GameProfile {
                    FolderPath = Path.Combine(docsPath, @"Rockstar Games\Red Dead Redemption 2\Profiles"),
                    FilePrefix = "PRDR*",
                    OutputPrefix = "RDR2"
                },
                new GameProfile {
                    FolderPath = Path.Combine(docsPath, @"Rockstar Games\GTAV Enhanced\Profiles"),
                    FilePrefix = "PGTA5*",
                    OutputPrefix = "GTAVe"
                }
            };

            Directory.CreateDirectory(desktopDir);
            int totalConverted = 0;

            foreach (var game in games)
            {
                if (!Directory.Exists(game.FolderPath)) continue;

                // 3. Iterate through ALL profile folders (in case the user has multiple Rockstar accounts)
                foreach (string profileDir in Directory.GetDirectories(game.FolderPath))
                {
                    string[] taskFiles = Directory.GetFiles(profileDir, game.FilePrefix);

                    foreach (string file in taskFiles)
                    {
                        byte[] fileBytes = File.ReadAllBytes(file);

                        // 4. Find where the actual JPEG data begins
                        int jpegStart = FindJpegHeader(fileBytes);

                        if (jpegStart != -1)
                        {
                            // 5. Dynamically calculate the exact length of the image
                            int imageLength = fileBytes.Length - jpegStart;
                            byte[] outputBytes = new byte[imageLength];
                            Array.Copy(fileBytes, jpegStart, outputBytes, 0, imageLength);

                            string fileName = $"{game.OutputPrefix}_Snap_{totalConverted}.jpeg";
                            string outputPath = Path.Combine(desktopDir, fileName);

                            File.WriteAllBytes(outputPath, outputBytes);
                            totalConverted++;
                        }
                    }
                }
            }

            Console.WriteLine($"Successfully converted {totalConverted} images! Your images are in a folder on your Desktop");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        /// <summary>
        /// Scans a byte array for the standard JPEG "Start of Image" marker (FF D8 FF)
        /// </summary>
        static int FindJpegHeader(byte[] fileBytes)
        {
            for (int i = 0; i < fileBytes.Length - 2; i++)
            {
                // 255 = 0xFF, 216 = 0xD8
                if (fileBytes[i] == 0xFF && fileBytes[i + 1] == 0xD8 && fileBytes[i + 2] == 0xFF)
                {
                    return i;
                }
            }
            return -1; // Header not found
        }
    }
}