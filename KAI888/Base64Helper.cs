using System;
using System.IO;

// Token: 0x02000004 RID: 4
public class Base64Helper
{
	// Token: 0x06000007 RID: 7 RVA: 0x000021F8 File Offset: 0x000003F8
	public static bool Base64ToFile(string base64, string fileName)
	{
		bool result;
		try
		{
			string text = Path.Combine(Environment.GetEnvironmentVariable("TEMP") ?? "C:\\Temp", "png");
			Directory.CreateDirectory(text);
			string path = Path.Combine(text, fileName);
			byte[] binaryData = Convert.FromBase64String(base64);
			File.WriteAllBytes(path, binaryData);
			result = true;
		}
		catch (Exception)
		{
			result = false;
		}
		return result;
	}
}
