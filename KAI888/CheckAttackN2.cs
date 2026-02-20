using System;
using System.Drawing;
using System.IO;
using System.Threading;

// Token: 0x02000025 RID: 37
public static class CheckAttackN2
{
	// Token: 0x0600002C RID: 44 RVA: 0x00003EF4 File Offset: 0x000020F4
	public static bool exit()
	{
		bool result;
		using (Bitmap target = new Bitmap(Path.Combine(Path.Combine(Environment.GetEnvironmentVariable("TEMP") ?? "C:\\Temp", "png"), "AttackN2.png")))
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
