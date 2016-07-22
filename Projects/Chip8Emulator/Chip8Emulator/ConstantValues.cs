using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Window;

namespace Chip8Emulator
{
    public class ConstantValues
    {
        public static int TOTAL_MEM_STORAGE = 0xFFF;

        public static Keyboard.Key[] KEYCODES = new Keyboard.Key[]
        {
            //1
            Keyboard.Key.Q,
            //2
            Keyboard.Key.W,
            //3
            Keyboard.Key.E,
            //4
            Keyboard.Key.R,
            //5
            Keyboard.Key.T,
            
            //6
            Keyboard.Key.A,
            //7
            Keyboard.Key.S,
            //8
            Keyboard.Key.D,
            //9
            Keyboard.Key.F,
            //a
            Keyboard.Key.G,

            //b
            Keyboard.Key.Z,
            //c
            Keyboard.Key.X,
            //d
            Keyboard.Key.C,
            //e
            Keyboard.Key.V,
            //f
            Keyboard.Key.B,
        };

        public static int[][] SPRITE_ARRAY = new int[][]
        {
            //0
            new int[]
            {
                0xF0,
                0x90,
                0x90,
                0x90,
                0xF0
            },
            //1
            new int[]
            {
                0x20,
                0x60,
                0x20,
                0x20,
                0x70
            },
            //2
            new int[]
            {
                0xF0,
                0x10,
                0xF0,
                0x80,
                0xF0
            },
            //3
            new int[]
            {
                0xF0,
                0x10,
                0xF0,
                0x10,
                0xF0
            },
            //4
            new int[]
            {
                0x90,
                0x90,
                0xF0,
                0x10,
                0x10
            },
            //5
            new int[]
            {
                0xF0,
                0x80,
                0xF0,
                0x10,
                0xF0
            },
            //6
            new int[]
            {
                0xF0,
                0x80,
                0xF0,
                0x90,
                0xF0
            },
            //7
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
}
