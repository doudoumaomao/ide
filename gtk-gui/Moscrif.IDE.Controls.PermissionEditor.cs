
// This file has been generated by the GUI designer. Do not modify.
namespace Moscrif.IDE.Controls
{
	public partial class PermissionEditor
	{
		private global::Gtk.HBox hbox1;
		private global::Gtk.ScrolledWindow GtkScrolledWindow;
		private global::Gtk.TextView tvPermission;
		private global::Gtk.VButtonBox vbButton;
		private global::Gtk.Button buttonCancel;
		private global::Gtk.Button buttonOk;
		
		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget Moscrif.IDE.Controls.PermissionEditor
			this.Name = "Moscrif.IDE.Controls.PermissionEditor";
			this.Title = global::Mono.Unix.Catalog.GetString ("Permission Editor");
			this.WindowPosition = ((global::Gtk.WindowPosition)(1));
			// Internal child Moscrif.IDE.Controls.PermissionEditor.VBox
			global::Gtk.VBox w1 = this.VBox;
			w1.Name = "dialog1_VBox";
			w1.BorderWidth = ((uint)(2));
			// Container child dialog1_VBox.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			this.GtkScrolledWindow.BorderWidth = ((uint)(10));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.tvPermission = new global::Gtk.TextView ();
			this.tvPermission.CanFocus = true;
			this.tvPermission.Name = "tvPermission";
			this.GtkScrolledWindow.Add (this.tvPermission);
			this.hbox1.Add (this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.GtkScrolledWindow]));
			w3.Position = 0;
			// Container child hbox1.Gtk.Box+BoxChild
			this.vbButton = new global::Gtk.VButtonBox ();
			this.vbButton.Name = "vbButton";
			this.vbButton.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(3));
			this.hbox1.Add (this.vbButton);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.vbButton]));
			w4.PackType = ((global::Gtk.PackType)(1));
			w4.Position = 2;
			w4.Expand = false;
			w1.Add (this.hbox1);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(w1 [this.hbox1]));
			w5.Position = 0;
			// Internal child Moscrif.IDE.Controls.PermissionEditor.ActionArea
			global::Gtk.HButtonBox w6 = this.ActionArea;
			w6.Name = "dialog1_ActionArea";
			w6.Spacing = 10;
			w6.BorderWidth = ((uint)(10));
			w6.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(4));
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonCancel = new global::Gtk.Button ();
			this.buttonCancel.CanDefault = true;
			this.buttonCancel.CanFocus = true;
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.UseStock = true;
			this.buttonCancel.UseUnderline = true;
			this.buttonCancel.Label = "gtk-cancel";
			this.AddActionWidget (this.buttonCancel, -6);
			global::Gtk.ButtonBox.ButtonBoxChild w7 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w6 [this.buttonCancel]));
			w7.Expand = false;
			w7.Fill = false;
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonOk = new global::Gtk.Button ();
			this.buttonOk.CanDefault = true;
			this.buttonOk.CanFocus = true;
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.UseStock = true;
			this.buttonOk.UseUnderline = true;
			this.buttonOk.Label = "gtk-ok";
			this.AddActionWidget (this.buttonOk, -5);
			global::Gtk.ButtonBox.ButtonBoxChild w8 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w6 [this.buttonOk]));
			w8.Position = 1;
			w8.Expand = false;
			w8.Fill = false;
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 747;
			this.DefaultHeight = 491;
			this.Show ();
			this.tvPermission.PasteClipboard += new global::System.EventHandler (this.OnTvPermissionPasteClipboard);
		}
	}
}
