using ScintillaNET;
using System.Drawing;
using WeifenLuo.WinFormsUI.Docking;

namespace Greg.Conga.WinUI
{
	public partial class EditorView : DockContent
	{
        const string basicWords = "select from where order by desc asc group";


        public EditorView()
		{
			InitializeComponent();

            this.scintilla.Margins[0].Width = 16;
            this.scintilla.StyleResetDefault();
            this.scintilla.Styles[Style.Default].Font = "Consolas";
            this.scintilla.Styles[Style.Default].Size = 10;
            this.scintilla.StyleClearAll();
            this.scintilla.Styles[Style.Sql.Word].ForeColor = Color.Blue;


            this.scintilla.Lexer = Lexer.Sql;
            this.scintilla.SetKeywords(0, basicWords);

            this.scintilla.CharAdded += scintilla_CharAdded;
		}

        private void scintilla_CharAdded(object sender, CharAddedEventArgs e)
        {
            // Find the word start
            var currentPos = this.scintilla.CurrentPosition;
            var wordStartPos = this.scintilla.WordStartPosition(currentPos, true);

            // Display the autocompletion list
            var lenEntered = currentPos - wordStartPos;
            if (lenEntered > 0)
            {
                if (!this.scintilla.AutoCActive)
                    this.scintilla.AutoCShow(lenEntered, basicWords);
            }
        }
    }
}
