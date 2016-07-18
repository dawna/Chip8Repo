﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8Emulator
{
    public class Chip8ConfigModel
    {
        //16 bit registers.
        public uint[] V { get; set; }
        //32 bit register (usually stores memory addresses).
        public int I { get; set; }
        //? bit register (Delay Timer).
        public int DT { get; set; }
        //? bit register (Sound Timer).
        public int ST { get; set; }
        //16 bit program counter.
        public int PC { get; set; }
        //8 bit stack pointer.
        public byte SP { get; set; }
        //Stores 16 16-bit values.
        public int[] Stack { get; set; }
        //Stores the pixels on screen.
        public int[,] Pixels { get; set; }
        //Stores the width of the screen.
        public int ScreenWidth { get; set; }
        //Stores the height of the screen.
        public int ScreenHeight { get; set; }
        //Stores the keys that have been pressed.
        public bool[] KeyPresses { get; set; }
        //Bool that for key press.
        public bool KeyPressed { get; set; }
        //Stores the rom.
        public int[] Rom { get; set; }
    }
}
