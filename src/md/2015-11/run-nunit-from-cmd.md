[Home](/blog)

รัน NUnit จาก Command line
========================

ผมมีปัญหากับการรันเทสบน Visual Studio โดยเฉพาะกับ Project F# ซึ่งใช้เวลาค่อนข้างนาน แล้ว Visual Studio ก็ชอบค้างตามไปด้วย ผมแก้ปัญหาด้วยวิธีง่ายๆ คือ ย้ายมารันบน Command line ทั้งหมด อันนี้เป็นตัวอย่างสคริปต์ที่ใช้

## ไฟล์ build.ps1

```
$cmd=$args[0]
if($cmd -eq "test") {
    $fixture=$args[1]
    $project="MyProject.Tests"
    $nunit = "C:\Program Files (x86)\NUnit 2.6.4\bin\nunit-console.exe"
    & $nunit /fixture=$project.$fixture "$project/bin/Release/$project.dll"
}
```

## Run

```
powershell -File build.ps1 test ReportTest
```

## หมายเหตุ

/fixture สำหรับ F# Module ใช้เครื่องหมาย + ขั้นระหว่าง Module กับ Class เช่น MyNamespace.MyModule+MyClass