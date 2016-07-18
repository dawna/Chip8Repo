using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

                //Should begin on the 25th byte.
                int counter = 0x200 / 0x8;
                for (int i = 0; i < byteArray.Length; i ++)
                {
                    romData[counter] = byteArray[i];
                    counter++;
                }
            }catch (Exception e)
            {
                Console.WriteLine("Couldn't open file");
            }

            return romData;
        }

        public static void LoadSpritesIntoRom(int[] rom)
        {
            var spriteArray = new int[][]
            {
                new int[]
                {
                    0xF0,
                    0x90,
                    0x90,
                    0x90,
                    0xF0
                },
                new int[]
                {
                    0x20,
                    0x60,
                    0x20,
                    0x20,
                    0x70
                },
                new int[]
                {
                    0xF0,
                    0x10,
                    0xF0,
                    0x80,
                    0xF0
                },
                new int[]
                {
                    0xF0,
                    0x10,
                    0xF0,
                    0x10,
                    0xF0
                },
                new int[]
                {
                    0xF0,
                    0x80,
                    0xF0,
                    0x90,
                    0xF0
                },
                new int[]
                {
                    0xF0,
                    0x10,
                    0x20,
                    0x40,
                    0x40
                },
                new int[]
                {
                    0xF0,
                    0x90,
                    0xF0,
                    0x90,
                    0xF0
                },
                new int[]
                {
                    0xF0,
                    0x90,
                    0xF0,
                    0x10,
                    0xF0
                },
                new int[]
                {
                    0xF0,
                    0x90,
                    0xF0,
                    0x90,
                    0x90
                },
                new int[]
                {
                    0xE0,
                    0x90,
                    0xE0,
                    0x90,
                    0xE0
                },
                new int[]
                {
                    0xF0,
                    0x80,
                    0x80,
                    0x80,
                    0xF0
                },
                new int[]
                {
                    0xE0,
                    0x90,
                    0x90,
                    0x90,
                    0xE0
                },
                new int[]
                {
                    0xF0,
                    0x80,
                    0xF0,
                    0x80,
                    0xF0
                },
                new int[]
                {
                    0xF0,
                    0x80,
                    0xF0,
                    0x80,
                    0x80
                },
            };
        }

        static void Main(string[] args)
        {
            string filePath = @"C:\Users\AdamD\Source\Repos\Chip8Repo\Projects\Chip8Emulator\Chip8Emulator\c8games\VERS";

            //Retrieves ROM and stores it.
            int[] rom = ReadRomFromFile(filePath);
            
            Chip8Interpreter interpreter = new Chip8Interpreter(rom, ROMType.Normal);
            RenderWindow window = new RenderWindow(new VideoMode(800,600), "TEST WINDOW");

            Color windowColor = Color.Black;

            window.Closed += new EventHandler(OnClose);
            window.KeyPressed += new EventHandler<KeyEventArgs>(OnKeyPress);

            while (window.IsOpen())
            {
                window.DispatchEvents();
                window.Clear(windowColor);
                window.Display();
            }
        }

        public static void OnClose(object sender, EventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;
            window.Close();
        }

        public static void OnKeyPress(object sender, KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.Escape)
            {
                RenderWindow window = (RenderWindow)sender;
                window.Close();
            }
        }
    }
} 