using System;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
namespace BC_Cancer_Agency.four_D_VMAT.XML_parser
{
    internal static class Xml_parser
    {
        internal static xml_data Parse(string input_path)
        {
            XmlTextReader reader = new XmlTextReader(input_path);
            var out_put = new xml_data();
            out_put = Read(reader);
            Console.WriteLine("file is sucessfully parsed");
            return out_put;



        }

        private static xml_data Read(XmlTextReader reader)
        {
            var out_put = new xml_data();
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.Name)
                    {
                        case "Id":
                            reader.Read();
                            out_put.Id = reader.Value;
                            break;
                        case "MLCModel":
                            reader.Read();
                            out_put.MLC_Model = reader.Value;
                            break;
                        case "ControlPoints":
                            out_put.cps = new List<Control_Point>();
                            out_put.cps = Read_control_Points(reader);
                            break;
                    }
                }
                if (reader.NodeType == XmlNodeType.EndElement && reader.Name == "SetBeam")
                {
                    break;
                }
            }
            return out_put;
        }
        private static List<Control_Point> Read_control_Points(XmlTextReader reader)
        {
            var cps = new List<Control_Point>();
            while (reader.Read())
            {
                Control_Point cp = new Control_Point();
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {

                        switch (reader.Name)
                        {
                            case "SubBeam":
                                SubBeam s = new SubBeam();
                                reader.Read();
                                reader.Read();
                                if (reader.Name == "Seq")
                                {
                                    reader.Read();
                                    s.Seq = reader.Value;
                                }
                                reader.Read();
                                reader.Read();
                                reader.Read();
                                if (reader.Name == "Name")
                                {
                                    reader.Read();
                                    s.Name = reader.Value;
                                }
                                reader.Read();
                                cp.SubBeam = s;
                                break;
                            case "Energy":
                                reader.Read();
                                string Energy = reader.Value;
                                cp.Energy = Energy;
                                reader.Read();
                                break;
                            case "Mu":
                                reader.Read();
                                float Mu = Convert.ToSingle(reader.Value);
                                cp.Mu = Mu;
                                reader.Read();
                                break;
                            case "DRate":
                                reader.Read();
                                int DRate = Convert.ToInt32(reader.Value);
                                cp.DRate = DRate;
                                reader.Read();
                                break;
                            case "GantryRtn":
                                reader.Read();
                                float GantryRtn = Convert.ToSingle(reader.Value);
                                cp.GantryRtn = GantryRtn;
                                reader.Read();
                                break;
                            case "CollRtn":
                                reader.Read();
                                float CollRtn = Convert.ToSingle(reader.Value);
                                cp.CollRtn = CollRtn;
                                reader.Read();
                                break;
                            case "CouchLng":
                                reader.Read();
                                float CouchLng = Convert.ToSingle(reader.Value);
                                cp.CouchLng = CouchLng;
                                reader.Read();
                                break;
                            case "Y1":
                                reader.Read();
                                float Y1 = Convert.ToSingle(reader.Value);
                                cp.Y1 = Y1;
                                reader.Read();
                                break;
                            case "Y2":
                                reader.Read();
                                float Y2 = Convert.ToSingle(reader.Value);
                                cp.Y2 = Y2;
                                reader.Read();
                                break;
                            case "X1":
                                reader.Read();
                                float X1 = Convert.ToSingle(reader.Value);
                                cp.X1 = X1;
                                reader.Read();
                                break;
                            case "X2":
                                reader.Read();
                                float X2 = Convert.ToSingle(reader.Value);
                                cp.X2 = X2;
                                reader.Read();
                                break;
                            case "Mlc":
                                Mlc m = new Mlc();
                                reader.Read();
                                if (reader.Name == "ID")
                                {
                                    reader.Read();
                                    m.ID = reader.Value;
                                }
                                reader.Read();
                                reader.Read();
                                reader.Read();
                                if (reader.Name == "B")
                                {
                                    reader.Read();

                                    m.B = reader.Value.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(x => Convert.ToSingle(x)).ToList();
                                }
                                reader.Read();
                                reader.Read();
                                reader.Read();
                                if (reader.Name == "A")
                                {
                                    reader.Read();
                                    m.A = reader.Value.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(x => Convert.ToSingle(x)).ToList();
                                }
                                reader.Read();
                                reader.Read();
                                reader.Read();
                                cp.Mlc = m;
                                break;
                        }
                    }
                    if (reader.NodeType == XmlNodeType.EndElement && reader.Name == "Cp")
                    {
                        cps.Add(cp);
                        break;
                    }
                }
            }
            return cps;
        }
    }
}



