using System;
using System.IO;
using System.Linq;

namespace BC_Cancer_Agency.four_D_VMAT.TLE_Parser
{
    internal static class TLF_Parser
    {


        public static TrajectoryData Parse( string path)
        {

            using (var reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                //Read the file. Each item is read with approperiate size.
                string Signature = new string(reader.ReadChars(16));

                string Version = new string(reader.ReadChars(16));

                int HeaderSize = reader.ReadInt32();

                int SampleInterval = reader.ReadInt32();

                int NumberOfAxisSampled = reader.ReadInt32();

                int[] AxisEmumeration = new int[NumberOfAxisSampled];
                for (int i = 0; i < NumberOfAxisSampled; i++)
                {
                    AxisEmumeration[i] = reader.ReadInt32();
                }

                int[] SamplesPerAxis = new int[NumberOfAxisSampled];
                for (int i = 0; i < NumberOfAxisSampled; i++)
                {
                    SamplesPerAxis[i] = reader.ReadInt32();
                }

                int AxisScale = reader.ReadInt32();

                int NumberOfSubbeams = reader.ReadInt32();

                int IsTruncated = reader.ReadInt32();

                int NumberOfSnapshots = reader.ReadInt32();

                int MLCModel = reader.ReadInt32();

                int reserved = 1024 - (64 + NumberOfAxisSampled * 8);
                reader.ReadBytes(reserved);

                Subbeam[] SubbeamArray = new Subbeam[NumberOfSubbeams];
                for (int i = 0; i < NumberOfSubbeams; i++)
                {
                    //call subbeam contructer to construct subbeam
                    SubbeamArray[i] = new Subbeam(reader);
                }
                AxisData[] AxisDatas = new AxisData[NumberOfAxisSampled];
                for (int i = 0; i < NumberOfAxisSampled; i++)
                {
                    AxisDatas[i] = new AxisData(reader, AxisEmumeration[i], SamplesPerAxis[i]);
                }
                UInt16 CRC = reader.ReadUInt16();
                //contruct a data container to put all the data in it.
                TrajectoryData T = new TrajectoryData(Signature,Version,HeaderSize,SampleInterval,
                                                      NumberOfAxisSampled,AxisEmumeration,SamplesPerAxis,AxisScale,
                                                     NumberOfSubbeams,IsTruncated,NumberOfSnapshots,MLCModel,SubbeamArray,AxisDatas,CRC);

#if DEBUG
                Console.WriteLine("Here is the content of TLE file named "
              + path.Substring(path.LastIndexOf('/') + 1) + " :");

#endif
                Console.WriteLine(path.Substring(path.LastIndexOf('/') + 1) + " is parsed");
                return T;
            }
        }
    }
}
