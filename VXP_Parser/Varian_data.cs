using System;
using System.Collections.Generic;

namespace BC_Cancer_Agency.four_D_VMAT.VXF_Parser
{
    internal class Varian_data
    {
        private int cRC;
        private string version;
        private string[] data_layouts;
        private int patient_ID;
        private DateTime date;
        private float total_study_time;
        private int samples_per_second;
        private float scale_factor;
        private Dictionary<string, List<float>> data;

        public Varian_data(int cRC, string version, string[] data_layouts, int patient_ID, DateTime date, float total_study_time, int samples_per_second, float scale_factor, Dictionary<string, List<float>> data)
        {
            this.cRC = cRC;
            this.version = version;
            this.data_layouts = data_layouts;
            this.patient_ID = patient_ID;
            this.date = date;
            this.total_study_time = total_study_time;
            this.samples_per_second = samples_per_second;
            this.scale_factor = scale_factor;
            this.data = data;
        }
    }
}