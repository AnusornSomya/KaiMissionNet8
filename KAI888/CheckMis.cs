using System;
using System.Drawing;
using System.IO;
using System.Threading;

// Token: 0x02000018 RID: 24
public static class CheckMis
{
	// Token: 0x0600001F RID: 31 RVA: 0x00003668 File Offset: 0x00001868
	public static bool exit()
	{
		string path = Path.Combine(Environment.GetEnvironmentVariable("TEMP") ?? "C:\\Temp", "png");
		string targetPath = Path.Combine(path, "Blinking.png");
		string targetPath2 = Path.Combine(path, "NotBlinking.png");
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
