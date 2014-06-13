namespace HelloWorldModule

open System
open System.Windows
open System.Windows.Controls

open Microsoft.Practices.Prism.Modularity
open Microsoft.Practices.Prism.Regions
open Microsoft.Practices.Prism.Mvvm

open FSharpx

type HelloWorldXaml = XAML<"HelloWorldView.xaml">

type HelloWorldModule(registry:IRegionViewRegistry) =
    let mutable regionViewRegistry = registry
    interface IModule with
        member x.Initialize() = regionViewRegistry.RegisterViewWithRegion("MainRegion", fun _ -> HelloWorldXaml().Root:> obj)