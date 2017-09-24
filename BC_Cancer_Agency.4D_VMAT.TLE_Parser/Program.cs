using System;



namespace BC_Cancer_Agency.four_D_VMAT.TLE_Parser
{
    class MainClass
    {
        public static void Main()
        {
            
            var path = InputHandler.GetPathFromInput("a.bin");

            TrajectoryData trajectoryData = TLF_Parser.Parse(path);
#if DEBUG
            trajectoryData.Print();
#endif
		}
    }
}
