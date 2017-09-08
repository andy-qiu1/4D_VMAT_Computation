using System;
using System.IO;
namespace BC_Cancer_Agency.four_D_VMAT
{
    internal class AxisDataSnapshot
    {
        public float expected;
        public float actual;
        public AxisDataSnapshot(BinaryReader reader)
        {
            this.expected = reader.ReadSingle();
            this.actual = reader.ReadSingle();
        }

        internal void print()
        {
            Console.WriteLine("Expected: "+expected+"  "+"Actual: "+ actual);
        }
    }
}