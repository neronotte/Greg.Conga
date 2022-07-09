using System.Drawing;

namespace Greg.Conga.WinUI
{
	public static class ColorPalette
	{
		public static Color SuccessBackground  => Color.FromArgb(198, 239, 206);
		public static Color WarningBackground => Color.FromArgb(255, 235, 156);
		public static Color ErrorBackground => Color.FromArgb(255, 199, 206);

		public static Color SuccessForeground => Color.FromArgb(0, 97, 0);
		public static Color WarningForeground => Color.FromArgb(156, 87, 0);
		public static Color ErrorForeground => Color.FromArgb(156, 0, 6);
	}
}
