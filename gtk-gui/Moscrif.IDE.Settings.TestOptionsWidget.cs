
// This file has been generated by the GUI designer. Do not modify.
namespace Moscrif.IDE.Settings
{
	internal partial class TestOptionsWidget
	{
		private global::Gtk.Table table2;
		private global::Gtk.Label label5;
		private global::Gtk.Label label6;
		private global::Gtk.Label label7;
		private global::Gtk.Label label8;
		private global::Gtk.SpinButton sbBlue;
		private global::Gtk.SpinButton sbGreen;
		private global::Gtk.SpinButton sbRed;
		private global::Gtk.SpinButton spinbutton4;
		
		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget Moscrif.IDE.Settings.TestOptionsWidget
			global::Stetic.BinContainer.Attach (this);
			this.Name = "Moscrif.IDE.Settings.TestOptionsWidget";
			// Container child Moscrif.IDE.Settings.TestOptionsWidget.Gtk.Container+ContainerChild
			this.table2 = new global::Gtk.Table (((uint)(7)), ((uint)(3)), false);
			this.table2.Name = "table2";
			this.table2.RowSpacing = ((uint)(6));
			this.table2.ColumnSpacing = ((uint)(6));
			// Container child table2.Gtk.Table+TableChild
			this.label5 = new global::Gtk.Label ();
			this.label5.Name = "label5";
			this.label5.Xalign = 1F;
			this.label5.LabelProp = global::Mono.Unix.Catalog.GetString ("Red");
			this.table2.Add (this.label5);
			global::Gtk.Table.TableChild w1 = ((global::Gtk.Table.TableChild)(this.table2 [this.label5]));
			w1.XOptions = ((global::Gtk.AttachOptions)(4));
			w1.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.label6 = new global::Gtk.Label ();
			this.label6.Name = "label6";
			this.label6.Xalign = 1F;
			this.label6.LabelProp = global::Mono.Unix.Catalog.GetString ("Green");
			this.table2.Add (this.label6);
			global::Gtk.Table.TableChild w2 = ((global::Gtk.Table.TableChild)(this.table2 [this.label6]));
			w2.TopAttach = ((uint)(1));
			w2.BottomAttach = ((uint)(2));
			w2.XOptions = ((global::Gtk.AttachOptions)(4));
			w2.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.label7 = new global::Gtk.Label ();
			this.label7.Name = "label7";
			this.label7.Xalign = 1F;
			this.label7.LabelProp = global::Mono.Unix.Catalog.GetString ("Blue");
			this.table2.Add (this.label7);
			global::Gtk.Table.TableChild w3 = ((global::Gtk.Table.TableChild)(this.table2 [this.label7]));
			w3.TopAttach = ((uint)(2));
			w3.BottomAttach = ((uint)(3));
			w3.XOptions = ((global::Gtk.AttachOptions)(4));
			w3.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.label8 = new global::Gtk.Label ();
			this.label8.Name = "label8";
			this.label8.Xalign = 1F;
			this.label8.LabelProp = global::Mono.Unix.Catalog.GetString ("W->Tag ");
			this.label8.Wrap = true;
			this.table2.Add (this.label8);
			global::Gtk.Table.TableChild w4 = ((global::Gtk.Table.TableChild)(this.table2 [this.label8]));
			w4.TopAttach = ((uint)(3));
			w4.BottomAttach = ((uint)(4));
			w4.XOptions = ((global::Gtk.AttachOptions)(4));
			w4.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.sbBlue = new global::Gtk.SpinButton (0D, 255D, 1D);
			this.sbBlue.CanFocus = true;
			this.sbBlue.Name = "sbBlue";
			this.sbBlue.Adjustment.PageIncrement = 5D;
			this.sbBlue.ClimbRate = 1D;
			this.sbBlue.Numeric = true;
			this.table2.Add (this.sbBlue);
			global::Gtk.Table.TableChild w5 = ((global::Gtk.Table.TableChild)(this.table2 [this.sbBlue]));
			w5.TopAttach = ((uint)(2));
			w5.BottomAttach = ((uint)(3));
			w5.LeftAttach = ((uint)(1));
			w5.RightAttach = ((uint)(2));
			w5.XOptions = ((global::Gtk.AttachOptions)(4));
			w5.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.sbGreen = new global::Gtk.SpinButton (0D, 255D, 1D);
			this.sbGreen.CanFocus = true;
			this.sbGreen.Name = "sbGreen";
			this.sbGreen.Adjustment.PageIncrement = 5D;
			this.sbGreen.ClimbRate = 1D;
			this.sbGreen.Numeric = true;
			this.table2.Add (this.sbGreen);
			global::Gtk.Table.TableChild w6 = ((global::Gtk.Table.TableChild)(this.table2 [this.sbGreen]));
			w6.TopAttach = ((uint)(1));
			w6.BottomAttach = ((uint)(2));
			w6.LeftAttach = ((uint)(1));
			w6.RightAttach = ((uint)(2));
			w6.XOptions = ((global::Gtk.AttachOptions)(4));
			w6.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.sbRed = new global::Gtk.SpinButton (0D, 255D, 1D);
			this.sbRed.CanFocus = true;
			this.sbRed.Name = "sbRed";
			this.sbRed.Adjustment.PageIncrement = 5D;
			this.sbRed.ClimbRate = 1D;
			this.sbRed.Numeric = true;
			this.table2.Add (this.sbRed);
			global::Gtk.Table.TableChild w7 = ((global::Gtk.Table.TableChild)(this.table2 [this.sbRed]));
			w7.LeftAttach = ((uint)(1));
			w7.RightAttach = ((uint)(2));
			w7.XOptions = ((global::Gtk.AttachOptions)(4));
			w7.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.spinbutton4 = new global::Gtk.SpinButton (0D, 100D, 1D);
			this.spinbutton4.CanFocus = true;
			this.spinbutton4.Name = "spinbutton4";
			this.spinbutton4.Adjustment.PageIncrement = 10D;
			this.spinbutton4.ClimbRate = 1D;
			this.spinbutton4.Numeric = true;
			this.table2.Add (this.spinbutton4);
			global::Gtk.Table.TableChild w8 = ((global::Gtk.Table.TableChild)(this.table2 [this.spinbutton4]));
			w8.TopAttach = ((uint)(3));
			w8.BottomAttach = ((uint)(4));
			w8.LeftAttach = ((uint)(1));
			w8.RightAttach = ((uint)(2));
			w8.XOptions = ((global::Gtk.AttachOptions)(4));
			w8.YOptions = ((global::Gtk.AttachOptions)(4));
			this.Add (this.table2);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Hide ();
		}
	}
}
