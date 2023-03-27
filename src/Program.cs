using System;
using System.IO.Pipes;

namespace com_07
{
  class Program
  {
    const int EOT = int.MinValue;
#if TEST
        // Compil : dotnet build /p:DefineConstants="TEST" -o test
        // Codespaces exec : sudo ./test/com_07
        static void Main(string[] args)
        {
            Span<byte> mem = new(new byte[4]);
            
            using NamedPipeClientStream tuyau = new NamedPipeClientStream("traitement-entiers");
            
            tuyau.Connect();
                       
            for(var fib = (n1: 0, n2: 1); fib.n1 < 1000; fib = (fib.n2, fib.n1+fib.n2))
            {
                BitConverter.TryWriteBytes(mem, fib.n1);
                tuyau.Write(mem);
            }
            BitConverter.TryWriteBytes(mem, EOT);
            tuyau.Write(mem);
            tuyau.Flush();
            tuyau.Close();
        }
#else
    // Codespaces exec : sudo dotnet run
    static void Main(string[] args)
    {
      using NamedPipeServerStream tuyau = new("traitement-entiers", PipeDirection.In);
      byte[] mem = new byte[sizeof(int)];

      tuyau.WaitForConnection();
      for (; ; )
      {
        tuyau.Read(mem, 0, mem.Length);
        var val = BitConverter.ToInt32(mem);
        if (val == EOT)
        {
          tuyau.Disconnect();
          break;
        }
        Console.WriteLine(val);
      }
    }
#endif
  }
}
