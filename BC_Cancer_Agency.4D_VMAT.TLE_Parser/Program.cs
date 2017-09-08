using System;



namespace BC_Cancer_Agency.four_D_VMAT
{
    class MainClass
    {
        public static void Main()
        {
            var path = InputHandler.GetPathFromInput();
            var parser = new TLE_Parser();
            parser.parse(path);
        }
    }
}
