using System;
using System.Linq;

namespace BC_Cancer_Agency.four_D_VMAT.TLE_Parser
{
    internal class TrajectoryData
    {
        private string signature;
        private string version;
        private int headerSize;
        private int sampleInterval;
        private int numberOfAxisSampled;
        private int[] axisEmumeration;
        private int[] samplesPerAxis;
        private int axisScale;
        private int numberOfSubbeams;
        private int mLCModel;
        private Subbeam[] subbeamArray;
        private AxisData[] axisDatas;
        private ushort cRC;
        private int isTruncated;
        private int numberOfSnapshots;



        public TrajectoryData(string signature, string version, int headerSize, int sampleInterval, int numberOfAxisSampled, int[] axisEmumeration, int[] samplesPerAxis, int axisScale, int numberOfSubbeams, int isTruncated, int numberOfSnapshots, int mLCModel, Subbeam[] subbeamArray, AxisData[] axisDatas, ushort cRC)
        {
            this.signature = signature;
            this.version = version;
            this.headerSize = headerSize;
            this.sampleInterval = sampleInterval;
            this.numberOfAxisSampled = numberOfAxisSampled;
            this.axisEmumeration = axisEmumeration;
            this.samplesPerAxis = samplesPerAxis;
            this.axisScale = axisScale;
            this.numberOfSubbeams = numberOfSubbeams;
            this.isTruncated = isTruncated;
            this.numberOfSnapshots = numberOfSnapshots;
            this.mLCModel = mLCModel;
            this.subbeamArray = subbeamArray;
            this.axisDatas = axisDatas;
            this.cRC = cRC;
        }

        public void Print(){
			Console.WriteLine("Signiture is: " + this.signature);
			Console.WriteLine("Version is: " + this.version);
			Console.WriteLine("Header Size is: " + this.headerSize.ToString());
			Console.WriteLine("Sample Interval is: " + this.sampleInterval + " ms");
			Console.WriteLine("Number of Axis Sampled is: " + this.numberOfAxisSampled);
			Console.WriteLine("Axis Emumeration: " +
							  axisEmumeration.Skip(1).Aggregate(axisEmumeration[0].ToString().PadRight(2),
																(s, i) => s + "," + i.ToString().PadRight(2)));
			Console.WriteLine("Samples Per Axis: " +
							  samplesPerAxis.Skip(1).Aggregate(samplesPerAxis[0].ToString().PadRight(2),
															   (s, i) => s + "," + i.ToString().PadRight(2)));
			Console.WriteLine("Axis Scale is: " + (axisScale == 1 ? "Machine Scale" : "Modified IEC 61217"));
			Console.WriteLine("Number of Subbeams is: " + numberOfSubbeams.ToString());
			Console.WriteLine("The Machine is " + (isTruncated == 0 ? "Not Truncated" : "Truncated"));
			Console.WriteLine("Number of Snapshots is: " + numberOfSnapshots);
			Console.WriteLine("MLC Model is " + (mLCModel == 2 ? "NDS 120" : "NDS 120 HD"));
			for (int i = 0; i < numberOfSubbeams; i++)
			{
                Console.WriteLine("Subbeam " + i.ToString()+" :");
				subbeamArray[i].Print();
			}
			for (int i = 0; i < numberOfAxisSampled; i++)
			{
				axisDatas[i].print();
			}
			Console.WriteLine("CRC value is: " + cRC);
            
        }
    }
}