using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SpcDisassembler
{
	internal static class ProgramConsole
	{
		internal static void Start()
		{
			Apu.Memory = File.ReadAllBytes(Arguments.Source);

			var functions = new List<Function>();
			var branches = new List<FunctionReader.Branch>();

			branches.Add(new FunctionReader.Branch { Address = Arguments.Addresses[0], Flags = 0x00 });

			// Metal Combat APU
			//branches.Add(new FunctionReader.Branch { Address = 0x0922, Flags = 0x30 });
			//branches.Add(new FunctionReader.Branch { Address = 0x0982, Flags = 0x30 });
			//branches.Add(new FunctionReader.Branch { Address = 0x0990, Flags = 0x30 });
			//branches.Add(new FunctionReader.Branch { Address = 0x09A9, Flags = 0x30 });
			//branches.Add(new FunctionReader.Branch { Address = 0x09B5, Flags = 0x30 });
			//branches.Add(new FunctionReader.Branch { Address = 0x09D0, Flags = 0x30 });
			//branches.Add(new FunctionReader.Branch { Address = 0x09D5, Flags = 0x30 });
			//branches.Add(new FunctionReader.Branch { Address = 0x09EC, Flags = 0x30 });
			//branches.Add(new FunctionReader.Branch { Address = 0x09F1, Flags = 0x30 });
			//branches.Add(new FunctionReader.Branch { Address = 0x0A03, Flags = 0x30 });
			//branches.Add(new FunctionReader.Branch { Address = 0x0A06, Flags = 0x30 });
			//branches.Add(new FunctionReader.Branch { Address = 0x0A0A, Flags = 0x30 });
			//branches.Add(new FunctionReader.Branch { Address = 0x0A16, Flags = 0x30 });
			//branches.Add(new FunctionReader.Branch { Address = 0x0A37, Flags = 0x30 });
			//branches.Add(new FunctionReader.Branch { Address = 0x0A40, Flags = 0x30 });
			//branches.Add(new FunctionReader.Branch { Address = 0x0A5D, Flags = 0x30 });
			//branches.Add(new FunctionReader.Branch { Address = 0x09C0, Flags = 0x30 });
			//branches.Add(new FunctionReader.Branch { Address = 0x0A19, Flags = 0x30 });
			//branches.Add(new FunctionReader.Branch { Address = 0x0A1D, Flags = 0x30 });
			//branches.Add(new FunctionReader.Branch { Address = 0x0A33, Flags = 0x30 });
			//branches.Add(new FunctionReader.Branch { Address = 0x0A59, Flags = 0x30 });
			//branches.Add(new FunctionReader.Branch { Address = 0x0AA2, Flags = 0x30 });
			//branches.Add(new FunctionReader.Branch { Address = 0x0AE1, Flags = 0x30 });
			//branches.Add(new FunctionReader.Branch { Address = 0x0AE8, Flags = 0x30 });
			//branches.Add(new FunctionReader.Branch { Address = 0x0AC0, Flags = 0x30 });
			//branches.Add(new FunctionReader.Branch { Address = 0x0B63, Flags = 0x30 });
			//branches.Add(new FunctionReader.Branch { Address = 0x0B50, Flags = 0x30 });
			//branches.Add(new FunctionReader.Branch { Address = 0x0A80, Flags = 0x30 });
			//branches.Add(new FunctionReader.Branch { Address = 0x0A90, Flags = 0x30 });
			//branches.Add(new FunctionReader.Branch { Address = 0x0B96, Flags = 0x30 });
			//branches.Add(new FunctionReader.Branch { Address = 0x0B9C, Flags = 0x30 });
			//branches.Add(new FunctionReader.Branch { Address = 0x088C, Flags = 0x30 });
			//branches.Add(new FunctionReader.Branch { Address = 0x08AD, Flags = 0x30 });
			//branches.Add(new FunctionReader.Branch { Address = 0x0BA2, Flags = 0x30 });
			//branches.Add(new FunctionReader.Branch { Address = 0x0BAB, Flags = 0x30 });
			//branches.Add(new FunctionReader.Branch { Address = 0x0878, Flags = 0x30 });
			//branches.Add(new FunctionReader.Branch { Address = 0x0863, Flags = 0x30 });
			//branches.Add(new FunctionReader.Branch { Address = 0x08E2, Flags = 0x30 });
			//branches.Add(new FunctionReader.Branch { Address = 0x08B1, Flags = 0x30 });
			//branches.Add(new FunctionReader.Branch { Address = 0x08C9, Flags = 0x30 });

			// Vortex APU
			//branches.Add(new FunctionReader.Branch { Address = 0x0659, Flags = 0x00 });
			//branches.Add(new FunctionReader.Branch { Address = 0x0487, Flags = 0x00 });
			//branches.Add(new FunctionReader.Branch { Address = 0x0498, Flags = 0x00 });
			//branches.Add(new FunctionReader.Branch { Address = 0x05B1, Flags = 0x00 });
			//branches.Add(new FunctionReader.Branch { Address = 0x04D8, Flags = 0x00 });
			//branches.Add(new FunctionReader.Branch { Address = 0x04E0, Flags = 0x00 });
			//branches.Add(new FunctionReader.Branch { Address = 0x04A8, Flags = 0x00 });
			//branches.Add(new FunctionReader.Branch { Address = 0x05E5, Flags = 0x00 });

			while (branches.Any())
			{
				var branch = branches.First();
				branches.RemoveAt(0);

				if (functions.Any(x => x.Address == branch.Address))
					continue;

				InstructionReader.Position = branch.Address;
				InstructionReader.Flags = branch.Flags;

				FunctionReader.Read();

				functions.Add(new Function
				{
					Address = branch.Address,
					Flags = branch.Flags,
					Instructions = FunctionReader.Instructions
				});

				branches.AddRange(FunctionReader.Branches);
			}

			functions.Sort((a, b) => a.Address - b.Address);

			//AssemblyConsole.Write(functions);
			CSharpConsole.Write(functions);
		}


		internal struct Function
		{
			internal int Address;
			internal int Flags;
			internal FunctionReader.Instruction[] Instructions;
		}
	}
}
