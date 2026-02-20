using System;
using System.Drawing;
using System.IO;
using System.Threading;

// Token: 0x02000007 RID: 7
public static class Checkkill0Red
{
	// Token: 0x0600000E RID: 14 RVA: 0x00002A78 File Offset: 0x00000C78
	public static bool exit()
	{
		string targetPath = Path.Combine(Path.Combine(Environment.GetEnvironmentVariable("TEMP") ?? "C:\\Temp", "png"), "Checkkill0Red.png");
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
