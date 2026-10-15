using System;
using wt_lab3_3mvc_lyashuk.Controllers;

namespace wt_lab3_3mvc_lyashuk;

internal class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        var controller = new PlayerController();
        controller.Run();
    }
}