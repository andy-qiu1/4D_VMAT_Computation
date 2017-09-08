using System.IO;
using System;

namespace BC_Cancer_Agency.four_D_VMAT
{
    internal class Subbeam
    {
        int cp;
        float mu;
        float radTime;
        int Seq;
        string name;
        string reserved;


        public Subbeam(BinaryReader reader)
        {
            this.cp = reader.ReadInt32();
            this.mu = reader.ReadSingle();
            this.radTime = reader.ReadSingle();
            this.Seq = reader.ReadInt32();
            this.name = new string(reader.ReadChars(512));
            this.reserved = new string(reader.ReadChars(32));
        }
        public void Print()
        {
            Console.WriteLine("Control Point Number is: "+this.cp);
            Console.WriteLine("Does delievered is: "+this.mu+ " MU");
            Console.WriteLine("Expected Irradiation Time: "+this.radTime+ " S" );
            Console.WriteLine("Sequence number is: "+this.Seq);
            Console.WriteLine("Name is: "+this.name);
        }
    }
}