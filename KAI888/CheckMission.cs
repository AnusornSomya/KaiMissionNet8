using System;
using System.Drawing;
using System.IO;
using System.Threading;

// Token: 0x02000019 RID: 25
public static class CheckMission
{
	// Token: 0x06000020 RID: 32 RVA: 0x00003738 File Offset: 0x00001938
	public static bool exit()
	{
		bool result;
		using (Bitmap target = new Bitmap(Path.Combine(Path.Combine(Environment.GetEnvironmentVariable("TEMP") ?? "C:\\Temp", "png"), "MainMission.png")))
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
