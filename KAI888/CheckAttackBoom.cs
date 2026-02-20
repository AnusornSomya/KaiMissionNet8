using System;
using System.Drawing;
using System.IO;
using System.Threading;

// Token: 0x02000021 RID: 33
public static class CheckAttackBoom
{
	// Token: 0x06000028 RID: 40 RVA: 0x00003BB8 File Offset: 0x00001DB8
	public static bool exit()
	{
		string path = Path.Combine(Environment.GetEnvironmentVariable("TEMP") ?? "C:\\Temp", "png");
		string targetPath = Path.Combine(path, "AttackP.png");
		string targetPath2 = Path.Combine(path, "AttackO.png");
		string targetPath3 = Path.Combine(path, "AttackB.png");
		string targetPath4 = Path.Combine(path, "AttackA.png");
		bool result;
		using (Bitmap target = new Bitmap(targetPath))
		{
			using (Bitmap target2 = new Bitmap(targetPath2))
			{
				using (Bitmap target3 = new Bitmap(targetPath3))
				{
					using (Bitmap target4 = new Bitmap(targetPath4))
					{
						using (Bitmap screen = ImageSearchHelper.CaptureScreen())
						{
							Point foundAt;
							Point foundAt2;
							Point foundAt3;
							Point foundAt4;
							if (ImageSearchHelper.FindImageWithDll(screen, target, 20, out foundAt) || ImageSearchHelper.FindImageWithDll(screen, target2, 20, out foundAt2) || ImageSearchHelper.FindImageWithDll(screen, target3, 20, out foundAt3) || ImageSearchHelper.FindImageWithDll(screen, target4, 20, out foundAt4))
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
			}
		}
		return result;
	}
}
