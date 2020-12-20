using System;

namespace SpcDisassembler
{
	class Program
	{
		static void Main(string[] args)
		{
			Arguments.Parse(args);

			ProgramConsole.Start();
		}
	}
}
