using System;
using System.Drawing;
using System.IO;
using System.Threading;

// Token: 0x02000010 RID: 16
public static class Time250
{
	// Token: 0x06000017 RID: 23 RVA: 0x00003018 File Offset: 0x00001218
	public static bool exit()
	{
		string targetPath = Path.Combine(Path.Combine(Environment.GetEnvironmentVariable("TEMP") ?? "C:\\Temp", "png"), "Time250.png");
		for (int i = 0; i < 1; i++)
		{
			using (Bitmap target = new Bitmap(targetPath))
			{
				using (Bitmap screen = ImageSearchHelper.CaptureScreen())
				{
					Point foundAt;
					if (ImageSearchHelper.FindImageWithDll(screen, target, 20, out foundAt))
					{
						return true;
					}
					Thread.Sleep(100);
				}
			}
		}
		return false;
	}
}
