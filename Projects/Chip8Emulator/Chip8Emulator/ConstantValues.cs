using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8Emulator
{
    public class ConstantValues
    {
        public static int TOTAL_MEM_STORAGE = 0xFFF;

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
