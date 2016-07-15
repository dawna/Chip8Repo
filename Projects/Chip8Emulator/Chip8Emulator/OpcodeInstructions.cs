using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8Emulator
{
    public class OpcodeInstructions
    {
        public static void JumpToMachineRoutine(Chip8ConfigModel config)
        {
            //Do stuff
        }

        public static void ClearScreen(Chip8ConfigModel config)
        {
            config.Pixels = new int[config.ScreenWidth, config.ScreenHeight]; 
        }

        public static void ReturnFromSubroutine(Chip8ConfigModel config)
        {
            config.PC = config.Stack[config.SP];
            config.SP--;
        }

        public static void JumpToAddress(Chip8ConfigModel config, int instruction)
        {
            var addr = instruction & 0x0FFF;
            config.PC = addr;
        }

        public static void CallAddress(Chip8ConfigModel config, int instruction)
        {
            var addr = instruction & 0x0FFF;
            config.SP++;
            config.PC = config.Stack[config.SP];
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

            config.V[x] = kk;
        }

        public static void Add7xkk(Chip8ConfigModel config, int instruction)
        {
            var kk = instruction & 0x00FF;
            var x = (instruction & 0x0F00) >> 8;

            config.V[x] += kk;
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

            config.V[x] = result;
        }

        public static void Subtract(Chip8ConfigModel config, int instruction)
        {
            var x = (instruction & 0x0F00) >> 8;
            var y = (instruction & 0x00F0) >> 4;
        }
        
        public static void ShiftRight(Chip8ConfigModel config)
        {
            //Do stuff
        }

        public static void SubtractNoBorrow(Chip8ConfigModel config)
        {
            //Do stuff
        }

        public static void ShiftLeft(Chip8ConfigModel config)
        {
            //Do stuff
        }

        public static void SkipNextInstruction9xy0(Chip8ConfigModel config)
        {
            //Do stuff
        }
    }
}
