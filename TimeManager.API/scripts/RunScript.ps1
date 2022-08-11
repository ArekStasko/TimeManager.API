Import-Module -Name SqlServer

$param = $args
$csprojPath = '../TimeManager.API.csproj'
$xml = [Xml] (Get-Content $csprojPath)
$version = [Version] $xml.Project.PropertyGroup.Version
$Location = Get-Location


if($args.Length -eq 0){
    Write-Host "You should choose mode" -ForegroundColor Red
    Write-Host "If you need help type command help" 

    break
}

if($args[0] -eq "help"){
    Write-Host "RunScript file is used for deploying database"
    Write-Host "Available modes :"
    Write-Host "* Full" -NoNewline -ForegroundColor Yellow
    Write-Output "- use this mode if you want to deploy full database from scratch"
    Write-Host "* Latest" -NoNewline -ForegroundColor Yellow 
    Write-Output "- use this mode if you want to deploy only latest version of database"
    Write-Host "Available commands :"
    Write-Host "* help" -NoNewline -ForegroundColor Yellow 
    Write-Output "- use this command if you need help"
    Write-Host "* checkDB" -NoNewline -ForegroundColor Yellow 
    Write-Output "- use for checking database state"

    break;
}


if (-not (Get-Command Invoke-Sqlcmd -ErrorAction SilentlyContinue)) {
    Write-Error "Unabled to find Invoke-SqlCmd cmdlet"
}

if (-not (Get-Module -Name SqlServer | Where-Object {$_.ExportedCommands.Count -gt 0})) {
    Write-Error "The SqlServer module is not loaded"
}

if (-not (Get-Module -ListAvailable | Where-Object Name -eq SqlServer)) {
    Write-Error "Can't find the SqlServer module"
}

if(($args[0] -eq "Full") -or ($args[0] -eq "Latest")){

Import-Module SqlServer -ErrorAction Stop

$SQLServer = "mssql-server"
$Database = 'TimeManagerDB'
$Password = 'Password.1234'
$Location = Get-Location

try
{
$Data = Get-Content -Path $Location"\configuration.json" | ConvertFrom-Json 

foreach($scriptSet in $Data.script.PSObject.Properties){
    $sqlCommand = $scriptSet.Name

    Write-Host "Start executing"$sqlCommand" scripts"

    if($Data.script.$sqlCommand.Length -lt 1){
        Write-Host "There is no scripts for"$sqlCommand -ForegroundColor Yellow
        continue
    }

    foreach ($scriptFile in $Data.script.$sqlCommand) 
    {
        $scriptFileVersion = $scriptFile.Substring(1, [Math]::Min($scriptFile.Length, 5))

        if(($args[0] -eq "Latest") -and ($scriptFileVersion -eq $version)){
        Invoke-Sqlcmd -ServerInstance $SQLServer -Database $Database -Username 'sa' -Password $Password -InputFile $Location$scriptFile -Verbose *> $Location"\Logs\ScriptLogs.log"   
        continue 
        }

        Invoke-Sqlcmd -ServerInstance $SQLServer -Database $Database -InputFile $Location$scriptFile -Verbose *> $Location"\Logs\ScriptLogs.log"   
    }
    Write-Host $sqlCommand" scripts successfully done" -ForegroundColor Green
}

Write-Host "Building database succesfully done" -ForegroundColor Green

}
catch 
{
    Write-Host "Error has occured, look to log file" -ForegroundColor Red
    Write-Host "If you need help type command help" -ForegroundColor Yellow
}

}