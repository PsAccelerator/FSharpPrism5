module MainApp

open System
open System.Windows
open System.Windows.Controls
open Microsoft.Practices.Prism.Modularity
open Microsoft.Practices.Prism.UnityExtensions
open FsXaml

type Shell = XAML<"Shell.xaml">

type App() =
    inherit Application()
        override x.OnStartup(e) =
            base.OnStartup(e)
            let bootstrapper = new DemoBootstrapper() 
            bootstrapper.Run()

and DemoBootstrapper() =
    inherit UnityBootstrapper()
    override x.CreateShell() = 
        Shell().CreateRoot() :> DependencyObject
    override x.InitializeShell() =
        base.InitializeShell()
        App.Current.MainWindow <- x.Shell :?> Window
        App.Current.MainWindow.Show()
    override x.ConfigureModuleCatalog() = 
        base.ConfigureModuleCatalog()
        let moduleCatalog = x.ModuleCatalog :?> ModuleCatalog
        moduleCatalog.AddModule(typeof<HelloWorldModule.HelloWorldModule>) |> ignore

[<STAThread>]
(new App()).Run()|> ignore