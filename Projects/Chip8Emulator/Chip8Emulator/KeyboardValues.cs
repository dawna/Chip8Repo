using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8Emulator
{
    public class KeyboardValuesModel
    {
        //Stores the keys that have been pressed.
        public bool[] KeyPresses { get; set; }
        //Bool that for key press.
        public bool KeyPressed { get; set; }

        public KeyboardValuesModel()
        {
            this.KeyPresses = new bool[0xF];
            this.KeyPressed = false;
        }
    }
}
