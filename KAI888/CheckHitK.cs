using System;
using System.Drawing;
using System.IO;
using System.Threading;

// Token: 0x0200001E RID: 30
public static class CheckHitK
{
	// Token: 0x06000025 RID: 37 RVA: 0x00003A08 File Offset: 0x00001C08
	public static bool exit()
	{
		bool result;
		using (Bitmap target = new Bitmap(Path.Combine(Path.Combine(Environment.GetEnvironmentVariable("TEMP") ?? "C:\\Temp", "png"), "HitK.png")))
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
