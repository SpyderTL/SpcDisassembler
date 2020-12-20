using System;
using System.Collections.Generic;
using System.Text;

namespace SpcDisassembler
{
	internal static class FunctionReader
	{
		internal static Branch[] Branches;
		internal static Instruction[] Instructions;

		internal static void Read()
		{
			var branches = new List<Branch>();
			var instructions = new List<Instruction>();

			var reading = true;

			while (reading)
			{
				InstructionReader.Read();

				switch (InstructionReader.InstructionType)
				{
					case InstructionReader.InstructionTypes.Branch:
						if (InstructionReader.Parameter2Type != InstructionReader.ParameterTypes.Relative)
						{
							instructions.Add(new Instruction { Address = InstructionReader.Address, Length = InstructionReader.Length, Code = InstructionReader.Code, Parameter = InstructionReader.Position + InstructionReader.Parameter });
							branches.Add(new Branch { Address = InstructionReader.Position + InstructionReader.Parameter, Flags = InstructionReader.Flags });
						}
						else
						{
							instructions.Add(new Instruction { Address = InstructionReader.Address, Length = InstructionReader.Length, Code = InstructionReader.Code, Parameter = InstructionReader.Parameter, Parameter2 = InstructionReader.Position + InstructionReader.Parameter2 });
							branches.Add(new Branch { Address = InstructionReader.Position + InstructionReader.Parameter2, Flags = InstructionReader.Flags });
						}
						break;

					case InstructionReader.InstructionTypes.Call:
						instructions.Add(new Instruction { Address = InstructionReader.Address, Length = InstructionReader.Length, Code = InstructionReader.Code, Parameter = InstructionReader.Parameter });
						branches.Add(new Branch { Address = InstructionReader.Parameter, Flags = InstructionReader.Flags });
						break;

					case InstructionReader.InstructionTypes.Jump:
						if (InstructionReader.ParameterType == InstructionReader.ParameterTypes.Relative)
						{
							instructions.Add(new Instruction { Address = InstructionReader.Address, Length = InstructionReader.Length, Code = InstructionReader.Code, Parameter = InstructionReader.Position + InstructionReader.Parameter });
							branches.Add(new Branch { Address = InstructionReader.Position + InstructionReader.Parameter, Flags = InstructionReader.Flags });
						}
						else if (InstructionReader.Code == 0x1F)
						{
							instructions.Add(new Instruction { Address = InstructionReader.Address, Length = InstructionReader.Length, Code = InstructionReader.Code, Parameter = InstructionReader.Parameter });
						}
						else
						{
							instructions.Add(new Instruction { Address = InstructionReader.Address, Length = InstructionReader.Length, Code = InstructionReader.Code, Parameter = InstructionReader.Parameter });
							branches.Add(new Branch { Address = InstructionReader.Parameter, Flags = InstructionReader.Flags });
						}

						reading = false;
						break;

					case InstructionReader.InstructionTypes.Return:
						instructions.Add(new Instruction { Address = InstructionReader.Address, Length = InstructionReader.Length, Code = InstructionReader.Code, Parameter = InstructionReader.Parameter });
						reading = false;
						break;

					default:
						instructions.Add(new Instruction { Address = InstructionReader.Address, Length = InstructionReader.Length, Code = InstructionReader.Code, Parameter = InstructionReader.Parameter });
						break;
				}

				if (InstructionReader.OpCodes[InstructionReader.Code].Name == "BRK")
					reading = false;
				else if (InstructionReader.OpCodes[InstructionReader.Code].Name == "SLEEP")
					reading = false;
				else if (InstructionReader.OpCodes[InstructionReader.Code].Name == "STOP")
					reading = false;
				else if (InstructionReader.OpCodes[InstructionReader.Code].Name == "NOP")
					reading = false;
			}

			Branches = branches.ToArray();
			Instructions = instructions.ToArray();
		}

		internal struct Instruction
		{
			internal int Address;
			internal int Length;
			internal int Code;
			internal int Parameter;
			internal int Parameter2;
		}

		internal struct Branch
		{
			internal int Address;
			internal int Flags;
		}
	}
}
