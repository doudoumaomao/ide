using System;
using System.Collections.Generic;
using System.Collections;
using Gtk;
using Gdk;
using System.IO;
using Mono.TextEditor;
using Moscrif.IDE;
using Moscrif.IDE.Components;
using Moscrif.IDE.Controls;
using Moscrif.IDE.Editors;
using Moscrif.IDE.Execution;
using Moscrif.IDE.Workspace;
using Moscrif.IDE.Devices;
using Moscrif.IDE.Tool;
using Moscrif.IDE.Task;
using Moscrif.IDE.Settings;
using MessageDialogs = Moscrif.IDE.Controls.MessageDialog;
using Moscrif.IDE.Iface.Entities;
using System.Text;
using System.Security.Principal;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using Moscrif.IDE.Iface;

public partial class MainWindow : Gtk.Window
{

	public ActionManager ActionUiManager = new ActionManager();
	private ListStore projectModel = new ListStore(typeof(string), typeof(string));
	private ListStore resolutionModel = new ListStore(typeof(string), typeof(string));
	private ListStore deviceModel = new ListStore(typeof(string), typeof(int));
	private bool runningEmulator = false;

	Pixbuf pixbufGreen = null;
	Pixbuf pixbufRed = null;

	public bool RunningEmulator
	{
		get { return runningEmulator; }
		set { runningEmulator = value;}
	}

	private ComboBox cbProject = new ComboBox();
	private ComboBox cbDevice = new ComboBox();
	private ComboBox cbResolution = new ComboBox();

	private MenuBar mainMenu;
	Toolbar toolbarLeft = new Toolbar();
	Toolbar toolbarMiddle = new Toolbar();
	Toolbar toolbarRight = new Toolbar();
	public EditorNotebook EditorNotebook = new EditorNotebook();
	public Notebook FileNotebook = new Notebook();

	public Notebook OutputNotebook = new Notebook();
	public Notebook TaskNotebook = new Notebook();
	public WorkspaceTree WorkspaceTree = null;
	public FrameworkTree FrameworkTree = null;
	public FileExplorer FileExplorer = null;


	public OutputConsole OutputConsole = null;
	public ProcessOutput ProcessOutput = null;
	public ErrorOutput ErrorOutput = null;
	public LogOutput LogOutput = null;

	public BookmarkOutput BookmarkOutput = null;
	public TodoOutput TodoOutput = null;
	public FindOutput FindOutput = null;
	public FindReplaceControl FindReplaceControl = new FindReplaceControl();

	public LogMonitor LogMonitor = null;
	public LogGarbageCollector LogGarbageCollector = null;

	private NotebookMenuLabel garbageColectorLabel;

	private SplashScreenForm splash;
	//private bool statusSplash = false;

	/*bool update_status ()
     	{
         	statusSplash = splash.WaitingSplash;
         	return true;
     	}*/


	public MainWindow(string[] arguments) : base(Gtk.WindowType.Toplevel)
	{
		bool showSplash = true;
		bool openFileFromArg = false;
		string openFileAgument = "";
		for (int i = 0; i < arguments.Length; i++){
			Logger.LogDebugInfo("arg->{0}",arguments[i]);

			string arg = arguments[i];
			if (arg.StartsWith("-nosplash")){
				if (arg == "-nosplash")
					showSplash = false;
			}
			if(!arg.EndsWith(".exe")){ // argument file msw
				if(File.Exists(arg)){
					openFileAgument =arg;
					if(arg.ToLower().EndsWith(".msw"))
						openFileFromArg = true;
				}
			}
		}

		StringBuilder sbError = new StringBuilder();
		if(!File.Exists(MainClass.Settings.FilePath)){

			if(showSplash)
				splash = new SplashScreenForm(false);

			//statusSplash = true;
			Moscrif.IDE.Tool.Logger.LogDebugInfo(String.Format("Setting inicialize -{0}",DateTime.Now));
			string file = System.IO.Path.Combine(MainClass.Paths.SettingDir, "keybinding");
			if(MainClass.Platform.IsMac){
				Moscrif.IDE.Iface.KeyBindings.CreateKeyBindingsMac(file);
			} else{
				Moscrif.IDE.Iface.KeyBindings.CreateKeyBindingsWin(file);
			}

			MainClass.Settings.SaveSettings();


		} else {
			if(showSplash)
				splash = new SplashScreenForm(false);
		}

		if(MainClass.Platform.IsMac){
				ApplicationEvents.Quit += delegate (object sender, ApplicationQuitEventArgs e) {
					Application.Quit ();
					e.Handled = true;
				};

				ApplicationEvents.Reopen += delegate (object sender, ApplicationEventArgs e) {
					MainClass.MainWindow.Deiconify ();
					MainClass.MainWindow.Visible = true;
					e.Handled = true;
				};
		}

		Moscrif.IDE.Tool.Logger.LogDebugInfo(String.Format("splash.show-{0}",DateTime.Now));
		Console.WriteLine(String.Format("splash.show-{0}",DateTime.Now));

		if(showSplash)
			splash.ShowAll();

		//this.Maximize();
		StockIconsManager.Initialize();
		Moscrif.IDE.Tool.Logger.LogDebugInfo(String.Format("mainwindow.build.start-{0}",DateTime.Now));
		Build();
		Moscrif.IDE.Tool.Logger.LogDebugInfo(String.Format("mainwindow.build.end-{0}",DateTime.Now));
		//this.HideAll();

		SetSettingColor();

		lblMessage1.Text="";
		lblMessage2.Text="";
		if (String.IsNullOrEmpty(MainClass.Paths.TempDir))
		{

			MessageDialogs md =
				new MessageDialogs(MessageDialogs.DialogButtonType.Ok, MainClass.Languages.Translate("cannot_create_temp"),MainClass.Paths.TempDir, Gtk.MessageType.Error,null);
			md.ShowDialog();
			return;
		}
		string fullpath = MainClass.Paths.StylesDir;

		bool success = true;

		if (!Directory.Exists(fullpath))
			try {
				Directory.CreateDirectory(fullpath);
			} catch {
				success = false;
			}
		if (success){
			try {
				Mono.TextEditor.Highlighting.SyntaxModeService.LoadStylesAndModes(fullpath);
			} catch(Exception ex) {
				sbError.AppendLine("ERROR: " + ex.Message);
				Logger.Log(ex.Message);
			}
		}

		ActionUiManager.UI.AddWidget += new AddWidgetHandler(OnWidgetAdd);
		ActionUiManager.UI.ConnectProxy += new ConnectProxyHandler(OnProxyConnect);
		ActionUiManager.LoadInterface();
		this.AddAccelGroup(ActionUiManager.UI.AccelGroup);

		WorkspaceTree = new WorkspaceTree();
		FrameworkTree = new FrameworkTree();

		FileExplorer = new FileExplorer();

		FileNotebook.AppendPage(WorkspaceTree, new NotebookLabel("workspace-tree.png",MainClass.Languages.Translate("projects")));
		FileNotebook.BorderWidth = 2;

		FileNotebook.AppendPage(FrameworkTree, new NotebookLabel("libs.png",MainClass.Languages.Translate("libs")));
		FileNotebook.BorderWidth = 2;

		FileNotebook.AppendPage(FileExplorer, new NotebookLabel("workspace-tree.png",MainClass.Languages.Translate("files")));
		FileNotebook.BorderWidth = 2;

		FileNotebook.CurrentPage = 1;

		hpBodyMidle.Pack2(EditorNotebook, true, true);
		hpBodyMidle.Pack1(FileNotebook, false, true);
		FileNotebook.WidthRequest = 500;
		//hpBodyMidle.ShowAll();
		hpBodyMidle.ResizeMode = ResizeMode.Queue;

		try {
			//ActionUiManager.RecentFiles(MainClass.Settings.RecentFiles.GetFiles());
			//ActionUiManager.RecentWorkspace(MainClass.Settings.RecentFiles.GetWorkspace());
			ActionUiManager.RecentAll(MainClass.Settings.RecentFiles.GetFiles(),
			                          MainClass.Settings.RecentFiles.GetProjects(),
			                                          MainClass.Settings.RecentFiles.GetWorkspace());
		} catch {
		}

		cbResolution = new ComboBox();

		CellRendererText resolRenderer = new CellRendererText();

		cbResolution.Changed += new EventHandler(OnComboResolutionChanged);
		cbResolution.PackStart(resolRenderer, true);
		cbResolution.AddAttribute(resolRenderer, "text", 0);
		cbResolution.WidthRequest = 175;
		cbResolution.Model = resolutionModel;
		cbResolution.SetCellDataFunc(resolRenderer, new Gtk.CellLayoutDataFunc(RenderResolution));

		CellRendererText textRenderer = new CellRendererText();
		cbProject = new ComboBox();
		cbProject.Changed += new EventHandler(OnComboProjectChanged);
		cbProject.PackStart(textRenderer, true);
		cbProject.AddAttribute(textRenderer, "text", 0);
		cbProject.WidthRequest = 125;

		cbProject.Model = projectModel;

		cbDevice = new ComboBox();
		cbDevice.Changed += new EventHandler(OnComboDeviceChanged);
		cbDevice.PackStart(textRenderer, true);
		cbDevice.AddAttribute(textRenderer, "text", 0);
		cbDevice.WidthRequest = 110;
		cbDevice.Model = deviceModel;


		ReloadSettings(false);
		OpenFile("StartPage",false);

		PageIsChanged("StartPage");

		if ((MainClass.Settings.Account != null) && (MainClass.Settings.Account.Remember)){
			MainClass.User = MainClass.Settings.Account;
		} else {
			MainClass.User = null;
		}

		SetLogin();

		OutputConsole = new OutputConsole();

		Gtk.Menu outputMenu = new Gtk.Menu();
		GetOutputMenu(ref outputMenu);

		BookmarkOutput = new BookmarkOutput();

		OutputNotebook.AppendPage(OutputConsole, new NotebookMenuLabel("console.png",MainClass.Languages.Translate("console"),outputMenu));
		OutputNotebook.AppendPage(FindReplaceControl, new NotebookLabel("find.png",MainClass.Languages.Translate("find")));
		OutputNotebook.AppendPage(BookmarkOutput, new NotebookLabel("bookmark.png",MainClass.Languages.Translate("bookmarks")));

		LogMonitor = new LogMonitor();
		Gtk.Menu monMenu = new Gtk.Menu();
		GetOutputMenu(ref monMenu, LogMonitor);

		OutputNotebook.AppendPage(LogMonitor, new NotebookMenuLabel("log.png",MainClass.Languages.Translate("Monitor"),monMenu));

		LogGarbageCollector = new LogGarbageCollector();
		Gtk.Menu gcMenu = new Gtk.Menu();
		GetOutputMenu(ref gcMenu, LogGarbageCollector);

		garbageColectorLabel =new NotebookMenuLabel("log.png",MainClass.Languages.Translate("garbage_collector",0),gcMenu);

		OutputNotebook.AppendPage(LogGarbageCollector,garbageColectorLabel );

		hpOutput.Add1(OutputNotebook);

		ProcessOutput = new ProcessOutput();
		Gtk.Menu taskMenu = new Gtk.Menu();
		GetOutputMenu(ref taskMenu, ProcessOutput);
		TaskNotebook.AppendPage(ProcessOutput, new NotebookMenuLabel("task.png",MainClass.Languages.Translate("process"),taskMenu));

		ErrorOutput = new ErrorOutput();
		Gtk.Menu errorMenu = new Gtk.Menu();
		GetOutputMenu(ref errorMenu, ErrorOutput);
		TaskNotebook.AppendPage(ErrorOutput, new NotebookMenuLabel("error.png",MainClass.Languages.Translate("errors"),errorMenu));


		LogOutput = new LogOutput();
		Gtk.Menu logMenu = new Gtk.Menu();
		GetOutputMenu(ref logMenu, LogOutput);
		TaskNotebook.AppendPage(LogOutput, new NotebookMenuLabel("log.png",MainClass.Languages.Translate("logs"),logMenu));


		TodoOutput = new TodoOutput();
		//Gtk.Menu todoMenu = new Gtk.Menu();
		//GetOutputMenu(ref todoMenu, TodoOutput);
		TaskNotebook.AppendPage(TodoOutput, new NotebookLabel("task.png",MainClass.Languages.Translate("task")));


		FindOutput = new FindOutput();
		Gtk.Menu findMenu = new Gtk.Menu();
		GetOutputMenu(ref findMenu, FindOutput);
		TaskNotebook.AppendPage(FindOutput, new NotebookMenuLabel("find.png",MainClass.Languages.Translate("find_result"),findMenu));


		hpOutput.Add2(TaskNotebook);

		FirstShow();
		//this.ShowAll();

		EditorNotebook.PageIsChanged +=PageIsChanged;

		if (openFileFromArg){ // open workspace from argument file
		 	Workspace workspace = Workspace.OpenWorkspace(openFileAgument);
			Console.WriteLine("Open File From Arg");
			if (workspace != null){
				ReloadWorkspace(workspace, false,false);
				Console.WriteLine("RecentFiles");
				MainClass.Settings.RecentFiles.AddWorkspace(workspace.FilePath, workspace.FilePath);
				//ActionUiManager.RefreshRecentWorkspace(MainClass.Settings.RecentFiles.GetWorkspace());
				ActionUiManager.RefreshRecentAll(MainClass.Settings.RecentFiles.GetFiles(),
			                          MainClass.Settings.RecentFiles.GetProjects(),
		                                 MainClass.Settings.RecentFiles.GetWorkspace());
			} else
				openFileFromArg = false;
		} else if((MainClass.Settings.OpenLastOpenedWorkspace) && !openFileFromArg ){
			if(String.IsNullOrEmpty(MainClass.Workspace.FilePath) && (String.IsNullOrEmpty(MainClass.Settings.CurrentWorkspace) ) ){
				/*MessageDialogs md =
				new MessageDialogs(MessageDialogs.DialogButtonType.Ok, MainClass.Languages.Translate("workspace_is_corrupted"), null, Gtk.MessageType.Error,null);
					md.ShowDialog();*/
				MainClass.Settings.CurrentWorkspace = "";
			} else{
				ReloadWorkspace(MainClass.Workspace, false,false);
			}
		} else if(!MainClass.Settings.OpenLastOpenedWorkspace && (!openFileFromArg) ){
			MainClass.Workspace = new Workspace();
			MainClass.Settings.CurrentWorkspace = "";
		}

		if(!String.IsNullOrEmpty(openFileAgument)){
			if(!openFileAgument.ToLower().EndsWith(".msw"))
				OpenFile(openFileAgument,true);
		}

		EditorNotebook.Page=0;

		WorkspaceTree.FileIsSelected+= delegate(string fileName, int fileType,string appFileName) {

			if(String.IsNullOrEmpty(fileName)){
				SetSensitiveMenu(false);
				return;
			}
			ActionUiManager.SetSensitive("propertyall",true);

			SetSensitiveMenu(true);

			if(MainClass.Settings.AutoSelectProject){

				if((TypeFile)fileType == TypeFile.AppFile)
					SetActualProject(fileName);
				else if (!String.IsNullOrEmpty(appFileName))
					SetActualProject(appFileName);
			}
		};

		SetSensitiveMenu(false);

		string newUpdater = System.IO.Path.Combine(MainClass.Paths.AppPath,"moscrif-updater.exe.new");

		if(System.IO.File.Exists(newUpdater)){

			string oldUpdater = System.IO.Path.Combine(MainClass.Paths.AppPath,"moscrif-updater.exe");
			try{
				if(File.Exists(oldUpdater))
					File.Delete(oldUpdater);

				  File.Copy(newUpdater,oldUpdater);

				  File.Delete(newUpdater);
			}catch(Exception ex){
				sbError.AppendLine("WARNING: " + ex.Message);
				Logger.Error(ex.Message);
			}
		}

		//Gtk.Drag.
		Gtk.Drag.DestSet (this, 0, null, 0);
		this.DragDrop += delegate(object o, DragDropArgs args) {

			Gdk.DragContext dc=args.Context;

			foreach (object k in dc.Data.Keys){
				Console.WriteLine(k);
			}
			foreach (object v in dc.Data.Values){
				Console.WriteLine(v);
			}

			Atom [] targets = args.Context.Targets;
			foreach (Atom a in targets){
				//Console.WriteLine (a.Name);
				if(a.Name == "text/uri-list")
					Gtk.Drag.GetData (o as Widget, dc, a, args.Time);
			}
		};


		this.DragDataReceived += delegate(object o, DragDataReceivedArgs args) {

			//Gdk.DragContext dc=args.Context;
			if(args.SelectionData != null){
				string fullData = System.Text.Encoding.UTF8.GetString (args.SelectionData.Data);
	
				foreach (string individualFile in fullData.Split ('\n')) {
					string file = individualFile.Trim ();
					if (file.StartsWith ("file://")) {
						file = new Uri(file).LocalPath;
	
						try {
							OpenFile(file,true);
						} catch (Exception e) {
							sbError.AppendLine("ERROR: " + String.Format("unable to open file {0} exception was :\n{1}", file, e.ToString()));
							Logger.Error(String.Format("unable to open file {0} exception was :\n{1}", file, e.ToString()));
						}
	
					}
	
				}
			}
		};

		this.ShowAll();
		this.Maximize();

		//SetDefaultvpBody();

		int x, y, w, h, d = 0;
		hpOutput.Parent.ParentWindow.GetGeometry(out x, out y, out w, out h, out d);
		hpOutput.Position = w / 2;

		vpMenuRight.Parent.ParentWindow.GetGeometry(out x, out y, out w, out h, out d);
		if(w<1200){
			vpMenuRight.WidthRequest =125;
		} else {
			if(MainClass.Platform.IsMac)
				vpMenuRight.WidthRequest =385;
			else 
				vpMenuRight.WidthRequest =355;
		}

		if (MainClass.Platform.IsMac) {
			try{
				ActionUiManager.CreateMacMenu(mainMenu);

			} catch (Exception ex){
				sbError.AppendLine(String.Format("ERROR: Mac IGE Main Menu failed."+ex.Message));
				Logger.Error("Mac IGE Main Menu failed."+ex.Message,null);
			}
		}

		ReloadPanel();

		Moscrif.IDE.Tool.Logger.LogDebugInfo(String.Format("splash.hide-{0}",DateTime.Now));

		Console.WriteLine(String.Format("splash.hide-{0}",DateTime.Now));

		if(showSplash)
			splash.HideAll();

		EditorNotebook.OnLoadFinish = true;

		OutputConsole.WriteError(sbError.ToString());

		//Moscrif.IDE.Iface.SocetServer.OutputStreamChanged +=
		IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());

		lblPort.Text =MainClass.Settings.SocetServerPort;
		int indx = 0;
		foreach (IPAddress ip in ipHostInfo.AddressList){
			cbIpAdress.AppendText(ip.ToString());

			if (ip.AddressFamily == AddressFamily.InterNetwork){
				if(cbIpAdress.Active <0)
					cbIpAdress.Active = indx;
				//ipAddress = ip;
				//Tool.Logger.Debug("InterNetwork IP- >"+ipAddress.ToString());
			}
			indx++;
		}

		Moscrif.IDE.Iface.SocketServer.OutputClientChanged+= delegate(object sndr, string message) {
			Gtk.Application.Invoke(delegate{
				//this.OutputConsole.WriteText("\n");
				this.OutputConsole.WriteText(message);
				//Console.WriteLine("\n");
				Console.WriteLine(message);
			});
		};

		cbIpAdress.Changed += delegate(object sender, EventArgs e) {
		};

		string fileRed = System.IO.Path.Combine(MainClass.Paths.ResDir, "socket-red.png");
		string fileGreen = System.IO.Path.Combine(MainClass.Paths.ResDir, "socket-green.png");

		if (System.IO.File.Exists(fileRed)) {
			pixbufRed = new Pixbuf(fileRed);
		}
		if (System.IO.File.Exists(fileGreen)) {
			pixbufGreen = new Pixbuf(fileGreen);
		}
		btnSocketServer.Relief = ReliefStyle.None;
		btnSocketServer.CanFocus = false;
		btnSocketServer.WidthRequest = btnSocketServer.HeightRequest =24;
		btnSocketServer.Image = new Gtk.Image(pixbufRed);
		//lblSocket.Text = ip;


		Thread ExecEditorThreads = new Thread(new ThreadStart(ExecEditorThread));
		//filllStartPageThread.Priority = ThreadPriority.Normal;
		ExecEditorThreads.Name = "ExecEditorThread";
		ExecEditorThreads.IsBackground = true;
		ExecEditorThreads.Start();

		/*if((MainClass.Settings.Account == null) || (String.IsNullOrEmpty(MainClass.Settings.Account.Token))){
			LoginDialog ld = new LoginDialog(null);
			ld.Run();
			ld.Destroy();
		}*/
	}
	


	private void RenderResolution (CellLayout cell_layout, CellRenderer cell, TreeModel model, TreeIter iter)
		//(Gtk.TreeViewColumn column, Gtk.CellRenderer cell, Gtk.TreeModel model, Gtk.TreeIter iter)
	{
		string type = (string) model.GetValue (iter, 1);

		Pango.FontDescription fd = new Pango.FontDescription();

		if ((type == "-1") || (type == "-2")) {
			//(cell as Gtk.CellRendererText).ForegroundGdk = new Gdk.Color(255,111,0); // "black";
			fd.Style =  Pango.Style.Italic;
		}
		(cell as Gtk.CellRendererText).FontDesc = fd;
	}

	private void PageIsChanged (string filename){

		if(String.IsNullOrEmpty(filename)) return;

		WorkspaceTree.SetSelectedFile(filename);

		lblMessage2.Text= System.IO.Path.GetFileName(filename);

		string ext = System.IO.Path.GetExtension(filename);

			if (filename == "StartPage"){
				ActionUiManager.SetSensitive("save",false);
				ActionUiManager.SetSensitive("saveas",false);
				ActionUiManager.SetEditMenu(false);
				//ActionUiManager.SetSensitive("EditAction",false);
			} else {
				switch (ext) {
				case ".png":
				case ".jpg":
				case ".jpeg":
				case ".bmp":
				case ".gif":
				case ".tif":
				case ".svg":
					ActionUiManager.SetSensitive("save",true);
					ActionUiManager.SetSensitive("saveas",true);
					ActionUiManager.SetEditMenu(false);
					break;
				case ".db":
					ActionUiManager.SetSensitive("save",false);
					ActionUiManager.SetSensitive("saveas",false);
					ActionUiManager.SetEditMenu(false);
					//ActionUiManager.SetSensitive("EditAction",false);
					break;
				default:
					ActionUiManager.SetSensitive("save",true);
					ActionUiManager.SetSensitive("saveas",true);
					ActionUiManager.SetEditMenu(true);
				//ActionUiManager.SetSensitive("EditAction",true);
					break;
				}
		}

	}


	private void FirstShow(){
		while (Application.EventsPending ())
			Application.RunIteration ();
		OutputConsole.QueueDraw();
		ProcessOutput.QueueDraw();

		if(MainClass.Platform.IsMac){
			ActionUiManager.ReloadKeyBind();
		}
	}

	private void SetDefaultvpBody(){

		int x2, y2, w2, h2, d2 = 0;
		vpBody.Parent.ParentWindow.GetGeometry(out x2, out y2, out w2, out h2, out d2);

		int jednaStvrtina =(h2 / 4);
		//Console.WriteLine("jednaStvrtina -> {0}",jednaStvrtina);

		if (jednaStvrtina< 250)
			jednaStvrtina = 250;
		if (jednaStvrtina> 400)
			jednaStvrtina = 400;

		//Console.WriteLine("h2 -> {0}",h2);
		int triStvrtiny = h2-jednaStvrtina;
		//Console.WriteLine("triStvrtiny -> {0}",triStvrtiny);
		vpBody.Position =triStvrtiny;
	}

	private void GetOutputMenu(ref Gtk.Menu outputMenu){

		MenuItem miC = new MenuItem(MainClass.Languages.Translate("clear"));
		miC.Activated+= delegate {
			OutputConsole.Clear();
		};
		outputMenu.Add(miC);

		MenuItem miS = new MenuItem(MainClass.Languages.Translate("save"));
		miS.Activated+= delegate {
			OutputConsole.Save();
		};
		outputMenu.Add(miS);
	}

	private void GetOutputMenu(ref Gtk.Menu outputMenu,ITaskOutput taskOut ){

		MenuItem miC = new MenuItem(MainClass.Languages.Translate("clear"));
		miC.Activated+= delegate {
			taskOut.ClearOutput();
		};
		outputMenu.Add(miC);
	}


	public void CreateWorkspace(string workspaceFile,string workspaceName,string workspaceOutput,string workspaceRoot,bool copyLibs){

		Workspace workspace = null;
		try{
			workspace = Workspace.CreateWorkspace(workspaceFile,workspaceName,workspaceOutput,workspaceRoot,copyLibs);
		}catch(Exception ex){
			MessageDialogs mdEror =
				new MessageDialogs(MessageDialogs.DialogButtonType.Ok, ex.Message,"", Gtk.MessageType.Error);
			mdEror.ShowDialog();
			return;
		}
		if(workspace == null) return;

		TreeIter iter;
		if (cbResolution.GetActiveIter(out iter)) {
			string prj = (string)cbResolution.Model.GetValue(iter, 1);

			workspace.ActualResolution = prj;
		}

		if (workspace != null)
		{
			ReloadWorkspace(workspace,true,true);
		}
	}

	public void SaveWorkspace()
	{
		if (!String.IsNullOrEmpty(MainClass.Workspace.FilePath)){
			int bottonPane =MainClass.Workspace.VpBodyHeight;
			int leftPane =MainClass.Workspace.HpBodyMiddleWidth;

			if(MainClass.Workspace.ShowLeftPane)
				leftPane =hpBodyMidle.Position;

			if(MainClass.Workspace.ShowBottomPane)
				bottonPane =vpBody.Position;

			MainClass.Workspace.SaveWorkspace(EditorNotebook.OpenFiles, bottonPane,leftPane , hpOutput.Position);
		}

	}

	public bool CloseActualWorkspace()
	{
		SaveWorkspace();
		if(!this.EditorNotebook.CloseAllPage()){
			return false;
		}
		MainClass.Workspace.SaveUserWorkspaceFile();
		//SaveWorkspace();

		SetSensitiveMenu(false);

		projectModel.Clear();
		WorkspaceTree.Clear();
		FrameworkTree.Clear();
		return true;
	}

	public void ReloadWorkspace(Workspace workspace, bool addRecent, bool settingPanel)
	{
		if (workspace != MainClass.Workspace)
			CloseActualWorkspace();

		MainClass.Workspace = workspace;
		List<string> projectPaths = new List<string>();

		this.Title = MainClass.Languages.Translate("moscrif_ide_title",workspace.Name,workspace.FilePath);

		foreach (string project in workspace.ProjectsFile)
			projectPaths.Add(MainClass.Workspace.GetFullPath(project));

		workspace.Projects.Clear();
		workspace.ProjectsFile.Clear();

		OpenFile("StartPage",false);
		foreach (string projectPath in projectPaths){
			OpenProject(projectPath, false);
		}

		TreeIter ti = new TreeIter();
		bool isFind = false;

		int countProject = 0;
		projectModel.Foreach((model, path, iterr) => {
			//string name = projectModel.GetValue(iterr, 0).ToString();
			string pathProject = projectModel.GetValue(iterr, 1).ToString();
			countProject++;
			if (pathProject == MainClass.Workspace.ActualProjectPath){
				ti = iterr;
				isFind = true;
				return true;
			}
				return false;
		});

		if (isFind)
			cbProject.SetActiveIter(ti);
		else{
			if (countProject >0)
				cbProject.Active = 0;
		}

		ReloadDevice(true);

		foreach (string file in workspace.OpenFiles)
			if (System.IO.File.Exists(file))
				EditorNotebook.Open(file);

		// -Menu for mobile platform
		//GenerateMenuPublish();
		if(settingPanel){
			ReloadPanel();

			Gtk.Action ac =  ActionUiManager.FindActionByName("clear");
			if (ac!=  null)
				(ac as ToggleAction).Active =MainClass.Settings.ClearConsoleBeforRuning;
	
			Gtk.Action acSL =  ActionUiManager.FindActionByName("showleftpane");
			if (acSL!=  null)
				(acSL as ToggleAction).Active =MainClass.Workspace.ShowLeftPane;
	
			Gtk.Action acSR =  ActionUiManager.FindActionByName("showrightpane");
			if (acSR!=  null)
				(acSR as ToggleAction).Active =MainClass.Workspace.ShowRightPane;
		}

		if (addRecent){
			MainClass.Settings.RecentFiles.AddWorkspace(workspace.FilePath, workspace.FilePath);
			//ActionUiManager.RefreshRecentWorkspace(MainClass.Settings.RecentFiles.GetWorkspace());
			ActionUiManager.RefreshRecentAll(MainClass.Settings.RecentFiles.GetFiles(),
			                          MainClass.Settings.RecentFiles.GetProjects(),
		                                 MainClass.Settings.RecentFiles.GetWorkspace());

		}

		FrameworkTree.LoadLibs(workspace.RootDirectory);
		BookmarkOutput.RefreshBookmark();

		FileExplorer.SetPath(workspace.FileExplorerPath);
	}

	public void SetBodyParameter(){
		int bottonPane =MainClass.Workspace.VpBodyHeight;
		int leftPane =MainClass.Workspace.HpBodyMiddleWidth;

		bottonPane =vpBody.Position;
		leftPane =hpBodyMidle.Position;

		MainClass.Workspace.HpBodyMiddleWidth =leftPane;
		MainClass.Workspace.VpBodyHeight =bottonPane;

	}

	public void ReloadPanel(){

		int x, y, w, h, d = 0;
		hpOutput.Parent.ParentWindow.GetGeometry(out x, out y, out w, out h, out d);

		int vpBodyHeight = MainClass.Workspace.VpBodyHeight;
		int hpBodyMiddleWidth = MainClass.Workspace.HpBodyMiddleWidth;

		int hpOutputWidth = MainClass.Workspace.HpOutputWidth;// output->find
		if (hpOutputWidth > 0)
				hpOutput.Position = hpOutputWidth;
		else {
			hpOutput.Position = w / 2;
		}

		if(MainClass.Workspace.ShowLeftPane){
			//if (hpBodyMiddleWidth != 0) // tree->editor
			//	hpBodyMidle.Position = hpBodyMiddleWidth;

			if ((hpBodyMiddleWidth != 0) &&(hpBodyMiddleWidth < w)){
				hpBodyMidle.Position = hpBodyMiddleWidth;
			}else {
				hpBodyMidle.Position = 200;
			}

		}else {
			hpBodyMidle.Position = 0;//100;
		}
		
		if(MainClass.Workspace.ShowBottomPane ){
			if ((vpBodyHeight != 0) &&(vpBodyHeight < h)){
				vpBody.Position = vpBodyHeight;
			}else {
				SetDefaultvpBody();
			}
		} else {
			vpBody.Parent.ParentWindow.GetGeometry(out x, out y, out w, out h, out d);
			vpBody.Position = h;
		}
	}

	public void SetActualProject(string appPath){

		string appFilename = System.IO.Path.GetFileNameWithoutExtension(appPath);

		projectModel.Foreach((model, path, iterr) => {
			string name = projectModel.GetValue(iterr, 0).ToString();
			string pathProject = projectModel.GetValue(iterr, 1).ToString();

			if (name == appFilename){
				cbProject.SetActiveIter(iterr);
				return true;
			}
				return false;
		});

	}


	public void SetSettingColor(){
		Gdk.Color col = new Gdk.Color(224, 41, 47);

		if (MainClass.Settings.BackgroundColor == null){
			MainClass.Settings.BackgroundColor = new Moscrif.IDE.Settings.Settings.BackgroundColors(218,218,218);
		}
		col = new Gdk.Color(MainClass.Settings.BackgroundColor.Red,MainClass.Settings.BackgroundColor.Green,MainClass.Settings.BackgroundColor.Blue);

		//Gdk.Color.Parse("red", ref col);
		this.ModifyBg(StateType.Normal, col);
		this.toolbarRight.ModifyBg(StateType.Normal, col);
		this.toolbarLeft.ModifyBg(StateType.Normal, col);
		this.toolbarMiddle.ModifyBg(StateType.Normal, col);
		this.vbMenuMidle.ModifyBg(StateType.Normal, col);

	}

	public void ReloadSettings(bool setSelectedDevices)
	{

		SetSettingColor();


		if(String.IsNullOrEmpty(MainClass.Settings.ConsoleTaskFont)){
			if( MainClass.Platform.IsMac){
				MainClass.Settings.ConsoleTaskFont= "Monaco 12";
			} else {
				MainClass.Settings.ConsoleTaskFont= "Monospace 10";
			}

		}
		if(setSelectedDevices){
			ErrorOutput.SetFont(MainClass.Settings.ConsoleTaskFont);
			ProcessOutput.SetFont(MainClass.Settings.ConsoleTaskFont);
			LogOutput.SetFont(MainClass.Settings.ConsoleTaskFont);
			TodoOutput.SetFont(MainClass.Settings.ConsoleTaskFont);
			FindOutput.SetFont(MainClass.Settings.ConsoleTaskFont);
			OutputConsole.SetFont(MainClass.Settings.ConsoleTaskFont);

			LogMonitor.SetFont(MainClass.Settings.ConsoleTaskFont);
			LogGarbageCollector.SetFont(MainClass.Settings.ConsoleTaskFont);
		}

		string path = string.Empty;

		ReloadDevice(setSelectedDevices);

		if(setSelectedDevices)
			EditorNotebook.RefreshSetting();

		if (!Directory.Exists(MainClass.Paths.TempPrecompileDir))
			try {
				Directory.CreateDirectory(MainClass.Paths.TempPrecompileDir);

			} catch {
				MainClass.Settings.PreCompile = false;
			}
		//Console.WriteLine(MainClass.Tools.TempPrecompileDir);

		string pathPreCompile = System.IO.Path.Combine(MainClass.Paths.TempPrecompileDir, "moscrif.exe");
		if( MainClass.Platform.IsMac){
			pathPreCompile = System.IO.Path.Combine(MainClass.Paths.TempPrecompileDir, "moscrif.app");
		
			if (!Directory.Exists(pathPreCompile)) {
	
				string emulator = System.IO.Path.Combine(MainClass.Settings.EmulatorDirectory, "moscrif.app");
				try {
					//System.IO.File.Copy(emulator, pathPreCompile);
					MainClass.Tools.CopyDirectory(emulator, pathPreCompile,false,false);

				} catch {
					MainClass.Settings.PreCompile = false;
				}
			}		
		} else {

			if (!File.Exists(pathPreCompile)) {
	
				string emulator = System.IO.Path.Combine(MainClass.Settings.EmulatorDirectory, "moscrif.exe");
				try {
					System.IO.File.Copy(emulator, pathPreCompile);
				} catch {
					MainClass.Settings.PreCompile = false;
				}
			}
		}

	}

	#region progres
	private double stepProgress = 0.0;
	private double actualValue = 0.0;

	public void ProgressStart(double stepvalue, string text)
	{

		Gtk.Application.Invoke(delegate {

			pbProgress.SizeRequest();
			pbProgress.HeightRequest = 1;

			//Console.WriteLine("stepvalue >>" + stepvalue);
			pbProgress.PulseStep = stepvalue;
			stepProgress = stepvalue;
			actualValue = 0.0;
			//Console.WriteLine("pbProgress.PulseStep >>" + pbProgress.PulseStep);
			pbProgress.Text = text;
			pbProgress.QueueDraw();
		});

	}

	public void ProgressEnd()
	{
		pbProgress.Fraction = 0.0;
		pbProgress.Text = "";
		stepProgress = 0.01;
		actualValue = 0.0;

		pbProgress.QueueDraw();
	}

	public void ProgressStepInvoke(){

		Gtk.Application.Invoke(delegate {
			 ProgressStep();
		});
	}


	public void ProgressStep()
	{
		//Console.WriteLine("pbProgress.Fraction>>" + pbProgress.Fraction);
		actualValue = actualValue + stepProgress;//pbProgress.PulseStep;
		//Console.WriteLine("actualValue >>" + actualValue);

		if (actualValue > 1.0)
			actualValue = 0;

		pbProgress.Fraction = actualValue;
		pbProgress.QueueDraw();

		//Console.WriteLine("pbProgress.Fraction>>" + pbProgress.Fraction);

		while (Application.EventsPending ())
			Application.RunIteration ();

	}


	#endregion

	#region Task

	private void ExecEditorThread()
    	{

	bool play = true;
	bool isBussy = false;
		try {
	   		while (play) {
				Thread.Sleep (2000);
				if ((MainClass.Workspace != null) && (MainClass.Workspace.ActualProject != null) && !isBussy) {
			    		isBussy = true;
						
			    		//lock (secondTaskList) {
			    		TaskList tl = new TaskList();
			    		tl.TasksList = new System.Collections.Generic.List<Moscrif.IDE.Task.ITask>();
						
			    		TodoTask tt = new TodoTask();
			    		//tt.Initialize(new PrecompileData(editor.Document.Text, fileName));
			    		tt.Initialize(MainClass.Workspace.ActualProject);
						
			    		tl.TasksList.Clear();
			    		tl.TasksList.Add(tt);

			    		RunSecondaryTaskList(tl, TODOTaskWritte,false);
			    		isBussy = false;
		    		}
			}
		}catch(ThreadAbortException tae){
			Thread.ResetAbort ();
			Logger.Error("ERROR - Cannot run editor thread.");
			Logger.Error(tae.Message);
		}finally{

		}
	}


	public void ClearOutput(){

		MainClass.MainWindow.ProcessOutput.Clear();
		MainClass.MainWindow.ErrorOutput.Clear();
		MainClass.MainWindow.LogOutput.Clear();
		MainClass.MainWindow.LogMonitor.Clear();
		MainClass.MainWindow.LogGarbageCollector.Clear();

		garbageColectorLabel.SetLabel(MainClass.Languages.Translate("garbage_collector",this.LogGarbageCollector.CountItem));

	}

	public void FindOutputWritte(object sender, string name, string status, List<TaskMessage> errors)
	{
		Gtk.Application.Invoke(delegate{
			this.FindOutput.WriteTask(sender, name, status, errors,false);
			TaskNotebook.CurrentPage = 4;
			ProgressEnd();
		});
	}

	public void TODOTaskWritte(object sender, string name, string status, List<TaskMessage> errors)
	{
		Gtk.Application.Invoke(delegate{
			this.TodoOutput.WriteTask(sender, name, status, errors,true);
		});
	}

	public void RunSecondaryTaskList(TaskList tasklist, ProcessTaskHandler processTaskHandler, bool clearError)
	{
		if(clearError){
			Gtk.Application.Invoke(delegate{

			this.ErrorOutput.Clear();
			});
		}

		MainClass.TaskServices.RunSecondaryTastList(tasklist, processTaskHandler, ErrorTaskWritte);
	}

	public void RunSecondaryTaskList(TaskList tasklist)
	{
		RunSecondaryTaskList(tasklist, EndTaskWritte,false);
	}

	public void RunTaskList(TaskList tasklist,bool enableLogCatch)
	{

		if (!enableLogCatch)
			MainClass.TaskServices.RunPrimaryTastListOnlineWrite(tasklist, EndTaskWritte, ErrorTaskWritte, null);
		else
			MainClass.TaskServices.RunPrimaryTastListOnlineWrite(tasklist, EndTaskWritte, ErrorTaskWritte, LogTaskWritte);
	}

	public void GoToFile(string file, object position)
	{
		if (String.IsNullOrEmpty(file))
			this.EditorNotebook.GoToCurrentFile(position);
		else
			this.EditorNotebook.GoToFile(file, position);
		hpBodyMidle.FocusChain = new Gtk.Widget [] { this.EditorNotebook };
	}

	public void EndTaskWritte(object sender, string name, string status, List<TaskMessage> errors)
	{
		this.ProcessOutput.WriteTask_II(sender, name, status, errors);
	}

	public void ErrorTaskWritte(object sender, string name, string status, TaskMessage error)
	{
		Gtk.Application.Invoke(delegate{

			this.ErrorOutput.WriteTask_II(sender, name, status, error);
			if (MainClass.Settings.ShowErrorPane)
				TaskNotebook.CurrentPage = 1;
		});
	}

	public void ErrorWritte(string name, string status, List<string> errors)
	{
		this.ErrorOutput.WriteTask(name,status,errors);
		if (MainClass.Settings.ShowErrorPane)
			TaskNotebook.CurrentPage = 1;
	}

	public void LogTaskWritte(object sender, string name, string status, TaskMessage error)
	{
		Gtk.Application.Invoke(delegate{
			this.LogOutput.WriteTask_II(sender, name, status, error);
		});
	}

	public void MonitorTaskWritte(object sender, string name, string status, TaskMessage error)
	{
		Gtk.Application.Invoke(delegate{
			this.LogMonitor.WriteTask_II(sender, name, status, error);
		});
	}

	public void GcTaskWritte(object sender, string name, string status, TaskMessage error)
	{
		Gtk.Application.Invoke(delegate{
			this.LogGarbageCollector.WriteTask_II(sender, name, status, error);
			garbageColectorLabel.SetLabel(MainClass.Languages.Translate("garbage_collector",this.LogGarbageCollector.CountItem+1));
		});
	}

	public void RunEmulator(string command, string arguments, string workDir, ProcessEventHandler pve)
	{

		this.ProcessOutput.Clear();
		//ProcessWrapper pw = MainClass.ProcessService.StartProcess(command, arguments, workDir, ProcessOutputChange, ProcessErrorChange);
		ProcessWrapper pw = new ProcessWrapper();

		if (pve != null){
			pw = MainClass.ProcessService.StartProcess(command, arguments, workDir, pve, pve);

		}
		else
			pw = MainClass.ProcessService.StartProcess(command, arguments, workDir, ProcessOutputChange, ProcessErrorChange);

		//VRATIT SPET
		//runningEmulator = true;
		runningEmulator = false;

		pw.Exited += delegate(object sender, EventArgs e) {
			Console.WriteLine("Emulator exit");
			runningEmulator = false;
			if (pve != null)
				pve(null, " ");
		};
	}

	public void RunProcessWait(string command, string arguments, string workDir,ProcessEventHandler pve,EventHandler exitHandler)
	{
		ProcessWrapper pw = MainClass.ProcessService.StartProcess(command, arguments, workDir, pve, pve);
		pw.Exited += exitHandler;
		pw.WaitForExit();

	}

	public void RunProcess(string command, string arguments, string workDir)
	{
		RunProcess(command,arguments,workDir,true,null);
	}

	public void RunProcess(string command, string arguments, string workDir,bool captureOutput,EventHandler exitHandler)
	{
		ProcessWrapper pw = new ProcessWrapper();
		if (captureOutput)
			pw =MainClass.ProcessService.StartProcess(command, arguments, workDir, ProcessOutputChange, ProcessErrorChange);
		else
			pw =MainClass.ProcessService.StartProcess(command, arguments, workDir, ProcessOutputNoChange, ProcessOutputNoChange);

		pw.Exited += exitHandler;
	}

	void HandlePwExited (object sender, EventArgs e)
	{

	}

	void ProcessOutputNoChange(object sender, string message)
	{
		Console.WriteLine(message);
	}
	void ProcessOutputChange(object sender, string message)
	{
		Console.WriteLine(message);
		this.OutputConsole.WriteText(message);
	}

	void ProcessErrorChange(object sender, string message)
	{	Console.WriteLine(message);
		this.OutputConsole.WriteError(message);
	}

	#endregion


	public void LoginLogout(){
		loginlogoutcontrol1.LoginLogout();
	}

	public void ReLogin(){
		loginlogoutcontrol1.LoginLogout();
	}

	public void SetLogin(){
		loginlogoutcontrol1.SetLogin();
	}

	#region Project
	private void ShowProject(Project project, bool addRecent)
	{
		WorkspaceTree.LoadProject(project);
		if(addRecent){

			MainClass.Settings.RecentFiles.AddProject(project.FilePath, project.FilePath);
		}
	}

	public void OpenProject(string filename, bool addRecent)
	{
		Project p = MainClass.Workspace.OpenProject(filename);

		AddAndShowProject(p,addRecent);
	}

	public void AddAndShowProject(Project p, bool addRecent){
		if (p != null) {
			projectModel.AppendValues(p.ProjectName, p.FilePath);
			ShowProject(p,addRecent);

			if (MainClass.Workspace.Projects.Count<2)
				cbProject.Active = 0;
		}
	}

	public void CreateProject(string filename, string projectName, string projectLocation, string projectDir, string aplicationFile,string skin, string theme)
	{
		Project p = null;
		try{
			p = MainClass.Workspace.CreateProject(filename, projectName, projectLocation, projectDir, aplicationFile,skin,theme);
		} catch(Exception ex){
			MessageDialogs md = new MessageDialogs(MessageDialogs.DialogButtonType.Ok, MainClass.Languages.Translate("invalid_zip"), ex.Message, Gtk.MessageType.Error);
			md.ShowDialog();
			return ;
		}
		if(p!=null)
			AddAndShowProject(p,true);

	}

	public void ConvertAppToProject(AppFile aplicationFile)
	{
		Project p = MainClass.Workspace.ConvertAppToProject(aplicationFile);
		AddAndShowProject(p,true);
	}

	public void ImportProject(string destinationFile, bool isZipFile)
	{
		if(String.IsNullOrEmpty(MainClass.Workspace.FilePath)){

			NewWorkspaceDialog nwd = new NewWorkspaceDialog(false);
			int result = nwd.Run();

			if (result == (int)ResponseType.Ok) {
				string workspaceName = nwd.WorkspaceName;
				string workspaceOutput = nwd.WorkspaceOutput;
				string workspaceRoot =nwd.WorkspaceRoot;
				bool copyLibs = nwd.CopyLibs;

				string workspaceFile = System.IO.Path.Combine(workspaceRoot, workspaceName + ".msw");
				MainClass.MainWindow.CreateWorkspace(workspaceFile,workspaceName,workspaceOutput,workspaceRoot,copyLibs);

			} else { 
				nwd.Destroy();
				return ;
			}
			nwd.Destroy();
		}

		if(String.IsNullOrEmpty(MainClass.Workspace.FilePath)) return ;

		string fileName = System.IO.Path.GetFileNameWithoutExtension(destinationFile);
		string destinationDir = System.IO.Path.GetDirectoryName(destinationFile); // aka workspace from
		string projectDir = System.IO.Path.Combine(destinationDir,fileName); // aka project dir from

		if(isZipFile){
			string tempDir =  System.IO.Path.Combine(MainClass.Paths.TempDir,fileName);
			MainClass.Tools.UnzipFile(destinationFile,tempDir);
			destinationDir =tempDir;

			string[] fis1 = System.IO.Directory.GetFiles(destinationDir,"*.app",SearchOption.TopDirectoryOnly);
			if ((fis1 == null) || (fis1.Length<1)){
				MessageDialogs md = new MessageDialogs(MessageDialogs.DialogButtonType.Ok, MainClass.Languages.Translate("invalid_zip"), "", Gtk.MessageType.Error);
				md.ShowDialog();
				return ;
			}


			fileName = System.IO.Path.GetFileNameWithoutExtension(fis1[0]);
			//destinationDir = System.IO.Path.GetDirectoryName(destinationFile);

			projectDir = System.IO.Path.Combine(destinationDir,fileName);
		}
		//MainClass.Tools.UnzipFile(zipFile,tempDir);

		string[] fis = System.IO.Directory.GetFiles(destinationDir,fileName+".app",SearchOption.TopDirectoryOnly);
		string[] fisMsp = System.IO.Directory.GetFiles(destinationDir,fileName+".msp",SearchOption.TopDirectoryOnly);

		if ((fis == null) || (fis.Length<1)){
			MessageDialogs md = new MessageDialogs(MessageDialogs.DialogButtonType.Ok, MainClass.Languages.Translate("invalid_zip"), "", Gtk.MessageType.Error);
			md.ShowDialog();
			return;
		}

		if(!System.IO.Directory.Exists(projectDir)){
			MessageDialogs md = new MessageDialogs(MessageDialogs.DialogButtonType.Ok, MainClass.Languages.Translate("invalid_project"), "", Gtk.MessageType.Error);
			md.ShowDialog();
			//fc.Destroy();
			return ;
		}

		string fileExistApp = System.IO.Path.GetFileNameWithoutExtension(fis[0]);

		string[] fiExist = Directory.GetFiles(MainClass.Workspace.RootDirectory,"*.app",SearchOption.TopDirectoryOnly);

		if((fiExist != null) || (fiExist.Length>0)){
			List<string> existApp = new List<string>(fiExist);
			//foreach(string fileApp in fis){
			//	string fileExistApp = System.IO.Path.GetFileNameWithoutExtension(fileApp);
			int findIndex = existApp.FindIndex(x=> System.IO.Path.GetFileNameWithoutExtension(x) == fileExistApp);
			if(findIndex>-1){
				MessageDialogs md = new MessageDialogs(MessageDialogs.DialogButtonType.Ok,  MainClass.Languages.Translate("project_exist"), "", Gtk.MessageType.Error);
				md.ShowDialog();
			//fc.Destroy();
				return ;
			}
					//}
		}

		string newApp = System.IO.Path.GetFileName(fis[0]);
		newApp = System.IO.Path.Combine(MainClass.Workspace.RootDirectory,newApp);

		if(isZipFile){
			// zkopirujem vsetko co bolo v zipe
			MainClass.Tools.CopyDirectory(destinationDir,MainClass.Workspace.RootDirectory,false,true);
		} else {
			// zkopirujem len veci k projektu app,msp a dir
			System.IO.File.Copy(fis[0],newApp);

			if( (fis != null) && (fisMsp.Length >0) && ( !string.IsNullOrEmpty(fisMsp[0]) )){
				string newMsp = System.IO.Path.GetFileName(fisMsp[0]);
				newMsp = System.IO.Path.Combine(MainClass.Workspace.RootDirectory,newMsp);
				System.IO.File.Copy(fisMsp[0],newMsp);
			}
			string newPrjDir = System.IO.Path.Combine(MainClass.Workspace.RootDirectory,fileName);

			MainClass.Tools.CopyDirectory(projectDir,newPrjDir,true,true);

		}

		if (!System.IO.File.Exists(newApp) ){
			MessageDialogs md = new MessageDialogs(MessageDialogs.DialogButtonType.Ok, MainClass.Languages.Translate("import_failed"), "", Gtk.MessageType.Error);
			md.ShowDialog();
			//fc.Destroy();
			return;
		}

		AppFile appFile= new AppFile(newApp);

		if( (fisMsp.Length <1) || ( string.IsNullOrEmpty(fisMsp[0]) )){
			ConvertAppToProject(appFile);

		} else {
			string newMsp = System.IO.Path.GetFileName(fisMsp[0]);
			newMsp = System.IO.Path.Combine(MainClass.Workspace.RootDirectory,newMsp);
			OpenProject(newMsp,true);
		}
		LoggingInfo log = new LoggingInfo();
		log.LoggWebThread(LoggingInfo.ActionId.IDEImportProject,appFile.Name);

		SetActualProject(newApp);
		WorkspaceTree.SetSelectedFile(newApp);
	}

	public void PropertisALL()
	{
		string filename = "";

		int typ = -1;
		Gtk.TreeIter ti = new Gtk.TreeIter();
		WorkspaceTree.GetSelectedFile(out filename, out typ, out ti);

		if (String.IsNullOrEmpty(filename))
			return;

		if (typ == (int)Moscrif.IDE.Workspace.TypeFile.AppFile){
			PropertisProject();
		} else if (typ == (int)Moscrif.IDE.Workspace.TypeFile.Directory){
			PropertisDirectory();
		} else {
			PropertisFile();
		}

	}

	public void OpenOutput(bool projectFromTree)
	{

		Project p;
		if(projectFromTree){
			string appname = "";
			int typ = -1;
			Gtk.TreeIter ti = new Gtk.TreeIter();
			WorkspaceTree.GetSelectedFile(out appname, out typ, out ti);

			if (String.IsNullOrEmpty(appname))
				return;

			p = MainClass.Workspace.FindProject_byApp(appname, true);
			if (p == null)
				return;
		} else {
			p = MainClass.Workspace.ActualProject;
		}

		if (!String.IsNullOrEmpty(p.ProjectOutput)){
			try{
				string fullOutput =p.OutputMaskToFullPath;

				if(!Directory.Exists(fullOutput)){
					Directory.CreateDirectory(fullOutput);
				}
				System.Diagnostics.Process.Start(fullOutput);
			}catch{
			}
		}
	}

	public void ShowProjectInExplorer(bool projectFromTree)
	{

		Project p;
		if(projectFromTree){
			string appname = "";
			int typ = -1;
			Gtk.TreeIter ti = new Gtk.TreeIter();
			WorkspaceTree.GetSelectedFile(out appname, out typ, out ti);

			if (String.IsNullOrEmpty(appname))
				return;

			p = MainClass.Workspace.FindProject_byApp(appname, true);
			if (p == null)
				return;
		} else {
			p = MainClass.Workspace.ActualProject;
		}

		if (!String.IsNullOrEmpty(p.ProjectOutput)){
			try{
				string fullOutput =p.AbsolutProjectDir;

				if(!Directory.Exists(fullOutput)){
					Directory.CreateDirectory(fullOutput);
				}
				System.Diagnostics.Process.Start(fullOutput);
			}catch{
			}
		}
	}

	public void PropertisProject()
	{
		string appname = "";
		int typ = -1;
		Gtk.TreeIter ti = new Gtk.TreeIter();
		WorkspaceTree.GetSelectedFile(out appname, out typ, out ti);

		if (String.IsNullOrEmpty(appname))
			return;
		Project p = MainClass.Workspace.FindProject_byApp(appname, true);

		if (p == null){	return;}

		PreferencesDialog pd = new PreferencesDialog(TypPreferences.ProjectSetting,p,p.ProjectName);
		int result = pd.Run();
		if (result == (int)ResponseType.Ok)
			MainClass.Workspace.SaveProject(p);

		pd.Destroy();
	}


	public Project UnloadProject(){
		string appname = "";
		int typ = -1;
		Gtk.TreeIter ti = new Gtk.TreeIter();
		WorkspaceTree.GetSelectedFile(out appname, out typ, out ti);

		if (String.IsNullOrEmpty(appname))
			return null;

		Project p = MainClass.Workspace.CloseProject(appname);

		TreeIter iter = new TreeIter();

		projectModel.Foreach((model, path, iterr) => {
					string name = projectModel.GetValue(iterr, 0).ToString();
				string pathProject = projectModel.GetValue(iterr, 1).ToString();

				if ((name == p.ProjectName) && (pathProject == p.FilePath)){
						iter = iterr;
						return true;
				}
					return false;
			});

		projectModel.Remove(ref iter);
		SetSensitiveMenu(false);

		if(MainClass.Workspace.ActualProject == p){
			MainClass.Workspace.ActualProject = null;
			cbProject.Active =0;
		}

		if (p != null)
			WorkspaceTree.RemoveTree(ti);
		return p;
	}

     public Project RenameProject()
    {
	string appname = "";
	int typ = -1;
	Gtk.TreeIter ti = new Gtk.TreeIter();

	WorkspaceTree.GetSelectedFile(out appname, out typ, out ti);

	//string appfile = WorkspaceTree.GetSelectedProjectApp();
	Project prj = MainClass.Workspace.FindProject_byApp(appname, true);

	if (prj == null)
	    return null;

	EntryDialog ed = new EntryDialog(
	    prj.ProjectName,
	    MainClass.Languages.Translate("new_name")
	);

	int result = ed.Run();

	if (result != (int)ResponseType.Ok) {
	    ed.Destroy();
	    return null;
	}

	if (String.IsNullOrEmpty(ed.TextEntry)) {
	    	ed.Destroy();
		return null;
	}
	string newName = MainClass.Tools.RemoveDiacritics(ed.TextEntry);
	ed.Destroy();

	string oldPrjName =prj.ProjectName;

	if (newName == prj.ProjectName){
		return null;
	}

	try{
		List<string> listFile = new List<string>();
		FileUtility.GetAllFiles(ref listFile, prj.AbsolutProjectDir);

		foreach (string file in listFile)
			EditorNotebook.ClosePage(file, true);

		if(!MainClass.Workspace.RenameProject(prj,newName))
			return null;

		projectModel.Foreach((model, path, iterr) => {
			string name = projectModel.GetValue(iterr, 0).ToString();
			//string pathProject = projectModel.GetValue(iterr, 1).ToString();

			if ((name == oldPrjName)){ //&& (pathProject == prj.FilePath)){
				projectModel.SetValue(iterr,0,prj.ProjectName);
				projectModel.SetValue(iterr,1,prj.FilePath);
					//iter = iterr;
				return true;
			}
				return false;
		});


	}catch(Exception ex){
		Logger.Error(ex.Message);
		MessageDialogs md =
		new MessageDialogs(MessageDialogs.DialogButtonType.Ok, MainClass.Languages.Translate("cannot_rename_project",prj.ProjectName),ex.Message, Gtk.MessageType.Error);
		md.ShowDialog();

	}
	WorkspaceTree.RefreshProject(prj, ti);
	return prj;
	}

	public void DeleteProject()
	{
		Project p =  UnloadProject();
		if(p== null)
			return;

		try {
			System.IO.Directory.Delete(p.AbsolutProjectDir,true);
			System.IO.File.Delete(p.FilePath);
			System.IO.File.Delete(p.AbsolutAppFilePath);

		} catch (Exception ex){
			Logger.Error(ex.Message);
		}

	}

	public void RefreshProject()
	{
		string path = "";
		int typ = -1;
		Gtk.TreeIter ti = new Gtk.TreeIter();

		WorkspaceTree.GetSelectedFile(out path, out typ, out ti);

		if (String.IsNullOrEmpty(path)) return;

		if ((typ == (int)TypeFile.AppFile)) {
			Project prj = MainClass.Workspace.FindProject_byApp(path, true);
			if (prj != null)
				WorkspaceTree.RefreshProject(prj, ti);

		} else if ((typ == (int)TypeFile.Directory)) {
			string appfile = WorkspaceTree.GetSelectedProjectApp();
			Project prj = MainClass.Workspace.FindProject_byApp(appfile, true);
			if (prj != null)
				WorkspaceTree.RefreshDir(path, prj, ti);
		}
	}

	#endregion

	#region File


	public void PropertisFile()
	{
		string file = "";
		string appfile = "";
		int typ = -1;
		Gtk.TreeIter ti = new Gtk.TreeIter();
		WorkspaceTree.GetSelectedFile(out file, out typ, out ti);

		if (String.IsNullOrEmpty(file))
			return;

		appfile = WorkspaceTree.GetSelectedProjectApp();

		Project p = MainClass.Workspace.FindProject_byApp(appfile, true);
		if (p == null)
			return;

		FilePropertisData fpd = new FilePropertisData();
		fpd.Filename = MainClass.Workspace.GetRelativePath(file);
		fpd.Project = p;

		PreferencesDialog pd = new PreferencesDialog(TypPreferences.FileSetting,fpd,fpd.Filename);
		int result = pd.Run();
		if (result == (int)ResponseType.Ok) {
			MainClass.Workspace.SaveProject(p);

			FileItem fi = p.FilesProperty.Find(x => x.SystemFilePath == fpd.Filename);

			if (fi != null) {
				TypeFile newTyp = TypeFile.SourceFile;

				if (fi.IsExcluded)
					newTyp = TypeFile.ExcludetFile;
				else
					newTyp = TypeFile.SourceFile;

				MainClass.MainWindow.WorkspaceTree.UpdateIter(ti, String.Empty, String.Empty, (int)newTyp);
			}

		}
		pd.Destroy();
	}

	public void PropertisDirectory()
	{
		string file = "";
		string appfile = "";
		int typ = -1;
		Gtk.TreeIter ti = new Gtk.TreeIter();
		WorkspaceTree.GetSelectedFile(out file, out typ, out ti);

		if (String.IsNullOrEmpty(file)) return;

		appfile = WorkspaceTree.GetSelectedProjectApp();

		Project p = MainClass.Workspace.FindProject_byApp(appfile, true);
		if (p == null)
			return;

		FilePropertisData fpd = new FilePropertisData();
		fpd.Filename = MainClass.Workspace.GetRelativePath(file);
		fpd.Project = p;

		PreferencesDialog pd = new PreferencesDialog(TypPreferences.DirectorySetting,fpd,fpd.Filename);
		int result = pd.Run();
		if (result == (int)ResponseType.Ok)
			MainClass.Workspace.SaveProject(p);

		pd.Destroy();
	}

	public void ShowDirectory()
	{
		string path = "";
		int typ = -1;
		Gtk.TreeIter ti = new Gtk.TreeIter();

		WorkspaceTree.GetSelectedFile(out path, out typ, out ti);

		if (String.IsNullOrEmpty(path)) return;

		if ((typ == (int)TypeFile.Directory)) {
			if(!Directory.Exists(path)){
				Directory.CreateDirectory(path);
			}
			System.Diagnostics.Process.Start(path);
		}
	}

	public void SetSearch()
	{
		OutputNotebook.CurrentPage = 1;
		object o = EditorNotebook.GetSelectedObject();

		if (o != null){
			FindReplaceControl.SetFindText((string)o);
		}
		FindReplaceControl.SetFocus();
	}

	public void SetFileAsStartup()
	{
		string filename = "";
		int typ = -1;
		Gtk.TreeIter ti = new Gtk.TreeIter();

		WorkspaceTree.GetSelectedFile(out filename, out typ, out ti);

		if (String.IsNullOrEmpty(filename)) return;

		string appFilePath = WorkspaceTree.GetSelectedProjectApp();

		MainClass.Workspace.SetAsStartup(filename, appFilePath);
		WorkspaceTree.UpdateIter(ti, String.Empty, String.Empty, (int)TypeFile.StartFile);
	}

	public void OpenFile(string filename, bool addToRecent)
	{
		EditorNotebook.Open(filename);

		if(addToRecent){
			MainClass.Settings.RecentFiles.AddFile(filename, filename);

			//ActionUiManager.RefreshRecentFiles(MainClass.Settings.RecentFiles.GetFiles());
			ActionUiManager.RefreshRecentAll(MainClass.Settings.RecentFiles.GetFiles(),
			                          MainClass.Settings.RecentFiles.GetProjects(),
			                                 MainClass.Settings.RecentFiles.GetWorkspace());
		}
	}

	public void OpenSelectFile()
	{
		string filename = "";
		int typ = -1;
		Gtk.TreeIter ti = new Gtk.TreeIter();
		WorkspaceTree.GetSelectedFile(out filename, out typ, out ti);

		if (String.IsNullOrEmpty(filename)) return;

		if (typ != (int)TypeFile.Directory){
			EditorNotebook.Open(filename);
		}

	}

	public void CreateFile(string filename,string content)
	{
		string dir = "";
		int typ = -1;
		Gtk.TreeIter ti = new Gtk.TreeIter();

		WorkspaceTree.GetSelectedFileDirectory(out dir, out typ, out ti);

		if (String.IsNullOrEmpty(dir)) return;

		string newFile = "";
		newFile = MainClass.Workspace.CreateFile(filename, dir, typ, content);

		if (!String.IsNullOrEmpty(newFile)) {
			MainClass.Settings.RecentFiles.AddFile(newFile, newFile);

			//ActionUiManager.RefreshRecentFiles(MainClass.Settings.RecentFiles.GetFiles());
			ActionUiManager.RefreshRecentAll(MainClass.Settings.RecentFiles.GetFiles(),
			                          MainClass.Settings.RecentFiles.GetProjects(),
		                                 MainClass.Settings.RecentFiles.GetWorkspace());
			WorkspaceTree.AddFileToTree(newFile, ti);
			OpenFile(newFile,true);
		}
	}

	public void RenameFile()
	{
		MessageDialogs md;
		string filename = "";
		int typ = -1;
		Gtk.TreeIter ti = new Gtk.TreeIter();

		WorkspaceTree.GetSelectedFile(out filename, out typ, out ti);

		if (typ == (int)TypeFile.Directory){

			if ((String.IsNullOrEmpty(filename)) || !Directory.Exists(filename)){
				md = 
				new MessageDialogs(MessageDialogs.DialogButtonType.Ok, MainClass.Languages.Translate("file_not_exist_f1",filename),"", Gtk.MessageType.Error);
				md.ShowDialog();
				return;
			}

		} else {
			if ((String.IsNullOrEmpty(filename)) || !File.Exists(filename)){
				md = 
				new MessageDialogs(MessageDialogs.DialogButtonType.Ok, MainClass.Languages.Translate("file_not_exist_f1",filename),"", Gtk.MessageType.Error);
				md.ShowDialog();
				return;
			}
		} 
		bool isDir = (typ == (int)TypeFile.Directory)? true:false;
		string oldName = System.IO.Path.GetFileName(filename);
		EntryDialog ed = new EntryDialog(oldName,MainClass.Languages.Translate("new_name"));

		int result = ed.Run();

		if (result == (int)ResponseType.Ok) { // Rename Directory
			string newName = ed.TextEntry;
			string newPath ="";
			string msg = FileUtility.RenameItem(filename,isDir, newName,out newPath );

			if(!String.IsNullOrEmpty(msg)){
				string message = MainClass.Languages.Translate("cannot_rename_file",filename);
				if(isDir)
					message = MainClass.Languages.Translate("cannot_rename_directory",filename);

				MessageDialogs mdd = 
					new MessageDialogs(MessageDialogs.DialogButtonType.Ok, message,msg, Gtk.MessageType.Error);
				mdd.ShowDialog();

				return;
			}
			if(!String.IsNullOrEmpty(newPath)){
				WorkspaceTree.UpdateIter(ti, newName, newPath, typ);
			}
		}
		ed.Destroy();
	}


	public void CreateDirectory(string Filename)
	{
		string dir = "";
		int typ = -1;
		Gtk.TreeIter ti = new Gtk.TreeIter();

		WorkspaceTree.GetSelectedFileDirectory(out dir, out typ, out ti);

		if (String.IsNullOrEmpty(dir)) return;

		string newFile = MainClass.Workspace.CreateDirectory(Filename, dir, typ);
		WorkspaceTree.AddDirectoryToTree(newFile, ti);
	}

	public void AddFile(string Filename)
	{
		string dir = "";
		int typ = -1;
		Gtk.TreeIter ti = new Gtk.TreeIter();

		WorkspaceTree.GetSelectedFileDirectory(out dir, out typ, out ti);

		if (String.IsNullOrEmpty(dir)) return;

		string newFile = MainClass.Workspace.AddFile(Filename, dir, typ);

		WorkspaceTree.AddFileToTree(newFile, ti);
		MainClass.Settings.RecentFiles.AddFile(newFile, newFile);

		//ActionUiManager.RefreshRecentFiles(MainClass.Settings.RecentFiles.GetFiles());
		ActionUiManager.RefreshRecentAll(MainClass.Settings.RecentFiles.GetFiles(),
			                          MainClass.Settings.RecentFiles.GetProjects(),
		                                 MainClass.Settings.RecentFiles.GetWorkspace());
	}

	public void AddDirectory(string Filename)
	{
		string dir = "";
		int typ = -1;
		Gtk.TreeIter ti = new Gtk.TreeIter();

		WorkspaceTree.GetSelectedFileDirectory(out dir, out typ, out ti);

		if (String.IsNullOrEmpty(dir)) return;

		string newFile = MainClass.Workspace.AddDirectory(Filename, dir, typ);

		if(!String.IsNullOrEmpty(newFile))
			WorkspaceTree.AddDirectoryToTree(newFile, ti);
	}

	public void AddTheme()
	{
		string dir = "";
		int typ = -1;
		Gtk.TreeIter ti = new Gtk.TreeIter();

		WorkspaceTree.GetSelectedFileDirectory(out dir, out typ, out ti);

		if (String.IsNullOrEmpty(dir)) return;

		string newFile = MainClass.Workspace.AddTheme( dir, typ);

		if(!String.IsNullOrEmpty(newFile))
			WorkspaceTree.AddThemeDirectoryToTree(newFile, ti);
	}

	public void ToggleExcludeFile()
	{
		string filename = "";
		int typ = -1;
		Gtk.TreeIter ti = new Gtk.TreeIter();

		MainClass.MainWindow.WorkspaceTree.GetSelectedFile(out filename, out typ, out ti);

		if (String.IsNullOrEmpty(filename)) return;

		string appFile = MainClass.MainWindow.WorkspaceTree.GetSelectedProjectApp();

		TypeFile? newTyp = MainClass.Workspace.ToggleExcludeFile(filename, appFile);

		if (newTyp != null)
			MainClass.MainWindow.WorkspaceTree.UpdateIter(ti, String.Empty, String.Empty, (int)newTyp.Value);
	}

	public void DeleteFile()
	{
		MessageDialogs md;

		string filename = "";
		int typ = -1;
		Gtk.TreeIter ti = new Gtk.TreeIter();
		WorkspaceTree.GetSelectedFile(out filename, out typ, out ti);

		if (String.IsNullOrEmpty(filename)) return;

		if (typ == (int)TypeFile.AppFile) {
			md = new 	MessageDialogs(MessageDialogs.DialogButtonType.Ok, MainClass.Languages.Translate("start_file_delete_error"),"", Gtk.MessageType.Error);
			md.ShowDialog();
			return;
		}

		if (typ == (int)TypeFile.StartFile) {
			md = new 	MessageDialogs(MessageDialogs.DialogButtonType.Ok, MainClass.Languages.Translate("start_file_delete_error"),"", Gtk.MessageType.Error);
			md.ShowDialog();
			return;
		}
		bool isDir = (typ == (int)TypeFile.Directory)? true:false;
		string message ="" ;
		if (isDir) {
			message = MainClass.Languages.Translate("question_delete_folder",filename);
		} else {
			message = MainClass.Languages.Translate("question_delete_file",filename);
		}

		md = new MessageDialogs(MessageDialogs.DialogButtonType.YesNo, message, "", Gtk.MessageType.Question);

		int result = md.ShowDialog();

		if (result != (int)Gtk.ResponseType.Yes)
				return;


		string msg = FileUtility.DeleteItem(filename,isDir);

		if(!String.IsNullOrEmpty(msg)){
			message = MainClass.Languages.Translate("cannot_delete_file",filename);
			MessageDialogs mdd = 
				new MessageDialogs(MessageDialogs.DialogButtonType.Ok, message,msg, Gtk.MessageType.Error);
			mdd.ShowDialog();
			return;
		}

		WorkspaceTree.RemoveTree(ti);
	}

	#endregion

	#region Menu -> Statusbar

	// pridanie menu a toolbarov do prislusnich widgetov
	private void OnWidgetAdd(object obj, AddWidgetArgs args)
	{
		if (args.Widget is Toolbar) {
			args.Widget.Show();
			if (args.Widget.Name == "toolbarLeft") {
				toolbarLeft = (Toolbar)args.Widget;

				toolbarLeft.ShowAll();
				toolbarLeft.IconSize = IconSize.LargeToolbar;

				vpMenuLeft.Pack1(toolbarLeft, false, false);

			}
			if (args.Widget.Name == "toolbarMiddle") {
				toolbarMiddle = (Toolbar)args.Widget;

				vbMenuMidle.PackEnd(toolbarMiddle,true, true, 0);//true, false,

				ToolItem tic = new ToolItem();
				ToolItem tic2 = new ToolItem();
				ToolItem tic3 = new ToolItem();
				ToolItem til1 = new ToolItem();
				ToolItem til2 = new ToolItem();
				ToolItem til3 = new ToolItem();

				Label lbl1 = new Label(MainClass.Languages.Translate("project"));
				Label lbl2 = new Label(MainClass.Languages.Translate("resolution"));
				Label lbl3 = new Label(MainClass.Languages.Translate("device"));

				til1.Add(lbl1);
				til2.Add(lbl2);
				til3.Add(lbl3);
				if(MainClass.Platform.IsMac){

					VBox vboxMenu1 = new VBox();
					vboxMenu1.PackStart(new Label(),true,false,0);
					vboxMenu1.PackStart(cbProject,false,false,0);
					vboxMenu1.PackEnd(new Label(),true,false,0);

					VBox vboxMenu2 = new VBox();
					vboxMenu2.PackStart(new Label(),true,false,0);
					vboxMenu2.PackStart(cbResolution,false,false,0);
					vboxMenu2.PackEnd(new Label(),true,false,0);

					VBox vboxMenu3 = new VBox();
					vboxMenu3.PackStart(new Label(),true,false,0);
					vboxMenu3.PackStart(cbDevice,false,false,0);
					vboxMenu3.PackEnd(new Label(),true,false,0);

					tic.Add(vboxMenu1);
					tic2.Add(vboxMenu2);
					tic3.Add(vboxMenu3);

				} else {
					tic.Add(cbProject);
					tic2.Add(cbResolution);
					tic3.Add(cbDevice);

				}


				toolbarMiddle.Insert(tic2, 0);
				toolbarMiddle.Insert(til2, 0);
				toolbarMiddle.Insert(new SeparatorToolItem(), 0);
				toolbarMiddle.Insert(tic3, 0);
				toolbarMiddle.Insert(til3, 0);
				toolbarMiddle.Insert(new SeparatorToolItem(), 0);
				toolbarMiddle.Insert(tic, 0);
				toolbarMiddle.Insert(til1, 0);

				toolbarMiddle.ShowAll();
			}
			if (args.Widget.Name == "toolbarRight") {
				toolbarRight = (Toolbar)args.Widget;
				vpMenuRight.Pack1(toolbarRight, true, true);
				toolbarRight.IconSize = IconSize.LargeToolbar;
			}
		}
		if (args.Widget is MenuBar) {
			mainMenu =(MenuBar)args.Widget;
			mainMenu.Show();
			if(!MainClass.Platform.IsMac)
				vbMenuMidle.PackStart(mainMenu, true, true, 0);
		}
	}


	public void PushText(string message){

		lblMessage1.Text = message;
	}
	// Jazda nad menu zobrazi v status bare text tooltip menu
	private void OnSelect(object obj, EventArgs args)
	{
		if (obj.GetType() == typeof(ImageMenuItem)) {

			ImageMenuItem imi = (ImageMenuItem)obj;
			if (!String.IsNullOrEmpty(imi.Action.Tooltip))
				statusbar1.Push(1, imi.Action.Tooltip);
		}
	}

	private void OnDeselect(object obj, EventArgs args)
	{
		statusbar1.Pop(0);
	}

	private void OnProxyConnect(object obj, ConnectProxyArgs args)
	{
		if (args.Proxy is MenuItem) {
			((Item)args.Proxy).Selected += new EventHandler(OnSelect);
			((Item)args.Proxy).Deselected += new EventHandler(OnDeselect);
		}
	}

	#endregion

	private void ReloadDevice(bool setSelectedDevices){

		deviceModel.Clear();
		foreach (Rule rl in MainClass.Settings.Platform.Rules) {
			if( (rl.Tag == -1 ) && !MainClass.Settings.ShowUnsupportedDevices) continue;
			if( (rl.Tag == -2 ) && !MainClass.Settings.ShowDebugDevices) continue;

			string dirPublish = MainClass.Tools.GetPublishDirectory(rl.Specific);
			if (System.IO.Directory.Exists(dirPublish)){
				TreeIter tiD = deviceModel.AppendValues(rl.Name, rl.Id);

				if(setSelectedDevices){
					if (rl.Id==  MainClass.Workspace.ActualDevice) {
						cbDevice.SetActiveIter(tiD);
					}
				}
			}else {
				Logger.Debug("{0} devices missing publish tool.",rl.Name);
			}
		}
		if (cbDevice.Active<0)
			cbDevice.Active = 0;
	}

	private void SetSensitiveMenu(bool sensitivy)
	{
		ActionUiManager.SetDefaultMenu(sensitivy);
		WorkspaceTree.SetCreateSensitive(sensitivy);

	}

	private void FullResolution(int device, bool allResolution){

		bool isFind = false;
		bool hardAll  = false;
		resolutionModel.Clear();
		string path="";
		if(MainClass.Workspace!= null)
			path = MainClass.Workspace.ActualResolution;

		string[] listFi = Directory.GetFiles(MainClass.Paths.DisplayDir, "*.ini");
		int prefferedIndex = 0;
		string vvgaPath = System.IO.Path.Combine(MainClass.Paths.DisplayDir,"noskin_vga.ini");
		int indx =0;
		TreeIter tiSelect = new TreeIter();

		PlatformResolution pr = MainClass.Settings.PlatformResolutions.Find(x=>x.IdPlatform == device);
		if(pr == null){
			hardAll = true; // nema definiciu , zobrazuju sa vsetky
		}

		foreach (string fi in listFi) {
			EmulatorDisplay dd = new EmulatorDisplay(fi);
			if (dd.Load()) {

				if((!allResolution) && (!hardAll)){
					Rule rlr = MainClass.Settings.Resolution.Rules.Find(x=>x.Height==dd.Height && x.Width== dd.Width);
					if((rlr!= null) && device >-1){
						if(!pr.IsValidResolution(rlr.Id)){
							continue;
						}
					}
				}

				TreeIter ti = resolutionModel.AppendValues(dd.Title, dd.FilePath);
				if (dd.FilePath == vvgaPath)
					prefferedIndex =indx;

				if (dd.FilePath == path) {
					isFind = true;
					tiSelect = ti;
				}
				indx++;
			}
		}
		if (isFind)
			cbResolution.SetActiveIter(tiSelect);
		else{
			if(System.IO.File.Exists(vvgaPath))
				cbResolution.Active = prefferedIndex;
			else cbResolution.Active =0;
		}

		if(!hardAll){
			if(!allResolution){
				resolutionModel.AppendValues(MainClass.Languages.Translate("show_denied" ) , "-1");
			} else {
				resolutionModel.AppendValues(MainClass.Languages.Translate("hide_denied" ) , "-2");
			}
		}

	}

	void OnComboResolutionChanged(object o, EventArgs args)
	{
		ComboBox combo = o as ComboBox;
		if (o == null)
			return;

		TreeIter iter;
		if (combo.GetActiveIter(out iter)) {
			string prj = (string)combo.Model.GetValue(iter, 1);

			if(prj == "-1"){
				FullResolution(MainClass.Workspace.ActualDevice, true);
			}else if (prj == "-2"){
				FullResolution(MainClass.Workspace.ActualDevice, false);
			} else {
				MainClass.Workspace.ActualResolution = prj;
			}
		}
	}

	void OnComboDeviceChanged(object o, EventArgs args)
	{
		ComboBox combo = o as ComboBox;
		if (o == null)
			return;

		TreeIter iter;
		int device = -1;
		if (combo.GetActiveIter(out iter)) {
			device = (int)combo.Model.GetValue(iter, 1);

			MainClass.Workspace.ActualDevice = device;
		}
		FullResolution(device,false);
	}

	void OnComboProjectChanged(object o, EventArgs args)
	{
		ComboBox combo = o as ComboBox;
		if (o == null)
			return;

		TreeIter iter;
		if (combo.GetActiveIter(out iter)) {
			string prj = (string)combo.Model.GetValue(iter, 1);

			MainClass.Workspace.SetActualProject(prj);

			if(MainClass.Workspace.ActualProjectPath.Contains(" ")){

				string error =MainClass.Languages.Translate("error_whitespace");
				OutputConsole.WriteError( error );
				List<string> lst = new List<string>();
				lst.Add(error);
				LogOutput.WriteTask("","",lst);
				TaskNotebook.CurrentPage = 2;
			}
		}
	}


	public bool InicializeQuit(){

		LoggingInfo log = new LoggingInfo();
		log.LoggWebThread(LoggingInfo.ActionId.IDEEnd);

		if( !CloseActualWorkspace()){
			return false;
		}
		MainClass.Settings.SaveSettings();

		if (this.EditorNotebook.NPages > 0)
			return true;

		MainClass.TaskServices.Stop();

		if(Directory.Exists(MainClass.Paths.TempDir)){
			try{
				Directory.Delete(MainClass.Paths.TempDir,true);
			} catch{
				Logger.Error("CANNOT DELETE TEMP DIR.");
			}
		}

		Moscrif.IDE.Tool.Logger.LogDebugInfo(String.Format("application.exi-{0}",DateTime.Now));
		Console.WriteLine(String.Format("application.exit-{0}",DateTime.Now));

		return true;
	}

	public void QuitApplication()
	{
		Application.Quit();
	}

	protected void OnDeleteEvent(object sender, DeleteEventArgs a)
	{
		InicializeQuit();

		Application.Quit();
		a.RetVal = true;
	}

	protected void OnBtnSocketServerClicked (object sender, EventArgs e)
	{	if(String.IsNullOrEmpty(cbIpAdress.ActiveText)) return;

		if(Moscrif.IDE.Iface.SocketServer.Running){
			Moscrif.IDE.Iface.SocketServer.CloseSockets();
			cbIpAdress.Sensitive = true;
			btnSocketServer.Image = new Gtk.Image(pixbufRed);
		} else {
			string ip = Moscrif.IDE.Iface.SocketServer.StartListen(cbIpAdress.ActiveText, MainClass.Settings.SocetServerPort);
			cbIpAdress.Sensitive = false;
			btnSocketServer.Image = new Gtk.Image(pixbufGreen);
		}
	}

}