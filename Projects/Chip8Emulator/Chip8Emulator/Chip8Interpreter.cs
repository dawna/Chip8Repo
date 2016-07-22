using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8Emulator
{
    public class Chip8Interpreter
    {
        private Renderer _renderer{ get; set; }
        private KeyboardConfigurations _keyboardConfig { get; set; }

        private int[] _rom { get;  set; }
        private ROMType _romType { get;  set; }

        private Chip8ConfigModel ConfigurationsModel { get; set; }
         
        public Chip8Interpreter(int[] rom, ROMType romType, Renderer renderer, KeyboardConfigurations keyboardConfig)
        {
            this._rom = rom;
            this._renderer = renderer;
            this._keyboardConfig = keyboardConfig;
            this.InitializeInterpreter(romType);
        }

        public Chip8Interpreter(ROMType romType, Renderer renderer, KeyboardConfigurations keyboardConfig)
        {
            this._renderer = renderer;
            this._keyboardConfig = keyboardConfig;
            this.InitializeInterpreter(romType);
        }

        public void UpdateScreen(RenderWindow window)
        {
            this._renderer.DrawToScreen(this.ConfigurationsModel, window);
        }

        public void Reset()
        {
            this.InitializeInterpreter(this._romType);
        }
        
        private void InitializeInterpreter(ROMType romType)
        {
            this._romType = romType;

            //Default starting value for PC
            var localPC = 0x200;
            if (this._romType == ROMType.ETI660)
            {
                localPC = 0x600 / 8;
            }

            this.ConfigurationsModel = new Chip8ConfigModel
            {
                Rom = this._rom,
                Stack = new int[0xF + 1],
                V = new byte[0xF + 1],
                PC = localPC,
                Pixels = new int[65,33],
                KeyModel = this._keyboardConfig.KeyModel,
                ScreenWidth = 64,
                ScreenHeight = 32
            };
        }

        public bool PopInstruction()
        {
            if (ConfigurationsModel.PC >= this._rom.Length || ConfigurationsModel.PC + 1 >= this._rom.Length)
                return false;

            var opcode = (this._rom[ConfigurationsModel.PC] << 8) | this._rom[ConfigurationsModel.PC + 1];
            OpcodeInterpreter(opcode);

            return (opcode != 0);
        }

        private void OpcodeInterpreter(int opcode)
        {
            switch ((opcode & 0xF000) >> 0xc)
            {
                case 0x0:
                    if ((opcode & 0x0F00) == 0)
                    {
                        switch (opcode & 0x000F)
                        {
                            case 0x0:
                                //00E0
                                OpcodeInstructions.ClearScreen(this.ConfigurationsModel);
                                break;
                            case 0xE:
                                //00EE
                                OpcodeInstructions.ReturnFromSubroutine(this.ConfigurationsModel);
                                break;
                        }
                    }
                    else
                    {
                        //0nnn
                        OpcodeInstructions.JumpToMachineRoutine(this.ConfigurationsModel);
                    }
                    break;
                case 0x1:
                    //1nnn
                    OpcodeInstructions.JumpToAddress(this.ConfigurationsModel, opcode);
                    break;
                case 0x2:
                    //2nnn
                    OpcodeInstructions.CallAddress(this.ConfigurationsModel, opcode);
                    break;
                case 0x3:
                    OpcodeInstructions.SkipNextInstruction3xkk(this.ConfigurationsModel, opcode);
                    break;
                case 0x4:
                    OpcodeInstructions.SkipNextInstruction4xkk(this.ConfigurationsModel, opcode);
                    break;
                case 0x5:
                    OpcodeInstructions.SkipNextInstruction5xy0(this.ConfigurationsModel, opcode);
                    break;
                case 0x6:
                    OpcodeInstructions.Load6xkk(this.ConfigurationsModel, opcode);
                    break;
                case 0x7:
                    OpcodeInstructions.Add7xkk(this.ConfigurationsModel, opcode);
                    break;
                case 0x8:
                    var rightMostBit = 0xF & opcode;
                    switch (rightMostBit)
                    {
                        case 0: 
                            OpcodeInstructions.Load8xy0(this.ConfigurationsModel, opcode);
                            break;
                        case 1:
                            OpcodeInstructions.Or(this.ConfigurationsModel, opcode);
                            break;
                        case 2:
                            OpcodeInstructions.And(this.ConfigurationsModel, opcode);
                            break;
                        case 3:
                            OpcodeInstructions.XOR(this.ConfigurationsModel, opcode);
                            break;
                        case 4:
                            OpcodeInstructions.Add8xy4(this.ConfigurationsModel, opcode);
                            break;
                        case 5:
                            OpcodeInstructions.Subtract(this.ConfigurationsModel, opcode);
                            break;
                        case 6:
                            OpcodeInstructions.ShiftRight(this.ConfigurationsModel, opcode);
                            break;
                        case 7:
                            OpcodeInstructions.SubtractNoBorrow(this.ConfigurationsModel, opcode);
                            break;
                        case 0xE:
                            OpcodeInstructions.ShiftLeft(this.ConfigurationsModel, opcode);
                            break;
                    }
                    break;
                case 0x9:
                    OpcodeInstructions.SkipNextInstruction9xy0(this.ConfigurationsModel, opcode);
                    break;
                case 0xA:
                    OpcodeInstructions.LoadAnnn(this.ConfigurationsModel, opcode);
                    break;
                case 0xB:
                    OpcodeInstructions.JumpBnnn(this.ConfigurationsModel, opcode);
                    break;
                case 0xC:
                    OpcodeInstructions.Random(this.ConfigurationsModel, opcode);
                    break;
                case 0xD:
                    OpcodeInstructions.Draw(this.ConfigurationsModel, opcode);
                    break;
                case 0xE:
                    var lastTwoDigits = 0xFF & opcode;

                    if (lastTwoDigits == 0x9E)
                    {
                        OpcodeInstructions.SkipNextInstructionKeyPressed(this.ConfigurationsModel, opcode);
                    }
                    else if (lastTwoDigits == 0xA1)
                    {
                        OpcodeInstructions.SkipNextInstructionKeyNotPressed(this.ConfigurationsModel, opcode);
                    }

                    break;
                case 0xF:
                    var digits = 0xFF & opcode;

                    switch(digits)
                    {
                        case 0x07:
                            OpcodeInstructions.DelayTimerFx07(this.ConfigurationsModel, opcode);
                            break;
                        case 0x0A:
                            OpcodeInstructions.WaitForKeyPress(this.ConfigurationsModel, opcode);
                            break;
                        case 0x15:
                            OpcodeInstructions.SetDelayTimerFx15(this.ConfigurationsModel, opcode);
                            break;
                        case 0x18:
                            OpcodeInstructions.SetSoundTimer(this.ConfigurationsModel, opcode);
                            break;
                        case 0x1E:
                            OpcodeInstructions.AddFx1E(this.ConfigurationsModel, opcode);
                            break;
                        case 0x29:
                            OpcodeInstructions.LoadFx29(this.ConfigurationsModel, opcode);
                            break;
                        case 0x33:
                            OpcodeInstructions.LoadFx33(this.ConfigurationsModel, opcode);
                            break;
                        case 0x55:
                            OpcodeInstructions.LoadFx55(this.ConfigurationsModel, opcode);
                            break;
                        case 0x65:
                            OpcodeInstructions.LoadFx65(this.ConfigurationsModel, opcode);
                            break;
                    }
                    break;
            }

            if (this.ConfigurationsModel.DT > 0)
            {
                this.ConfigurationsModel.DT--;
            }
            if (this.ConfigurationsModel.ST > 0)
            {
                this.ConfigurationsModel.ST--;
            }

            this.ConfigurationsModel.PC+=2;
        }
    }
}
