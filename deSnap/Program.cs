namespace deSnap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo taskDirectory = new DirectoryInfo(@"C:\Users\sch3f\Repos\GitHub\deSnap\deSnap\bin\Debug\net6.0"); //IMPORTANT TO CHANGE LATER TO A CORRECT PATH
            FileInfo[] taskFiles = taskDirectory.GetFiles("PGTA5*");
            foreach (FileInfo file in taskFiles)
            {
                Console.WriteLine(file.Name);
            }
            
            string path = @"PGTA5134690640";
            byte[] readFile = File.ReadAllBytes(path); //converts the file in PATH to byte array

            byte[] output = new byte[527900]; //new output array
            Array.Copy(readFile, 292, output, 0, 527900); //copies the relevant data from original array to new one

            int fileNum = 1;
            string fileName = "Snapmatic" + fileNum.ToString() + ".jpeg"; //output file name

            System.IO.File.WriteAllBytes(fileName, output);

            Console.WriteLine("Conversion was successful!. Your images are in the $PATH"); //add path later
            Console.WriteLine("Press any key to exit.");
        }
    }
}