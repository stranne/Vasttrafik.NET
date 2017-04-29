$rootPath = (Get-Item -Path ".\" -Verbose).FullName

dotnet restore

Set-Location 'src\Stranne.VasttrafikNET.Tests'

$resultsFile = $rootPath + '\artifacts\Stranne.VasttrafikNET_coverage.xml'
If (Test-Path $resultsFile){
	Remove-Item $resultsFile
}

$openCoverConsole = $ENV:USERPROFILE + '\.nuget\packages\OpenCover\4.6.690\tools\OpenCover.Console.exe'
$target = '-target:C:\Program Files\dotnet\dotnet.exe'
$targetArgs = '-targetargs: test -c Release'
$filter = '-filter:+[Stranne.VasttrafikNET]* -[Stranne.VasttrafikNET.Tests]* -[Stranne.VasttrafikNET.Examples.*]*'
$output = '-output:' + $resultsFile

& $openCoverConsole $target $targetArgs '-register:user' $filter '-hideskipped:Filter' '-returntargetcode' '-mergeoutput' $output '-oldStyle'

Set-Location $rootPath

$reportGenerator = $ENV:USERPROFILE + '\.nuget\packages\reportgenerator\2.5.6\tools\ReportGenerator.exe'
$reportOutput = $rootPath + '\artifacts\CoverageReport\'
$reports = '-reports:' + $resultsFile
$targetdir = '-targetdir:' + $reportOutput

If (Test-Path $reportOutput){
	Remove-Item $reportOutput -recurse
}

& $reportGenerator $reports $targetdir

Invoke-Item ($reportOutput + 'index.htm')