$destname = Read-Host 'Input new module name in lowercase'
$upperCaseDestName = (Get-Culture).TextInfo.ToTitleCase($destname)


Get-ChildItem -Filter "*something*" -Recurse | Rename-Item -NewName {$_.name -replace 'something', $destname }

$configFiles = Get-ChildItem -Filter "*$destname*" -Recurse
foreach ($file in $configFiles)
{
    (Get-Content $file.PSPath) |
    Foreach-Object { $_ -creplace "something", $destname } |
    Set-Content $file.PSPath
}

foreach ($file in $configFiles)
{
    (Get-Content $file.PSPath) |
    Foreach-Object { $_ -creplace "Something", $upperCaseDestName } |
    Set-Content $file.PSPath
}