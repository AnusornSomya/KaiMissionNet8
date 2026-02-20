using System;
using System.Drawing;
using System.IO;
using System.Threading;

// Token: 0x02000009 RID: 9
public static class CheckWin0Red
{
	// Token: 0x06000010 RID: 16 RVA: 0x00002BB8 File Offset: 0x00000DB8
	public static bool exit()
	{
		string targetPath = Path.Combine(Path.Combine(Environment.GetEnvironmentVariable("TEMP") ?? "C:\\Temp", "png"), "Win0Red.png");
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
