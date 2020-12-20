using System;
using System.Collections.Generic;
using System.Linq;

namespace SpcDisassembler
{
	internal class AssemblyConsole
	{
		internal static void Write(List<ProgramConsole.Function> functions)
		{
			for (var x = 0; x < functions.Count; x++)
			{
				var function = functions[x];

				Label(function);

				foreach (var instruction in function.Instructions)
				{
					if (instruction.Address != function.Address &&
						functions.Any(x => x.Address == instruction.Address))
						break;

					var opCode = InstructionReader.OpCodes[instruction.Code];

					Indent();
					Address(instruction);
					Code(instruction);
					Mnemonic(opCode);
					Parameter(instruction, opCode);

					Console.WriteLine();

				}

				Console.WriteLine();
			}
		}

		internal static void Label(ProgramConsole.Function function)
		{
			Console.WriteLine(function.Address.ToString("X6") + ":");
		}

		internal static void Indent()
		{
			Console.Write("\t");
		}

		internal static void Address(FunctionReader.Instruction instruction)
		{
			Console.Write(instruction.Address.ToString("X6") + " ");
		}

		internal static void Code(FunctionReader.Instruction instruction)
		{
			Console.Write(instruction.Code.ToString("X2") + " ");
		}

		internal static void Mnemonic(InstructionReader.OpCode opCode)
		{
			Console.Write(opCode.Name + " ");
		}

		internal static void Parameter(FunctionReader.Instruction instruction, InstructionReader.OpCode opCode)
		{
			switch (instruction.Length)
			{
				case 1:
					break;

				case 2:
					Console.Write(instruction.Parameter.ToString("X2"));
					break;

				case 3:
					Console.Write(instruction.Parameter.ToString("X4"));
					break;
			}
		}

		internal static void Symbol(FunctionReader.Instruction instruction, InstructionReader.OpCode opCode)
		{
			if (instruction.Length == 1)
				return;

			switch (opCode.InstructionType)
			{
				default:
					//Console.Write("$");
					break;
			}
		}

		internal static void Index(InstructionReader.OpCode opCode)
		{
			//if (opCode.Index != InstructionReader.IndexRegister.None)
			//	Console.Write(", " + opCode.Index);
		}
	}
}