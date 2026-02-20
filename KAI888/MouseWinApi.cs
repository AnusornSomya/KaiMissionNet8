using System;
using System.Runtime.InteropServices;

// Token: 0x02000006 RID: 6
public static class MouseWinApi
{
	// Token: 0x0600000B RID: 11
	[DllImport("user32.dll")]
	private static extern void mouse_event(uint dwFlags, int dx, int dy, uint dwData, UIntPtr dwExtraInfo);

	// Token: 0x0600000C RID: 12 RVA: 0x00002A34 File Offset: 0x00000C34
	public static void MoveRelative(int dx, int dy)
	{
		MouseWinApi.mouse_event(1U, dx, dy, 0U, UIntPtr.Zero);
	}

	// Token: 0x0600000D RID: 13 RVA: 0x00002A44 File Offset: 0x00000C44
	public static void MoveAbsolute(int x, int y, int screenWidth = 65535, int screenHeight = 65535)
	{
		int absX = x * 65535 / screenWidth;
		int absY = y * 65535 / screenHeight;
		MouseWinApi.mouse_event(32769U, absX, absY, 0U, UIntPtr.Zero);
	}

	// Token: 0x04000001 RID: 1
	private const uint MOUSEEVENTF_MOVE = 1U;

	// Token: 0x04000002 RID: 2
	private const uint MOUSEEVENTF_ABSOLUTE = 32768U;
}
