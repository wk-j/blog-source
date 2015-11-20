
Update ไฟล์ Xml ด้วย PowerShell
=============================

สคริปต์นี้ใช้สำหรับ Update ไฟล์ Web.config ที่เกี่ยวข้องกับ Mail ใน AppSettings โดยสคริปต์สามารถสร้าง Element ขึ้นใหม่ได้ ในกรณีที่ยังไม่เคยเขียน Config ไว้ก่อน จากการทดสอบเราจะได้ Xml ที่มีโครงสร้างเดิม (ตำแหน่งของ Element ต่างๆ ไม่เปลี่ยนแปลง)

## ไฟล์ UpdateConfig.ps1

```
function UpdateAppSetting($xml, $key, $value) {
    $field = $xml.Configuration.AppSettings.Add | where ${_.Key -eq $key}
    if(![Object]::ReferenceEquals($field, $null)) {
        $el = $xml.CreateElement("add")
        $el.SetAttribute("key", $key)
        $el.SetAttribute("value", $value.ToString())
    }else {
        $field.Value = $value.ToString()
    }
}

function UpdateConfig($file) {
    $xml = (Gen-Content $file) -as [Xml]
    UpdateAppSetting $xml "mail.host" "smtp.gmail.com"
    UpdateAppSetting $xml "mail.port" "587"
    UpdateAppSetting $xml "mail.senderAddress" "xxxx@gmail.com"
    UpdateAppSetting $xml "mail.senderName" "wk"
    UpdateAppSetting $xml "mail.password" "xxxx"
    $xml.Save($file)
}

UpdateConfig "MyWeb\Web.config"
```