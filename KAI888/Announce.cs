using System;
using System.Drawing;
using System.IO;
using System.Threading;

// Token: 0x02000011 RID: 17
public static class Announce
{
	// Token: 0x06000018 RID: 24 RVA: 0x000030B8 File Offset: 0x000012B8
	public static bool exit()
	{
		string path = Path.Combine(Environment.GetEnvironmentVariable("TEMP") ?? "C:\\Temp", "png");
		string targetPath = Path.Combine(path, "Ok1.png");
		string targetPath2 = Path.Combine(path, "Announce.png");
		bool result;
		using (Bitmap target = new Bitmap(targetPath))
		{
			using (Bitmap target2 = new Bitmap(targetPath2))
			{
				using (Bitmap screen = ImageSearchHelper.CaptureScreen())
				{
					Point foundAt;
					Point foundAt2;
					if (ImageSearchHelper.FindImageWithDll(screen, target, 20, out foundAt) && ImageSearchHelper.FindImageWithDll(screen, target2, 20, out foundAt2))
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
