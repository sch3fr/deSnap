namespace deSnap
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            string path = @"PGTA5134690640";
            byte[] readFile = File.ReadAllBytes(path);

            byte[] output = new byte[527900];
            Array.Copy(readFile, 292, output, 0, 527900);

            System.IO.File.WriteAllBytes("image.jpeg", output);

            Console.WriteLine("Conversion was successful!. Your images are in the $PATH"); //add path later
            Console.WriteLine("Press any key to exit.");

        }
    }
}