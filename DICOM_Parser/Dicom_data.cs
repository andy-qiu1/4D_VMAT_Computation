using System.Collections.Generic;

namespace BC_Cancer_Agency.four_D_VMAT.DICOM_Parser
{
    public class Dicom_data
    {
        internal List<int> BeamEnable;
        internal List<int> Phase;
        internal List<int> Ant_Post;
        internal int number_of_waveform_samples;
    }
}