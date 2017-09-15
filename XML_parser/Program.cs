


namespace BC_Cancer_Agency.four_D_VMAT.XML_parser
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var input_path = InputHandler.GetPathFromInput();
            xml_data x = Xml_parser.Parse(input_path);

        }
    }
}
