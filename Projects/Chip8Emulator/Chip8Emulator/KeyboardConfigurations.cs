using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Window;

namespace Chip8Emulator
{
    public class KeyboardConfigurations
    {
        public KeyboardValuesModel KeyModel { get; set; }

        public KeyboardConfigurations()
        {
            this.KeyModel = new KeyboardValuesModel();
        }
        public void KeyPressedEvent(object sender, KeyEventArgs e)
        {
            for (var i = 0; i < 0xF; i++)
            {
                if (e.Code == ConstantValues.KEYCODES[i])
                {
                    this.KeyModel.KeyPresses[i] = true;
                    this.KeyModel.KeyPressed = true;
                }
            }
        }

        public void KeyReleasedEvent(object sender, KeyEventArgs e)
        {
            for (var i = 0; i < 0xF; i++)
            {
                if (e.Code == ConstantValues.KEYCODES[i])
                {
                    this.KeyModel.KeyPresses[i] = false;
                    this.KeyModel.KeyPressed = false;
                }
            }
        }
    }
}
