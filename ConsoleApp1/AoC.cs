using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp;

public class AoC
{
    protected string Input { get; set; }

    public List<string> ResultList { get; private set; }
    
    public AoC(string input)
    {
        Input = input;
        ResultList = new List<string>();
    }
}

