#addin "nuget:?package=Cake.Codecov"

#tool "nuget:?package=OpenCover"
#tool "nuget:?package=ReportGenerator"
#tool "nuget:?package=GitVersion.CommandLine"
#tool "nuget:?package=Codecov"

GitVersion gitVersion;

Task("Clean")
    .Does(() =>
{
    CleanDirectories("./artifacts");
});

Task("Version")
    .Does(() =>
{
   gitVersion = GitVersion(new GitVersionSettings {
       UpdateAssemblyInfo = true
   });
});

Task("Restore")
    .Does(() =>
{
    DotNetCoreRestore(new DotNetCoreRestoreSettings {
        Verbose = false
    });
});

Task("Build-Debug")
    .IsDependentOn("Version")
    .IsDependentOn("Restore")
    .Does(() =>
{
    DotNetBuild("./Stranne.VasttrafikNET.sln", settings => settings
        .SetConfiguration("Debug")
        .SetVerbosity(Cake.Core.Diagnostics.Verbosity.Minimal));
});

Task("Run-Unit-Tests")
    .IsDependentOn("Build-Debug")
    .Does(() =>
{
    OpenCover(tool => {
            tool.DotNetCoreTest("./src/Stranne.VasttrafikNET.Tests/Stranne.VasttrafikNET.Tests.csproj", new DotNetCoreTestSettings {
                NoBuild = true,
                Verbose = false
            });
        },
        new FilePath("./artifacts/Stranne.VasttrafikNET_coverage.xml"),
        new OpenCoverSettings()
            .WithFilter("+[Stranne.VasttrafikNET]*")
            .WithFilter("-[Stranne.VasttrafikNET.Tests]*")
            .WithFilter("-[Stranne.VasttrafikNET.Examples.*]*")
    );
});

Task("Create-Test-Report")
    .IsDependentOn("Run-Unit-Tests")
    .Does(() =>
{
    ReportGenerator("./artifacts/Stranne.VasttrafikNET_coverage.xml", "./artifacts/report", new ReportGeneratorSettings {
        Verbosity = Cake.Common.Tools.ReportGenerator.ReportGeneratorVerbosity.Info
    });
});

Task("Build")
    .IsDependentOn("Version")
    .IsDependentOn("Restore")
    .Does(() =>
{
    DotNetBuild("./Stranne.VasttrafikNET.sln", settings => settings
        .SetConfiguration("Release")
        .SetVerbosity(Cake.Core.Diagnostics.Verbosity.Minimal));
});

Task("Create-Nuget-Package")
    .IsDependentOn("Build")
    .Does(() =>
{
    DotNetCorePack("./src/Stranne.VasttrafikNET/Stranne.VasttrafikNET.csproj", new DotNetCorePackSettings {
        ArgumentCustomization = args => args
            .Append("--include-symbols")
            .Append("/p:NoPackageAnalysis=true")
            .Append("/p:PackageVersion=" + gitVersion.MajorMinorPatch + gitVersion.PreReleaseTagWithDash),
        NoBuild = true,
        Configuration = "Release",
        OutputDirectory = new DirectoryPath("./artifacts")
    });
});

Task("Package-Test-Report")
    .IsDependentOn("Create-Test-Report")
    .Does(() =>
{
    Zip("./artifacts/report", "./artifacts/test-report.zip");
});

Task("Send-To-Codecov")
    .IsDependentOn("Run-Unit-Tests")
    .Does(() =>
{
    Codecov(new CodecovSettings {
        Files = new string[] {
            "./artifacts/Stranne.VasttrafikNET_coverage.xml"
        }
    });
});

Task("Default")
    .IsDependentOn("Clean")
    .IsDependentOn("Create-Test-Report")
    .IsDependentOn("Create-Nuget-Package");

Task("AppVeyor")
    .IsDependentOn("Clean")
    .IsDependentOn("Package-Test-Report")
    .IsDependentOn("Create-Nuget-Package")
    .IsDependentOn("Send-To-Codecov");

var target = Argument("target", "Default");
RunTarget(target);