$destname = Read-Host 'Input new area name in lowercase'
$upperCaseDestName = (Get-Culture).TextInfo.ToTitleCase($destname)


Get-ChildItem -Filter "*blank-portal*" -Recurse | Rename-Item -NewName {$_.name -replace 'blank', $destname }

$configFiles = Get-ChildItem -Filter "*$destname*" -Recurse
foreach ($file in $configFiles)
{
    (Get-Content $file.PSPath) |
    Foreach-Object { $_ -creplace "blank", $destname } |
    Set-Content $file.PSPath
}

foreach ($file in $configFiles)
{
    (Get-Content $file.PSPath) |
    Foreach-Object { $_ -creplace "Blank", $upperCaseDestName } |
    Set-Content $file.PSPath
}