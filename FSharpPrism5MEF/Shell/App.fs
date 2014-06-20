module MainApp

open System
open System.IO
open System.Windows
open System.ComponentModel.Composition
open System.ComponentModel.Composition.Hosting
open System.Windows.Controls
open Microsoft.Practices.Prism.Modularity
open Microsoft.Practices.Prism.MefExtensions
open FsXaml

type Shell = XAML<"Shell.xaml">

type App() =
    inherit Application()
        override x.OnStartup(e) =
            base.OnStartup(e)
            let bootstrapper = new Bootstrapper() 
            bootstrapper.Run()

and Bootstrapper() =
    inherit MefBootstrapper()
        override x.CreateShell() = 
            let window = Shell()
            window.CreateRoot() :> DependencyObject
        override x.InitializeShell() =
            base.InitializeShell()
            App.Current.MainWindow <- x.Shell :?> Window
            App.Current.MainWindow.Show()
        override x.ConfigureContainer() =
             base.ConfigureContainer()
        override x.CreateModuleCatalog() =
             new ConfigurationModuleCatalog() :> IModuleCatalog
        override x.ConfigureModuleCatalog() =
            base.ConfigureModuleCatalog()
        override x.ConfigureAggregateCatalog() =
            x.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof<Bootstrapper>.Assembly))
            let path = @"..\..\..\DirectoryModules"
            let dir = new DirectoryInfo(path);
            if not dir.Exists then dir.Create()
            let catalog = new DirectoryCatalog(path)
            x.AggregateCatalog.Catalogs.Add(catalog)

[<STAThread>]
(new App()).Run()|> ignore