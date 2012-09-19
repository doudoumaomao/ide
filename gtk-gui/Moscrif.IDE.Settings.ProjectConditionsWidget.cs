
// This file has been generated by the GUI designer. Do not modify.
namespace Moscrif.IDE.Settings
{
	public partial class ProjectConditionsWidget
	{
		private global::Gtk.Table table2;
		private global::Gtk.ScrolledWindow GtkScrolledWindow;
		private global::Gtk.TreeView tvRules;
		private global::Gtk.ScrolledWindow GtkScrolledWindow1;
		private global::Gtk.TreeView tvConditions;
		private global::Gtk.Label label3;
		private global::Gtk.Label label4;
		private global::Gtk.VButtonBox vbuttonbox2;
		private global::Gtk.Button btnAddRules;
		private global::Gtk.Button btnDeleteRule;
		private global::Gtk.Button btnEditRule;
		private global::Gtk.VButtonBox vbuttonbox3;
		private global::Gtk.Button btnAddCond;
		private global::Gtk.Button btnDeleteCond;
		private global::Gtk.Button btnEditCond;
		
		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget Moscrif.IDE.Settings.ProjectConditionsWidget
			global::Stetic.BinContainer.Attach (this);
			this.Name = "Moscrif.IDE.Settings.ProjectConditionsWidget";
			// Container child Moscrif.IDE.Settings.ProjectConditionsWidget.Gtk.Container+ContainerChild
			this.table2 = new global::Gtk.Table (((uint)(3)), ((uint)(3)), false);
			this.table2.Name = "table2";
			this.table2.RowSpacing = ((uint)(6));
			this.table2.ColumnSpacing = ((uint)(6));
			// Container child table2.Gtk.Table+TableChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.tvRules = new global::Gtk.TreeView ();
			this.tvRules.CanFocus = true;
			this.tvRules.Name = "tvRules";
			this.GtkScrolledWindow.Add (this.tvRules);
			this.table2.Add (this.GtkScrolledWindow);
			global::Gtk.Table.TableChild w2 = ((global::Gtk.Table.TableChild)(this.table2 [this.GtkScrolledWindow]));
			w2.TopAttach = ((uint)(2));
			w2.BottomAttach = ((uint)(3));
			w2.LeftAttach = ((uint)(1));
			w2.RightAttach = ((uint)(2));
			w2.YPadding = ((uint)(5));
			w2.XOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.GtkScrolledWindow1 = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow1.Name = "GtkScrolledWindow1";
			this.GtkScrolledWindow1.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow1.Gtk.Container+ContainerChild
			this.tvConditions = new global::Gtk.TreeView ();
			this.tvConditions.CanFocus = true;
			this.tvConditions.Name = "tvConditions";
			this.GtkScrolledWindow1.Add (this.tvConditions);
			this.table2.Add (this.GtkScrolledWindow1);
			global::Gtk.Table.TableChild w4 = ((global::Gtk.Table.TableChild)(this.table2 [this.GtkScrolledWindow1]));
			w4.LeftAttach = ((uint)(1));
			w4.RightAttach = ((uint)(2));
			w4.YPadding = ((uint)(5));
			// Container child table2.Gtk.Table+TableChild
			this.label3 = new global::Gtk.Label ();
			this.label3.WidthRequest = 75;
			this.label3.Name = "label3";
			this.label3.Xalign = 1F;
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString ("Rules");
			this.table2.Add (this.label3);
			global::Gtk.Table.TableChild w5 = ((global::Gtk.Table.TableChild)(this.table2 [this.label3]));
			w5.TopAttach = ((uint)(2));
			w5.BottomAttach = ((uint)(3));
			w5.XPadding = ((uint)(5));
			w5.XOptions = ((global::Gtk.AttachOptions)(4));
			w5.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.label4 = new global::Gtk.Label ();
			this.label4.WidthRequest = 75;
			this.label4.Name = "label4";
			this.label4.Xalign = 1F;
			this.label4.LabelProp = global::Mono.Unix.Catalog.GetString ("Conditions");
			this.table2.Add (this.label4);
			global::Gtk.Table.TableChild w6 = ((global::Gtk.Table.TableChild)(this.table2 [this.label4]));
			w6.XPadding = ((uint)(5));
			w6.XOptions = ((global::Gtk.AttachOptions)(4));
			w6.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.vbuttonbox2 = new global::Gtk.VButtonBox ();
			this.vbuttonbox2.Name = "vbuttonbox2";
			this.vbuttonbox2.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(3));
			// Container child vbuttonbox2.Gtk.ButtonBox+ButtonBoxChild
			this.btnAddRules = new global::Gtk.Button ();
			this.btnAddRules.CanFocus = true;
			this.btnAddRules.Name = "btnAddRules";
			this.btnAddRules.UseUnderline = true;
			this.btnAddRules.Label = global::Mono.Unix.Catalog.GetString ("Add");
			this.vbuttonbox2.Add (this.btnAddRules);
			global::Gtk.ButtonBox.ButtonBoxChild w7 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.vbuttonbox2 [this.btnAddRules]));
			w7.Expand = false;
			w7.Fill = false;
			// Container child vbuttonbox2.Gtk.ButtonBox+ButtonBoxChild
			this.btnDeleteRule = new global::Gtk.Button ();
			this.btnDeleteRule.CanFocus = true;
			this.btnDeleteRule.Name = "btnDeleteRule";
			this.btnDeleteRule.UseUnderline = true;
			this.btnDeleteRule.Label = global::Mono.Unix.Catalog.GetString ("Delete");
			this.vbuttonbox2.Add (this.btnDeleteRule);
			global::Gtk.ButtonBox.ButtonBoxChild w8 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.vbuttonbox2 [this.btnDeleteRule]));
			w8.Position = 1;
			w8.Expand = false;
			w8.Fill = false;
			// Container child vbuttonbox2.Gtk.ButtonBox+ButtonBoxChild
			this.btnEditRule = new global::Gtk.Button ();
			this.btnEditRule.CanFocus = true;
			this.btnEditRule.Name = "btnEditRule";
			this.btnEditRule.UseUnderline = true;
			this.btnEditRule.Label = global::Mono.Unix.Catalog.GetString ("Edit");
			this.vbuttonbox2.Add (this.btnEditRule);
			global::Gtk.ButtonBox.ButtonBoxChild w9 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.vbuttonbox2 [this.btnEditRule]));
			w9.Position = 2;
			w9.Expand = false;
			w9.Fill = false;
			this.table2.Add (this.vbuttonbox2);
			global::Gtk.Table.TableChild w10 = ((global::Gtk.Table.TableChild)(this.table2 [this.vbuttonbox2]));
			w10.TopAttach = ((uint)(2));
			w10.BottomAttach = ((uint)(3));
			w10.LeftAttach = ((uint)(2));
			w10.RightAttach = ((uint)(3));
			w10.XPadding = ((uint)(5));
			w10.XOptions = ((global::Gtk.AttachOptions)(4));
			w10.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.vbuttonbox3 = new global::Gtk.VButtonBox ();
			this.vbuttonbox3.Name = "vbuttonbox3";
			this.vbuttonbox3.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(3));
			// Container child vbuttonbox3.Gtk.ButtonBox+ButtonBoxChild
			this.btnAddCond = new global::Gtk.Button ();
			this.btnAddCond.CanFocus = true;
			this.btnAddCond.Name = "btnAddCond";
			this.btnAddCond.UseUnderline = true;
			this.btnAddCond.Label = global::Mono.Unix.Catalog.GetString ("Add");
			this.vbuttonbox3.Add (this.btnAddCond);
			global::Gtk.ButtonBox.ButtonBoxChild w11 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.vbuttonbox3 [this.btnAddCond]));
			w11.Expand = false;
			w11.Fill = false;
			// Container child vbuttonbox3.Gtk.ButtonBox+ButtonBoxChild
			this.btnDeleteCond = new global::Gtk.Button ();
			this.btnDeleteCond.CanFocus = true;
			this.btnDeleteCond.Name = "btnDeleteCond";
			this.btnDeleteCond.UseUnderline = true;
			this.btnDeleteCond.Label = global::Mono.Unix.Catalog.GetString ("Delete");
			this.vbuttonbox3.Add (this.btnDeleteCond);
			global::Gtk.ButtonBox.ButtonBoxChild w12 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.vbuttonbox3 [this.btnDeleteCond]));
			w12.Position = 1;
			w12.Expand = false;
			w12.Fill = false;
			// Container child vbuttonbox3.Gtk.ButtonBox+ButtonBoxChild
			this.btnEditCond = new global::Gtk.Button ();
			this.btnEditCond.CanFocus = true;
			this.btnEditCond.Name = "btnEditCond";
			this.btnEditCond.UseUnderline = true;
			this.btnEditCond.Label = global::Mono.Unix.Catalog.GetString ("Edit");
			this.vbuttonbox3.Add (this.btnEditCond);
			global::Gtk.ButtonBox.ButtonBoxChild w13 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.vbuttonbox3 [this.btnEditCond]));
			w13.Position = 2;
			w13.Expand = false;
			w13.Fill = false;
			this.table2.Add (this.vbuttonbox3);
			global::Gtk.Table.TableChild w14 = ((global::Gtk.Table.TableChild)(this.table2 [this.vbuttonbox3]));
			w14.LeftAttach = ((uint)(2));
			w14.RightAttach = ((uint)(3));
			w14.YPadding = ((uint)(5));
			w14.XOptions = ((global::Gtk.AttachOptions)(4));
			w14.YOptions = ((global::Gtk.AttachOptions)(4));
			this.Add (this.table2);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Hide ();
			this.btnAddCond.Clicked += new global::System.EventHandler (this.OnBtnAddCondClicked);
			this.btnDeleteCond.Clicked += new global::System.EventHandler (this.OnBtnDeleteCondClicked);
			this.btnEditCond.Clicked += new global::System.EventHandler (this.OnBtnEditCondClicked);
			this.btnAddRules.Clicked += new global::System.EventHandler (this.OnBtnAddRulesClicked);
			this.btnDeleteRule.Clicked += new global::System.EventHandler (this.OnBtnDeleteCond1Clicked);
			this.btnEditRule.Clicked += new global::System.EventHandler (this.OnBtnEditCond1Clicked);
		}
	}
}