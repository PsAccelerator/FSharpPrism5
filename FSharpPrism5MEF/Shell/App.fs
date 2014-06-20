﻿module MainApp

open System
open System.Windows
open System.Windows.Controls
open FsXaml

type MainWindow = XAML<"MainWindow.xaml">

let loadWindow() =
   let window = MainWindow()
   
   // Your awesome code goes here and you have strongly typed access to the XAML via "window"
   
   window.CreateRoot()

[<STAThread>]
(new Application()).Run(loadWindow()) |> ignore