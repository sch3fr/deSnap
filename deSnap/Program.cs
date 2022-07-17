namespace deSnap
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            string path = @"PGTA5134690640";
            byte[] readText = File.ReadAllBytes(path);

            List<byte> converted = new List<byte>(readText);
            Console.WriteLine(converted.Count);
            for (int i = 0; i < 292; i++)
            {
                converted.RemoveAt(i);
            }
            Console.WriteLine(converted.Count);
            /*
            foreach (byte s in converted)
            {
                Console.WriteLine(s);
            }
            */
            System.IO.File.WriteAllBytes("testOld.txt", converted.ToArray());
        }
    }
}