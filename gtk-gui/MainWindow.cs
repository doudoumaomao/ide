
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.UIManager UIManager;
	private global::Gtk.RadioAction aaaAction;
	private global::Gtk.VBox vbMain;
	private global::Gtk.HBox hbMenu;
	private global::Gtk.VPaned vpMenuLeft;
	private global::Gtk.VBox vbMenuMidle;
	private global::Gtk.VPaned vpMenuRight;
	private global::Gtk.VPaned vpBody;
	private global::Gtk.HPaned hpBodyMidle;
	private global::Gtk.HPaned hpOutput;
	private global::Gtk.Statusbar statusbar1;
	private global::Gtk.HBox hbox1;
	private global::Gtk.Label lblMessage1;
	private global::Gtk.Table table1;
	private global::Gtk.Button btnSocketServer;
	private global::Gtk.ComboBox cbIpAdress;
	private global::Gtk.Label lblMessage2;
	private global::Gtk.Label lblPort;
	private global::Gtk.ProgressBar pbProgress;
	private global::Moscrif.IDE.Components.LoginLogoutControl loginlogoutcontrol1;
	
	protected virtual void Build ()
	{
		global::Stetic.Gui.Initialize (this);
		// Widget MainWindow
		this.UIManager = new global::Gtk.UIManager ();
		global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup ("Default");
		this.aaaAction = new global::Gtk.RadioAction ("aaaAction", global::Mono.Unix.Catalog.GetString ("aaa"), null, null, 0);
		this.aaaAction.Group = new global::GLib.SList (global::System.IntPtr.Zero);
		this.aaaAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("aaa");
		w1.Add (this.aaaAction, null);
		this.UIManager.InsertActionGroup (w1, 0);
		this.AddAccelGroup (this.UIManager.AccelGroup);
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString ("Moscrif Ide");
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.vbMain = new global::Gtk.VBox ();
		this.vbMain.Name = "vbMain";
		this.vbMain.Spacing = 6;
		// Container child vbMain.Gtk.Box+BoxChild
		this.hbMenu = new global::Gtk.HBox ();
		this.hbMenu.Name = "hbMenu";
		// Container child hbMenu.Gtk.Box+BoxChild
		this.vpMenuLeft = new global::Gtk.VPaned ();
		this.vpMenuLeft.WidthRequest = 290;
		this.vpMenuLeft.CanFocus = true;
		this.vpMenuLeft.Name = "vpMenuLeft";
		this.vpMenuLeft.Position = 1;
		this.hbMenu.Add (this.vpMenuLeft);
		global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbMenu [this.vpMenuLeft]));
		w2.Position = 0;
		w2.Expand = false;
		// Container child hbMenu.Gtk.Box+BoxChild
		this.vbMenuMidle = new global::Gtk.VBox ();
		this.vbMenuMidle.Name = "vbMenuMidle";
		this.hbMenu.Add (this.vbMenuMidle);
		global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbMenu [this.vbMenuMidle]));
		w3.Position = 1;
		// Container child hbMenu.Gtk.Box+BoxChild
		this.vpMenuRight = new global::Gtk.VPaned ();
		this.vpMenuRight.WidthRequest = 385;
		this.vpMenuRight.CanFocus = true;
		this.vpMenuRight.Name = "vpMenuRight";
		this.vpMenuRight.Position = 1;
		this.hbMenu.Add (this.vpMenuRight);
		global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbMenu [this.vpMenuRight]));
		w4.Position = 2;
		w4.Expand = false;
		this.vbMain.Add (this.hbMenu);
		global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbMain [this.hbMenu]));
		w5.Position = 0;
		w5.Expand = false;
		// Container child vbMain.Gtk.Box+BoxChild
		this.vpBody = new global::Gtk.VPaned ();
		this.vpBody.CanFocus = true;
		this.vpBody.Name = "vpBody";
		this.vpBody.Position = 311;
		// Container child vpBody.Gtk.Paned+PanedChild
		this.hpBodyMidle = new global::Gtk.HPaned ();
		this.hpBodyMidle.CanFocus = true;
		this.hpBodyMidle.Name = "hpBodyMidle";
		this.hpBodyMidle.Position = 179;
		this.vpBody.Add (this.hpBodyMidle);
		global::Gtk.Paned.PanedChild w6 = ((global::Gtk.Paned.PanedChild)(this.vpBody [this.hpBodyMidle]));
		w6.Resize = false;
		// Container child vpBody.Gtk.Paned+PanedChild
		this.hpOutput = new global::Gtk.HPaned ();
		this.hpOutput.CanFocus = true;
		this.hpOutput.Name = "hpOutput";
		this.hpOutput.Position = 509;
		this.vpBody.Add (this.hpOutput);
		this.vbMain.Add (this.vpBody);
		global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbMain [this.vpBody]));
		w8.Position = 1;
		// Container child vbMain.Gtk.Box+BoxChild
		this.statusbar1 = new global::Gtk.Statusbar ();
		this.statusbar1.Name = "statusbar1";
		this.statusbar1.Spacing = 6;
		this.statusbar1.BorderWidth = ((uint)(1));
		// Container child statusbar1.Gtk.Box+BoxChild
		this.hbox1 = new global::Gtk.HBox ();
		this.hbox1.Name = "hbox1";
		this.hbox1.Spacing = 7;
		// Container child hbox1.Gtk.Box+BoxChild
		this.lblMessage1 = new global::Gtk.Label ();
		this.lblMessage1.WidthRequest = 175;
		this.lblMessage1.Name = "lblMessage1";
		this.lblMessage1.LabelProp = global::Mono.Unix.Catalog.GetString ("lblMessage1");
		this.lblMessage1.Selectable = true;
		this.hbox1.Add (this.lblMessage1);
		global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.lblMessage1]));
		w9.Position = 0;
		w9.Expand = false;
		w9.Fill = false;
		// Container child hbox1.Gtk.Box+BoxChild
		this.table1 = new global::Gtk.Table (((uint)(1)), ((uint)(4)), false);
		this.table1.Name = "table1";
		this.table1.RowSpacing = ((uint)(6));
		this.table1.ColumnSpacing = ((uint)(6));
		// Container child table1.Gtk.Table+TableChild
		this.btnSocketServer = new global::Gtk.Button ();
		this.btnSocketServer.WidthRequest = 22;
		this.btnSocketServer.HeightRequest = 22;
		this.btnSocketServer.CanFocus = true;
		this.btnSocketServer.Name = "btnSocketServer";
		this.btnSocketServer.UseUnderline = true;
		this.btnSocketServer.Relief = ((global::Gtk.ReliefStyle)(2));
		// Container child btnSocketServer.Gtk.Container+ContainerChild
		global::Gtk.Alignment w10 = new global::Gtk.Alignment (0.5F, 0.5F, 0F, 0F);
		// Container child GtkAlignment.Gtk.Container+ContainerChild
		global::Gtk.HBox w11 = new global::Gtk.HBox ();
		w11.Spacing = 2;
		// Container child GtkHBox.Gtk.Container+ContainerChild
		global::Gtk.Image w12 = new global::Gtk.Image ();
		w11.Add (w12);
		// Container child GtkHBox.Gtk.Container+ContainerChild
		global::Gtk.Label w14 = new global::Gtk.Label ();
		w11.Add (w14);
		w10.Add (w11);
		this.btnSocketServer.Add (w10);
		this.table1.Add (this.btnSocketServer);
		global::Gtk.Table.TableChild w18 = ((global::Gtk.Table.TableChild)(this.table1 [this.btnSocketServer]));
		w18.LeftAttach = ((uint)(3));
		w18.RightAttach = ((uint)(4));
		w18.XOptions = ((global::Gtk.AttachOptions)(4));
		w18.YOptions = ((global::Gtk.AttachOptions)(4));
		// Container child table1.Gtk.Table+TableChild
		this.cbIpAdress = global::Gtk.ComboBox.NewText ();
		this.cbIpAdress.Name = "cbIpAdress";
		this.table1.Add (this.cbIpAdress);
		global::Gtk.Table.TableChild w19 = ((global::Gtk.Table.TableChild)(this.table1 [this.cbIpAdress]));
		w19.LeftAttach = ((uint)(1));
		w19.RightAttach = ((uint)(2));
		w19.XOptions = ((global::Gtk.AttachOptions)(4));
		w19.YOptions = ((global::Gtk.AttachOptions)(4));
		// Container child table1.Gtk.Table+TableChild
		this.lblMessage2 = new global::Gtk.Label ();
		this.lblMessage2.WidthRequest = 175;
		this.lblMessage2.Name = "lblMessage2";
		this.lblMessage2.LabelProp = global::Mono.Unix.Catalog.GetString ("lblMessage2");
		this.table1.Add (this.lblMessage2);
		global::Gtk.Table.TableChild w20 = ((global::Gtk.Table.TableChild)(this.table1 [this.lblMessage2]));
		w20.XOptions = ((global::Gtk.AttachOptions)(4));
		w20.YOptions = ((global::Gtk.AttachOptions)(4));
		// Container child table1.Gtk.Table+TableChild
		this.lblPort = new global::Gtk.Label ();
		this.lblPort.Name = "lblPort";
		this.table1.Add (this.lblPort);
		global::Gtk.Table.TableChild w21 = ((global::Gtk.Table.TableChild)(this.table1 [this.lblPort]));
		w21.LeftAttach = ((uint)(2));
		w21.RightAttach = ((uint)(3));
		w21.XOptions = ((global::Gtk.AttachOptions)(4));
		w21.YOptions = ((global::Gtk.AttachOptions)(4));
		this.hbox1.Add (this.table1);
		global::Gtk.Box.BoxChild w22 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.table1]));
		w22.Position = 1;
		w22.Expand = false;
		w22.Fill = false;
		// Container child hbox1.Gtk.Box+BoxChild
		this.pbProgress = new global::Gtk.ProgressBar ();
		this.pbProgress.Name = "pbProgress";
		this.hbox1.Add (this.pbProgress);
		global::Gtk.Box.BoxChild w23 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.pbProgress]));
		w23.Position = 2;
		this.statusbar1.Add (this.hbox1);
		global::Gtk.Box.BoxChild w24 = ((global::Gtk.Box.BoxChild)(this.statusbar1 [this.hbox1]));
		w24.Position = 1;
		// Container child statusbar1.Gtk.Box+BoxChild
		this.loginlogoutcontrol1 = new global::Moscrif.IDE.Components.LoginLogoutControl ();
		this.loginlogoutcontrol1.Events = ((global::Gdk.EventMask)(256));
		this.loginlogoutcontrol1.Name = "loginlogoutcontrol1";
		this.statusbar1.Add (this.loginlogoutcontrol1);
		global::Gtk.Box.BoxChild w25 = ((global::Gtk.Box.BoxChild)(this.statusbar1 [this.loginlogoutcontrol1]));
		w25.Position = 2;
		w25.Expand = false;
		w25.Fill = false;
		this.vbMain.Add (this.statusbar1);
		global::Gtk.Box.BoxChild w26 = ((global::Gtk.Box.BoxChild)(this.vbMain [this.statusbar1]));
		w26.Position = 2;
		w26.Expand = false;
		w26.Fill = false;
		this.Add (this.vbMain);
		if ((this.Child != null)) {
			this.Child.ShowAll ();
		}
		this.DefaultWidth = 1315;
		this.DefaultHeight = 667;
		this.Hide ();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
		this.btnSocketServer.Clicked += new global::System.EventHandler (this.OnBtnSocketServerClicked);
	}
}