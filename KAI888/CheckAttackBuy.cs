using System;
using System.Drawing;
using System.IO;
using System.Threading;

// Token: 0x0200001F RID: 31
public static class CheckAttackBuy
{
	// Token: 0x06000026 RID: 38 RVA: 0x00003A98 File Offset: 0x00001C98
	public static bool exit()
	{
		bool result;
		using (Bitmap target = new Bitmap(Path.Combine(Path.Combine(Environment.GetEnvironmentVariable("TEMP") ?? "C:\\Temp", "png"), "AttackBuy.png")))
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
