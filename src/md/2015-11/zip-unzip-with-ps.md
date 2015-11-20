
Zip และ Unzip ไฟล์ด้วย PowerShell
===============================

## ไฟล์ Zip.ps1

```
Add-Type -Assembly "System.IO.Compression.FilmeSystem"

$production="\\192.168.0.XX\Production"
$version = Get-Date -Format "yy.MMdd"
[System.IO.Compression.ZipFile]::CreateFromDirectory($production, "Production-$version.zip")
```

Zip ไฟล์ทั้งหมดใน Folder Production โดยตั้งชื่อไฟล์ให้มี วันเดือนปีปัจจุบันแนบลงไปด้วย

## ไฟล์ Unzip.ps1

```
Add-Type -Assembly "System.IO.Compression.FileSystem"

$file = $args[0]
$version = [System.IO.Path]::GetFileNameWithoutExtension($file)

if(!Test-Path $version) {
    New-Item -ItemType Directory $version
}

[System.IO.Compression.ZipFile]::ExtractToDirectory("$file", "$version")
```

Unzip ไฟล์เก็บใน Folder ชื่อเดียวกับไฟล์ Zip โดย Check ก่อนว่า Folder มีอยู่แล้วหรือไม่ ถ้ายังก็สร้างขึ้นก่อน