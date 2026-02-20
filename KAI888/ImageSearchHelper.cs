using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

// Token: 0x02000003 RID: 3
public static class ImageSearchHelper
{
	// Token: 0x06000004 RID: 4 RVA: 0x00002064 File Offset: 0x00000264
	public static bool FindImageWithDll(Bitmap screenBmp, Bitmap targetBmp, int tolerance, out Point foundAt)
	{
		foundAt = Point.Empty;
		BitmapData screenData = screenBmp.LockBits(new Rectangle(0, 0, screenBmp.Width, screenBmp.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
		BitmapData targetData = targetBmp.LockBits(new Rectangle(0, 0, targetBmp.Width, targetBmp.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
		bool result;
		try
		{
			int x;
			int y;
			if (ImageSearchNative.FindImageRGB(screenData.Scan0, screenBmp.Width, screenBmp.Height, screenData.Stride, targetData.Scan0, targetBmp.Width, targetBmp.Height, targetData.Stride, tolerance, out x, out y))
			{
				foundAt = new Point(x, y);
				result = true;
			}
			else
			{
				result = false;
			}
		}
		finally
		{
			screenBmp.UnlockBits(screenData);
			targetBmp.UnlockBits(targetData);
		}
		return result;
	}

	// Token: 0x06000005 RID: 5 RVA: 0x00002130 File Offset: 0x00000330
	public static Bitmap CaptureScreen()
	{
		Rectangle bounds = Screen.PrimaryScreen.Bounds;
		Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height);
		using (Graphics g = Graphics.FromImage(bitmap))
		{
			g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
		}
		return bitmap;
	}

	// Token: 0x06000006 RID: 6 RVA: 0x00002198 File Offset: 0x00000398
	public static Bitmap CapturePartialScreen(Rectangle region)
	{
		Bitmap bitmap = new Bitmap(region.Width, region.Height);
		using (Graphics g = Graphics.FromImage(bitmap))
		{
			g.CopyFromScreen(region.Location, Point.Empty, region.Size);
		}
		return bitmap;
	}
}
