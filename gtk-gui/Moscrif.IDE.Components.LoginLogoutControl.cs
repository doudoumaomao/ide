
// This file has been generated by the GUI designer. Do not modify.
namespace Moscrif.IDE.Components
{
	public partial class LoginLogoutControl
	{
		private global::Gtk.HBox hbox2;
		private global::Gtk.Label lblName;
		private global::Gtk.Button btnState;
		private global::Gtk.Button btnAction;
		
		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget Moscrif.IDE.Components.LoginLogoutControl
			global::Stetic.BinContainer.Attach (this);
			this.Name = "Moscrif.IDE.Components.LoginLogoutControl";
			// Container child Moscrif.IDE.Components.LoginLogoutControl.Gtk.Container+ContainerChild
			this.hbox2 = new global::Gtk.HBox ();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.lblName = new global::Gtk.Label ();
			this.lblName.Name = "lblName";
			this.lblName.LabelProp = global::Mono.Unix.Catalog.GetString ("Open Source");
			this.hbox2.Add (this.lblName);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.lblName]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.btnState = new global::Gtk.Button ();
			this.btnState.CanFocus = true;
			this.btnState.Name = "btnState";
			this.btnState.UseUnderline = true;
			this.btnState.Relief = ((global::Gtk.ReliefStyle)(2));
			this.btnState.Label = global::Mono.Unix.Catalog.GetString ("Login");
			this.hbox2.Add (this.btnState);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.btnState]));
			w2.Position = 1;
			w2.Expand = false;
			w2.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.btnAction = new global::Gtk.Button ();
			this.btnAction.CanFocus = true;
			this.btnAction.Name = "btnAction";
			this.btnAction.UseUnderline = true;
			this.btnAction.Relief = ((global::Gtk.ReliefStyle)(2));
			this.btnAction.Label = global::Mono.Unix.Catalog.GetString ("Upgrade");
			this.hbox2.Add (this.btnAction);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.btnAction]));
			w3.Position = 2;
			w3.Expand = false;
			w3.Fill = false;
			this.Add (this.hbox2);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Hide ();
			this.btnState.Clicked += new global::System.EventHandler (this.OnBtnStateClicked);
			this.btnAction.Clicked += new global::System.EventHandler (this.OnBtnActionClicked);
		}
	}
}