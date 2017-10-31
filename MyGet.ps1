param(
    [Alias('v')]
    [string]$PackageVersion = $env:PackageVersion,
    [Alias('c')]
    [string]$Configuration = $env:Configuration
) 

$TraceColor = 'DarkCyan'

Write-Host 'dotnet clean starting' -foregroundcolor $TraceColor
dotnet clean
Write-Host 'dotnet clean completed' -foregroundcolor $TraceColor

Write-Host 'dotnet build starting' -foregroundcolor $TraceColor
dotnet build -c $Configuration /p:PackageVersion=$PackageVersion
Write-Host 'dotnet build completed' -foregroundcolor $TraceColor

Write-Host 'dotnet test starting' -foregroundcolor $TraceColor
dotnet test /p:PackageVersion=$PackageVersion
Write-Host 'dotnet test completed' -foregroundcolor $TraceColor