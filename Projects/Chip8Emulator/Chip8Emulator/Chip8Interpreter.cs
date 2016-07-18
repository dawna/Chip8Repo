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
        private int[] _rom { get;  set; }
        private ROMType _romType { get;  set; }

        private Chip8ConfigModel ConfigurationsModel { get; set; }
         
        public Chip8Interpreter(int[] rom, ROMType romType)
        {
            this._rom = rom;
            this.InitializeInterpreter(romType);
        }

        public Chip8Interpreter(ROMType romType)
        {
            this.InitializeInterpreter(romType);
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
                localPC = 0x600;
            }

            this.ConfigurationsModel = new Chip8ConfigModel
            {
                Rom = this._rom,
                Stack = new int[0xF],
                V = new uint[0xF],
                PC = localPC
            };
        }

        public void InterpretationLoop()
        {
            while (true)
            {
                var opcode = (this._rom[ConfigurationsModel.PC] << 8) | this._rom[ConfigurationsModel.PC + 1];
                OpcodeInterpreter(opcode);
            }
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
                    //3nnn
                    OpcodeInstructions.CallAddress(this.ConfigurationsModel, opcode);
                    break;
                case 0x3:
                    break;
                case 0x4:
                    break;
                case 0x5:
                    break;
                case 0x6:
                    break;
                case 0x7:
                    break;
                case 0x8:
                    break;
                case 0x9:
                    break;
                case 0xA:
                    break;
                case 0xB:
                    break;
                case 0xC:
                    break;
                case 0xD:
                    break;
                case 0xE:
                    break;
                case 0xF:
                    break;
            }

            this.ConfigurationsModel.PC+=2;
        }
    }
}
