using System;
using System.Drawing;
using System.IO;
using System.Threading;

// Token: 0x0200001A RID: 26
public static class CheckHitBuy
{
	// Token: 0x06000021 RID: 33 RVA: 0x000037C8 File Offset: 0x000019C8
	public static bool exit()
	{
		bool result;
		using (Bitmap target = new Bitmap(Path.Combine(Path.Combine(Environment.GetEnvironmentVariable("TEMP") ?? "C:\\Temp", "png"), "HitBuy.png")))
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
