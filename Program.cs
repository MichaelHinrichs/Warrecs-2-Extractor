using System.IO;

namespace Warrecs_2_Extractor
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryReader br = new BinaryReader(File.OpenRead(args[0]));
            Directory.CreateDirectory(Path.GetDirectoryName(args[0]) + "//" + Path.GetExtension(args[0]));
            int i = 0;
            while (br.BaseStream.Position < br.BaseStream.Length)
            {
                var variable = br.ReadBytes(4);
                System.Array.Reverse(variable);
                int size = System.BitConverter.ToInt32(variable, 0);
                using FileStream FS = File.Create(Path.GetDirectoryName(args[0]) + "//" + Path.GetExtension(args[0]) + "//" + i);
                BinaryWriter bw = new(FS);
                bw.Write(br.ReadBytes(size));
                bw.Close();
                i++;
            }
        }
    }
}
