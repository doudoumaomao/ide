
// This file has been generated by the GUI designer. Do not modify.
namespace Moscrif.IDE.Controls.SqlLite
{
	public partial class SqlLiteEditTable
	{
		private global::Gtk.VBox vbox2;
		private global::Gtk.HBox hbox1;
		private global::Gtk.Label label1;
		private global::Gtk.Entry entrTableName;
		private global::Gtk.Button btnRenameTable;
		private global::Gtk.Frame frame1;
		private global::Gtk.Alignment GtkAlignment2;
		private global::Gtk.VBox vbox3;
		private global::Gtk.ScrolledWindow GtkScrolledWindow;
		private global::Gtk.TreeView tvFields;
		private global::Gtk.HButtonBox hbuttonbox2;
		private global::Gtk.Button btnDeleteField;
		private global::Gtk.Button btnCreateField;
		private global::Gtk.Button btnEditField;
		private global::Gtk.Label GtkLabel4;
		private global::Gtk.Button buttonOk;
		
		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget Moscrif.IDE.Controls.SqlLite.SqlLiteEditTable
			this.Name = "Moscrif.IDE.Controls.SqlLite.SqlLiteEditTable";
			this.WindowPosition = ((global::Gtk.WindowPosition)(1));
			// Internal child Moscrif.IDE.Controls.SqlLite.SqlLiteEditTable.VBox
			global::Gtk.VBox w1 = this.VBox;
			w1.Name = "dialog1_VBox";
			w1.BorderWidth = ((uint)(2));
			// Container child dialog1_VBox.Gtk.Box+BoxChild
			this.vbox2 = new global::Gtk.VBox ();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.label1 = new global::Gtk.Label ();
			this.label1.Name = "label1";
			this.label1.Xalign = 1F;
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString ("Table Name :");
			this.hbox1.Add (this.label1);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.label1]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			w2.Padding = ((uint)(5));
			// Container child hbox1.Gtk.Box+BoxChild
			this.entrTableName = new global::Gtk.Entry ();
			this.entrTableName.Sensitive = false;
			this.entrTableName.CanFocus = true;
			this.entrTableName.Name = "entrTableName";
			this.entrTableName.IsEditable = true;
			this.entrTableName.InvisibleChar = '●';
			this.hbox1.Add (this.entrTableName);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.entrTableName]));
			w3.Position = 1;
			// Container child hbox1.Gtk.Box+BoxChild
			this.btnRenameTable = new global::Gtk.Button ();
			this.btnRenameTable.CanFocus = true;
			this.btnRenameTable.Name = "btnRenameTable";
			this.btnRenameTable.UseUnderline = true;
			this.btnRenameTable.Label = global::Mono.Unix.Catalog.GetString ("Rename Table");
			this.hbox1.Add (this.btnRenameTable);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.btnRenameTable]));
			w4.Position = 2;
			w4.Expand = false;
			w4.Fill = false;
			this.vbox2.Add (this.hbox1);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.hbox1]));
			w5.Position = 0;
			w5.Expand = false;
			w5.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.frame1 = new global::Gtk.Frame ();
			this.frame1.Name = "frame1";
			// Container child frame1.Gtk.Container+ContainerChild
			this.GtkAlignment2 = new global::Gtk.Alignment (0F, 0F, 1F, 1F);
			this.GtkAlignment2.Name = "GtkAlignment2";
			this.GtkAlignment2.LeftPadding = ((uint)(12));
			// Container child GtkAlignment2.Gtk.Container+ContainerChild
			this.vbox3 = new global::Gtk.VBox ();
			this.vbox3.Name = "vbox3";
			this.vbox3.Spacing = 6;
			// Container child vbox3.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.tvFields = new global::Gtk.TreeView ();
			this.tvFields.CanFocus = true;
			this.tvFields.Name = "tvFields";
			this.GtkScrolledWindow.Add (this.tvFields);
			this.vbox3.Add (this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.GtkScrolledWindow]));
			w7.Position = 0;
			// Container child vbox3.Gtk.Box+BoxChild
			this.hbuttonbox2 = new global::Gtk.HButtonBox ();
			this.hbuttonbox2.Name = "hbuttonbox2";
			this.hbuttonbox2.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(4));
			// Container child hbuttonbox2.Gtk.ButtonBox+ButtonBoxChild
			this.btnDeleteField = new global::Gtk.Button ();
			this.btnDeleteField.CanFocus = true;
			this.btnDeleteField.Name = "btnDeleteField";
			this.btnDeleteField.UseUnderline = true;
			this.btnDeleteField.Label = global::Mono.Unix.Catalog.GetString ("Delete");
			this.hbuttonbox2.Add (this.btnDeleteField);
			global::Gtk.ButtonBox.ButtonBoxChild w8 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.hbuttonbox2 [this.btnDeleteField]));
			w8.Expand = false;
			w8.Fill = false;
			// Container child hbuttonbox2.Gtk.ButtonBox+ButtonBoxChild
			this.btnCreateField = new global::Gtk.Button ();
			this.btnCreateField.CanFocus = true;
			this.btnCreateField.Name = "btnCreateField";
			this.btnCreateField.UseUnderline = true;
			this.btnCreateField.Label = global::Mono.Unix.Catalog.GetString ("Create");
			this.hbuttonbox2.Add (this.btnCreateField);
			global::Gtk.ButtonBox.ButtonBoxChild w9 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.hbuttonbox2 [this.btnCreateField]));
			w9.Position = 1;
			w9.Expand = false;
			w9.Fill = false;
			// Container child hbuttonbox2.Gtk.ButtonBox+ButtonBoxChild
			this.btnEditField = new global::Gtk.Button ();
			this.btnEditField.CanFocus = true;
			this.btnEditField.Name = "btnEditField";
			this.btnEditField.UseUnderline = true;
			this.btnEditField.Label = global::Mono.Unix.Catalog.GetString ("Edit");
			this.hbuttonbox2.Add (this.btnEditField);
			global::Gtk.ButtonBox.ButtonBoxChild w10 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.hbuttonbox2 [this.btnEditField]));
			w10.Position = 2;
			w10.Expand = false;
			w10.Fill = false;
			this.vbox3.Add (this.hbuttonbox2);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.hbuttonbox2]));
			w11.Position = 1;
			w11.Expand = false;
			w11.Fill = false;
			this.GtkAlignment2.Add (this.vbox3);
			this.frame1.Add (this.GtkAlignment2);
			this.GtkLabel4 = new global::Gtk.Label ();
			this.GtkLabel4.Name = "GtkLabel4";
			this.GtkLabel4.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>Define fields</b>");
			this.GtkLabel4.UseMarkup = true;
			this.frame1.LabelWidget = this.GtkLabel4;
			this.vbox2.Add (this.frame1);
			global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.frame1]));
			w14.Position = 1;
			w1.Add (this.vbox2);
			global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(w1 [this.vbox2]));
			w15.Position = 0;
			// Internal child Moscrif.IDE.Controls.SqlLite.SqlLiteEditTable.ActionArea
			global::Gtk.HButtonBox w16 = this.ActionArea;
			w16.Name = "dialog1_ActionArea";
			w16.Spacing = 10;
			w16.BorderWidth = ((uint)(5));
			w16.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(4));
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonOk = new global::Gtk.Button ();
			this.buttonOk.CanDefault = true;
			this.buttonOk.CanFocus = true;
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.UseUnderline = true;
			this.buttonOk.Label = global::Mono.Unix.Catalog.GetString ("_Close");
			this.AddActionWidget (this.buttonOk, -5);
			global::Gtk.ButtonBox.ButtonBoxChild w17 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w16 [this.buttonOk]));
			w17.Expand = false;
			w17.Fill = false;
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 400;
			this.DefaultHeight = 300;
			this.Show ();
			this.btnRenameTable.Clicked += new global::System.EventHandler (this.OnBtnRenameTableClicked);
			this.btnDeleteField.Clicked += new global::System.EventHandler (this.OnBtnDeleteFieldClicked);
			this.btnCreateField.Clicked += new global::System.EventHandler (this.OnBtnCreateFieldClicked);
			this.btnEditField.Clicked += new global::System.EventHandler (this.OnBtnEditFieldClicked);
		}
	}
}
