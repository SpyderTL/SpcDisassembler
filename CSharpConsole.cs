using System;
using System.Collections.Generic;
using System.Linq;

namespace SpcDisassembler
{
	internal class CSharpConsole
	{
		internal static void Write(List<ProgramConsole.Function> functions)
		{
			Console.WriteLine("public class ApuProgram");
			Console.WriteLine("{");

			for (var x = 0; x < functions.Count; x++)
			{
				var function = functions[x];

				Function(function);

				foreach (var instruction in function.Instructions)
				{
					if (instruction.Address != function.Address &&
						functions.Any(x => x.Address == instruction.Address))
						break;

					var opCode = InstructionReader.OpCodes[instruction.Code];

					Indent();
					Indent();

					//Address(instruction);
					//Code(instruction);
					//Mnemonic(opCode);
					//Parameter(instruction, opCode);

					//Console.WriteLine();
					//Indent();
					//Indent();
					Instruction(instruction, opCode);

					Console.WriteLine();
				}

				Indent();
				Console.WriteLine("}");

				Console.WriteLine();
			}

			Console.WriteLine("}");
		}

		private static void Function(ProgramConsole.Function function)
		{
			Indent();
			Console.WriteLine("public void L" + function.Address.ToString("X4") + "()");
			Indent();
			Console.WriteLine("{");
		}

		private static void Indent()
		{
			Console.Write("\t");
		}

		private static void Instruction(FunctionReader.Instruction instruction, InstructionReader.OpCode opCode)
		{
			switch (instruction.Code)
			{
				case 0x01:
					Console.Write("[0xFFDE]();");
					break;

				case 0x11:
					Console.Write("[0xFFDC]();");
					break;

				case 0x21:
					Console.Write("[0xFFDA]();");
					break;

				case 0x31:
					Console.Write("[0xFFD8]();");
					break;

				case 0x41:
					Console.Write("[0xFFD6]();");
					break;

				case 0x51:
					Console.Write("[0xFFD4]();");
					break;

				case 0x61:
					Console.Write("[0xFFD2]();");
					break;

				case 0x71:
					Console.Write("[0xFFD0]();");
					break;

				case 0x81:
					Console.Write("[0xFFCE]();");
					break;

				case 0x91:
					Console.Write("[0xFFCC]();");
					break;

				case 0xA1:
					Console.Write("[0xFFCA]();");
					break;

				case 0xB1:
					Console.Write("[0xFFC8]();");
					break;

				case 0xC1:
					Console.Write("[0xFFC6]();");
					break;

				case 0xD1:
					Console.Write("[0xFFC4]();");
					break;

				case 0xE1:
					Console.Write("[0xFFC2]();");
					break;

				case 0xF1:
					Console.Write("[0xFFC0]();");
					break;

				case 0x02:
					Console.Write("[0x" + instruction.Parameter.ToString("X2") + "] |= 0x01;");
					break;

				case 0x12:
					Console.Write("[0x" + instruction.Parameter.ToString("X2") + "] &= ~0x01;");
					break;

				case 0x32:
					Console.Write("[0x" + instruction.Parameter.ToString("X2") + "] &= ~0x02;");
					break;

				case 0x52:
					Console.Write("[0x" + instruction.Parameter.ToString("X2") + "] &= ~0x04;");
					break;

				case 0x72:
					Console.Write("[0x" + instruction.Parameter.ToString("X2") + "] &= ~0x08;");
					break;

				case 0x92:
					Console.Write("[0x" + instruction.Parameter.ToString("X2") + "] &= ~0x10;");
					break;

				case 0xB2:
					Console.Write("[0x" + instruction.Parameter.ToString("X2") + "] &= ~0x20;");
					break;

				case 0xD2:
					Console.Write("[0x" + instruction.Parameter.ToString("X2") + "] &= ~0x40;");
					break;

				case 0xF2:
					Console.Write("[0x" + instruction.Parameter.ToString("X2") + "] &= ~0x80;");
					break;

				case 0x22:
					Console.Write("[0x" + instruction.Parameter.ToString("X2") + "] |= 0x02;");
					break;

				case 0x42:
					Console.Write("[0x" + instruction.Parameter.ToString("X2") + "] |= 0x04;");
					break;

				case 0x62:
					Console.Write("[0x" + instruction.Parameter.ToString("X2") + "] |= 0x08;");
					break;

				case 0x82:
					Console.Write("[0x" + instruction.Parameter.ToString("X2") + "] |= 0x10;");
					break;

				case 0xA2:
					Console.Write("[0x" + instruction.Parameter.ToString("X2") + "] |= 0x20;");
					break;

				case 0xC2:
					Console.Write("[0x" + instruction.Parameter.ToString("X2") + "] |= 0x40;");
					break;

				case 0xE2:
					Console.Write("[0x" + instruction.Parameter.ToString("X2") + "] |= 0x80;");
					break;

				case 0x03:
					Console.WriteLine();
					Indent();
					Indent();
					Console.WriteLine("if (([0x" + instruction.Parameter.ToString("X2") + "] & 0x01) != 0)");
					Indent();
					Indent();
					Indent();
					Console.WriteLine("return this.L" + instruction.Parameter2.ToString("X4") + "();");
					break;

				case 0x23:
					Console.WriteLine();
					Indent();
					Indent();
					Console.WriteLine("if (([0x" + instruction.Parameter.ToString("X2") + "] & 0x02) != 0)");
					Indent();
					Indent();
					Indent();
					Console.WriteLine("return this.L" + instruction.Parameter2.ToString("X4") + "();");
					break;

				case 0x43:
					Console.WriteLine();
					Indent();
					Indent();
					Console.WriteLine("if (([0x" + instruction.Parameter.ToString("X2") + "] & 0x04) != 0)");
					Indent();
					Indent();
					Indent();
					Console.WriteLine("return this.L" + instruction.Parameter2.ToString("X4") + "();");
					break;

				case 0x63:
					Console.WriteLine();
					Indent();
					Indent();
					Console.WriteLine("if (([0x" + instruction.Parameter.ToString("X2") + "] & 0x08) != 0)");
					Indent();
					Indent();
					Indent();
					Console.WriteLine("return this.L" + instruction.Parameter2.ToString("X4") + "();");
					break;

				case 0x83:
					Console.WriteLine();
					Indent();
					Indent();
					Console.WriteLine("if (([0x" + instruction.Parameter.ToString("X2") + "] & 0x10) != 0)");
					Indent();
					Indent();
					Indent();
					Console.WriteLine("return this.L" + instruction.Parameter2.ToString("X4") + "();");
					break;

				case 0xA3:
					Console.WriteLine();
					Indent();
					Indent();
					Console.WriteLine("if (([0x" + instruction.Parameter.ToString("X2") + "] & 0x20) != 0)");
					Indent();
					Indent();
					Indent();
					Console.WriteLine("return this.L" + instruction.Parameter2.ToString("X4") + "();");
					break;

				case 0xC3:
					Console.WriteLine("if (([0x" + instruction.Parameter.ToString("X2") + "] & 0x40) != 0)");
					Indent();
					Indent();
					Indent();
					Console.WriteLine("return this.L" + instruction.Parameter2.ToString("X4") + "();");
					break;

				case 0xE3:
					Console.WriteLine();
					Indent();
					Indent();
					Console.WriteLine("if (([0x" + instruction.Parameter.ToString("X2") + "] & 0x80) != 0)");
					Indent();
					Indent();
					Indent();
					Console.WriteLine("return this.L" + instruction.Parameter2.ToString("X4") + "();");
					break;

				case 0x13:
					Console.WriteLine();
					Indent();
					Indent();
					Console.WriteLine("if (([0x" + instruction.Parameter.ToString("X2") + "] & 0x01) == 0)");
					Indent();
					Indent();
					Indent();
					Console.WriteLine("return this.L" + instruction.Parameter2.ToString("X4") + "();");
					break;

				case 0x33:
					Console.WriteLine();
					Indent();
					Indent();
					Console.WriteLine("if (([0x" + instruction.Parameter.ToString("X2") + "] & 0x02) == 0)");
					Indent();
					Indent();
					Indent();
					Console.WriteLine("return this.L" + instruction.Parameter2.ToString("X4") + "();");
					break;

				case 0x53:
					Console.WriteLine();
					Indent();
					Indent();
					Console.WriteLine("if (([0x" + instruction.Parameter.ToString("X2") + "] & 0x04) == 0)");
					Indent();
					Indent();
					Indent();
					Console.WriteLine("return this.L" + instruction.Parameter2.ToString("X4") + "();");
					break;

				case 0x73:
					Console.WriteLine();
					Indent();
					Indent();
					Console.WriteLine("if (([0x" + instruction.Parameter.ToString("X2") + "] & 0x08) == 0)");
					Indent();
					Indent();
					Indent();
					Console.WriteLine("return this.L" + instruction.Parameter2.ToString("X4") + "();");
					break;

				case 0x93:
					Console.WriteLine();
					Indent();
					Indent();
					Console.WriteLine("if (([0x" + instruction.Parameter.ToString("X2") + "] & 0x10) == 0)");
					Indent();
					Indent();
					Indent();
					Console.WriteLine("return this.L" + instruction.Parameter2.ToString("X4") + "();");
					break;

				case 0xB3:
					Console.WriteLine();
					Indent();
					Indent();
					Console.WriteLine("if (([0x" + instruction.Parameter.ToString("X2") + "] & 0x20) == 0)");
					Indent();
					Indent();
					Indent();
					Console.WriteLine("return this.L" + instruction.Parameter2.ToString("X4") + "();");
					break;

				case 0xD3:
					Console.WriteLine();
					Indent();
					Indent();
					Console.WriteLine("if (([0x" + instruction.Parameter.ToString("X2") + "] & 0x40) == 0)");
					Indent();
					Indent();
					Indent();
					Console.WriteLine("return this.L" + instruction.Parameter2.ToString("X4") + "();");
					break;

				case 0xF3:
					Console.WriteLine();
					Indent();
					Indent();
					Console.WriteLine("if (([0x" + instruction.Parameter.ToString("X2") + "] & 0x80) == 0)");
					Indent();
					Indent();
					Indent();
					Console.WriteLine("return this.L" + instruction.Parameter2.ToString("X4") + "();");
					break;

				case 0x0B:
					Console.Write("[");
					Parameter(instruction);
					Console.Write("] <<= 1;");
					break;

				case 0x0C:
					Console.Write("[");
					Parameter(instruction);
					Console.Write("] <<= 1;");
					break;

				case 0x4C:
					Console.Write("[");
					Parameter(instruction);
					Console.Write("] <<= 1;");
					break;

				case 0x1B:
					Console.Write("[");
					Parameter(instruction);
					Console.Write(" + X] <<= 1;");
					break;

				case 0x4B:
					Console.Write("[");
					Parameter(instruction);
					Console.Write("] <<= 1;");
					break;

				case 0x5B:
					Console.Write("[");
					Parameter(instruction);
					Console.Write(" + X] <<= 1;");
					break;

				case 0x1C:
					Console.Write("A <<= 1;");
					break;

				case 0x5C:
					Console.Write("A >>= 1;");
					break;

				case 0x06:
					Console.Write("A |= [X];");
					break;

				case 0x04:
					Console.Write("A |= [");
					Parameter(instruction);
					Console.Write("];");
					break;

				case 0x05:
					Console.Write("A |= [");
					Parameter(instruction);
					Console.Write("];");
					break;

				case 0x14:
					Console.Write("A |= [");
					Parameter(instruction);
					Console.Write(" + X];");
					break;

				case 0x15:
					Console.Write("A |= [");
					Parameter(instruction);
					Console.Write(" + X];");
					break;

				case 0x16:
					Console.Write("A |= [");
					Parameter(instruction);
					Console.Write(" + Y];");
					break;

				case 0x07:
					Console.Write("A |= [[");
					Parameter(instruction);
					Console.Write(" + X]];");
					break;

				case 0x08:
					Console.Write("A |= ");
					Parameter(instruction);
					Console.Write(";");
					break;

				case 0x09:
					Console.Write("[0x" + instruction.Parameter.ToString("X2") + "] |= [0x" + instruction.Parameter2.ToString("X2") + "];");
					break;

				case 0x17:
					Console.Write("A |= [[");
					Parameter(instruction);
					Console.Write("] + Y];");
					break;

				case 0x18:
					Console.Write("[0x" + instruction.Parameter.ToString("X2") + "] |= 0x" + instruction.Parameter2.ToString("X2") + ";");
					break;

				case 0x19:
					Console.Write("[X] |= [Y];");
					break;

				case 0x1E:
					Console.Write("C = 1; temp = X - [");
					Parameter(instruction);
					Console.Write("];");
					break;

				case 0x1F:
					Console.Write("return [");
					Parameter(instruction);
					Console.Write(" + X]();");
					break;

				case 0x20:
					Console.Write("D = 0;");
					break;

				case 0x24:
					Console.Write("A &= [0x" + instruction.Parameter.ToString("X2") + "];");
					break;

				case 0x25:
					Console.Write("A &= [0x" + instruction.Parameter.ToString("X2") + "];");
					break;

				case 0x26:
					Console.Write("A &= [X];");
					break;

				case 0x0A:
					Console.Write("C |= [0x" + instruction.Parameter.ToString("X2") + "] & (1 << " + instruction.Parameter2 + ")");
					break;

				case 0x2A:
					Console.Write("C |= ~([0x" + instruction.Parameter.ToString("X2") + "] & (1 << " + instruction.Parameter2 + "))");
					break;

				case 0x27:
					Console.Write("A &= [[0x" + instruction.Parameter.ToString("X2") + " + X]];");
					break;

				case 0x28:
					Console.Write("A &= 0x" + instruction.Parameter.ToString("X2") + ";");
					break;

				case 0x29:
					Console.Write("[0x" + instruction.Parameter.ToString("X2") + "] &= [0x" + instruction.Parameter2.ToString("X2") + "];");
					break;

				case 0x2F:
					Console.Write("return this.L" + instruction.Parameter.ToString("X4") + "();");
					break;

				case 0x34:
					Console.Write("A &= [0x" + instruction.Parameter.ToString("X2") + " + X];");
					break;

				case 0x35:
					Console.Write("A &= [0x" + instruction.Parameter.ToString("X2") + " + X];");
					break;

				case 0x36:
					Console.Write("A &= [0x" + instruction.Parameter.ToString("X2") + " + Y];");
					break;

				case 0x37:
					Console.Write("A &= [[0x" + instruction.Parameter.ToString("X2") + "] + Y];");
					break;

				case 0x38:
					Console.Write("[0x" + instruction.Parameter.ToString("X2") + "] &= 0x" + instruction.Parameter2.ToString("X2") + ";");
					break;

				case 0x39:
					Console.Write("[X] &= [Y];");
					break;

				case 0x2B:
					Console.Write("Cpu.ROL([");
					Parameter(instruction);
					Console.Write("]);");
					break;

				case 0x6B:
					Console.Write("Cpu.ROR([");
					Parameter(instruction);
					Console.Write("]);");
					break;

				case 0x2C:
					Console.Write("Cpu.ROL([");
					Parameter(instruction);
					Console.Write("]);");
					break;

				case 0x6C:
					Console.Write("Cpu.ROR([");
					Parameter(instruction);
					Console.Write("]);");
					break;

				case 0x3B:
					Console.Write("Cpu.ROL([");
					Parameter(instruction);
					Console.Write(" + X]);");
					break;

				case 0x7B:
					Console.Write("Cpu.ROR([");
					Parameter(instruction);
					Console.Write(" + X]);");
					break;

				case 0x3C:
					Console.Write("Cpu.ROL(A);");
					break;

				case 0x7C:
					Console.Write("Cpu.ROR(A);");
					break;

				case 0x3D:
					Console.Write("X++;");
					break;

				case 0x3E:
					Console.Write("C = 1; temp = X - [");
					Parameter(instruction);
					Console.Write("];");
					break;

				case 0x3F:
					Console.Write("this.L" + instruction.Parameter.ToString("X4") + "();");
					break;

				case 0x40:
					Console.Write("D = 1;");
					break;

				case 0x0E:
					Console.Write("temp = A - [");
					Parameter(instruction);
					Console.Write("]; [");
					Parameter(instruction);
					Console.Write("] |= A;");
					break;

				case 0x4E:
					Console.Write("temp = A - [");
					Parameter(instruction);
					Console.Write("]; [");
					Parameter(instruction);
					Console.Write("] &= ~A;");
					break;

				case 0x4F:
					Console.Write("LFF" + instruction.Parameter.ToString("X2") + "();");
					break;

				case 0x5A:
					Console.Write("C = 1; temp = YA - [");
					Parameter(instruction);
					Console.Write("];");
					break;

				case 0x46:
					Console.Write("A ^= [X];");
					break;

				case 0x44:
					Console.Write("A ^= [");
					Parameter(instruction);
					Console.Write("];");
					break;

				case 0x45:
					Console.Write("A ^= [");
					Parameter(instruction);
					Console.Write("];");
					break;

				case 0x54:
					Console.Write("A ^= [");
					Parameter(instruction);
					Console.Write(" + X];");
					break;

				case 0x55:
					Console.Write("A ^= [");
					Parameter(instruction);
					Console.Write(" + X];");
					break;

				case 0x56:
					Console.Write("A ^= [");
					Parameter(instruction);
					Console.Write(" + Y];");
					break;

				case 0x48:
					Console.Write("A ^= ");
					Parameter(instruction);
					Console.Write(";");
					break;

				case 0x47:
					Console.Write("A ^= [[");
					Parameter(instruction);
					Console.Write(" + X]];");
					break;

				case 0x57:
					Console.Write("A ^= [[");
					Parameter(instruction);
					Console.Write("] + Y];");
					break;

				case 0x59:
					Console.Write("[X] ^= [Y];");
					break;

				case 0x5D:
					Console.Write("X = A;");
					break;

				case 0x5E:
					Console.Write("C = 1; temp = Y - [");
					Parameter(instruction);
					Console.Write("];");
					break;

				case 0x5F:
					Console.Write("return this.L" + instruction.Parameter.ToString("X4") + "();");
					break;

				case 0x60:
					Console.Write("C = 0;");
					break;

				case 0x64:
					Console.Write("C = 1; temp = A - [");
					Parameter(instruction);
					Console.Write("];");
					break;

				case 0x65:
					Console.Write("C = 1; temp = A - [");
					Parameter(instruction);
					Console.Write("];");
					break;

				case 0x66:
					Console.Write("C = 1; temp = A - [X];");
					break;

				case 0x67:
					Console.Write("C = 1; temp = A - [[");
					Parameter(instruction);
					Console.Write(" + X]];");
					break;

				case 0x68:
					Console.Write("C = 1; temp = A - ");
					Parameter(instruction);
					Console.Write(";");
					break;

				case 0x69:
					Console.Write("C = 1; temp = [0x" + (instruction.Parameter & 0xff).ToString("X2") + "] - [0x" + (instruction.Parameter >> 8).ToString("X2") + "];");
					break;

				case 0x6A:
					Console.Write("C &= ~([0x" + instruction.Parameter.ToString("X2") + "] >> " + instruction.Parameter2 + ") & 0x01;");
					break;

				case 0x4A:
					Console.Write("C &= ([0x" + instruction.Parameter.ToString("X2") + "] >> " + instruction.Parameter2 + ") & 0x01;");
					break;

				case 0x6F:
					Console.Write("return;");
					break;

				case 0x74:
					Console.Write("C = 1; temp = A - [");
					Parameter(instruction);
					Console.Write(" + X];");
					break;

				case 0x75:
					Console.Write("C = 1; temp = A - [");
					Parameter(instruction);
					Console.Write(" + X];");
					break;

				case 0x76:
					Console.Write("C = 1; temp = A - [");
					Parameter(instruction);
					Console.Write(" + Y];");
					break;

				case 0x77:
					Console.Write("C = 1; temp = A - [[");
					Parameter(instruction);
					Console.Write("] + Y];");
					break;

				case 0x78:
					Console.Write("C = 1; temp = [0x + " + (instruction.Parameter & 0xff).ToString("X2") + "] - 0x" + (instruction.Parameter >> 8).ToString("X2") + ";");
					break;

				case 0x79:
					Console.Write("C = 1; temp = [X] - [Y];");
					break;

				case 0x7D:
					Console.Write("A = X;");
					break;

				case 0x7E:
					Console.Write("C = 1; temp = Y - [");
					Parameter(instruction);
					Console.Write("];");
					break;

				case 0x80:
					Console.Write("C = 1;");
					break;

				case 0x8D:
					Console.Write("Y = ");
					Parameter(instruction);
					Console.Write(";");
					break;

				case 0x8F:
					Console.Write("[0x" + (instruction.Parameter >> 8).ToString("X2") + "] = 0x" + (instruction.Parameter & 0xff).ToString("X2") + ";");
					break;

				case 0x90:
					Console.WriteLine();
					Indent();
					Indent();
					Console.WriteLine("if (C == 0)");
					Indent();
					Indent();
					Indent();
					Console.WriteLine("return this.L" + instruction.Parameter.ToString("X4") + "();");
					break;

				case 0x30:
					Console.WriteLine();
					Indent();
					Indent();
					Console.WriteLine("if (N == 1)");
					Indent();
					Indent();
					Indent();
					Console.WriteLine("return this.L" + instruction.Parameter.ToString("X4") + "();");
					break;

				case 0x10:
					Console.WriteLine();
					Indent();
					Indent();
					Console.WriteLine("if (N == 0)");
					Indent();
					Indent();
					Indent();
					Console.WriteLine("return this.L" + instruction.Parameter.ToString("X4") + "();");
					break;

				case 0x50:
					Console.WriteLine();
					Indent();
					Indent();
					Console.WriteLine("if (V == 0)");
					Indent();
					Indent();
					Indent();
					Console.WriteLine("return this.L" + instruction.Parameter.ToString("X4") + "();");
					break;

				case 0x70:
					Console.WriteLine();
					Indent();
					Indent();
					Console.WriteLine("if (V == 1)");
					Indent();
					Indent();
					Indent();
					Console.WriteLine("return this.L" + instruction.Parameter.ToString("X4") + "();");
					break;

				case 0x7A:
					Console.Write("YA += [");
					Parameter(instruction);
					Console.Write("] + C;");
					break;

				case 0x84:
					Console.Write("A += [");
					Parameter(instruction);
					Console.Write("] + C;");
					break;

				case 0x85:
					Console.Write("A += [");
					Parameter(instruction);
					Console.Write("] + C;");
					break;

				case 0x86:
					Console.Write("A += [X] + C;");
					break;

				case 0x87:
					Console.Write("A += [[");
					Parameter(instruction);
					Console.Write(" + X]] + C;");
					break;

				case 0x88:
					Console.Write("A += ");
					Parameter(instruction);
					Console.Write(" + C;");
					break;

				case 0x89:
					Console.Write("[0x" + instruction.Parameter.ToString("X2") + "] += [0x" + instruction.Parameter.ToString("X2") + "];");
					break;

				case 0x94:
					Console.Write("A += [");
					Parameter(instruction);
					Console.Write(" + X] + C;");
					break;

				case 0x95:
					Console.Write("A += [");
					Parameter(instruction);
					Console.Write(" + X] + C;");
					break;

				case 0x96:
					Console.Write("A += [");
					Parameter(instruction);
					Console.Write(" + Y] + C;");
					break;

				case 0x97:
					Console.Write("A += [[");
					Parameter(instruction);
					Console.Write("] + Y] + C;");
					break;

				case 0x49:
					Console.Write("[0x" + instruction.Parameter.ToString("X2") + "] ^= [0x" + instruction.Parameter2.ToString("X2") + "];");
					break;

				case 0x58:
					Console.Write("[0x" + instruction.Parameter.ToString("X2") + "] ^= 0x" + instruction.Parameter2.ToString("X2") + ";");
					break;

				case 0x98:
					Console.Write("[0x" + instruction.Parameter.ToString("X2") + "] += 0x" + instruction.Parameter2.ToString("X2") + ";");
					break;

				case 0x99:
					Console.Write("[X] += [Y] + C;");
					break;

				case 0x9A:
					Console.Write("YA -= [");
					Parameter(instruction);
					Console.Write("];");
					break;

				case 0x8B:
					Console.Write("[");
					Parameter(instruction);
					Console.Write("]--;");
					break;

				case 0x9B:
					Console.Write("[");
					Parameter(instruction);
					Console.Write(" + X]--;");
					break;

				case 0x8C:
					Console.Write("[");
					Parameter(instruction);
					Console.Write("]--;");
					break;

				case 0x1A:
					Console.Write("[");
					Parameter(instruction);
					Console.Write("]--;\t// 16-bit");
					break;

				case 0x9C:
					Console.Write("A--;");
					break;

				case 0x9E:
					Console.Write("A = YA / X; Y = YA % X;");
					break;

				case 0x9F:
					Console.Write("A = (A >> 4) | (A << 4);");
					break;

				case 0xDC:
					Console.Write("Y--;");
					break;

				case 0x1D:
					Console.Write("X--;");
					break;

				case 0xB9:
					Console.Write("[X] -= [Y] + !C;");
					break;

				case 0xA4:
					Console.Write("A -= [");
					Parameter(instruction);
					Console.Write("] + !C;");
					break;

				case 0xA5:
					Console.Write("A -= [");
					Parameter(instruction);
					Console.Write("] + !C;");
					break;

				case 0xB4:
					Console.Write("A -= [");
					Parameter(instruction);
					Console.Write(" + X] + !C;");
					break;

				case 0xB5:
					Console.Write("A -= [");
					Parameter(instruction);
					Console.Write(" + X] + !C;");
					break;

				case 0xB6:
					Console.Write("A -= [");
					Parameter(instruction);
					Console.Write(" + Y] + !C;");
					break;

				case 0xA6:
					Console.Write("A -= [X] + !C;");
					break;

				case 0xA8:
					Console.Write("A -= ");
					Parameter(instruction);
					Console.Write(" + !C;");
					break;

				case 0xA7:
					Console.Write("A -= [[");
					Parameter(instruction);
					Console.Write(" + X]] + !C;");
					break;

				case 0xA9:
					Console.Write("[0x" + instruction.Parameter.ToString("X2") + "] -= [0x" + instruction.Parameter2.ToString("X2") + "] + !C;");
					break;

				case 0xB7:
					Console.Write("A -= [[");
					Parameter(instruction);
					Console.Write("] + Y] + !C;");
					break;

				case 0xB8:
					Console.Write("[0x" + instruction.Parameter.ToString("X2") + "] -= 0x" + instruction.Parameter2.ToString("X2") + " + !C;");
					break;

				case 0x9D:
					Console.Write("X = S;");
					break;

				case 0xA0:
					Console.Write("I = 1;");
					break;

				case 0xAB:
					Console.Write("[");
					Parameter(instruction);
					Console.Write("]++;");
					break;

				case 0x3A:
					Console.Write("[");
					Parameter(instruction);
					Console.Write("]++;\t// 16-bit");
					break;

				case 0xAC:
					Console.Write("[");
					Parameter(instruction);
					Console.Write("]++;");
					break;

				case 0xAD:
					Console.Write("C = 1; temp = Y - ");
					Parameter(instruction);
					Console.Write(";");
					break;

				case 0x2D:
					Console.Write("Stack.Push(A);");
					break;

				case 0x0D:
					Console.Write("Stack.Push(P);");
					break;

				case 0x4D:
					Console.Write("Stack.Push(X);");
					break;

				case 0x6D:
					Console.Write("Stack.Push(Y);");
					break;

				case 0xAE:
					Console.Write("A = Stack.Pop();");
					break;

				case 0xCE:
					Console.Write("X = Stack.Pop();");
					break;

				case 0xEE:
					Console.Write("Y = Stack.Pop();");
					break;

				case 0x8E:
					Console.Write("P = Stack.Pop();");
					break;

				case 0xAF:
					Console.Write("Stack.Push(A);");
					break;

				case 0x8A:
					Console.Write("C ^= [0x" + (instruction.Parameter & 0x1fff).ToString("X4") + "] >> " + (instruction.Parameter >> 13).ToString() + " & 1;");
					break;

				case 0xAA:
					Console.Write("C = [0x" + (instruction.Parameter & 0x1fff).ToString("X4") + "] >> " + (instruction.Parameter >> 13).ToString() + " & 1;");
					break;

				case 0xB0:
					Console.WriteLine();
					Indent();
					Indent();
					Console.WriteLine("if (C == 1)");
					Indent();
					Indent();
					Indent();
					Console.WriteLine("return this.L" + instruction.Parameter.ToString("X4") + "();");
					break;

				case 0xBA:
					Console.Write("YA = [");
					Parameter(instruction);
					Console.Write("];");
					break;

				case 0xBB:
					Console.Write("[");
					Parameter(instruction);
					Console.Write(" + X]++;");
					break;

				case 0xBC:
					Console.Write("A++;");
					break;

				case 0xBD:
					Console.Write("S = X;");
					break;

				case 0xBF:
					Console.Write("A = [X++];");
					break;

				case 0xC0:
					Console.Write("I = 0;");
					break;

				case 0xC4:
					Console.Write("[");
					Parameter(instruction);
					Console.Write("] = A;");
					break;

				case 0xC5:
					Console.Write("[");
					Parameter(instruction);
					Console.Write("] = A;");
					break;

				case 0xC6:
					Console.Write("[X] = A;");
					break;

				case 0xC7:
					Console.Write("[[");
					Parameter(instruction);
					Console.Write(" + X]] = A;");
					break;

				case 0xC8:
					Console.Write("C = 1; temp = X - ");
					Parameter(instruction);
					Console.Write(";");
					break;

				case 0xC9:
					Console.Write("[");
					Parameter(instruction);
					Console.Write("] = X;");
					break;

				case 0xCA:
					Console.Write("[0x" + (instruction.Parameter & 0x1fff).ToString("X4") + "] |= C << " + (instruction.Parameter >> 13).ToString() + ";");
					break;

				case 0xCB:
					Console.Write("[");
					Parameter(instruction);
					Console.Write("] = Y;");
					break;

				case 0xCC:
					Console.Write("[");
					Parameter(instruction);
					Console.Write("] = Y;");
					break;

				case 0xCD:
					Console.Write("X = ");
					Parameter(instruction);
					Console.Write(";");
					break;

				case 0xCF:
					Console.Write("YA = Y * A;");
					break;

				case 0xD0:
					Console.WriteLine();
					Indent();
					Indent();
					Console.WriteLine("if (Z == 0)");
					Indent();
					Indent();
					Indent();
					Console.WriteLine("return this.L" + instruction.Parameter.ToString("X4") + "();");
					break;

				case 0xD4:
					Console.Write("[");
					Parameter(instruction);
					Console.Write(" + X] = A;");
					break;

				case 0xD5:
					Console.Write("[");
					Parameter(instruction);
					Console.Write(" + X] = A;");
					break;

				case 0xD6:
					Console.Write("[");
					Parameter(instruction);
					Console.Write(" + Y] = A;");
					break;

				case 0xD7:
					Console.Write("[[");
					Parameter(instruction);
					Console.Write("] + Y] = A;");
					break;

				case 0xD8:
					Console.Write("[");
					Parameter(instruction);
					Console.Write("] = X;");
					break;

				case 0xD9:
					Console.Write("[");
					Parameter(instruction);
					Console.Write(" + Y] = X;");
					break;

				case 0xDA:
					Console.Write("[");
					Parameter(instruction);
					Console.Write("] = YA;");
					break;

				case 0xDB:
					Console.Write("[");
					Parameter(instruction);
					Console.Write(" + X] = Y;");
					break;

				case 0xDE:
					Console.WriteLine();
					Indent();
					Indent();
					Console.WriteLine("C = 1; temp = A - [0x" + instruction.Parameter.ToString("X2") + " + X]; if (Z == 0)");
					Indent();
					Indent();
					Indent();
					Console.WriteLine("return this.L" + instruction.Parameter2.ToString("X4") + "();");
					break;

				case 0x2E:
					Console.WriteLine();
					Indent();
					Indent();
					Console.WriteLine("C = 1; temp = A - [0x" + instruction.Parameter.ToString("X2") + "]; if (Z == 0)");
					Indent();
					Indent();
					Indent();
					Console.WriteLine("return this.L" + instruction.Parameter2.ToString("X4") + "();");
					break;

				case 0xDD:
					Console.Write("A = Y;");
					break;

				case 0xE0:
					Console.Write("V = 0;");
					break;

				case 0xE4:
					Console.Write("A = [");
					Parameter(instruction);
					Console.Write("];");
					break;

				case 0xE5:
					Console.Write("A = [");
					Parameter(instruction);
					Console.Write("];");
					break;

				case 0xE6:
					Console.Write("A = [X];");
					break;

				case 0xE7:
					Console.Write("A = [");
					Parameter(instruction);
					Console.Write(" + X];");
					break;

				case 0xE8:
					Console.Write("A = ");
					Parameter(instruction);
					Console.Write(";");
					break;

				case 0xE9:
					Console.Write("X = [");
					Parameter(instruction);
					Console.Write("];");
					break;

				case 0xEA:
					Console.Write("[0x" + (instruction.Parameter & 0xfff).ToString("X4") + "] ^= (1 << " + (instruction.Parameter >> 13) + ");");
					break;

				case 0xEB:
					Console.Write("Y = [");
					Parameter(instruction);
					Console.Write("];");
					break;

				case 0xEC:
					Console.Write("Y = [");
					Parameter(instruction);
					Console.Write("];");
					break;

				case 0xED:
					Console.Write("C = !C;");
					break;

				case 0xF0:
					Console.WriteLine();
					Indent();
					Indent();
					Console.WriteLine("if (Z == 1)");
					Indent();
					Indent();
					Indent();
					Console.WriteLine("return this.L" + instruction.Parameter.ToString("X4") + "();");
					break;

				case 0xF4:
					Console.Write("A = [");
					Parameter(instruction);
					Console.Write(" + X];");
					break;

				case 0xF5:
					Console.Write("A = [");
					Parameter(instruction);
					Console.Write(" + X];");
					break;

				case 0xF6:
					Console.Write("A = [");
					Parameter(instruction);
					Console.Write(" + Y];");
					break;

				case 0xF7:
					Console.Write("A = [[");
					Parameter(instruction);
					Console.Write("] + Y];");
					break;

				case 0xF8:
					Console.Write("X = [");
					Parameter(instruction);
					Console.Write("];");
					break;

				case 0xF9:
					Console.Write("X = [");
					Parameter(instruction);
					Console.Write(" + Y];");
					break;

				case 0xFA:
					Console.Write("[0x" + (instruction.Parameter & 0xff).ToString("X2") + "] = [0x" + (instruction.Parameter >> 8).ToString("X2") + "];");
					break;

				case 0xFB:
					Console.Write("Y = [");
					Parameter(instruction);
					Console.Write(" + X];");
					break;

				case 0xFC:
					Console.Write("Y++;");
					break;

				case 0xFD:
					Console.Write("Y = A;");
					break;

				case 0x6E:
					Console.WriteLine();
					Indent();
					Indent();
					Console.Write("[");
					Parameter(instruction);
					Console.WriteLine("]--; if (Z == 0)");
					Indent();
					Indent();
					Indent();
					Console.WriteLine("return this.L" + instruction.Parameter2.ToString("X4") + "();");
					break;

				case 0xFE:
					Console.WriteLine();
					Indent();
					Indent();
					Console.WriteLine("Y--; if (Z == 0)");
					Indent();
					Indent();
					Indent();
					Console.WriteLine("return this.L" + instruction.Parameter.ToString("X4") + "();");
					break;

				default:
					Console.Write("Cpu." + opCode.Name + "();\t// 0x" + instruction.Code.ToString("X2"));
					break;
			}
		}

		private static void Address(FunctionReader.Instruction instruction)
		{
			Console.Write(instruction.Address.ToString("X4") + " ");
		}

		private static void Code(FunctionReader.Instruction instruction)
		{
			Console.Write("// " + instruction.Code.ToString("X2"));
		}

		private static void Parameter(FunctionReader.Instruction instruction)
		{
			if(instruction.Length == 2)
				Console.Write("0x" + instruction.Parameter.ToString("X2"));
			else
				Console.Write("0x" + instruction.Parameter.ToString("X4"));
		}

		private static void Mnemonic(InstructionReader.OpCode opCode)
		{
			Console.Write(opCode.Name + " ");
		}
	}
}