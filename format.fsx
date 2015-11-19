#I "packages/FAKE/tools/"
#r "FakeLib.dll"

#load @"FSharp.Formatting.fsx"

open FSharp.Literate
open System.IO
open Fake.FileHelper

let source = "src/md"
let resource = "resource"
let template = "src/html/template.html"
let indexTemplate = "src/html/indexTemplate.html"
let index = "src/md/index.md"
let output= "../blog"

let delete() =
    DirectoryInfo(output).GetFiles("*.html", SearchOption.AllDirectories)
    |> Seq.iter(fun x -> DeleteFile x.FullName)

let format() =
    Literate.ProcessMarkdown(index, indexTemplate, sprintf "%s/index.html" output)
    Literate.ProcessDirectory(source, template, output)
let deploy() =
    CopyDir output resource (fun x -> true)

delete()
format()
deploy()