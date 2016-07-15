using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8Emulator
{
    public class OpcodeInstructions
    {
        public static Action<Chip8ConfigModel> JumpToMachineRoutine = delegate(Chip8ConfigModel data)
        {
            //Do stuff
        };

        public static Action<Chip8ConfigModel> ClearScreen = delegate(Chip8ConfigModel data)
        {
            //Do stuff
        };

        public static Action<Chip8ConfigModel> ReturnFromSubroutine = delegate(Chip8ConfigModel data)
        {
            //Do stuff
        };

        public static Action<Chip8ConfigModel> JumpToAddress = delegate(Chip8ConfigModel data)
        {
            //Do stuff
        };

        public static Action<Chip8ConfigModel> CallAddress = delegate(Chip8ConfigModel data)
        {
            //Do stuff
        };

        public static Action<Chip8ConfigModel> SkipNextInstruction3xkk = delegate(Chip8ConfigModel data)
        {
            //Do stuff
        };

        public static Action<Chip8ConfigModel> SkipNextInstruction4xkk = delegate(Chip8ConfigModel data)
        {
            //Do stuff
        };

        public static Action<Chip8ConfigModel> Load6xkk = delegate(Chip8ConfigModel data)
        {
            //Do stuff
        };

        public static Action<Chip8ConfigModel> Add7xkk = delegate(Chip8ConfigModel data)
        {
            //Do stuff
        };

        public static Action<Chip8ConfigModel> Load8xy0 = delegate(Chip8ConfigModel data)
        {
            //Do stuff
        };

        public static Action<Chip8ConfigModel> Or = delegate(Chip8ConfigModel data)
        {
            //Do stuff
        };

        public static Action<Chip8ConfigModel> And = delegate(Chip8ConfigModel data)
        {
            //Do stuff
        };

        public static Action<Chip8ConfigModel> XOR = delegate(Chip8ConfigModel data)
        {
            //Do stuff
        };

        public static Action<Chip8ConfigModel> Add8xy4 = delegate(Chip8ConfigModel data)
        {
            //Do stuff
        };

        public static Action<Chip8ConfigModel> Subtract = delegate(Chip8ConfigModel data)
        {
            //Do stuff
        };
        
        public static Action<Chip8ConfigModel> ShiftRight = delegate(Chip8ConfigModel data)
        {
            //Do stuff
        };

        public static Action<Chip8ConfigModel> SubtractNoBorrow = delegate(Chip8ConfigModel data)
        {
            //Do stuff
        };

        public static Action<Chip8ConfigModel> ShiftLeft = delegate(Chip8ConfigModel data)
        {
            //Do stuff
        };

        public static Action<Chip8ConfigModel> SkipNextInstruction9xy0 = delegate(Chip8ConfigModel data)
        {
            //Do stuff
        };
    }
}
