namespace HelloWorldModule

open System
open System.Windows
open System.Windows.Controls
open System.ComponentModel.Composition

open Microsoft.Practices.Prism.Modularity
open Microsoft.Practices.Prism.Regions
open Microsoft.Practices.Prism.Mvvm
open Microsoft.Practices.Prism.MefExtensions.Modularity

open FsXaml

type HelloWorldXaml = XAML<"HelloWorldView.xaml">

[<ModuleExport(typeof<HelloWorldModule>)>]
type HelloWorldModule =
    val regionViewRegistry: IRegionViewRegistry
    interface IModule with
        member x.Initialize() = x.regionViewRegistry.RegisterViewWithRegion("MainRegion", fun _ -> HelloWorldXaml():> obj)
    [<ImportingConstructor>]
    new (regionViewRegistry) = {regionViewRegistry = regionViewRegistry}