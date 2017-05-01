using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectHeadphones
{
  class Program
  {
    static void Main(string[] args)
    {
      bool succeed = false;
      for (int attempts = 0; !succeed && attempts < 10; ++attempts)
      {
        try
        {
          Bluetooth.Connect("00180926D2D6");
          succeed = true;
          Console.WriteLine("Success!");
        }
        catch (Exception ex)
        {
          succeed = false;
          Console.WriteLine("Unable to connect because {0}. Attempt {1}/10",
            ex.Message, attempts + 1);
          Console.WriteLine();
          Thread.Sleep(500);
        }
      }
    }
  }
}
