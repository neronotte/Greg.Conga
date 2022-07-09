using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Greg.Conga.WinUI
{
	public partial class IntellisensePanel : UserControl
	{
		private Control containerControl;
		private TextBox textControl;
		private Point positionRelativeToRoot;

		private readonly int yOffset = 18;

		public IntellisensePanel()
		{
			InitializeComponent();
			this.Visible = false;
		}

		public Control ContainerControl
		{
			get { return this.containerControl; }
			set
			{
				if (ReferenceEquals(this.containerControl, value)) return;

				this.UnbindLogic();
				this.containerControl = value;
				this.BindLogic();
			}
		}

		public TextBox TextControl
		{
			get { return this.textControl; }
			set
			{
				if (ReferenceEquals(this.textControl, value)) return;

				this.UnbindLogic();
				this.textControl = value;
				this.BindLogic();
			}
		}

		public string[] Fields { get; set; }

		private void BindLogic()
		{
			if (this.containerControl == null || this.textControl == null) return;

			this.positionRelativeToRoot = this.GetPositionRelativeToRoot(this.textControl, this.containerControl);
			this.textControl.KeyUp += this.OnTextCotrolKeyUp;
			this.textControl.KeyUp += this.OnWhereKeyUp;
			this.textControl.LostFocus += this.OnTextControlLostFocus;
			
		}

		private void UnbindLogic()
		{
			this.positionRelativeToRoot = new Point(0, 0);
			if (this.textControl == null) return;

			this.textControl.KeyUp -= this.OnTextCotrolKeyUp;
			this.textControl.KeyUp -= this.OnWhereKeyUp;
			this.textControl.LostFocus -= this.OnTextControlLostFocus;
		}

		private void OnTextControlLostFocus(object sender, EventArgs e)
		{
			this.Visible = false;
		}

		private void OnTextCotrolKeyUp(object sender, KeyEventArgs e)
		{
			if (this.Fields == null) return;

			var caretPos = this.textControl.SelectionStart + this.textControl.SelectionLength;

			var isAtTheEnd = caretPos == this.textControl.Text.Length;

			if (isAtTheEnd) caretPos--;

			var position = this.textControl.GetPositionFromCharIndex(caretPos);

			var xOffset = isAtTheEnd ? 6 : 0;


			this.lblPosition.Text = $"x:{position.X}, y:{position.Y}";
			this.Left = position.X + this.positionRelativeToRoot.X + xOffset;
			this.Top = position.Y + this.positionRelativeToRoot.Y + yOffset;
			this.Visible = true;
		}

		private Point GetPositionRelativeToRoot(Control control, Control root)
		{
			if (control == root) return new Point(0, 0);
			if (control.Parent == null) return new Point(control.Left, control.Top);

			var parentOffset = this.GetPositionRelativeToRoot(control.Parent, root);

			return new Point(
				control.Left + parentOffset.X,
				control.Top + parentOffset.Y
			);
		}

		private void OnWhereKeyUp(object sender, KeyEventArgs e)
		{
			this.flow.SuspendLayout();

			this.flow.Controls.Clear();
			var text = this.textControl.Text;

			if (!GetWord(text, this.textControl.SelectionStart, out int startIndex, out int length))
			{
				this.flow.ResumeLayout();
				return;
			}

			if (length < Properties.Settings.Default.NumberOfCharsToStartIntellisense)
			{
				this.flow.ResumeLayout();
				return;
			}

			var word = text.Substring(startIndex, length);

			var foundFields = this.Fields?
				.Where(x => x.IndexOf(word, StringComparison.OrdinalIgnoreCase) >= 0)
				.Take(10)
				.ToArray() ?? Array.Empty<string>();

			foreach (var f in foundFields)
			{
				var l = new LinkLabel();
				l.Click += (s, e1) =>
				{
					this.textControl.Text = text.Substring(0, startIndex) + f + text.Substring(startIndex + length);
				};
				l.Text = f;
				l.Margin = new Padding(0, 0, 20, 20);
				l.AutoSize = true;
				this.flow.Controls.Add(l);
			}
			this.flow.ResumeLayout();
		}

		private bool GetWord(string text, int selectionStart, out int startIndex, out int length)
		{
			startIndex = -1;
			length = -1;

			if (text == null) return false;
			if (selectionStart < 1) return false;

			const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_";

			char currentChar;
			startIndex = selectionStart;
			do
			{
				startIndex--;
				currentChar = text[startIndex];
			}
			while (validChars.Contains(currentChar) && startIndex > 0);

			if (!validChars.Contains(currentChar))
				startIndex++;

			if (selectionStart == text.Length)
			{
				length = text.Length - startIndex;
				return true;
			}

			int endIndex;
			length = 0;
			do
			{
				endIndex = startIndex + length;
				currentChar = text[endIndex];
				length++;
			}
			while (validChars.Contains(currentChar) && endIndex < text.Length - 1);

			if (!validChars.Contains(currentChar))
				length--;

			return true;
		}
	}
}
