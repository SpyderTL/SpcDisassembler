using System;
using System.Collections.Generic;
using System.Text;

namespace SpcDisassembler
{
	internal static class InstructionReader
	{
		internal static int Position;
		internal static int Flags;
		internal static int Address;
		internal static int Code;
		internal static int Length;
		internal static InstructionTypes InstructionType;
		internal static InstructionTargets Source;
		internal static InstructionTargets Destination;
		internal static ParameterTypes ParameterType;
		internal static ParameterTypes Parameter2Type;
		internal static int Parameter;
		internal static int Parameter2;

		internal static void Read()
		{
			Address = Position;

			Code = Apu.Memory[Position++];
			Length = OpCodes[Code].Length;

			InstructionType = OpCodes[Code].InstructionType;
			Source = OpCodes[Code].Source;
			Destination = OpCodes[Code].Destination;
			ParameterType = OpCodes[Code].ParameterType;
			Parameter2Type = OpCodes[Code].Parameter2Type;

			switch (Length)
			{
				case 1:
					Parameter = -1;
					Parameter2 = -1;
					break;

				case 2:
					if(ParameterType == ParameterTypes.Relative)
						Parameter = (sbyte)Apu.Memory[Position++];
					else
						Parameter = Apu.Memory[Position++];

					Parameter2 = -1;
					break;

				case 3:
					if (Parameter2Type == ParameterTypes.None)
						Parameter = Apu.Memory[Position++] | (Apu.Memory[Position++] << 8);
					else if(Parameter2Type == ParameterTypes.Relative)
					{
						Parameter = Apu.Memory[Position++];
						Parameter2 = (sbyte)Apu.Memory[Position++];
					}
					else
					{
						Parameter = Apu.Memory[Position++];
						Parameter2 = Apu.Memory[Position++];
					}
					break;
			}
		}
		
		internal enum InstructionTypes
		{
			None,
			Jump,
			Branch,
			Call,
			Return
		}

		internal enum ParameterTypes
		{
			None,
			Immediate,
			Absolute,
			Relative,
			Bit
		}

		internal enum InstructionTargets
		{
			None,
			Stack,
			Immediate,
			Variable,
			Table,
			Pointer,
			PointerTable,
			TablePointer,
			A,
			X,
			Y,
			YA
		}

		internal struct OpCode
		{
			internal string Name;
			internal string Description;
			internal int Length;
			internal InstructionTypes InstructionType;
			internal InstructionTargets Source;
			internal InstructionTargets Destination;
			internal ParameterTypes ParameterType;
			internal ParameterTypes Parameter2Type;
		}

		internal static OpCode[] OpCodes = new OpCode[]
		{
			// 0x00
			new OpCode { Name = "NOP", Length = 1, Description = "" },
			new OpCode { Name = "TCALL", Length = 1, Description = "" },
			new OpCode { Name = "SET1", Length = 2, Description = "" },
			new OpCode { Name = "BBS", Length = 3, InstructionType = InstructionTypes.Branch, ParameterType = ParameterTypes.Absolute, Parameter2Type = ParameterTypes.Relative, Description = "" },
			new OpCode { Name = "OR", Length = 2, Description = "" },
			new OpCode { Name = "OR", Length = 3, Description = "" },
			new OpCode { Name = "OR", Length = 1, Description = "" },
			new OpCode { Name = "OR", Length = 2, Description = "" },

			new OpCode { Name = "OR", Length = 2, Description = "" },
			new OpCode { Name = "OR", Length = 3, Description = "" },
			new OpCode { Name = "OR1", Length = 3, Description = "" },
			new OpCode { Name = "ASL", Length = 2, Description = "" },
			new OpCode { Name = "ASL", Length = 3, Description = "" },
			new OpCode { Name = "PUSH", Length = 1, Description = "" },
			new OpCode { Name = "TSET1", Length = 3, Description = "" },
			new OpCode { Name = "BRK", Length = 1, Description = "" },

			// 0x10
			new OpCode { Name = "BPL", Length = 2, InstructionType = InstructionTypes.Branch, ParameterType = ParameterTypes.Relative, Description = "" },
			new OpCode { Name = "TCALL", Length = 1, Description = "" },
			new OpCode { Name = "CLR1", Length = 2, Description = "" },
			new OpCode { Name = "BBC", Length = 3, InstructionType = InstructionTypes.Branch, ParameterType = ParameterTypes.Absolute, Parameter2Type = ParameterTypes.Relative, Description = "" },
			new OpCode { Name = "OR", Length = 2, Description = "" },
			new OpCode { Name = "OR", Length = 3, Description = "" },
			new OpCode { Name = "OR", Length = 3, Description = "" },
			new OpCode { Name = "OR", Length = 2, Description = "" },

			new OpCode { Name = "OR", Length = 3, Description = "" },
			new OpCode { Name = "OR", Length = 1, Description = "" },
			new OpCode { Name = "DECW", Length = 2, Description = "" },
			new OpCode { Name = "ASL", Length = 2, Description = "" },
			new OpCode { Name = "ASL", Length = 1, Description = "" },
			new OpCode { Name = "DEC", Length = 1, Description = "" },
			new OpCode { Name = "CMP", Length = 3, Description = "" },
			new OpCode { Name = "JMP", Length = 3, InstructionType = InstructionTypes.Jump, Description = "" },

			// 0x20
			new OpCode { Name = "CLRP", Length = 1, Description = "" },
			new OpCode { Name = "TCALL", Length = 1, Description = "" },
			new OpCode { Name = "SET1", Length = 2, Description = "" },
			new OpCode { Name = "BBS", Length = 3, InstructionType = InstructionTypes.Branch, ParameterType = ParameterTypes.Absolute, Parameter2Type = ParameterTypes.Relative, Description = "" },
			new OpCode { Name = "AND", Length = 2, Description = "" },
			new OpCode { Name = "AND", Length = 3, Description = "" },
			new OpCode { Name = "AND", Length = 1, Description = "" },
			new OpCode { Name = "AND", Length = 2, Description = "" },

			new OpCode { Name = "AND", Length = 2, Description = "" },
			new OpCode { Name = "AND", Length = 3, Description = "" },
			new OpCode { Name = "OR1", Length = 3, Description = "" },
			new OpCode { Name = "ROL", Length = 2, Description = "" },
			new OpCode { Name = "ROL", Length = 3, Description = "" },
			new OpCode { Name = "PUSH", Length = 1, Description = "" },
			new OpCode { Name = "CBNE", Length = 3, InstructionType = InstructionTypes.Branch, ParameterType = ParameterTypes.Absolute, Parameter2Type = ParameterTypes.Relative, Description = "" },
			new OpCode { Name = "BRA", Length = 2, InstructionType = InstructionTypes.Jump, ParameterType = ParameterTypes.Relative, Description = "" },

			// 0x30
			new OpCode { Name = "BMI", Length = 2, InstructionType = InstructionTypes.Branch, ParameterType = ParameterTypes.Relative, Description = "" },
			new OpCode { Name = "TCALL", Length = 1, Description = "" },
			new OpCode { Name = "CLR1", Length = 2, Description = "" },
			new OpCode { Name = "BBC", Length = 3, InstructionType = InstructionTypes.Branch, ParameterType = ParameterTypes.Absolute, Parameter2Type = ParameterTypes.Relative, Description = "" },
			new OpCode { Name = "AND", Length = 2, Description = "" },
			new OpCode { Name = "AND", Length = 3, Description = "" },
			new OpCode { Name = "AND", Length = 3, Description = "" },
			new OpCode { Name = "AND", Length = 2, Description = "" },

			new OpCode { Name = "AND", Length = 3, Description = "" },
			new OpCode { Name = "AND", Length = 1, Description = "" },
			new OpCode { Name = "INCW", Length = 2, Description = "" },
			new OpCode { Name = "ROL", Length = 2, Description = "" },
			new OpCode { Name = "ROL", Length = 1, Description = "" },
			new OpCode { Name = "INC", Length = 1, Description = "" },
			new OpCode { Name = "CMP", Length = 2, Description = "" },
			new OpCode { Name = "CALL", Length = 3, InstructionType = InstructionTypes.Call, Description = "" },

			// 0x40
			new OpCode { Name = "SETP", Length = 1, Description = "" },
			new OpCode { Name = "TCALL", Length = 1, Description = "" },
			new OpCode { Name = "SET1", Length = 2, Description = "" },
			new OpCode { Name = "BBS", Length = 3, InstructionType = InstructionTypes.Branch, ParameterType = ParameterTypes.Absolute, Parameter2Type = ParameterTypes.Relative, Description = "" },
			new OpCode { Name = "EOR", Length = 2, Description = "" },
			new OpCode { Name = "EOR", Length = 3, Description = "" },
			new OpCode { Name = "EOR", Length = 1, Description = "" },
			new OpCode { Name = "EOR", Length = 2, Description = "" },

			new OpCode { Name = "EOR", Length = 2, Description = "" },
			new OpCode { Name = "EOR", Length = 3, Description = "" },
			new OpCode { Name = "AND1", Length = 3, Description = "" },
			new OpCode { Name = "LSR", Length = 2, Description = "" },
			new OpCode { Name = "LSR", Length = 3, Description = "" },
			new OpCode { Name = "PUSH", Length = 1, Description = "" },
			new OpCode { Name = "TCLR1", Length = 3, Description = "" },
			new OpCode { Name = "PCALL", Length = 2, Description = "" },

			// 0x50
			new OpCode { Name = "BVC", Length = 2, InstructionType = InstructionTypes.Branch, ParameterType = ParameterTypes.Relative, Description = "" },
			new OpCode { Name = "TCALL", Length = 1, Description = "" },
			new OpCode { Name = "CLR1", Length = 2, Description = "" },
			new OpCode { Name = "BBC", Length = 3, InstructionType = InstructionTypes.Branch, ParameterType = ParameterTypes.Absolute, Parameter2Type = ParameterTypes.Relative, Description = "" },
			new OpCode { Name = "EOR", Length = 2, Description = "" },
			new OpCode { Name = "EOR", Length = 3, Description = "" },
			new OpCode { Name = "EOR", Length = 3, Description = "" },
			new OpCode { Name = "EOR", Length = 2, Description = "" },

			new OpCode { Name = "EOR", Length = 3, Description = "" },
			new OpCode { Name = "EOR", Length = 1, Description = "" },
			new OpCode { Name = "CMPW", Length = 2, Description = "" },
			new OpCode { Name = "LSR", Length = 2, Description = "" },
			new OpCode { Name = "LSR", Length = 1, Description = "" },
			new OpCode { Name = "MOV", Length = 1, Description = "" },
			new OpCode { Name = "CMP", Length = 3, Description = "" },
			new OpCode { Name = "JMP", Length = 3, InstructionType = InstructionTypes.Jump, Description = "" },

			// 0x60
			new OpCode { Name = "CLRC", Length = 1, Description = "" },
			new OpCode { Name = "TCALL", Length = 1, Description = "" },
			new OpCode { Name = "SET1", Length = 2, Description = "" },
			new OpCode { Name = "BBS", Length = 3, InstructionType = InstructionTypes.Branch, ParameterType = ParameterTypes.Absolute, Parameter2Type = ParameterTypes.Relative, Description = "" },
			new OpCode { Name = "CMP", Length = 2, Description = "" },
			new OpCode { Name = "CMP", Length = 3, Description = "" },
			new OpCode { Name = "CMP", Length = 1, Description = "" },
			new OpCode { Name = "CMP", Length = 2, Description = "" },

			new OpCode { Name = "CMP", Length = 2, Description = "" },
			new OpCode { Name = "CMP", Length = 3, Description = "" },
			new OpCode { Name = "AND1", Length = 3, Description = "" },
			new OpCode { Name = "ROR", Length = 2, Description = "" },
			new OpCode { Name = "ROR", Length = 3, Description = "" },
			new OpCode { Name = "PUSH", Length = 1, Description = "" },
			new OpCode { Name = "DBNZ", Length = 3, InstructionType = InstructionTypes.Branch, ParameterType = ParameterTypes.Absolute, Parameter2Type = ParameterTypes.Relative, Description = "" },
			new OpCode { Name = "RET", Length = 1, InstructionType = InstructionTypes.Return, Description = "" },

			// 0x70
			new OpCode { Name = "BVS", Length = 2, InstructionType = InstructionTypes.Branch, ParameterType = ParameterTypes.Relative, Description = "" },
			new OpCode { Name = "TCALL", Length = 1, Description = "" },
			new OpCode { Name = "CLR1", Length = 2, Description = "" },
			new OpCode { Name = "BBC", Length = 3, InstructionType = InstructionTypes.Branch, ParameterType = ParameterTypes.Absolute, Parameter2Type = ParameterTypes.Relative, Description = "" },
			new OpCode { Name = "CMP", Length = 2, Description = "" },
			new OpCode { Name = "CMP", Length = 3, Description = "" },
			new OpCode { Name = "CMP", Length = 3, Description = "" },
			new OpCode { Name = "CMP", Length = 2, Description = "" },

			new OpCode { Name = "CMP", Length = 3, Description = "" },
			new OpCode { Name = "CMP", Length = 1, Description = "" },
			new OpCode { Name = "ADDW", Length = 2, Description = "" },
			new OpCode { Name = "ROR", Length = 2, Description = "" },
			new OpCode { Name = "ROR", Length = 1, Description = "" },
			new OpCode { Name = "MOV", Length = 1, Description = "" },
			new OpCode { Name = "CMP", Length = 2, Description = "" },
			new OpCode { Name = "RETI", Length = 1, InstructionType = InstructionTypes.Return, Description = "" },

			// 0x80
			new OpCode { Name = "SETC", Length = 1, Description = "" },
			new OpCode { Name = "TCALL", Length = 1, Description = "" },
			new OpCode { Name = "SET1", Length = 2, Description = "" },
			new OpCode { Name = "BBS", Length = 3, InstructionType = InstructionTypes.Branch, ParameterType = ParameterTypes.Absolute, Parameter2Type = ParameterTypes.Relative, Description = "" },
			new OpCode { Name = "ADC", Length = 2, Description = "" },
			new OpCode { Name = "ADC", Length = 3, Description = "" },
			new OpCode { Name = "ADC", Length = 1, Description = "" },
			new OpCode { Name = "ADC", Length = 2, Description = "" },

			new OpCode { Name = "ADC", Length = 2, Description = "" },
			new OpCode { Name = "ADC", Length = 3, Description = "" },
			new OpCode { Name = "EOR1", Length = 3, Description = "" },
			new OpCode { Name = "DEC", Length = 2, Description = "" },
			new OpCode { Name = "DEC", Length = 3, Description = "" },
			new OpCode { Name = "MOV", Length = 2, Description = "" },
			new OpCode { Name = "POP", Length = 1, Description = "" },
			new OpCode { Name = "MOV", Length = 3, Description = "" },

			// 0x90
			new OpCode { Name = "BCC", Length = 2, InstructionType = InstructionTypes.Branch, ParameterType = ParameterTypes.Relative, Description = "" },
			new OpCode { Name = "TCALL", Length = 1, Description = "" },
			new OpCode { Name = "CLR1", Length = 2, Description = "" },
			new OpCode { Name = "BBC", Length = 3, InstructionType = InstructionTypes.Branch, ParameterType = ParameterTypes.Absolute, Parameter2Type = ParameterTypes.Relative, Description = "" },
			new OpCode { Name = "ADC", Length = 2, Description = "" },
			new OpCode { Name = "ADC", Length = 3, Description = "" },
			new OpCode { Name = "ADC", Length = 3, Description = "" },
			new OpCode { Name = "ADC", Length = 2, Description = "" },

			new OpCode { Name = "ADC", Length = 3, Description = "" },
			new OpCode { Name = "ADC", Length = 2, Description = "" },
			new OpCode { Name = "SUBW", Length = 2, Description = "" },
			new OpCode { Name = "DEC", Length = 2, Description = "" },
			new OpCode { Name = "DEC", Length = 1, Description = "" },
			new OpCode { Name = "MOV", Length = 1, Description = "" },
			new OpCode { Name = "DIV", Length = 1, Description = "" },
			new OpCode { Name = "XCN", Length = 1, Description = "" },

			// 0xA0
			new OpCode { Name = "EI", Length = 1, Description = "" },
			new OpCode { Name = "TCALL", Length = 1, Description = "" },
			new OpCode { Name = "SET1", Length = 2, Description = "" },
			new OpCode { Name = "BBS", Length = 3, InstructionType = InstructionTypes.Branch, ParameterType = ParameterTypes.Absolute, Parameter2Type = ParameterTypes.Relative, Description = "" },
			new OpCode { Name = "SBC", Length = 2, Description = "" },
			new OpCode { Name = "SBC", Length = 3, Description = "" },
			new OpCode { Name = "SBC", Length = 1, Description = "" },
			new OpCode { Name = "SBC", Length = 2, Description = "" },

			new OpCode { Name = "SBC", Length = 2, Description = "" },
			new OpCode { Name = "SBC", Length = 3, Description = "" },
			new OpCode { Name = "MOV1", Length = 3, Description = "" },
			new OpCode { Name = "INC", Length = 2, Description = "" },
			new OpCode { Name = "INC", Length = 3, Description = "" },
			new OpCode { Name = "CMP", Length = 2, Description = "" },
			new OpCode { Name = "POP", Length = 1, Description = "" },
			new OpCode { Name = "MOV", Length = 3, Description = "" },

			// 0xB0
			new OpCode { Name = "BCS", Length = 2, InstructionType = InstructionTypes.Branch, ParameterType = ParameterTypes.Relative, Description = "" },
			new OpCode { Name = "TCALL", Length = 1, Description = "" },
			new OpCode { Name = "CLR1", Length = 2, Description = "" },
			new OpCode { Name = "BBC", Length = 3, InstructionType = InstructionTypes.Branch, ParameterType = ParameterTypes.Absolute, Parameter2Type = ParameterTypes.Relative, Description = "" },
			new OpCode { Name = "SBC", Length = 2, Description = "" },
			new OpCode { Name = "SBC", Length = 3, Description = "" },
			new OpCode { Name = "SBC", Length = 3, Description = "" },
			new OpCode { Name = "SBC", Length = 2, Description = "" },

			new OpCode { Name = "SBC", Length = 3, Description = "" },
			new OpCode { Name = "SBC", Length = 1, Description = "" },
			new OpCode { Name = "MOVW", Length = 2, Description = "" },
			new OpCode { Name = "INC", Length = 2, Description = "" },
			new OpCode { Name = "INC", Length = 1, Description = "" },
			new OpCode { Name = "MOV", Length = 1, Description = "" },
			new OpCode { Name = "DAS", Length = 1, Description = "" },
			new OpCode { Name = "MOV", Length = 1, Description = "" },

			// 0xC0
			new OpCode { Name = "DI", Length = 1, Description = "" },
			new OpCode { Name = "TCALL", Length = 1, Description = "" },
			new OpCode { Name = "SET1", Length = 2, Description = "" },
			new OpCode { Name = "BBS", Length = 3, InstructionType = InstructionTypes.Branch, ParameterType = ParameterTypes.Absolute, Parameter2Type = ParameterTypes.Relative, Description = "" },
			new OpCode { Name = "MOV", Length = 2, Source = InstructionTargets.A, Destination = InstructionTargets.Variable, Description = "" },
			new OpCode { Name = "MOV", Length = 3, Source = InstructionTargets.A, Destination = InstructionTargets.Variable, Description = "" },
			new OpCode { Name = "MOV", Length = 1, Source = InstructionTargets.A, Destination = InstructionTargets.Table, Description = "" },
			new OpCode { Name = "MOV", Length = 2, Source = InstructionTargets.A, Destination = InstructionTargets.None, Description = "" },

			new OpCode { Name = "CMP", Length = 2, Description = "" },
			new OpCode { Name = "MOV", Length = 3, Source = InstructionTargets.None, Destination = InstructionTargets.None, Description = "" },
			new OpCode { Name = "MOV1", Length = 3, Description = "" },
			new OpCode { Name = "MOV", Length = 2, Source = InstructionTargets.None, Destination = InstructionTargets.None, Description = "" },
			new OpCode { Name = "MOV", Length = 3, Source = InstructionTargets.None, Destination = InstructionTargets.None, Description = "" },
			new OpCode { Name = "MOV", Length = 2, Source = InstructionTargets.None, Destination = InstructionTargets.None, Description = "" },
			new OpCode { Name = "POP", Length = 1, Description = "" },
			new OpCode { Name = "MUL", Length = 1, Description = "" },

			// 0xD0
			new OpCode { Name = "BNE", Length = 2, InstructionType = InstructionTypes.Branch, ParameterType = ParameterTypes.Relative, Description = "" },
			new OpCode { Name = "TCALL", Length = 1, Description = "" },
			new OpCode { Name = "CLR1", Length = 2, Description = "" },
			new OpCode { Name = "BBC", Length = 3, InstructionType = InstructionTypes.Branch, ParameterType = ParameterTypes.Absolute, Parameter2Type = ParameterTypes.Relative, Description = "" },
			new OpCode { Name = "MOV", Length = 2, Source = InstructionTargets.None, Destination = InstructionTargets.None, Description = "" },
			new OpCode { Name = "MOV", Length = 3, Source = InstructionTargets.None, Destination = InstructionTargets.None, Description = "" },
			new OpCode { Name = "MOV", Length = 3, Source = InstructionTargets.None, Destination = InstructionTargets.None, Description = "" },
			new OpCode { Name = "MOV", Length = 2, Source = InstructionTargets.None, Destination = InstructionTargets.None, Description = "" },

			new OpCode { Name = "MOV", Length = 2, Source = InstructionTargets.None, Destination = InstructionTargets.None, Description = "" },
			new OpCode { Name = "MOV", Length = 2, Source = InstructionTargets.None, Destination = InstructionTargets.None, Description = "" },
			new OpCode { Name = "MOVW", Length = 2, Source = InstructionTargets.None, Destination = InstructionTargets.None, Description = "" },
			new OpCode { Name = "MOV", Length = 2, Source = InstructionTargets.None, Destination = InstructionTargets.None, Description = "" },
			new OpCode { Name = "DEC", Length = 1, Description = "" },
			new OpCode { Name = "MOV", Length = 1, Source = InstructionTargets.None, Destination = InstructionTargets.None, Description = "" },
			new OpCode { Name = "CBNE", Length = 3, InstructionType = InstructionTypes.Branch, ParameterType = ParameterTypes.Absolute, Parameter2Type = ParameterTypes.Relative, Description = "" },
			new OpCode { Name = "DAA", Length = 1, Description = "" },

			// 0xE0
			new OpCode { Name = "CLRV", Length = 1, Description = "" },
			new OpCode { Name = "TCALL", Length = 1, Description = "" },
			new OpCode { Name = "SET1", Length = 2, Description = "" },
			new OpCode { Name = "BBS", Length = 3, InstructionType = InstructionTypes.Branch, ParameterType = ParameterTypes.Absolute, Parameter2Type = ParameterTypes.Relative, Description = "" },
			new OpCode { Name = "MOV", Length = 2, Source = InstructionTargets.None, Destination = InstructionTargets.None, Description = "" },
			new OpCode { Name = "MOV", Length = 3, Source = InstructionTargets.None, Destination = InstructionTargets.None, Description = "" },
			new OpCode { Name = "MOV", Length = 1, Source = InstructionTargets.None, Destination = InstructionTargets.None, Description = "" },
			new OpCode { Name = "MOV", Length = 2, Source = InstructionTargets.None, Destination = InstructionTargets.None, Description = "" },

			new OpCode { Name = "MOV", Length = 2, Source = InstructionTargets.None, Destination = InstructionTargets.None, Description = "" },
			new OpCode { Name = "MOV", Length = 3, Source = InstructionTargets.None, Destination = InstructionTargets.None, Description = "" },
			new OpCode { Name = "NOT1", Length = 3, Description = "" },
			new OpCode { Name = "MOV", Length = 2, Source = InstructionTargets.None, Destination = InstructionTargets.None, Description = "" },
			new OpCode { Name = "MOV", Length = 3, Source = InstructionTargets.None, Destination = InstructionTargets.None, Description = "" },
			new OpCode { Name = "NOTC", Length = 1, Description = "" },
			new OpCode { Name = "POP", Length = 1, Description = "" },
			new OpCode { Name = "SLEEP", Length = 1, Description = "" },

			// 0xF0
			new OpCode { Name = "BEQ", Length = 2, InstructionType = InstructionTypes.Branch, ParameterType = ParameterTypes.Relative, Description = "" },
			new OpCode { Name = "TCALL", Length = 1, Description = "" },
			new OpCode { Name = "CLR1", Length = 2, Description = "" },
			new OpCode { Name = "BBC", Length = 3, InstructionType = InstructionTypes.Branch, ParameterType = ParameterTypes.Absolute, Parameter2Type = ParameterTypes.Relative, Description = "" },
			new OpCode { Name = "MOV", Length = 2, Source = InstructionTargets.None, Destination = InstructionTargets.None, Description = "" },
			new OpCode { Name = "MOV", Length = 3, Source = InstructionTargets.None, Destination = InstructionTargets.None, Description = "" },
			new OpCode { Name = "MOV", Length = 3, Source = InstructionTargets.None, Destination = InstructionTargets.None, Description = "" },
			new OpCode { Name = "MOV", Length = 2, Source = InstructionTargets.None, Destination = InstructionTargets.None, Description = "" },

			new OpCode { Name = "MOV", Length = 2, Source = InstructionTargets.None, Destination = InstructionTargets.None, Description = "" },
			new OpCode { Name = "MOV", Length = 2, Source = InstructionTargets.None, Destination = InstructionTargets.None, Description = "" },
			new OpCode { Name = "MOV", Length = 3, Source = InstructionTargets.None, Destination = InstructionTargets.None, Description = "" },
			new OpCode { Name = "MOV", Length = 2, Source = InstructionTargets.None, Destination = InstructionTargets.None, Description = "" },
			new OpCode { Name = "INC", Length = 1, Description = "" },
			new OpCode { Name = "MOV", Length = 1, Source = InstructionTargets.None, Destination = InstructionTargets.None, Description = "" },
			new OpCode { Name = "DBNZ", Length = 2, InstructionType = InstructionTypes.Branch, ParameterType = ParameterTypes.Relative, Description = "" },
			new OpCode { Name = "STOP", Length = 1, Description = "" },
		};
	}
}
