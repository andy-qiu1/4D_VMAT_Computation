

namespace BC_Cancer_Agency.four_D_VMAT.DICOM_Parser
{

    class MainClass
    {
        public static void Main(string[] args)
        {
            // full path of python interpreter 
            string file_path = InputHandler.GetPathFromInput();
            Dicom_data d = DICOM_parser.Parse(file_path);

        }
    }
}
