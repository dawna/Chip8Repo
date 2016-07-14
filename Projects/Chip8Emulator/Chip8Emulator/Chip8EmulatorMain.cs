using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8Emulator
{
    class Chip8EmulatorMain
    {
        public static int[] ReadRomFromFile(string filePath)
        {
            var romData = new int[ConstantValues.TOTAL_MEM_STORAGE];

            try
            {
                byte[] byteArray = File.ReadAllBytes(filePath);

                if (byteArray.Length > ConstantValues.TOTAL_MEM_STORAGE)
                {
                    //Throw exception.
                }

                int counter = 0;
                for (int i = 0; i < byteArray.Length - 1; i += 2)
                {
                    romData[counter] = (byteArray[i] << 8) | byteArray[i + 1];
                    counter++;
                }
            }catch (Exception e)
            {
                Console.WriteLine("Couldn't open file");
            }

            return romData;
        }

        static void Main(string[] args)
        {
            string filePath = @"C:\Users\AdamD\Source\Repos\Chip8Repo\Projects\Chip8Emulator\Chip8Emulator\c8games\VERS";

            //Retrieves ROM and stores it.
            ReadRomFromFile(filePath);
            //Execute Opcodes
        }
    }
} 