using System;
using System.Runtime.InteropServices;
using System.Threading;

// Token: 0x02000028 RID: 40
public static class AutoItX
{
	// Token: 0x0600002F RID: 47 RVA: 0x000040E4 File Offset: 0x000022E4
	public static void AU3_Send(string szSendText, int nMode = 0)
	{
		if (string.IsNullOrEmpty(szSendText))
		{
			return;
		}
		if (!szSendText.StartsWith("{") || !szSendText.EndsWith("}"))
		{
			for (int i = 0; i < szSendText.Length; i++)
			{
				short num = AutoItX.VkKeyScan(szSendText[i]);
				byte vk = (byte)(num & 255);
				bool flag = (num & 256) != 0;
				if (flag)
				{
					AutoItX.SendKeyEvent("SHIFT", true);
				}
				char c = (char)vk;
				AutoItX.SendKeyEvent(c.ToString(), true);
				c = (char)vk;
				AutoItX.SendKeyEvent(c.ToString(), false);
				if (flag)
				{
					AutoItX.SendKeyEvent("SHIFT", false);
				}
			}
			return;
		}
		string inner = szSendText.Substring(1, szSendText.Length - 2).Trim();
		string[] parts = inner.Split(new char[]
		{
			' '
		}, StringSplitOptions.RemoveEmptyEntries);
		if (parts.Length == 2 && (parts[1].Equals("down", StringComparison.OrdinalIgnoreCase) || parts[1].Equals("up", StringComparison.OrdinalIgnoreCase)))
		{
			bool isDown = parts[1].Equals("down", StringComparison.OrdinalIgnoreCase);
			AutoItX.SendKeyEvent(parts[0], isDown);
			return;
		}
		string keyName = inner;
		bool isDown2 = false;
		if (inner.EndsWith("UP", StringComparison.OrdinalIgnoreCase))
		{
			keyName = inner.Substring(0, inner.Length - 2);
			isDown2 = false;
		}
		else if (inner.EndsWith("DOWN", StringComparison.OrdinalIgnoreCase))
		{
			keyName = inner.Substring(0, inner.Length - 4);
			isDown2 = true;
		}
		AutoItX.SendKeyEvent(keyName, isDown2);
	}

	// Token: 0x06000030 RID: 48 RVA: 0x0000424A File Offset: 0x0000244A
	public static void AU3_Sleep(int milliseconds)
	{
		Thread.Sleep(milliseconds);
	}

	// Token: 0x06000031 RID: 49 RVA: 0x00004252 File Offset: 0x00002452
	public static void AU3_MouseDown(string button)
	{
		AutoItX.SendMouse(button, true);
	}

	// Token: 0x06000032 RID: 50 RVA: 0x0000425B File Offset: 0x0000245B
	public static void AU3_MouseUp(string button)
	{
		AutoItX.SendMouse(button, false);
	}

	// Token: 0x06000033 RID: 51 RVA: 0x00004264 File Offset: 0x00002464
	public static int AU3_PixelGetColor(int x, int y)
	{
		IntPtr hdc = AutoItX.GetDC(IntPtr.Zero);
		int pixel = (int)AutoItX.GetPixel(hdc, x, y);
		AutoItX.ReleaseDC(IntPtr.Zero, hdc);
		return pixel;
	}

	// Token: 0x06000034 RID: 52 RVA: 0x00004290 File Offset: 0x00002490
	public static void AU3_MouseClick(string button, int x, int y, int clicks, int speed)
	{
		AutoItX.SetCursorPos(x, y);
		for (int i = 0; i < clicks; i++)
		{
			AutoItX.SendMouse(button, true);
			AutoItX.SendMouse(button, false);
			if (speed > 0)
			{
				Thread.Sleep(speed);
			}
		}
	}

	// Token: 0x06000035 RID: 53 RVA: 0x000042CB File Offset: 0x000024CB
	public static void AU3_MouseMove(int x, int y, int speed)
	{
		AutoItX.SetCursorPos(x, y);
	}

	// Token: 0x06000036 RID: 54 RVA: 0x000042D8 File Offset: 0x000024D8
	private static void SendKeyEvent(string keyName, bool keyDown)
	{
		string text = keyName.ToUpperInvariant();
		ushort num;
		if (text != null)
		{
			switch (text.Length)
			{
			case 2:
				if (text == "UP")
				{
					num = 38;
					goto IL_2F5;
				}
				break;
			case 3:
			{
				char c = text[0];
				if (c != 'A')
				{
					if (c != 'E')
					{
						if (c == 'T')
						{
							if (text == "TAB")
							{
								num = 9;
								goto IL_2F5;
							}
						}
					}
					else if (text == "ESC")
					{
						num = 27;
						goto IL_2F5;
					}
				}
				else if (text == "ALT")
				{
					num = 18;
					goto IL_2F5;
				}
				break;
			}
			case 4:
			{
				char c = text[0];
				if (c <= 'D')
				{
					if (c != 'C')
					{
						if (c == 'D')
						{
							if (text == "DOWN")
							{
								num = 40;
								goto IL_2F5;
							}
						}
					}
					else if (text == "CTRL")
					{
						num = 17;
						goto IL_2F5;
					}
				}
				else if (c != 'L')
				{
					if (c == 'M')
					{
						if (text == "MENU")
						{
							num = 18;
							goto IL_2F5;
						}
					}
				}
				else if (text == "LEFT")
				{
					num = 37;
					goto IL_2F5;
				}
				break;
			}
			case 5:
			{
				char c = text[1];
				if (c <= 'I')
				{
					if (c != 'H')
					{
						if (c == 'I')
						{
							if (text == "RIGHT")
							{
								num = 39;
								goto IL_2F5;
							}
						}
					}
					else if (text == "SHIFT")
					{
						num = 16;
						goto IL_2F5;
					}
				}
				else if (c != 'N')
				{
					if (c == 'P')
					{
						if (text == "SPACE")
						{
							num = 32;
							goto IL_2F5;
						}
					}
				}
				else if (text == "ENTER")
				{
					num = 13;
					goto IL_2F5;
				}
				break;
			}
			case 6:
				if (text == "RETURN")
				{
					num = 13;
					goto IL_2F5;
				}
				break;
			case 7:
				if (text == "CONTROL")
				{
					num = 17;
					goto IL_2F5;
				}
				break;
			}
		}
		string fn = text;
		int fnum;
		if (fn.StartsWith("F", StringComparison.OrdinalIgnoreCase) && int.TryParse(fn.Substring(1), out fnum) && fnum >= 1 && fnum <= 24)
		{
			num = (ushort)(112 + fnum - 1);
		}
		else if (keyName.Length == 1 && char.IsLetterOrDigit(keyName[0]))
		{
			num = (ushort)char.ToUpperInvariant(keyName[0]);
		}
		else
		{
			num = (ushort)(AutoItX.VkKeyScan(keyName[0]) & 255);
		}
		IL_2F5:
		ushort vk = num;
		AutoItX.INPUT input = new AutoItX.INPUT
		{
			type = 1,
			U = new AutoItX.InputUnion
			{
				ki = new AutoItX.KEYBDINPUT
				{
					wVk = vk,
					wScan = 0,
					dwFlags = (keyDown ? 0U : 2U),
					time = 0U,
					dwExtraInfo = IntPtr.Zero
				}
			}
		};
		AutoItX.SendInput(1U, new AutoItX.INPUT[]
		{
			input
		}, Marshal.SizeOf<AutoItX.INPUT>());
	}

	// Token: 0x06000037 RID: 55 RVA: 0x00004660 File Offset: 0x00002860
	private static void SendMouse(string button, bool down)
	{
		string a = button.ToLowerInvariant();
		uint num;
		if (!(a == "right"))
		{
			if (!(a == "middle"))
			{
				num = (down ? 2U : 4U);
			}
			else
			{
				num = (down ? 32U : 64U);
			}
		}
		else
		{
			num = (down ? 8U : 16U);
		}
		uint flag = num;
		AutoItX.INPUT input = new AutoItX.INPUT
		{
			type = 0,
			U = new AutoItX.InputUnion
			{
				mi = new AutoItX.MOUSEINPUT
				{
					dx = 0,
					dy = 0,
					mouseData = 0,
					dwFlags = (int)flag,
					time = 0,
					dwExtraInfo = IntPtr.Zero
				}
			}
		};
		AutoItX.SendInput(1U, new AutoItX.INPUT[]
		{
			input
		}, Marshal.SizeOf<AutoItX.INPUT>());
	}

	// Token: 0x06000038 RID: 56
	[DllImport("user32.dll", SetLastError = true)]
	private static extern uint SendInput(uint nInputs, AutoItX.INPUT[] pInputs, int cbSize);

	// Token: 0x06000039 RID: 57
	[DllImport("user32.dll")]
	private static extern short VkKeyScan(char ch);

	// Token: 0x0600003A RID: 58
	[DllImport("user32.dll")]
	private static extern bool SetCursorPos(int X, int Y);

	// Token: 0x0600003B RID: 59
	[DllImport("user32.dll")]
	private static extern IntPtr GetDC(IntPtr hWnd);

	// Token: 0x0600003C RID: 60
	[DllImport("user32.dll")]
	private static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

	// Token: 0x0600003D RID: 61
	[DllImport("gdi32.dll")]
	private static extern uint GetPixel(IntPtr hdc, int nXPos, int nYPos);

	// Token: 0x04000003 RID: 3
	private const int INPUT_KEYBOARD = 1;

	// Token: 0x04000004 RID: 4
	private const int INPUT_MOUSE = 0;

	// Token: 0x04000005 RID: 5
	private const uint KEYEVENTF_KEYUP = 2U;

	// Token: 0x04000006 RID: 6
	private const ushort VK_SHIFT = 16;

	// Token: 0x04000007 RID: 7
	private const ushort VK_CONTROL = 17;

	// Token: 0x04000008 RID: 8
	private const ushort VK_MENU = 18;

	// Token: 0x04000009 RID: 9
	private const ushort VK_ESCAPE = 27;

	// Token: 0x0400000A RID: 10
	private const ushort VK_TAB = 9;

	// Token: 0x0400000B RID: 11
	private const ushort VK_RETURN = 13;

	// Token: 0x0400000C RID: 12
	private const ushort VK_SPACE = 32;

	// Token: 0x0400000D RID: 13
	private const ushort VK_LEFT = 37;

	// Token: 0x0400000E RID: 14
	private const ushort VK_UP = 38;

	// Token: 0x0400000F RID: 15
	private const ushort VK_RIGHT = 39;

	// Token: 0x04000010 RID: 16
	private const ushort VK_DOWN = 40;

	// Token: 0x04000011 RID: 17
	private const ushort VK_F1 = 112;

	// Token: 0x04000012 RID: 18
	private const uint MOUSEEVENTF_LEFTDOWN = 2U;

	// Token: 0x04000013 RID: 19
	private const uint MOUSEEVENTF_LEFTUP = 4U;

	// Token: 0x04000014 RID: 20
	private const uint MOUSEEVENTF_RIGHTDOWN = 8U;

	// Token: 0x04000015 RID: 21
	private const uint MOUSEEVENTF_RIGHTUP = 16U;

	// Token: 0x04000016 RID: 22
	private const uint MOUSEEVENTF_MIDDLEDOWN = 32U;

	// Token: 0x04000017 RID: 23
	private const uint MOUSEEVENTF_MIDDLEUP = 64U;

	// Token: 0x0200002A RID: 42
	private struct INPUT
	{
		// Token: 0x04000059 RID: 89
		public int type;

		// Token: 0x0400005A RID: 90
		public AutoItX.InputUnion U;
	}

	// Token: 0x0200002B RID: 43
	[StructLayout(LayoutKind.Explicit)]
	private struct InputUnion
	{
		// Token: 0x0400005B RID: 91
		[FieldOffset(0)]
		public AutoItX.MOUSEINPUT mi;

		// Token: 0x0400005C RID: 92
		[FieldOffset(0)]
		public AutoItX.KEYBDINPUT ki;
	}

	// Token: 0x0200002C RID: 44
	private struct MOUSEINPUT
	{
		// Token: 0x0400005D RID: 93
		public int dx;

		// Token: 0x0400005E RID: 94
		public int dy;

		// Token: 0x0400005F RID: 95
		public int mouseData;

		// Token: 0x04000060 RID: 96
		public int dwFlags;

		// Token: 0x04000061 RID: 97
		public int time;

		// Token: 0x04000062 RID: 98
		public IntPtr dwExtraInfo;
	}

	// Token: 0x0200002D RID: 45
	private struct KEYBDINPUT
	{
		// Token: 0x04000063 RID: 99
		public ushort wVk;

		// Token: 0x04000064 RID: 100
		public ushort wScan;

		// Token: 0x04000065 RID: 101
		public uint dwFlags;

		// Token: 0x04000066 RID: 102
		public uint time;

		// Token: 0x04000067 RID: 103
		public IntPtr dwExtraInfo;
	}
}
