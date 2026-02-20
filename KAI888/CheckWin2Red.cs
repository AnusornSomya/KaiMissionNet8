using System;
using System.Drawing;
using System.IO;
using System.Threading;

// Token: 0x0200000B RID: 11
public static class CheckWin2Red
{
	// Token: 0x06000012 RID: 18 RVA: 0x00002CF8 File Offset: 0x00000EF8
	public static bool exit()
	{
		string targetPath = Path.Combine(Path.Combine(Environment.GetEnvironmentVariable("TEMP") ?? "C:\\Temp", "png"), "Win2Red.png");
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
