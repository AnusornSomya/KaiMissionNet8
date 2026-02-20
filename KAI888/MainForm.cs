using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Globalization;
using System.Reflection;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace ImageSearchUI
{
	// Token: 0x02000029 RID: 41
	public partial class MainForm : Form
	{
		// Token: 0x0600003E RID: 62 RVA: 0x00004734 File Offset: 0x00002934
		private void SaveCheckboxStates()
		{
			Dictionary<string, bool> state = new Dictionary<string, bool>
			{
				{
					"chkClosePass",
					this.chkClosePass.Checked
				},
				{
					"chkCloseSpecial",
					this.chkCloseSpecial.Checked
				},
				{
					"chkCloseMessage",
					this.chkCloseMessage.Checked
				},
				{
					"chkCheckIN",
					this.chkCheckIN.Checked
				},
				{
					"chkCloseCheck",
					this.chkCloseCheck.Checked
				},
				{
					"chkStartGame",
					this.chkStartGame.Checked
				},
				{
					"chkReady",
					this.chkReady.Checked
				},
				{
					"chkNotReady",
					this.chkNotReady.Checked
				},
				{
					"chkOk1",
					this.chkOk1.Checked
				},
				{
					"chkOk2",
					this.chkOk2.Checked
				},
				{
					"chkOkMission",
					this.chkOkMission.Checked
				},
				{
					"chkEndGame",
					this.chkEndGame.Checked
				},
				{
					"chkOutRoom",
					this.chkOutRoom.Checked
				},
				{
					"chkGiveHead",
					this.chkGiveHead.Checked
				},
				{
					"chkOrderF5",
					this.chkOrderF5.Checked
				},
				{
					"chkSlasHead",
					this.chkSlasHead.Checked
				},
				{
					"chkSlasBody",
					this.chkSlasBody.Checked
				},
				{
					"chkBuff",
					this.chkBuff.Checked
				},
				{
					"chkCornerR",
					this.chkCornerR.Checked
				},
				{
					"chkCornerL",
					this.chkCornerL.Checked
				},
				{
					"chkNotCorner",
					this.chkNotCorner.Checked
				},
				{
					"chkMissionHit",
					this.chkMissionHit.Checked
				},
				{
					"chkMissionAttack",
					this.chkMissionAttack.Checked
				},
				{
					"chkWigHead",
					this.chkWigHead.Checked
				},
				{
					"chkWigBody",
					this.chkWigBody.Checked
				},
				{
					"chkExpClan",
					this.chkExpClan.Checked
				},
				{
					"chkWaterPark",
					this.chkWaterPark.Checked
				},
				{
					"chkTower11",
					this.chkTower11.Checked
				},
				{
					"chkMetro",
					this.chkMetro.Checked
				},
				{
					"chkFatalZone",
					this.chkFatalZone.Checked
				},
				{
					"chkFalluCity",
					this.chkFalluCity.Checked
				},
				{
					"chkMarineWave",
					this.chkMarineWave.Checked
				},
				{
					"chkSlasHeadSpawn30",
					this.chkSlasHeadSpawn30.Checked
				},
				{
					"chkSlasBodySpawn30",
					this.chkSlasBodySpawn30.Checked
				},
				{
					"chkSlasHeadSpawn50",
					this.chkSlasHeadSpawn50.Checked
				},
				{
					"chkSlasBodySpawn50",
					this.chkSlasBodySpawn50.Checked
				},
				{
					"chkSlasHeadSpawn100",
					this.chkSlasHeadSpawn100.Checked
				},
				{
					"chkSlasBodySpawn100",
					this.chkSlasBodySpawn100.Checked
				}
			};
			File.WriteAllText(this.checkboxStatePath, JsonConvert.SerializeObject(state));
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00004A9C File Offset: 0x00002C9C
		private void LoadCheckboxStates()
		{
			if (File.Exists(this.checkboxStatePath))
			{
				Dictionary<string, bool> state = JsonConvert.DeserializeObject<Dictionary<string, bool>>(File.ReadAllText(this.checkboxStatePath));
				this.chkClosePass.Checked = (state.ContainsKey("chkClosePass") && state["chkClosePass"]);
				this.chkCloseSpecial.Checked = (state.ContainsKey("chkCloseSpecial") && state["chkCloseSpecial"]);
				this.chkCloseMessage.Checked = (state.ContainsKey("chkCloseMessage") && state["chkCloseMessage"]);
				this.chkCheckIN.Checked = (state.ContainsKey("chkCheckIN") && state["chkCheckIN"]);
				this.chkCloseCheck.Checked = (state.ContainsKey("chkCloseCheck") && state["chkCloseCheck"]);
				this.chkStartGame.Checked = (state.ContainsKey("chkStartGame") && state["chkStartGame"]);
				this.chkReady.Checked = (state.ContainsKey("chkReady") && state["chkReady"]);
				this.chkNotReady.Checked = (state.ContainsKey("chkNotReady") && state["chkNotReady"]);
				this.chkOk1.Checked = (state.ContainsKey("chkOk1") && state["chkOk1"]);
				this.chkOk2.Checked = (state.ContainsKey("chkOk2") && state["chkOk2"]);
				this.chkOkMission.Checked = (state.ContainsKey("chkOkMission") && state["chkOkMission"]);
				this.chkEndGame.Checked = (state.ContainsKey("chkEndGame") && state["chkEndGame"]);
				this.chkOutRoom.Checked = (state.ContainsKey("chkOutRoom") && state["chkOutRoom"]);
				this.chkGiveHead.Checked = (state.ContainsKey("chkGiveHead") && state["chkGiveHead"]);
				this.chkOrderF5.Checked = (state.ContainsKey("chkOrderF5") && state["chkOrderF5"]);
				this.chkSlasHead.Checked = (state.ContainsKey("chkSlasHead") && state["chkSlasHead"]);
				this.chkSlasBody.Checked = (state.ContainsKey("chkSlasBody") && state["chkSlasBody"]);
				this.chkBuff.Checked = (state.ContainsKey("chkBuff") && state["chkBuff"]);
				this.chkCornerR.Checked = (state.ContainsKey("chkCornerR") && state["chkCornerR"]);
				this.chkCornerL.Checked = (state.ContainsKey("chkCornerL") && state["chkCornerL"]);
				this.chkNotCorner.Checked = (state.ContainsKey("chkNotCorner") && state["chkNotCorner"]);
				this.chkMissionHit.Checked = (state.ContainsKey("chkMissionHit") && state["chkMissionHit"]);
				this.chkMissionAttack.Checked = (state.ContainsKey("chkMissionAttack") && state["chkMissionAttack"]);
				this.chkWigHead.Checked = (state.ContainsKey("chkWigHead") && state["chkWigHead"]);
				this.chkWigBody.Checked = (state.ContainsKey("chkWigBody") && state["chkWigBody"]);
				this.chkExpClan.Checked = (state.ContainsKey("chkExpClan") && state["chkExpClan"]);
				this.chkWaterPark.Checked = (state.ContainsKey("chkWaterPark") && state["chkWaterPark"]);
				this.chkTower11.Checked = (state.ContainsKey("chkTower11") && state["chkTower11"]);
				this.chkMetro.Checked = (state.ContainsKey("chkMetro") && state["chkMetro"]);
				this.chkFatalZone.Checked = (state.ContainsKey("chkFatalZone") && state["chkFatalZone"]);
				this.chkFalluCity.Checked = (state.ContainsKey("chkFalluCity") && state["chkFalluCity"]);
				this.chkMarineWave.Checked = (state.ContainsKey("chkMarineWave") && state["chkMarineWave"]);
				this.chkSlasHeadSpawn30.Checked = (state.ContainsKey("chkSlasHeadSpawn30") && state["chkSlasHeadSpawn30"]);
				this.chkSlasBodySpawn30.Checked = (state.ContainsKey("chkSlasBodySpawn30") && state["chkSlasBodySpawn30"]);
				this.chkSlasHeadSpawn50.Checked = (state.ContainsKey("chkSlasHeadSpawn50") && state["chkSlasHeadSpawn50"]);
				this.chkSlasBodySpawn50.Checked = (state.ContainsKey("chkSlasBodySpawn50") && state["chkSlasBodySpawn50"]);
				this.chkSlasHeadSpawn100.Checked = (state.ContainsKey("chkSlasHeadSpawn100") && state["chkSlasHeadSpawn100"]);
				this.chkSlasBodySpawn100.Checked = (state.ContainsKey("chkSlasBodySpawn100") && state["chkSlasBodySpawn100"]);

			}
		}


		private void HighlightSelectedButton(Button selected)
		{
			// ถ้ามีปุ่มก่อนหน้า → ล้างสีเดิม
			if (selectedSetButton != null)
			{
				selectedSetButton.BackColor = defaultButtonBackColor;
			}

			// เปลี่ยนสีปุ่มใหม่เป็นสีฟ้าอ่อน
			selected.BackColor = Color.LightSkyBlue;

			// เก็บไว้ว่าอันนี้คือปุ่มที่เลือกล่าสุด
			selectedSetButton = selected;
			this.UpdateMissionOptionsVisibility();
		}

		private void ResetHighlightedButton()
		{
			if (selectedSetButton != null)
			{
				selectedSetButton.BackColor = defaultButtonBackColor;
				selectedSetButton = null;
			}
			this.UpdateMissionOptionsVisibility();
		}

		private void UpdateMissionOptionsVisibility()
		{
			if (this.missionOptionsPanel == null)
			{
				return;
			}

			bool isNormalMission = selectedSetButton == this.btnMission;
			bool isKaiMission = selectedSetButton == this.btnKaiMission;

			// Only allow selecting mission types when using the normal "ปั้มฉายา" button.
			this.chkMissionAttack.Enabled = isNormalMission;
			this.chkMissionHit.Enabled = isNormalMission;

			if (isKaiMission)
			{
				// Kai mode: force-clear and lock the mission type options.
				this.chkMissionAttack.Checked = false;
				this.chkMissionHit.Checked = false;
			}
			else if (isNormalMission)
			{
				this.EnsureMissionOptionDefaults();
			}

			// Show the mission options only for normal mission mode.
			this.missionOptionsPanel.Visible = isNormalMission;
		}

		private void EnsureMissionOptionDefaults()
		{
			// If the user hasn't chosen a mission type yet, default to "ภารกิจจู่โจม".
			if (!this.chkMissionHit.Checked && !this.chkMissionAttack.Checked)
			{
				this.chkMissionAttack.Checked = true;
			}
		}

		public struct RECT
		{
			// Token: 0x040000B9 RID: 185
			public int Left;

			// Token: 0x040000BA RID: 186
			public int Top;

			// Token: 0x040000BB RID: 187
			public int Right;

			// Token: 0x040000BC RID: 188
			public int Bottom;
		}

		[DllImport("user32.dll")]
		private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

		[DllImport("user32.dll")]
		private static extern bool GetWindowRect(IntPtr hwnd, out MainForm.RECT lpRect);

		// Token: 0x06000042 RID: 66
		[DllImport("user32.dll")]
		private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

		// Token: 0x06000043 RID: 67
		[DllImport("user32.dll")]
		private static extern void mouse_event(uint dwFlags, int dx, int dy, uint dwData, UIntPtr dwExtraInfo);
		private static Rectangle customRegion = new Rectangle(512, 153, 15, 384);

		private static int redThreshold = 200;

		// Token: 0x0400002E RID: 46
		private static int greenThreshold = 50;

		// Token: 0x0400002F RID: 47
		private static int blueThreshold = 50;

		// Default: single left-click with no delay when target detected
		private static List<ActionItem> actionSequence = new List<ActionItem>
		{
			new ActionItem(ActionItem.ActionType.MouseClick, "left", 0)
		};

		private static IntPtr FindGameWindow()
		{
			IntPtr hwnd = MainForm.FindWindow("PBApp", null);
			if (hwnd == IntPtr.Zero)
			{
				return IntPtr.Zero;
			}
			return hwnd;
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00008AAC File Offset: 0x00006CAC
		private static Rectangle GetWindowRect(IntPtr hwnd)
		{
			if (hwnd == IntPtr.Zero)
			{
				return Rectangle.Empty;
			}
			MainForm.RECT rect;
			MainForm.GetWindowRect(hwnd, out rect);
			return new Rectangle(rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top);
		}

		// Token: 0x06000066 RID: 102 RVA: 0x00008B00 File Offset: 0x00006D00
		private static Bitmap CaptureScreen(Rectangle region)
		{
			Bitmap result;
			try
			{
				Bitmap bitmap = new Bitmap(region.Width, region.Height);
				using (Graphics graphics = Graphics.FromImage(bitmap))
				{
					graphics.CopyFromScreen(region.Left, region.Top, 0, 0, bitmap.Size);
				}
				result = bitmap;
			}
			catch
			{
				result = null;
			}
			return result;
		}

		private static bool DetectRedPixelBgr(Bitmap image)
		{
			if (image == null)
			{
				return false;
			}
			bool result;
			try
			{
				for (int y = 0; y < image.Height; y++)
				{
					for (int x = 0; x < image.Width; x++)
					{
						Color pixel = image.GetPixel(x, y);
						if ((int)pixel.B <= MainForm.blueThreshold && (int)pixel.G <= MainForm.greenThreshold && (int)pixel.R >= MainForm.redThreshold)
						{
							return true;
						}
					}
				}
				result = false;
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		private static void MainFunction()
		{
			IntPtr hwnd = MainForm.FindGameWindow();
			if (hwnd == IntPtr.Zero)
			{
				return;
			}
			Rectangle windowRect = MainForm.GetWindowRect(hwnd);
			if (windowRect == Rectangle.Empty)
			{
				return;
			}
			using (Bitmap screenshot = MainForm.CaptureScreen(new Rectangle(windowRect.Left + MainForm.customRegion.Left, windowRect.Top + MainForm.customRegion.Top, MainForm.customRegion.Width, MainForm.customRegion.Height)))
			{
				if (screenshot != null && MainForm.DetectRedPixelBgr(screenshot))
				{
					foreach (ActionItem action in MainForm.actionSequence)
					{
						switch (action.Type)
						{
							case ActionItem.ActionType.MouseClick:
								{
									uint downFlag = 0U;
									uint upFlag = 0U;
									uint mouseData = 0U;
									string text = action.Value.ToLower();
									if (!(text == "left"))
									{
										if (!(text == "right"))
										{
											if (!(text == "middle"))
											{
												if (!(text == "side button 1"))
												{
													if (text == "side button 2")
													{
														downFlag = 128U;
														upFlag = 256U;
														mouseData = 2U;
													}
												}
												else
												{
													downFlag = 128U;
													upFlag = 256U;
													mouseData = 1U;
												}
											}
											else
											{
												downFlag = 32U;
												upFlag = 64U;
											}
										}
										else
										{
											downFlag = 8U;
											upFlag = 16U;
										}
									}
									else
									{
										downFlag = 2U;
										upFlag = 4U;
									}
									if (downFlag != 0U && upFlag != 0U)
									{
										MainForm.mouse_event(downFlag, 0, 0, mouseData, UIntPtr.Zero);
										Thread.Sleep(action.DelayMs);
										MainForm.mouse_event(upFlag, 0, 0, mouseData, UIntPtr.Zero);
									}
									break;
								}
							case ActionItem.ActionType.KeyPress:
								{
									byte keyCode = 0;
									string text = action.Value;
									if (text != null)
									{
										switch (text.Length)
										{
											case 1:
												switch (text[0])
												{
													case '0':
														keyCode = 48;
														break;
													case '1':
														keyCode = 49;
														break;
													case '2':
														keyCode = 50;
														break;
													case '3':
														keyCode = 51;
														break;
													case '4':
														keyCode = 52;
														break;
													case '5':
														keyCode = 53;
														break;
													case '6':
														keyCode = 54;
														break;
													case '7':
														keyCode = 55;
														break;
													case '8':
														keyCode = 56;
														break;
													case '9':
														keyCode = 57;
														break;
													case 'A':
														keyCode = 65;
														break;
													case 'B':
														keyCode = 66;
														break;
													case 'C':
														keyCode = 67;
														break;
													case 'D':
														keyCode = 68;
														break;
													case 'E':
														keyCode = 69;
														break;
													case 'F':
														keyCode = 70;
														break;
													case 'G':
														keyCode = 71;
														break;
													case 'H':
														keyCode = 72;
														break;
													case 'I':
														keyCode = 73;
														break;
													case 'J':
														keyCode = 74;
														break;
													case 'K':
														keyCode = 75;
														break;
													case 'L':
														keyCode = 76;
														break;
													case 'M':
														keyCode = 77;
														break;
													case 'N':
														keyCode = 78;
														break;
													case 'O':
														keyCode = 79;
														break;
													case 'P':
														keyCode = 80;
														break;
													case 'Q':
														keyCode = 81;
														break;
													case 'R':
														keyCode = 82;
														break;
													case 'S':
														keyCode = 83;
														break;
													case 'T':
														keyCode = 84;
														break;
													case 'U':
														keyCode = 85;
														break;
													case 'V':
														keyCode = 86;
														break;
													case 'W':
														keyCode = 87;
														break;
													case 'X':
														keyCode = 88;
														break;
													case 'Y':
														keyCode = 89;
														break;
													case 'Z':
														keyCode = 90;
														break;
												}
												break;
											case 2:
												switch (text[1])
												{
													case '1':
														if (text == "F1")
														{
															keyCode = 112;
														}
														break;
													case '2':
														if (text == "F2")
														{
															keyCode = 113;
														}
														break;
													case '3':
														if (text == "F3")
														{
															keyCode = 114;
														}
														break;
													case '4':
														if (text == "F4")
														{
															keyCode = 115;
														}
														break;
													case '5':
														if (text == "F5")
														{
															keyCode = 116;
														}
														break;
													case '6':
														if (text == "F6")
														{
															keyCode = 117;
														}
														break;
													case '7':
														if (text == "F7")
														{
															keyCode = 118;
														}
														break;
													case '8':
														if (text == "F8")
														{
															keyCode = 119;
														}
														break;
													case '9':
														if (text == "F9")
														{
															keyCode = 120;
														}
														break;
												}
												break;
											case 3:
												{
													char c = text[2];
													if (c <= 'b')
													{
														switch (c)
														{
															case '0':
																if (text == "F10")
																{
																	keyCode = 121;
																}
																break;
															case '1':
																if (text == "F11")
																{
																	keyCode = 122;
																}
																break;
															case '2':
																if (text == "F12")
																{
																	keyCode = 123;
																}
																break;
															default:
																if (c == 'b')
																{
																	if (text == "Tab")
																	{
																		keyCode = 9;
																	}
																}
																break;
														}
													}
													else if (c != 'd')
													{
														if (c == 't')
														{
															if (text == "Alt")
															{
																keyCode = 18;
															}
														}
													}
													else if (text == "End")
													{
														keyCode = 35;
													}
													break;
												}
											case 4:
												{
													char c = text[0];
													if (c != 'C')
													{
														if (c == 'H')
														{
															if (text == "Home")
															{
																keyCode = 36;
															}
														}
													}
													else if (text == "Ctrl")
													{
														keyCode = 17;
													}
													break;
												}
											case 5:
												{
													char c = text[1];
													if (c != 'h')
													{
														if (c != 'n')
														{
															if (c == 'p')
															{
																if (text == "Space")
																{
																	keyCode = 32;
																}
															}
														}
														else if (text == "Enter")
														{
															keyCode = 13;
														}
													}
													else if (text == "Shift")
													{
														keyCode = 16;
													}
													break;
												}
											case 6:
												{
													char c = text[0];
													if (c != 'D')
													{
														if (c != 'E')
														{
															if (c == 'I')
															{
																if (text == "Insert")
																{
																	keyCode = 45;
																}
															}
														}
														else if (text == "Escape")
														{
															keyCode = 27;
														}
													}
													else if (text == "Delete")
													{
														keyCode = 46;
													}
													break;
												}
											case 7:
												if (text == "Page Up")
												{
													keyCode = 33;
												}
												break;
											case 8:
												{
													char c = text[7];
													switch (c)
													{
														case '*':
															if (text == "Numpad *")
															{
																keyCode = 106;
															}
															break;
														case '+':
															if (text == "Numpad +")
															{
																keyCode = 107;
															}
															break;
														case ',':
															break;
														case '-':
															if (text == "Numpad -")
															{
																keyCode = 109;
															}
															break;
														case '.':
															if (text == "Numpad .")
															{
																keyCode = 110;
															}
															break;
														case '/':
															if (text == "Numpad /")
															{
																keyCode = 111;
															}
															break;
														case '0':
															if (text == "Numpad 0")
															{
																keyCode = 96;
															}
															break;
														case '1':
															if (text == "Numpad 1")
															{
																keyCode = 97;
															}
															break;
														case '2':
															if (text == "Numpad 2")
															{
																keyCode = 98;
															}
															break;
														case '3':
															if (text == "Numpad 3")
															{
																keyCode = 99;
															}
															break;
														case '4':
															if (text == "Numpad 4")
															{
																keyCode = 100;
															}
															break;
														case '5':
															if (text == "Numpad 5")
															{
																keyCode = 101;
															}
															break;
														case '6':
															if (text == "Numpad 6")
															{
																keyCode = 102;
															}
															break;
														case '7':
															if (text == "Numpad 7")
															{
																keyCode = 103;
															}
															break;
														case '8':
															if (text == "Numpad 8")
															{
																keyCode = 104;
															}
															break;
														case '9':
															if (text == "Numpad 9")
															{
																keyCode = 105;
															}
															break;
														default:
															if (c == 'w')
															{
																if (text == "Up Arrow")
																{
																	keyCode = 38;
																}
															}
															break;
													}
													break;
												}
											case 9:
												{
													char c = text[0];
													if (c != 'B')
													{
														if (c != 'C')
														{
															if (c == 'P')
															{
																if (text == "Page Down")
																{
																	keyCode = 34;
																}
															}
														}
														else if (text == "Caps Lock")
														{
															keyCode = 20;
														}
													}
													else if (text == "Backspace")
													{
														keyCode = 8;
													}
													break;
												}
											case 10:
												{
													char c = text[0];
													if (c != 'D')
													{
														if (c == 'L')
														{
															if (text == "Left Arrow")
															{
																keyCode = 37;
															}
														}
													}
													else if (text == "Down Arrow")
													{
														keyCode = 40;
													}
													break;
												}
											case 11:
												if (text == "Right Arrow")
												{
													keyCode = 39;
												}
												break;
										}
									}
									if (keyCode != 0)
									{
										MainForm.keybd_event(keyCode, 0, 0U, UIntPtr.Zero);
										Thread.Sleep(10);
										MainForm.keybd_event(keyCode, 0, 2U, UIntPtr.Zero);
									}
									break;
								}
							case ActionItem.ActionType.Delay:
								Thread.Sleep(action.DelayMs);
								break;
						}
					}
				}
			}
		}


		// Token: 0x06000040 RID: 64 RVA: 0x00005070 File Offset: 0x00003270
		public MainForm()
		{

			Image formBackgroundImage = null;
			try
			{
				// ตัวอย่าง Base64 string (ให้แทนด้วยของคุณเอง)
				string base64String = "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";

				// แปลง Base64 -> Image
				byte[] imageBytes = Convert.FromBase64String(base64String);
				using (MemoryStream ms = new MemoryStream(imageBytes))
				{
					formBackgroundImage = Image.FromStream(ms);
				}
			}
			catch
			{
				formBackgroundImage = null; // fallback
			}


			//if (File.Exists(imagePath))
			//{
			this.BackgroundImage = formBackgroundImage;
			this.BackgroundImageLayout = ImageLayout.Stretch;
			this.BackColor = Color.Black;
			this.ShowIcon = false;

			//}
			Photo.save();
			this.Text = "KAIMISSION By RedSkull";
			base.Size = new Size(500, 400);
			base.FormBorderStyle = FormBorderStyle.FixedSingle;
			base.MaximizeBox = false;

			this.btnToggleStart = new Button
			{
				Text = "เริ่มการทำงาน",
				Location = new Point(20, 15),
				Size = new Size(180, 30)
			};
			this.chkstart = new CheckBox
			{
				Text = "✅ เริ่มการค้นหา",
				Location = new Point(20, 20),
				AutoSize = true,
				Visible = false // 👈 ซ่อนไว้ไม่ให้แสดงบน UI
			};
			//this.chkstart = new CheckBox
			//         {
			//             Text = "✅ เริ่มการค้นหา",
			//             Location = new Point(20, 20),
			//             AutoSize = true
			//         };
			this.chkClosePass = new CheckBox
			{
				Text = "ปิดพาส",
				Location = new Point(20, 40),
				AutoSize = true
			};
			this.chkCloseSpecial = new CheckBox
			{
				Text = "ปิดราคาพิเศษ",
				Location = new Point(20, 60),
				AutoSize = true
			};
			this.chkCloseMessage = new CheckBox
			{
				Text = "ปิดEvent",
				Location = new Point(20, 80),
				AutoSize = true
			};
			this.chkCheckIN = new CheckBox
			{
				Text = "เช็คอิน",
				Location = new Point(20, 100),
				AutoSize = true
			};
			this.chkCloseCheck = new CheckBox
			{
				Text = "ปิดเช็คอิน",
				Location = new Point(20, 120),
				AutoSize = true
			};
			this.chkStartGame = new CheckBox
			{
				Text = "เริ่มเกม",
				Location = new Point(20, 140),
				AutoSize = true
			};
			this.chkReady = new CheckBox
			{
				Text = "กดพร้อม",
				Location = new Point(20, 160),
				AutoSize = true
			};
			this.chkNotReady = new CheckBox
			{
				Text = "กดยกเลิก",
				Location = new Point(20, 180),
				AutoSize = true
			};
			this.chkOk1 = new CheckBox
			{
				Text = "ยืนยันใหญ๋",
				Location = new Point(20, 200),
				AutoSize = true
			};
			this.chkOk2 = new CheckBox
			{
				Text = "ยืนยันเล็ก",
				Location = new Point(20, 220),
				AutoSize = true
			};
			this.chkOkMission = new CheckBox
			{
				Text = "ยืนยันภารกิจ",
				Location = new Point(20, 240),
				AutoSize = true
			};
			this.chkEndGame = new CheckBox
			{
				Text = "ยืนยันจบเกมส์",
				Location = new Point(20, 260),
				AutoSize = true
			};
			this.chkOutRoom = new CheckBox
			{
				Text = "สั่งออกห้อง",
				Location = new Point(20, 280),
				AutoSize = true
			};
			this.chkGiveHead = new CheckBox
			{
				Text = "ให้หัวออโต้",
				Location = new Point(20, 300),
				AutoSize = true
			};
			this.chkOrderF5 = new CheckBox
			{
				Text = "สั่งกดพร้อม",
				Location = new Point(20, 320),
				AutoSize = true
			};
			this.chkSlasHead = new CheckBox
			{
				Text = "เดินฟันหัวBH",
				Location = new Point(200, 80),
				AutoSize = true
			};
			this.chkSlasBody = new CheckBox
			{
				Text = "เดินฟันตัวBH",
				Location = new Point(200, 100),
				AutoSize = true
			};
			this.chkBuff = new CheckBox
			{
				Text = "ปั้มบัพแคลนCTY",
				Location = new Point(200, 120),
				AutoSize = true
			};
			this.chkCornerR = new CheckBox
			{
				Text = "สั่งชิดมุมขวา",
				Location = new Point(200, 140),
				AutoSize = true
			};
			this.chkCornerL = new CheckBox
			{
				Text = "สั่งชิดมุมซ้าย",
				Location = new Point(200, 160),
				AutoSize = true
			};
			this.chkNotCorner = new CheckBox
			{
				Text = "สั่งยืนนิ่ง",
				Location = new Point(200, 180),
				AutoSize = true
			};
			this.chkMissionHit = new CheckBox
			{
				Text = "ภารกิจตีฝ่า",
				Location = new Point(200, 200),
				AutoSize = true
			};
			this.chkMissionAttack = new CheckBox
			{
				Text = "ภารกิจจู่โจม",
				Location = new Point(200, 220),
				AutoSize = true
			};
			this.chkWigHead = new CheckBox
			{
				Text = "เดินฟันหัวBH[วิก]",
				Location = new Point(200, 240),
				AutoSize = true
			};
			this.chkWigBody = new CheckBox
			{
				Text = "เดินฟันตัวBH[วิก]",
				Location = new Point(200, 260),
				AutoSize = true
			};
			this.chkExpClan = new CheckBox
			{
				Text = "ปั้มเวลแคลน",
				Location = new Point(200, 280),
				AutoSize = true
			};
			this.chkWaterPark = new CheckBox
			{
				Text = "เดินฟันWaterPark[R]",
				Location = new Point(400, 40),
				AutoSize = true
			};
			this.chkTower11 = new CheckBox
			{
				Text = "เดินฟันTower11[B]",
				Location = new Point(400, 60),
				AutoSize = true
			};
			this.chkMetro = new CheckBox
			{
				Text = "เดินฟันMetro[R]",
				Location = new Point(400, 80),
				AutoSize = true
			};
			this.chkFatalZone = new CheckBox
			{
				Text = "เดินฟันFatalZone[B]",
				Location = new Point(400, 100),
				AutoSize = true
			};
			this.chkFalluCity = new CheckBox
			{
				Text = "ปั้มบัพFalluCity[R]",
				Location = new Point(400, 140),
				AutoSize = true
			};
			this.chkMarineWave = new CheckBox
			{
				Text = "ปั้มบัพMarineWave[R]",
				Location = new Point(400, 160),
				AutoSize = true
			};
			this.chkSlasHeadSpawn30 = new CheckBox
			{
				Text = "เดินฟันหัวBH[30%]",
				Location = new Point(400, 200),
				AutoSize = true
			};
			this.chkSlasBodySpawn30 = new CheckBox
			{
				Text = "เดินฟันตัวBH[30%]",
				Location = new Point(400, 220),
				AutoSize = true
			};
			this.chkSlasHeadSpawn50 = new CheckBox
			{
				Text = "เดินฟันหัวBH[50%]",
				Location = new Point(400, 240),
				AutoSize = true
			};
			this.chkSlasBodySpawn50 = new CheckBox
			{
				Text = "เดินฟันตัวBH[50%]",
				Location = new Point(400, 260),
				AutoSize = true
			};
			this.chkSlasHeadSpawn100 = new CheckBox
			{
				Text = "เดินฟันหัวBH[100%]",
				Location = new Point(400, 280),
				AutoSize = true
			};
			this.chkSlasBodySpawn100 = new CheckBox
			{
				Text = "เดินฟันตัวBH[100%]",
				Location = new Point(400, 300),
				AutoSize = true
			};
			this.lblStatus = new Label
			{
				Text = "\ud83d\udfe1 สถานะ: รอ",
				Location = new Point(20, 340),
				Size = new Size(360, 40),
				AutoSize = false,
				MaximumSize = new Size(360, 0),
				AutoEllipsis = true
			};
			this.lblLicenseStatus = new Label
			{
				Text = "สถานะใบอนุญาต: กำลังตรวจสอบ...",
				AutoSize = false,
				Size = new Size(540, 20),
				TextAlign = ContentAlignment.MiddleCenter,
				ForeColor = Color.White
			};
			this.lblLicenseTime = new Label
			{
				Text = string.Empty,
				AutoSize = false,
				Size = new Size(540, 18),
				TextAlign = ContentAlignment.MiddleCenter,
				ForeColor = Color.LightGray
			};
			this.NameBot1 = new Label
			{
				Text = "Bot Exp Basic",
				Location = new Point(200, 60),
				Size = new Size(360, 40),
				AutoSize = true,
				MaximumSize = new Size(360, 0),
				AutoEllipsis = true
			};
			this.NameBot2 = new Label
			{
				Text = "Death Match Event +Exp%",
				Location = new Point(400, 20),
				Size = new Size(360, 40),
				AutoSize = true,
				MaximumSize = new Size(360, 0),
				AutoEllipsis = true
			};
			this.NameBot3 = new Label
			{
				Text = "Boom Match Event +Exp%",
				Location = new Point(400, 120),
				Size = new Size(360, 40),
				AutoSize = true,
				MaximumSize = new Size(360, 0),
				AutoEllipsis = true
			};
			this.NameBot4 = new Label
			{
				Text = "Bot Exp Spawn",
				Location = new Point(400, 180),
				Size = new Size(360, 40),
				AutoSize = true,
				MaximumSize = new Size(360, 0),
				AutoEllipsis = true
			};
			this.NameBot5 = new Label
			{
				Text = "Bot Exp Clan",
				Location = new Point(265, 390),
				Size = new Size(360, 40),
				AutoSize = true,
				MaximumSize = new Size(360, 0),
				AutoEllipsis = true
			};
			this.lblStatus.AutoSize = true;
			this.lblStatus.MaximumSize = new Size(540, 0);
			this.btnExp = new Button
			{
				Text = "ปั้มExp (BH)",
				Location = new Point(20, 390),
				Size = new Size(120, 20)
			};
			this.btnBuff = new Button
			{
				Text = "ปั้มบัพแคลน (CTY)",
				Location = new Point(20, 410),
				Size = new Size(120, 20)
			};
			this.btnMission = new Button
			{
				Text = "ปั้มฉายา",
				Location = new Point(20, 430),
				Size = new Size(120, 20)
			};
			this.btnMission.Visible = true;
			this.btnKaiRun = new Button
			{
				Text = "ไก่ชิดมุม",
				Location = new Point(140, 390),
				Size = new Size(120, 20)
			};
			this.btnKaiStill = new Button
			{
				Text = "ไก่บัพแคลน",
				Location = new Point(140, 410),
				Size = new Size(120, 20)
			};
			this.btnKaiMission = new Button
			{
				Text = "ไก่ปั้มฉายา",
				Location = new Point(140, 430),
				Size = new Size(120, 20)
			};
			this.btnKaiMission.Visible = true;
			this.btnExpClan = new Button
			{
				Text = "ปั้มเวลแคลน",
				Location = new Point(260, 410),
				Size = new Size(120, 20)
			};
			this.btnKaiClan = new Button
			{
				Text = "ไก่ปั้มเวลแคลน",
				Location = new Point(380, 410),
				Size = new Size(120, 20)
			};
			this.btnReKey = new Button
			{
				Text = "รีเซ็ทตั้งค่า",
				Location = new Point(260, 430),
				Size = new Size(120, 20)
			};

			// Show only title-related buttons on the main UI.
			this.btnExp.Visible = false;
			this.btnBuff.Visible = false;
			this.btnKaiRun.Visible = false;
			this.btnKaiStill.Visible = false;
			this.btnExpClan.Visible = false;
			this.btnKaiClan.Visible = false;
			this.btnReKey.Visible = false;
			this.btnPause = new Button
			{
				Text = "หยุดชั่วคราว",
				Location = new Point(390, 15), // ขยับมาให้ชิดขวา
				Size = new Size(180, 30)
			};
			this.cancellationSource = new CancellationTokenSource();
			this.Shown += async (s, e) => await InitializeLicenseAsync();
			base.Controls.AddRange(new Control[]
			{
				this.btnToggleStart,
				this.chkstart,
                this.btnExp,
                this.btnBuff,
                this.btnMission,
                this.btnKaiRun,
                this.btnKaiStill,
                this.btnKaiMission,
                this.btnExpClan,
                this.btnKaiClan,
                this.btnReKey,
                //this.btnPause,
				this.lblLicenseStatus,
				this.lblLicenseTime,
				this.lblStatus,
				//this.NameBot1,
				//this.NameBot2,
				//this.NameBot3,
				//this.NameBot4,
				//this.NameBot5,
				//this.chkClosePass,
				//this.chkCloseSpecial,
				//this.chkCloseMessage,
				//this.chkCheckIN,
				//this.chkCloseCheck,
				//this.chkStartGame,
				//this.chkReady,
				//this.chkNotReady,
				//this.chkOk1,
				//this.chkOk2,
				//this.chkOkMission,
				//this.chkEndGame,
				//this.chkOutRoom,
				//this.chkGiveHead,
				//this.chkOrderF5,
				//this.chkSlasHead,
				//this.chkSlasBody,
				//this.chkBuff,
				//this.chkCornerR,
				//this.chkCornerL,
				//this.chkNotCorner,
				//this.chkMissionHit,
				//this.chkMissionAttack,
				//this.chkWigHead,
				//this.chkWigBody,
				//this.chkExpClan,
				//this.chkWaterPark,
				//this.chkTower11,
				//this.chkMetro,
				//this.chkFatalZone,
				//this.chkFalluCity,
				//this.chkMarineWave,
				//this.chkSlasHeadSpawn30,
				//this.chkSlasBodySpawn30,
				//this.chkSlasHeadSpawn50,
				//this.chkSlasBodySpawn50,
				//this.chkSlasHeadSpawn100,
				//this.chkSlasBodySpawn100
			});

			// 📐 ขนาดพื้นฐาน
			int buttonWidth = 200;
			int buttonHeight = 40;
			int marginX = 30;
			int marginY = 20;

			// ✅ ใช้ขนาดจริงของฟอร์ม เพื่อให้จัดกลางได้ทุกขนาด
			int fullRowWidth = buttonWidth * 2 + marginX;
			int centerX = (this.ClientSize.Width - fullRowWidth) / 2;

			// ✅ จุดเริ่มต้นปุ่ม (ใต้ label สถานะ)
			int topPadding = 90;
			int startY = topPadding + buttonHeight + marginY;

			// ✅ กำหนดตำแหน่ง Label สถานะ (อยู่บนสุด ตรงกลาง)
			this.lblStatus.Location = new Point(centerX, 10);
			this.lblStatus.Size = new Size(fullRowWidth, 30);
			this.lblStatus.TextAlign = ContentAlignment.MiddleCenter;
			this.lblLicenseStatus.Location = new Point(centerX, 40);
			this.lblLicenseStatus.Size = new Size(fullRowWidth, 20);
			this.lblLicenseTime.Location = new Point(centerX, 62);
			this.lblLicenseTime.Size = new Size(fullRowWidth, 18);

			// ✅ ปุ่มเริ่มการทำงาน - เต็มแถว
			this.btnToggleStart.Location = new Point(centerX, topPadding);
			this.btnToggleStart.Size = new Size(fullRowWidth, buttonHeight);

			// ✅ ปุ่มแถวที่ 1
			this.btnExp.Location = new Point(centerX, startY);
			this.btnExp.Size = new Size(buttonWidth, buttonHeight);

			this.btnKaiRun.Location = new Point(centerX + buttonWidth + marginX, startY);
			this.btnKaiRun.Size = new Size(buttonWidth, buttonHeight);

			// ✅ ปุ่มแถวที่ 2
			this.btnBuff.Location = new Point(centerX, startY + (buttonHeight + marginY) * 1);
			this.btnBuff.Size = new Size(buttonWidth, buttonHeight);

			this.btnKaiStill.Location = new Point(centerX + buttonWidth + marginX, startY + (buttonHeight + marginY) * 1);
			this.btnKaiStill.Size = new Size(buttonWidth, buttonHeight);

			// ✅ ปุ่มแถวที่ 3
			int missionRowY = startY;
			this.btnMission.Location = new Point(centerX, missionRowY);
			this.btnMission.Size = new Size(buttonWidth, buttonHeight);

			this.btnKaiMission.Location = new Point(centerX + buttonWidth + marginX, missionRowY);
			this.btnKaiMission.Size = new Size(buttonWidth, buttonHeight);

			this.missionOptionsPanel = new FlowLayoutPanel
			{
				FlowDirection = FlowDirection.TopDown,
				WrapContents = false,
				AutoSize = true,
				AutoSizeMode = AutoSizeMode.GrowAndShrink,
				Margin = new Padding(0),
				Padding = new Padding(0),
				Visible = false,
				BackColor = Color.Transparent
			};
			this.chkMissionAttack.Margin = new Padding(0, 0, 0, 4);
			this.chkMissionHit.Margin = new Padding(0);
			this.missionOptionsPanel.Controls.Add(this.chkMissionAttack);
			this.missionOptionsPanel.Controls.Add(this.chkMissionHit);
			int missionPanelHeight = this.chkMissionAttack.PreferredSize.Height + this.chkMissionHit.PreferredSize.Height + 4;
			this.missionOptionsPanel.Location = new Point(centerX, missionRowY + buttonHeight + 5);
			base.Controls.Add(this.missionOptionsPanel);
			this.UpdateMissionOptionsVisibility();

			bool missionRowVisible = this.btnMission.Visible || this.btnKaiMission.Visible || this.missionOptionsPanel.Visible;
			int missionPanelSpacing = missionRowVisible ? missionPanelHeight + 5 : 0;
			int nextRowBase = startY + (buttonHeight + marginY) * (missionRowVisible ? 3 : 2) + missionPanelSpacing;

			// ✅ ปุ่มแถวที่ 4
			this.btnExpClan.Location = new Point(centerX, nextRowBase);
			this.btnExpClan.Size = new Size(buttonWidth, buttonHeight);

			this.btnKaiClan.Location = new Point(centerX + buttonWidth + marginX, nextRowBase);
			this.btnKaiClan.Size = new Size(buttonWidth, buttonHeight);

			// ✅ ปุ่มแถวที่ 5 (ปุ่มเดียว เต็มแถว)
			this.btnReKey.Location = new Point(centerX, nextRowBase + (buttonHeight + marginY));
			this.btnReKey.Size = new Size(fullRowWidth, buttonHeight);


			// ✅ ปรับลุคปุ่มให้ทั้งหมด: พื้นหลังขาว, ตัวอักษรดำ, ขอบบาง
			Button[] allButtons =
			{
				btnToggleStart, btnExp, btnKaiRun, btnBuff, btnKaiStill,
				btnMission, btnKaiMission, btnExpClan, btnKaiClan, btnReKey
			};

			foreach (Button btn in allButtons)
			{
				btn.BackColor = Color.White;
				btn.ForeColor = Color.Black;
				btn.FlatStyle = FlatStyle.Flat;
				btn.FlatAppearance.BorderSize = 1;
				btn.Font = new Font("Segoe UI", 10, FontStyle.Regular); // ✅ ตัวหนังสือดูทันสมัย
			}



			this.LoadCheckboxStates();
			base.FormClosing += delegate(object s, FormClosingEventArgs e)
			{
				this.SaveCheckboxStates();
			};
			this.captureTimer = new System.Windows.Forms.Timer
			{
				Interval = 10
			};
			this.captureTimer.Tick += delegate(object s, EventArgs e)
			{
				if (!this.isPaused && this.chkstart.Checked)
				{
					Bitmap bitmap = this.latestScreen;
					if (bitmap != null)
					{
						bitmap.Dispose();
					}
					Bitmap bitmap2 = this.latestScreencapture;
					if (bitmap2 != null)
					{
						bitmap2.Dispose();
					}
					this.latestScreen = ImageSearchHelper.CaptureScreen();
					this.latestScreencapture = ImageSearchHelper.CapturePartialScreen(new Rectangle(380, 605, 630, 120));
				}
			};

			// ใช้ปุ่มเริ่มใหม่
			this.btnToggleStart.Click += (s, e) =>
			{
				chkstart.Checked = !chkstart.Checked;

				if (chkstart.Checked)
				{
					btnToggleStart.Text = "หยุดการทำงาน";
					lblStatus.Text = "🟢 สถานะ: เริ่มการทำงานแล้ว...";
				}
				else
				{
					btnToggleStart.Text = "เริ่มการทำงาน";
					lblStatus.Text = "🟡 สถานะ: รอ";
				}
			};

			this.searchTimer = new System.Windows.Forms.Timer
			{
				Interval = 1000
			};
			this.searchTimer.Tick += delegate(object s, EventArgs e)
			{
				if (this.isPaused || this.latestScreen == null)
				{
					return;
				}
				string tasks = "";
				if (this.chkstart.Checked)
				{
					tasks += "เริ่มการทำงาน, ";
				}
				if (this.chkClosePass.Checked && !this.isClosingPass)
				{
					tasks += "ปิดพาส, ";
					using (Bitmap target = new Bitmap(Path.Combine(Path.Combine(Environment.GetEnvironmentVariable("TEMP") ?? "C:\\Temp", "png"), "Pass.png")))
					{
						Point foundAt;
						if (ImageSearchHelper.FindImageWithDll(this.latestScreen, target, 20, out foundAt))
						{
							this.isClosingPass = true;
							Task.Run(delegate()
							{
								try
								{
									AutoItX.AU3_Send("{esc down}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{esc up}", 0);
								}
								catch (OperationCanceledException)
								{
								}
								catch (Exception ex)
								{
									Console.WriteLine("Error (Ok_time): " + ex.Message);
								}
								finally
								{
									AutoItX.AU3_Sleep(2000);
									this.isClosingPass = false;
								}
							}, this.cancellationSource.Token);
						}
					}
				}
				if (this.chkCloseSpecial.Checked && !this.isClosingPass)
				{
					tasks += "ปิดราคาพิเศษ, ";
					using (Bitmap target2 = new Bitmap(Path.Combine(Path.Combine(Environment.GetEnvironmentVariable("TEMP") ?? "C:\\Temp", "png"), "Special.png")))
					{
						Point foundAt2;
						if (ImageSearchHelper.FindImageWithDll(this.latestScreen, target2, 20, out foundAt2))
						{
							this.isClosingPass = true;
							Task.Run(delegate()
							{
								CancellationToken token = this.cancellationSource.Token;
								try
								{
									AutoItX.AU3_Send("{esc down}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{esc up}", 0);
								}
								catch (OperationCanceledException)
								{
								}
								catch (Exception ex)
								{
									Console.WriteLine("Error (Ok_time): " + ex.Message);
								}
								finally
								{
									AutoItX.AU3_Sleep(2000);
									this.isClosingPass = false;
								}
							}, this.cancellationSource.Token);
						}
					}
				}
				if (this.chkCloseMessage.Checked && !this.isClosingPass)
				{
					tasks += "ปิดEvent, ";
					using (Bitmap target3 = new Bitmap(Path.Combine(Path.Combine(Environment.GetEnvironmentVariable("TEMP") ?? "C:\\Temp", "png"), "Message.png")))
					{
						Point foundAt3;
						if (ImageSearchHelper.FindImageWithDll(this.latestScreen, target3, 20, out foundAt3))
						{
							this.isClosingPass = true;
							Task.Run(delegate()
							{
								CancellationToken token = this.cancellationSource.Token;
								try
								{
									AutoItX.AU3_Send("{esc down}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{esc up}", 0);
									AutoItX.AU3_Sleep(1000);
								}
								catch (OperationCanceledException)
								{
								}
								catch (Exception ex)
								{
									Console.WriteLine("Error (Ok_time): " + ex.Message);
								}
								finally
								{
									AutoItX.AU3_Sleep(1000);
									this.isClosingPass = false;
								}
							}, this.cancellationSource.Token);
						}
					}
				}
				if (this.chkCheckIN.Checked && !this.isClosingPass)
				{
					tasks += "เช็คอิน, ";
					using (Bitmap target4 = new Bitmap(Path.Combine(Path.Combine(Environment.GetEnvironmentVariable("TEMP") ?? "C:\\Temp", "png"), "CheckIN.png")))
					{
						Point foundAt4;
						if (ImageSearchHelper.FindImageWithDll(this.latestScreen, target4, 0, out foundAt4))
						{
							this.isClosingPass = true;
							Task.Run(delegate()
							{
								CancellationToken token = this.cancellationSource.Token;
								try
								{
									AutoItX.AU3_MouseClick("left", 515, 705, 1, 0);
									AutoItX.AU3_Sleep(500);
									AutoItX.AU3_MouseMove(10, 10, 10);
								}
								catch (OperationCanceledException)
								{
								}
								catch (Exception ex)
								{
									Console.WriteLine("Error (Ok_time): " + ex.Message);
								}
								finally
								{
									AutoItX.AU3_Sleep(2000);
									this.isClosingPass = false;
								}
							}, this.cancellationSource.Token);
						}
					}
				}
				if (this.chkCloseCheck.Checked && !this.isClosingPass)
				{
					tasks += "ปิดเช็คอิน, ";
					using (Bitmap target5 = new Bitmap(Path.Combine(Path.Combine(Environment.GetEnvironmentVariable("TEMP") ?? "C:\\Temp", "png"), "CloseCheckIN.png")))
					{
						Point foundAt5;
						if (ImageSearchHelper.FindImageWithDll(this.latestScreen, target5, 0, out foundAt5))
						{
							this.isClosingPass = true;
							Task.Run(delegate()
							{
								CancellationToken token = this.cancellationSource.Token;
								try
								{
									AutoItX.AU3_Send("{esc down}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{esc up}", 0);
								}
								catch (OperationCanceledException)
								{
								}
								catch (Exception ex)
								{
									Console.WriteLine("Error (Ok_time): " + ex.Message);
								}
								finally
								{
									AutoItX.AU3_Sleep(2000);
									this.isClosingPass = false;
								}
							}, this.cancellationSource.Token);
						}
					}
				}
				if (this.chkStartGame.Checked)
				{
					tasks += "เริ่มเกม, ";
					using (Bitmap target6 = new Bitmap(Path.Combine(Path.Combine(Environment.GetEnvironmentVariable("TEMP") ?? "C:\\Temp", "png"), "Play.png")))
					{
						Point foundAt6;
						if (ImageSearchHelper.FindImageWithDll(this.latestScreen, target6, 20, out foundAt6))
						{
							Task.Run(delegate()
							{
								CancellationToken token = this.cancellationSource.Token;
								try
								{
									AutoItX.AU3_Send("{F5 down}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{F5 up}", 0);
									AutoItX.AU3_Send("{Enter down}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{Enter up}", 0);
									AutoItX.AU3_Send("{Enter down}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{Enter up}", 0);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{A up}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{S up}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{D up}", 0);
								}
								catch (OperationCanceledException)
								{
								}
								catch (Exception ex)
								{
									Console.WriteLine("Error (Ok_time): " + ex.Message);
								}
							}, this.cancellationSource.Token);
						}
					}
				}
				if (this.chkReady.Checked)
				{
					tasks += "กดพร้อม, ";
					using (Bitmap target7 = new Bitmap(Path.Combine(Path.Combine(Environment.GetEnvironmentVariable("TEMP") ?? "C:\\Temp", "png"), "Ready.png")))
					{
						Point foundAt7;
						if (ImageSearchHelper.FindImageWithDll(this.latestScreen, target7, 20, out foundAt7))
						{
							Task.Run(delegate()
							{
								CancellationToken token = this.cancellationSource.Token;
								try
								{
									AutoItX.AU3_Send("{F5 down}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{F5 up}", 0);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{A up}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{S up}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{D up}", 0);
								}
								catch (OperationCanceledException)
								{
								}
								catch (Exception ex)
								{
									Console.WriteLine("Error (Ok_time): " + ex.Message);
								}
							}, this.cancellationSource.Token);
						}
					}
				}
				if (this.chkNotReady.Checked)
				{
					tasks += "กดยกเลิก, ";
					using (Bitmap target8 = new Bitmap(Path.Combine(Path.Combine(Environment.GetEnvironmentVariable("TEMP") ?? "C:\\Temp", "png"), "NotReady.png")))
					{
						Point foundAt8;
						if (ImageSearchHelper.FindImageWithDll(this.latestScreen, target8, 20, out foundAt8))
						{
							Task.Run(delegate()
							{
								CancellationToken token = this.cancellationSource.Token;
								try
								{
									AutoItX.AU3_Sleep(6000);
									AutoItX.AU3_Send("{F5 down}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{F5 up}", 0);
								}
								catch (OperationCanceledException)
								{
								}
								catch (Exception ex)
								{
									Console.WriteLine("Error (Ok_time): " + ex.Message);
								}
							}, this.cancellationSource.Token);
						}
					}
				}
				if (this.chkOk1.Checked)
				{
					tasks += "ยืนยันใหญ่, ";
					string path = Path.Combine(Environment.GetEnvironmentVariable("TEMP") ?? "C:\\Temp", "png");
					string targetPath = Path.Combine(path, "Ok1.png");
					string targetPath2 = Path.Combine(path, "Ok3.png");
					using (Bitmap target9 = new Bitmap(targetPath))
					{
						using (Bitmap target10 = new Bitmap(targetPath2))
						{
							Point foundAt9;
							Point foundAt10;
							if (ImageSearchHelper.FindImageWithDll(this.latestScreen, target9, 20, out foundAt9) || ImageSearchHelper.FindImageWithDll(this.latestScreen, target10, 20, out foundAt10))
							{
								Task.Run(delegate()
								{
									CancellationToken token = this.cancellationSource.Token;
									try
									{
										if (Announce.exit())
										{
											AutoItX.AU3_Send("{Enter down}", 0);
											AutoItX.AU3_Sleep(100);
											AutoItX.AU3_Send("{Enter up}", 0);
										}
										if (Participate.exit())
										{
											AutoItX.AU3_Send("{Enter down}", 0);
											AutoItX.AU3_Sleep(100);
											AutoItX.AU3_Send("{Enter up}", 0);
										}
										if (PlayTime.exit())
										{
											AutoItX.AU3_Send("{esc down}", 0);
											AutoItX.AU3_Sleep(100);
											AutoItX.AU3_Send("{esc up}", 0);
										}
										if (RePair.exit())
										{
											AutoItX.AU3_Send("{Enter down}", 0);
											AutoItX.AU3_Sleep(100);
											AutoItX.AU3_Send("{Enter up}", 0);
										}
										if (Rank.exit())
										{
											AutoItX.AU3_Send("{Enter down}", 0);
											AutoItX.AU3_Sleep(100);
											AutoItX.AU3_Send("{Enter up}", 0);
										}
										if (EventPlay.exit())
										{
											AutoItX.AU3_Send("{Enter down}", 0);
											AutoItX.AU3_Sleep(100);
											AutoItX.AU3_Send("{Enter up}", 0);
										}
										if (BuyMission.exit())
										{
											AutoItX.AU3_Send("{Enter down}", 0);
											AutoItX.AU3_Sleep(100);
											AutoItX.AU3_Send("{Enter up}", 0);
										}
										else
										{
											AutoItX.AU3_Send("{Enter down}", 0);
											AutoItX.AU3_Sleep(100);
											AutoItX.AU3_Send("{Enter up}", 0);
										}
									}
									catch (OperationCanceledException)
									{
									}
									catch (Exception ex)
									{
										Console.WriteLine("Error (Ok_time): " + ex.Message);
									}
								}, this.cancellationSource.Token);
							}
						}
					}
				}
				if (this.chkOk2.Checked)
				{
					tasks += "ยืนยันเล็ก, ";
					using (Bitmap target11 = new Bitmap(Path.Combine(Path.Combine(Environment.GetEnvironmentVariable("TEMP") ?? "C:\\Temp", "png"), "Ok2.png")))
					{
						Point foundAt11;
						if (ImageSearchHelper.FindImageWithDll(this.latestScreen, target11, 20, out foundAt11))
						{
							Task.Run(delegate()
							{
								CancellationToken token = this.cancellationSource.Token;
								try
								{
									AutoItX.AU3_Send("{Enter down}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{Enter up}", 0);
								}
								catch (OperationCanceledException)
								{
								}
								catch (Exception ex)
								{
									Console.WriteLine("Error (Ok_time): " + ex.Message);
								}
							}, this.cancellationSource.Token);
						}
					}
				}
				if (this.chkOkMission.Checked)
				{
					tasks += "ยืนยันภาระกิจ, ";
					using (Bitmap target12 = new Bitmap(Path.Combine(Path.Combine(Environment.GetEnvironmentVariable("TEMP") ?? "C:\\Temp", "png"), "OkMission.png")))
					{
						Point foundAt12;
						if (ImageSearchHelper.FindImageWithDll(this.latestScreen, target12, 20, out foundAt12))
						{
							Task.Run(delegate()
							{
								CancellationToken token = this.cancellationSource.Token;
								try
								{
									AutoItX.AU3_MouseClick("left", 510, 470, 1, 0);
									AutoItX.AU3_Sleep(500);
									AutoItX.AU3_MouseClick("left", 510, 490, 1, 0);
									AutoItX.AU3_Sleep(500);
									AutoItX.AU3_MouseClick("left", 510, 505, 1, 0);
									AutoItX.AU3_Sleep(500);
									AutoItX.AU3_MouseClick("left", 510, 520, 1, 0);
									AutoItX.AU3_Sleep(500);
									AutoItX.AU3_MouseMove(10, 10, 10);
								}
								catch (OperationCanceledException)
								{
								}
								catch (Exception ex)
								{
									Console.WriteLine("Error (Ok_time): " + ex.Message);
								}
							}, this.cancellationSource.Token);
						}
					}
				}
				if (this.chkEndGame.Checked)
				{
					tasks += "ยืนยันจบเกมส์, ";
					using (Bitmap target13 = new Bitmap(Path.Combine(Path.Combine(Environment.GetEnvironmentVariable("TEMP") ?? "C:\\Temp", "png"), "EndGame.png")))
					{
						Point foundAt13;
						if (ImageSearchHelper.FindImageWithDll(this.latestScreen, target13, 20, out foundAt13))
						{
							Task.Run(delegate()
							{
								CancellationToken token = this.cancellationSource.Token;
								try
								{
									AutoItX.AU3_Send("{Enter down}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{Enter up}", 0);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{A up}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{S up}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{D up}", 0);
								}
								catch (OperationCanceledException)
								{
								}
								catch (Exception ex)
								{
									Console.WriteLine("Error (Ok_time): " + ex.Message);
								}
							}, this.cancellationSource.Token);
						}
					}
				}
				if (this.chkOutRoom.Checked && !this.isClosingPass)
				{
					tasks += "สั่งออกห้อง, ";
					using (Bitmap target14 = new Bitmap(Path.Combine(Path.Combine(Environment.GetEnvironmentVariable("TEMP") ?? "C:\\Temp", "png"), "OutRoom.png")))
					{
						Point foundAt14;
						if (ImageSearchHelper.FindImageWithDll(this.latestScreen, target14, 80, out foundAt14))
						{
							this.isClosingPass = true;
							Task.Run(delegate()
							{
								CancellationToken token = this.cancellationSource.Token;
								try
								{
									AutoItX.AU3_Send("{Esc DOWN}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{Esc UP}", 0);
									AutoItX.AU3_Sleep(500);
									AutoItX.AU3_Send("{Enter DOWN}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{Enter UP}", 0);
									AutoItX.AU3_Sleep(500);
									AutoItX.AU3_Send("{Enter DOWN}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{Enter UP}", 0);
									AutoItX.AU3_MouseMove(10, 10, 10);
								}
								catch (OperationCanceledException)
								{
								}
								catch (Exception ex)
								{
									Console.WriteLine("Error (Ok_time): " + ex.Message);
								}
								finally
								{
									AutoItX.AU3_Sleep(5000);
									this.isClosingPass = false;
								}
							}, this.cancellationSource.Token);
						}
					}
				}
				if (this.chkGiveHead.Checked)
				{
					tasks += "ให้หัวออโต้, ";
					using (Bitmap target15 = new Bitmap(Path.Combine(Path.Combine(Environment.GetEnvironmentVariable("TEMP") ?? "C:\\Temp", "png"), "GiveHead.png")))
					{
						Point foundAt15;
						if (ImageSearchHelper.FindImageWithDll(this.latestScreen, target15, 20, out foundAt15))
						{
							Task.Run(delegate()
							{
								CancellationToken token = this.cancellationSource.Token;
								try
								{
									AutoItX.AU3_MouseClick("left", 425, 685, 1, 0);
									AutoItX.AU3_Sleep(500);
									AutoItX.AU3_MouseMove(10, 10, 10);
								}
								catch (OperationCanceledException)
								{
								}
								catch (Exception ex)
								{
									Console.WriteLine("Error (Ok_time): " + ex.Message);
								}
							}, this.cancellationSource.Token);
						}
					}
				}
				if (this.chkOrderF5.Checked)
				{
					tasks += "สั่งกดพร้อม, ";
					string path2 = Path.Combine(Environment.GetEnvironmentVariable("TEMP") ?? "C:\\Temp", "png");
					string targetPath3 = Path.Combine(path2, "Ready.png");
					string targetPath4 = Path.Combine(path2, "OrderF5.png");
					using (Bitmap target16 = new Bitmap(targetPath3))
					{
						using (Bitmap target17 = new Bitmap(targetPath4))
						{
							Point foundAt16;
							Point foundAt17;
							if (ImageSearchHelper.FindImageWithDll(this.latestScreencapture, target16, 20, out foundAt16) && ImageSearchHelper.FindImageWithDll(this.latestScreencapture, target17, 20, out foundAt17))
							{
								Task.Run(delegate()
								{
									CancellationToken token = this.cancellationSource.Token;
									try
									{
										AutoItX.AU3_Send("{F5 DOWN}", 0);
										AutoItX.AU3_Sleep(100);
										AutoItX.AU3_Send("{F5 UP}", 0);
									}
									catch (OperationCanceledException)
									{
									}
									catch (Exception ex)
									{
										Console.WriteLine("Error (Ok_time): " + ex.Message);
									}
								}, this.cancellationSource.Token);
							}
						}
					}
				}
				if (this.chkSlasHead.Checked)
				{
					tasks += "เดินฟันหัวBH, ";
					string path3 = Path.Combine(Environment.GetEnvironmentVariable("TEMP") ?? "C:\\Temp", "png");
					string targetPath5 = Path.Combine(path3, "RUN160Red.png");
					string targetPath6 = Path.Combine(path3, "RUNRED000.png");
					using (Bitmap target18 = new Bitmap(targetPath5))
					{
						using (Bitmap target19 = new Bitmap(targetPath6))
						{
							Point foundAt18;
							Point foundAt19;
							if (ImageSearchHelper.FindImageWithDll(this.latestScreen, target18, 20, out foundAt18) && ImageSearchHelper.FindImageWithDll(this.latestScreen, target19, 20, out foundAt19))
							{
								if (!this.runActionSlasHead)
								{
									this.runActionSlasHead = true;
									AutoItX.AU3_MouseUp("left");
									AutoItX.AU3_Send("{CTRLUP}", 0);
									AutoItX.AU3_Send("{ALTUP}", 0);
									AutoItX.AU3_Sleep(1500);
									AutoItX.AU3_Send("{4 down}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{4 up}", 0);
									AutoItX.AU3_Send("{A down}", 0);
									AutoItX.AU3_Sleep(1500);
									AutoItX.AU3_Send("{A up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Send("{A down}", 0);
									AutoItX.AU3_Sleep(1500);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{A up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Send("{D down}", 0);
									AutoItX.AU3_Sleep(1500);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{D up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Sleep(1200);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Send("{D down}", 0);
									AutoItX.AU3_Sleep(850);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{D up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Sleep(2500);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{A down}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{A up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Sleep(2700);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Send("{A down}", 0);
									AutoItX.AU3_Sleep(1000);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{A up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Sleep(1300);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{A down}", 0);
									AutoItX.AU3_Sleep(400);
									AutoItX.AU3_Send("{A up}", 0);
									AutoItX.AU3_Send("{S down}", 0);
									AutoItX.AU3_Sleep(800);
									AutoItX.AU3_Send("{S up}", 0);
									AutoItX.AU3_Send("{4 down}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{4 up}", 0);
									AutoItX.AU3_Send("{CTRLDOWN}", 0);
									AutoItX.AU3_Sleep(150);
									AutoItX.AU3_MouseDown("left");
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_MouseUp("left");
									AutoItX.AU3_Send("{CTRLUP}", 0);
									AutoItX.AU3_Sleep(4000);
									if (Checkkill0Red.exit())
									{
										Console.WriteLine("stop kill action");
										AutoItX.AU3_Send("{Esc DOWN}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{Esc UP}", 0);
										AutoItX.AU3_Send("{Enter DOWN}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{Enter UP}", 0);
										AutoItX.AU3_Send("{Enter DOWN}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{Enter UP}", 0);
										AutoItX.AU3_MouseMove(10, 10, 10);
									}
									else
									{
										Console.WriteLine("start kill action");
										AutoItX.AU3_Send("{3 down}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{3 up}", 0);
										AutoItX.AU3_Send("{W down}", 0);
										AutoItX.AU3_Sleep(1000);
										AutoItX.AU3_Send("{A down}", 0);
										AutoItX.AU3_Sleep(1500);
										AutoItX.AU3_Send("{W up}", 0);
										AutoItX.AU3_Send("{A up}", 0);
										AutoItX.AU3_Send("{S down}", 0);
										AutoItX.AU3_Send("{A down}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{S up}", 0);
										AutoItX.AU3_Send("{A up}", 0);
										MouseWinApi.MoveRelative(0, -200);
										for (int i = 0; i < 92; i++)
										{
											AutoItX.AU3_MouseDown("left");
											AutoItX.AU3_Sleep(2000);
											MouseWinApi.MoveRelative(1800, 100);
											AutoItX.AU3_MouseDown("left");
											AutoItX.AU3_Sleep(1000);
											MouseWinApi.MoveRelative(-1800, -100);
										}
										AutoItX.AU3_Sleep(2000);
										AutoItX.AU3_MouseUp("left");
										AutoItX.AU3_MouseMove(10, 10, 10);
									}
								}
								else
								{
									this.runActionSlasHead = false;
								}
							}
						}
					}
				}
				if (this.chkSlasBody.Checked)
				{
					tasks += "เดินฟันตัวBH, ";
					string path4 = Path.Combine(Environment.GetEnvironmentVariable("TEMP") ?? "C:\\Temp", "png");
					string targetPath7 = Path.Combine(path4, "RUN160Red.png");
					string targetPath8 = Path.Combine(path4, "RUNRED000.png");
					using (Bitmap target20 = new Bitmap(targetPath7))
					{
						using (Bitmap target21 = new Bitmap(targetPath8))
						{
							Point foundAt20;
							Point foundAt21;
							if (ImageSearchHelper.FindImageWithDll(this.latestScreen, target20, 20, out foundAt20) && ImageSearchHelper.FindImageWithDll(this.latestScreen, target21, 20, out foundAt21))
							{
								if (!this.runActionSlasBoy)
								{
									this.runActionSlasBoy = true;
									AutoItX.AU3_MouseUp("left");
									AutoItX.AU3_Send("{CTRLUP}", 0);
									AutoItX.AU3_Send("{ALTUP}", 0);
									AutoItX.AU3_Sleep(1500);
									AutoItX.AU3_Send("{4 down}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{4 up}", 0);
									AutoItX.AU3_Send("{A down}", 0);
									AutoItX.AU3_Sleep(1500);
									AutoItX.AU3_Send("{A up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Send("{A down}", 0);
									AutoItX.AU3_Sleep(1500);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{A up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Send("{D down}", 0);
									AutoItX.AU3_Sleep(1500);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{D up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Sleep(1200);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Send("{D down}", 0);
									AutoItX.AU3_Sleep(850);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{D up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Sleep(2500);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{A down}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{A up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Sleep(2700);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Send("{A down}", 0);
									AutoItX.AU3_Sleep(1000);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{A up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Sleep(1300);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{A down}", 0);
									AutoItX.AU3_Sleep(400);
									AutoItX.AU3_Send("{A up}", 0);
									AutoItX.AU3_Send("{S down}", 0);
									AutoItX.AU3_Sleep(800);
									AutoItX.AU3_Send("{S up}", 0);
									AutoItX.AU3_Send("{4 down}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{4 up}", 0);
									AutoItX.AU3_Send("{CTRLDOWN}", 0);
									AutoItX.AU3_Sleep(150);
									AutoItX.AU3_MouseDown("left");
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_MouseUp("left");
									AutoItX.AU3_Send("{CTRLUP}", 0);
									AutoItX.AU3_Sleep(4000);
									if (Checkkill0Red.exit())
									{
										Console.WriteLine("stop kill action");
										AutoItX.AU3_Send("{Esc DOWN}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{Esc UP}", 0);
										AutoItX.AU3_Send("{Enter DOWN}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{Enter UP}", 0);
										AutoItX.AU3_Send("{Enter DOWN}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{Enter UP}", 0);
										AutoItX.AU3_MouseMove(10, 10, 10);
									}
									else
									{
										Console.WriteLine("start kill action");
										AutoItX.AU3_Send("{3 down}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{3 up}", 0);
										AutoItX.AU3_Send("{W down}", 0);
										AutoItX.AU3_Sleep(1000);
										AutoItX.AU3_Send("{A down}", 0);
										AutoItX.AU3_Sleep(1500);
										AutoItX.AU3_Send("{W up}", 0);
										AutoItX.AU3_Send("{A up}", 0);
										AutoItX.AU3_Send("{S down}", 0);
										AutoItX.AU3_Send("{A down}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{S up}", 0);
										AutoItX.AU3_Send("{A up}", 0);
										MouseWinApi.MoveRelative(0, 600);
										for (int j = 0; j < 92; j++)
										{
											AutoItX.AU3_MouseDown("left");
											AutoItX.AU3_Sleep(2000);
											MouseWinApi.MoveRelative(1800, -100);
											AutoItX.AU3_MouseDown("left");
											AutoItX.AU3_Sleep(1000);
											MouseWinApi.MoveRelative(-1800, 100);
										}
										AutoItX.AU3_Sleep(2000);
										AutoItX.AU3_MouseUp("left");
										AutoItX.AU3_MouseMove(10, 10, 10);
									}
								}
								else
								{
									this.runActionSlasBoy = false;
								}
							}
						}
					}
				}
				if (this.chkBuff.Checked)
				{
					tasks += "ปั้มบัพแคลนCTY, ";
					using (Bitmap target22 = new Bitmap(Path.Combine(Path.Combine(Environment.GetEnvironmentVariable("TEMP") ?? "C:\\Temp", "png"), "Win0Red.png")))
					{
						Point foundAt22;
						if (ImageSearchHelper.FindImageWithDll(this.latestScreen, target22, 20, out foundAt22))
						{
							if (CheckWin0.exit())
							{
								AutoItX.AU3_MouseUp("left");
								AutoItX.AU3_Send("{CTRLUP}", 0);
								AutoItX.AU3_Send("{ALTUP}", 0);
								AutoItX.AU3_Sleep(1000);
								AutoItX.AU3_Send("{4 down}", 0);
								AutoItX.AU3_Sleep(300);
								AutoItX.AU3_Send("{4 up}", 0);
								AutoItX.AU3_Send("{F down}", 0);
								AutoItX.AU3_Sleep(300);
								AutoItX.AU3_Send("{F up}", 0);
								AutoItX.AU3_Sleep(1500);
								AutoItX.AU3_MouseDown("left");
								AutoItX.AU3_Sleep(150);
								AutoItX.AU3_MouseUp("left");
								AutoItX.AU3_Sleep(13000);
								if (CheckWin0.exit())
								{
									AutoItX.AU3_MouseUp("left");
									AutoItX.AU3_Send("{CTRLUP}", 0);
									AutoItX.AU3_Send("{ALTUP}", 0);
									AutoItX.AU3_Send("{Esc DOWN}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{Esc UP}", 0);
									AutoItX.AU3_Send("{Enter DOWN}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{Enter UP}", 0);
									AutoItX.AU3_Send("{Enter DOWN}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{Enter UP}", 0);
								}
							}
							if (CheckWin1.exit())
							{
								AutoItX.AU3_MouseUp("left");
								AutoItX.AU3_Send("{CTRLUP}", 0);
								AutoItX.AU3_Send("{ALTUP}", 0);
								AutoItX.AU3_Sleep(1000);
								AutoItX.AU3_Send("{4 down}", 0);
								AutoItX.AU3_Sleep(300);
								AutoItX.AU3_Send("{4 up}", 0);
								AutoItX.AU3_Send("{F down}", 0);
								AutoItX.AU3_Sleep(300);
								AutoItX.AU3_Send("{F up}", 0);
								AutoItX.AU3_Sleep(1500);
								AutoItX.AU3_MouseDown("left");
								AutoItX.AU3_Sleep(150);
								AutoItX.AU3_MouseUp("left");
								AutoItX.AU3_Sleep(13000);
								if (CheckWin1.exit())
								{
									AutoItX.AU3_MouseUp("left");
									AutoItX.AU3_Send("{CTRLUP}", 0);
									AutoItX.AU3_Send("{ALTUP}", 0);
									AutoItX.AU3_Send("{Esc DOWN}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{Esc UP}", 0);
									AutoItX.AU3_Send("{Enter DOWN}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{Enter UP}", 0);
									AutoItX.AU3_Send("{Enter DOWN}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{Enter UP}", 0);
								}
							}
							if (CheckWin2.exit())
							{
								AutoItX.AU3_MouseUp("left");
								AutoItX.AU3_Send("{CTRLUP}", 0);
								AutoItX.AU3_Send("{ALTUP}", 0);
								AutoItX.AU3_Sleep(497);
								AutoItX.AU3_Send("{5 down}", 0);
								AutoItX.AU3_Sleep(144);
								AutoItX.AU3_Send("{5 up}", 0);
								AutoItX.AU3_Sleep(33);
								AutoItX.AU3_MouseDown("left");
								AutoItX.AU3_Sleep(319);
								AutoItX.AU3_Send("{A down}", 0);
								AutoItX.AU3_Sleep(104);
								AutoItX.AU3_Send("{S down}", 0);
								AutoItX.AU3_Sleep(82);
								AutoItX.AU3_MouseUp("left");
								AutoItX.AU3_Sleep(102);
								AutoItX.AU3_Send("{SPACEDOWN}", 0);
								AutoItX.AU3_Sleep(168);
								AutoItX.AU3_Send("{SPACEUP}", 0);
								AutoItX.AU3_Sleep(1344);
								AutoItX.AU3_Send("{4 down}", 0);
								AutoItX.AU3_Sleep(152);
								AutoItX.AU3_Send("{S up}", 0);
								AutoItX.AU3_Sleep(24);
								AutoItX.AU3_Send("{4 up}", 0);
								AutoItX.AU3_Sleep(144);
								AutoItX.AU3_Send("{W down}", 0);
								AutoItX.AU3_Sleep(71);
								AutoItX.AU3_Send("{A up}", 0);
								AutoItX.AU3_Sleep(177);
								AutoItX.AU3_Send("{D down}", 0);
								AutoItX.AU3_Sleep(96);
								AutoItX.AU3_Send("{W up}", 0);
								AutoItX.AU3_Sleep(471);
								AutoItX.AU3_Send("{W down}", 0);
								AutoItX.AU3_Sleep(24);
								AutoItX.AU3_Send("{D up}", 0);
								AutoItX.AU3_Sleep(320);
								AutoItX.AU3_Send("{D down}", 0);
								AutoItX.AU3_Sleep(137);
								AutoItX.AU3_Send("{D up}", 0);
								AutoItX.AU3_Sleep(999);
								AutoItX.AU3_Send("{A down}", 0);
								AutoItX.AU3_Sleep(664);
								AutoItX.AU3_Send("{W up}", 0);
								AutoItX.AU3_Sleep(35);
								AutoItX.AU3_Send("{A down}", 0);
								AutoItX.AU3_Sleep(53);
								AutoItX.AU3_Send("{W down}", 0);
								AutoItX.AU3_Sleep(671);
								AutoItX.AU3_Send("{W down}", 0);
								AutoItX.AU3_Send("{W up}", 0);
								AutoItX.AU3_Sleep(1097);
								AutoItX.AU3_Send("{W down}", 0);
								AutoItX.AU3_Sleep(80);
								AutoItX.AU3_Send("{A up}", 0);
								AutoItX.AU3_Sleep(500);
								AutoItX.AU3_Send("{W down}", 0);
								AutoItX.AU3_Sleep(300);
								AutoItX.AU3_Send("{D down}", 0);
								AutoItX.AU3_Sleep(176);
								AutoItX.AU3_Send("{D up}", 0);
								AutoItX.AU3_Sleep(1263);
								AutoItX.AU3_Send("{D down}", 0);
								AutoItX.AU3_Sleep(224);
								AutoItX.AU3_Send("{D up}", 0);
								AutoItX.AU3_Sleep(873);
								AutoItX.AU3_Send("{A down}", 0);
								AutoItX.AU3_Sleep(352);
								AutoItX.AU3_Send("{A up}", 0);
								AutoItX.AU3_Sleep(576);
								AutoItX.AU3_Send("{D down}", 0);
								AutoItX.AU3_Sleep(167);
								AutoItX.AU3_Send("{D up}", 0);
								AutoItX.AU3_Sleep(1840);
								AutoItX.AU3_Send("{D down}", 0);
								AutoItX.AU3_Sleep(192);
								AutoItX.AU3_Send("{W up}", 0);
								AutoItX.AU3_Sleep(312);
								AutoItX.AU3_Send("{W down}", 0);
								AutoItX.AU3_Sleep(568);
								AutoItX.AU3_Send("{D up}", 0);
								AutoItX.AU3_Sleep(33);
								AutoItX.AU3_Send("{W down}", 0);
								AutoItX.AU3_Sleep(808);
								AutoItX.AU3_Send("{A down}", 0);
								AutoItX.AU3_Sleep(241);
								AutoItX.AU3_Send("{W up}", 0);
								AutoItX.AU3_Sleep(500);
								AutoItX.AU3_Send("{A down}", 0);
								AutoItX.AU3_Sleep(28);
								AutoItX.AU3_Send("{W down}", 0);
								AutoItX.AU3_Sleep(175);
								AutoItX.AU3_Send("{A up}", 0);
								AutoItX.AU3_Sleep(353);
								AutoItX.AU3_Send("{1 down}", 0);
								AutoItX.AU3_Sleep(167);
								AutoItX.AU3_Send("{1 up}", 0);
								AutoItX.AU3_Sleep(329);
								AutoItX.AU3_Send("{A down}", 0);
								AutoItX.AU3_Sleep(120);
								AutoItX.AU3_Send("{A up}", 0);
								AutoItX.AU3_Sleep(17);
								AutoItX.AU3_MouseDown("left");
								AutoItX.AU3_Sleep(75);
								AutoItX.AU3_MouseUp("left");
								AutoItX.AU3_Sleep(388);
								AutoItX.AU3_MouseDown("left");
								AutoItX.AU3_Sleep(80);
								AutoItX.AU3_MouseUp("left");
								AutoItX.AU3_Sleep(56);
								AutoItX.AU3_Send("{A down}", 0);
								AutoItX.AU3_Sleep(55);
								AutoItX.AU3_MouseDown("left");
								AutoItX.AU3_Sleep(103);
								AutoItX.AU3_MouseUp("left");
								AutoItX.AU3_Sleep(73);
								AutoItX.AU3_Send("{W up}", 0);
								AutoItX.AU3_Sleep(13);
								AutoItX.AU3_MouseDown("left");
								AutoItX.AU3_Sleep(76);
								AutoItX.AU3_MouseUp("left");
								AutoItX.AU3_Sleep(177);
								AutoItX.AU3_MouseDown("left");
								AutoItX.AU3_Sleep(101);
								AutoItX.AU3_MouseUp("left");
								AutoItX.AU3_Sleep(134);
								AutoItX.AU3_Send("{A down}", 0);
								AutoItX.AU3_Sleep(23);
								AutoItX.AU3_MouseDown("left");
								AutoItX.AU3_Sleep(12);
								AutoItX.AU3_Send("{A down}", 0);
								AutoItX.AU3_Sleep(87);
								AutoItX.AU3_MouseUp("left");
								AutoItX.AU3_Sleep(14);
								AutoItX.AU3_Send("{A down}", 0);
								AutoItX.AU3_Sleep(117);
								AutoItX.AU3_MouseDown("left");
								AutoItX.AU3_Sleep(19);
								AutoItX.AU3_Send("{A down}", 0);
								AutoItX.AU3_Sleep(49);
								AutoItX.AU3_MouseUp("left");
								AutoItX.AU3_Sleep(20);
								AutoItX.AU3_Send("{A down}", 0);
								AutoItX.AU3_Sleep(22);
								AutoItX.AU3_Send("{A up}", 0);
								AutoItX.AU3_Sleep(333);
								AutoItX.AU3_MouseDown("left");
								AutoItX.AU3_Sleep(86);
								AutoItX.AU3_MouseUp("left");
								AutoItX.AU3_Sleep(37);
								AutoItX.AU3_Send("{D down}", 0);
								AutoItX.AU3_Sleep(122);
								AutoItX.AU3_MouseDown("left");
								AutoItX.AU3_Sleep(98);
								AutoItX.AU3_MouseUp("left");
								AutoItX.AU3_Sleep(231);
								AutoItX.AU3_MouseDown("left");
								AutoItX.AU3_Sleep(50);
								AutoItX.AU3_Send("{D down}", 0);
								AutoItX.AU3_Sleep(22);
								AutoItX.AU3_MouseUp("left");
								AutoItX.AU3_Sleep(12);
								AutoItX.AU3_Send("{D down}", 0);
								AutoItX.AU3_Sleep(72);
								AutoItX.AU3_MouseDown("left");
								AutoItX.AU3_Sleep(31);
								AutoItX.AU3_Send("{D down}", 0);
								AutoItX.AU3_Sleep(41);
								AutoItX.AU3_MouseUp("left");
								AutoItX.AU3_Sleep(26);
								AutoItX.AU3_Send("{D down}", 0);
								AutoItX.AU3_Sleep(62);
								AutoItX.AU3_MouseDown("left");
								AutoItX.AU3_Sleep(5);
								AutoItX.AU3_Send("{D down}", 0);
								AutoItX.AU3_Sleep(52);
								AutoItX.AU3_MouseUp("left");
								AutoItX.AU3_Sleep(16);
								AutoItX.AU3_Send("{D down}", 0);
								AutoItX.AU3_Sleep(128);
								AutoItX.AU3_Send("{D up}", 0);
								AutoItX.AU3_Sleep(103);
								AutoItX.AU3_MouseDown("left");
								AutoItX.AU3_Sleep(25);
								AutoItX.AU3_Send("{4 down}", 0);
								AutoItX.AU3_Sleep(152);
								AutoItX.AU3_Send("{4 up}", 0);
								AutoItX.AU3_Sleep(176);
								AutoItX.AU3_Send("{A down}", 0);
								AutoItX.AU3_Sleep(100);
								AutoItX.AU3_Send("{W down}", 0);
								AutoItX.AU3_Sleep(700);
								AutoItX.AU3_Send("{A up}", 0);
								AutoItX.AU3_Send("{W up}", 0);
								AutoItX.AU3_Sleep(40);
								AutoItX.AU3_Send("{CTRLDOWN}", 0);
								MouseWinApi.MoveRelative(0, 2200);
								AutoItX.AU3_Sleep(300);
								AutoItX.AU3_MouseUp("left");
								AutoItX.AU3_Send("{CTRLUP}", 0);
								AutoItX.AU3_Sleep(5000);
								if (CheckWin3.exit())
								{
									AutoItX.AU3_MouseUp("left");
									AutoItX.AU3_Send("{CTRLUP}", 0);
									AutoItX.AU3_Send("{ALTUP}", 0);
									AutoItX.AU3_Send("{Esc DOWN}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{Esc UP}", 0);
									AutoItX.AU3_Send("{Enter DOWN}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{Enter UP}", 0);
									AutoItX.AU3_Send("{Enter DOWN}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{Enter UP}", 0);
								}
							}
						}
					}
				}
				if (this.chkCornerR.Checked)
				{
					tasks += "สั่งชิดมุมขวา, ";
					string path5 = Path.Combine(Environment.GetEnvironmentVariable("TEMP") ?? "C:\\Temp", "png");
					string targetPath9 = Path.Combine(path5, "RUN160Red.png");
					string targetPath10 = Path.Combine(path5, "Round.png");
					using (Bitmap target23 = new Bitmap(targetPath9))
					{
						using (Bitmap target24 = new Bitmap(targetPath10))
						{
							Point foundAt23;
							Point foundAt24;
							if (ImageSearchHelper.FindImageWithDll(this.latestScreen, target23, 20, out foundAt23) || ImageSearchHelper.FindImageWithDll(this.latestScreen, target24, 20, out foundAt24))
							{
								Task.Run(delegate()
								{
									CancellationToken token = this.cancellationSource.Token;
									try
									{
										AutoItX.AU3_MouseUp("left");
										AutoItX.AU3_Sleep(100);
										AutoItX.AU3_Send("{CTRLUP}", 0);
										AutoItX.AU3_Sleep(100);
										AutoItX.AU3_Send("{ALTUP}", 0);
										AutoItX.AU3_Sleep(1000);
										AutoItX.AU3_Send("{S down}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{D down}", 0);
										AutoItX.AU3_Sleep(200);
									}
									catch (OperationCanceledException)
									{
									}
									catch (Exception ex)
									{
										Console.WriteLine("Error (Ok_time): " + ex.Message);
									}
								}, this.cancellationSource.Token);
							}
						}
					}
				}
				if (this.chkCornerL.Checked)
				{
					tasks += "สั่งชิดมุมซ้าย, ";
					string path6 = Path.Combine(Environment.GetEnvironmentVariable("TEMP") ?? "C:\\Temp", "png");
					string targetPath11 = Path.Combine(path6, "RUN160Red.png");
					string targetPath12 = Path.Combine(path6, "Round.png");
					using (Bitmap target25 = new Bitmap(targetPath11))
					{
						using (Bitmap target26 = new Bitmap(targetPath12))
						{
							Point foundAt25;
							Point foundAt26;
							if (ImageSearchHelper.FindImageWithDll(this.latestScreen, target25, 20, out foundAt25) || ImageSearchHelper.FindImageWithDll(this.latestScreen, target26, 20, out foundAt26))
							{
								Task.Run(delegate()
								{
									CancellationToken token = this.cancellationSource.Token;
									try
									{
										AutoItX.AU3_MouseUp("left");
										AutoItX.AU3_Sleep(100);
										AutoItX.AU3_Send("{CTRLUP}", 0);
										AutoItX.AU3_Sleep(100);
										AutoItX.AU3_Send("{ALTUP}", 0);
										AutoItX.AU3_Sleep(1000);
										AutoItX.AU3_Send("{S down}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{A down}", 0);
										AutoItX.AU3_Sleep(200);
									}
									catch (OperationCanceledException)
									{
									}
									catch (Exception ex)
									{
										Console.WriteLine("Error (Ok_time): " + ex.Message);
									}
								}, this.cancellationSource.Token);
							}
						}
					}
				}
				if (this.chkNotCorner.Checked)
				{
					tasks += "สั่งยืนนิ่ง, ";
					using (Bitmap target27 = new Bitmap(Path.Combine(Path.Combine(Environment.GetEnvironmentVariable("TEMP") ?? "C:\\Temp", "png"), "NotRUN.png")))
					{
						Point foundAt27;
						if (ImageSearchHelper.FindImageWithDll(this.latestScreen, target27, 20, out foundAt27))
						{
							Task.Run(delegate()
							{
								CancellationToken token = this.cancellationSource.Token;
								try
								{
									AutoItX.AU3_MouseUp("left");
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{CTRLUP}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{ALTUP}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{A up}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{S up}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{D up}", 0);
								}
								catch (OperationCanceledException)
								{
								}
								catch (Exception ex)
								{
									Console.WriteLine("Error (Ok_time): " + ex.Message);
								}
							}, this.cancellationSource.Token);
						}
					}
				}
				if (this.chkMissionHit.Checked)
				{
					tasks += "ภารกิจตีฝ่า, ";
					string path7 = Path.Combine(Environment.GetEnvironmentVariable("TEMP") ?? "C:\\Temp", "png");
					string filename13 = Path.Combine(path7, "Blinking.png");
					string filename14 = Path.Combine(path7, "NotBlinking.png");
					using (Bitmap bitmap28 = new Bitmap(filename13))
					{
						using (Bitmap bitmap29 = new Bitmap(filename14))
						{
							Point point28;
							Point point29;
							if (ImageSearchHelper.FindImageWithDll(this.latestScreen, bitmap28, 20, out point28) || ImageSearchHelper.FindImageWithDll(this.latestScreen, bitmap29, 20, out point29))
							{
								if (CheckMis.exit())
								{
									AutoItX.AU3_MouseClick("left", 775, 750, 1, 0);
									AutoItX.AU3_Sleep(1000);
									AutoItX.AU3_MouseClick("left", 10, 10, 1, 0);
									AutoItX.AU3_Sleep(1500);
									AutoItX.AU3_Send("{Enter down}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{Enter up}", 0);
									AutoItX.AU3_Sleep(500);
								}
								if (CheckMission.exit())
								{
									AutoItX.AU3_MouseClick("left", 550, 80, 1, 0);
									AutoItX.AU3_Sleep(500);
									AutoItX.AU3_MouseClick("left", 610, 130, 1, 0);
									AutoItX.AU3_Sleep(500);
									AutoItX.AU3_MouseClick("left", 435, 215, 1, 0);
									AutoItX.AU3_Sleep(500);
									AutoItX.AU3_MouseClick("left", 10, 10, 1, 0);
									AutoItX.AU3_Sleep(500);
								}
								if (CheckHitBuy.exit())
								{
									AutoItX.AU3_MouseClick("left", 875, 130, 1, 0);
									AutoItX.AU3_Sleep(500);
									AutoItX.AU3_Send("{Enter down}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{Enter up}", 0);
									AutoItX.AU3_Sleep(500);
									AutoItX.AU3_Send("{Enter down}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{Enter up}", 0);
									AutoItX.AU3_Sleep(500);
									AutoItX.AU3_MouseClick("left", 445, 75, 1, 0);
									AutoItX.AU3_Sleep(500);
									AutoItX.AU3_MouseClick("left", 550, 80, 1, 0);
									AutoItX.AU3_Sleep(500);
								}
								if (CheckHitSell.exit())
								{
									AutoItX.AU3_MouseClick("left", 955, 125, 1, 0);
									AutoItX.AU3_Sleep(500);
									AutoItX.AU3_Send("{Enter down}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{Enter up}", 0);
									// เพิ่ม
									AutoItX.AU3_Sleep(500);
									AutoItX.AU3_Send("{Enter down}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{Enter up}", 0);
									// สุดเพิ่ม
									AutoItX.AU3_Sleep(500);
									AutoItX.AU3_MouseClick("left", 445, 75, 1, 0);
									AutoItX.AU3_Sleep(500);
									AutoItX.AU3_MouseClick("left", 550, 80, 1, 0);
									AutoItX.AU3_Sleep(500);
									// เพิ่ม ล่าง
									AutoItX.AU3_MouseClick("left", 515, 755, 1, 0);
									AutoItX.AU3_Sleep(1500);
									AutoItX.AU3_MouseClick("left", 415, 140, 1, 0);
									AutoItX.AU3_Sleep(1000);
									AutoItX.AU3_Send("{K down}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{K up}", 0);
									AutoItX.AU3_Send("{- down}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{- up}", 0);
									AutoItX.AU3_Send("{2 down}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{2 up}", 0);
									AutoItX.AU3_Sleep(1000);
									AutoItX.AU3_MouseClick("left", 560, 260, 1, 0);
									AutoItX.AU3_Sleep(1000);
									AutoItX.AU3_Send("{Esc down}", 0);
									AutoItX.AU3_Sleep(500);
									AutoItX.AU3_Send("{Esc up}", 0);
									AutoItX.AU3_Sleep(2000);
								}
								if (CheckHitP.exit())
								{
									AutoItX.AU3_MouseClick("left", 515, 755, 1, 0);
									AutoItX.AU3_Sleep(1500);
									AutoItX.AU3_MouseClick("left", 415, 140, 1, 0);
									AutoItX.AU3_Sleep(1000);
									AutoItX.AU3_Send("{K down}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{K up}", 0);
									AutoItX.AU3_Send("{- down}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{- up}", 0);
									AutoItX.AU3_Send("{2 down}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{2 up}", 0);
									AutoItX.AU3_Sleep(1000);
									AutoItX.AU3_MouseClick("left", 560, 260, 1, 0);
									AutoItX.AU3_Sleep(1000);
									AutoItX.AU3_Send("{Esc down}", 0);
									AutoItX.AU3_Sleep(500);
									AutoItX.AU3_Send("{Esc up}", 0);
									AutoItX.AU3_Sleep(2000);
									AutoItX.AU3_MouseClick("left", 495, 650, 1, 0);
									AutoItX.AU3_Sleep(500);
									AutoItX.AU3_Send("{SHIFTdown}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{F down}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{F up}", 0);
									AutoItX.AU3_Send("{SHIFTup}", 0);
									AutoItX.AU3_Send("{5 down}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{5 up}", 0);
									AutoItX.AU3_Send("{Enter down}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{Enter up}", 0);
									AutoItX.AU3_Sleep(5000);
									for (int k = 0; k < 10; k++)
									{
										AutoItX.AU3_Send("{F5 down}", 0);
										AutoItX.AU3_Sleep(100);
										AutoItX.AU3_Send("{F5 up}", 0);
										AutoItX.AU3_Sleep(500);
									}
									AutoItX.AU3_Sleep(4000);
									if (CheckRun.exit())
									{
										AutoItX.AU3_MouseUp("left");
										AutoItX.AU3_Send("{CTRLUP}", 0);
										AutoItX.AU3_Send("{ALTUP}", 0);
										AutoItX.AU3_Sleep(1500);
										AutoItX.AU3_Send("{4 down}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{4 up}", 0);
										AutoItX.AU3_Send("{A down}", 0);
										AutoItX.AU3_Sleep(1500);
										AutoItX.AU3_Send("{A up}", 0);
										AutoItX.AU3_Send("{W down}", 0);
										AutoItX.AU3_Send("{A down}", 0);
										AutoItX.AU3_Sleep(1500);
										AutoItX.AU3_Send("{W up}", 0);
										AutoItX.AU3_Send("{A up}", 0);
										AutoItX.AU3_Send("{W down}", 0);
										AutoItX.AU3_Send("{D down}", 0);
										AutoItX.AU3_Sleep(1500);
										AutoItX.AU3_Send("{W up}", 0);
										AutoItX.AU3_Send("{D up}", 0);
										AutoItX.AU3_Send("{W down}", 0);
										AutoItX.AU3_Sleep(1200);
										AutoItX.AU3_Send("{W up}", 0);
										AutoItX.AU3_Send("{W down}", 0);
										AutoItX.AU3_Send("{D down}", 0);
										AutoItX.AU3_Sleep(850);
										AutoItX.AU3_Send("{W up}", 0);
										AutoItX.AU3_Send("{D up}", 0);
										AutoItX.AU3_Send("{W down}", 0);
										AutoItX.AU3_Sleep(2500);
										AutoItX.AU3_Send("{W up}", 0);
										AutoItX.AU3_Send("{D down}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{D up}", 0);
										AutoItX.AU3_Send("{W down}", 0);
										AutoItX.AU3_Sleep(3800);
										AutoItX.AU3_Send("{W up}", 0);
										AutoItX.AU3_Send("{D down}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{D up}", 0);
										AutoItX.AU3_Send("{W down}", 0);
										AutoItX.AU3_Sleep(2300);
										AutoItX.AU3_Send("{W up}", 0);
										MouseWinApi.MoveRelative(-3115, -20);
										AutoItX.AU3_Send("{W down}", 0);
										AutoItX.AU3_Sleep(100);
										AutoItX.AU3_Send("{W up}", 0);
										AutoItX.AU3_Send("{1 down}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{1 up}", 0);
										for (int l = 0; l < 12; l++)
										{
											AutoItX.AU3_MouseDown("left");
											AutoItX.AU3_Sleep(20);
											AutoItX.AU3_MouseUp("left");
											AutoItX.AU3_Sleep(500);
										}
										for (int m = 0; m < 3; m++)
										{
											AutoItX.AU3_Send("{Enter down}", 0);
											AutoItX.AU3_Sleep(300);
											AutoItX.AU3_Send("{Enter up}", 0);											
											AutoItX.AU3_Sleep(100);
											AutoItX.AU3_Send("{SHIFTdown}", 0);
											AutoItX.AU3_Sleep(100);
											AutoItX.AU3_Send("{O down}", 0);
											AutoItX.AU3_Sleep(100);
											AutoItX.AU3_Send("{O up}", 0);
											AutoItX.AU3_Send("{U down}", 0);
											AutoItX.AU3_Sleep(100);
											AutoItX.AU3_Send("{U up}", 0);
											AutoItX.AU3_Send("{T down}", 0);
											AutoItX.AU3_Sleep(100);
											AutoItX.AU3_Send("{T up}", 0);
											AutoItX.AU3_Send("{SHIFTup}", 0);
											AutoItX.AU3_Send("{Enter down}", 0);
											AutoItX.AU3_Sleep(300);
											AutoItX.AU3_Send("{Enter up}", 0);
											AutoItX.AU3_Sleep(1500);
										}
									}
								}
								if (CheckHitA.exit())
								{
									AutoItX.AU3_Send("{Esc down}", 0);
									AutoItX.AU3_Sleep(500);
									AutoItX.AU3_Send("{Esc up}", 0);
									AutoItX.AU3_Sleep(2000);
									AutoItX.AU3_MouseClick("left", 495, 650, 1, 0);
									AutoItX.AU3_Sleep(500);									
									AutoItX.AU3_Send("{SHIFTdown}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{F down}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{F up}", 0);
									AutoItX.AU3_Send("{SHIFTup}", 0);
									AutoItX.AU3_Send("{5 down}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{5 up}", 0);
									AutoItX.AU3_Send("{Enter down}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{Enter up}", 0);
									AutoItX.AU3_Sleep(5000);
									for (int n = 0; n < 10; n++)
									{
										AutoItX.AU3_Send("{F5 down}", 0);
										AutoItX.AU3_Sleep(100);
										AutoItX.AU3_Send("{F5 up}", 0);
										AutoItX.AU3_Sleep(500);
									}
									AutoItX.AU3_Sleep(4000);
									if (CheckRun.exit())
									{
										AutoItX.AU3_MouseUp("left");
										AutoItX.AU3_Send("{CTRLUP}", 0);
										AutoItX.AU3_Send("{ALTUP}", 0);
										AutoItX.AU3_Sleep(1500);
										AutoItX.AU3_Send("{4 down}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{4 up}", 0);
										AutoItX.AU3_Send("{A down}", 0);
										AutoItX.AU3_Sleep(1500);
										AutoItX.AU3_Send("{A up}", 0);
										AutoItX.AU3_Send("{W down}", 0);
										AutoItX.AU3_Send("{A down}", 0);
										AutoItX.AU3_Sleep(1500);
										AutoItX.AU3_Send("{W up}", 0);
										AutoItX.AU3_Send("{A up}", 0);
										AutoItX.AU3_Send("{W down}", 0);
										AutoItX.AU3_Send("{D down}", 0);
										AutoItX.AU3_Sleep(1500);
										AutoItX.AU3_Send("{W up}", 0);
										AutoItX.AU3_Send("{D up}", 0);
										AutoItX.AU3_Send("{W down}", 0);
										AutoItX.AU3_Sleep(1200);
										AutoItX.AU3_Send("{W up}", 0);
										AutoItX.AU3_Send("{W down}", 0);
										AutoItX.AU3_Send("{D down}", 0);
										AutoItX.AU3_Sleep(850);
										AutoItX.AU3_Send("{W up}", 0);
										AutoItX.AU3_Send("{D up}", 0);
										AutoItX.AU3_Send("{W down}", 0);
										AutoItX.AU3_Sleep(2500);
										AutoItX.AU3_Send("{W up}", 0);
										AutoItX.AU3_Send("{D down}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{D up}", 0);
										AutoItX.AU3_Send("{W down}", 0);
										AutoItX.AU3_Sleep(3800);
										AutoItX.AU3_Send("{W up}", 0);
										AutoItX.AU3_Send("{D down}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{D up}", 0);
										AutoItX.AU3_Send("{W down}", 0);
										AutoItX.AU3_Sleep(2300);
										AutoItX.AU3_Send("{W up}", 0);
										MouseWinApi.MoveRelative(-3115, -20);
										AutoItX.AU3_Send("{W down}", 0);
										AutoItX.AU3_Sleep(100);
										AutoItX.AU3_Send("{W up}", 0);
										AutoItX.AU3_Send("{W down}", 0);
										AutoItX.AU3_Sleep(2000);
										AutoItX.AU3_Send("{W up}", 0);
										AutoItX.AU3_Send("{3 down}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{3 up}", 0);
										AutoItX.AU3_Send("{CTRLDOWN}", 0);
										AutoItX.AU3_Sleep(150);
										AutoItX.AU3_MouseDown("left");
										AutoItX.AU3_Sleep(1500);
										AutoItX.AU3_MouseUp("left");
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{CTRLUP}", 0);
										MouseWinApi.MoveRelative(3115, 20);
										AutoItX.AU3_Send("{A down}", 0);
										AutoItX.AU3_Send("{S down}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{A up}", 0);
										AutoItX.AU3_Send("{S up}", 0);
										AutoItX.AU3_Send("{A down}", 0);
										AutoItX.AU3_Send("{W down}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{W up}", 0);
										AutoItX.AU3_Send("{S up}", 0);
										AutoItX.AU3_Send("{CTRLDOWN}", 0);
										AutoItX.AU3_Sleep(150);
										AutoItX.AU3_MouseDown("left");
										AutoItX.AU3_Sleep(2500);
										AutoItX.AU3_MouseUp("left");
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{CTRLUP}", 0);
										AutoItX.AU3_Send("{1 down}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{1 up}", 0);
										for (int num = 0; num < 12; num++)
										{
											AutoItX.AU3_MouseDown("left");
											AutoItX.AU3_Sleep(20);
											AutoItX.AU3_MouseUp("left");
											AutoItX.AU3_Sleep(500);
										}
										for (int num2 = 0; num2 < 3; num2++)
										{
											AutoItX.AU3_Send("{Enter down}", 0);
											AutoItX.AU3_Sleep(300);
											AutoItX.AU3_Send("{Enter up}", 0);											
											AutoItX.AU3_Sleep(100);
											AutoItX.AU3_Send("{SHIFTdown}", 0);
											AutoItX.AU3_Sleep(100);
											AutoItX.AU3_Send("{O down}", 0);
											AutoItX.AU3_Sleep(100);
											AutoItX.AU3_Send("{O up}", 0);
											AutoItX.AU3_Send("{U down}", 0);
											AutoItX.AU3_Sleep(100);
											AutoItX.AU3_Send("{U up}", 0);
											AutoItX.AU3_Send("{T down}", 0);
											AutoItX.AU3_Sleep(100);
											AutoItX.AU3_Send("{T up}", 0);
											AutoItX.AU3_Send("{SHIFTup}", 0);
											AutoItX.AU3_Send("{Enter down}", 0);
											AutoItX.AU3_Sleep(300);
											AutoItX.AU3_Send("{Enter up}", 0);
											AutoItX.AU3_Sleep(1000);
										}
									}
								}
								if (CheckHitK.exit())
								{
									AutoItX.AU3_Send("{Esc down}", 0);
									AutoItX.AU3_Sleep(500);
									AutoItX.AU3_Send("{Esc up}", 0);
									AutoItX.AU3_Sleep(2000);
									AutoItX.AU3_MouseClick("left", 495, 650, 1, 0);
									AutoItX.AU3_Sleep(500);									
									AutoItX.AU3_Send("{SHIFTdown}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{F down}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{F up}", 0);
									AutoItX.AU3_Send("{SHIFTup}", 0);
									AutoItX.AU3_Send("{5 down}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{5 up}", 0);
									AutoItX.AU3_Send("{Enter down}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{Enter up}", 0);
									AutoItX.AU3_Sleep(5000);
									for (int num3 = 0; num3 < 10; num3++)
									{
										AutoItX.AU3_Send("{F5 down}", 0);
										AutoItX.AU3_Sleep(100);
										AutoItX.AU3_Send("{F5 up}", 0);
										AutoItX.AU3_Sleep(500);
									}
									AutoItX.AU3_Sleep(4000);
									if (CheckRun.exit())
									{
										AutoItX.AU3_MouseUp("left");
										AutoItX.AU3_Send("{CTRLUP}", 0);
										AutoItX.AU3_Send("{ALTUP}", 0);
										AutoItX.AU3_Sleep(1500);
										AutoItX.AU3_Send("{4 down}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{4 up}", 0);
										AutoItX.AU3_Send("{A down}", 0);
										AutoItX.AU3_Sleep(1500);
										AutoItX.AU3_Send("{A up}", 0);
										AutoItX.AU3_Send("{W down}", 0);
										AutoItX.AU3_Send("{A down}", 0);
										AutoItX.AU3_Sleep(1500);
										AutoItX.AU3_Send("{W up}", 0);
										AutoItX.AU3_Send("{A up}", 0);
										AutoItX.AU3_Send("{W down}", 0);
										AutoItX.AU3_Send("{D down}", 0);
										AutoItX.AU3_Sleep(1500);
										AutoItX.AU3_Send("{W up}", 0);
										AutoItX.AU3_Send("{D up}", 0);
										AutoItX.AU3_Send("{W down}", 0);
										AutoItX.AU3_Sleep(1200);
										AutoItX.AU3_Send("{W up}", 0);
										AutoItX.AU3_Send("{W down}", 0);
										AutoItX.AU3_Send("{D down}", 0);
										AutoItX.AU3_Sleep(850);
										AutoItX.AU3_Send("{W up}", 0);
										AutoItX.AU3_Send("{D up}", 0);
										AutoItX.AU3_Send("{W down}", 0);
										AutoItX.AU3_Sleep(2500);
										AutoItX.AU3_Send("{W up}", 0);
										AutoItX.AU3_Send("{D down}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{D up}", 0);
										AutoItX.AU3_Send("{W down}", 0);
										AutoItX.AU3_Sleep(3800);
										AutoItX.AU3_Send("{W up}", 0);
										AutoItX.AU3_Send("{D down}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{D up}", 0);
										AutoItX.AU3_Send("{W down}", 0);
										AutoItX.AU3_Sleep(2300);
										AutoItX.AU3_Send("{W up}", 0);
										MouseWinApi.MoveRelative(-3115, -20);
										AutoItX.AU3_Send("{W down}", 0);
										AutoItX.AU3_Sleep(100);
										AutoItX.AU3_Send("{W up}", 0);
										AutoItX.AU3_Send("{1 down}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{1 up}", 0);
										for (int num4 = 0; num4 < 12; num4++)
										{
											AutoItX.AU3_MouseDown("left");
											AutoItX.AU3_Sleep(20);
											AutoItX.AU3_MouseUp("left");
											AutoItX.AU3_Sleep(500);
										}
										AutoItX.AU3_Sleep(2300);
										AutoItX.AU3_Send("{4 down}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{4 up}", 0);
										MouseWinApi.MoveRelative(0, 2200);
										AutoItX.AU3_MouseDown("left");
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_MouseUp("left");
										AutoItX.AU3_Sleep(12000);
										for (int num18 = 0; num18 < 3; num18++)
										{
											AutoItX.AU3_MouseUp("left");
											AutoItX.AU3_Send("{CTRLUP}", 0);
											AutoItX.AU3_Send("{ALTUP}", 0);
											AutoItX.AU3_Sleep(1500);
											AutoItX.AU3_Send("{4 down}", 0);
											AutoItX.AU3_Sleep(300);
											AutoItX.AU3_Send("{4 up}", 0);
											AutoItX.AU3_Send("{A down}", 0);
											AutoItX.AU3_Sleep(1500);
											AutoItX.AU3_Send("{A up}", 0);
											AutoItX.AU3_Send("{W down}", 0);
											AutoItX.AU3_Send("{A down}", 0);
											AutoItX.AU3_Sleep(1500);
											AutoItX.AU3_Send("{W up}", 0);
											AutoItX.AU3_Send("{A up}", 0);
											AutoItX.AU3_Send("{W down}", 0);
											AutoItX.AU3_Send("{D down}", 0);
											AutoItX.AU3_Sleep(1500);
											AutoItX.AU3_Send("{W up}", 0);
											AutoItX.AU3_Send("{D up}", 0);
											AutoItX.AU3_Send("{W down}", 0);
											AutoItX.AU3_Sleep(1200);
											AutoItX.AU3_Send("{W up}", 0);
											AutoItX.AU3_Send("{W down}", 0);
											AutoItX.AU3_Send("{D down}", 0);
											AutoItX.AU3_Sleep(850);
											AutoItX.AU3_Send("{W up}", 0);
											AutoItX.AU3_Send("{D up}", 0);
											AutoItX.AU3_Send("{W down}", 0);
											AutoItX.AU3_Sleep(2500);
											AutoItX.AU3_Send("{W up}", 0);
											AutoItX.AU3_Send("{D down}", 0);
											AutoItX.AU3_Sleep(300);
											AutoItX.AU3_Send("{D up}", 0);
											AutoItX.AU3_Send("{W down}", 0);
											AutoItX.AU3_Sleep(3800);
											AutoItX.AU3_Send("{W up}", 0);
											AutoItX.AU3_Send("{D down}", 0);
											AutoItX.AU3_Sleep(300);
											AutoItX.AU3_Send("{D up}", 0);
											AutoItX.AU3_Send("{W down}", 0);
											AutoItX.AU3_Sleep(2300);
											AutoItX.AU3_Send("{W up}", 0);
											MouseWinApi.MoveRelative(-3115, -20);
											AutoItX.AU3_Send("{W down}", 0);
											AutoItX.AU3_Sleep(2000);
											AutoItX.AU3_Send("{W up}", 0);
											MouseWinApi.MoveRelative(0, 2200);
											AutoItX.AU3_MouseDown("left");
											AutoItX.AU3_Sleep(300);
											AutoItX.AU3_MouseUp("left");
											AutoItX.AU3_Sleep(12000);
										}
										for (int num5 = 0; num5 < 3; num5++)
										{
											AutoItX.AU3_Send("{Enter down}", 0);
											AutoItX.AU3_Sleep(300);
											AutoItX.AU3_Send("{Enter up}", 0);											
											AutoItX.AU3_Sleep(100);
											AutoItX.AU3_Send("{SHIFTdown}", 0);
											AutoItX.AU3_Sleep(100);
											AutoItX.AU3_Send("{O down}", 0);
											AutoItX.AU3_Sleep(100);
											AutoItX.AU3_Send("{O up}", 0);
											AutoItX.AU3_Send("{U down}", 0);
											AutoItX.AU3_Sleep(100);
											AutoItX.AU3_Send("{U up}", 0);
											AutoItX.AU3_Send("{T down}", 0);
											AutoItX.AU3_Sleep(100);
											AutoItX.AU3_Send("{T up}", 0);
											AutoItX.AU3_Send("{SHIFTup}", 0);
											AutoItX.AU3_Send("{Enter down}", 0);
											AutoItX.AU3_Sleep(300);
											AutoItX.AU3_Send("{Enter up}", 0);
											AutoItX.AU3_Sleep(1500);
										}
									}
								}
								AutoItX.AU3_Sleep(1000);
							}
						}
					}
				}
				if (this.chkMissionAttack.Checked)
				{
					tasks += "ภารกิจจู่โจม, ";
					string path8 = Path.Combine(Environment.GetEnvironmentVariable("TEMP") ?? "C:\\Temp", "png");
					string filename15 = Path.Combine(path8, "Blinking.png");
					string filename16 = Path.Combine(path8, "NotBlinking.png");
					using (Bitmap bitmap30 = new Bitmap(filename15))
					{
						using (Bitmap bitmap31 = new Bitmap(filename16))
						{
							Point point30;
							Point point31;
							if (ImageSearchHelper.FindImageWithDll(this.latestScreen, bitmap30, 20, out point30) || ImageSearchHelper.FindImageWithDll(this.latestScreen, bitmap31, 20, out point31))
							{
								if (CheckMis.exit())
								{
									AutoItX.AU3_MouseClick("left", 775, 750, 1, 0);
									AutoItX.AU3_Sleep(1000);
									AutoItX.AU3_MouseClick("left", 10, 10, 1, 0);
									AutoItX.AU3_Sleep(1500);
									AutoItX.AU3_Send("{Enter down}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{Enter up}", 0);
									AutoItX.AU3_Sleep(500);
								}
								if (CheckMission.exit())
								{
									AutoItX.AU3_MouseClick("left", 550, 80, 1, 0);
									AutoItX.AU3_Sleep(500);
									AutoItX.AU3_MouseClick("left", 610, 130, 1, 0);
									AutoItX.AU3_Sleep(500);
									AutoItX.AU3_MouseClick("left", 435, 265, 1, 0);
									AutoItX.AU3_Sleep(500);
									AutoItX.AU3_MouseClick("left", 10, 10, 1, 0);
									AutoItX.AU3_Sleep(500);
								}
								if (CheckAttackBuy.exit())
								{
									AutoItX.AU3_MouseClick("left", 875, 130, 1, 0);
									AutoItX.AU3_Sleep(500);
									AutoItX.AU3_Send("{Enter down}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{Enter up}", 0);
									AutoItX.AU3_Sleep(500);
									AutoItX.AU3_Send("{Enter down}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{Enter up}", 0);
									AutoItX.AU3_Sleep(500);
									AutoItX.AU3_MouseClick("left", 445, 75, 1, 0);
									AutoItX.AU3_Sleep(500);
									AutoItX.AU3_MouseClick("left", 550, 80, 1, 0);
									AutoItX.AU3_Sleep(500);
								}
								if (CheckAttackSell.exit())
								{
									AutoItX.AU3_MouseClick("left", 955, 125, 1, 0);
									AutoItX.AU3_Sleep(500);
									AutoItX.AU3_Send("{Enter down}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{Enter up}", 0);
									// เพิ่ม
									AutoItX.AU3_Sleep(500);
									AutoItX.AU3_Send("{Enter down}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{Enter up}", 0);
									// สุดเพิ่ม
									AutoItX.AU3_Sleep(500);
									AutoItX.AU3_MouseClick("left", 445, 75, 1, 0);
									AutoItX.AU3_Sleep(500);
									AutoItX.AU3_MouseClick("left", 550, 80, 1, 0);
									AutoItX.AU3_Sleep(500);
									// เพิ่ม ล่าง
									AutoItX.AU3_MouseClick("left", 515, 755, 1, 0);
									AutoItX.AU3_Sleep(1500);
									AutoItX.AU3_MouseClick("left", 415, 140, 1, 0);
									AutoItX.AU3_Sleep(1000);
									AutoItX.AU3_Send("{K down}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{K up}", 0);
									AutoItX.AU3_Send("{- down}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{- up}", 0);
									AutoItX.AU3_Send("{2 down}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{2 up}", 0);
									AutoItX.AU3_Sleep(1000);
									AutoItX.AU3_MouseClick("left", 560, 260, 1, 0);
									AutoItX.AU3_Sleep(1000);
									AutoItX.AU3_Send("{Esc down}", 0);
									AutoItX.AU3_Sleep(500);
									AutoItX.AU3_Send("{Esc up}", 0);
									AutoItX.AU3_Sleep(2000);
								}
								if (CheckAttackT.exit())
								{
									AutoItX.AU3_MouseClick("left", 515, 755, 1, 0);
									AutoItX.AU3_Sleep(1500);
									AutoItX.AU3_MouseClick("left", 415, 140, 1, 0);
									AutoItX.AU3_Sleep(1000);
									AutoItX.AU3_Send("{K down}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{K up}", 0);
									AutoItX.AU3_Send("{- down}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{- up}", 0);
									AutoItX.AU3_Send("{2 down}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{2 up}", 0);
									AutoItX.AU3_Sleep(1000);
									AutoItX.AU3_MouseClick("left", 560, 260, 1, 0);
									AutoItX.AU3_Sleep(1000);
									AutoItX.AU3_Send("{Esc down}", 0);
									AutoItX.AU3_Sleep(500);
									AutoItX.AU3_Send("{Esc up}", 0);
									AutoItX.AU3_Sleep(2000);
									AutoItX.AU3_MouseClick("left", 495, 650, 1, 0);
									AutoItX.AU3_Sleep(500);
									AutoItX.AU3_Send("{SHIFTdown}", 0);
									AutoItX.AU3_Sleep(100);						
									AutoItX.AU3_Send("{F down}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{F up}", 0);
									AutoItX.AU3_Send("{SHIFTup}", 0);
									AutoItX.AU3_Send("{5 down}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{5 up}", 0);
									AutoItX.AU3_Send("{Enter down}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{Enter up}", 0);
									AutoItX.AU3_Sleep(5000);
									for (int num6 = 0; num6 < 10; num6++)
									{
										AutoItX.AU3_Send("{F5 down}", 0);
										AutoItX.AU3_Sleep(100);
										AutoItX.AU3_Send("{F5 up}", 0);
										AutoItX.AU3_Sleep(500);
									}
									AutoItX.AU3_Sleep(4000);
									if (CheckRun.exit())
									{
										AutoItX.AU3_MouseUp("left");
										AutoItX.AU3_Send("{CTRLUP}", 0);
										AutoItX.AU3_Send("{ALTUP}", 0);
										AutoItX.AU3_Sleep(1500);
										AutoItX.AU3_Send("{4 down}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{4 up}", 0);
										AutoItX.AU3_Send("{A down}", 0);
										AutoItX.AU3_Sleep(1500);
										AutoItX.AU3_Send("{A up}", 0);
										AutoItX.AU3_Send("{W down}", 0);
										AutoItX.AU3_Send("{A down}", 0);
										AutoItX.AU3_Sleep(1500);
										AutoItX.AU3_Send("{W up}", 0);
										AutoItX.AU3_Send("{A up}", 0);
										AutoItX.AU3_Send("{W down}", 0);
										AutoItX.AU3_Send("{D down}", 0);
										AutoItX.AU3_Sleep(1500);
										AutoItX.AU3_Send("{W up}", 0);
										AutoItX.AU3_Send("{D up}", 0);
										AutoItX.AU3_Send("{W down}", 0);
										AutoItX.AU3_Sleep(1200);
										AutoItX.AU3_Send("{W up}", 0);
										AutoItX.AU3_Send("{W down}", 0);
										AutoItX.AU3_Send("{D down}", 0);
										AutoItX.AU3_Sleep(850);
										AutoItX.AU3_Send("{W up}", 0);
										AutoItX.AU3_Send("{D up}", 0);
										AutoItX.AU3_Send("{W down}", 0);
										AutoItX.AU3_Sleep(2500);
										AutoItX.AU3_Send("{W up}", 0);
										AutoItX.AU3_Send("{D down}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{D up}", 0);
										AutoItX.AU3_Send("{W down}", 0);
										AutoItX.AU3_Sleep(3800);
										AutoItX.AU3_Send("{W up}", 0);
										AutoItX.AU3_Send("{D down}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{D up}", 0);
										AutoItX.AU3_Send("{W down}", 0);
										AutoItX.AU3_Sleep(2300);
										AutoItX.AU3_Send("{W up}", 0);
										MouseWinApi.MoveRelative(-3115, -20);
										AutoItX.AU3_Send("{W down}", 0);
										AutoItX.AU3_Sleep(100);
										AutoItX.AU3_Send("{W up}", 0);
										AutoItX.AU3_Send("{1 down}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{1 up}", 0);
										for (int num7 = 0; num7 < 12; num7++)
										{
											AutoItX.AU3_MouseDown("left");
											AutoItX.AU3_Sleep(20);
											AutoItX.AU3_MouseUp("left");
											AutoItX.AU3_Sleep(500);
										}
										AutoItX.AU3_Sleep(10000);
										AutoItX.AU3_Send("{4 down}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{4 up}", 0);
										MouseWinApi.MoveRelative(0, -1500);
										AutoItX.AU3_MouseDown("left");
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_MouseUp("left");
										AutoItX.AU3_Sleep(4000);
										for (int num8 = 0; num8 < 3; num8++)
										{
											AutoItX.AU3_Send("{Enter down}", 0);
											AutoItX.AU3_Sleep(300);
											AutoItX.AU3_Send("{Enter up}", 0);
											AutoItX.AU3_Sleep(100);
											AutoItX.AU3_Send("{SHIFTdown}", 0);
											AutoItX.AU3_Sleep(100);
											AutoItX.AU3_Send("{O down}", 0);
											AutoItX.AU3_Sleep(100);
											AutoItX.AU3_Send("{O up}", 0);
											AutoItX.AU3_Send("{U down}", 0);
											AutoItX.AU3_Sleep(100);
											AutoItX.AU3_Send("{U up}", 0);
											AutoItX.AU3_Send("{T down}", 0);
											AutoItX.AU3_Sleep(100);
											AutoItX.AU3_Send("{T up}", 0);
											AutoItX.AU3_Send("{SHIFTup}", 0);
											AutoItX.AU3_Send("{Enter down}", 0);
											AutoItX.AU3_Sleep(300);
											AutoItX.AU3_Send("{Enter up}", 0);
											AutoItX.AU3_Sleep(1500);
										}
									}
								}
								if (CheckAttackL.exit())
								{
									AutoItX.AU3_MouseClick("left", 515, 755, 1, 0);
									AutoItX.AU3_Sleep(1500);
									AutoItX.AU3_MouseClick("left", 415, 140, 1, 0);
									AutoItX.AU3_Sleep(1000);
									AutoItX.AU3_Send("{K down}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{K up}", 0);
									AutoItX.AU3_Send("{- down}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{- up}", 0);
									AutoItX.AU3_Send("{1 down}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{1 up}", 0);
									AutoItX.AU3_Sleep(1000);
									AutoItX.AU3_MouseClick("left", 560, 260, 1, 0);
									AutoItX.AU3_Sleep(1000);
									AutoItX.AU3_Send("{Esc down}", 0);
									AutoItX.AU3_Sleep(500);
									AutoItX.AU3_Send("{Esc up}", 0);
									AutoItX.AU3_Sleep(2000);
									AutoItX.AU3_MouseClick("left", 495, 650, 1, 0);
									AutoItX.AU3_Sleep(500);
									AutoItX.AU3_Send("{SHIFTdown}", 0);
									AutoItX.AU3_Sleep(100);									
									AutoItX.AU3_Send("{F down}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{F up}", 0);
									AutoItX.AU3_Send("{SHIFTup}", 0);
									AutoItX.AU3_Send("{5 down}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{5 up}", 0);
									AutoItX.AU3_Send("{Enter down}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{Enter up}", 0);
									AutoItX.AU3_Sleep(5000);
									for (int num9 = 0; num9 < 10; num9++)
									{
										AutoItX.AU3_Send("{F5 down}", 0);
										AutoItX.AU3_Sleep(100);
										AutoItX.AU3_Send("{F5 up}", 0);
										AutoItX.AU3_Sleep(500);
									}
									AutoItX.AU3_Sleep(4000);
									if (CheckRun.exit())
									{
										for (int num10 = 0; num10 < 2; num10++)
										{
											AutoItX.AU3_MouseUp("left");
											AutoItX.AU3_Send("{CTRLUP}", 0);
											AutoItX.AU3_Send("{ALTUP}", 0);
											AutoItX.AU3_Sleep(1500);
											AutoItX.AU3_Send("{4 down}", 0);
											AutoItX.AU3_Sleep(300);
											AutoItX.AU3_Send("{4 up}", 0);
											AutoItX.AU3_Send("{A down}", 0);
											AutoItX.AU3_Sleep(1500);
											AutoItX.AU3_Send("{A up}", 0);
											AutoItX.AU3_Send("{W down}", 0);
											AutoItX.AU3_Send("{A down}", 0);
											AutoItX.AU3_Sleep(1500);
											AutoItX.AU3_Send("{W up}", 0);
											AutoItX.AU3_Send("{A up}", 0);
											AutoItX.AU3_Send("{W down}", 0);
											AutoItX.AU3_Send("{D down}", 0);
											AutoItX.AU3_Sleep(1500);
											AutoItX.AU3_Send("{W up}", 0);
											AutoItX.AU3_Send("{D up}", 0);
											AutoItX.AU3_Send("{W down}", 0);
											AutoItX.AU3_Sleep(1200);
											AutoItX.AU3_Send("{W up}", 0);
											AutoItX.AU3_Send("{W down}", 0);
											AutoItX.AU3_Send("{D down}", 0);
											AutoItX.AU3_Sleep(850);
											AutoItX.AU3_Send("{W up}", 0);
											AutoItX.AU3_Send("{D up}", 0);
											AutoItX.AU3_Send("{W down}", 0);
											AutoItX.AU3_Sleep(2500);
											AutoItX.AU3_Send("{W up}", 0);
											AutoItX.AU3_Send("{D down}", 0);
											AutoItX.AU3_Sleep(300);
											AutoItX.AU3_Send("{D up}", 0);
											AutoItX.AU3_Send("{W down}", 0);
											AutoItX.AU3_Sleep(3800);
											AutoItX.AU3_Send("{W up}", 0);
											AutoItX.AU3_Send("{D down}", 0);
											AutoItX.AU3_Sleep(300);
											AutoItX.AU3_Send("{D up}", 0);
											AutoItX.AU3_Send("{W down}", 0);
											AutoItX.AU3_Sleep(2300);
											AutoItX.AU3_Send("{W up}", 0);
											MouseWinApi.MoveRelative(-3115, -20);
											AutoItX.AU3_Send("{W down}", 0);
											AutoItX.AU3_Sleep(100);
											AutoItX.AU3_Send("{W up}", 0);
											AutoItX.AU3_Send("{1 down}", 0);
											AutoItX.AU3_Sleep(300);
											AutoItX.AU3_Send("{1 up}", 0);
											for (int num11 = 0; num11 < 12; num11++)
											{
												AutoItX.AU3_MouseDown("left");
												AutoItX.AU3_Sleep(20);
												AutoItX.AU3_MouseUp("left");
												AutoItX.AU3_Sleep(500);
											}
											AutoItX.AU3_Send("{4 down}", 0);
											AutoItX.AU3_Sleep(300);
											AutoItX.AU3_Send("{4 up}", 0);
											MouseWinApi.MoveRelative(0, 2200);
											AutoItX.AU3_MouseDown("left");
											AutoItX.AU3_Sleep(300);
											AutoItX.AU3_MouseUp("left");
											AutoItX.AU3_Sleep(12000);
										}
										for (int num12 = 0; num12 < 3; num12++)
										{
											AutoItX.AU3_Send("{Enter down}", 0);
											AutoItX.AU3_Sleep(300);
											AutoItX.AU3_Send("{Enter up}", 0);											
											AutoItX.AU3_Sleep(100);
											AutoItX.AU3_Send("{SHIFTdown}", 0);
											AutoItX.AU3_Sleep(100);
											AutoItX.AU3_Send("{O down}", 0);
											AutoItX.AU3_Sleep(100);
											AutoItX.AU3_Send("{O up}", 0);
											AutoItX.AU3_Send("{U down}", 0);
											AutoItX.AU3_Sleep(100);
											AutoItX.AU3_Send("{U up}", 0);
											AutoItX.AU3_Send("{T down}", 0);
											AutoItX.AU3_Sleep(100);
											AutoItX.AU3_Send("{T up}", 0);
											AutoItX.AU3_Send("{SHIFTup}", 0);
											AutoItX.AU3_Send("{Enter down}", 0);
											AutoItX.AU3_Sleep(300);
											AutoItX.AU3_Send("{Enter up}", 0);
											AutoItX.AU3_Sleep(1500);
										}
									}
								}
								if (CheckAttackN2.exit())
								{
									AutoItX.AU3_MouseClick("left", 515, 755, 1, 0);
									AutoItX.AU3_Sleep(1500);
									AutoItX.AU3_MouseClick("left", 415, 140, 1, 0);
									AutoItX.AU3_Sleep(1000);
									AutoItX.AU3_Send("{K down}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{K up}", 0);
									AutoItX.AU3_Send("{- down}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{- up}", 0);
									AutoItX.AU3_Send("{1 down}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{1 up}", 0);
									AutoItX.AU3_Sleep(1000);
									AutoItX.AU3_MouseClick("left", 560, 260, 1, 0);
									AutoItX.AU3_Sleep(1000);
									AutoItX.AU3_Send("{Esc down}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{Esc up}", 0);
									AutoItX.AU3_Sleep(2000);
									AutoItX.AU3_MouseClick("left", 495, 650, 1, 0);
									AutoItX.AU3_Sleep(500);
									AutoItX.AU3_Send("{SHIFTdown}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{F down}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{F up}", 0);
									AutoItX.AU3_Send("{SHIFTup}", 0);
									AutoItX.AU3_Send("{5 down}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{5 up}", 0);
									AutoItX.AU3_Send("{Enter down}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{Enter up}", 0);
									AutoItX.AU3_Sleep(5000);
									for (int num13 = 0; num13 < 10; num13++)
									{
										AutoItX.AU3_Send("{F5 down}", 0);
										AutoItX.AU3_Sleep(100);
										AutoItX.AU3_Send("{F5 up}", 0);
										AutoItX.AU3_Sleep(500);
									}
									AutoItX.AU3_Sleep(10000);
									if (CheckRun.exit())
									{
										for (int num14 = 0; num14 < 2; num14++)
										{
											AutoItX.AU3_MouseUp("left");
											AutoItX.AU3_Send("{CTRLUP}", 0);
											AutoItX.AU3_Send("{ALTUP}", 0);
											AutoItX.AU3_Sleep(1500);
											AutoItX.AU3_Send("{4 down}", 0);
											AutoItX.AU3_Sleep(300);
											AutoItX.AU3_Send("{4 up}", 0);
											AutoItX.AU3_Send("{A down}", 0);
											AutoItX.AU3_Sleep(1500);
											AutoItX.AU3_Send("{A up}", 0);
											AutoItX.AU3_Send("{W down}", 0);
											AutoItX.AU3_Send("{A down}", 0);
											AutoItX.AU3_Sleep(1500);
											AutoItX.AU3_Send("{W up}", 0);
											AutoItX.AU3_Send("{A up}", 0);
											AutoItX.AU3_Send("{W down}", 0);
											AutoItX.AU3_Send("{D down}", 0);
											AutoItX.AU3_Sleep(1500);
											AutoItX.AU3_Send("{W up}", 0);
											AutoItX.AU3_Send("{D up}", 0);
											AutoItX.AU3_Send("{W down}", 0);
											AutoItX.AU3_Sleep(1200);
											AutoItX.AU3_Send("{W up}", 0);
											AutoItX.AU3_Send("{W down}", 0);
											AutoItX.AU3_Send("{D down}", 0);
											AutoItX.AU3_Sleep(850);
											AutoItX.AU3_Send("{W up}", 0);
											AutoItX.AU3_Send("{D up}", 0);
											AutoItX.AU3_Send("{W down}", 0);
											AutoItX.AU3_Sleep(2500);
											AutoItX.AU3_Send("{W up}", 0);
											AutoItX.AU3_Send("{D down}", 0);
											AutoItX.AU3_Sleep(300);
											AutoItX.AU3_Send("{D up}", 0);
											AutoItX.AU3_Send("{W down}", 0);
											AutoItX.AU3_Sleep(3800);
											AutoItX.AU3_Send("{W up}", 0);
											AutoItX.AU3_Send("{D down}", 0);
											AutoItX.AU3_Sleep(300);
											AutoItX.AU3_Send("{D up}", 0);
											AutoItX.AU3_Send("{W down}", 0);
											AutoItX.AU3_Sleep(2300);
											AutoItX.AU3_Send("{W up}", 0);
											MouseWinApi.MoveRelative(-3115, -20);
											AutoItX.AU3_Send("{W down}", 0);
											AutoItX.AU3_Sleep(100);
											AutoItX.AU3_Send("{W up}", 0);
											AutoItX.AU3_Send("{1 down}", 0);
											AutoItX.AU3_Sleep(300);
											AutoItX.AU3_Send("{1 up}", 0);
											for (int num15 = 0; num15 < 12; num15++)
											{
												AutoItX.AU3_MouseDown("left");
												AutoItX.AU3_Sleep(20);
												AutoItX.AU3_MouseUp("left");
												AutoItX.AU3_Sleep(500);
											}
											AutoItX.AU3_Send("{4 down}", 0);
											AutoItX.AU3_Sleep(300);
											AutoItX.AU3_Send("{4 up}", 0);
											MouseWinApi.MoveRelative(0, 2200);
											AutoItX.AU3_MouseDown("left");
											AutoItX.AU3_Sleep(300);
											AutoItX.AU3_MouseUp("left");
											AutoItX.AU3_Sleep(12000);
										}
										for (int num16 = 0; num16 < 3; num16++)
										{
											AutoItX.AU3_Send("{Enter down}", 0);
											AutoItX.AU3_Sleep(300);
											AutoItX.AU3_Send("{Enter up}", 0);											
											AutoItX.AU3_Sleep(100);
											AutoItX.AU3_Send("{SHIFTdown}", 0);
											AutoItX.AU3_Sleep(100);
											AutoItX.AU3_Send("{O down}", 0);
											AutoItX.AU3_Sleep(100);
											AutoItX.AU3_Send("{O up}", 0);
											AutoItX.AU3_Send("{U down}", 0);
											AutoItX.AU3_Sleep(100);
											AutoItX.AU3_Send("{U up}", 0);
											AutoItX.AU3_Send("{T down}", 0);
											AutoItX.AU3_Sleep(100);
											AutoItX.AU3_Send("{T up}", 0);
											AutoItX.AU3_Send("{SHIFTup}", 0);
											AutoItX.AU3_Send("{Enter down}", 0);
											AutoItX.AU3_Sleep(300);
											AutoItX.AU3_Send("{Enter up}", 0);
											AutoItX.AU3_Sleep(1500);
										}
									}
								}
								if (CheckAttackK.exit())
								{
									AutoItX.AU3_Send("{Esc down}", 0);
									AutoItX.AU3_Sleep(500);
									AutoItX.AU3_Send("{Esc up}", 0);
									AutoItX.AU3_Sleep(2000);
									AutoItX.AU3_MouseClick("left", 495, 650, 1, 0);
									AutoItX.AU3_Sleep(500);		
									AutoItX.AU3_Send("{SHIFTdown}", 0);
									AutoItX.AU3_Sleep(100);							
									AutoItX.AU3_Send("{F down}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{F up}", 0);
									AutoItX.AU3_Send("{SHIFTup}", 0);
									AutoItX.AU3_Send("{5 down}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{5 up}", 0);
									AutoItX.AU3_Send("{Enter down}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{Enter up}", 0);
									AutoItX.AU3_Sleep(5000);
									for (int num17 = 0; num17 < 10; num17++)
									{
										AutoItX.AU3_Send("{F5 down}", 0);
										AutoItX.AU3_Sleep(100);
										AutoItX.AU3_Send("{F5 up}", 0);
										AutoItX.AU3_Sleep(500);
									}
									AutoItX.AU3_Sleep(4000);
									if (CheckRun.exit())
									{
										for (int num18 = 0; num18 < 3; num18++)
										{
											AutoItX.AU3_MouseUp("left");
											AutoItX.AU3_Send("{CTRLUP}", 0);
											AutoItX.AU3_Send("{ALTUP}", 0);
											AutoItX.AU3_Sleep(1500);
											AutoItX.AU3_Send("{4 down}", 0);
											AutoItX.AU3_Sleep(300);
											AutoItX.AU3_Send("{4 up}", 0);
											AutoItX.AU3_Send("{A down}", 0);
											AutoItX.AU3_Sleep(1500);
											AutoItX.AU3_Send("{A up}", 0);
											AutoItX.AU3_Send("{W down}", 0);
											AutoItX.AU3_Send("{A down}", 0);
											AutoItX.AU3_Sleep(1500);
											AutoItX.AU3_Send("{W up}", 0);
											AutoItX.AU3_Send("{A up}", 0);
											AutoItX.AU3_Send("{W down}", 0);
											AutoItX.AU3_Send("{D down}", 0);
											AutoItX.AU3_Sleep(1500);
											AutoItX.AU3_Send("{W up}", 0);
											AutoItX.AU3_Send("{D up}", 0);
											AutoItX.AU3_Send("{W down}", 0);
											AutoItX.AU3_Sleep(1200);
											AutoItX.AU3_Send("{W up}", 0);
											AutoItX.AU3_Send("{W down}", 0);
											AutoItX.AU3_Send("{D down}", 0);
											AutoItX.AU3_Sleep(850);
											AutoItX.AU3_Send("{W up}", 0);
											AutoItX.AU3_Send("{D up}", 0);
											AutoItX.AU3_Send("{W down}", 0);
											AutoItX.AU3_Sleep(2500);
											AutoItX.AU3_Send("{W up}", 0);
											AutoItX.AU3_Send("{D down}", 0);
											AutoItX.AU3_Sleep(300);
											AutoItX.AU3_Send("{D up}", 0);
											AutoItX.AU3_Send("{W down}", 0);
											AutoItX.AU3_Sleep(3800);
											AutoItX.AU3_Send("{W up}", 0);
											AutoItX.AU3_Send("{D down}", 0);
											AutoItX.AU3_Sleep(300);
											AutoItX.AU3_Send("{D up}", 0);
											AutoItX.AU3_Send("{W down}", 0);
											AutoItX.AU3_Sleep(2300);
											AutoItX.AU3_Send("{W up}", 0);
											MouseWinApi.MoveRelative(-3115, -20);
											AutoItX.AU3_Send("{W down}", 0);
											AutoItX.AU3_Sleep(2000);
											AutoItX.AU3_Send("{W up}", 0);
											MouseWinApi.MoveRelative(0, 2200);
											AutoItX.AU3_MouseDown("left");
											AutoItX.AU3_Sleep(300);
											AutoItX.AU3_MouseUp("left");
											AutoItX.AU3_Sleep(12000);
										}
										for (int num19 = 0; num19 < 3; num19++)
										{
											AutoItX.AU3_Send("{Enter down}", 0);
											AutoItX.AU3_Sleep(300);
											AutoItX.AU3_Send("{Enter up}", 0);											
											AutoItX.AU3_Sleep(100);
											AutoItX.AU3_Send("{SHIFTdown}", 0);
											AutoItX.AU3_Sleep(100);
											AutoItX.AU3_Send("{O down}", 0);
											AutoItX.AU3_Sleep(100);
											AutoItX.AU3_Send("{O up}", 0);
											AutoItX.AU3_Send("{U down}", 0);
											AutoItX.AU3_Sleep(100);
											AutoItX.AU3_Send("{U up}", 0);
											AutoItX.AU3_Send("{T down}", 0);
											AutoItX.AU3_Sleep(100);
											AutoItX.AU3_Send("{T up}", 0);
											AutoItX.AU3_Send("{SHIFTup}", 0);
											AutoItX.AU3_Send("{Enter down}", 0);
											AutoItX.AU3_Sleep(300);
											AutoItX.AU3_Send("{Enter up}", 0);
											AutoItX.AU3_Sleep(1500);
										}
									}
								}
								if (CheckAttackBoom.exit())
								{
									AutoItX.AU3_Send("{Esc down}", 0);
									AutoItX.AU3_Sleep(500);
									AutoItX.AU3_Send("{Esc up}", 0);
									AutoItX.AU3_Sleep(2000);
									AutoItX.AU3_MouseClick("left", 495, 650, 1, 0);
									AutoItX.AU3_Sleep(500);		
									AutoItX.AU3_Send("{SHIFTdown}", 0);
									AutoItX.AU3_Sleep(100);							
									AutoItX.AU3_Send("{F down}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{F up}", 0);
									AutoItX.AU3_Send("{SHIFTup}", 0);
									AutoItX.AU3_Send("{5 down}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{5 up}", 0);
									AutoItX.AU3_Send("{Enter down}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{Enter up}", 0);
									AutoItX.AU3_Sleep(5000);
									for (int num20 = 0; num20 < 10; num20++)
									{
										AutoItX.AU3_Send("{F5 down}", 0);
										AutoItX.AU3_Sleep(100);
										AutoItX.AU3_Send("{F5 up}", 0);
										AutoItX.AU3_Sleep(500);
									}
									AutoItX.AU3_Sleep(4000);
									if (CheckRun.exit())
									{
										AutoItX.AU3_MouseUp("left");
										AutoItX.AU3_Send("{CTRLUP}", 0);
										AutoItX.AU3_Send("{ALTUP}", 0);
										AutoItX.AU3_Sleep(1500);
										AutoItX.AU3_Send("{4 down}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{4 up}", 0);
										AutoItX.AU3_Send("{A down}", 0);
										AutoItX.AU3_Sleep(1500);
										AutoItX.AU3_Send("{A up}", 0);
										AutoItX.AU3_Send("{W down}", 0);
										AutoItX.AU3_Send("{A down}", 0);
										AutoItX.AU3_Sleep(1500);
										AutoItX.AU3_Send("{W up}", 0);
										AutoItX.AU3_Send("{A up}", 0);
										AutoItX.AU3_Send("{W down}", 0);
										AutoItX.AU3_Send("{D down}", 0);
										AutoItX.AU3_Sleep(1500);
										AutoItX.AU3_Send("{W up}", 0);
										AutoItX.AU3_Send("{D up}", 0);
										AutoItX.AU3_Send("{W down}", 0);
										AutoItX.AU3_Sleep(1200);
										AutoItX.AU3_Send("{W up}", 0);
										AutoItX.AU3_Send("{W down}", 0);
										AutoItX.AU3_Send("{D down}", 0);
										AutoItX.AU3_Sleep(850);
										AutoItX.AU3_Send("{W up}", 0);
										AutoItX.AU3_Send("{D up}", 0);
										AutoItX.AU3_Send("{W down}", 0);
										AutoItX.AU3_Sleep(2500);
										AutoItX.AU3_Send("{W up}", 0);
										AutoItX.AU3_Send("{D down}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{D up}", 0);
										AutoItX.AU3_Send("{W down}", 0);
										AutoItX.AU3_Sleep(3800);
										AutoItX.AU3_Send("{W up}", 0);
										AutoItX.AU3_Send("{D down}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{D up}", 0);
										AutoItX.AU3_Send("{W down}", 0);
										AutoItX.AU3_Sleep(2300);
										AutoItX.AU3_Send("{W up}", 0);
										MouseWinApi.MoveRelative(-3115, -20);
										AutoItX.AU3_Send("{W down}", 0);
										AutoItX.AU3_Sleep(100);
										AutoItX.AU3_Send("{W up}", 0);
										AutoItX.AU3_Send("{1 down}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{1 up}", 0);
										for (int num21 = 0; num21 < 8; num21++)
										{
											AutoItX.AU3_MouseDown("left");
											AutoItX.AU3_Sleep(20);
											AutoItX.AU3_MouseUp("left");
											AutoItX.AU3_Sleep(500);
										}
										AutoItX.AU3_Sleep(10000);
										AutoItX.AU3_Send("{4 down}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{4 up}", 0);
										MouseWinApi.MoveRelative(0, -1500);
										AutoItX.AU3_MouseDown("left");
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_MouseUp("left");
										AutoItX.AU3_Sleep(4000);
										for (int num22 = 0; num22 < 3; num22++)
										{
											AutoItX.AU3_Send("{Enter down}", 0);
											AutoItX.AU3_Sleep(300);
											AutoItX.AU3_Send("{Enter up}", 0);
											AutoItX.AU3_Sleep(100);
											AutoItX.AU3_Send("{SHIFTdown}", 0);
											AutoItX.AU3_Sleep(100);
											AutoItX.AU3_Send("{O down}", 0);
											AutoItX.AU3_Sleep(100);
											AutoItX.AU3_Send("{O up}", 0);
											AutoItX.AU3_Send("{U down}", 0);
											AutoItX.AU3_Sleep(100);
											AutoItX.AU3_Send("{U up}", 0);
											AutoItX.AU3_Send("{T down}", 0);
											AutoItX.AU3_Sleep(100);
											AutoItX.AU3_Send("{T up}", 0);
											AutoItX.AU3_Send("{SHIFTup}", 0);
											AutoItX.AU3_Send("{Enter down}", 0);
											AutoItX.AU3_Sleep(300);
											AutoItX.AU3_Send("{Enter up}", 0);
											AutoItX.AU3_Sleep(1500);
										}
									}
								}
								if (CheckAttackNoBoom.exit())
								{
									AutoItX.AU3_Send("{Esc down}", 0);
									AutoItX.AU3_Sleep(500);
									AutoItX.AU3_Send("{Esc up}", 0);
									AutoItX.AU3_Sleep(2000);
									AutoItX.AU3_MouseClick("left", 495, 650, 1, 0);
									AutoItX.AU3_Sleep(500);		
									AutoItX.AU3_Send("{SHIFTdown}", 0);
									AutoItX.AU3_Sleep(100);							
									AutoItX.AU3_Send("{F down}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{F up}", 0);
									AutoItX.AU3_Send("{SHIFTup}", 0);
									AutoItX.AU3_Send("{5 down}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{5 up}", 0);
									AutoItX.AU3_Send("{Enter down}", 0);
									AutoItX.AU3_Sleep(100);
									AutoItX.AU3_Send("{Enter up}", 0);
									AutoItX.AU3_Sleep(5000);
									for (int num23 = 0; num23 < 10; num23++)
									{
										AutoItX.AU3_Send("{F5 down}", 0);
										AutoItX.AU3_Sleep(100);
										AutoItX.AU3_Send("{F5 up}", 0);
										AutoItX.AU3_Sleep(500);
									}
									AutoItX.AU3_Sleep(4000);
									if (CheckRun.exit())
									{
										AutoItX.AU3_MouseUp("left");
										AutoItX.AU3_Send("{CTRLUP}", 0);
										AutoItX.AU3_Send("{ALTUP}", 0);
										AutoItX.AU3_Sleep(1500);
										AutoItX.AU3_Send("{4 down}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{4 up}", 0);
										AutoItX.AU3_Send("{A down}", 0);
										AutoItX.AU3_Sleep(1500);
										AutoItX.AU3_Send("{A up}", 0);
										AutoItX.AU3_Send("{W down}", 0);
										AutoItX.AU3_Send("{A down}", 0);
										AutoItX.AU3_Sleep(1500);
										AutoItX.AU3_Send("{W up}", 0);
										AutoItX.AU3_Send("{A up}", 0);
										AutoItX.AU3_Send("{W down}", 0);
										AutoItX.AU3_Send("{D down}", 0);
										AutoItX.AU3_Sleep(1500);
										AutoItX.AU3_Send("{W up}", 0);
										AutoItX.AU3_Send("{D up}", 0);
										AutoItX.AU3_Send("{W down}", 0);
										AutoItX.AU3_Sleep(1200);
										AutoItX.AU3_Send("{W up}", 0);
										AutoItX.AU3_Send("{W down}", 0);
										AutoItX.AU3_Send("{D down}", 0);
										AutoItX.AU3_Sleep(850);
										AutoItX.AU3_Send("{W up}", 0);
										AutoItX.AU3_Send("{D up}", 0);
										AutoItX.AU3_Send("{W down}", 0);
										AutoItX.AU3_Sleep(2500);
										AutoItX.AU3_Send("{W up}", 0);
										AutoItX.AU3_Send("{D down}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{D up}", 0);
										AutoItX.AU3_Send("{W down}", 0);
										AutoItX.AU3_Sleep(3800);
										AutoItX.AU3_Send("{W up}", 0);
										AutoItX.AU3_Send("{D down}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{D up}", 0);
										AutoItX.AU3_Send("{W down}", 0);
										AutoItX.AU3_Sleep(2300);
										AutoItX.AU3_Send("{W up}", 0);
										MouseWinApi.MoveRelative(-3115, -20);
										AutoItX.AU3_Send("{W down}", 0);
										AutoItX.AU3_Sleep(100);
										AutoItX.AU3_Send("{W up}", 0);
										AutoItX.AU3_Send("{1 down}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{1 up}", 0);
										for (int num24 = 0; num24 < 8; num24++)
										{
											AutoItX.AU3_MouseDown("left");
											AutoItX.AU3_Sleep(20);
											AutoItX.AU3_MouseUp("left");
											AutoItX.AU3_Sleep(500);
										}
										AutoItX.AU3_Sleep(10000);
										for (int num25 = 0; num25 < 8; num25++)
										{
											AutoItX.AU3_MouseDown("left");
											AutoItX.AU3_Sleep(20);
											AutoItX.AU3_MouseUp("left");
											AutoItX.AU3_Sleep(500);
										}
										for (int num26 = 0; num26 < 3; num26++)
										{
											AutoItX.AU3_Send("{Enter down}", 0);
											AutoItX.AU3_Sleep(300);
											AutoItX.AU3_Send("{Enter up}", 0);											
											AutoItX.AU3_Sleep(100);
											AutoItX.AU3_Send("{SHIFTdown}", 0);
											AutoItX.AU3_Sleep(100);
											AutoItX.AU3_Send("{O down}", 0);
											AutoItX.AU3_Sleep(100);
											AutoItX.AU3_Send("{O up}", 0);
											AutoItX.AU3_Send("{U down}", 0);
											AutoItX.AU3_Sleep(100);
											AutoItX.AU3_Send("{U up}", 0);
											AutoItX.AU3_Send("{T down}", 0);
											AutoItX.AU3_Sleep(100);
											AutoItX.AU3_Send("{T up}", 0);
											AutoItX.AU3_Send("{SHIFTup}", 0);
											AutoItX.AU3_Send("{Enter down}", 0);
											AutoItX.AU3_Sleep(300);
											AutoItX.AU3_Send("{Enter up}", 0);
											AutoItX.AU3_Sleep(1500);
										}
									}
								}
								AutoItX.AU3_Sleep(1000);
							}
						}
					}
				}
				if (this.chkWigHead.Checked)
				{
					tasks += "เดินฟันหัวBH[วิก], ";
					string path9 = Path.Combine(Environment.GetEnvironmentVariable("TEMP") ?? "C:\\Temp", "png");
					string targetPath17 = Path.Combine(path9, "RUN160Red.png");
					string targetPath18 = Path.Combine(path9, "RUNRED000.png");
					using (Bitmap target32 = new Bitmap(targetPath17))
					{
						using (Bitmap target33 = new Bitmap(targetPath18))
						{
							Point foundAt32;
							Point foundAt33;
							if (ImageSearchHelper.FindImageWithDll(this.latestScreen, target32, 20, out foundAt32) && ImageSearchHelper.FindImageWithDll(this.latestScreen, target33, 20, out foundAt33))
							{
								if (!this.runActionSlasHead)
								{
									this.runActionSlasHead = true;
									AutoItX.AU3_MouseUp("left");
									AutoItX.AU3_Send("{CTRLUP}", 0);
									AutoItX.AU3_Send("{ALTUP}", 0);
									AutoItX.AU3_Sleep(1500);
									AutoItX.AU3_Send("{4 down}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{4 up}", 0);
									AutoItX.AU3_Send("{A down}", 0);
									AutoItX.AU3_Sleep(1500);
									AutoItX.AU3_Send("{A up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Send("{A down}", 0);
									AutoItX.AU3_Sleep(1300);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{A up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Send("{D down}", 0);
									AutoItX.AU3_Sleep(1300);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{D up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Sleep(1000);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Send("{D down}", 0);
									AutoItX.AU3_Sleep(850);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{D up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Sleep(2000);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{A down}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{A up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Sleep(2200);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Send("{A down}", 0);
									AutoItX.AU3_Sleep(700);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{A up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Sleep(1300);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{A down}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{A up}", 0);
									AutoItX.AU3_Send("{S down}", 0);
									AutoItX.AU3_Sleep(800);
									AutoItX.AU3_Send("{S up}", 0);
									AutoItX.AU3_Send("{4 down}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{4 up}", 0);
									AutoItX.AU3_Send("{CTRLDOWN}", 0);
									AutoItX.AU3_Sleep(150);
									AutoItX.AU3_MouseDown("left");
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_MouseUp("left");
									AutoItX.AU3_Send("{CTRLUP}", 0);
									AutoItX.AU3_Sleep(4000);
									if (Checkkill0Red.exit())
									{
										Console.WriteLine("stop kill action");
										AutoItX.AU3_Send("{Esc DOWN}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{Esc UP}", 0);
										AutoItX.AU3_Send("{Enter DOWN}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{Enter UP}", 0);
										AutoItX.AU3_Send("{Enter DOWN}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{Enter UP}", 0);
										AutoItX.AU3_MouseMove(10, 10, 10);
									}
									else
									{
										Console.WriteLine("start kill action");
										AutoItX.AU3_Send("{3 down}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{3 up}", 0);
										AutoItX.AU3_Send("{W down}", 0);
										AutoItX.AU3_Sleep(3000);
										AutoItX.AU3_Send("{W up}", 0);
										AutoItX.AU3_Send("{S down}", 0);
										AutoItX.AU3_Sleep(150);
										AutoItX.AU3_Send("{S up}", 0);
										AutoItX.AU3_Send("{A down}", 0);
										AutoItX.AU3_Sleep(1500);
										AutoItX.AU3_Send("{A up}", 0);
										AutoItX.AU3_Send("{S down}", 0);
										AutoItX.AU3_Send("{A down}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{S up}", 0);
										AutoItX.AU3_Send("{A up}", 0);
										MouseWinApi.MoveRelative(0, -200);
										for (int i26 = 0; i26 < 95; i26++)
										{
											AutoItX.AU3_MouseDown("left");
											AutoItX.AU3_Sleep(2000);
											MouseWinApi.MoveRelative(1800, 100);
											AutoItX.AU3_MouseDown("left");
											AutoItX.AU3_Sleep(1000);
											MouseWinApi.MoveRelative(-1800, -100);
										}
										AutoItX.AU3_MouseMove(10, 10, 10);
										AutoItX.AU3_MouseUp("left");
										AutoItX.AU3_Sleep(15000);
										AutoItX.AU3_MouseClick("left", 190, 410, 1, 0);
										AutoItX.AU3_Sleep(500);
										AutoItX.AU3_MouseClick("left", 10, 10, 1, 0);
										AutoItX.AU3_Sleep(500);
										AutoItX.AU3_MouseMove(10, 10, 10);
									}
								}
								else
								{
									this.runActionSlasHead = false;
								}
							}
						}
					}
				}
				if (this.chkWigBody.Checked)
				{
					tasks += "เดินฟันตัวBH[วิก], ";
					string path10 = Path.Combine(Environment.GetEnvironmentVariable("TEMP") ?? "C:\\Temp", "png");
					string targetPath19 = Path.Combine(path10, "RUN160Red.png");
					string targetPath20 = Path.Combine(path10, "RUNRED000.png");
					using (Bitmap target34 = new Bitmap(targetPath19))
					{
						using (Bitmap target35 = new Bitmap(targetPath20))
						{
							Point foundAt34;
							Point foundAt35;
							if (ImageSearchHelper.FindImageWithDll(this.latestScreen, target34, 20, out foundAt34) && ImageSearchHelper.FindImageWithDll(this.latestScreen, target35, 20, out foundAt35))
							{
								if (!this.runActionSlasHead)
								{
									this.runActionSlasHead = true;
									AutoItX.AU3_MouseUp("left");
									AutoItX.AU3_Send("{CTRLUP}", 0);
									AutoItX.AU3_Send("{ALTUP}", 0);
									AutoItX.AU3_Sleep(1500);
									AutoItX.AU3_Send("{4 down}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{4 up}", 0);
									AutoItX.AU3_Send("{A down}", 0);
									AutoItX.AU3_Sleep(1500);
									AutoItX.AU3_Send("{A up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Send("{A down}", 0);
									AutoItX.AU3_Sleep(1300);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{A up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Send("{D down}", 0);
									AutoItX.AU3_Sleep(1300);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{D up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Sleep(1000);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Send("{D down}", 0);
									AutoItX.AU3_Sleep(850);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{D up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Sleep(2000);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{A down}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{A up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Sleep(2200);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Send("{A down}", 0);
									AutoItX.AU3_Sleep(700);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{A up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Sleep(1300);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{A down}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{A up}", 0);
									AutoItX.AU3_Send("{S down}", 0);
									AutoItX.AU3_Sleep(800);
									AutoItX.AU3_Send("{S up}", 0);
									AutoItX.AU3_Send("{4 down}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{4 up}", 0);
									AutoItX.AU3_Send("{CTRLDOWN}", 0);
									AutoItX.AU3_Sleep(150);
									AutoItX.AU3_MouseDown("left");
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_MouseUp("left");
									AutoItX.AU3_Send("{CTRLUP}", 0);
									AutoItX.AU3_Sleep(4000);
									if (Checkkill0Red.exit())
									{
										Console.WriteLine("stop kill action");
										AutoItX.AU3_Send("{Esc DOWN}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{Esc UP}", 0);
										AutoItX.AU3_Send("{Enter DOWN}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{Enter UP}", 0);
										AutoItX.AU3_Send("{Enter DOWN}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{Enter UP}", 0);
										AutoItX.AU3_MouseMove(10, 10, 10);
									}
									else
									{
										Console.WriteLine("start kill action");
										AutoItX.AU3_Send("{3 down}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{3 up}", 0);
										AutoItX.AU3_Send("{W down}", 0);
										AutoItX.AU3_Sleep(3000);
										AutoItX.AU3_Send("{W up}", 0);
										AutoItX.AU3_Send("{S down}", 0);
										AutoItX.AU3_Sleep(150);
										AutoItX.AU3_Send("{S up}", 0);
										AutoItX.AU3_Send("{A down}", 0);
										AutoItX.AU3_Sleep(1500);
										AutoItX.AU3_Send("{A up}", 0);
										AutoItX.AU3_Send("{S down}", 0);
										AutoItX.AU3_Send("{A down}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{S up}", 0);
										AutoItX.AU3_Send("{A up}", 0);
										MouseWinApi.MoveRelative(0, 600);
										for (int i27 = 0; i27 < 95; i27++)
										{
											AutoItX.AU3_MouseDown("left");
											AutoItX.AU3_Sleep(2000);
											MouseWinApi.MoveRelative(1800, -100);
											AutoItX.AU3_MouseDown("left");
											AutoItX.AU3_Sleep(1000);
											MouseWinApi.MoveRelative(-1800, 100);
										}
										AutoItX.AU3_MouseMove(10, 10, 10);
										AutoItX.AU3_MouseUp("left");
										AutoItX.AU3_Sleep(15000);
										AutoItX.AU3_MouseClick("left", 190, 410, 1, 0);
										AutoItX.AU3_Sleep(500);
										AutoItX.AU3_MouseClick("left", 10, 10, 1, 0);
										AutoItX.AU3_Sleep(500);
										AutoItX.AU3_MouseMove(10, 10, 10);
									}
								}
								else
								{
									this.runActionSlasHead = false;
								}
							}
						}
					}
				}
				if (this.chkExpClan.Checked)
				{
					tasks += "ปั้มเวลแคลน, ";
					using (Bitmap target36 = new Bitmap(Path.Combine(Path.Combine(Environment.GetEnvironmentVariable("TEMP") ?? "C:\\Temp", "png"), "Time250.png")))
					{
						Point foundAt36;
						if (ImageSearchHelper.FindImageWithDll(this.latestScreen, target36, 20, out foundAt36) && Time250.exit())
						{
							AutoItX.AU3_MouseUp("left");
							AutoItX.AU3_Send("{CTRLUP}", 0);
							AutoItX.AU3_Send("{ALTUP}", 0);
							AutoItX.AU3_Sleep(500);
							AutoItX.AU3_Send("{4 down}", 0);
							AutoItX.AU3_Sleep(300);
							AutoItX.AU3_Send("{4 up}", 0);
							AutoItX.AU3_Send("{A down}", 0);
							AutoItX.AU3_Send("{S down}", 0);
							AutoItX.AU3_Sleep(1300);
							AutoItX.AU3_Send("{A up}", 0);
							AutoItX.AU3_Send("{S up}", 0);
							AutoItX.AU3_Send("{D down}", 0);
							AutoItX.AU3_Sleep(450);
							AutoItX.AU3_Send("{D up}", 0);
							AutoItX.AU3_Send("{W down}", 0);
							AutoItX.AU3_Sleep(2500);
							AutoItX.AU3_Send("{A down}", 0);
							AutoItX.AU3_Sleep(3000);
							AutoItX.AU3_Send("{A up}", 0);
							AutoItX.AU3_Send("{D down}", 0);
							AutoItX.AU3_Sleep(500);
							AutoItX.AU3_Send("{D up}", 0);
							AutoItX.AU3_Sleep(4500);
							AutoItX.AU3_MouseDown("left");
							AutoItX.AU3_Sleep(300);
							AutoItX.AU3_Send("{D down}", 0);
							AutoItX.AU3_Sleep(1000);
							AutoItX.AU3_Send("{D up}", 0);
							AutoItX.AU3_Sleep(500);
							AutoItX.AU3_Send("{D down}", 0);
							AutoItX.AU3_Sleep(1300);
							AutoItX.AU3_Send("{D up}", 0);
							AutoItX.AU3_Send("{W up}", 0);
							MouseWinApi.MoveRelative(-1650, 0);
							AutoItX.AU3_MouseUp("left");
							AutoItX.AU3_Send("{1 down}", 0);
							AutoItX.AU3_Sleep(150);
							AutoItX.AU3_Send("{1 up}", 0);
							AutoItX.AU3_Sleep(2000);
							for (int num29 = 0; num29 < 6; num29++)
							{
								AutoItX.AU3_Sleep(467);
								AutoItX.AU3_MouseDown("right");
								AutoItX.AU3_Sleep(112);
								AutoItX.AU3_MouseUp("right");
								AutoItX.AU3_Sleep(231);
								AutoItX.AU3_MouseDown("left");
								AutoItX.AU3_Sleep(89);
								AutoItX.AU3_MouseUp("left");
								AutoItX.AU3_Sleep(145);
								AutoItX.AU3_MouseDown("left");
								AutoItX.AU3_Sleep(101);
								AutoItX.AU3_MouseUp("left");
							}
						}
					}
				}
				if (this.chkWaterPark.Checked)
				{
					tasks += "เดินฟันWaterPark[R], ";
					string path11 = Path.Combine(Environment.GetEnvironmentVariable("TEMP") ?? "C:\\Temp", "png");
					string targetPath21 = Path.Combine(path11, "RUN160Red.png");
					string targetPath22 = Path.Combine(path11, "RUNRED000.png");
					using (Bitmap target37 = new Bitmap(targetPath21))
					{
						using (Bitmap target38 = new Bitmap(targetPath22))
						{
							Point foundAt37;
							Point foundAt38;
							if (ImageSearchHelper.FindImageWithDll(this.latestScreen, target37, 20, out foundAt37) && ImageSearchHelper.FindImageWithDll(this.latestScreen, target38, 20, out foundAt38))
							{
								if (!this.runActionSlasHead)
								{
									this.runActionSlasHead = true;
									AutoItX.AU3_MouseUp("left");
									AutoItX.AU3_Send("{CTRLUP}", 0);
									AutoItX.AU3_Send("{ALTUP}", 0);
									AutoItX.AU3_Sleep(1500);
									AutoItX.AU3_Send("{4 down}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{4 up}", 0);
									AutoItX.AU3_Send("{D down}", 0);
									AutoItX.AU3_Sleep(2000);
									AutoItX.AU3_Send("{D up}", 0);
									AutoItX.AU3_Send("{S down}", 0);
									AutoItX.AU3_Send("{D down}", 0);
									AutoItX.AU3_Sleep(1300);
									AutoItX.AU3_Send("{S up}", 0);
									AutoItX.AU3_Send("{D up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Sleep(1500);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{D down}", 0);
									AutoItX.AU3_Sleep(770);
									AutoItX.AU3_Send("{D up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Sleep(2500);
									AutoItX.AU3_Send("{A down}", 0);
									AutoItX.AU3_Sleep(350);
									AutoItX.AU3_Send("{A up}", 0);
									AutoItX.AU3_Sleep(2000);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{D down}", 0);
									AutoItX.AU3_Sleep(650);
									AutoItX.AU3_Send("{D up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Sleep(600);
									AutoItX.AU3_Send("{SPACE down}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{SPACE Up}", 0);
									AutoItX.AU3_Sleep(5200);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{A down}", 0);
									AutoItX.AU3_Sleep(3000);
									AutoItX.AU3_Send("{A up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Sleep(1000);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{4 down}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{4 up}", 0);
									AutoItX.AU3_Send("{CTRLDOWN}", 0);
									AutoItX.AU3_Sleep(150);
									AutoItX.AU3_MouseDown("left");
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_MouseUp("left");
									AutoItX.AU3_Send("{CTRLUP}", 0);
									AutoItX.AU3_Sleep(4000);
									if (Checkkill0Red.exit())
									{
										Console.WriteLine("stop kill action");
										AutoItX.AU3_Send("{Esc DOWN}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{Esc UP}", 0);
										AutoItX.AU3_Send("{Enter DOWN}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{Enter UP}", 0);
										AutoItX.AU3_Send("{Enter DOWN}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{Enter UP}", 0);
										AutoItX.AU3_MouseMove(10, 10, 10);
									}
									else
									{
										Console.WriteLine("start kill action");
										AutoItX.AU3_Send("{3 down}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{3 up}", 0);
										AutoItX.AU3_Send("{W down}", 0);
										AutoItX.AU3_Sleep(2500);
										AutoItX.AU3_Send("{W up}", 0);
										AutoItX.AU3_Send("{A down}", 0);
										AutoItX.AU3_Sleep(500);
										AutoItX.AU3_Send("{S down}", 0);
										AutoItX.AU3_Sleep(1000);
										AutoItX.AU3_Send("{A up}", 0);
										AutoItX.AU3_Send("{S up}", 0);
										MouseWinApi.MoveRelative(2200, -200);
										for (int i29 = 0; i29 < 92; i29++)
										{
											AutoItX.AU3_MouseDown("left");
											AutoItX.AU3_Sleep(2000);
											MouseWinApi.MoveRelative(2200, 100);
											AutoItX.AU3_MouseDown("left");
											AutoItX.AU3_Sleep(1000);
											MouseWinApi.MoveRelative(-2200, -100);
										}
										AutoItX.AU3_Sleep(2000);
										AutoItX.AU3_MouseUp("left");
										AutoItX.AU3_MouseMove(10, 10, 10);
									}
								}
								else
								{
									this.runActionSlasHead = false;
								}
							}
						}
					}
				}
				if (this.chkTower11.Checked)
				{
					tasks += "เดินฟันTower11[B], ";
					string path12 = Path.Combine(Environment.GetEnvironmentVariable("TEMP") ?? "C:\\Temp", "png");
					string targetPath23 = Path.Combine(path12, "RUN160Blue.png");
					string targetPath24 = Path.Combine(path12, "RUNBLUE000.png");
					using (Bitmap target39 = new Bitmap(targetPath23))
					{
						using (Bitmap target40 = new Bitmap(targetPath24))
						{
							Point foundAt39;
							Point foundAt40;
							if (ImageSearchHelper.FindImageWithDll(this.latestScreen, target39, 20, out foundAt39) && ImageSearchHelper.FindImageWithDll(this.latestScreen, target40, 20, out foundAt40))
							{
								if (!this.runActionSlasHead)
								{
									this.runActionSlasHead = true;
									AutoItX.AU3_MouseUp("left");
									AutoItX.AU3_Send("{CTRLUP}", 0);
									AutoItX.AU3_Send("{ALTUP}", 0);
									AutoItX.AU3_Sleep(1500);
									AutoItX.AU3_Send("{4 down}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{4 up}", 0);
									AutoItX.AU3_Send("{D down}", 0);
									AutoItX.AU3_Sleep(3000);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Sleep(3000);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{D up}", 0);
									AutoItX.AU3_Send("{A down}", 0);
									AutoItX.AU3_Sleep(800);
									AutoItX.AU3_Send("{A up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{SPACE down}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{SPACE Up}", 0);
									AutoItX.AU3_Sleep(12000);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{D down}", 0);
									AutoItX.AU3_Sleep(200);
									AutoItX.AU3_Send("{D up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{SPACE down}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{SPACE Up}", 0);
									AutoItX.AU3_Sleep(1000);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{A down}", 0);
									AutoItX.AU3_Sleep(1200);
									AutoItX.AU3_Send("{A up}", 0);
									AutoItX.AU3_Send("{CTRLDOWN}", 0);
									AutoItX.AU3_Sleep(150);
									AutoItX.AU3_MouseDown("left");
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_MouseUp("left");
									AutoItX.AU3_Send("{CTRLUP}", 0);
									AutoItX.AU3_Sleep(4000);
									if (Checkkill0Blue.exit())
									{
										Console.WriteLine("stop kill action");
										AutoItX.AU3_Send("{Esc DOWN}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{Esc UP}", 0);
										AutoItX.AU3_Send("{Enter DOWN}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{Enter UP}", 0);
										AutoItX.AU3_Send("{Enter DOWN}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{Enter UP}", 0);
										AutoItX.AU3_MouseMove(10, 10, 10);
									}
									else
									{
										Console.WriteLine("start kill action");
										AutoItX.AU3_Send("{3 down}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{3 up}", 0);
										AutoItX.AU3_Send("{W down}", 0);
										AutoItX.AU3_Sleep(1500);
										AutoItX.AU3_Send("{W up}", 0);
										AutoItX.AU3_Send("{W down}", 0);
										AutoItX.AU3_Send("{D down}", 0);
										AutoItX.AU3_Sleep(1500);
										AutoItX.AU3_Send("{D up}", 0);
										AutoItX.AU3_Send("{W up}", 0);
										AutoItX.AU3_Send("{F down}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{F up}", 0);
										MouseWinApi.MoveRelative(2700, -300);
										for (int i30 = 0; i30 < 92; i30++)
										{
											AutoItX.AU3_MouseDown("left");
											AutoItX.AU3_Sleep(2000);
											MouseWinApi.MoveRelative(-2700, 100);
											AutoItX.AU3_MouseDown("left");
											AutoItX.AU3_Sleep(1000);
											MouseWinApi.MoveRelative(2700, -100);
										}
										AutoItX.AU3_Sleep(2000);
										AutoItX.AU3_MouseUp("left");
										AutoItX.AU3_MouseMove(10, 10, 10);
									}
								}
								else
								{
									this.runActionSlasHead = false;
								}
							}
						}
					}
				}
				if (this.chkMetro.Checked)
				{
					tasks += "เดินฟันWaterPark[R], ";
					string path13 = Path.Combine(Environment.GetEnvironmentVariable("TEMP") ?? "C:\\Temp", "png");
					string targetPath25 = Path.Combine(path13, "RUN160Red.png");
					string targetPath26 = Path.Combine(path13, "RUNRED000.png");
					using (Bitmap target41 = new Bitmap(targetPath25))
					{
						using (Bitmap target42 = new Bitmap(targetPath26))
						{
							Point foundAt41;
							Point foundAt42;
							if (ImageSearchHelper.FindImageWithDll(this.latestScreen, target41, 20, out foundAt41) && ImageSearchHelper.FindImageWithDll(this.latestScreen, target42, 20, out foundAt42))
							{
								if (!this.runActionSlasHead)
								{
									this.runActionSlasHead = true;
									AutoItX.AU3_MouseUp("left");
									AutoItX.AU3_Send("{CTRLUP}", 0);
									AutoItX.AU3_Send("{ALTUP}", 0);
									AutoItX.AU3_Sleep(1500);
									AutoItX.AU3_Send("{4 down}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{4 up}", 0);
									AutoItX.AU3_Send("{A down}", 0);
									AutoItX.AU3_Sleep(2000);
									AutoItX.AU3_Send("{A up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Sleep(2000);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{D down}", 0);
									AutoItX.AU3_Sleep(500);
									AutoItX.AU3_Send("{D up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Sleep(2000);
									AutoItX.AU3_Send("{A down}", 0);
									AutoItX.AU3_Sleep(5200);
									AutoItX.AU3_Send("{A up}", 0);
									AutoItX.AU3_Sleep(10000);
									AutoItX.AU3_Send("{D down}", 0);
									AutoItX.AU3_Sleep(1700);
									AutoItX.AU3_Send("{D up}", 0);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{4 down}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{4 up}", 0);
									AutoItX.AU3_Send("{CTRLDOWN}", 0);
									AutoItX.AU3_Sleep(150);
									AutoItX.AU3_MouseDown("left");
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_MouseUp("left");
									AutoItX.AU3_Send("{CTRLUP}", 0);
									AutoItX.AU3_Sleep(4000);
									if (Checkkill0Red.exit())
									{
										Console.WriteLine("stop kill action");
										AutoItX.AU3_Send("{Esc DOWN}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{Esc UP}", 0);
										AutoItX.AU3_Send("{Enter DOWN}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{Enter UP}", 0);
										AutoItX.AU3_Send("{Enter DOWN}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{Enter UP}", 0);
										AutoItX.AU3_MouseMove(10, 10, 10);
									}
									else
									{
										Console.WriteLine("start kill action");
										AutoItX.AU3_Send("{3 down}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{3 up}", 0);
										AutoItX.AU3_Send("{W down}", 0);
										AutoItX.AU3_Send("{A down}", 0);
										AutoItX.AU3_Sleep(2000);
										AutoItX.AU3_Send("{A up}", 0);
										AutoItX.AU3_Send("{W up}", 0);
										MouseWinApi.MoveRelative(3500, -200);
										for (int i31 = 0; i31 < 92; i31++)
										{
											AutoItX.AU3_MouseDown("left");
											AutoItX.AU3_Sleep(2000);
											MouseWinApi.MoveRelative(2900, 100);
											AutoItX.AU3_MouseDown("left");
											AutoItX.AU3_Sleep(1000);
											MouseWinApi.MoveRelative(-2900, -100);
										}
										AutoItX.AU3_Sleep(2000);
										AutoItX.AU3_MouseUp("left");
										AutoItX.AU3_MouseMove(10, 10, 10);
									}
								}
								else
								{
									this.runActionSlasHead = false;
								}
							}
						}
					}
				}
				if (this.chkFatalZone.Checked)
				{
					tasks += "เดินฟันFatalZone[B], ";
					string path14 = Path.Combine(Environment.GetEnvironmentVariable("TEMP") ?? "C:\\Temp", "png");
					string targetPath27 = Path.Combine(path14, "RUN160Blue.png");
					string targetPath28 = Path.Combine(path14, "RUNBLUE000.png");
					using (Bitmap target43 = new Bitmap(targetPath27))
					{
						using (Bitmap target44 = new Bitmap(targetPath28))
						{
							Point foundAt43;
							Point foundAt44;
							if (ImageSearchHelper.FindImageWithDll(this.latestScreen, target43, 20, out foundAt43) && ImageSearchHelper.FindImageWithDll(this.latestScreen, target44, 20, out foundAt44))
							{
								if (!this.runActionSlasHead)
								{
									this.runActionSlasHead = true;
									AutoItX.AU3_MouseUp("left");
									AutoItX.AU3_Send("{CTRLUP}", 0);
									AutoItX.AU3_Send("{ALTUP}", 0);
									AutoItX.AU3_Sleep(1500);
									AutoItX.AU3_Send("{4 down}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{4 up}", 0);
									AutoItX.AU3_Send("{A down}", 0);
									AutoItX.AU3_Sleep(2000);
									AutoItX.AU3_Send("{A up}", 0);
									AutoItX.AU3_Send("{D down}", 0);
									AutoItX.AU3_Sleep(150);
									AutoItX.AU3_Send("{D up}", 0);
									AutoItX.AU3_Send("{S down}", 0);
									AutoItX.AU3_Sleep(500);
									AutoItX.AU3_Send("{S up}", 0);
									AutoItX.AU3_Send("{S down}", 0);
									AutoItX.AU3_Send("{A down}", 0);
									AutoItX.AU3_Sleep(800);
									AutoItX.AU3_Send("{S up}", 0);
									AutoItX.AU3_Send("{A up}", 0);
									AutoItX.AU3_Send("{D down}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{D up}", 0);
									AutoItX.AU3_Sleep(1500);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{A down}", 0);
									AutoItX.AU3_Sleep(700);
									AutoItX.AU3_Send("{A up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Sleep(3000);
									AutoItX.AU3_Send("{D down}", 0);
									AutoItX.AU3_Sleep(500);
									AutoItX.AU3_Send("{D up}", 0);
									AutoItX.AU3_Sleep(5000);
									AutoItX.AU3_Send("{A down}", 0);
									AutoItX.AU3_Sleep(1000);
									AutoItX.AU3_Send("{A up}", 0);
									AutoItX.AU3_Sleep(1300);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{D down}", 0);
									AutoItX.AU3_Sleep(870);
									AutoItX.AU3_Send("{D up}", 0);
									AutoItX.AU3_Send("{4 down}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{4 up}", 0);
									AutoItX.AU3_Send("{CTRLDOWN}", 0);
									AutoItX.AU3_Sleep(150);
									AutoItX.AU3_MouseDown("left");
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_MouseUp("left");
									AutoItX.AU3_Send("{CTRLUP}", 0);
									AutoItX.AU3_Sleep(4000);
									if (Checkkill0Blue.exit())
									{
										Console.WriteLine("stop kill action");
										AutoItX.AU3_Send("{Esc DOWN}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{Esc UP}", 0);
										AutoItX.AU3_Send("{Enter DOWN}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{Enter UP}", 0);
										AutoItX.AU3_Send("{Enter DOWN}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{Enter UP}", 0);
										AutoItX.AU3_MouseMove(10, 10, 10);
									}
									else
									{
										Console.WriteLine("start kill action");
										AutoItX.AU3_Send("{3 down}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{3 up}", 0);
										AutoItX.AU3_Send("{W down}", 0);
										AutoItX.AU3_Sleep(2000);
										AutoItX.AU3_Send("{W up}", 0);
										AutoItX.AU3_Send("{A down}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{A up}", 0);
										AutoItX.AU3_Send("{W down}", 0);
										AutoItX.AU3_Send("{D down}", 0);
										AutoItX.AU3_Sleep(500);
										AutoItX.AU3_Send("{D up}", 0);
										AutoItX.AU3_Send("{W up}", 0);
										AutoItX.AU3_Send("{F down}", 0);
										AutoItX.AU3_Sleep(150);
										AutoItX.AU3_Send("{F up}", 0);
										MouseWinApi.MoveRelative(1800, -200);
										for (int i32 = 0; i32 < 92; i32++)
										{
											AutoItX.AU3_MouseDown("left");
											AutoItX.AU3_Sleep(2000);
											MouseWinApi.MoveRelative(-1600, 0);
											AutoItX.AU3_MouseDown("left");
											AutoItX.AU3_Sleep(1000);
											MouseWinApi.MoveRelative(1600, 0);
										}
										AutoItX.AU3_Sleep(2000);
										AutoItX.AU3_MouseUp("left");
										AutoItX.AU3_MouseMove(10, 10, 10);
									}
								}
								else
								{
									this.runActionSlasHead = false;
								}
							}
						}
					}
				}
				if (this.chkFalluCity.Checked)
				{
					tasks += "ปั้มบัพFalluCity[R], ";
					using (Bitmap target45 = new Bitmap(Path.Combine(Path.Combine(Environment.GetEnvironmentVariable("TEMP") ?? "C:\\Temp", "png"), "Win0Red.png")))
					{
						Point foundAt45;
						if (ImageSearchHelper.FindImageWithDll(this.latestScreen, target45, 20, out foundAt45))
						{
							if (CheckWin0.exit())
							{
								AutoItX.AU3_MouseUp("left");
								AutoItX.AU3_Send("{CTRLUP}", 0);
								AutoItX.AU3_Send("{ALTUP}", 0);
								AutoItX.AU3_Sleep(1000);
								AutoItX.AU3_Send("{4 down}", 0);
								AutoItX.AU3_Sleep(300);
								AutoItX.AU3_Send("{4 up}", 0);
								AutoItX.AU3_Send("{F down}", 0);
								AutoItX.AU3_Sleep(300);
								AutoItX.AU3_Send("{F up}", 0);
								AutoItX.AU3_Sleep(1500);
								AutoItX.AU3_MouseDown("left");
								AutoItX.AU3_Sleep(150);
								AutoItX.AU3_MouseUp("left");
								AutoItX.AU3_Sleep(13000);
							}
							if (CheckWin1.exit())
							{
								AutoItX.AU3_MouseUp("left");
								AutoItX.AU3_Send("{CTRLUP}", 0);
								AutoItX.AU3_Send("{ALTUP}", 0);
								AutoItX.AU3_Sleep(1000);
								AutoItX.AU3_Send("{4 down}", 0);
								AutoItX.AU3_Sleep(300);
								AutoItX.AU3_Send("{4 up}", 0);
								AutoItX.AU3_Send("{F down}", 0);
								AutoItX.AU3_Sleep(300);
								AutoItX.AU3_Send("{F up}", 0);
								AutoItX.AU3_Sleep(1500);
								AutoItX.AU3_MouseDown("left");
								AutoItX.AU3_Sleep(150);
								AutoItX.AU3_MouseUp("left");
								AutoItX.AU3_Sleep(13000);
							}
							if (CheckWin2.exit())
							{
								AutoItX.AU3_MouseUp("left");
								AutoItX.AU3_Send("{CTRLUP}", 0);
								AutoItX.AU3_Send("{ALTUP}", 0);
								AutoItX.AU3_Sleep(500);
								AutoItX.AU3_Send("{4 down}", 0);
								AutoItX.AU3_Sleep(300);
								AutoItX.AU3_Send("{4 up}", 0);
								AutoItX.AU3_Send("{A down}", 0);
								AutoItX.AU3_Send("{S down}", 0);
								AutoItX.AU3_Sleep(1300);
								AutoItX.AU3_Send("{A up}", 0);
								AutoItX.AU3_Send("{S up}", 0);
								AutoItX.AU3_Send("{W down}", 0);
								AutoItX.AU3_Send("{D down}", 0);
								AutoItX.AU3_Sleep(4000);
								AutoItX.AU3_Send("{D up}", 0);
								AutoItX.AU3_Sleep(5000);
								AutoItX.AU3_Send("{D down}", 0);
								AutoItX.AU3_Sleep(700);
								AutoItX.AU3_Send("{D up}", 0);
								AutoItX.AU3_Sleep(3200);
								AutoItX.AU3_Send("{W up}", 0);
								AutoItX.AU3_MouseDown("left");
								AutoItX.AU3_Send("{W down}", 0);
								AutoItX.AU3_Send("{D down}", 0);
								AutoItX.AU3_Sleep(2500);
								AutoItX.AU3_Send("{D up}", 0);
								AutoItX.AU3_Sleep(2000);
								AutoItX.AU3_Send("{W up}", 0);
								MouseWinApi.MoveRelative(0, 2200);
								AutoItX.AU3_MouseUp("left");
								AutoItX.AU3_Sleep(5000);
								if (CheckWin3.exit())
								{
									AutoItX.AU3_MouseUp("left");
									AutoItX.AU3_Send("{CTRLUP}", 0);
									AutoItX.AU3_Send("{ALTUP}", 0);
									AutoItX.AU3_Send("{Esc DOWN}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{Esc UP}", 0);
									AutoItX.AU3_Send("{Enter DOWN}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{Enter UP}", 0);
									AutoItX.AU3_Send("{Enter DOWN}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{Enter UP}", 0);
								}
							}
						}
					}
				}
				if (this.chkMarineWave.Checked)
				{
					tasks += "ปั้มบัพMarineWave[R], ";
					using (Bitmap target46 = new Bitmap(Path.Combine(Path.Combine(Environment.GetEnvironmentVariable("TEMP") ?? "C:\\Temp", "png"), "Win0Red.png")))
					{
						Point foundAt46;
						if (ImageSearchHelper.FindImageWithDll(this.latestScreen, target46, 20, out foundAt46))
						{
							if (CheckWin0.exit())
							{
								AutoItX.AU3_MouseUp("left");
								AutoItX.AU3_Send("{CTRLUP}", 0);
								AutoItX.AU3_Send("{ALTUP}", 0);
								AutoItX.AU3_Sleep(1000);
								AutoItX.AU3_Send("{4 down}", 0);
								AutoItX.AU3_Sleep(300);
								AutoItX.AU3_Send("{4 up}", 0);
								MouseWinApi.MoveRelative(0, 2500);
								AutoItX.AU3_Sleep(1500);
								AutoItX.AU3_MouseDown("left");
								AutoItX.AU3_Sleep(150);
								AutoItX.AU3_MouseUp("left");
								AutoItX.AU3_Sleep(13000);
							}
							if (CheckWin1.exit())
							{
								AutoItX.AU3_MouseUp("left");
								AutoItX.AU3_Send("{CTRLUP}", 0);
								AutoItX.AU3_Send("{ALTUP}", 0);
								AutoItX.AU3_Sleep(1000);
								AutoItX.AU3_Send("{4 down}", 0);
								AutoItX.AU3_Sleep(300);
								AutoItX.AU3_Send("{4 up}", 0);
								MouseWinApi.MoveRelative(0, 2500);
								AutoItX.AU3_Sleep(1500);
								AutoItX.AU3_MouseDown("left");
								AutoItX.AU3_Sleep(150);
								AutoItX.AU3_MouseUp("left");
								AutoItX.AU3_Sleep(13000);
							}
							if (CheckWin2.exit())
							{
								AutoItX.AU3_MouseUp("left");
								AutoItX.AU3_Send("{CTRLUP}", 0);
								AutoItX.AU3_Send("{ALTUP}", 0);
								AutoItX.AU3_Sleep(1500);
								AutoItX.AU3_Send("{4 down}", 0);
								AutoItX.AU3_Sleep(150);
								AutoItX.AU3_Send("{4 up}", 0);
								AutoItX.AU3_Send("{W down}", 0);
								AutoItX.AU3_Sleep(1800);
								AutoItX.AU3_Send("{W up}", 0);
								AutoItX.AU3_Send("{D down}", 0);
								AutoItX.AU3_Sleep(1300);
								AutoItX.AU3_Send("{D up}", 0);
								AutoItX.AU3_Send("{W down}", 0);
								AutoItX.AU3_Sleep(2400);
								AutoItX.AU3_Send("{W up}", 0);
								AutoItX.AU3_Send("{A down}", 0);
								AutoItX.AU3_Send("{W down}", 0);
								AutoItX.AU3_Sleep(1600);
								AutoItX.AU3_Send("{A up}", 0);
								AutoItX.AU3_Sleep(2000);
								AutoItX.AU3_Send("{W up}", 0);
								AutoItX.AU3_Send("{D down}", 0);
								AutoItX.AU3_Sleep(150);
								AutoItX.AU3_Send("{D up}", 0);
								AutoItX.AU3_Send("{W down}", 0);
								AutoItX.AU3_Sleep(800);
								AutoItX.AU3_Send("{W up}", 0);
								AutoItX.AU3_Send("{A down}", 0);
								AutoItX.AU3_Sleep(1500);
								AutoItX.AU3_Send("{A up}", 0);
								AutoItX.AU3_Send("{W down}", 0);
								AutoItX.AU3_Sleep(3000);
								AutoItX.AU3_Send("{W up}", 0);
								AutoItX.AU3_Send("{D down}", 0);
								AutoItX.AU3_Sleep(500);
								AutoItX.AU3_Send("{D up}", 0);
								AutoItX.AU3_MouseDown("left");
								AutoItX.AU3_Send("{W down}", 0);
								AutoItX.AU3_Sleep(1500);
								AutoItX.AU3_Send("{W up}", 0);
								MouseWinApi.MoveRelative(0, 2200);
								AutoItX.AU3_MouseUp("left");
								AutoItX.AU3_Sleep(5000);
								if (CheckWin3.exit())
								{
									AutoItX.AU3_MouseUp("left");
									AutoItX.AU3_Send("{CTRLUP}", 0);
									AutoItX.AU3_Send("{ALTUP}", 0);
									AutoItX.AU3_Send("{Esc DOWN}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{Esc UP}", 0);
									AutoItX.AU3_Send("{Enter DOWN}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{Enter UP}", 0);
									AutoItX.AU3_Send("{Enter DOWN}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{Enter UP}", 0);
								}
							}
						}
					}
				}
				if (this.chkSlasHeadSpawn30.Checked)
				{
					tasks += "เดินฟันหัวBH[30%], ";
					string path15 = Path.Combine(Environment.GetEnvironmentVariable("TEMP") ?? "C:\\Temp", "png");
					string targetPath29 = Path.Combine(path15, "RUN160Red.png");
					string targetPath30 = Path.Combine(path15, "RUNRED000.png");
					using (Bitmap target47 = new Bitmap(targetPath29))
					{
						using (Bitmap target48 = new Bitmap(targetPath30))
						{
							Point foundAt47;
							Point foundAt48;
							if (ImageSearchHelper.FindImageWithDll(this.latestScreen, target47, 20, out foundAt47) && ImageSearchHelper.FindImageWithDll(this.latestScreen, target48, 20, out foundAt48))
							{
								if (!this.runActionSlasHead)
								{
									this.runActionSlasHead = true;
									AutoItX.AU3_MouseUp("left");
									AutoItX.AU3_Send("{CTRLUP}", 0);
									AutoItX.AU3_Send("{ALTUP}", 0);
									AutoItX.AU3_Sleep(1500);
									AutoItX.AU3_Send("{4 down}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{4 up}", 0);
									AutoItX.AU3_Send("{A down}", 0);
									AutoItX.AU3_Sleep(1500);
									AutoItX.AU3_Send("{A up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Send("{A down}", 0);
									AutoItX.AU3_Sleep(1500);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{A up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Send("{D down}", 0);
									AutoItX.AU3_Sleep(1500);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{D up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Sleep(1200);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Send("{D down}", 0);
									AutoItX.AU3_Sleep(850);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{D up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Sleep(2500);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{A down}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{A up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Sleep(2700);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Send("{A down}", 0);
									AutoItX.AU3_Sleep(1000);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{A up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Sleep(1300);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{A down}", 0);
									AutoItX.AU3_Sleep(400);
									AutoItX.AU3_Send("{A up}", 0);
									AutoItX.AU3_Send("{S down}", 0);
									AutoItX.AU3_Sleep(800);
									AutoItX.AU3_Send("{S up}", 0);
									AutoItX.AU3_Send("{4 down}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{4 up}", 0);
									AutoItX.AU3_Send("{CTRLDOWN}", 0);
									AutoItX.AU3_Sleep(150);
									AutoItX.AU3_MouseDown("left");
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_MouseUp("left");
									AutoItX.AU3_Send("{CTRLUP}", 0);
									AutoItX.AU3_Sleep(4000);
									if (Checkkill0Red.exit())
									{
										Console.WriteLine("stop kill action");
										AutoItX.AU3_Send("{Esc DOWN}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{Esc UP}", 0);
										AutoItX.AU3_Send("{Enter DOWN}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{Enter UP}", 0);
										AutoItX.AU3_Send("{Enter DOWN}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{Enter UP}", 0);
										AutoItX.AU3_MouseMove(10, 10, 10);
									}
									else
									{
										Console.WriteLine("start kill action");
										AutoItX.AU3_Send("{3 down}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{3 up}", 0);
										AutoItX.AU3_Send("{W down}", 0);
										AutoItX.AU3_Sleep(1000);
										AutoItX.AU3_Send("{A down}", 0);
										AutoItX.AU3_Sleep(1500);
										AutoItX.AU3_Send("{W up}", 0);
										AutoItX.AU3_Send("{A up}", 0);
										AutoItX.AU3_Send("{S down}", 0);
										AutoItX.AU3_Send("{A down}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{S up}", 0);
										AutoItX.AU3_Send("{A up}", 0);
										MouseWinApi.MoveRelative(0, -200);
										for (int i33 = 0; i33 < 85; i33++)
										{
											AutoItX.AU3_MouseDown("left");
											AutoItX.AU3_Sleep(2000);
											MouseWinApi.MoveRelative(1800, 100);
											AutoItX.AU3_MouseDown("left");
											AutoItX.AU3_Sleep(1000);
											MouseWinApi.MoveRelative(-1800, -100);
										}
										AutoItX.AU3_Sleep(2000);
										AutoItX.AU3_MouseUp("left");
										AutoItX.AU3_MouseMove(10, 10, 10);
									}
								}
								else
								{
									this.runActionSlasHead = false;
								}
							}
						}
					}
				}
				if (this.chkSlasBodySpawn30.Checked)
				{
					tasks += "เดินฟันตัวBH[30%], ";
					string path16 = Path.Combine(Environment.GetEnvironmentVariable("TEMP") ?? "C:\\Temp", "png");
					string targetPath31 = Path.Combine(path16, "RUN160Red.png");
					string targetPath32 = Path.Combine(path16, "RUNRED000.png");
					using (Bitmap target49 = new Bitmap(targetPath31))
					{
						using (Bitmap target50 = new Bitmap(targetPath32))
						{
							Point foundAt49;
							Point foundAt50;
							if (ImageSearchHelper.FindImageWithDll(this.latestScreen, target49, 20, out foundAt49) && ImageSearchHelper.FindImageWithDll(this.latestScreen, target50, 20, out foundAt50))
							{
								if (!this.runActionSlasBoy)
								{
									this.runActionSlasBoy = true;
									AutoItX.AU3_MouseUp("left");
									AutoItX.AU3_Send("{CTRLUP}", 0);
									AutoItX.AU3_Send("{ALTUP}", 0);
									AutoItX.AU3_Sleep(1500);
									AutoItX.AU3_Send("{4 down}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{4 up}", 0);
									AutoItX.AU3_Send("{A down}", 0);
									AutoItX.AU3_Sleep(1500);
									AutoItX.AU3_Send("{A up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Send("{A down}", 0);
									AutoItX.AU3_Sleep(1500);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{A up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Send("{D down}", 0);
									AutoItX.AU3_Sleep(1500);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{D up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Sleep(1200);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Send("{D down}", 0);
									AutoItX.AU3_Sleep(850);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{D up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Sleep(2500);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{A down}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{A up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Sleep(2700);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Send("{A down}", 0);
									AutoItX.AU3_Sleep(1000);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{A up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Sleep(1300);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{A down}", 0);
									AutoItX.AU3_Sleep(400);
									AutoItX.AU3_Send("{A up}", 0);
									AutoItX.AU3_Send("{S down}", 0);
									AutoItX.AU3_Sleep(800);
									AutoItX.AU3_Send("{S up}", 0);
									AutoItX.AU3_Send("{4 down}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{4 up}", 0);
									AutoItX.AU3_Send("{CTRLDOWN}", 0);
									AutoItX.AU3_Sleep(150);
									AutoItX.AU3_MouseDown("left");
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_MouseUp("left");
									AutoItX.AU3_Send("{CTRLUP}", 0);
									AutoItX.AU3_Sleep(4000);
									if (Checkkill0Red.exit())
									{
										Console.WriteLine("stop kill action");
										AutoItX.AU3_Send("{Esc DOWN}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{Esc UP}", 0);
										AutoItX.AU3_Send("{Enter DOWN}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{Enter UP}", 0);
										AutoItX.AU3_Send("{Enter DOWN}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{Enter UP}", 0);
										AutoItX.AU3_MouseMove(10, 10, 10);
									}
									else
									{
										Console.WriteLine("start kill action");
										AutoItX.AU3_Send("{3 down}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{3 up}", 0);
										AutoItX.AU3_Send("{W down}", 0);
										AutoItX.AU3_Sleep(1000);
										AutoItX.AU3_Send("{A down}", 0);
										AutoItX.AU3_Sleep(1500);
										AutoItX.AU3_Send("{W up}", 0);
										AutoItX.AU3_Send("{A up}", 0);
										AutoItX.AU3_Send("{S down}", 0);
										AutoItX.AU3_Send("{A down}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{S up}", 0);
										AutoItX.AU3_Send("{A up}", 0);
										MouseWinApi.MoveRelative(0, 600);
										for (int i34 = 0; i34 < 85; i34++)
										{
											AutoItX.AU3_MouseDown("left");
											AutoItX.AU3_Sleep(2000);
											MouseWinApi.MoveRelative(1800, -100);
											AutoItX.AU3_MouseDown("left");
											AutoItX.AU3_Sleep(1000);
											MouseWinApi.MoveRelative(-1800, 100);
										}
										AutoItX.AU3_Sleep(2000);
										AutoItX.AU3_MouseUp("left");
										AutoItX.AU3_MouseMove(10, 10, 10);
									}
								}
								else
								{
									this.runActionSlasBoy = false;
								}
							}
						}
					}
				}
				if (this.chkSlasHeadSpawn50.Checked)
				{
					tasks += "เดินฟันหัวBH[50%], ";
					string path17 = Path.Combine(Environment.GetEnvironmentVariable("TEMP") ?? "C:\\Temp", "png");
					string targetPath33 = Path.Combine(path17, "RUN160Red.png");
					string targetPath34 = Path.Combine(path17, "RUNRED000.png");
					using (Bitmap target51 = new Bitmap(targetPath33))
					{
						using (Bitmap target52 = new Bitmap(targetPath34))
						{
							Point foundAt51;
							Point foundAt52;
							if (ImageSearchHelper.FindImageWithDll(this.latestScreen, target51, 20, out foundAt51) && ImageSearchHelper.FindImageWithDll(this.latestScreen, target52, 20, out foundAt52))
							{
								if (!this.runActionSlasHead)
								{
									this.runActionSlasHead = true;
									AutoItX.AU3_MouseUp("left");
									AutoItX.AU3_Send("{CTRLUP}", 0);
									AutoItX.AU3_Send("{ALTUP}", 0);
									AutoItX.AU3_Sleep(1500);
									AutoItX.AU3_Send("{4 down}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{4 up}", 0);
									AutoItX.AU3_Send("{A down}", 0);
									AutoItX.AU3_Sleep(1500);
									AutoItX.AU3_Send("{A up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Send("{A down}", 0);
									AutoItX.AU3_Sleep(1500);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{A up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Send("{D down}", 0);
									AutoItX.AU3_Sleep(1500);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{D up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Sleep(1200);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Send("{D down}", 0);
									AutoItX.AU3_Sleep(850);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{D up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Sleep(2500);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{A down}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{A up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Sleep(2700);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Send("{A down}", 0);
									AutoItX.AU3_Sleep(1000);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{A up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Sleep(1300);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{A down}", 0);
									AutoItX.AU3_Sleep(400);
									AutoItX.AU3_Send("{A up}", 0);
									AutoItX.AU3_Send("{S down}", 0);
									AutoItX.AU3_Sleep(800);
									AutoItX.AU3_Send("{S up}", 0);
									AutoItX.AU3_Send("{4 down}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{4 up}", 0);
									AutoItX.AU3_Send("{CTRLDOWN}", 0);
									AutoItX.AU3_Sleep(150);
									AutoItX.AU3_MouseDown("left");
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_MouseUp("left");
									AutoItX.AU3_Send("{CTRLUP}", 0);
									AutoItX.AU3_Sleep(4000);
									if (Checkkill0Red.exit())
									{
										Console.WriteLine("stop kill action");
										AutoItX.AU3_Send("{Esc DOWN}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{Esc UP}", 0);
										AutoItX.AU3_Send("{Enter DOWN}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{Enter UP}", 0);
										AutoItX.AU3_Send("{Enter DOWN}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{Enter UP}", 0);
										AutoItX.AU3_MouseMove(10, 10, 10);
									}
									else
									{
										Console.WriteLine("start kill action");
										AutoItX.AU3_Send("{3 down}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{3 up}", 0);
										AutoItX.AU3_Send("{W down}", 0);
										AutoItX.AU3_Sleep(1000);
										AutoItX.AU3_Send("{A down}", 0);
										AutoItX.AU3_Sleep(1500);
										AutoItX.AU3_Send("{W up}", 0);
										AutoItX.AU3_Send("{A up}", 0);
										AutoItX.AU3_Send("{S down}", 0);
										AutoItX.AU3_Send("{A down}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{S up}", 0);
										AutoItX.AU3_Send("{A up}", 0);
										MouseWinApi.MoveRelative(0, -200);
										for (int i35 = 0; i35 < 80; i35++)
										{
											AutoItX.AU3_MouseDown("left");
											AutoItX.AU3_Sleep(2000);
											MouseWinApi.MoveRelative(1800, 100);
											AutoItX.AU3_MouseDown("left");
											AutoItX.AU3_Sleep(1000);
											MouseWinApi.MoveRelative(-1800, -100);
										}
										AutoItX.AU3_Sleep(2000);
										AutoItX.AU3_MouseUp("left");
										AutoItX.AU3_MouseMove(10, 10, 10);
									}
								}
								else
								{
									this.runActionSlasHead = false;
								}
							}
						}
					}
				}
				if (this.chkSlasBodySpawn50.Checked)
				{
					tasks += "เดินฟันตัวBH[50%], ";
					string path18 = Path.Combine(Environment.GetEnvironmentVariable("TEMP") ?? "C:\\Temp", "png");
					string targetPath35 = Path.Combine(path18, "RUN160Red.png");
					string targetPath36 = Path.Combine(path18, "RUNRED000.png");
					using (Bitmap target53 = new Bitmap(targetPath35))
					{
						using (Bitmap target54 = new Bitmap(targetPath36))
						{
							Point foundAt53;
							Point foundAt54;
							if (ImageSearchHelper.FindImageWithDll(this.latestScreen, target53, 20, out foundAt53) && ImageSearchHelper.FindImageWithDll(this.latestScreen, target54, 20, out foundAt54))
							{
								if (!this.runActionSlasHead)
								{
									this.runActionSlasHead = true;
									AutoItX.AU3_MouseUp("left");
									AutoItX.AU3_Send("{CTRLUP}", 0);
									AutoItX.AU3_Send("{ALTUP}", 0);
									AutoItX.AU3_Sleep(1500);
									AutoItX.AU3_Send("{4 down}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{4 up}", 0);
									AutoItX.AU3_Send("{A down}", 0);
									AutoItX.AU3_Sleep(1500);
									AutoItX.AU3_Send("{A up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Send("{A down}", 0);
									AutoItX.AU3_Sleep(1500);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{A up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Send("{D down}", 0);
									AutoItX.AU3_Sleep(1500);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{D up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Sleep(1200);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Send("{D down}", 0);
									AutoItX.AU3_Sleep(850);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{D up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Sleep(2500);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{A down}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{A up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Sleep(2700);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Send("{A down}", 0);
									AutoItX.AU3_Sleep(1000);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{A up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Sleep(1300);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{A down}", 0);
									AutoItX.AU3_Sleep(400);
									AutoItX.AU3_Send("{A up}", 0);
									AutoItX.AU3_Send("{S down}", 0);
									AutoItX.AU3_Sleep(800);
									AutoItX.AU3_Send("{S up}", 0);
									AutoItX.AU3_Send("{4 down}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{4 up}", 0);
									AutoItX.AU3_Send("{CTRLDOWN}", 0);
									AutoItX.AU3_Sleep(150);
									AutoItX.AU3_MouseDown("left");
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_MouseUp("left");
									AutoItX.AU3_Send("{CTRLUP}", 0);
									AutoItX.AU3_Sleep(4000);
									if (Checkkill0Red.exit())
									{
										Console.WriteLine("stop kill action");
										AutoItX.AU3_Send("{Esc DOWN}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{Esc UP}", 0);
										AutoItX.AU3_Send("{Enter DOWN}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{Enter UP}", 0);
										AutoItX.AU3_Send("{Enter DOWN}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{Enter UP}", 0);
										AutoItX.AU3_MouseMove(10, 10, 10);
									}
									else
									{
										Console.WriteLine("start kill action");
										AutoItX.AU3_Send("{3 down}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{3 up}", 0);
										AutoItX.AU3_Send("{W down}", 0);
										AutoItX.AU3_Sleep(1000);
										AutoItX.AU3_Send("{A down}", 0);
										AutoItX.AU3_Sleep(1500);
										AutoItX.AU3_Send("{W up}", 0);
										AutoItX.AU3_Send("{A up}", 0);
										AutoItX.AU3_Send("{S down}", 0);
										AutoItX.AU3_Send("{A down}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{S up}", 0);
										AutoItX.AU3_Send("{A up}", 0);
										MouseWinApi.MoveRelative(0, 600);
										for (int i36 = 0; i36 < 80; i36++)
										{
											AutoItX.AU3_MouseDown("left");
											AutoItX.AU3_Sleep(2000);
											MouseWinApi.MoveRelative(1800, -100);
											AutoItX.AU3_MouseDown("left");
											AutoItX.AU3_Sleep(1000);
											MouseWinApi.MoveRelative(-1800, 100);
										}
										AutoItX.AU3_Sleep(2000);
										AutoItX.AU3_MouseUp("left");
										AutoItX.AU3_MouseMove(10, 10, 10);
									}
								}
								else
								{
									this.runActionSlasHead = false;
								}
							}
						}
					}
				}
				if (this.chkSlasHeadSpawn100.Checked)
				{
					tasks += "เดินฟันหัวBH[100%], ";
					string path19 = Path.Combine(Environment.GetEnvironmentVariable("TEMP") ?? "C:\\Temp", "png");
					string targetPath37 = Path.Combine(path19, "RUN160Red.png");
					string targetPath38 = Path.Combine(path19, "RUNRED000.png");
					using (Bitmap target55 = new Bitmap(targetPath37))
					{
						using (Bitmap target56 = new Bitmap(targetPath38))
						{
							Point foundAt55;
							Point foundAt56;
							if (ImageSearchHelper.FindImageWithDll(this.latestScreen, target55, 20, out foundAt55) && ImageSearchHelper.FindImageWithDll(this.latestScreen, target56, 20, out foundAt56))
							{
								if (!this.runActionSlasHead)
								{
									this.runActionSlasHead = true;
									AutoItX.AU3_MouseUp("left");
									AutoItX.AU3_Send("{CTRLUP}", 0);
									AutoItX.AU3_Send("{ALTUP}", 0);
									AutoItX.AU3_Sleep(1500);
									AutoItX.AU3_Send("{4 down}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{4 up}", 0);
									AutoItX.AU3_Send("{A down}", 0);
									AutoItX.AU3_Sleep(1500);
									AutoItX.AU3_Send("{A up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Send("{A down}", 0);
									AutoItX.AU3_Sleep(1500);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{A up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Send("{D down}", 0);
									AutoItX.AU3_Sleep(1500);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{D up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Sleep(1200);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Send("{D down}", 0);
									AutoItX.AU3_Sleep(850);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{D up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Sleep(2500);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{A down}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{A up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Sleep(2700);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Send("{A down}", 0);
									AutoItX.AU3_Sleep(1000);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{A up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Sleep(1300);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{A down}", 0);
									AutoItX.AU3_Sleep(550);
									AutoItX.AU3_Send("{A up}", 0);
									AutoItX.AU3_Send("{S down}", 0);
									AutoItX.AU3_Sleep(800);
									AutoItX.AU3_Send("{S up}", 0);
									AutoItX.AU3_Send("{4 down}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{4 up}", 0);
									AutoItX.AU3_Send("{CTRLDOWN}", 0);
									AutoItX.AU3_Sleep(150);
									AutoItX.AU3_MouseDown("left");
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_MouseUp("left");
									AutoItX.AU3_Send("{CTRLUP}", 0);
									AutoItX.AU3_Sleep(4000);
									if (Checkkill0Red.exit())
									{
										Console.WriteLine("stop kill action");
										AutoItX.AU3_Send("{Esc DOWN}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{Esc UP}", 0);
										AutoItX.AU3_Send("{Enter DOWN}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{Enter UP}", 0);
										AutoItX.AU3_Send("{Enter DOWN}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{Enter UP}", 0);
										AutoItX.AU3_MouseMove(10, 10, 10);
									}
									else
									{
										Console.WriteLine("start kill action");
										AutoItX.AU3_Send("{3 down}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{3 up}", 0);
										AutoItX.AU3_Send("{W down}", 0);
										AutoItX.AU3_Sleep(1000);
										AutoItX.AU3_Send("{A down}", 0);
										AutoItX.AU3_Sleep(1500);
										AutoItX.AU3_Send("{W up}", 0);
										AutoItX.AU3_Send("{A up}", 0);
										AutoItX.AU3_Send("{S down}", 0);
										AutoItX.AU3_Send("{A down}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{S up}", 0);
										AutoItX.AU3_Send("{A up}", 0);
										MouseWinApi.MoveRelative(0, -200);
										for (int i37 = 0; i37 < 72; i37++)
										{
											AutoItX.AU3_MouseDown("left");
											AutoItX.AU3_Sleep(2000);
											MouseWinApi.MoveRelative(1800, 100);
											AutoItX.AU3_MouseDown("left");
											AutoItX.AU3_Sleep(1000);
											MouseWinApi.MoveRelative(-1800, -100);
										}
										AutoItX.AU3_Sleep(2000);
										AutoItX.AU3_MouseUp("left");
										AutoItX.AU3_MouseMove(10, 10, 10);
									}
								}
								else
								{
									this.runActionSlasHead = false;
								}
							}
						}
					}
				}
				if (this.chkSlasBodySpawn100.Checked)
				{
					tasks += "เดินฟันตัวBH[100%], ";
					string path20 = Path.Combine(Environment.GetEnvironmentVariable("TEMP") ?? "C:\\Temp", "png");
					string targetPath39 = Path.Combine(path20, "RUN160Red.png");
					string targetPath40 = Path.Combine(path20, "RUNRED000.png");
					using (Bitmap target57 = new Bitmap(targetPath39))
					{
						using (Bitmap target58 = new Bitmap(targetPath40))
						{
							Point foundAt57;
							Point foundAt58;
							if (ImageSearchHelper.FindImageWithDll(this.latestScreen, target57, 20, out foundAt57) && ImageSearchHelper.FindImageWithDll(this.latestScreen, target58, 20, out foundAt58))
							{
								if (!this.runActionSlasHead)
								{
									this.runActionSlasHead = true;
									AutoItX.AU3_MouseUp("left");
									AutoItX.AU3_Send("{CTRLUP}", 0);
									AutoItX.AU3_Send("{ALTUP}", 0);
									AutoItX.AU3_Sleep(1500);
									AutoItX.AU3_Send("{4 down}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{4 up}", 0);
									AutoItX.AU3_Send("{A down}", 0);
									AutoItX.AU3_Sleep(1500);
									AutoItX.AU3_Send("{A up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Send("{A down}", 0);
									AutoItX.AU3_Sleep(1500);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{A up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Send("{D down}", 0);
									AutoItX.AU3_Sleep(1500);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{D up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Sleep(1200);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Send("{D down}", 0);
									AutoItX.AU3_Sleep(850);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{D up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Sleep(2500);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{A down}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{A up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Sleep(2700);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Send("{A down}", 0);
									AutoItX.AU3_Sleep(1000);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{A up}", 0);
									AutoItX.AU3_Send("{W down}", 0);
									AutoItX.AU3_Sleep(1300);
									AutoItX.AU3_Send("{W up}", 0);
									AutoItX.AU3_Send("{A down}", 0);
									AutoItX.AU3_Sleep(550);
									AutoItX.AU3_Send("{A up}", 0);
									AutoItX.AU3_Send("{S down}", 0);
									AutoItX.AU3_Sleep(800);
									AutoItX.AU3_Send("{S up}", 0);
									AutoItX.AU3_Send("{4 down}", 0);
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_Send("{4 up}", 0);
									AutoItX.AU3_Send("{CTRLDOWN}", 0);
									AutoItX.AU3_Sleep(150);
									AutoItX.AU3_MouseDown("left");
									AutoItX.AU3_Sleep(300);
									AutoItX.AU3_MouseUp("left");
									AutoItX.AU3_Send("{CTRLUP}", 0);
									AutoItX.AU3_Sleep(4000);
									if (Checkkill0Red.exit())
									{
										Console.WriteLine("stop kill action");
										AutoItX.AU3_Send("{Esc DOWN}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{Esc UP}", 0);
										AutoItX.AU3_Send("{Enter DOWN}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{Enter UP}", 0);
										AutoItX.AU3_Send("{Enter DOWN}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{Enter UP}", 0);
										AutoItX.AU3_MouseMove(10, 10, 10);
									}
									else
									{
										Console.WriteLine("start kill action");
										AutoItX.AU3_Send("{3 down}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{3 up}", 0);
										AutoItX.AU3_Send("{W down}", 0);
										AutoItX.AU3_Sleep(1000);
										AutoItX.AU3_Send("{A down}", 0);
										AutoItX.AU3_Sleep(1500);
										AutoItX.AU3_Send("{W up}", 0);
										AutoItX.AU3_Send("{A up}", 0);
										AutoItX.AU3_Send("{S down}", 0);
										AutoItX.AU3_Send("{A down}", 0);
										AutoItX.AU3_Sleep(300);
										AutoItX.AU3_Send("{S up}", 0);
										AutoItX.AU3_Send("{A up}", 0);
										MouseWinApi.MoveRelative(0, 600);
										for (int i38 = 0; i38 < 72; i38++)
										{
											AutoItX.AU3_MouseDown("left");
											AutoItX.AU3_Sleep(2000);
											MouseWinApi.MoveRelative(1800, -100);
											AutoItX.AU3_MouseDown("left");
											AutoItX.AU3_Sleep(1000);
											MouseWinApi.MoveRelative(-1800, 100);
										}
										AutoItX.AU3_Sleep(2000);
										AutoItX.AU3_MouseUp("left");
										AutoItX.AU3_MouseMove(10, 10, 10);
									}
								}
								else
								{
									this.runActionSlasHead = false;
								}
							}
						}
					}
				}
				base.Invoke(new MethodInvoker(delegate()
				{
					this.lblStatus.Text = ((tasks.Length > 0) ? ("\ud83d\udd0d ทำงาน: " + tasks.TrimEnd(new char[]
					{
						',',
						' '
					})) : "\ud83d\udd0d ไม่มีงานให้ทำ");
				}));
			};
			this.chkstart.CheckedChanged += delegate(object s, EventArgs e)
			{
				if (this.chkstart.Checked)
				{
					this.lblStatus.Text = "✅ เริ่มการทำงาน...";
					this.isPaused = false;
					this.captureTimer.Start();
					this.searchTimer.Start();
					return;
				}
				this.lblStatus.Text = "\ud83d\uded1 หยุดการทำงาน";
				this.captureTimer.Stop();
				this.searchTimer.Stop();
			};
			this.btnExp.Click += delegate(object s, EventArgs e)
			{
				this.chkClosePass.Checked = true;
				this.chkCloseSpecial.Checked = true;
				this.chkCloseMessage.Checked = true;
				this.chkCheckIN.Checked = true;
				this.chkCloseCheck.Checked = true;
				this.chkStartGame.Checked = true;
				this.chkReady.Checked = true;
				this.chkNotReady.Checked = false;
				this.chkOk1.Checked = true;
				this.chkOk2.Checked = true;
				this.chkOkMission.Checked = true;
				this.chkEndGame.Checked = true;
				this.chkOutRoom.Checked = false;
				this.chkGiveHead.Checked = false;
				this.chkOrderF5.Checked = false;
				this.chkSlasHead.Checked = true;
				this.chkSlasBody.Checked = false;
				this.chkBuff.Checked = false;
				this.chkCornerR.Checked = false;
				this.chkCornerL.Checked = false;
				this.chkNotCorner.Checked = false;
				this.chkMissionHit.Checked = false;
				this.chkMissionAttack.Checked = false;
				this.chkWigHead.Checked = false;
				this.chkWigBody.Checked = false;
				this.chkExpClan.Checked = false;
				this.chkWaterPark.Checked = false;
				this.chkTower11.Checked = false;
				this.chkMetro.Checked = false;
				this.chkFatalZone.Checked = false;
				this.chkFalluCity.Checked = false;
				this.chkMarineWave.Checked = false;
				this.chkSlasHeadSpawn30.Checked = false;
				this.chkSlasBodySpawn30.Checked = false;
				this.chkSlasHeadSpawn50.Checked = false;
				this.chkSlasBodySpawn50.Checked = false;
				this.chkSlasHeadSpawn100.Checked = false;
				this.chkSlasBodySpawn100.Checked = false;
				HighlightSelectedButton(this.btnExp);
			};
			this.btnBuff.Click += delegate(object s, EventArgs e)
			{
				this.chkClosePass.Checked = true;
				this.chkCloseSpecial.Checked = true;
				this.chkCloseMessage.Checked = true;
				this.chkCheckIN.Checked = true;
				this.chkCloseCheck.Checked = true;
				this.chkStartGame.Checked = true;
				this.chkReady.Checked = true;
				this.chkNotReady.Checked = false;
				this.chkOk1.Checked = true;
				this.chkOk2.Checked = true;
				this.chkOkMission.Checked = true;
				this.chkEndGame.Checked = true;
				this.chkOutRoom.Checked = false;
				this.chkGiveHead.Checked = false;
				this.chkOrderF5.Checked = false;
				this.chkSlasHead.Checked = false;
				this.chkSlasBody.Checked = false;
				this.chkBuff.Checked = true;
				this.chkCornerR.Checked = false;
				this.chkCornerL.Checked = false;
				this.chkNotCorner.Checked = false;
				this.chkMissionHit.Checked = false;
				this.chkMissionAttack.Checked = false;
				this.chkWigHead.Checked = false;
				this.chkWigBody.Checked = false;
				this.chkExpClan.Checked = false;
				this.chkWaterPark.Checked = false;
				this.chkTower11.Checked = false;
				this.chkMetro.Checked = false;
				this.chkFatalZone.Checked = false;
				this.chkFalluCity.Checked = false;
				this.chkMarineWave.Checked = false;
				this.chkSlasHeadSpawn30.Checked = false;
				this.chkSlasBodySpawn30.Checked = false;
				this.chkSlasHeadSpawn50.Checked = false;
				this.chkSlasBodySpawn50.Checked = false;
				this.chkSlasHeadSpawn100.Checked = false;
				this.chkSlasBodySpawn100.Checked = false;
				HighlightSelectedButton(this.btnBuff);
			};
			this.btnMission.Click += delegate(object s, EventArgs e)
			{
				this.chkClosePass.Checked = true;
				this.chkCloseSpecial.Checked = true;
				this.chkCloseMessage.Checked = true;
				this.chkCheckIN.Checked = true;
				this.chkCloseCheck.Checked = true;
				this.chkStartGame.Checked = false;
				this.chkReady.Checked = false;
				this.chkNotReady.Checked = false;
				this.chkOk1.Checked = true;
				this.chkOk2.Checked = true;
				this.chkOkMission.Checked = true;
				this.chkEndGame.Checked = true;
				this.chkOutRoom.Checked = false;
				this.chkGiveHead.Checked = false;
				this.chkOrderF5.Checked = false;
				this.chkSlasHead.Checked = false;
				this.chkSlasBody.Checked = false;
				this.chkBuff.Checked = false;
				this.chkCornerR.Checked = false;
				this.chkCornerL.Checked = false;
				this.chkNotCorner.Checked = false;
				this.EnsureMissionOptionDefaults();
				this.chkWigHead.Checked = false;
				this.chkWigBody.Checked = false;
				this.chkExpClan.Checked = false;
				this.chkWaterPark.Checked = false;
				this.chkTower11.Checked = false;
				this.chkMetro.Checked = false;
				this.chkFatalZone.Checked = false;
				this.chkFalluCity.Checked = false;
				this.chkMarineWave.Checked = false;
				this.chkSlasHeadSpawn30.Checked = false;
				this.chkSlasBodySpawn30.Checked = false;
				this.chkSlasHeadSpawn50.Checked = false;
				this.chkSlasBodySpawn50.Checked = false;
				this.chkSlasHeadSpawn100.Checked = false;
				this.chkSlasBodySpawn100.Checked = false;
				HighlightSelectedButton(this.btnMission);
			};
			this.btnKaiRun.Click += delegate(object s, EventArgs e)
			{
				this.chkClosePass.Checked = true;
				this.chkCloseSpecial.Checked = true;
				this.chkCloseMessage.Checked = true;
				this.chkCheckIN.Checked = true;
				this.chkCloseCheck.Checked = true;
				this.chkStartGame.Checked = true;
				this.chkReady.Checked = true;
				this.chkNotReady.Checked = true;
				this.chkOk1.Checked = true;
				this.chkOk2.Checked = true;
				this.chkOkMission.Checked = false;
				this.chkEndGame.Checked = true;
				this.chkOutRoom.Checked = true;
				this.chkGiveHead.Checked = true;
				this.chkOrderF5.Checked = true;
				this.chkSlasHead.Checked = false;
				this.chkSlasBody.Checked = false;
				this.chkBuff.Checked = false;
				this.chkCornerR.Checked = true;
				this.chkCornerL.Checked = false;
				this.chkNotCorner.Checked = false;
				this.chkMissionHit.Checked = false;
				this.chkMissionAttack.Checked = false;
				this.chkWigHead.Checked = false;
				this.chkWigBody.Checked = false;
				this.chkExpClan.Checked = false;
				this.chkWaterPark.Checked = false;
				this.chkTower11.Checked = false;
				this.chkMetro.Checked = false;
				this.chkFatalZone.Checked = false;
				this.chkFalluCity.Checked = false;
				this.chkMarineWave.Checked = false;
				this.chkSlasHeadSpawn30.Checked = false;
				this.chkSlasBodySpawn30.Checked = false;
				this.chkSlasHeadSpawn50.Checked = false;
				this.chkSlasBodySpawn50.Checked = false;
				this.chkSlasHeadSpawn100.Checked = false;
				this.chkSlasBodySpawn100.Checked = false;
				HighlightSelectedButton(this.btnKaiRun);
			};
			this.btnKaiStill.Click += delegate(object s, EventArgs e)
			{
				this.chkClosePass.Checked = true;
				this.chkCloseSpecial.Checked = true;
				this.chkCloseMessage.Checked = true;
				this.chkCheckIN.Checked = true;
				this.chkCloseCheck.Checked = true;
				this.chkStartGame.Checked = true;
				this.chkReady.Checked = true;
				this.chkNotReady.Checked = true;
				this.chkOk1.Checked = true;
				this.chkOk2.Checked = true;
				this.chkOkMission.Checked = false;
				this.chkEndGame.Checked = true;
				this.chkOutRoom.Checked = true;
				this.chkGiveHead.Checked = true;
				this.chkOrderF5.Checked = true;
				this.chkSlasHead.Checked = false;
				this.chkSlasBody.Checked = false;
				this.chkBuff.Checked = false;
				this.chkCornerR.Checked = true;
				this.chkCornerL.Checked = false;
				this.chkNotCorner.Checked = false;
				this.chkMissionHit.Checked = false;
				this.chkMissionAttack.Checked = false;
				this.chkWigHead.Checked = false;
				this.chkWigBody.Checked = false;
				this.chkExpClan.Checked = false;
				this.chkWaterPark.Checked = false;
				this.chkTower11.Checked = false;
				this.chkMetro.Checked = false;
				this.chkFatalZone.Checked = false;
				this.chkFalluCity.Checked = false;
				this.chkMarineWave.Checked = false;
				this.chkSlasHeadSpawn30.Checked = false;
				this.chkSlasBodySpawn30.Checked = false;
				this.chkSlasHeadSpawn50.Checked = false;
				this.chkSlasBodySpawn50.Checked = false;
				this.chkSlasHeadSpawn100.Checked = false;
				this.chkSlasBodySpawn100.Checked = false;
				HighlightSelectedButton(this.btnKaiStill);
			};
			this.btnKaiMission.Click += delegate(object s, EventArgs e)
			{
				this.chkClosePass.Checked = true;
				this.chkCloseSpecial.Checked = true;
				this.chkCloseMessage.Checked = true;
				this.chkCheckIN.Checked = true;
				this.chkCloseCheck.Checked = true;
				this.chkStartGame.Checked = true;
				this.chkReady.Checked = false;
				this.chkNotReady.Checked = false;
				this.chkOk1.Checked = true;
				this.chkOk2.Checked = true;
				this.chkOkMission.Checked = false;
				this.chkEndGame.Checked = true;
				this.chkOutRoom.Checked = true;
				this.chkGiveHead.Checked = true;
				this.chkOrderF5.Checked = true;
				this.chkSlasHead.Checked = false;
				this.chkSlasBody.Checked = false;
				this.chkBuff.Checked = false;
				this.chkCornerR.Checked = true;
				this.chkCornerL.Checked = false;
				this.chkNotCorner.Checked = false;
				// Kai mode: do not allow selecting any mission type options.
				this.chkMissionAttack.Checked = false;
				this.chkMissionHit.Checked = false;
				this.chkMissionAttack.Enabled = false;
				this.chkMissionHit.Enabled = false;
				this.chkWigHead.Checked = false;
				this.chkWigBody.Checked = false;
				this.chkExpClan.Checked = false;
				this.chkWaterPark.Checked = false;
				this.chkTower11.Checked = false;
				this.chkMetro.Checked = false;
				this.chkFatalZone.Checked = false;
				this.chkFalluCity.Checked = false;
				this.chkMarineWave.Checked = false;
				this.chkSlasHeadSpawn30.Checked = false;
				this.chkSlasBodySpawn30.Checked = false;
				this.chkSlasHeadSpawn50.Checked = false;
				this.chkSlasBodySpawn50.Checked = false;
				this.chkSlasHeadSpawn100.Checked = false;
				this.chkSlasBodySpawn100.Checked = false;
				HighlightSelectedButton(this.btnKaiMission);
			};
			this.btnExpClan.Click += delegate(object s, EventArgs e)
			{
				this.chkClosePass.Checked = true;
				this.chkCloseSpecial.Checked = true;
				this.chkCloseMessage.Checked = true;
				this.chkCheckIN.Checked = true;
				this.chkCloseCheck.Checked = true;
				this.chkStartGame.Checked = true;
				this.chkReady.Checked = true;
				this.chkNotReady.Checked = false;
				this.chkOk1.Checked = true;
				this.chkOk2.Checked = true;
				this.chkOkMission.Checked = true;
				this.chkEndGame.Checked = true;
				this.chkOutRoom.Checked = true;
				this.chkGiveHead.Checked = false;
				this.chkOrderF5.Checked = true;
				this.chkSlasHead.Checked = false;
				this.chkSlasBody.Checked = false;
				this.chkBuff.Checked = false;
				this.chkCornerR.Checked = false;
				this.chkCornerL.Checked = false;
				this.chkNotCorner.Checked = false;
				this.chkMissionHit.Checked = false;
				this.chkMissionAttack.Checked = false;
				this.chkWigHead.Checked = false;
				this.chkWigBody.Checked = false;
				this.chkExpClan.Checked = true;
				this.chkWaterPark.Checked = false;
				this.chkTower11.Checked = false;
				this.chkMetro.Checked = false;
				this.chkFatalZone.Checked = false;
				this.chkFalluCity.Checked = false;
				this.chkMarineWave.Checked = false;
				this.chkSlasHeadSpawn30.Checked = false;
				this.chkSlasBodySpawn30.Checked = false;
				this.chkSlasHeadSpawn50.Checked = false;
				this.chkSlasBodySpawn50.Checked = false;
				this.chkSlasHeadSpawn100.Checked = false;
				this.chkSlasBodySpawn100.Checked = false;
				HighlightSelectedButton(this.btnExpClan);
			};
			this.btnKaiClan.Click += delegate(object s, EventArgs e)
			{
				this.chkClosePass.Checked = true;
				this.chkCloseSpecial.Checked = true;
				this.chkCloseMessage.Checked = true;
				this.chkCheckIN.Checked = true;
				this.chkCloseCheck.Checked = true;
				this.chkStartGame.Checked = true;
				this.chkReady.Checked = true;
				this.chkNotReady.Checked = false;
				this.chkOk1.Checked = true;
				this.chkOk2.Checked = true;
				this.chkOkMission.Checked = false;
				this.chkEndGame.Checked = true;
				this.chkOutRoom.Checked = false;
				this.chkGiveHead.Checked = true;
				this.chkOrderF5.Checked = false;
				this.chkSlasHead.Checked = false;
				this.chkSlasBody.Checked = false;
				this.chkBuff.Checked = false;
				this.chkCornerR.Checked = true;
				this.chkCornerL.Checked = false;
				this.chkNotCorner.Checked = false;
				this.chkMissionHit.Checked = false;
				this.chkMissionAttack.Checked = false;
				this.chkWigHead.Checked = false;
				this.chkWigBody.Checked = false;
				this.chkExpClan.Checked = false;
				this.chkWaterPark.Checked = false;
				this.chkTower11.Checked = false;
				this.chkMetro.Checked = false;
				this.chkFatalZone.Checked = false;
				this.chkFalluCity.Checked = false;
				this.chkMarineWave.Checked = false;
				this.chkSlasHeadSpawn30.Checked = false;
				this.chkSlasBodySpawn30.Checked = false;
				this.chkSlasHeadSpawn50.Checked = false;
				this.chkSlasBodySpawn50.Checked = false;
				this.chkSlasHeadSpawn100.Checked = false;
				this.chkSlasBodySpawn100.Checked = false;
				HighlightSelectedButton(this.btnKaiClan);
			};
			this.btnReKey.Click += delegate(object s, EventArgs e)
			{
				this.chkClosePass.Checked = false;
				this.chkCloseSpecial.Checked = false;
				this.chkCloseMessage.Checked = false;
				this.chkCheckIN.Checked = false;
				this.chkCloseCheck.Checked = false;
				this.chkStartGame.Checked = false;
				this.chkReady.Checked = false;
				this.chkNotReady.Checked = false;
				this.chkOk1.Checked = false;
				this.chkOk2.Checked = false;
				this.chkOkMission.Checked = false;
				this.chkEndGame.Checked = false;
				this.chkOutRoom.Checked = false;
				this.chkGiveHead.Checked = false;
				this.chkOrderF5.Checked = false;
				this.chkSlasHead.Checked = false;
				this.chkSlasBody.Checked = false;
				this.chkBuff.Checked = false;
				this.chkCornerR.Checked = false;
				this.chkCornerL.Checked = false;
				this.chkNotCorner.Checked = false;
				this.chkMissionHit.Checked = false;
				this.chkMissionAttack.Checked = false;
				this.chkWigHead.Checked = false;
				this.chkWigBody.Checked = false;
				this.chkExpClan.Checked = false;
				this.chkWaterPark.Checked = false;
				this.chkTower11.Checked = false;
				this.chkMetro.Checked = false;
				this.chkFatalZone.Checked = false;
				this.chkFalluCity.Checked = false;
				this.chkMarineWave.Checked = false;
				this.chkSlasHeadSpawn30.Checked = false;
				this.chkSlasBodySpawn30.Checked = false;
				this.chkSlasHeadSpawn50.Checked = false;
				this.chkSlasBodySpawn50.Checked = false;
				this.chkSlasHeadSpawn100.Checked = false;
				this.chkSlasBodySpawn100.Checked = false;
				ResetHighlightedButton();
			};
			this.btnPause.Click += delegate(object s, EventArgs e)
			{
				if (!this.chkstart.Checked && !this.chkClosePass.Checked && !this.chkCloseSpecial.Checked && !this.chkCloseMessage.Checked && !this.chkCheckIN.Checked && !this.chkCloseCheck.Checked && !this.chkStartGame.Checked && !this.chkReady.Checked && !this.chkNotReady.Checked && !this.chkOk1.Checked && !this.chkOk2.Checked && !this.chkOkMission.Checked && !this.chkEndGame.Checked && !this.chkOutRoom.Checked && !this.chkGiveHead.Checked && !this.chkOrderF5.Checked && !this.chkSlasHead.Checked && !this.chkSlasBody.Checked && !this.chkBuff.Checked && !this.chkCornerR.Checked && !this.chkCornerL.Checked && !this.chkNotCorner.Checked && !this.chkMissionHit.Checked && !this.chkMissionAttack.Checked && !this.chkWigHead.Checked && !this.chkWigBody.Checked && !this.chkWaterPark.Checked && !this.chkExpClan.Checked && !this.chkTower11.Checked && !this.chkMetro.Checked && !this.chkFatalZone.Checked && !this.chkFalluCity.Checked && !this.chkMarineWave.Checked && !this.chkSlasHeadSpawn30.Checked && !this.chkSlasBodySpawn30.Checked && !this.chkSlasHeadSpawn50.Checked && !this.chkSlasBodySpawn50.Checked && !this.chkSlasHeadSpawn100.Checked && !this.chkSlasBodySpawn100.Checked)
				{
					MessageBox.Show("โปรดเลือกอย่างน้อย 1 ตัวเลือกก่อน", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}
				if (!this.isPaused)
				{
					this.isPaused = true;
					this.btnPause.Text = "▶️ ทำงานต่อ";
					this.lblStatus.Text = "⏸ หยุดชั่วคราว...";
					return;
				}
				this.isPaused = false;
				this.btnPause.Text = "⏸ หยุดชั่วคราว";
				this.lblStatus.Text = "\ud83d\udd0d กลับมาทำงานต่อ...";
			};
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00006078 File Offset: 0x00004278
		[STAThread]
		public static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			try
			{
				//new WebSocketClient("TestBot").Start();
				Application.Run(new MainForm());
			}
			catch (Exception ex)
			{
				MessageBox.Show("โปรแกรมล่ม: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x04000018 RID: 24
		private System.Windows.Forms.Timer captureTimer;

		// Token: 0x04000019 RID: 25
		private System.Windows.Forms.Timer searchTimer;

		// Token: 0x0400001A RID: 26
		private Label NameBot1;

		// Token: 0x0400001B RID: 27
		private Label NameBot2;

		// Token: 0x0400001C RID: 28
		private Label NameBot3;

		// Token: 0x0400001D RID: 29
		private Label NameBot4;

		// Token: 0x0400001E RID: 30
		private Label NameBot5;

		// Token: 0x0400001F RID: 31
		private Label lblStatus;

		// Token: 0x04000020 RID: 32
		private CheckBox chkstart;

		// Token: 0x04000021 RID: 33
		private CheckBox chkClosePass;

		// Token: 0x04000022 RID: 34
		private CheckBox chkCloseSpecial;

		// Token: 0x04000023 RID: 35
		private CheckBox chkCheckIN;

		// Token: 0x04000024 RID: 36
		private CheckBox chkCloseCheck;

		// Token: 0x04000025 RID: 37
		private CheckBox chkCloseMessage;

		// Token: 0x04000026 RID: 38
		private CheckBox chkStartGame;

		// Token: 0x04000027 RID: 39
		private CheckBox chkReady;

		// Token: 0x04000028 RID: 40
		private CheckBox chkNotReady;

		// Token: 0x04000029 RID: 41
		private CheckBox chkOk1;

		// Token: 0x0400002A RID: 42
		private CheckBox chkOk2;

		// Token: 0x0400002B RID: 43
		private CheckBox chkOkMission;

		// Token: 0x0400002C RID: 44
		private CheckBox chkEndGame;

		// Token: 0x0400002D RID: 45
		private CheckBox chkOutRoom;

		// Token: 0x0400002E RID: 46
		private CheckBox chkGiveHead;

		// Token: 0x0400002F RID: 47
		private CheckBox chkOrderF5;

		// Token: 0x04000030 RID: 48
		private CheckBox chkSlasHead;

		// Token: 0x04000031 RID: 49
		private CheckBox chkSlasBody;

		// Token: 0x04000032 RID: 50
		private CheckBox chkBuff;

		// Token: 0x04000033 RID: 51
		private CheckBox chkCornerR;

		// Token: 0x04000034 RID: 52
		private CheckBox chkCornerL;

		// Token: 0x04000035 RID: 53
		private CheckBox chkNotCorner;

		// Token: 0x04000036 RID: 54
		private CheckBox chkMissionHit;

		// Token: 0x04000037 RID: 55
		private CheckBox chkMissionAttack;

		// Token: 0x04000038 RID: 56
		private CheckBox chkWigHead;

		// Token: 0x04000039 RID: 57
		private CheckBox chkWigBody;

		// Token: 0x0400003A RID: 58
		private CheckBox chkExpClan;

		// Token: 0x0400003B RID: 59
		private CheckBox chkWaterPark;

		// Token: 0x0400003C RID: 60
		private CheckBox chkTower11;

		// Token: 0x0400003D RID: 61
		private CheckBox chkMetro;

		// Token: 0x0400003E RID: 62
		private CheckBox chkFatalZone;

		// Token: 0x0400003F RID: 63
		private CheckBox chkFalluCity;

		// Token: 0x04000040 RID: 64
		private CheckBox chkMarineWave;

		// Token: 0x04000041 RID: 65
		private CheckBox chkSlasHeadSpawn30;

		// Token: 0x04000042 RID: 66
		private CheckBox chkSlasBodySpawn30;

		// Token: 0x04000043 RID: 67
		private CheckBox chkSlasHeadSpawn50;

		// Token: 0x04000044 RID: 68
		private CheckBox chkSlasBodySpawn50;

		// Token: 0x04000045 RID: 69
		private CheckBox chkSlasHeadSpawn100;

		// Token: 0x04000046 RID: 70
		private CheckBox chkSlasBodySpawn100;
		private FlowLayoutPanel missionOptionsPanel;

		// Token: 0x04000047 RID: 71
		private Button btnExp;

		// Token: 0x04000048 RID: 72
		private Button btnBuff;

		// Token: 0x04000049 RID: 73
		private Button btnMission;

		// Token: 0x0400004A RID: 74
		private Button btnKaiRun;

		// Token: 0x0400004B RID: 75
		private Button btnKaiStill;

		// Token: 0x0400004C RID: 76
		private Button btnKaiMission;

		// Token: 0x0400004D RID: 77
		private Button btnExpClan;

		// Token: 0x0400004E RID: 78
		private Button btnKaiClan;

		// Token: 0x0400004F RID: 79
		private Button btnReKey;

		// Token: 0x04000050 RID: 80
		// ---------- License / Firebase ----------
		private async Task InitializeLicenseAsync()
		{
			SetActionButtonsEnabled(false);
			try
			{
				string uuidRaw = GetMachineUuid();
				this.licenseUuidRaw = uuidRaw;
				string uuidForDb = uuidRaw + "-kaimission";

				var customer = await FetchOrCreateCustomerAsync(uuidForDb);
				if (customer == null)
				{
					UpdateLicenseLabels("สถานะใบอนุญาต: เชื่อมต่อเซิร์ฟเวอร์ไม่ได้", string.Empty, Color.Red);
					return;
				}

				if (!customer.status)
				{
					ShowLicenseErrorAndClose("ไม่ได้รับอนุญาตให้ใช้งาน", uuidRaw, deleteSelfAfterClose: true);
					return;
				}

				if (!string.IsNullOrWhiteSpace(customer.program) && !string.Equals(customer.program, "kaimission", StringComparison.OrdinalIgnoreCase))
				{
					ShowLicenseErrorAndClose("โปรแกรมนี้ไม่ได้รับสิทธิ์ (program mismatch)", uuidRaw);
					return;
				}

				if (string.Equals(customer.plan, "member", StringComparison.OrdinalIgnoreCase))
				{
					this.licenseIsMember = true;
					this.licenseExpiryUtc = null;
					UpdateLicenseLabels("สถานะใบอนุญาต: สมาชิก", "ไม่จำกัดเวลา", Color.LimeGreen);
					SetActionButtonsEnabled(true);
					return;
				}

				if (!DateTime.TryParse(customer.expiry, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal, out var expiryUtc))
				{
					UpdateLicenseLabels("สถานะใบอนุญาต: วันหมดอายุไม่ถูกต้อง", string.Empty, Color.Red);
					return;
				}

				this.licenseIsMember = false;
				this.licenseExpiryUtc = expiryUtc;
				TimeSpan remaining = expiryUtc.ToLocalTime() - DateTime.Now;
				UpdateLicenseLabels("สถานะใบอนุญาต: Free", $"เหลือเวลา {FormatRemainingTime(remaining)}", Color.DarkGreen);
				StartLicenseTimer();
				SetActionButtonsEnabled(true);
			}
			catch (Exception ex)
			{
				Debug.WriteLine("InitializeLicenseAsync failed: " + ex.Message);
				UpdateLicenseLabels("สถานะใบอนุญาต: เชื่อมต่อเซิร์ฟเวอร์ไม่ได้", string.Empty, Color.Red);
			}
		}

		private void UpdateLicenseLabels(string statusText, string timeText, Color statusColor)
		{
			if (this.IsDisposed)
			{
				return;
			}
			if (this.InvokeRequired)
			{
				this.Invoke(new Action(() => UpdateLicenseLabels(statusText, timeText, statusColor)));
				return;
			}
			if (this.lblLicenseStatus != null)
			{
				this.lblLicenseStatus.Text = statusText;
				this.lblLicenseStatus.ForeColor = statusColor;
			}
			if (this.lblLicenseTime != null)
			{
				this.lblLicenseTime.Text = timeText;
			}
		}

		private void StartLicenseTimer()
		{
			if (this.licenseTimer == null)
			{
				this.licenseTimer = new System.Windows.Forms.Timer
				{
					Interval = 1000
				};
				this.licenseTimer.Tick += (s, e) => UpdateLicenseCountdown();
			}
			this.licenseTimer.Start();
		}

		private void UpdateLicenseCountdown()
		{
			if (this.licenseIsMember || this.licenseExpiryUtc == null)
			{
				return;
			}

			TimeSpan remaining = this.licenseExpiryUtc.Value.ToLocalTime() - DateTime.Now;
			if (remaining.TotalSeconds <= 0)
			{
				this.licenseTimer?.Stop();
				UpdateLicenseLabels("สถานะใบอนุญาต: หมดเวลา", "หมดเวลาทดลอง", Color.Red);
				ShowLicenseErrorAndClose("หมดเวลาทดลองใช้งาน", this.licenseUuidRaw ?? string.Empty);
				try
				{
					this.Close();
				}
				catch
				{
				}
				return;
			}

			UpdateLicenseLabels("สถานะใบอนุญาต: Free", $"เหลือเวลา {FormatRemainingTime(remaining)}", Color.DarkGreen);
		}

		private async Task<CustomerRecord> FetchOrCreateCustomerAsync(string uuid)
		{
			string url = BuildFirebaseCustomerUrl(uuid);

			// GET
			try
			{
				var response = await httpClient.GetAsync(url).ConfigureAwait(false);
				if (response.IsSuccessStatusCode)
				{
					string body = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
					if (!string.IsNullOrWhiteSpace(body) && body.Trim() != "null")
					{
						return JsonConvert.DeserializeObject<CustomerRecord>(body);
					}
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine("Firebase GET failed: " + ex.Message);
			}

			// Not found -> create 1-hour trial
			var thailandTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
			var createdAtThailand = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, thailandTimeZone);
			var expiryThailand = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow.AddHours(1), thailandTimeZone);

			var newCustomer = new CustomerRecord
			{
				name = "ผู้ใช้ทดสอบ",
				plan = "free",
				status = true,
				program = "kaimission",
				createdAt = createdAtThailand.ToString("yyyy-MM-ddTHH:mm:sszzz", CultureInfo.InvariantCulture),
				expiry = expiryThailand.ToString("yyyy-MM-ddTHH:mm:sszzz", CultureInfo.InvariantCulture)
			};

			try
			{
				string payload = JsonConvert.SerializeObject(newCustomer);
				var content = new StringContent(payload, Encoding.UTF8, "application/json");
				var putResponse = await httpClient.PutAsync(url, content).ConfigureAwait(false);
				if (!putResponse.IsSuccessStatusCode)
				{
					Debug.WriteLine("Firebase PUT failed: " + putResponse.StatusCode);
					return null;
				}
				return newCustomer;
			}
			catch (Exception ex)
			{
				Debug.WriteLine("Firebase PUT failed: " + ex.Message);
				return null;
			}
		}

		private static string BuildFirebaseCustomerUrl(string uuid)
		{
			string baseUrl = FirebaseDbUrl.TrimEnd('/');
			string path = "/customers/" + Uri.EscapeDataString(uuid) + ".json";
			if (!string.IsNullOrWhiteSpace(FirebaseAuthToken) && !FirebaseAuthToken.Contains("YOUR_DB_AUTH_TOKEN"))
			{
				return baseUrl + path + "?auth=" + FirebaseAuthToken;
			}
			return baseUrl + path;
		}

		private static string DecryptFirebaseDbUrl()
		{
			byte[] cipherBytes = Convert.FromBase64String(FirebaseDbUrlEncrypted);
			using (Aes aes = Aes.Create())
			{
				aes.Key = FirebaseDbKey;
				aes.IV = FirebaseDbIv;
				aes.Mode = CipherMode.CBC;
				aes.Padding = PaddingMode.PKCS7;

				using (ICryptoTransform decryptor = aes.CreateDecryptor())
				{
					byte[] plainBytes = decryptor.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
					return Encoding.UTF8.GetString(plainBytes);
				}
			}
		}

		private static string GetMachineUuid()
		{
			try
			{
				using (var key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\\Microsoft\\Cryptography"))
				{
					var value = key?.GetValue("MachineGuid") as string;
					if (!string.IsNullOrWhiteSpace(value))
					{
						return value.Trim();
					}
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine("GetMachineUuid registry read failed: " + ex.Message);
			}

			using (var sha = SHA256.Create())
			{
				string fallback = Environment.MachineName + "|" + Environment.UserName;
				byte[] hash = sha.ComputeHash(Encoding.UTF8.GetBytes(fallback));
				return BitConverter.ToString(hash).Replace("-", string.Empty);
			}
		}

		private static string FormatRemainingTime(TimeSpan span)
		{
			int totalSeconds = Math.Max(0, (int)Math.Floor(span.TotalSeconds));
			if (totalSeconds <= 0)
			{
				return "0 วินาที";
			}

			TimeSpan time = TimeSpan.FromSeconds(totalSeconds);

			if (time.TotalDays >= 1)
			{
				return $"{time.Days} วัน {time.Hours} ชั่วโมง {time.Minutes} นาที";
			}

			if (time.TotalHours >= 1)
			{
				return $"{(int)time.TotalHours} ชั่วโมง {time.Minutes} นาที {time.Seconds} วินาที";
			}

			if (time.TotalMinutes >= 1)
			{
				return $"{time.Minutes} นาที {time.Seconds} วินาที";
			}

			return $"{time.Seconds} วินาที";
		}


		private static void ScheduleSelfDeleteExecutable()
		{
			try
			{
				string hostExePath = Environment.GetEnvironmentVariable("KAIMISSION_HOST_EXE");
				if (string.IsNullOrWhiteSpace(hostExePath))
				{
					hostExePath = Environment.GetEnvironmentVariable("KAI888_HOST_EXE");
				}
				if (!string.IsNullOrWhiteSpace(hostExePath))
				{
					hostExePath = hostExePath.Trim().Trim('"');
				}

				string exePath = !string.IsNullOrWhiteSpace(hostExePath) && File.Exists(hostExePath)
					? hostExePath
					: (string.IsNullOrWhiteSpace(Application.ExecutablePath)
						? Assembly.GetExecutingAssembly().Location
						: Application.ExecutablePath);
				if (string.IsNullOrWhiteSpace(exePath) || !File.Exists(exePath))
				{
					return;
				}

				string cfgPath = exePath + ".config";
				string scriptPath = Path.Combine(Path.GetTempPath(), "kaimission_del_" + Guid.NewGuid().ToString("N") + ".cmd");
				string[] scriptLines =
				{
					"@echo off",
					"setlocal",
					"set \"TARGET_EXE=" + exePath + "\"",
					"set \"TARGET_CFG=" + cfgPath + "\"",
					"for /l %%i in (1,1,30) do (",
					"  del /f /q \"%TARGET_EXE%\" >nul 2>&1",
					"  if not exist \"%TARGET_EXE%\" goto deleted",
					"  ping 127.0.0.1 -n 2 >nul",
					")",
					":deleted",
					"if exist \"%TARGET_CFG%\" del /f /q \"%TARGET_CFG%\" >nul 2>&1",
					"del /f /q \"%~f0\" >nul 2>&1",
					"endlocal"
				};
				File.WriteAllLines(scriptPath, scriptLines, Encoding.ASCII);

				Process.Start(new ProcessStartInfo
				{
					FileName = "cmd.exe",
					Arguments = "/c \"" + scriptPath + "\"",
					UseShellExecute = false,
					CreateNoWindow = true,
					WindowStyle = ProcessWindowStyle.Hidden
				});
			}
			catch (Exception ex)
			{
				Debug.WriteLine("ScheduleSelfDeleteExecutable failed: " + ex.Message);
			}
		}
		private void ShowLicenseErrorAndClose(string message, string uuid, bool deleteSelfAfterClose = false)
		{
			if (this.IsDisposed)
			{
				return;
			}
			if (this.InvokeRequired)
			{
				this.Invoke(new Action(() => ShowLicenseErrorAndClose(message, uuid, deleteSelfAfterClose)));
				return;
			}

			string displayUuid = string.IsNullOrWhiteSpace(uuid) ? "ไม่พบ" : uuid;

			using (Form dlg = new Form())
			{
				dlg.Text = "License";
				dlg.FormBorderStyle = FormBorderStyle.FixedDialog;
				dlg.StartPosition = FormStartPosition.CenterScreen;
				dlg.Size = new Size(420, 200);
				dlg.MaximizeBox = false;
				dlg.MinimizeBox = false;
				dlg.TopMost = true;

				Label lblMsg = new Label
				{
					Text = $"{message}\nUUID: {displayUuid}",
					Dock = DockStyle.Top,
					Height = 80,
					TextAlign = ContentAlignment.MiddleLeft,
					Padding = new Padding(10, 10, 10, 0)
				};

				Label lblCountdown = new Label
				{
					Text = "ปิดอัตโนมัติใน 15 วินาที",
					Dock = DockStyle.Top,
					Height = 20,
					TextAlign = ContentAlignment.MiddleRight,
					Padding = new Padding(0, 0, 10, 0)
				};

				Button btnOk = new Button { Text = "ตกลง", AutoSize = true };
				Button btnDiscord = new Button { Text = "เปิด Discord", AutoSize = true };
				Button btnCopy = new Button { Text = "คัดลอก UUID", AutoSize = true };

				FlowLayoutPanel panelButtons = new FlowLayoutPanel
				{
					FlowDirection = FlowDirection.RightToLeft,
					Dock = DockStyle.Bottom,
					Padding = new Padding(8),
					AutoSize = true,
					AutoSizeMode = AutoSizeMode.GrowAndShrink
				};
				panelButtons.Controls.Add(btnOk);
				panelButtons.Controls.Add(btnDiscord);
				panelButtons.Controls.Add(btnCopy);

				int secondsLeft = 15;
				System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer
				{
					Interval = 1000
				};
				timer.Tick += (s, e) =>
				{
					secondsLeft--;
					lblCountdown.Text = $"ปิดอัตโนมัติใน {secondsLeft} วินาที";
					if (secondsLeft <= 0)
					{
						timer.Stop();
						dlg.Close();
					}
				};

				btnOk.Click += (s, e) =>
				{
					timer.Stop();
					dlg.Close();
				};

				btnCopy.Click += (s, e) =>
				{
					try
					{
						Clipboard.SetText(displayUuid);
					}
					catch (Exception ex)
					{
						Debug.WriteLine("Copy UUID failed: " + ex.Message);
					}
				};

				btnDiscord.Click += (s, e) =>
				{
					try
					{
						Process.Start(new ProcessStartInfo
						{
							FileName = "https://discord.gg/msHbnzpzTZ",
							UseShellExecute = true
						});
					}
					catch (Exception ex)
					{
						Debug.WriteLine("Open Discord failed: " + ex.Message);
					}
				};

				dlg.Controls.Add(panelButtons);
				dlg.Controls.Add(lblCountdown);
				dlg.Controls.Add(lblMsg);

				timer.Start();
				dlg.ShowDialog(this);
				timer.Stop();
			}

			try
			{
				this.Close();
			}
			catch
			{
			}

			if (deleteSelfAfterClose)
			{
				ScheduleSelfDeleteExecutable();
				Environment.Exit(0);
			}
		}

		private void SetActionButtonsEnabled(bool enabled)
		{
			Button[] buttons =
			{
				btnToggleStart, btnExp, btnBuff, btnMission, btnKaiRun,
				btnKaiStill, btnKaiMission, btnExpClan, btnKaiClan, btnReKey
			};
			foreach (var b in buttons)
			{
				if (b != null)
				{
					b.Enabled = enabled;
				}
			}
		}

		private class CustomerRecord
		{
			public string name { get; set; }
			public string plan { get; set; }
			public bool status { get; set; }
			public string program { get; set; }
			public string expiry { get; set; }
			public string createdAt { get; set; }
		}
		// ---------- End License / Firebase ----------

		private Button btnPause;

		// Token: 0x04000051 RID: 81
		private bool isPaused;

		// Token: 0x04000052 RID: 82
		private Bitmap latestScreen;

		// Token: 0x04000053 RID: 83
		private Bitmap latestScreencapture;

		// Token: 0x04000054 RID: 84
		private bool runActionSlasHead;

		// Token: 0x04000055 RID: 85
		private bool runActionSlasBoy;

		// Token: 0x04000056 RID: 86
		private bool isClosingPass;

		// Token: 0x04000057 RID: 87
		private CancellationTokenSource cancellationSource;

		// Token: 0x04000058 RID: 88
		private string checkboxStatePath = "checkbox_state.json";

		private Button btnToggleStart;

		private Button selectedSetButton = null;

		private Color defaultButtonBackColor = Color.White;

		// License/Firebase
		private readonly HttpClient httpClient = new HttpClient();
		private const string FirebaseDbUrlEncrypted = "xSNO97aMzngLsCSOm+Bx3Q3Iw1EV76O8hogxjLpgvftRdXfznxK8UJOFWwuvk3BzgUIdShanIuUpzV2GL+Hj0VTKh1mFww2H1MB78sHsegM=";
		private static readonly byte[] FirebaseDbKey = Convert.FromBase64String("DBtoACbLWiFjgwPTzaOk1jCDg3LaSy9fmZoBVDh19rg=");
		private static readonly byte[] FirebaseDbIv = Convert.FromBase64String("4nEd7j5mqqqv066dxbYyqg==");
		private static readonly string FirebaseDbUrl = DecryptFirebaseDbUrl();
		private const string FirebaseAuthToken = "";
		private DateTime? licenseExpiryUtc;
		private bool licenseIsMember;
		private Label lblLicenseStatus;
		private Label lblLicenseTime;
		private System.Windows.Forms.Timer licenseTimer;
		private string licenseUuidRaw;
	}
}




