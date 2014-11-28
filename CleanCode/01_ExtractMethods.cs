using System;
using System.IO;

namespace CleanCode
{
	public static class RefactorMethod
	{
	    private static void WriteDataToFile(string path, byte[] data)
	    {
            var fs = new FileStream(path, FileMode.OpenOrCreate);
	        fs.Write(data, 0, data.Length);
            fs.Close();
	    }
		private static void SaveData(string path, byte[] data)
		{
            WriteDataToFile(path, data);
            WriteDataToFile(Path.ChangeExtension(path, "bkp"), data);

			// save last-write time
			string timeFile = path + ".time";
			var t = BitConverter.GetBytes(DateTime.Now.Ticks);
            WriteDataToFile(timeFile, t);
		}
	}
}