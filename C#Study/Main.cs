
using C_Study;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

class MainClass
{
    public static void Main()
    {
        OldSword NewSwor = new OldSword();

        GameCore gameCore = new GameCore();
        gameCore.Start();
        gameCore.Update();


    }
}
