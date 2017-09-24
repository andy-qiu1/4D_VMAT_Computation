using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BC_Cancer_Agency.four_D_VMAT.VXF_Parser
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var path = InputHandler.GetPathFromInput();
            Varian_data v = VXF_Parser.Parse(path);


        }

    }
}

