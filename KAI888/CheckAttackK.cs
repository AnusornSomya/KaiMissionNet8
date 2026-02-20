using System;
using System.Drawing;
using System.IO;
using System.Threading;

// Token: 0x02000026 RID: 38
public static class CheckAttackK
{
	// Token: 0x0600002D RID: 45 RVA: 0x00003F84 File Offset: 0x00002184
	public static bool exit()
	{
		bool result;
		using (Bitmap target = new Bitmap(Path.Combine(Path.Combine(Environment.GetEnvironmentVariable("TEMP") ?? "C:\\Temp", "png"), "AttackK.png")))
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
