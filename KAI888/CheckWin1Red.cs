using System;
using System.Drawing;
using System.IO;
using System.Threading;

// Token: 0x0200000A RID: 10
public static class CheckWin1Red
{
	// Token: 0x06000011 RID: 17 RVA: 0x00002C58 File Offset: 0x00000E58
	public static bool exit()
	{
		string targetPath = Path.Combine(Path.Combine(Environment.GetEnvironmentVariable("TEMP") ?? "C:\\Temp", "png"), "Win1Red.png");
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
