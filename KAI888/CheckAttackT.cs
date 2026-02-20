using System;
using System.Drawing;
using System.IO;
using System.Threading;

// Token: 0x02000023 RID: 35
public static class CheckAttackT
{
	// Token: 0x0600002A RID: 42 RVA: 0x00003DD4 File Offset: 0x00001FD4
	public static bool exit()
	{
		bool result;
		using (Bitmap target = new Bitmap(Path.Combine(Path.Combine(Environment.GetEnvironmentVariable("TEMP") ?? "C:\\Temp", "png"), "AttackT.png")))
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
