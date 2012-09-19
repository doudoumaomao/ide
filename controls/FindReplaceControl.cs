using System;
using System.Linq;
using Moscrif.IDE.Editors;
using Moscrif.IDE.Task;
using System.Collections.Generic;
using Moscrif.IDE.Workspace;
using Moscrif.IDE.Iface.Entities;

namespace Moscrif.IDE.Controls
{
	public partial class FindReplaceControl : Gtk.Bin
	{
		private bool ignoreTextChange = false;

		protected virtual void OnButton1Clicked(object sender, System.EventArgs e)
		{
			string expresion = this.entrExpresion.Text;

			if (!String.IsNullOrEmpty(expresion)) {
				SearchPattern sp = GetSearchPattern();

				if(cbPlace.Active == 0){
					MainClass.MainWindow.EditorNotebook.SearchNext();
				}
				else {
					sp.ReplaceExpresion = null;
					StartFindReplaceInFiles(sp);

				}

			}
		}

		private SearchPattern GetSearchPattern(){

			SearchPattern sp = new SearchPattern();
			sp.CaseSensitive = this.chbCaseSensitive.Active;
			sp.WholeWorlds = this.chbWholeWords.Active;
			sp.Expresion = this.entrExpresion.Text;
			sp.CloseFiles = new List<string>();
			sp.OpenFiles = new List<string>();

			switch (cbPlace.Active)
			{
			    case 0:{
			        sp.SearchTyp =  SearchPattern.TypSearch.CurentDocument;
			        break;
				}
			    case 1:{
				sp.SearchTyp =  SearchPattern.TypSearch.AllOpenDocument;
				sp.OpenFiles = new List<string>(MainClass.MainWindow.EditorNotebook.OpenFiles.ToArray());
				break;
				}
			    case 2:{
				sp.SearchTyp =  SearchPattern.TypSearch.CurentProject;
				MainClass.Workspace.ActualProject.GetAllFiles(ref sp.CloseFiles,MainClass.Workspace.ActualProject.AbsolutProjectDir,string.Empty,true);
				break;
				}
			    case 3:{
				sp.SearchTyp =  SearchPattern.TypSearch.AllOpenProject;
				foreach (Project p in MainClass.Workspace.Projects)
					p.GetAllFiles(ref sp.CloseFiles,p.AbsolutProjectDir,string.Empty);
				break;
				}
			}

			return sp;
		}
		/*
			switch (searchPatern.SearchTyp)
			{
			    case SearchPattern.TypSearch.CurentProject:
			        MainClass.Workspace.ActualProject.GetAllFiles(ref files,MainClass.Workspace.ActualProject.AbsolutProjectDir,string.Empty);
			        break;
			    case SearchPattern.TypSearch.AllOpenProject:{
				foreach (Project p in MainClass.Workspace.Projects)
					p.GetAllFiles(ref files,p.AbsolutProjectDir,string.Empty);
			        break;
				}
			    case SearchPattern.TypSearch.AllOpenDocument:{

			        break;
				}
			    default:
			        Console.WriteLine("Default case");
			        break;
			}
		 */

		private void SetSearch(){

			string expresion = this.entrExpresion.Text;
			if (!String.IsNullOrEmpty(expresion)) {
				SearchPattern sp = GetSearchPattern();

				if(cbPlace.Active == 0)
					MainClass.MainWindow.EditorNotebook.Search(sp);
			}
		}


		private void StartFindReplaceInFiles(SearchPattern sp){

			MainClass.MainWindow.FindOutput.Clear();

			/*foreach(string s in MainClass.MainWindow.EditorNotebook.OpenFiles)
				Console.WriteLine(s);

			Console.WriteLine("---------------");

			foreach(string s in sp.CloseFiles)
				Console.WriteLine(s);

			Console.WriteLine("*********************");*/
			// first - find/replace in open files
			List<string> notOpen = new List<string>(sp.CloseFiles);
			List<string> opened = new List<string>(sp.OpenFiles);

			List<string> allOpened = new List<string>(MainClass.MainWindow.EditorNotebook.OpenFiles);
			// files in not opened -vsetky subory rozdelime na otvorene a zavrete
			if(sp.CloseFiles.Count>0){
				// Except(sp.CloseFiles,allOpened);
				notOpen =new List<string>(sp.CloseFiles.Except(allOpened,StringComparer.CurrentCultureIgnoreCase).ToList().ToArray());
				opened = new List<string>(sp.CloseFiles.Except(notOpen,StringComparer.CurrentCultureIgnoreCase).ToList().ToArray());

				sp.CloseFiles = new List<string>(notOpen);
				sp.OpenFiles = new List<string>(opened);
			}

			TaskList tl = new TaskList();

			/*if(opened.Count>0){
				SearchPattern spO = sp.Clone();
				spO.OpenFiles = new List<string>(opened);

				FindInOpenFileTask rt = new FindInOpenFileTask();
				rt.Initialize(spO);
	
				tl.TasksList.Clear();
				tl.TasksList.Add(rt);

				sp.CloseFiles = new List<string>(notOpen);

			}*/

			// find replace in closed files

			FindReplaceTask ft = new FindReplaceTask();
			//ReplaceTask ft = new ReplaceTask();
			ft.Initialize(sp);

			tl.TasksList.Add(ft);

			MainClass.MainWindow.RunSecondaryTaskList(tl, MainClass.MainWindow.FindOutputWritte,false);
		}


		public FindReplaceControl()
		{
			this.Build();
			this.cbPlace.Active = 0;
		}

		public void SetFocus(){

			entrExpresion.GrabFocus();
		}

		public void SetFindText(string text){

			if(!String.IsNullOrEmpty(text)){

				ignoreTextChange = true;
					entrExpresion.Text = text;
			}
		}

		protected virtual void OnEntrExpresionChanged(object sender, System.EventArgs e)
		{
			if(cbPlace.Active != 0) return;

			string expresion = entrExpresion.Text;

			if (!String.IsNullOrEmpty(expresion)) {
				SearchPattern sp = GetSearchPattern();

				if(cbPlace.Active == 0){

					if(!ignoreTextChange){
						MainClass.MainWindow.EditorNotebook.Search(sp);
					} else {
	
						MainClass.MainWindow.EditorNotebook.SetSearchExpresion(sp);
						ignoreTextChange = false;
					}
				}
			}
		}

		protected virtual void OnBtnReplaceClicked(object sender, System.EventArgs e)
		{
			
			string expresion = entrExpresion.Text;
			string replaceExpresion = entrReplaceText.Text;
			
			if (String.IsNullOrEmpty(expresion))
				return;
			if (String.IsNullOrEmpty(replaceExpresion))
				return;
			
			SearchPattern sp = GetSearchPattern();
			
			sp.ReplaceExpresion = replaceExpresion;

			if(cbPlace.Active == 0){
				MainClass.MainWindow.EditorNotebook.Replace(sp);
			}else {
			/*	TaskList tl = new TaskList();
				FindTask ft = new FindTask();
				ft.Initialize(sp);

				tl.TasksList.Clear();
				tl.TasksList.Add(ft);

				MainClass.MainWindow.RunSecondaryTaskList(tl, MainClass.MainWindow.FindOutputWritte);*/

			}
		}

		protected virtual void OnBtnReplaceAllClicked(object sender, System.EventArgs e)
		{
			string expresion = entrExpresion.Text;
			string replaceExpresion = entrReplaceText.Text;
			
			if (String.IsNullOrEmpty(expresion))
				return;
			if (String.IsNullOrEmpty(replaceExpresion))
				return;
			
			SearchPattern sp = GetSearchPattern();
			
			sp.ReplaceExpresion = replaceExpresion;

			if(cbPlace.Active == 0){
				MainClass.MainWindow.EditorNotebook.ReplaceAll(sp);
			}else {
				StartFindReplaceInFiles(sp);
			}

		}

		protected virtual void OnEntrExpresionKeyReleaseEvent(object o, Gtk.KeyReleaseEventArgs args)
		{
			//if(cbPlace.Active != 0) return;
			if (args.Event.Key == Gdk.Key.Return) {
				string expresion = entrExpresion.Text;
				if (!String.IsNullOrEmpty(expresion)) {
					SearchPattern sp = GetSearchPattern();

					if(cbPlace.Active == 0){
						MainClass.MainWindow.EditorNotebook.SearchNext();
					}
					else {
						sp.ReplaceExpresion = null;

						StartFindReplaceInFiles(sp);
	
					}
				}
				
			}
			
		}


		protected void OnEntrReplaceTextKeyReleaseEvent (object o, Gtk.KeyReleaseEventArgs args)
		{
			if (String.IsNullOrEmpty(entrExpresion.Text))
				return;
			if (String.IsNullOrEmpty(entrReplaceText.Text))
				return;

			//if(cbPlace.Active != 0) return;
			if (args.Event.Key == Gdk.Key.Return) {
				string expresion = entrExpresion.Text;
				if (!String.IsNullOrEmpty(expresion)) {
					SearchPattern sp = GetSearchPattern();
					sp.ReplaceExpresion = entrReplaceText.Text;

					if(cbPlace.Active == 0){
						MainClass.MainWindow.EditorNotebook.Replace(sp);
					}
					else {
						StartFindReplaceInFiles(sp);

					}
				}

			}
		}

		protected virtual void OnChbWholeWordsToggled (object sender, System.EventArgs e)
		{
			SetSearch();
		}

		protected virtual void OnChbCaseSensitiveToggled (object sender, System.EventArgs e)
		{
			SetSearch();
		}

		protected void OnCbPlaceChanged (object sender, System.EventArgs e)
		{
			if(cbPlace.Active!= 0){
				btnReplace.Sensitive = false;
			} else {
				btnReplace.Sensitive = true;
			}
		}

	}
}
