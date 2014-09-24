using BotFramework;
using ExileBot;
using SlimDX.Direct3D9;
using System;
using System.Drawing;
namespace ExileHUD
{
	public class XPHRenderer : HUDPlugin
	{
		private long startXp;
		private DateTime startTime;
		private DateTime lastCalcTime;
		private bool hasStarted;
		private string curDisplayString = "0.00 XP/h";
		private string curTimeLeftString = "--h --m --s until level up";
		private Rect bounds = new Rect(0, 0, 0, 0);
		public Rect Bounds
		{
			get
			{
				if (!Settings.GetBool("XphDisplay"))
				{
					return new Rect(0, 0, 0, 0);
				}
				return this.bounds;
			}
			private set
			{
				this.bounds = value;
			}
		}
		public override void OnEnable()
		{
			this.poe.CurrentArea.OnAreaChange += new AreaChangeEvent(this.CurrentArea_OnAreaChange);
		}
		public override void OnDisable()
		{
		}
		private void CurrentArea_OnAreaChange(Area area)
		{
			this.startXp = this.poe.Player.GetComponent<Player>().XP;
			this.startTime = DateTime.Now;
			this.curTimeLeftString = "--h --m --s until level up";
		}
		public override void Render(RenderingContext rc)
		{
			if (!Settings.GetBool("XphDisplay") || (this.poe.Player != null && this.poe.Player.GetComponent<Player>().Level >= 100))
			{
				return;
			}
			if (!this.hasStarted)
			{
				this.startXp = this.poe.Player.GetComponent<Player>().XP;
				this.startTime = DateTime.Now;
				this.lastCalcTime = DateTime.Now;
				this.hasStarted = true;
				return;
			}
			if ((DateTime.Now - this.lastCalcTime).TotalSeconds > 1.0)
			{
				long num = this.poe.Player.GetComponent<Player>().XP - this.startXp;
				float num2 = (float)((double)num / (DateTime.Now - this.startTime).TotalHours);
				if ((double)num2 > 1000000.0)
				{
					this.curDisplayString = ((double)num2 / 1000000.0).ToString("0.00") + "M XP/h";
				}
				else
				{
					if ((double)num2 > 1000.0)
					{
						this.curDisplayString = ((double)num2 / 1000.0).ToString("0.00") + "K XP/h";
					}
					else
					{
						this.curDisplayString = num2.ToString("0.00") + " XP/h";
					}
				}
				int level = this.poe.Player.GetComponent<Player>().Level;
				if (level + 1 >= Constants.PlayerXpLevels.Length)
				{
					return;
				}
				long num3 = (long)((ulong)Constants.PlayerXpLevels[level + 1] - (ulong)this.poe.Player.GetComponent<Player>().XP);
				if (num2 > 1f)
				{
					int num4 = (int)((float)num3 / num2 * 3600f);
					int num5 = num4 / 60;
					int num6 = num5 / 60;
					this.curTimeLeftString = string.Concat(new object[]
					{
						num6,
						"h ",
						num5 % 60,
						"m ",
						num4 % 60,
						"s until level up"
					});
				}
				this.lastCalcTime = DateTime.Now;
			}
			int @int = Settings.GetInt("XphDisplay.FontSize");
			int int2 = Settings.GetInt("XphDisplay.BgAlpha");
			Rect clientRect = this.poe.Internal.IngameState.IngameUi.Minimap.SmallMinimap.GetClientRect();
			Vec2 vec = new Vec2(clientRect.X - 10, clientRect.Y + 5);
			int num7 = 0;
			Vec2 vec2 = rc.AddTextWithHeight(new Vec2(vec.X, vec.Y), this.curDisplayString, Color.White, @int, DrawTextFormat.Right);
			num7 += vec2.Y;
			Vec2 vec3 = rc.AddTextWithHeight(new Vec2(vec.X, vec.Y + num7), this.curTimeLeftString, Color.White, @int, DrawTextFormat.Right);
			num7 += vec3.Y;
			int val = Math.Max(vec2.X, vec3.X) + 10;
			int num8 = Math.Max(val, Math.Max(clientRect.W, this.overlay.PreloadAlert.Bounds.W));
			Rect rect = new Rect(vec.X - num8 + 5, vec.Y - 5, num8, num7 + 10);
			this.Bounds = rect;
			rc.AddBox(rect, Color.FromArgb(int2, 1, 1, 1));
		}
	}
}