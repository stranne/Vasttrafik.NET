#addin "nuget:?package=Cake.Codecov&version=1.0.1"

#tool "nuget:?package=OpenCover&version=4.7.1221"
#tool nuget:?package=Codecov&version=1.13.0

GitVersion gitVersion = new GitVersion();
const string ArtifactsFolder = "./artifacts";
const string CoverageReportXmlFile = "./artifacts/Stranne.VasttrafikNET_coverage.xml";
const string CoverageReportFolder = "./artifacts/report";
const string CoverageReportZipFile = "./artifacts/test-report.zip";

Task("Clean")
    .Does(() =>
{
    CleanDirectories(new [] {
        ArtifactsFolder,
        "./src/Stranne.VasttrafikNET/bin",
        "./src/Stranne.VasttrafikNET.Tests/bin",
        "./src/Examples/Stranne.VasttrafikNET.Examples.Api/bin",
        "./src/Examples/Stranne.VasttrafikNET.Examples.DownloadParkingImage/bin"
    });
});

Task("Version")
    .Does(() =>
{
    try {
        gitVersion = GitVersion(new GitVersionSettings {
            UpdateAssemblyInfo = true
        });
        Information("Git version " + gitVersion.MajorMinorPatch + gitVersion.PreReleaseTagWithDash);
    } catch {
        Warning("Failed to get git version, using 1.0.0 by default");
    }
});

Task("Restore")
    .Does(() =>
{
    DotNetRestore();
});

Task("Build-Debug")
    .IsDependentOn("Version")
    .IsDependentOn("Restore")
    .Does(() =>
{
    DotNetBuild("./Stranne.VasttrafikNET.sln", new DotNetBuildSettings {
        Configuration = "Debug",
        Verbosity = Cake.Common.Tools.DotNet.DotNetVerbosity.Minimal
    });
});

Task("Run-Tests")
    .IsDependentOn("Build-Debug")
    .Does(() =>
{
    DotNetTest(
        "./src/Stranne.VasttrafikNET.Tests/Stranne.VasttrafikNET.Tests.csproj",
        new DotNetTestSettings {
            NoBuild = true
        }
    );
});

Task("Create-Open-Cover-Report")
    .IsDependentOn("Build-Debug")
    .Does(() =>
{
    OpenCover(tool => {
            tool.DotNetTest("./src/Stranne.VasttrafikNET.Tests/Stranne.VasttrafikNET.Tests.csproj", new DotNetTestSettings {
                NoBuild = true
            });
        },
        new FilePath(CoverageReportXmlFile),
        new OpenCoverSettings()
            .WithFilter("+[Stranne.VasttrafikNET]*")
            .WithFilter("-[Stranne.VasttrafikNET.Tests]*")
            .WithFilter("-[Stranne.VasttrafikNET.Examples.*]*")
    );
});

Task("Create-Test-Report")
    .IsDependentOn("Create-Open-Cover-Report")
    .Does(() =>
{
    ReportGenerator(new FilePath(CoverageReportXmlFile), CoverageReportFolder, new ReportGeneratorSettings {
        Verbosity = Cake.Common.Tools.ReportGenerator.ReportGeneratorVerbosity.Info
    });
});

Task("Build")
    .IsDependentOn("Version")
    .IsDependentOn("Restore")
    .Does(() =>
{
    DotNetBuild("./Stranne.VasttrafikNET.sln", new DotNetBuildSettings {
        Configuration = "Release",
        Verbosity = Cake.Common.Tools.DotNet.DotNetVerbosity.Minimal
    });
});

Task("Create-Nuget-Package")
    .IsDependentOn("Build")
    .Does(() =>
{
    DotNetPack("./src/Stranne.VasttrafikNET/Stranne.VasttrafikNET.csproj", new DotNetPackSettings {
        ArgumentCustomization = args => args
            .Append("--include-symbols")
            .Append("/p:NoPackageAnalysis=true")
            .Append("/p:PackageVersion=" + gitVersion.MajorMinorPatch + gitVersion.PreReleaseTagWithDash),
        NoBuild = true,
        Configuration = "Release",
        OutputDirectory = new DirectoryPath(ArtifactsFolder)
    });
});

Task("Package-Test-Report")
    .IsDependentOn("Create-Test-Report")
    .Does(() =>
{
    Zip(CoverageReportFolder, CoverageReportZipFile);
});

Task("Send-To-Codecov")
    .IsDependentOn("Create-Open-Cover-Report")
    .WithCriteria(AppVeyor.IsRunningOnAppVeyor)
    .Does(() =>
{
    Codecov(CoverageReportXmlFile);
});

Task("Default")
    .IsDependentOn("Clean")
    .IsDependentOn("Run-Tests")
    .IsDependentOn("Create-Nuget-Package");

Task("Windows")
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
