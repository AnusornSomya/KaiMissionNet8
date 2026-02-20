using System;
using System.Drawing;
using System.IO;
using System.Threading;

// Token: 0x0200000C RID: 12
public static class CheckWin0
{
	// Token: 0x06000013 RID: 19 RVA: 0x00002D98 File Offset: 0x00000F98
	public static bool exit()
	{
		string targetPath = Path.Combine(Path.Combine(Environment.GetEnvironmentVariable("TEMP") ?? "C:\\Temp", "png"), "Win1.png");
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
