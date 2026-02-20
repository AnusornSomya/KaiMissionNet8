using System;
using System.Drawing;
using System.IO;
using System.Threading;

// Token: 0x0200001B RID: 27
public static class CheckHitSell
{
	// Token: 0x06000022 RID: 34 RVA: 0x00003858 File Offset: 0x00001A58
	public static bool exit()
	{
		bool result;
		using (Bitmap target = new Bitmap(Path.Combine(Path.Combine(Environment.GetEnvironmentVariable("TEMP") ?? "C:\\Temp", "png"), "HitSell.png")))
		{
			using (Bitmap screen = ImageSearchHelper.CaptureScreen())
			{
				Point foundAt;
				if (ImageSearchHelper.FindImageWithDll(screen, target, 20, out foundAt))
				{
					result = true;
				}
				else
				{
					Thread.Sleep(100);
					result = false;
				}
			}
		}
		return result;
	}
}
