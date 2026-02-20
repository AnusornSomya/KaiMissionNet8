using System;
using System.Drawing;
using System.IO;
using System.Threading;

// Token: 0x0200001D RID: 29
public static class CheckHitA
{
	// Token: 0x06000024 RID: 36 RVA: 0x00003978 File Offset: 0x00001B78
	public static bool exit()
	{
		bool result;
		using (Bitmap target = new Bitmap(Path.Combine(Path.Combine(Environment.GetEnvironmentVariable("TEMP") ?? "C:\\Temp", "png"), "HitA.png")))
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
