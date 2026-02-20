using System;
using System.Drawing;
using System.IO;
using System.Threading;

// Token: 0x0200001C RID: 28
public static class CheckHitP
{
	// Token: 0x06000023 RID: 35 RVA: 0x000038E8 File Offset: 0x00001AE8
	public static bool exit()
	{
		bool result;
		using (Bitmap target = new Bitmap(Path.Combine(Path.Combine(Environment.GetEnvironmentVariable("TEMP") ?? "C:\\Temp", "png"), "HitP.png")))
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
