
// This file has been generated by the GUI designer. Do not modify.
namespace Moscrif.IDE.Controls
{
	public partial class FindReplaceControl
	{
		private global::Gtk.VBox vbox1;
		private global::Gtk.HBox hbox1;
		private global::Gtk.Label label1;
		private global::Gtk.Entry entrExpresion;
		private global::Gtk.Button btnFind;
		private global::Gtk.HBox hbox3;
		private global::Gtk.Label label2;
		private global::Gtk.Entry entrReplaceText;
		private global::Gtk.HPaned hpaned1;
		private global::Gtk.Button btnReplace;
		private global::Gtk.Button btnReplaceAll;
		private global::Gtk.HBox hbox2;
		private global::Gtk.Frame frame1;
		private global::Gtk.Alignment GtkAlignment;
		private global::Gtk.VBox vbox2;
		private global::Gtk.CheckButton chbWholeWords;
		private global::Gtk.CheckButton chbCaseSensitive;
		private global::Gtk.Label GtkLabel5;
		private global::Gtk.Frame frame2;
		private global::Gtk.VBox vbox3;
		private global::Gtk.ComboBox cbPlace;
		private global::Gtk.Label GtkLabel6;
		
		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget Moscrif.IDE.Controls.FindReplaceControl
			global::Stetic.BinContainer.Attach (this);
			this.Name = "Moscrif.IDE.Controls.FindReplaceControl";
			// Container child Moscrif.IDE.Controls.FindReplaceControl.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox ();
			this.vbox1.Name = "vbox1";
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.label1 = new global::Gtk.Label ();
			this.label1.Name = "label1";
			this.label1.Xalign = 1F;
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString ("Find");
			this.hbox1.Add (this.label1);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.label1]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			w1.Padding = ((uint)(5));
			// Container child hbox1.Gtk.Box+BoxChild
			this.entrExpresion = new global::Gtk.Entry ();
			this.entrExpresion.CanFocus = true;
			this.entrExpresion.Name = "entrExpresion";
			this.entrExpresion.IsEditable = true;
			this.entrExpresion.InvisibleChar = '●';
			this.hbox1.Add (this.entrExpresion);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.entrExpresion]));
			w2.Position = 1;
			// Container child hbox1.Gtk.Box+BoxChild
			this.btnFind = new global::Gtk.Button ();
			this.btnFind.CanFocus = true;
			this.btnFind.Name = "btnFind";
			this.btnFind.UseUnderline = true;
			this.btnFind.Label = global::Mono.Unix.Catalog.GetString ("_Find");
			this.hbox1.Add (this.btnFind);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.btnFind]));
			w3.Position = 2;
			w3.Expand = false;
			w3.Fill = false;
			w3.Padding = ((uint)(5));
			this.vbox1.Add (this.hbox1);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox1]));
			w4.Position = 0;
			w4.Expand = false;
			w4.Fill = false;
			w4.Padding = ((uint)(5));
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox3 = new global::Gtk.HBox ();
			this.hbox3.Name = "hbox3";
			this.hbox3.Spacing = 6;
			// Container child hbox3.Gtk.Box+BoxChild
			this.label2 = new global::Gtk.Label ();
			this.label2.Name = "label2";
			this.label2.Xalign = 1F;
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString ("Replace");
			this.hbox3.Add (this.label2);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.label2]));
			w5.Position = 0;
			w5.Expand = false;
			w5.Fill = false;
			w5.Padding = ((uint)(5));
			// Container child hbox3.Gtk.Box+BoxChild
			this.entrReplaceText = new global::Gtk.Entry ();
			this.entrReplaceText.CanFocus = true;
			this.entrReplaceText.Name = "entrReplaceText";
			this.entrReplaceText.IsEditable = true;
			this.entrReplaceText.InvisibleChar = '●';
			this.hbox3.Add (this.entrReplaceText);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.entrReplaceText]));
			w6.Position = 1;
			// Container child hbox3.Gtk.Box+BoxChild
			this.hpaned1 = new global::Gtk.HPaned ();
			this.hpaned1.CanFocus = true;
			this.hpaned1.Name = "hpaned1";
			this.hpaned1.Position = 51;
			// Container child hpaned1.Gtk.Paned+PanedChild
			this.btnReplace = new global::Gtk.Button ();
			this.btnReplace.CanFocus = true;
			this.btnReplace.Name = "btnReplace";
			this.btnReplace.UseUnderline = true;
			this.btnReplace.Label = global::Mono.Unix.Catalog.GetString ("Replace");
			this.hpaned1.Add (this.btnReplace);
			global::Gtk.Paned.PanedChild w7 = ((global::Gtk.Paned.PanedChild)(this.hpaned1 [this.btnReplace]));
			w7.Resize = false;
			// Container child hpaned1.Gtk.Paned+PanedChild
			this.btnReplaceAll = new global::Gtk.Button ();
			this.btnReplaceAll.CanFocus = true;
			this.btnReplaceAll.Name = "btnReplaceAll";
			this.btnReplaceAll.UseUnderline = true;
			this.btnReplaceAll.Label = global::Mono.Unix.Catalog.GetString ("Replace All");
			this.hpaned1.Add (this.btnReplaceAll);
			this.hbox3.Add (this.hpaned1);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.hpaned1]));
			w9.Position = 2;
			w9.Expand = false;
			w9.Fill = false;
			w9.Padding = ((uint)(5));
			this.vbox1.Add (this.hbox3);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox3]));
			w10.Position = 1;
			w10.Expand = false;
			w10.Fill = false;
			w10.Padding = ((uint)(5));
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox2 = new global::Gtk.HBox ();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.frame1 = new global::Gtk.Frame ();
			this.frame1.Name = "frame1";
			this.frame1.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child frame1.Gtk.Container+ContainerChild
			this.GtkAlignment = new global::Gtk.Alignment (0F, 0F, 1F, 1F);
			this.GtkAlignment.Name = "GtkAlignment";
			this.GtkAlignment.LeftPadding = ((uint)(12));
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			this.vbox2 = new global::Gtk.VBox ();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.chbWholeWords = new global::Gtk.CheckButton ();
			this.chbWholeWords.CanFocus = true;
			this.chbWholeWords.Name = "chbWholeWords";
			this.chbWholeWords.Label = global::Mono.Unix.Catalog.GetString ("_Whole Words Only");
			this.chbWholeWords.DrawIndicator = true;
			this.chbWholeWords.UseUnderline = true;
			this.vbox2.Add (this.chbWholeWords);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.chbWholeWords]));
			w11.Position = 0;
			w11.Expand = false;
			w11.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.chbCaseSensitive = new global::Gtk.CheckButton ();
			this.chbCaseSensitive.CanFocus = true;
			this.chbCaseSensitive.Name = "chbCaseSensitive";
			this.chbCaseSensitive.Label = global::Mono.Unix.Catalog.GetString ("_Case Sensitive");
			this.chbCaseSensitive.DrawIndicator = true;
			this.chbCaseSensitive.UseUnderline = true;
			this.vbox2.Add (this.chbCaseSensitive);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.chbCaseSensitive]));
			w12.Position = 1;
			w12.Expand = false;
			w12.Fill = false;
			this.GtkAlignment.Add (this.vbox2);
			this.frame1.Add (this.GtkAlignment);
			this.GtkLabel5 = new global::Gtk.Label ();
			this.GtkLabel5.Name = "GtkLabel5";
			this.GtkLabel5.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>Settings</b>");
			this.GtkLabel5.UseMarkup = true;
			this.frame1.LabelWidget = this.GtkLabel5;
			this.hbox2.Add (this.frame1);
			global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.frame1]));
			w15.Position = 0;
			w15.Expand = false;
			w15.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.frame2 = new global::Gtk.Frame ();
			this.frame2.Name = "frame2";
			this.frame2.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child frame2.Gtk.Container+ContainerChild
			this.vbox3 = new global::Gtk.VBox ();
			this.vbox3.Name = "vbox3";
			this.vbox3.Spacing = 6;
			// Container child vbox3.Gtk.Box+BoxChild
			this.cbPlace = global::Gtk.ComboBox.NewText ();
			this.cbPlace.AppendText (global::Mono.Unix.Catalog.GetString ("Current Document"));
			this.cbPlace.AppendText (global::Mono.Unix.Catalog.GetString ("All Open Document"));
			this.cbPlace.AppendText (global::Mono.Unix.Catalog.GetString ("Current Project"));
			this.cbPlace.AppendText (global::Mono.Unix.Catalog.GetString ("All Open Project"));
			this.cbPlace.Name = "cbPlace";
			this.vbox3.Add (this.cbPlace);
			global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.cbPlace]));
			w16.Position = 0;
			w16.Expand = false;
			w16.Fill = false;
			this.frame2.Add (this.vbox3);
			this.GtkLabel6 = new global::Gtk.Label ();
			this.GtkLabel6.Name = "GtkLabel6";
			this.GtkLabel6.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>Place</b>");
			this.GtkLabel6.UseMarkup = true;
			this.frame2.LabelWidget = this.GtkLabel6;
			this.hbox2.Add (this.frame2);
			global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.frame2]));
			w18.Position = 1;
			w18.Expand = false;
			w18.Fill = false;
			this.vbox1.Add (this.hbox2);
			global::Gtk.Box.BoxChild w19 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox2]));
			w19.Position = 2;
			w19.Padding = ((uint)(5));
			this.Add (this.vbox1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.hbox3.Hide ();
			this.frame2.Hide ();
			this.Hide ();
			this.entrExpresion.Changed += new global::System.EventHandler (this.OnEntrExpresionChanged);
			this.entrExpresion.KeyReleaseEvent += new global::Gtk.KeyReleaseEventHandler (this.OnEntrExpresionKeyReleaseEvent);
			this.btnFind.Clicked += new global::System.EventHandler (this.OnButton1Clicked);
			this.entrReplaceText.KeyReleaseEvent += new global::Gtk.KeyReleaseEventHandler (this.OnEntrReplaceTextKeyReleaseEvent);
			this.btnReplace.Clicked += new global::System.EventHandler (this.OnBtnReplaceClicked);
			this.btnReplaceAll.Clicked += new global::System.EventHandler (this.OnBtnReplaceAllClicked);
			this.chbWholeWords.Toggled += new global::System.EventHandler (this.OnChbWholeWordsToggled);
			this.chbCaseSensitive.Toggled += new global::System.EventHandler (this.OnChbCaseSensitiveToggled);
			this.cbPlace.Changed += new global::System.EventHandler (this.OnCbPlaceChanged);
		}
	}
}