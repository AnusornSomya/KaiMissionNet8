using System;
using System.Drawing;
using System.IO;
using System.Threading;

// Token: 0x02000024 RID: 36
public static class CheckAttackL
{
	// Token: 0x0600002B RID: 43 RVA: 0x00003E64 File Offset: 0x00002064
	public static bool exit()
	{
		bool result;
		using (Bitmap target = new Bitmap(Path.Combine(Path.Combine(Environment.GetEnvironmentVariable("TEMP") ?? "C:\\Temp", "png"), "AttackL.png")))
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
