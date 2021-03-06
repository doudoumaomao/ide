
// This file has been generated by the GUI designer. Do not modify.
namespace Moscrif.IDE.Controls
{
	public partial class NewWorkspaceDialog
	{
		private global::Gtk.VBox vbox2;
		private global::Gtk.Table table2b;
		private global::Gtk.Entry entWorkspace;
		private global::Gtk.Label label3;
		private global::Gtk.Label label6;
		private global::Gtk.Expander expander1;
		private global::Gtk.Table table2;
		private global::Gtk.CheckButton cbCopyLibs;
		private global::Gtk.CheckButton cbSubFolder;
		private global::Gtk.Label label4;
		private global::Gtk.Label GtkLabel5;
		private global::Gtk.Frame trmProject;
		private global::Gtk.Alignment GtkAlignment1;
		private global::Gtk.VBox vbox3;
		private global::Gtk.Table table3;
		private global::Gtk.Entry entrProjectName;
		private global::Gtk.Label label5;
		private global::Gtk.Label GtkLabel4;
		private global::Gtk.Button buttonCancel;
		private global::Gtk.Button buttonOk;
		
		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget Moscrif.IDE.Controls.NewWorkspaceDialog
			this.Name = "Moscrif.IDE.Controls.NewWorkspaceDialog";
			this.Title = global::Mono.Unix.Catalog.GetString ("New Workspace");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Internal child Moscrif.IDE.Controls.NewWorkspaceDialog.VBox
			global::Gtk.VBox w1 = this.VBox;
			w1.Name = "dialog1_VBox";
			w1.BorderWidth = ((uint)(2));
			// Container child dialog1_VBox.Gtk.Box+BoxChild
			this.vbox2 = new global::Gtk.VBox ();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			this.vbox2.BorderWidth = ((uint)(10));
			// Container child vbox2.Gtk.Box+BoxChild
			this.table2b = new global::Gtk.Table (((uint)(2)), ((uint)(2)), false);
			this.table2b.Name = "table2b";
			this.table2b.RowSpacing = ((uint)(6));
			this.table2b.ColumnSpacing = ((uint)(6));
			// Container child table2b.Gtk.Table+TableChild
			this.entWorkspace = new global::Gtk.Entry ();
			this.entWorkspace.CanFocus = true;
			this.entWorkspace.Events = ((global::Gdk.EventMask)(2048));
			this.entWorkspace.Name = "entWorkspace";
			this.entWorkspace.IsEditable = true;
			this.entWorkspace.InvisibleChar = '●';
			this.table2b.Add (this.entWorkspace);
			global::Gtk.Table.TableChild w2 = ((global::Gtk.Table.TableChild)(this.table2b [this.entWorkspace]));
			w2.LeftAttach = ((uint)(1));
			w2.RightAttach = ((uint)(2));
			w2.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2b.Gtk.Table+TableChild
			this.label3 = new global::Gtk.Label ();
			this.label3.Name = "label3";
			this.label3.Xalign = 1F;
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString ("Location :");
			this.table2b.Add (this.label3);
			global::Gtk.Table.TableChild w3 = ((global::Gtk.Table.TableChild)(this.table2b [this.label3]));
			w3.TopAttach = ((uint)(1));
			w3.BottomAttach = ((uint)(2));
			w3.XPadding = ((uint)(5));
			w3.XOptions = ((global::Gtk.AttachOptions)(4));
			w3.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2b.Gtk.Table+TableChild
			this.label6 = new global::Gtk.Label ();
			this.label6.Name = "label6";
			this.label6.Xalign = 1F;
			this.label6.LabelProp = global::Mono.Unix.Catalog.GetString ("Workspace Name :");
			this.table2b.Add (this.label6);
			global::Gtk.Table.TableChild w4 = ((global::Gtk.Table.TableChild)(this.table2b [this.label6]));
			w4.XPadding = ((uint)(5));
			w4.XOptions = ((global::Gtk.AttachOptions)(4));
			w4.YOptions = ((global::Gtk.AttachOptions)(4));
			this.vbox2.Add (this.table2b);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.table2b]));
			w5.Position = 0;
			w5.Expand = false;
			w5.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.expander1 = new global::Gtk.Expander (null);
			this.expander1.CanFocus = true;
			this.expander1.Name = "expander1";
			// Container child expander1.Gtk.Container+ContainerChild
			this.table2 = new global::Gtk.Table (((uint)(3)), ((uint)(2)), false);
			this.table2.Name = "table2";
			this.table2.RowSpacing = ((uint)(6));
			this.table2.ColumnSpacing = ((uint)(6));
			// Container child table2.Gtk.Table+TableChild
			this.cbCopyLibs = new global::Gtk.CheckButton ();
			this.cbCopyLibs.CanFocus = true;
			this.cbCopyLibs.Name = "cbCopyLibs";
			this.cbCopyLibs.Label = global::Mono.Unix.Catalog.GetString ("Copy All Libs");
			this.cbCopyLibs.DrawIndicator = true;
			this.cbCopyLibs.UseUnderline = true;
			this.table2.Add (this.cbCopyLibs);
			global::Gtk.Table.TableChild w6 = ((global::Gtk.Table.TableChild)(this.table2 [this.cbCopyLibs]));
			w6.TopAttach = ((uint)(1));
			w6.BottomAttach = ((uint)(2));
			w6.LeftAttach = ((uint)(1));
			w6.RightAttach = ((uint)(2));
			w6.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.cbSubFolder = new global::Gtk.CheckButton ();
			this.cbSubFolder.CanFocus = true;
			this.cbSubFolder.Name = "cbSubFolder";
			this.cbSubFolder.Label = global::Mono.Unix.Catalog.GetString ("Create directory for workspace");
			this.cbSubFolder.Active = true;
			this.cbSubFolder.DrawIndicator = true;
			this.cbSubFolder.UseUnderline = true;
			this.table2.Add (this.cbSubFolder);
			global::Gtk.Table.TableChild w7 = ((global::Gtk.Table.TableChild)(this.table2 [this.cbSubFolder]));
			w7.TopAttach = ((uint)(2));
			w7.BottomAttach = ((uint)(3));
			w7.LeftAttach = ((uint)(1));
			w7.RightAttach = ((uint)(2));
			w7.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.label4 = new global::Gtk.Label ();
			this.label4.Name = "label4";
			this.label4.Xalign = 1F;
			this.label4.LabelProp = global::Mono.Unix.Catalog.GetString ("Output Directory :");
			this.table2.Add (this.label4);
			global::Gtk.Table.TableChild w8 = ((global::Gtk.Table.TableChild)(this.table2 [this.label4]));
			w8.XPadding = ((uint)(9));
			w8.XOptions = ((global::Gtk.AttachOptions)(4));
			w8.YOptions = ((global::Gtk.AttachOptions)(4));
			this.expander1.Add (this.table2);
			this.GtkLabel5 = new global::Gtk.Label ();
			this.GtkLabel5.Name = "GtkLabel5";
			this.GtkLabel5.LabelProp = global::Mono.Unix.Catalog.GetString ("Detail");
			this.GtkLabel5.UseUnderline = true;
			this.expander1.LabelWidget = this.GtkLabel5;
			this.vbox2.Add (this.expander1);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.expander1]));
			w10.Position = 1;
			w10.Expand = false;
			w10.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.trmProject = new global::Gtk.Frame ();
			this.trmProject.Name = "trmProject";
			// Container child trmProject.Gtk.Container+ContainerChild
			this.GtkAlignment1 = new global::Gtk.Alignment (0F, 0F, 1F, 1F);
			this.GtkAlignment1.Name = "GtkAlignment1";
			this.GtkAlignment1.LeftPadding = ((uint)(12));
			// Container child GtkAlignment1.Gtk.Container+ContainerChild
			this.vbox3 = new global::Gtk.VBox ();
			this.vbox3.Name = "vbox3";
			this.vbox3.Spacing = 6;
			// Container child vbox3.Gtk.Box+BoxChild
			this.table3 = new global::Gtk.Table (((uint)(1)), ((uint)(2)), false);
			this.table3.Name = "table3";
			this.table3.RowSpacing = ((uint)(6));
			this.table3.ColumnSpacing = ((uint)(8));
			this.table3.BorderWidth = ((uint)(6));
			// Container child table3.Gtk.Table+TableChild
			this.entrProjectName = new global::Gtk.Entry ();
			this.entrProjectName.CanFocus = true;
			this.entrProjectName.Name = "entrProjectName";
			this.entrProjectName.IsEditable = true;
			this.entrProjectName.InvisibleChar = '●';
			this.table3.Add (this.entrProjectName);
			global::Gtk.Table.TableChild w11 = ((global::Gtk.Table.TableChild)(this.table3 [this.entrProjectName]));
			w11.LeftAttach = ((uint)(1));
			w11.RightAttach = ((uint)(2));
			w11.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table3.Gtk.Table+TableChild
			this.label5 = new global::Gtk.Label ();
			this.label5.WidthRequest = 85;
			this.label5.Name = "label5";
			this.label5.Xalign = 1F;
			this.label5.LabelProp = global::Mono.Unix.Catalog.GetString ("Project Name :");
			this.table3.Add (this.label5);
			global::Gtk.Table.TableChild w12 = ((global::Gtk.Table.TableChild)(this.table3 [this.label5]));
			w12.XOptions = ((global::Gtk.AttachOptions)(4));
			w12.YOptions = ((global::Gtk.AttachOptions)(4));
			this.vbox3.Add (this.table3);
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.table3]));
			w13.Position = 0;
			w13.Expand = false;
			w13.Fill = false;
			this.GtkAlignment1.Add (this.vbox3);
			this.trmProject.Add (this.GtkAlignment1);
			this.GtkLabel4 = new global::Gtk.Label ();
			this.GtkLabel4.Name = "GtkLabel4";
			this.GtkLabel4.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>Project</b>");
			this.GtkLabel4.UseMarkup = true;
			this.trmProject.LabelWidget = this.GtkLabel4;
			this.vbox2.Add (this.trmProject);
			global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.trmProject]));
			w16.Position = 2;
			w1.Add (this.vbox2);
			global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(w1 [this.vbox2]));
			w17.Position = 0;
			// Internal child Moscrif.IDE.Controls.NewWorkspaceDialog.ActionArea
			global::Gtk.HButtonBox w18 = this.ActionArea;
			w18.Name = "dialog1_ActionArea";
			w18.Spacing = 10;
			w18.BorderWidth = ((uint)(10));
			w18.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(4));
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonCancel = new global::Gtk.Button ();
			this.buttonCancel.CanDefault = true;
			this.buttonCancel.CanFocus = true;
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.UseStock = true;
			this.buttonCancel.UseUnderline = true;
			this.buttonCancel.Label = "gtk-cancel";
			this.AddActionWidget (this.buttonCancel, -6);
			global::Gtk.ButtonBox.ButtonBoxChild w19 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w18 [this.buttonCancel]));
			w19.Expand = false;
			w19.Fill = false;
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonOk = new global::Gtk.Button ();
			this.buttonOk.CanDefault = true;
			this.buttonOk.CanFocus = true;
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.UseUnderline = true;
			this.buttonOk.Label = global::Mono.Unix.Catalog.GetString ("_OK");
			w18.Add (this.buttonOk);
			global::Gtk.ButtonBox.ButtonBoxChild w20 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w18 [this.buttonOk]));
			w20.Position = 1;
			w20.Expand = false;
			w20.Fill = false;
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 444;
			this.DefaultHeight = 303;
			this.vbox3.Hide ();
			this.trmProject.Hide ();
			this.Show ();
			this.entWorkspace.KeyReleaseEvent += new global::Gtk.KeyReleaseEventHandler (this.OnEntWorkspaceKeyReleaseEvent);
			this.entrProjectName.KeyReleaseEvent += new global::Gtk.KeyReleaseEventHandler (this.OnEntrProjectNameKeyReleaseEvent);
			this.buttonOk.Clicked += new global::System.EventHandler (this.OnButtonOkClicked);
		}
	}
}
