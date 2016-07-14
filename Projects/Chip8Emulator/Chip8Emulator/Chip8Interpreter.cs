using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8Emulator
{
    public class Chip8Interpreter
    {
        private readonly Renderer _renderer{ get; set; }
        private readonly int[] _rom { get;  set; }
        private readonly ROMType _romType { get;  set; }

        private Chip8DataModel ConfigurationsModel { get; set; }
         
        public Chip8Interpreter(int[] _rom, ROMType romType)
        {
            this._rom = _rom;
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

            this.ConfigurationsModel = new Chip8DataModel
            {
                Stack = new int[0xF],
                V = new int[0xF],
                PC = localPC
            };
        }

        public void InterpretationLoop()
        {
            while (true)
            {

            }
        }

        private List<Action<Chip8DataModel>> OpcodeInterpreter()
        {
            var opcodeFunctions = new List<Action<Chip8DataModel>>();

            foreach (int opcode in this._rom)
            {
                switch ((opcode & 0xF000) >> 0xc)
                {
                    case 0x0:
                        if ((opcode & 0x0F00) == 0)
                        {
                            switch (opcode & 0x000F)
                            {
                                case 0x0:
                                    break;
                                case 0xE:
                                    break;
                            }
                        }
                        else
                        {
                            opcodeFunctions.Add(OpcodeInstructions.Jump);
                            //0nnn
                        }
                        break;
                    case 0x1:
                        break;
                    case 0x2:
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
            }

            return opcodeFunctions;
        }
    }
}
