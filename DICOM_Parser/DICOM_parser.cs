using System;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;


namespace BC_Cancer_Agency.four_D_VMAT.DICOM_Parser
{
    internal static class DICOM_parser
    {
        public static Dicom_data Parse(string file_path){
			string python = "/Library/Frameworks/Python.framework/Versions/3.5/bin/python3.5";

			// python app to call 
			string myPythonApp = "Test.py";

			// dummy parameters to send Python script 

			// Create new process start info 
			ProcessStartInfo myProcessStartInfo = new ProcessStartInfo(python);

			// make sure we can read the output from stdout 
			myProcessStartInfo.UseShellExecute = false;
			myProcessStartInfo.RedirectStandardOutput = true;

			// start python app with 3 arguments  
			// 1st arguments is pointer to itself,  
			// 2nd and 3rd are actual arguments we want to send 
			myProcessStartInfo.Arguments = myPythonApp + " " + file_path;

			Process myProcess = new Process();
			// assign start information to the process 
			myProcess.StartInfo = myProcessStartInfo;

			Console.WriteLine("Calling Python script with 1 argument");
			// start the process 
			myProcess.Start();

			// Read the standard output of the app we called.  
			// in order to avoid deadlock we will read output first 
			// and then wait for process terminate: 
			StreamReader myStreamReader = myProcess.StandardOutput;

			string myString = myStreamReader.ReadLine();
			Console.WriteLine(myString + " is read");
			myString = myStreamReader.ReadLine();

			List<Int32> BeamEnable = myString.Split(new char[] { ',', '[', ']' }, StringSplitOptions.RemoveEmptyEntries)
									 .Select(x => Convert.ToInt32(x)).ToList();
			foreach (var beam_enable in BeamEnable)
			{
				Console.WriteLine(beam_enable);
			}
			myString = myStreamReader.ReadLine();
			Console.WriteLine(myString + " is read");
			myString = myStreamReader.ReadLine();

			var Phase = myString.Split(new char[] { ',', '[', ']' }, StringSplitOptions.RemoveEmptyEntries)
								.Select(x => Convert.ToInt32(x)).ToList();
			foreach (var phase in Phase)
			{
				Console.WriteLine(phase);
			}
			myString = myStreamReader.ReadLine();
			Console.WriteLine(myString + " is read");
			myString = myStreamReader.ReadLine();

			var Ant_Post = myString.Split(new char[] { ',', '[', ']' }, StringSplitOptions.RemoveEmptyEntries)
								.Select(x => Convert.ToInt32(x)).ToList();
			foreach (var ant_post in Ant_Post)
			{
				Console.WriteLine(ant_post);
			}
			myString = myStreamReader.ReadLine();
			int number_of_waveform_samples = Convert.ToInt32(myString);

			if (number_of_waveform_samples != BeamEnable.Count() | number_of_waveform_samples != Phase.Count() | number_of_waveform_samples != Ant_Post.Count())
			{
				Console.WriteLine("Some data is missing");
			}
			else
			{
				Console.WriteLine("file was parsed successfully");
			}
            Dicom_data d = new Dicom_data();
            d.BeamEnable = BeamEnable;
            d.Phase = Phase;
            d.Ant_Post = Ant_Post;
            d.number_of_waveform_samples = number_of_waveform_samples;





			/*if you need to read multiple lines, you might use: 
                string myString = myStreamReader.ReadToEnd() */

			// wait exit signal from the app we called and then close it. 
			myProcess.WaitForExit();
			myProcess.Close();
            return d;



		}
    }
}