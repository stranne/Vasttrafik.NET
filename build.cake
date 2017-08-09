#addin "nuget:?package=Cake.Codecov"
#addin "nuget:?package=Cake.Incubator"

#tool "nuget:?package=OpenCover"
#tool "nuget:?package=ReportGenerator"
#tool "nuget:?package=GitVersion.CommandLine"
#tool "nuget:?package=Codecov&version=1.0.1"

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
    DotNetCoreRestore();
});

Task("Build-Debug")
    .IsDependentOn("Version")
    .IsDependentOn("Restore")
    .Does(() =>
{
    DotNetCoreBuild("./Stranne.VasttrafikNET.sln", new DotNetCoreBuildSettings {
        Configuration = "Debug",
        Verbosity = Cake.Common.Tools.DotNetCore.DotNetCoreVerbosity.Minimal
    });
});

Task("Run-Tests")
    .IsDependentOn("Build-Debug")
    .Does(() =>
{
    DotNetCoreTest(
        new DotNetCoreTestSettings {
            NoBuild = true
        },
        "./src/Stranne.VasttrafikNET.Tests/Stranne.VasttrafikNET.Tests.csproj",
        new Cake.Common.Tools.XUnit.XUnit2Settings()
    );
});

Task("Create-Open-Cover-Report")
    .IsDependentOn("Build-Debug")
    .Does(() =>
{
    OpenCover(tool => {
            tool.DotNetCoreTest("./src/Stranne.VasttrafikNET.Tests/Stranne.VasttrafikNET.Tests.csproj", new DotNetCoreTestSettings {
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
    ReportGenerator(CoverageReportXmlFile, CoverageReportFolder, new ReportGeneratorSettings {
        Verbosity = Cake.Common.Tools.ReportGenerator.ReportGeneratorVerbosity.Info
    });
});

Task("Build")
    .IsDependentOn("Version")
    .IsDependentOn("Restore")
    .Does(() =>
{
    DotNetCoreBuild("./Stranne.VasttrafikNET.sln", new DotNetCoreBuildSettings {
        Configuration = "Release",
        Verbosity = Cake.Common.Tools.DotNetCore.DotNetCoreVerbosity.Minimal
    });
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
    Codecov(new CodecovSettings {
        Files = new [] { CoverageReportXmlFile }    });
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

Task("Travis")
    .IsDependentOn("Clean")
    .IsDependentOn("Run-Tests")
    .IsDependentOn("Create-Nuget-Package");

var target = Argument("target", "Default");
RunTarget(target);