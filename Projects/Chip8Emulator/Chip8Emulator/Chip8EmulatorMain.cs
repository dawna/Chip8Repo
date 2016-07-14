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
            byte[] byteArray = File.ReadAllBytes(filePath);

            if (byteArray.Length > ConstantValues.TOTAL_MEM_STORAGE)
            {
                //Throw exception.
            }

            int counter = 0;
            for (int i = 0; i < byteArray.Length - 1; i+= 2)
            {
                romData[counter] = (byteArray[i] << 8) | byteArray[i + 1];
                counter++;
            }

            return romData;
        }

        static void Main(string[] args)
        {
            string filePath = @"c:\users\adam\documents\visual studio 2013\Projects\Chip8Emulator\Chip8Emulator\c8games\VERS";

            //Retrieves ROM and stores it.
            ReadRomFromFile(filePath);
            //Execute Opcodes
        }
    }
} 