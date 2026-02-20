using System;
using System.Runtime.InteropServices;

// Token: 0x02000002 RID: 2
public static class ImageSearchNative
{
	// Token: 0x06000001 RID: 1
	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern bool SetDllDirectory(string lpPathName);

	// Token: 0x06000002 RID: 2 RVA: 0x00002050 File Offset: 0x00000250
	static ImageSearchNative()
	{
		ImageSearchNative.SetDllDirectory(AppDomain.CurrentDomain.BaseDirectory);
	}

	// Token: 0x06000003 RID: 3
	[DllImport("ImageSearchNative.dll", CallingConvention = CallingConvention.StdCall)]
	public static extern bool FindImageRGB(IntPtr screenData, int screenWidth, int screenHeight, int screenStride, IntPtr targetData, int targetWidth, int targetHeight, int targetStride, int tolerance, out int foundX, out int foundY);
}
