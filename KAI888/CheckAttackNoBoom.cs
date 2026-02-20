using System;
using System.Drawing;
using System.IO;
using System.Threading;

// Token: 0x02000022 RID: 34
public static class CheckAttackNoBoom
{
	// Token: 0x06000029 RID: 41 RVA: 0x00003D04 File Offset: 0x00001F04
	public static bool exit()
	{
		string path = Path.Combine(Environment.GetEnvironmentVariable("TEMP") ?? "C:\\Temp", "png");
		string targetPath = Path.Combine(path, "AttackI.png");
		string targetPath2 = Path.Combine(path, "AttackN1.png");
		bool result;
		using (Bitmap target = new Bitmap(targetPath))
		{
			using (Bitmap target2 = new Bitmap(targetPath2))
			{
				using (Bitmap screen = ImageSearchHelper.CaptureScreen())
				{
					Point foundAt;
					Point foundAt2;
					if (ImageSearchHelper.FindImageWithDll(screen, target, 20, out foundAt) || ImageSearchHelper.FindImageWithDll(screen, target2, 20, out foundAt2))
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
		}
		return result;
	}
}
