[Home](/blog)

สร้างบล๊อกด้วย FSharp.Formatting
=============================

บล๊อกนี้เขียนด้วย markdown ทั้งหมด ผมใช้วิธีแปลงไฟล์ .md เป็น .html ด้วย [FSharp.Formatting](http://tpetricek.github.io/FSharp.Formatting/)

## ขั้นตอน

- เขียน .md ด้วย atom เก็บไว้ในโฟลเดอร์ src
- แปลงไฟล์ .md เป็น .html และ commit ขึ้น github โดยใช้สคริปต์ build.sh

## ไฟล์ build.sh

```
fsharpi format.fsx
cd ../blog
git add --all
git commit -m "update"
git push -u origin gh-pages
cd ../blog-source
```

## ไฟล์ format.fsx

```fsharp
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
```

ไฟล์อื่นๆ สามารถเข้าไปดูใน [blog-source](https://github.com/wk-j/blog-source) ได้เลย
