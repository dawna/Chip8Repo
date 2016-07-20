using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8Emulator
{
    public class OpcodeInstructions
    {
        private static Random _ran = new Random();

        public static void JumpToMachineRoutine(Chip8ConfigModel config)
        {
            //TODO.
        }

        public static void ClearScreen(Chip8ConfigModel config)
        {
            config.Pixels = new int[config.ScreenWidth + 1, config.ScreenHeight + 1]; 
        }

        public static void ReturnFromSubroutine(Chip8ConfigModel config)
        {
            config.PC = config.Stack[config.SP];
            config.SP--;

            config.PC -= 2;
        }

        public static void JumpToAddress(Chip8ConfigModel config, int instruction)
        {
            var addr = instruction & 0x0FFF;
            config.PC = addr;

            config.PC -= 2;
        }

        public static void CallAddress(Chip8ConfigModel config, int instruction)
        {
            var addr = instruction & 0x0FFF;
            config.SP++;
            config.Stack[config.SP] = config.PC;
            config.PC = addr;

            config.PC -= 2;
        }

        public static void SkipNextInstruction3xkk(Chip8ConfigModel config, int instruction)
        {
            var kk = instruction & 0x00FF;
            var x = (instruction & 0x0F00) >> 8;
            var vX = config.V[x];

            if (vX == kk)
            {
                config.PC += 2;
            }
        }

        public static void SkipNextInstruction4xkk(Chip8ConfigModel config, int instruction)
        {
            var kk = instruction & 0x00FF;
            var x = (instruction & 0x0F00) >> 8;
            var vX = config.V[x];

            if (vX != kk)
            {
                config.PC += 2;
            }
        }

        public static void SkipNextInstruction5xy0(Chip8ConfigModel config, int instruction)
        {
            var x = (instruction & 0x0F00) >> 8;
            var y = (instruction & 0x00F0) >> 4;
            var vX = config.V[x];
            var vY = config.V[y];

            if (vX == vY)
            {
                config.PC += 2;
            }
        }
        public static void Load6xkk(Chip8ConfigModel config, int instruction)
        {
            var kk = instruction & 0x00FF;
            var x = (instruction & 0x0F00) >> 8;

            config.V[x] = (byte)kk;
        }

        public static void Add7xkk(Chip8ConfigModel config, int instruction)
        {
            var kk = instruction & 0x00FF;
            var x = (instruction & 0x0F00) >> 8;

            config.V[x] += (byte)kk;
        }

        public static void Load8xy0(Chip8ConfigModel config, int instruction)
        {
            var x = (instruction & 0x0F00) >> 8;
            var y = (instruction & 0x00F0) >> 4;

            config.V[x] = config.V[y];
        }

        public static void Or(Chip8ConfigModel config, int instruction)
        {
            var x = (instruction & 0x0F00) >> 8;
            var y = (instruction & 0x00F0) >> 4;

            config.V[x] |= config.V[y];
        }

        public static void And(Chip8ConfigModel config, int instruction)
        {
            var x = (instruction & 0x0F00) >> 8;
            var y = (instruction & 0x00F0) >> 4;

            config.V[x] &= config.V[y];
        }

        public static void XOR(Chip8ConfigModel config, int instruction)
        {
            var x = (instruction & 0x0F00) >> 8;
            var y = (instruction & 0x00F0) >> 4;

            config.V[x] ^= config.V[y];
        }

        public static void Add8xy4(Chip8ConfigModel config, int instruction)
        {
            var x = (instruction & 0x0F00) >> 8;
            var y = (instruction & 0x00F0) >> 4;
            var vX = config.V[x];
            var vY = config.V[y];

            var result = vX + vY;

            //0xFF.
            if (result > 255)
            {
                result = result & 0xFF;
                config.V[0xF] = 1;
            }
            else
            {
                config.V[0xF] = 0;
            }

            config.V[x] = (byte)result;
        }

        public static void Subtract(Chip8ConfigModel config, int instruction)
        {
            var x = (instruction & 0x0F00) >> 8;
            var y = (instruction & 0x00F0) >> 4;
            var vX = config.V[x];
            var vY = config.V[y];

            config.V[0xF] = (byte)((vX > vY)? 1 : 0);

            //This may not be right.
            config.V[x] = (byte)(vX - vY);
        }
        
        //This may not be right.
        public static void ShiftRight(Chip8ConfigModel config, int instruction)
        {
            var x = (instruction & 0x0F00) >> 8;
            var vX = config.V[x];

            config.V[0xF] = (byte)((vX % 2 != 0)? 1 : 0);
            config.V[x] = (byte)(vX / 2);
        }

        public static void SubtractNoBorrow(Chip8ConfigModel config, int instruction)
        {
            var x = (instruction & 0x0F00) >> 8;
            var y = (instruction & 0x00F0) >> 4;
            var vX = config.V[x];
            var vY = config.V[y];

            config.V[0xF] = (byte)((vY > vX)? 1 : 0);

            //This may not be right.
            config.V[x] = (byte)(vY - vX);
        }

        public static void ShiftLeft(Chip8ConfigModel config, int instruction)
        {
            byte x = (byte)((instruction & 0x0F00) >> 8);
            byte vX = config.V[x];

            //vX >= 128.
            config.V[0xF] = (byte)((vX >= 0x80)? 1 : 0);
            config.V[x] = (byte)(vX * 2);
        }

        public static void SkipNextInstruction9xy0(Chip8ConfigModel config, int instruction)
        {
            var x = (instruction & 0x0F00) >> 8;
            var y = (instruction & 0x00F0) >> 4;
            var vX = config.V[x];
            var vY = config.V[y];

            if (vX != vY)
            {
                config.PC += 2;
            }
        }

        public static void LoadAnnn(Chip8ConfigModel config, int instruction)
        {
            var nnn = instruction & 0x0FFF;
            config.I = nnn;
        }

        public static void JumpBnnn(Chip8ConfigModel config, int instruction)
        {
            var nnn = instruction & 0x0FFF;
            config.PC = config.V[0] + nnn;

            config.PC -= 2;
        }

        public static void Random(Chip8ConfigModel config, int instruction)
        {
            var kk = instruction & 0x00FF;
            var x = (instruction & 0x0F00) >> 8;

            var num = OpcodeInstructions._ran.Next(0, 255);

            config.V[x] = (byte)(num & kk);
        }

        public static void Draw(Chip8ConfigModel config, int instruction)
        {
            var n = 0xF & instruction;
            var x = (instruction & 0x0F00) >> 8;
            var y = (instruction & 0x00F0) >> 4;
            var rom = config.Rom;
            var I = config.I;

            var vX = config.V[x];
            var vY = config.V[y];

            var counter = 0;
            for (int i = I; i < I + n; i++)
            {
                for (int j = 1; j <= 8; j++)
                {
                    var place = 0;
                    if (vX + j > config.ScreenWidth)
                    {
                        place = (vX + j) - config.ScreenWidth;
                    }
                    else
                    {
                        place = vX + j;
                    }

                    var before = config.Pixels[place, vY + counter];
                    config.Pixels[place, vY + counter] ^= (GetNthBit(rom[i], 9 - j));

                    if (before == 1 && config.Pixels[place,vY + counter] == 0)
                    {
                        config.V[0xF] = 1;
                    }
                }

                counter++;
            }
        }

        public static int GetNthBit(int b, int j)
        {
            return ((b & (1 << j - 1)) != 0)? 1: 0;
        }

        public static void SkipNextInstructionKeyPressed(Chip8ConfigModel config, int instruction)
        {
            var x = (instruction & 0x0F00) >> 8;

            if (config.KeyPresses[x])
            {
                config.PC += 2; 
            }
        }

        public static void SkipNextInstructionKeyNotPressed(Chip8ConfigModel config, int instruction)
        {
            var x = (instruction & 0x0F00) >> 8;

            if (!config.KeyPresses[x]) 
            {
                config.PC += 2;
            }
        }

        public static void DelayTimerFx07(Chip8ConfigModel config, int instruction)
        {
            var x = (instruction & 0x0F00) >> 8;
            config.V[x] = (byte)config.DT;
        }

        public static void WaitForKeyPress(Chip8ConfigModel config, int instruction)
        {
            var x = (instruction & 0x0F00) >> 8;

            var key = 0;
            if (config.KeyPressed)
            {
                for (int i = 0; i < 0xF; i++)
                {
                    if (config.KeyPresses[i])
                    {
                        key = i;
                        break;
                    }
                }
                config.V[x] = (byte)key;
            }
            else
            {
                config.PC -= 2;
            }
        }

        public static void SetDelayTimerFx15(Chip8ConfigModel config, int instruction)
        {
            var x = (instruction & 0x0F00) >> 8;
            config.DT = (int)config.V[x];
        }

        public static void SetSoundTimer(Chip8ConfigModel config, int instruction)
        {
            var x = (instruction & 0x0F00) >> 8;

            config.ST = (int)config.V[x];
        }

        public static void AddFx1E(Chip8ConfigModel config, int instruction)
        {
            var x = (instruction & 0x0F00) >> 8;

            config.I += (int)config.V[x]; //Carry?
        }

        public static void LoadFx29(Chip8ConfigModel config, int instruction)
        {
            var x = (instruction & 0x0F00) >> 8;

            config.I = (int)config.V[x] * 5;
        }

        public static void LoadFx33(Chip8ConfigModel config, int instruction)
        {
            var x = (instruction & 0x0F00) >> 8;
            var vX = (int)config.V[x];

            var hundreds = (vX % 1000) / 100;
            var tens = (vX % 100) / 10;
            var ones = (vX % 10);

            config.Rom[config.I] = hundreds;
            config.Rom[config.I + 1] = tens;
            config.Rom[config.I + 2] = ones;
        }

        public static void LoadFx55(Chip8ConfigModel config, int instruction)
        {
            var x = (instruction & 0x0F00) >> 8;
            var rom = config.Rom;
            var I = config.I; 

            for (int i = 0; i <= 0xF; i++)
            {
                rom[I + i] = (int)config.V[i];
            }
        }

        public static void LoadFx65(Chip8ConfigModel config, int instruction)
        {
            var x = (instruction & 0x0F00) >> 8;
            var rom = config.Rom;
            var I = config.I; 
            
            for (int i = 0; i <= x; i++)
            {
                config.V[i] = (byte)rom[I + i];
            }
        }
    }
}
