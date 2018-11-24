cd src
#(Get-Content Swastika-IO.sln) | ForEach-Object { $_ -creplace "Mix", "Sio" } | Set-Content Swastika-IO.sln
#Get-ChildItem -Path *Mix*.csproj* -File -Recurse | ForEach-Object -Process {
#    (Get-Content -LiteralPath $_.FullName) | ForEach-Object { $_ -creplace "Mix", "Sio" } | Set-Content $_.FullName
#    Rename-item -LiteralPath $_.FullName -NewName ($_.name -creplace "Mix","Sio") -Verbose
#}

[string[]]$excludefiles = @('package.json','package-lock.json', 'project.assets.json')

Get-ChildItem -Path *.sln -File -Recurse | ForEach-Object -Process {
    (Get-Content -LiteralPath $_.FullName) | ForEach-Object { $_ -creplace "Mix", "Sio" } | Set-Content $_.FullName
    Rename-item -LiteralPath $_.FullName -NewName ($_.name -creplace "Mix","Sio") -Verbose
}
Get-ChildItem -Path *.sln -File -Recurse | ForEach-Object -Process {
    (Get-Content -LiteralPath $_.FullName) | ForEach-Object { $_ -creplace "mix", "sio" } | Set-Content $_.FullName
    Rename-item -LiteralPath $_.FullName -NewName ($_.name -creplace "mix","sio") -Verbose
}
Get-ChildItem -Path *.project -File -Recurse | ForEach-Object -Process {
    (Get-Content -LiteralPath $_.FullName) | ForEach-Object { $_ -replace "mix", "sio" } | Set-Content $_.FullName
    Rename-item -LiteralPath $_.FullName -NewName ($_.name -replace "mix","sio") -Verbose
}


Get-ChildItem -Path *.csproj -File -Recurse | ForEach-Object -Process {
    (Get-Content -LiteralPath $_.FullName) | ForEach-Object { $_ -creplace "Mix", "Sio" } | Set-Content $_.FullName
    Rename-item -LiteralPath $_.FullName -NewName ($_.name -creplace "Mix","Sio") -Verbose
}
Get-ChildItem -Path *.csproj -File -Recurse | ForEach-Object -Process {
    (Get-Content -LiteralPath $_.FullName) | ForEach-Object { $_ -creplace "mix", "sio" } | Set-Content $_.FullName
    Rename-item -LiteralPath $_.FullName -NewName ($_.name -creplace "mix","sio") -Verbose
}

Get-ChildItem -Path *.cs -File -Recurse | ForEach-Object -Process {
    (Get-Content -LiteralPath $_.FullName) | ForEach-Object { $_ -creplace "Mix", "Sio" } | Set-Content $_.FullName
    Rename-item -LiteralPath $_.FullName -NewName ($_.name -creplace "Mix","Sio") -Verbose
}
Get-ChildItem -Path *.cs -File -Recurse | ForEach-Object -Process {
    (Get-Content -LiteralPath $_.FullName) | ForEach-Object { $_ -creplace "mix", "sio" } | Set-Content $_.FullName
    Rename-item -LiteralPath $_.FullName -NewName ($_.name -creplace "mix","sio") -Verbose
}

Get-ChildItem -Path *.cshtml -File -Recurse | ForEach-Object -Process {
    (Get-Content -LiteralPath $_.FullName) | ForEach-Object { $_ -creplace "Mix", "Sio" } | Set-Content $_.FullName
    Rename-item -LiteralPath $_.FullName -NewName ($_.name -creplace "Mix","Sio") -Verbose
}
Get-ChildItem -Path *.cshtml -File -Recurse | ForEach-Object -Process {
    (Get-Content -LiteralPath $_.FullName) | ForEach-Object { $_ -creplace "mix", "sio" } | Set-Content $_.FullName
    Rename-item -LiteralPath $_.FullName -NewName ($_.name -creplace "mix","sio") -Verbose
}



Get-ChildItem -Path *.json -File -Recurse -exclude package.json,package-lock.json,project.assets.json | ForEach-Object -Process {
    (Get-Content -LiteralPath $_.FullName) | ForEach-Object { $_ -creplace "Mix", "Sio" } | Set-Content $_.FullName
    Rename-item -LiteralPath $_.FullName -NewName ($_.name -creplace "Mix","Sio") -Verbose
}
Get-ChildItem -Path *.json -File -Recurse -exclude  package.json,package-lock.json,project.assets.json | ForEach-Object -Process {
    (Get-Content -LiteralPath $_.FullName) | ForEach-Object { $_ -creplace "mix","sio" } | Set-Content $_.FullName
    Rename-item -LiteralPath $_.FullName -NewName ($_.name -creplace "mix","sio") -Verbose
}


Get-ChildItem -Path *.html -File -Recurse | ForEach-Object -Process {
    (Get-Content -LiteralPath $_.FullName) | ForEach-Object { $_ -creplace "Mix", "Sio" } | Set-Content $_.FullName
    Rename-item -LiteralPath $_.FullName -NewName ($_.name -creplace "Mix","Sio") -Verbose
}
Get-ChildItem -Path *.html -File -Recurse | ForEach-Object -Process {
    (Get-Content -LiteralPath $_.FullName) | ForEach-Object { $_ -creplace "mix","sio" } | Set-Content $_.FullName
    Rename-item -LiteralPath $_.FullName -NewName ($_.name -creplace "mix","sio") -Verbose
}

Get-ChildItem -Path *.js -File -Recurse -exclude chartjs.min.js,aes.js,crypto-js.js,vendor.min.js | ForEach-Object -Process {
    (Get-Content -LiteralPath $_.FullName) | ForEach-Object { $_ -creplace "Mix", "Sio" } | Set-Content $_.FullName
    Rename-item -LiteralPath $_.FullName -NewName ($_.name -creplace "Mix","Sio") -Verbose
}
Get-ChildItem -Path *.js -File -Recurse -exclude chartjs.min.js,aes.js,crypto-js.js,vendor.min.js | ForEach-Object -Process {
    (Get-Content -LiteralPath $_.FullName) | ForEach-Object { $_ -creplace "mix", "sio" } | Set-Content $_.FullName
    Rename-item -LiteralPath $_.FullName -NewName ($_.name -creplace "mix","sio") -Verbose
}

Get-ChildItem -Path *.css -File -Recurse | ForEach-Object -Process {
    (Get-Content -LiteralPath $_.FullName) | ForEach-Object { $_ -creplace "Mix", "Sio" } | Set-Content $_.FullName
    Rename-item -LiteralPath $_.FullName -NewName ($_.name -creplace "Mix","Sio") -Verbose
}
Get-ChildItem -Path *.css -File -Recurse | ForEach-Object -Process {
    (Get-Content -LiteralPath $_.FullName) | ForEach-Object { $_ -creplace "mix", "sio" } | Set-Content $_.FullName
    Rename-item -LiteralPath $_.FullName -NewName ($_.name -creplace "mix","sio") -Verbose
}



#Get-ChildItem -Path Mix* -Directory | ForEach-Object -Process {
#    Rename-item -LiteralPath $_.FullName -NewName ($_.Name -creplace "Mix","Sio") -Verbose
#}

$OldText = "Mix"
$NewText = "Sio"

Get-ChildItem $Path -Recurse | %{$_.FullName} |
Sort-Object -Property Length -Descending |
% {
    Write-Host $_
    $Item = Get-Item $_
    $PathRoot = $Item.FullName | Split-Path
    $OldName = $Item.FullName | Split-Path -Leaf
    $NewName = $OldName -creplace $OldText, $NewText
    $NewPath = $PathRoot | Join-Path -ChildPath $NewName
    if (!$Item.PSIsContainer -and $Extension -contains $Item.Extension) {
        (Get-Content $Item) | % {
            #Write-Host $_
            $_ -creplace $OldText, $NewText
        } | Set-Content $Item
    }
    if ($OldName.Contains($OldText)) {
        Rename-Item -LiteralPath $Item.FullName -NewName $NewPath -Verbose
        #Write-Host $NewPath
    }
}

# Get-ChildItem -Path *ESX* -Directory | ForEach-Object -Process {Rename-item -Path $_.Name -NewName ($_.name -creplace "ESX","VMWARE") -Verbose}
