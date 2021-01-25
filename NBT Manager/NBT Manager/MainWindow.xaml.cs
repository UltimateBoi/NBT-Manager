using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Navigation;

namespace NBT_Manager
{
	// Token: 0x02000003 RID: 3
	public partial class MainWindow : Window
	{
		// Token: 0x06000004 RID: 4 RVA: 0x00002093 File Offset: 0x00000293
		public MainWindow()
		{
			this.InitializeComponent();
			this.Init_Tab1();
			this.Init_Tab2();
			this.Init_Tab3();
			this.CheckForUpdate();
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000020C0 File Offset: 0x000002C0
		private void CheckForUpdate()
		{
			string text = new WebClient().DownloadString("https://raw.githubusercontent.com/nbtmanager/NBT-Manager/main/Version.txt");
			bool flag = text.Replace("\n", "").Replace("\r", "") != MainWindow.version;
			if (flag)
			{
				bool flag2 = MessageBox.Show("New version available! Download now?", "Update", MessageBoxButton.YesNo, MessageBoxImage.Asterisk) == MessageBoxResult.Yes;
				if (flag2)
				{
					Process.Start("https://github.com/nbtmanager/NBT-Manager");
				}
			}
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002133 File Offset: 0x00000333
		private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
		{
			Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
			e.Handled = true;
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002154 File Offset: 0x00000354
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Button button = sender as Button;
			bool flag = button != null;
			if (flag)
			{
				string text = button.Tag.ToString();
				Clipboard.SetText(text);
				button.FontWeight = FontWeights.Normal;
				button.BorderThickness = new Thickness(1.0);
			}
		}

		// Token: 0x06000008 RID: 8 RVA: 0x000021A8 File Offset: 0x000003A8
		private void Button_PreviewMouseDown(object sender, MouseButtonEventArgs e)
		{
			Button button = sender as Button;
			bool flag = button != null;
			if (flag)
			{
				button.FontWeight = FontWeights.Bold;
				button.BorderThickness = new Thickness(5.0);
			}
		}

		// Token: 0x06000009 RID: 9 RVA: 0x000021E8 File Offset: 0x000003E8
		private void ResetButton_Click(object sender, RoutedEventArgs e)
		{
			Array.Clear(MainWindow.Enchantment_List, 0, MainWindow.Enchantment_List.Length);
			foreach (object obj in this.Tab2Grid.Children)
			{
				UIElement uielement = (UIElement)obj;
				bool flag = uielement is CheckBox;
				if (flag)
				{
					(uielement as CheckBox).IsChecked = new bool?(false);
				}
			}
			Button button = sender as Button;
			bool flag2 = button != null;
			if (flag2)
			{
				button.FontWeight = FontWeights.Normal;
				button.BorderThickness = new Thickness(1.0);
			}
		}

		// Token: 0x0600000A RID: 10 RVA: 0x000022B4 File Offset: 0x000004B4
		private void CheckBox_Checked(object sender, RoutedEventArgs e)
		{
			string[,] array = new string[37, 3];
			array[0, 0] = "Aqua Affinity";
			array[0, 1] = "8";
			array[0, 2] = "1";
			array[1, 0] = "Bane of Arthropods";
			array[1, 1] = "11";
			array[1, 2] = "5";
			array[2, 0] = "Blast Protection";
			array[2, 1] = "3";
			array[2, 2] = "4";
			array[3, 0] = "Channeling";
			array[3, 1] = "32";
			array[3, 2] = "1";
			array[4, 0] = "Depth Strider";
			array[4, 1] = "7";
			array[4, 2] = "3";
			array[5, 0] = "Efficiency";
			array[5, 1] = "15";
			array[5, 2] = "5";
			array[6, 0] = "Feather Falling";
			array[6, 1] = "2";
			array[6, 2] = "4";
			array[7, 0] = "Fire Aspect";
			array[7, 1] = "13";
			array[7, 2] = "2";
			array[8, 0] = "Fire Protection";
			array[8, 1] = "1";
			array[8, 2] = "4";
			array[9, 0] = "Flame";
			array[9, 1] = "21";
			array[9, 2] = "1";
			array[10, 0] = "Fortune";
			array[10, 1] = "18";
			array[10, 2] = "3";
			array[11, 0] = "Frost Walker";
			array[11, 1] = "25";
			array[11, 2] = "2";
			array[12, 0] = "Impaling";
			array[12, 1] = "29";
			array[12, 2] = "5";
			array[13, 0] = "Infinity";
			array[13, 1] = "22";
			array[13, 2] = "1";
			array[14, 0] = "Knockback";
			array[14, 1] = "12";
			array[14, 2] = "2";
			array[15, 0] = "Loyalty";
			array[15, 1] = "31";
			array[15, 2] = "3";
			array[16, 0] = "Looting";
			array[16, 1] = "14";
			array[16, 2] = "3";
			array[17, 0] = "Luck of the Sea";
			array[17, 1] = "23";
			array[17, 2] = "3";
			array[18, 0] = "Lure";
			array[18, 1] = "24";
			array[18, 2] = "3";
			array[19, 0] = "Mending";
			array[19, 1] = "26";
			array[19, 2] = "1";
			array[20, 0] = "Multishot";
			array[20, 1] = "33";
			array[20, 2] = "1";
			array[21, 0] = "Piercing";
			array[21, 1] = "34";
			array[21, 2] = "4";
			array[22, 0] = "Power";
			array[22, 1] = "19";
			array[22, 2] = "5";
			array[23, 0] = "Projectile Protection";
			array[23, 1] = "4";
			array[23, 2] = "4";
			array[24, 0] = "Protection";
			array[24, 1] = "0";
			array[24, 2] = "4";
			array[25, 0] = "Punch";
			array[25, 1] = "20";
			array[25, 2] = "2";
			array[26, 0] = "Quick Charge";
			array[26, 1] = "35";
			array[26, 2] = "3";
			array[27, 0] = "Respiration";
			array[27, 1] = "6";
			array[27, 2] = "3";
			array[28, 0] = "Riptide";
			array[28, 1] = "30";
			array[28, 2] = "3";
			array[29, 0] = "Sharpness";
			array[29, 1] = "9";
			array[29, 2] = "5";
			array[30, 0] = "Silk Touch";
			array[30, 1] = "16";
			array[30, 2] = "1";
			array[31, 0] = "Smite";
			array[31, 1] = "10";
			array[31, 2] = "5";
			array[32, 0] = "Thorns";
			array[32, 1] = "5";
			array[32, 2] = "3";
			array[33, 0] = "Unbreaking";
			array[33, 1] = "17";
			array[33, 2] = "3";
			array[34, 0] = "Curse of Binding";
			array[34, 1] = "27";
			array[34, 2] = "1";
			array[35, 0] = "Curse of Vanishing";
			array[35, 1] = "28";
			array[35, 2] = "1";
			array[36, 0] = "Soul Speed";
			array[36, 1] = "36";
			array[36, 2] = "3";
			string[,] array2 = array;
			CheckBox checkBox = sender as CheckBox;
			bool flag = checkBox != null;
			if (flag)
			{
				int num = 0;
				for (int i = 0; i < MainWindow.Enchantment_List.GetLength(0); i++)
				{
					bool flag2 = MainWindow.Enchantment_List[i, 0] == null;
					if (flag2)
					{
						num = i;
						break;
					}
				}
				for (int j = 0; j < array2.GetLength(0); j++)
				{
					bool flag3 = checkBox.Content.ToString() == array2[j, 0];
					if (flag3)
					{
						MainWindow.Enchantment_List[num, 0] = array2[j, 0];
						MainWindow.Enchantment_List[num, 1] = array2[j, 1];
						MainWindow.Enchantment_List[num, 2] = array2[j, 2];
					}
				}
			}
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002994 File Offset: 0x00000B94
		private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
		{
			CheckBox checkBox = sender as CheckBox;
			bool flag = checkBox != null;
			if (flag)
			{
				for (int i = 0; i < MainWindow.Enchantment_List.GetLength(0); i++)
				{
					bool flag2 = checkBox.Content.ToString() == MainWindow.Enchantment_List[i, 0];
					if (flag2)
					{
						MainWindow.Enchantment_List[i, 0] = null;
						MainWindow.Enchantment_List[i, 1] = null;
						MainWindow.Enchantment_List[i, 2] = null;
					}
				}
			}
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002A1C File Offset: 0x00000C1C
		private void DefaultRadioButton_Checked(object sender, RoutedEventArgs e)
		{
			RadioButton radioButton = sender as RadioButton;
			bool flag = radioButton != null;
			if (flag)
			{
				bool flag2 = this.CustomTextBox != null && this.CustomSlider != null;
				if (flag2)
				{
					this.CustomTextBox.IsEnabled = false;
					this.CustomSlider.IsEnabled = false;
				}
			}
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002A70 File Offset: 0x00000C70
		private void CustomRadioButton_Checked(object sender, RoutedEventArgs e)
		{
			RadioButton radioButton = sender as RadioButton;
			bool flag = radioButton != null;
			if (flag)
			{
				bool flag2 = this.CustomTextBox != null && this.CustomSlider != null;
				if (flag2)
				{
					this.CustomTextBox.IsEnabled = true;
					this.CustomSlider.IsEnabled = true;
				}
			}
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002AC4 File Offset: 0x00000CC4
		private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
		{
			Regex regex = new Regex("[^0-9]+");
			e.Handled = regex.IsMatch(e.Text);
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002AF0 File Offset: 0x00000CF0
		private void GenerateButton_Click(object sender, RoutedEventArgs e)
		{
			Button button = sender as Button;
			bool flag = button != null;
			if (flag)
			{
				bool is32K = button.Name == "Generate32KButton";
				string text = this.GenerateEnchantmentList(is32K);
				Clipboard.SetText(text);
				button.FontWeight = FontWeights.Normal;
				button.BorderThickness = new Thickness(1.0);
			}
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002B50 File Offset: 0x00000D50
		private void ShulkerButton_Click(object sender, RoutedEventArgs e)
		{
			bool flag = this.ShulkerTextBox.Text == "" || this.ShulkerTextBox.Text == "<Enter data value here>";
			if (flag)
			{
				MessageBox.Show("Enter valid data value!", "Warning", MessageBoxButton.OK, MessageBoxImage.Exclamation);
			}
			else
			{
				Button button = sender as Button;
				bool flag2 = button != null;
				if (flag2)
				{
					string text = this.GenerateShulker(this.ShulkerTextBox.Text);
					Clipboard.SetText(text);
					button.FontWeight = FontWeights.Normal;
					button.BorderThickness = new Thickness(1.0);
				}
			}
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002BF4 File Offset: 0x00000DF4
		public string Convert(string str)
		{
			bool flag = str == "kit1";
			string result;
			if (flag)
			{
				result = "{Items:[{Count:1b,Damage:0s,Name:\"minecraft:netherite_helmet\",Slot:0b,WasPickedUp:0b,tag:{Damage:0,ench:[{id:0s,lvl:32767s},{id:8s,lvl:32767s},{id:6s,lvl:32767s},{id:17s,lvl:32767s},{id:26s,lvl:32767s},]}},{Count:1b,Damage:0s,Name:\"minecraft:netherite_chestplate\",Slot:1b,WasPickedUp:0b,tag:{Damage:0,ench:[{id:0s,lvl:32767s},{id:17s,lvl:32767s},{id:26s,lvl:32767s},]}},{Count:1b,Damage:0s,Name:\"minecraft:netherite_leggings\",Slot:2b,WasPickedUp:0b,tag:{Damage:0,ench:[{id:0s,lvl:32767s},{id:17s,lvl:32767s},{id:26s,lvl:32767s},]}},{Count:1b,Damage:0s,Name:\"minecraft:netherite_boots\",Slot:3b,WasPickedUp:0b,tag:{Damage:0,ench:[{id:0s,lvl:32767s},{id:2s,lvl:32767s},{id:7s,lvl:32767s},{id:36s,lvl:32767s},{id:17s,lvl:32767s},{id:26s,lvl:32767s},]}},{Count:1b,Damage:0s,Name:\"minecraft:elytra\",Slot:5b,WasPickedUp:0b,tag:{Damage:0,ench:[{id:17s,lvl:32767s},{id:26s,lvl:32767s},]}},{Count:1b,Damage:0s,Name:\"minecraft:shield\",Slot:6b,WasPickedUp:0b,tag:{Damage:0,ench:[{id:17s,lvl:32767s},{id:26s,lvl:32767s},]}},{Count:64b,Damage:0s,Name:\"minecraft:fireworks\",Slot:7b,WasPickedUp:0b,tag:{Fireworks:{Explosions:[],Flight:10b}}},{Count:1b,Damage:0s,Name:\"minecraft:totem\",Slot:8b,WasPickedUp:0b},{Count:1b,Damage:0s,Name:\"minecraft:netherite_sword\",Slot:9b,WasPickedUp:0b,tag:{Damage:0,ench:[{id:9s,lvl:32767s},{id:13s,lvl:32767s},{id:14s,lvl:32767s},{id:12s,lvl:32767s},{id:17s,lvl:32767s},{id:26s,lvl:32767s},]}},{Count:1b,Damage:0s,Name:\"minecraft:bow\",Slot:10b,WasPickedUp:0b,tag:{Damage:0,ench:[{id:19s,lvl:32767s},{id:20s,lvl:32767s},{id:21s,lvl:32767s},{id:22s,lvl:32767s},{id:17s,lvl:32767s},]}},{Count:1b,Damage:0s,Name:\"minecraft:crossbow\",Slot:11b,WasPickedUp:0b,tag:{Damage:0,ench:[{id:33s,lvl:32767s},{id:34s,lvl:32767s},{id:35s,lvl:3s},{id:17s,lvl:32767s},{id:26s,lvl:32767s},]}},{Count:1b,Damage:0s,Name:\"minecraft:trident\",Slot:12b,WasPickedUp:0b,tag:{Damage:0,ench:[{id:29s,lvl:32767s},{id:30s,lvl:3s},{id:17s,lvl:32767s},{id:26s,lvl:32767s},]}},{Count:64b,Damage:0s,Name:\"minecraft:appleenchanted\",Slot:14b,WasPickedUp:0b},{Count:64b,Damage:0s,Name:\"minecraft:appleenchanted\",Slot:15b,WasPickedUp:0b},{Count:64b,Damage:0s,Name:\"minecraft:fireworks\",Slot:16b,WasPickedUp:0b,tag:{Fireworks:{Explosions:[],Flight:10b}}},{Count:1b,Damage:0s,Name:\"minecraft:totem\",Slot:17b,WasPickedUp:0b},{Count:1b,Damage:0s,Name:\"minecraft:netherite_pickaxe\",Slot:18b,WasPickedUp:0b,tag:{Damage:0,ench:[{id:18s,lvl:32767s},{id:15s,lvl:32767s},{id:17s,lvl:32767s},{id:26s,lvl:32767s},]}},{Count:1b,Damage:0s,Name:\"minecraft:netherite_axe\",Slot:19b,WasPickedUp:0b,tag:{Damage:0,ench:[{id:9s,lvl:32767s},{id:18s,lvl:32767s},{id:15s,lvl:32767s},{id:17s,lvl:32767s},{id:26s,lvl:32767s},]}},{Count:1b,Damage:0s,Name:\"minecraft:netherite_shovel\",Slot:20b,WasPickedUp:0b,tag:{Damage:0,ench:[{id:18s,lvl:32767s},{id:15s,lvl:32767s},{id:17s,lvl:32767s},{id:26s,lvl:32767s},]}},{Count:1b,Damage:0s,Name:\"minecraft:netherite_hoe\",Slot:21b,WasPickedUp:0b,tag:{Damage:0,ench:[{id:18s,lvl:32767s},{id:15s,lvl:32767s},{id:17s,lvl:32767s},{id:26s,lvl:32767s},]}},{Count:64b,Damage:25s,Name:\"minecraft:arrow\",Slot:23b,WasPickedUp:0b},{Count:64b,Damage:25s,Name:\"minecraft:arrow\",Slot:24b,WasPickedUp:0b},{Count:64b,Damage:0s,Name:\"minecraft:fireworks\",Slot:25b,WasPickedUp:0b,tag:{Fireworks:{Explosions:[],Flight:10b}}},{Count:1b,Damage:0s,Name:\"minecraft:totem\",Slot:26b,WasPickedUp:0b}]}";
			}
			else
			{
				bool flag2 = str == "kit2";
				if (flag2)
				{
					result = "{Items:[{Count:1b,Damage:0s,Name:\"minecraft:netherite_helmet\",Slot:0b,WasPickedUp:0b,tag:{Damage:0,ench:[{id:1s,lvl:32767s},{id:2s,lvl:32767s},{id:3s,lvl:32767s},{id:4s,lvl:32767s},{id:5s,lvl:32767s},{id:6s,lvl:32767s},{id:7s,lvl:32767s},{id:8s,lvl:32767s},{id:9s,lvl:32767s},{id:10s,lvl:32767s},{id:11s,lvl:32767s},{id:12s,lvl:32767s},{id:13s,lvl:32767s},{id:14s,lvl:32767s},{id:15s,lvl:32767s},{id:16s,lvl:32767s},{id:17s,lvl:32767s},{id:18s,lvl:32767s},{id:19s,lvl:32767s},{id:20s,lvl:32767s},{id:21s,lvl:32767s},{id:22s,lvl:32767s},{id:23s,lvl:32767s},{id:24s,lvl:32767s},{id:25s,lvl:32767s},{id:26s,lvl:32767s},{id:27s,lvl:32767s},{id:28s,lvl:32767s},{id:29s,lvl:32767s},{id:30s,lvl:32767s},{id:31s,lvl:32767s},{id:32s,lvl:32767s},{id:33s,lvl:32767s},{id:34s,lvl:32767s},{id:35s,lvl:32767s},{id:36s,lvl:32767s}]}},{Count:1b,Damage:0s,Name:\"minecraft:netherite_chestplate\",Slot:1b,WasPickedUp:0b,tag:{Damage:0,ench:[{id:1s,lvl:32767s},{id:2s,lvl:32767s},{id:3s,lvl:32767s},{id:4s,lvl:32767s},{id:5s,lvl:32767s},{id:6s,lvl:32767s},{id:7s,lvl:32767s},{id:8s,lvl:32767s},{id:9s,lvl:32767s},{id:10s,lvl:32767s},{id:11s,lvl:32767s},{id:12s,lvl:32767s},{id:13s,lvl:32767s},{id:14s,lvl:32767s},{id:15s,lvl:32767s},{id:16s,lvl:32767s},{id:17s,lvl:32767s},{id:18s,lvl:32767s},{id:19s,lvl:32767s},{id:20s,lvl:32767s},{id:21s,lvl:32767s},{id:22s,lvl:32767s},{id:23s,lvl:32767s},{id:24s,lvl:32767s},{id:25s,lvl:32767s},{id:26s,lvl:32767s},{id:27s,lvl:32767s},{id:28s,lvl:32767s},{id:29s,lvl:32767s},{id:30s,lvl:32767s},{id:31s,lvl:32767s},{id:32s,lvl:32767s},{id:33s,lvl:32767s},{id:34s,lvl:32767s},{id:35s,lvl:32767s},{id:36s,lvl:32767s}]}},{Count:1b,Damage:0s,Name:\"minecraft:netherite_leggings\",Slot:2b,WasPickedUp:0b,tag:{Damage:0,ench:[{id:1s,lvl:32767s},{id:2s,lvl:32767s},{id:3s,lvl:32767s},{id:4s,lvl:32767s},{id:5s,lvl:32767s},{id:6s,lvl:32767s},{id:7s,lvl:32767s},{id:8s,lvl:32767s},{id:9s,lvl:32767s},{id:10s,lvl:32767s},{id:11s,lvl:32767s},{id:12s,lvl:32767s},{id:13s,lvl:32767s},{id:14s,lvl:32767s},{id:15s,lvl:32767s},{id:16s,lvl:32767s},{id:17s,lvl:32767s},{id:18s,lvl:32767s},{id:19s,lvl:32767s},{id:20s,lvl:32767s},{id:21s,lvl:32767s},{id:22s,lvl:32767s},{id:23s,lvl:32767s},{id:24s,lvl:32767s},{id:25s,lvl:32767s},{id:26s,lvl:32767s},{id:27s,lvl:32767s},{id:28s,lvl:32767s},{id:29s,lvl:32767s},{id:30s,lvl:32767s},{id:31s,lvl:32767s},{id:32s,lvl:32767s},{id:33s,lvl:32767s},{id:34s,lvl:32767s},{id:35s,lvl:32767s},{id:36s,lvl:32767s}]}},{Count:1b,Damage:0s,Name:\"minecraft:netherite_boots\",Slot:3b,WasPickedUp:0b,tag:{Damage:0,ench:[{id:1s,lvl:32767s},{id:2s,lvl:32767s},{id:3s,lvl:32767s},{id:4s,lvl:32767s},{id:5s,lvl:32767s},{id:6s,lvl:32767s},{id:7s,lvl:32767s},{id:8s,lvl:32767s},{id:9s,lvl:32767s},{id:10s,lvl:32767s},{id:11s,lvl:32767s},{id:12s,lvl:32767s},{id:13s,lvl:32767s},{id:14s,lvl:32767s},{id:15s,lvl:32767s},{id:16s,lvl:32767s},{id:17s,lvl:32767s},{id:18s,lvl:32767s},{id:19s,lvl:32767s},{id:20s,lvl:32767s},{id:21s,lvl:32767s},{id:22s,lvl:32767s},{id:23s,lvl:32767s},{id:24s,lvl:32767s},{id:25s,lvl:32767s},{id:26s,lvl:32767s},{id:27s,lvl:32767s},{id:28s,lvl:32767s},{id:29s,lvl:32767s},{id:30s,lvl:32767s},{id:31s,lvl:32767s},{id:32s,lvl:32767s},{id:33s,lvl:32767s},{id:34s,lvl:32767s},{id:35s,lvl:32767s},{id:36s,lvl:32767s}]}},{Count:1b,Damage:0s,Name:\"minecraft:elytra\",Slot:5b,WasPickedUp:0b,tag:{Damage:0,ench:[{id:1s,lvl:32767s},{id:2s,lvl:32767s},{id:3s,lvl:32767s},{id:4s,lvl:32767s},{id:5s,lvl:32767s},{id:6s,lvl:32767s},{id:7s,lvl:32767s},{id:8s,lvl:32767s},{id:9s,lvl:32767s},{id:10s,lvl:32767s},{id:11s,lvl:32767s},{id:12s,lvl:32767s},{id:13s,lvl:32767s},{id:14s,lvl:32767s},{id:15s,lvl:32767s},{id:16s,lvl:32767s},{id:17s,lvl:32767s},{id:18s,lvl:32767s},{id:19s,lvl:32767s},{id:20s,lvl:32767s},{id:21s,lvl:32767s},{id:22s,lvl:32767s},{id:23s,lvl:32767s},{id:24s,lvl:32767s},{id:25s,lvl:32767s},{id:26s,lvl:32767s},{id:27s,lvl:32767s},{id:28s,lvl:32767s},{id:29s,lvl:32767s},{id:30s,lvl:32767s},{id:31s,lvl:32767s},{id:32s,lvl:32767s},{id:33s,lvl:32767s},{id:34s,lvl:32767s},{id:35s,lvl:32767s},{id:36s,lvl:32767s}]}},{Count:1b,Damage:0s,Name:\"minecraft:shield\",Slot:6b,WasPickedUp:0b,tag:{Damage:0,ench:[{id:1s,lvl:32767s},{id:2s,lvl:32767s},{id:3s,lvl:32767s},{id:4s,lvl:32767s},{id:5s,lvl:32767s},{id:6s,lvl:32767s},{id:7s,lvl:32767s},{id:8s,lvl:32767s},{id:9s,lvl:32767s},{id:10s,lvl:32767s},{id:11s,lvl:32767s},{id:12s,lvl:32767s},{id:13s,lvl:32767s},{id:14s,lvl:32767s},{id:15s,lvl:32767s},{id:16s,lvl:32767s},{id:17s,lvl:32767s},{id:18s,lvl:32767s},{id:19s,lvl:32767s},{id:20s,lvl:32767s},{id:21s,lvl:32767s},{id:22s,lvl:32767s},{id:23s,lvl:32767s},{id:24s,lvl:32767s},{id:25s,lvl:32767s},{id:26s,lvl:32767s},{id:27s,lvl:32767s},{id:28s,lvl:32767s},{id:29s,lvl:32767s},{id:30s,lvl:32767s},{id:31s,lvl:32767s},{id:32s,lvl:32767s},{id:33s,lvl:32767s},{id:34s,lvl:32767s},{id:35s,lvl:32767s},{id:36s,lvl:32767s}]}},{Count:64b,Damage:0s,Name:\"minecraft:fireworks\",Slot:7b,WasPickedUp:0b,tag:{Fireworks:{Explosions:[],Flight:10b}}},{Count:1b,Damage:0s,Name:\"minecraft:totem\",Slot:8b,WasPickedUp:0b},{Count:1b,Damage:0s,Name:\"minecraft:netherite_sword\",Slot:9b,WasPickedUp:0b,tag:{Damage:0,ench:[{id:1s,lvl:32767s},{id:2s,lvl:32767s},{id:3s,lvl:32767s},{id:4s,lvl:32767s},{id:5s,lvl:32767s},{id:6s,lvl:32767s},{id:7s,lvl:32767s},{id:8s,lvl:32767s},{id:9s,lvl:32767s},{id:10s,lvl:32767s},{id:11s,lvl:32767s},{id:12s,lvl:32767s},{id:13s,lvl:32767s},{id:14s,lvl:32767s},{id:15s,lvl:32767s},{id:16s,lvl:32767s},{id:17s,lvl:32767s},{id:18s,lvl:32767s},{id:19s,lvl:32767s},{id:20s,lvl:32767s},{id:21s,lvl:32767s},{id:22s,lvl:32767s},{id:23s,lvl:32767s},{id:24s,lvl:32767s},{id:25s,lvl:32767s},{id:26s,lvl:32767s},{id:27s,lvl:32767s},{id:28s,lvl:32767s},{id:29s,lvl:32767s},{id:30s,lvl:32767s},{id:31s,lvl:32767s},{id:32s,lvl:32767s},{id:33s,lvl:32767s},{id:34s,lvl:32767s},{id:35s,lvl:32767s},{id:36s,lvl:32767s}]}},{Count:1b,Damage:0s,Name:\"minecraft:bow\",Slot:10b,WasPickedUp:0b,tag:{Damage:0,ench:[{id:1s,lvl:32767s},{id:2s,lvl:32767s},{id:3s,lvl:32767s},{id:4s,lvl:32767s},{id:5s,lvl:32767s},{id:6s,lvl:32767s},{id:7s,lvl:32767s},{id:8s,lvl:32767s},{id:9s,lvl:32767s},{id:10s,lvl:32767s},{id:11s,lvl:32767s},{id:12s,lvl:32767s},{id:13s,lvl:32767s},{id:14s,lvl:32767s},{id:15s,lvl:32767s},{id:16s,lvl:32767s},{id:17s,lvl:32767s},{id:18s,lvl:32767s},{id:19s,lvl:32767s},{id:20s,lvl:32767s},{id:21s,lvl:32767s},{id:22s,lvl:32767s},{id:23s,lvl:32767s},{id:24s,lvl:32767s},{id:25s,lvl:32767s},{id:26s,lvl:32767s},{id:27s,lvl:32767s},{id:28s,lvl:32767s},{id:29s,lvl:32767s},{id:30s,lvl:32767s},{id:31s,lvl:32767s},{id:32s,lvl:32767s},{id:33s,lvl:32767s},{id:34s,lvl:32767s},{id:35s,lvl:32767s},{id:36s,lvl:32767s}]}},{Count:1b,Damage:0s,Name:\"minecraft:crossbow\",Slot:11b,WasPickedUp:0b,tag:{Damage:0,ench:[{id:1s,lvl:32767s},{id:2s,lvl:32767s},{id:3s,lvl:32767s},{id:4s,lvl:32767s},{id:5s,lvl:32767s},{id:6s,lvl:32767s},{id:7s,lvl:32767s},{id:8s,lvl:32767s},{id:9s,lvl:32767s},{id:10s,lvl:32767s},{id:11s,lvl:32767s},{id:12s,lvl:32767s},{id:13s,lvl:32767s},{id:14s,lvl:32767s},{id:15s,lvl:32767s},{id:16s,lvl:32767s},{id:17s,lvl:32767s},{id:18s,lvl:32767s},{id:19s,lvl:32767s},{id:20s,lvl:32767s},{id:21s,lvl:32767s},{id:22s,lvl:32767s},{id:23s,lvl:32767s},{id:24s,lvl:32767s},{id:25s,lvl:32767s},{id:26s,lvl:32767s},{id:27s,lvl:32767s},{id:28s,lvl:32767s},{id:29s,lvl:32767s},{id:30s,lvl:32767s},{id:31s,lvl:32767s},{id:32s,lvl:32767s},{id:33s,lvl:32767s},{id:34s,lvl:32767s},{id:35s,lvl:32767s},{id:36s,lvl:32767s}]}},{Count:1b,Damage:0s,Name:\"minecraft:trident\",Slot:12b,WasPickedUp:0b,tag:{Damage:0,ench:[{id:1s,lvl:32767s},{id:2s,lvl:32767s},{id:3s,lvl:32767s},{id:4s,lvl:32767s},{id:5s,lvl:32767s},{id:6s,lvl:32767s},{id:7s,lvl:32767s},{id:8s,lvl:32767s},{id:9s,lvl:32767s},{id:10s,lvl:32767s},{id:11s,lvl:32767s},{id:12s,lvl:32767s},{id:13s,lvl:32767s},{id:14s,lvl:32767s},{id:15s,lvl:32767s},{id:16s,lvl:32767s},{id:17s,lvl:32767s},{id:18s,lvl:32767s},{id:19s,lvl:32767s},{id:20s,lvl:32767s},{id:21s,lvl:32767s},{id:22s,lvl:32767s},{id:23s,lvl:32767s},{id:24s,lvl:32767s},{id:25s,lvl:32767s},{id:26s,lvl:32767s},{id:27s,lvl:32767s},{id:28s,lvl:32767s},{id:29s,lvl:32767s},{id:30s,lvl:32767s},{id:31s,lvl:32767s},{id:32s,lvl:32767s},{id:33s,lvl:32767s},{id:34s,lvl:32767s},{id:35s,lvl:32767s},{id:36s,lvl:32767s}]}},{Count:64b,Damage:0s,Name:\"minecraft:appleenchanted\",Slot:14b,WasPickedUp:0b},{Count:64b,Damage:0s,Name:\"minecraft:appleenchanted\",Slot:15b,WasPickedUp:0b},{Count:64b,Damage:0s,Name:\"minecraft:fireworks\",Slot:16b,WasPickedUp:0b,tag:{Fireworks:{Explosions:[],Flight:10b}}},{Count:1b,Damage:0s,Name:\"minecraft:totem\",Slot:17b,WasPickedUp:0b},{Count:1b,Damage:0s,Name:\"minecraft:netherite_pickaxe\",Slot:18b,WasPickedUp:0b,tag:{Damage:0,ench:[{id:1s,lvl:32767s},{id:2s,lvl:32767s},{id:3s,lvl:32767s},{id:4s,lvl:32767s},{id:5s,lvl:32767s},{id:6s,lvl:32767s},{id:7s,lvl:32767s},{id:8s,lvl:32767s},{id:9s,lvl:32767s},{id:10s,lvl:32767s},{id:11s,lvl:32767s},{id:12s,lvl:32767s},{id:13s,lvl:32767s},{id:14s,lvl:32767s},{id:15s,lvl:32767s},{id:16s,lvl:32767s},{id:17s,lvl:32767s},{id:18s,lvl:32767s},{id:19s,lvl:32767s},{id:20s,lvl:32767s},{id:21s,lvl:32767s},{id:22s,lvl:32767s},{id:23s,lvl:32767s},{id:24s,lvl:32767s},{id:25s,lvl:32767s},{id:26s,lvl:32767s},{id:27s,lvl:32767s},{id:28s,lvl:32767s},{id:29s,lvl:32767s},{id:30s,lvl:32767s},{id:31s,lvl:32767s},{id:32s,lvl:32767s},{id:33s,lvl:32767s},{id:34s,lvl:32767s},{id:35s,lvl:32767s},{id:36s,lvl:32767s}]}},{Count:1b,Damage:0s,Name:\"minecraft:netherite_axe\",Slot:19b,WasPickedUp:0b,tag:{Damage:0,ench:[{id:1s,lvl:32767s},{id:2s,lvl:32767s},{id:3s,lvl:32767s},{id:4s,lvl:32767s},{id:5s,lvl:32767s},{id:6s,lvl:32767s},{id:7s,lvl:32767s},{id:8s,lvl:32767s},{id:9s,lvl:32767s},{id:10s,lvl:32767s},{id:11s,lvl:32767s},{id:12s,lvl:32767s},{id:13s,lvl:32767s},{id:14s,lvl:32767s},{id:15s,lvl:32767s},{id:16s,lvl:32767s},{id:17s,lvl:32767s},{id:18s,lvl:32767s},{id:19s,lvl:32767s},{id:20s,lvl:32767s},{id:21s,lvl:32767s},{id:22s,lvl:32767s},{id:23s,lvl:32767s},{id:24s,lvl:32767s},{id:25s,lvl:32767s},{id:26s,lvl:32767s},{id:27s,lvl:32767s},{id:28s,lvl:32767s},{id:29s,lvl:32767s},{id:30s,lvl:32767s},{id:31s,lvl:32767s},{id:32s,lvl:32767s},{id:33s,lvl:32767s},{id:34s,lvl:32767s},{id:35s,lvl:32767s},{id:36s,lvl:32767s}]}},{Count:1b,Damage:0s,Name:\"minecraft:netherite_shovel\",Slot:20b,WasPickedUp:0b,tag:{Damage:0,ench:[{id:1s,lvl:32767s},{id:2s,lvl:32767s},{id:3s,lvl:32767s},{id:4s,lvl:32767s},{id:5s,lvl:32767s},{id:6s,lvl:32767s},{id:7s,lvl:32767s},{id:8s,lvl:32767s},{id:9s,lvl:32767s},{id:10s,lvl:32767s},{id:11s,lvl:32767s},{id:12s,lvl:32767s},{id:13s,lvl:32767s},{id:14s,lvl:32767s},{id:15s,lvl:32767s},{id:16s,lvl:32767s},{id:17s,lvl:32767s},{id:18s,lvl:32767s},{id:19s,lvl:32767s},{id:20s,lvl:32767s},{id:21s,lvl:32767s},{id:22s,lvl:32767s},{id:23s,lvl:32767s},{id:24s,lvl:32767s},{id:25s,lvl:32767s},{id:26s,lvl:32767s},{id:27s,lvl:32767s},{id:28s,lvl:32767s},{id:29s,lvl:32767s},{id:30s,lvl:32767s},{id:31s,lvl:32767s},{id:32s,lvl:32767s},{id:33s,lvl:32767s},{id:34s,lvl:32767s},{id:35s,lvl:32767s},{id:36s,lvl:32767s}]}},{Count:1b,Damage:0s,Name:\"minecraft:netherite_hoe\",Slot:21b,WasPickedUp:0b,tag:{Damage:0,ench:[{id:1s,lvl:32767s},{id:2s,lvl:32767s},{id:3s,lvl:32767s},{id:4s,lvl:32767s},{id:5s,lvl:32767s},{id:6s,lvl:32767s},{id:7s,lvl:32767s},{id:8s,lvl:32767s},{id:9s,lvl:32767s},{id:10s,lvl:32767s},{id:11s,lvl:32767s},{id:12s,lvl:32767s},{id:13s,lvl:32767s},{id:14s,lvl:32767s},{id:15s,lvl:32767s},{id:16s,lvl:32767s},{id:17s,lvl:32767s},{id:18s,lvl:32767s},{id:19s,lvl:32767s},{id:20s,lvl:32767s},{id:21s,lvl:32767s},{id:22s,lvl:32767s},{id:23s,lvl:32767s},{id:24s,lvl:32767s},{id:25s,lvl:32767s},{id:26s,lvl:32767s},{id:27s,lvl:32767s},{id:28s,lvl:32767s},{id:29s,lvl:32767s},{id:30s,lvl:32767s},{id:31s,lvl:32767s},{id:32s,lvl:32767s},{id:33s,lvl:32767s},{id:34s,lvl:32767s},{id:35s,lvl:32767s},{id:36s,lvl:32767s}]}},{Count:64b,Damage:25s,Name:\"minecraft:arrow\",Slot:23b,WasPickedUp:0b},{Count:64b,Damage:25s,Name:\"minecraft:arrow\",Slot:24b,WasPickedUp:0b},{Count:64b,Damage:0s,Name:\"minecraft:fireworks\",Slot:25b,WasPickedUp:0b,tag:{Fireworks:{Explosions:[],Flight:10b}}},{Count:1b,Damage:0s,Name:\"minecraft:totem\",Slot:26b,WasPickedUp:0b}]}";
				}
				else
				{
					string text = "";
					string[] array = str.Split(new char[]
					{
						','
					});
					foreach (string text2 in array)
					{
						bool flag3 = text2 == "30" || text2 == "31" || text2 == "35";
						if (flag3)
						{
							text = text + "{id:" + text2 + "s,lvl:3s},";
						}
						else
						{
							text = text + "{id:" + text2 + "s,lvl:32767s},";
						}
					}
					result = text;
				}
			}
			return result;
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002CD4 File Offset: 0x00000ED4
		public string GenerateEnchantmentList(bool is32K)
		{
			string text = "";
			for (int i = 0; i < MainWindow.Enchantment_List.GetLength(0); i++)
			{
				bool flag = MainWindow.Enchantment_List[i, 0] != null;
				if (flag)
				{
					if (is32K)
					{
						text = text + "{id:" + MainWindow.Enchantment_List[i, 1] + "s,lvl:32767s},";
					}
					else
					{
						bool flag3;
						if (this.DefaultRadioButton.IsEnabled)
						{
							bool? isChecked = this.DefaultRadioButton.IsChecked;
							bool flag2 = true;
							flag3 = (isChecked.GetValueOrDefault() == flag2 & isChecked != null);
						}
						else
						{
							flag3 = false;
						}
						bool flag4 = flag3;
						if (flag4)
						{
							text = string.Concat(new string[]
							{
								text,
								"{id:",
								MainWindow.Enchantment_List[i, 1],
								"s,lvl:",
								MainWindow.Enchantment_List[i, 2],
								"s},"
							});
						}
						else
						{
							bool flag5;
							if (this.CustomRadioButton.IsEnabled)
							{
								bool? isChecked = this.CustomRadioButton.IsChecked;
								bool flag2 = true;
								flag5 = (isChecked.GetValueOrDefault() == flag2 & isChecked != null);
							}
							else
							{
								flag5 = false;
							}
							bool flag6 = flag5;
							if (flag6)
							{
								bool flag7 = this.CustomTextBox.Text != "";
								if (flag7)
								{
									text = string.Concat(new string[]
									{
										text,
										"{id:",
										MainWindow.Enchantment_List[i, 1],
										"s,lvl:",
										this.CustomTextBox.Text,
										"s},"
									});
								}
							}
						}
					}
				}
			}
			bool flag8;
			if (text == "")
			{
				bool? isChecked = this.GodModeCheckBox.IsChecked;
				bool flag2 = false;
				flag8 = (isChecked.GetValueOrDefault() == flag2 & isChecked != null);
			}
			else
			{
				flag8 = false;
			}
			bool flag9 = flag8;
			string result;
			if (flag9)
			{
				result = "";
			}
			else
			{
				bool flag10;
				if (text == "")
				{
					bool? isChecked = this.GodModeCheckBox.IsChecked;
					bool flag2 = true;
					flag10 = (isChecked.GetValueOrDefault() == flag2 & isChecked != null);
				}
				else
				{
					flag10 = false;
				}
				bool flag11 = flag10;
				if (flag11)
				{
					result = "{Unbreakable:1b}";
				}
				else
				{
					bool flag12;
					if (text != "")
					{
						bool? isChecked = this.GodModeCheckBox.IsChecked;
						bool flag2 = true;
						flag12 = (isChecked.GetValueOrDefault() == flag2 & isChecked != null);
					}
					else
					{
						flag12 = false;
					}
					bool flag13 = flag12;
					if (flag13)
					{
						result = "{Unbreakable:1b,ench:[" + text + "]}";
					}
					else
					{
						result = "{ench:[" + text + "]}";
					}
				}
			}
			return result;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002F60 File Offset: 0x00001160
		public string GenerateShulker(string dataValue)
		{
			string text = "";
			for (int i = 0; i < 27; i++)
			{
				text = string.Concat(new string[]
				{
					text,
					"{Count:64b,Damage:0s,Name:\"minecraft:",
					dataValue,
					"\",Slot:",
					i.ToString(),
					"b,WasPickedUp:0b},"
				});
			}
			bool flag = text == "";
			string result;
			if (flag)
			{
				result = "";
			}
			else
			{
				result = "{Items:[" + text + "]}";
			}
			return result;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002FEC File Offset: 0x000011EC
		public void Init_Tab1()
		{
			ToolTipService.SetShowDuration(this.Tab1HeaderGrid, 60000);
			this.Tab1HeaderGrid.ToolTip = "<HELP>\n\nItems with common 32k enchantments.\n\nClick to copy and then ' .give shulker_box 1 0 .nbt write '";
			string[,] array = new string[16, 3];
			array[0, 0] = "Helmet";
			array[0, 1] = "netherite_helmet";
			array[0, 2] = "0,8,6,17,26";
			array[1, 0] = "Chestplate";
			array[1, 1] = "netherite_chestplate";
			array[1, 2] = "0,17,26";
			array[2, 0] = "Leggings";
			array[2, 1] = "netherite_leggings";
			array[2, 2] = "0,17,26";
			array[3, 0] = "Boots";
			array[3, 1] = "netherite_boots";
			array[3, 2] = "0,2,7,36,17,26";
			array[4, 0] = "Sword";
			array[4, 1] = "netherite_sword";
			array[4, 2] = "9,13,14,12,17,26";
			array[5, 0] = "Bow";
			array[5, 1] = "bow";
			array[5, 2] = "19,20,21,22,17";
			array[6, 0] = "Crossbow";
			array[6, 1] = "crossbow";
			array[6, 2] = "33,34,35,17,26";
			array[7, 0] = "Trident";
			array[7, 1] = "trident";
			array[7, 2] = "29,30,17,26";
			array[8, 0] = "Pickaxe";
			array[8, 1] = "netherite_pickaxe";
			array[8, 2] = "18,15,17,26";
			array[9, 0] = "Axe";
			array[9, 1] = "netherite_axe";
			array[9, 2] = "9,18,15,17,26";
			array[10, 0] = "Shovel";
			array[10, 1] = "netherite_shovel";
			array[10, 2] = "18,15,17,26";
			array[11, 0] = "Hoe";
			array[11, 1] = "netherite_hoe";
			array[11, 2] = "18,15,17,26";
			array[12, 0] = "Elytra";
			array[12, 1] = "elytra";
			array[12, 2] = "17,26";
			array[13, 0] = "Shield";
			array[13, 1] = "shield";
			array[13, 2] = "17,26";
			array[14, 0] = "32K Kit 1";
			array[14, 1] = "";
			array[14, 2] = "kit1";
			array[15, 0] = "32K Kit 2";
			array[15, 1] = "";
			array[15, 2] = "kit2";
			string[,] array2 = array;
			int num = -1;
			foreach (RowDefinition rowDefinition in ((IEnumerable<RowDefinition>)this.Tab1Grid.RowDefinitions))
			{
				num++;
				int num2 = -1;
				foreach (ColumnDefinition columnDefinition in ((IEnumerable<ColumnDefinition>)this.Tab1Grid.ColumnDefinitions))
				{
					num2++;
					int num3 = num * this.Tab1Grid.ColumnDefinitions.Count + num2;
					Button button = new Button();
					button.FontSize = 18.0;
					button.Content = array2[num3, 0];
					Grid.SetColumn(button, num2);
					Grid.SetRow(button, num);
					bool flag = array2[num3, 0].Contains("32K");
					if (flag)
					{
						button.Tag = this.Convert(array2[num3, 2]);
					}
					else
					{
						button.Tag = string.Concat(new string[]
						{
							"{Items:[{Count:1b,Damage:0s,Name:\"minecraft:",
							array2[num3, 1],
							"\",Slot:0b,WasPickedUp:0b,tag:{Damage:0,ench:[",
							this.Convert(array2[num3, 2]),
							"]}}]}"
						});
					}
					button.Click += this.Button_Click;
					button.PreviewMouseDown += this.Button_PreviewMouseDown;
					button.ToolTip = ".give shulker_box 1 0 .nbt write";
					button.Margin = new Thickness(1.0);
					button.Background = new SolidColorBrush(Color.FromArgb(100, byte.MaxValue, 0, 0));
					button.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#99FF0000");
					this.Tab1Grid.Children.Add(button);
				}
			}
		}

		// Token: 0x06000015 RID: 21 RVA: 0x000034CC File Offset: 0x000016CC
		public void Init_Tab2()
		{
			ToolTipService.SetShowDuration(this.Tab2HeaderGrid, 60000);
			this.Tab2HeaderGrid.ToolTip = "<HELP>\n\nItems with custom enchantments.\n\n1. Select enchantment(s) from list\n2. Select maximum legit possible level or enter custom level\n3. Click on Generate Command/Generate 32K Command/Enchant All\n4. Select item ingame and then ' .nbt write '\n\nGenerate Command - will generate command with selected level and selected enchantment(s)\nGenerate 32K Command - will generate command with 32k level of seleced enchantment(s)\nEnchant all - will give all enchantments with 32k level";
			this.EnchantAllButton.Tag = "{ench:[{id:1s,lvl:32767s},{id:2s,lvl:32767s},{id:3s,lvl:32767s},{id:4s,lvl:32767s},{id:5s,lvl:32767s},{id:6s,lvl:32767s},{id:7s,lvl:32767s},{id:8s,lvl:32767s},{id:9s,lvl:32767s},{id:10s,lvl:32767s},{id:11s,lvl:32767s},{id:12s,lvl:32767s},{id:13s,lvl:32767s},{id:14s,lvl:32767s},{id:15s,lvl:32767s},{id:16s,lvl:32767s},{id:17s,lvl:32767s},{id:18s,lvl:32767s},{id:19s,lvl:32767s},{id:20s,lvl:32767s},{id:21s,lvl:32767s},{id:22s,lvl:32767s},{id:23s,lvl:32767s},{id:24s,lvl:32767s},{id:25s,lvl:32767s},{id:26s,lvl:32767s},{id:27s,lvl:32767s},{id:28s,lvl:32767s},{id:29s,lvl:32767s},{id:30s,lvl:32767s},{id:31s,lvl:32767s},{id:32s,lvl:32767s},{id:33s,lvl:32767s},{id:34s,lvl:32767s},{id:35s,lvl:32767s},{id:36s,lvl:32767s}]}";
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00003502 File Offset: 0x00001702
		public void Init_Tab3()
		{
			ToolTipService.SetShowDuration(this.Tab3HeaderGrid, 60000);
			this.Tab3HeaderGrid.ToolTip = "<HELP>\n\nGet shulker box full of items.\n\n1. Enter data value of item\n2. Get shulker box and then ' .give shulker_box 1 0 .nbt write '\n\n(Works for Items with no tags)";
			this.ShulkerTextBox.ToolTip = "DATA VALUE of item not DATA ID\n\n eg. diamond_block, netherite_ingot, enchanted_golden_apple";
		}

		// Token: 0x04000001 RID: 1
		public static string[,] Enchantment_List = new string[37, 3];

		// Token: 0x04000002 RID: 2
		public static string version = "1.2";

        private void Drag(object sender, MouseButtonEventArgs e)
		{
			if (e.ChangedButton == MouseButton.Left)
			{
				this.DragMove();
			}
		}

        private async void Exit(object sender, RoutedEventArgs e)
		{
			await Task.Delay(700);
			Application.Current.Shutdown();
		}

        private void Minimize(object sender, RoutedEventArgs e)
        {
			WindowState = WindowState.Minimized;
        }
    }
}
