
// This file has been generated by the GUI designer. Do not modify.
namespace Moscrif.IDE.Controls
{
	public partial class UniqueSequenceDialog
	{
		private global::Gtk.Table table1;
		private global::Gtk.ScrolledWindow GtkScrolledWindow;
		private global::Gtk.TextView tvInput;
		private global::Gtk.ScrolledWindow GtkScrolledWindow1;
		private global::Gtk.TextView tvOutput;
		private global::Gtk.HBox hbox1;
		private global::Gtk.Label label3;
		private global::Gtk.HBox hbox2;
		private global::Gtk.Label label2;
		private global::Gtk.Button buttonOk;
		
		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget Moscrif.IDE.Controls.UniqueSequenceDialog
			this.Name = "Moscrif.IDE.Controls.UniqueSequenceDialog";
			this.WindowPosition = ((global::Gtk.WindowPosition)(1));
			this.Modal = true;
			// Internal child Moscrif.IDE.Controls.UniqueSequenceDialog.VBox
			global::Gtk.VBox w1 = this.VBox;
			w1.Name = "dialog1_VBox";
			w1.BorderWidth = ((uint)(2));
			// Container child dialog1_VBox.Gtk.Box+BoxChild
			this.table1 = new global::Gtk.Table (((uint)(4)), ((uint)(1)), false);
			this.table1.Name = "table1";
			this.table1.RowSpacing = ((uint)(6));
			this.table1.ColumnSpacing = ((uint)(6));
			this.table1.BorderWidth = ((uint)(5));
			// Container child table1.Gtk.Table+TableChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.tvInput = new global::Gtk.TextView ();
			this.tvInput.CanFocus = true;
			this.tvInput.Name = "tvInput";
			this.GtkScrolledWindow.Add (this.tvInput);
			this.table1.Add (this.GtkScrolledWindow);
			global::Gtk.Table.TableChild w3 = ((global::Gtk.Table.TableChild)(this.table1 [this.GtkScrolledWindow]));
			w3.TopAttach = ((uint)(1));
			w3.BottomAttach = ((uint)(2));
			// Container child table1.Gtk.Table+TableChild
			this.GtkScrolledWindow1 = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow1.Name = "GtkScrolledWindow1";
			this.GtkScrolledWindow1.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow1.Gtk.Container+ContainerChild
			this.tvOutput = new global::Gtk.TextView ();
			this.tvOutput.CanFocus = true;
			this.tvOutput.Name = "tvOutput";
			this.GtkScrolledWindow1.Add (this.tvOutput);
			this.table1.Add (this.GtkScrolledWindow1);
			global::Gtk.Table.TableChild w5 = ((global::Gtk.Table.TableChild)(this.table1 [this.GtkScrolledWindow1]));
			w5.TopAttach = ((uint)(3));
			w5.BottomAttach = ((uint)(4));
			w5.XOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.label3 = new global::Gtk.Label ();
			this.label3.Name = "label3";
			this.label3.Xalign = 1F;
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString ("Output :");
			this.hbox1.Add (this.label3);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.label3]));
			w6.Position = 0;
			w6.Expand = false;
			w6.Fill = false;
			this.table1.Add (this.hbox1);
			global::Gtk.Table.TableChild w7 = ((global::Gtk.Table.TableChild)(this.table1 [this.hbox1]));
			w7.TopAttach = ((uint)(2));
			w7.BottomAttach = ((uint)(3));
			w7.XOptions = ((global::Gtk.AttachOptions)(4));
			w7.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.hbox2 = new global::Gtk.HBox ();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.label2 = new global::Gtk.Label ();
			this.label2.Name = "label2";
			this.label2.Xalign = 1F;
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString ("Input :");
			this.hbox2.Add (this.label2);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.label2]));
			w8.Position = 0;
			w8.Expand = false;
			w8.Fill = false;
			this.table1.Add (this.hbox2);
			global::Gtk.Table.TableChild w9 = ((global::Gtk.Table.TableChild)(this.table1 [this.hbox2]));
			w9.XOptions = ((global::Gtk.AttachOptions)(4));
			w9.YOptions = ((global::Gtk.AttachOptions)(4));
			w1.Add (this.table1);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(w1 [this.table1]));
			w10.Position = 0;
			// Internal child Moscrif.IDE.Controls.UniqueSequenceDialog.ActionArea
			global::Gtk.HButtonBox w11 = this.ActionArea;
			w11.Name = "dialog1_ActionArea";
			w11.Spacing = 10;
			w11.BorderWidth = ((uint)(5));
			w11.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(4));
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonOk = new global::Gtk.Button ();
			this.buttonOk.CanDefault = true;
			this.buttonOk.CanFocus = true;
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.UseStock = true;
			this.buttonOk.UseUnderline = true;
			this.buttonOk.Label = "gtk-ok";
			this.AddActionWidget (this.buttonOk, -5);
			global::Gtk.ButtonBox.ButtonBoxChild w12 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w11 [this.buttonOk]));
			w12.Expand = false;
			w12.Fill = false;
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 400;
			this.DefaultHeight = 300;
			this.Show ();
			this.tvInput.KeyReleaseEvent += new global::Gtk.KeyReleaseEventHandler (this.OnTvInputKeyReleaseEvent);
			this.buttonOk.Clicked += new global::System.EventHandler (this.OnButtonOkClicked);
		}
	}
}
