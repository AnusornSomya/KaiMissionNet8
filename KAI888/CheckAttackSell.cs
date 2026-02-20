using System;
using System.Drawing;
using System.IO;
using System.Threading;

// Token: 0x02000020 RID: 32
public static class CheckAttackSell
{
	// Token: 0x06000027 RID: 39 RVA: 0x00003B28 File Offset: 0x00001D28
	public static bool exit()
	{
		bool result;
		using (Bitmap target = new Bitmap(Path.Combine(Path.Combine(Environment.GetEnvironmentVariable("TEMP") ?? "C:\\Temp", "png"), "AttackSell.png")))
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
