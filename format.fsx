#I "packages/FAKE/tools/"
#r "FakeLib.dll"

#load @"FSharp.Formatting.fsx"

open FSharp.Literate
open System.IO
open Fake.FileHelper

let source = "src/md"
let resource = "resource"
let template = "src/html/template.html"
let output= "release"

let format() =
    let doc = Path.Combine(source, "hello.md")
    Literate.ProcessDirectory(source, template, "release")

let deploy() =
    CopyDir output resource (fun x -> true)


format()
deploy()
