
using System;
using System.IO;

namespace BC_Cancer_Agency.four_D_VMAT.TLE_Parser
{

	public enum AxisEnumeration
	{

		CollRtn = 0,
		GantryRtn = 1,
		Y1 = 2,
		Y2 = 3,
		X1 = 4,
		X2 = 5,
		CouchVrt = 6,
		CouchLng = 7,
		CouchLat = 8,
		CouchRtn = 9,
		CouchPut = 10,
		CouchRol = 11,
		MU = 40,
		BeamHold = 41,
		ControlPoint = 42,
		MLC = 50,
	}
    internal class AxisData
    {
        AxisEnumeration ae;
        AxisDataSnapshot[] AxisDataSnapshots;
        private int numberOfSample;


        public AxisData(BinaryReader reader,int axis, int numberOfSample) 
        {
            this.ae = (BC_Cancer_Agency.four_D_VMAT.TLE_Parser.AxisEnumeration)axis;
            this.numberOfSample = numberOfSample;
            this.AxisDataSnapshots = new AxisDataSnapshot[numberOfSample];
            for (int i = 0;i < numberOfSample;i++){
                AxisDataSnapshots[i] = new AxisDataSnapshot(reader);
            }

        }

        internal void print()
        {
            Console.WriteLine(Enum.GetName(ae.GetType(),ae)+": ");
			for (int i = 0; i < numberOfSample; i++)
			{
				AxisDataSnapshots[i].print();
			}


        }
    }
}