
// This file has been generated by the GUI designer. Do not modify.
namespace Moscrif.IDE.Controls
{
	public partial class LoginDialog
	{
		private global::Gtk.Notebook notebook1;
		private global::Gtk.Table table1;
		private global::Gtk.Entry entrLogin;
		private global::Gtk.Entry entrPassword;
		private global::Gtk.CheckButton chbRemember;
		private global::Gtk.Label label2;
		private global::Gtk.Label label3;
		private global::Gtk.Label label1;
		private global::Gtk.Table table2;
		private global::Gtk.Entry entrEmailR;
		private global::Gtk.Entry entrLoginR;
		private global::Gtk.Entry entrPasswordR1;
		private global::Gtk.Entry entrPasswordR2;
		private global::Gtk.Label label4;
		private global::Gtk.Label label5;
		private global::Gtk.Label label6;
		private global::Gtk.Label lbl;
		private global::Gtk.Label lblRegister;
		private global::Gtk.Button buttonCancel;
		private global::Gtk.Button btnInfo;
		
		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget Moscrif.IDE.Controls.LoginDialog
			this.Name = "Moscrif.IDE.Controls.LoginDialog";
			this.WindowPosition = ((global::Gtk.WindowPosition)(3));
			// Internal child Moscrif.IDE.Controls.LoginDialog.VBox
			global::Gtk.VBox w1 = this.VBox;
			w1.Name = "dialog1_VBox";
			w1.BorderWidth = ((uint)(2));
			// Container child dialog1_VBox.Gtk.Box+BoxChild
			this.notebook1 = new global::Gtk.Notebook ();
			this.notebook1.CanFocus = true;
			this.notebook1.Name = "notebook1";
			this.notebook1.CurrentPage = 1;
			// Container child notebook1.Gtk.Notebook+NotebookChild
			this.table1 = new global::Gtk.Table (((uint)(3)), ((uint)(2)), false);
			this.table1.Name = "table1";
			this.table1.RowSpacing = ((uint)(6));
			this.table1.ColumnSpacing = ((uint)(6));
			this.table1.BorderWidth = ((uint)(5));
			// Container child table1.Gtk.Table+TableChild
			this.entrLogin = new global::Gtk.Entry ();
			this.entrLogin.CanFocus = true;
			this.entrLogin.Name = "entrLogin";
			this.entrLogin.IsEditable = true;
			this.entrLogin.InvisibleChar = '●';
			this.table1.Add (this.entrLogin);
			global::Gtk.Table.TableChild w2 = ((global::Gtk.Table.TableChild)(this.table1 [this.entrLogin]));
			w2.LeftAttach = ((uint)(1));
			w2.RightAttach = ((uint)(2));
			w2.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.entrPassword = new global::Gtk.Entry ();
			this.entrPassword.CanFocus = true;
			this.entrPassword.Name = "entrPassword";
			this.entrPassword.IsEditable = true;
			this.entrPassword.Visibility = false;
			this.entrPassword.InvisibleChar = '●';
			this.table1.Add (this.entrPassword);
			global::Gtk.Table.TableChild w3 = ((global::Gtk.Table.TableChild)(this.table1 [this.entrPassword]));
			w3.TopAttach = ((uint)(1));
			w3.BottomAttach = ((uint)(2));
			w3.LeftAttach = ((uint)(1));
			w3.RightAttach = ((uint)(2));
			w3.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.chbRemember = new global::Gtk.CheckButton ();
			this.chbRemember.CanFocus = true;
			this.chbRemember.Name = "chbRemember";
			this.chbRemember.Label = global::Mono.Unix.Catalog.GetString ("Remember Me");
			this.chbRemember.DrawIndicator = true;
			this.chbRemember.UseUnderline = true;
			this.table1.Add (this.chbRemember);
			global::Gtk.Table.TableChild w4 = ((global::Gtk.Table.TableChild)(this.table1 [this.chbRemember]));
			w4.TopAttach = ((uint)(2));
			w4.BottomAttach = ((uint)(3));
			w4.LeftAttach = ((uint)(1));
			w4.RightAttach = ((uint)(2));
			w4.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label2 = new global::Gtk.Label ();
			this.label2.Name = "label2";
			this.label2.Xalign = 1F;
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString ("Login :");
			this.table1.Add (this.label2);
			global::Gtk.Table.TableChild w5 = ((global::Gtk.Table.TableChild)(this.table1 [this.label2]));
			w5.XOptions = ((global::Gtk.AttachOptions)(4));
			w5.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label3 = new global::Gtk.Label ();
			this.label3.Name = "label3";
			this.label3.Xalign = 1F;
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString ("Password :");
			this.table1.Add (this.label3);
			global::Gtk.Table.TableChild w6 = ((global::Gtk.Table.TableChild)(this.table1 [this.label3]));
			w6.TopAttach = ((uint)(1));
			w6.BottomAttach = ((uint)(2));
			w6.XOptions = ((global::Gtk.AttachOptions)(4));
			w6.YOptions = ((global::Gtk.AttachOptions)(4));
			this.notebook1.Add (this.table1);
			// Notebook tab
			this.label1 = new global::Gtk.Label ();
			this.label1.Name = "label1";
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString ("Login");
			this.notebook1.SetTabLabel (this.table1, this.label1);
			this.label1.ShowAll ();
			// Container child notebook1.Gtk.Notebook+NotebookChild
			this.table2 = new global::Gtk.Table (((uint)(4)), ((uint)(2)), false);
			this.table2.Name = "table2";
			this.table2.RowSpacing = ((uint)(6));
			this.table2.ColumnSpacing = ((uint)(6));
			this.table2.BorderWidth = ((uint)(5));
			// Container child table2.Gtk.Table+TableChild
			this.entrEmailR = new global::Gtk.Entry ();
			this.entrEmailR.CanFocus = true;
			this.entrEmailR.Name = "entrEmailR";
			this.entrEmailR.IsEditable = true;
			this.entrEmailR.InvisibleChar = '●';
			this.table2.Add (this.entrEmailR);
			global::Gtk.Table.TableChild w8 = ((global::Gtk.Table.TableChild)(this.table2 [this.entrEmailR]));
			w8.TopAttach = ((uint)(3));
			w8.BottomAttach = ((uint)(4));
			w8.LeftAttach = ((uint)(1));
			w8.RightAttach = ((uint)(2));
			w8.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.entrLoginR = new global::Gtk.Entry ();
			this.entrLoginR.CanFocus = true;
			this.entrLoginR.Name = "entrLoginR";
			this.entrLoginR.IsEditable = true;
			this.entrLoginR.InvisibleChar = '●';
			this.table2.Add (this.entrLoginR);
			global::Gtk.Table.TableChild w9 = ((global::Gtk.Table.TableChild)(this.table2 [this.entrLoginR]));
			w9.LeftAttach = ((uint)(1));
			w9.RightAttach = ((uint)(2));
			w9.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.entrPasswordR1 = new global::Gtk.Entry ();
			this.entrPasswordR1.CanFocus = true;
			this.entrPasswordR1.Name = "entrPasswordR1";
			this.entrPasswordR1.IsEditable = true;
			this.entrPasswordR1.Visibility = false;
			this.entrPasswordR1.InvisibleChar = '●';
			this.table2.Add (this.entrPasswordR1);
			global::Gtk.Table.TableChild w10 = ((global::Gtk.Table.TableChild)(this.table2 [this.entrPasswordR1]));
			w10.TopAttach = ((uint)(1));
			w10.BottomAttach = ((uint)(2));
			w10.LeftAttach = ((uint)(1));
			w10.RightAttach = ((uint)(2));
			w10.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.entrPasswordR2 = new global::Gtk.Entry ();
			this.entrPasswordR2.CanFocus = true;
			this.entrPasswordR2.Name = "entrPasswordR2";
			this.entrPasswordR2.IsEditable = true;
			this.entrPasswordR2.Visibility = false;
			this.entrPasswordR2.InvisibleChar = '●';
			this.table2.Add (this.entrPasswordR2);
			global::Gtk.Table.TableChild w11 = ((global::Gtk.Table.TableChild)(this.table2 [this.entrPasswordR2]));
			w11.TopAttach = ((uint)(2));
			w11.BottomAttach = ((uint)(3));
			w11.LeftAttach = ((uint)(1));
			w11.RightAttach = ((uint)(2));
			w11.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.label4 = new global::Gtk.Label ();
			this.label4.Name = "label4";
			this.label4.Xalign = 1F;
			this.label4.LabelProp = global::Mono.Unix.Catalog.GetString ("Check Password :");
			this.table2.Add (this.label4);
			global::Gtk.Table.TableChild w12 = ((global::Gtk.Table.TableChild)(this.table2 [this.label4]));
			w12.TopAttach = ((uint)(2));
			w12.BottomAttach = ((uint)(3));
			w12.XOptions = ((global::Gtk.AttachOptions)(4));
			w12.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.label5 = new global::Gtk.Label ();
			this.label5.Name = "label5";
			this.label5.Xalign = 1F;
			this.label5.LabelProp = global::Mono.Unix.Catalog.GetString ("Password :");
			this.table2.Add (this.label5);
			global::Gtk.Table.TableChild w13 = ((global::Gtk.Table.TableChild)(this.table2 [this.label5]));
			w13.TopAttach = ((uint)(1));
			w13.BottomAttach = ((uint)(2));
			w13.XOptions = ((global::Gtk.AttachOptions)(4));
			w13.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.label6 = new global::Gtk.Label ();
			this.label6.Name = "label6";
			this.label6.Xalign = 1F;
			this.label6.LabelProp = global::Mono.Unix.Catalog.GetString ("Login :");
			this.table2.Add (this.label6);
			global::Gtk.Table.TableChild w14 = ((global::Gtk.Table.TableChild)(this.table2 [this.label6]));
			w14.XOptions = ((global::Gtk.AttachOptions)(4));
			w14.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.lbl = new global::Gtk.Label ();
			this.lbl.Name = "lbl";
			this.lbl.Xalign = 1F;
			this.lbl.LabelProp = global::Mono.Unix.Catalog.GetString ("Email :");
			this.table2.Add (this.lbl);
			global::Gtk.Table.TableChild w15 = ((global::Gtk.Table.TableChild)(this.table2 [this.lbl]));
			w15.TopAttach = ((uint)(3));
			w15.BottomAttach = ((uint)(4));
			w15.XOptions = ((global::Gtk.AttachOptions)(4));
			w15.YOptions = ((global::Gtk.AttachOptions)(4));
			this.notebook1.Add (this.table2);
			global::Gtk.Notebook.NotebookChild w16 = ((global::Gtk.Notebook.NotebookChild)(this.notebook1 [this.table2]));
			w16.Position = 1;
			// Notebook tab
			this.lblRegister = new global::Gtk.Label ();
			this.lblRegister.Name = "lblRegister";
			this.lblRegister.LabelProp = global::Mono.Unix.Catalog.GetString ("Register");
			this.notebook1.SetTabLabel (this.table2, this.lblRegister);
			this.lblRegister.ShowAll ();
			w1.Add (this.notebook1);
			global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(w1 [this.notebook1]));
			w17.Position = 0;
			w17.Expand = false;
			w17.Fill = false;
			w17.Padding = ((uint)(5));
			// Internal child Moscrif.IDE.Controls.LoginDialog.ActionArea
			global::Gtk.HButtonBox w18 = this.ActionArea;
			w18.Name = "dialog1_ActionArea";
			w18.Spacing = 10;
			w18.BorderWidth = ((uint)(5));
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
			this.btnInfo = new global::Gtk.Button ();
			this.btnInfo.CanFocus = true;
			this.btnInfo.Name = "btnInfo";
			this.btnInfo.UseUnderline = true;
			this.btnInfo.Label = global::Mono.Unix.Catalog.GetString ("----");
			this.AddActionWidget (this.btnInfo, 0);
			global::Gtk.ButtonBox.ButtonBoxChild w20 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w18 [this.btnInfo]));
			w20.Position = 1;
			w20.Expand = false;
			w20.Fill = false;
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 330;
			this.DefaultHeight = 244;
			this.Show ();
			this.notebook1.SwitchPage += new global::Gtk.SwitchPageHandler (this.OnNotebook1SwitchPage);
			this.entrPassword.KeyReleaseEvent += new global::Gtk.KeyReleaseEventHandler (this.OnEntrPasswordKeyReleaseEvent);
			this.entrLogin.KeyReleaseEvent += new global::Gtk.KeyReleaseEventHandler (this.OnEntrLoginKeyReleaseEvent);
			this.btnInfo.Clicked += new global::System.EventHandler (this.OnBtnInfoClicked);
		}
	}
}