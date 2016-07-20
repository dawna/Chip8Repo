using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8Emulator
{
    public class Renderer
    {
        public void DrawToScreen(Chip8ConfigModel model, RenderWindow window)
        {
            for (var y = 0; y <= model.ScreenHeight; y++)
            {
                for (var x = 0; x <= model.ScreenWidth; x++)
                {
                    if (model.Pixels[x, y] == 1)
                    {
                        RectangleShape rectangle = new RectangleShape();
                        rectangle.Size = new SFML.Window.Vector2f(10, 10);
                        rectangle.Position = new SFML.Window.Vector2f(x * 10, y * 10);
                        rectangle.FillColor = Color.White;

                        window.Draw(rectangle);
                    }
                }
            }
        }
    }
}
