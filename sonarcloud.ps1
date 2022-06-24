param(
    [string] $sonarSecret
)

Install-package BuildUtils -Confirm:$false -Scope CurrentUser -Force
Import-Module BuildUtils

$runningDirectory = Split-Path -Parent -Path $MyInvocation.MyCommand.Definition

$testOutputDir = "$runningDirectory/TestResults"

if (Test-Path $testOutputDir)
{
    Write-host "Cleaning temporary Test Output path $testOutputDir"
    Remove-Item $testOutputDir -Recurse -Force
}

$version = Invoke-Gitversion
$assemblyVer = $version.assemblyVersion

$branch = git branch --show-current
Write-Host "branch is $branch"

dotnet tool restore
#dotnet tool run dotnet-sonarscanner begin '
.\.sonar\scanner\dotnet-sonarscanner begin /k:"knsatishkumar-org_demo-sonar" /o:"knsatishkumar-org" /d:sonar.login="$sonarSecret" /d:sonar.host.url="https://sonarcloud.io" '
  /d:sonar.cs.vstest.reportsPaths=TestResults/*.trx ' # Path where I'm expecting to find test result in trx format
  /d:sonar.cs.opencover.reportsPaths=TestResults/*/coverage.opencover.xml ' # Name of the code coverage file
  /d:sonar.coverage.exclusions="**Test*.cs" '   # asembly names to be excluded from code coverage
  /d:sonar.branch.name="$branch"                # Actual branch I'm analyzing.

dotnet restore src
dotnet build src --configuration release

# Now execute tests with special attention to produce output
# that can be easily read by SonarCloud analyzer
dotnet test '
  -collect:"XPlat Code Coverage" '           # cross platform code coverage
  -results-directory TestResults/ '          # Test Result directory
  -logger "trx;LogFileName=unittests.trx" '  # Use standard trx format for logger output
  -no-build '
  -no-restore '
  -configuration release '
  -DataCollectionRunSettings.DataCollectors.DataCollector.Configuration.Format=opencover '# Special open cover data collector

.\.sonar\scanner\dotnet-sonarscanner end /d:sonar.login="$sonarSecret"
#dotnet tool run dotnet-sonarscanner end /d:sonar.login="$sonarSecret"