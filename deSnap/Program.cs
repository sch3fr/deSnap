namespace deSnap
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); 
            path = path + @"\Rockstar Games\GTA V\Profiles";
            string[] dirs = Directory.GetDirectories(path);
            path = dirs[0]; 
            //Code above finds users Documents folder, gets into GTA V folders and finds the path of randomly generated number folder

            DirectoryInfo taskDirectory = new DirectoryInfo(path);
            FileInfo[] taskFiles = taskDirectory.GetFiles("PGTA5*");  //looks for files that contain the PGTA5* string, adds them to an array
            int stop = taskFiles.Length; //finds the lenght of taskFiles array for later usage
            int counter = 0; //counter for moving through the files and naming purposes

            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\deSnap"; //desktop path
            DirectoryInfo dir = Directory.CreateDirectory(desktop); //creates the deSnap folder on Desktop

            for (int i = 0; i < stop; i++)
            {
                byte[] readFile = File.ReadAllBytes(taskFiles[counter].FullName); //converts the file in taskFiles array to new byte array

                byte[] output = new byte[527900]; //new array with wanted length without the header data
                Array.Copy(readFile, 292, output, 0, 527900); //copies the relevant data from original array to new one

                string fileName = "Snapmatic" + counter + ".jpeg"; //output file naming
                System.IO.File.WriteAllBytes(desktop + @"\deSnap" + fileName, output); //acuall file outputs
                counter++;
            }
            Console.WriteLine("Sucessfuly converted {0} images! Your images are in a folder on your Desktop", counter);
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}