using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
namespace BC_Cancer_Agency.four_D_VMAT.VXF_Parser
{
    internal static class VXF_Parser
    {
        internal static Varian_data Parse(String path)
        {
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                s = sr.ReadLine();
                if (s != "[Header]") { throw new FormatException("no header"); }
                s = sr.ReadLine();
                s = s.Remove(0, 4);
                int CRC = Convert.ToInt32(s);
                s = sr.ReadLine();
                string version = s.Remove(0, 8);
                s = sr.ReadLine();
                string[] Data_layouts = s.Remove(0, 12).Split(',');
                s = sr.ReadLine();
                int patient_ID = Convert.ToInt32(s.Remove(0, 11));
                s = sr.ReadLine();
                s = s.Remove(0, 5);
                var date_data_array = s.Split('-').Select(x => Convert.ToInt32(x));
                DateTime date = new DateTime(date_data_array.ElementAt(2), date_data_array.ElementAt(0), date_data_array.ElementAt(1));
                s = sr.ReadLine();
                s = s.Remove(0, 17);
                float Total_study_time = Convert.ToSingle(s);
                s = sr.ReadLine();
                s = s.Remove(0, 19);
                int Samples_per_second = Convert.ToInt32(s);
                s = sr.ReadLine();
                s = s.Remove(0, 13);
                float Scale_factor = Convert.ToSingle(s);
                s = sr.ReadLine();
                if (s != "[Data]") { throw new FormatException("no data"); }


                Dictionary<string, List<float>> data = new Dictionary<string, List<float>>();
                foreach (var data_layout in Data_layouts)
                {
                    data.Add(data_layout, new List<float>());
                }


                while (sr.Peek() > -1)
                {
                    s = sr.ReadLine();
                    Console.WriteLine(s);
                    float f;
                    var data_entries = s.Split(',').Select(st=>float.TryParse(st, out f) ? st : "0");

                    for (int i = 0; i < Data_layouts.Length; i++)
                    {
                        Console.WriteLine(data_entries.ElementAt(i));
                        data[Data_layouts[i]].Add(Convert.ToSingle(data_entries.ElementAt(i)));
                    }

                }
				Varian_data v = new Varian_data(CRC, version, Data_layouts, patient_ID, date, Total_study_time, Samples_per_second, Scale_factor, data);
				return v;

            }
        }

    }
}