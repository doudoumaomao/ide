
// This file has been generated by the GUI designer. Do not modify.
namespace Moscrif.IDE.Option
{
	public partial class KeyBindingWidget
	{
		private global::Gtk.VBox vbox2;
		private global::Gtk.Frame frame1;
		private global::Gtk.Alignment GtkAlignment1;
		private global::Gtk.HBox hbox2;
		private global::Gtk.Label label2;
		private global::Gtk.ComboBox cbKeyBinding;
		private global::Gtk.Button btnAccelAply1;
		private global::Gtk.Label GtkLabel1;
		private global::Gtk.HSeparator hseparator1;
		private global::Gtk.VBox vbox3;
		private global::Gtk.Label lblMessage;
		private global::Gtk.ScrolledWindow GtkScrolledWindow;
		private global::Gtk.TreeView tvKeyBind;
		private global::Gtk.HBox hbox1;
		private global::Gtk.Label label1;
		private global::Gtk.Entry entrAccel;
		private global::Gtk.Button btnAccelAply;
		
		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget Moscrif.IDE.Option.KeyBindingWidget
			global::Stetic.BinContainer.Attach (this);
			this.Name = "Moscrif.IDE.Option.KeyBindingWidget";
			// Container child Moscrif.IDE.Option.KeyBindingWidget.Gtk.Container+ContainerChild
			this.vbox2 = new global::Gtk.VBox ();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.frame1 = new global::Gtk.Frame ();
			this.frame1.Name = "frame1";
			// Container child frame1.Gtk.Container+ContainerChild
			this.GtkAlignment1 = new global::Gtk.Alignment (0F, 0F, 1F, 1F);
			this.GtkAlignment1.Name = "GtkAlignment1";
			this.GtkAlignment1.LeftPadding = ((uint)(12));
			// Container child GtkAlignment1.Gtk.Container+ContainerChild
			this.hbox2 = new global::Gtk.HBox ();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.label2 = new global::Gtk.Label ();
			this.label2.Name = "label2";
			this.label2.Xalign = 1F;
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString ("Keybinding :");
			this.hbox2.Add (this.label2);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.label2]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.cbKeyBinding = global::Gtk.ComboBox.NewText ();
			this.cbKeyBinding.Name = "cbKeyBinding";
			this.hbox2.Add (this.cbKeyBinding);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.cbKeyBinding]));
			w2.Position = 1;
			w2.Expand = false;
			w2.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.btnAccelAply1 = new global::Gtk.Button ();
			this.btnAccelAply1.CanFocus = true;
			this.btnAccelAply1.Name = "btnAccelAply1";
			this.btnAccelAply1.UseUnderline = true;
			// Container child btnAccelAply1.Gtk.Container+ContainerChild
			global::Gtk.Alignment w3 = new global::Gtk.Alignment (0.5F, 0.5F, 0F, 0F);
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			global::Gtk.HBox w4 = new global::Gtk.HBox ();
			w4.Spacing = 2;
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Image w5 = new global::Gtk.Image ();
			w5.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-apply", global::Gtk.IconSize.Menu);
			w4.Add (w5);
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Label w7 = new global::Gtk.Label ();
			w7.LabelProp = global::Mono.Unix.Catalog.GetString ("_Apply");
			w7.UseUnderline = true;
			w4.Add (w7);
			w3.Add (w4);
			this.btnAccelAply1.Add (w3);
			this.hbox2.Add (this.btnAccelAply1);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.btnAccelAply1]));
			w11.Position = 2;
			w11.Expand = false;
			w11.Fill = false;
			this.GtkAlignment1.Add (this.hbox2);
			this.frame1.Add (this.GtkAlignment1);
			this.GtkLabel1 = new global::Gtk.Label ();
			this.GtkLabel1.Name = "GtkLabel1";
			this.GtkLabel1.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>Scheme</b>");
			this.GtkLabel1.UseMarkup = true;
			this.frame1.LabelWidget = this.GtkLabel1;
			this.vbox2.Add (this.frame1);
			global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.frame1]));
			w14.Position = 0;
			w14.Expand = false;
			w14.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hseparator1 = new global::Gtk.HSeparator ();
			this.hseparator1.Name = "hseparator1";
			this.vbox2.Add (this.hseparator1);
			global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.hseparator1]));
			w15.Position = 1;
			w15.Expand = false;
			w15.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.vbox3 = new global::Gtk.VBox ();
			this.vbox3.Name = "vbox3";
			this.vbox3.Spacing = 6;
			// Container child vbox3.Gtk.Box+BoxChild
			this.lblMessage = new global::Gtk.Label ();
			this.lblMessage.Name = "lblMessage";
			this.lblMessage.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>label1</b>");
			this.lblMessage.UseMarkup = true;
			this.vbox3.Add (this.lblMessage);
			global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.lblMessage]));
			w16.Position = 0;
			w16.Expand = false;
			w16.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.tvKeyBind = new global::Gtk.TreeView ();
			this.tvKeyBind.CanFocus = true;
			this.tvKeyBind.Name = "tvKeyBind";
			this.GtkScrolledWindow.Add (this.tvKeyBind);
			this.vbox3.Add (this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.GtkScrolledWindow]));
			w18.Position = 1;
			// Container child vbox3.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.label1 = new global::Gtk.Label ();
			this.label1.Name = "label1";
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString ("Edit Key :");
			this.hbox1.Add (this.label1);
			global::Gtk.Box.BoxChild w19 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.label1]));
			w19.Position = 0;
			w19.Expand = false;
			w19.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.entrAccel = new global::Gtk.Entry ();
			this.entrAccel.CanFocus = true;
			this.entrAccel.Name = "entrAccel";
			this.entrAccel.IsEditable = true;
			this.entrAccel.InvisibleChar = 'â';
			this.hbox1.Add (this.entrAccel);
			global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.entrAccel]));
			w20.Position = 1;
			// Container child hbox1.Gtk.Box+BoxChild
			this.btnAccelAply = new global::Gtk.Button ();
			this.btnAccelAply.CanFocus = true;
			this.btnAccelAply.Name = "btnAccelAply";
			this.btnAccelAply.UseUnderline = true;
			// Container child btnAccelAply.Gtk.Container+ContainerChild
			global::Gtk.Alignment w21 = new global::Gtk.Alignment (0.5F, 0.5F, 0F, 0F);
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			global::Gtk.HBox w22 = new global::Gtk.HBox ();
			w22.Spacing = 2;
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Image w23 = new global::Gtk.Image ();
			w23.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-apply", global::Gtk.IconSize.Menu);
			w22.Add (w23);
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Label w25 = new global::Gtk.Label ();
			w25.LabelProp = global::Mono.Unix.Catalog.GetString ("_Apply");
			w25.UseUnderline = true;
			w22.Add (w25);
			w21.Add (w22);
			this.btnAccelAply.Add (w21);
			this.hbox1.Add (this.btnAccelAply);
			global::Gtk.Box.BoxChild w29 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.btnAccelAply]));
			w29.Position = 2;
			w29.Expand = false;
			w29.Fill = false;
			this.vbox3.Add (this.hbox1);
			global::Gtk.Box.BoxChild w30 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.hbox1]));
			w30.Position = 2;
			w30.Expand = false;
			w30.Fill = false;
			this.vbox2.Add (this.vbox3);
			global::Gtk.Box.BoxChild w31 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.vbox3]));
			w31.Position = 2;
			this.Add (this.vbox2);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Hide ();
			this.btnAccelAply1.Clicked += new global::System.EventHandler (this.OnBtnAccelAply1Clicked);
			this.entrAccel.KeyPressEvent += new global::Gtk.KeyPressEventHandler (this.OnEntrAccelKeyPressEvent);
			this.entrAccel.KeyReleaseEvent += new global::Gtk.KeyReleaseEventHandler (this.OnEntrAccelKeyReleaseEvent);
			this.entrAccel.Changed += new global::System.EventHandler (this.OnEntrAccelChanged);
			this.btnAccelAply.Clicked += new global::System.EventHandler (this.OnBtnAccelAplyClicked);
		}
	}
}
