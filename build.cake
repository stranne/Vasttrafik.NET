#addin "nuget:?package=Cake.Codecov"

#tool "nuget:?package=OpenCover"
#tool "nuget:?package=ReportGenerator"
#tool "nuget:?package=GitVersion.CommandLine"
#tool "nuget:?package=Codecov"

GitVersion gitVersion = new GitVersion();
const string ArtifactsFolder = "./artifacts";
const string CoverageReportXmlFile = "./artifacts/Stranne.VasttrafikNET_coverage.xml";
const string CoverageReportFolder = "./artifacts/report";
const string CoverageReportZipFile = "./artifacts/test-report.zip";

Task("Clean")
    .Does(() =>
{
    EnsureDirectoryExists(ArtifactsFolder);
    CleanDirectories(ArtifactsFolder);
});

Task("Version")
    .Does(() =>
{
   gitVersion = GitVersion(new GitVersionSettings {
       UpdateAssemblyInfo = true
   });
   Information("Git version " + gitVersion.MajorMinorPatch + gitVersion.PreReleaseTagWithDash);
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
    MSBuild("./Stranne.VasttrafikNET.sln", new MSBuildSettings {
        Verbosity = Cake.Core.Diagnostics.Verbosity.Minimal,
        ToolVersion = Cake.Common.Tools.MSBuild.MSBuildToolVersion.VS2017,
        Configuration = "Debug"
    });
});

Task("Run-Unit-Tests")
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
    .IsDependentOn("Run-Unit-Tests")
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
    MSBuild("./Stranne.VasttrafikNET.sln", new MSBuildSettings {
        Verbosity = Cake.Core.Diagnostics.Verbosity.Minimal,
        ToolVersion = Cake.Common.Tools.MSBuild.MSBuildToolVersion.VS2017,
        Configuration = "Release"
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
    .IsDependentOn("Run-Unit-Tests")
    .Does(() =>
{
    Codecov(new CodecovSettings {
        Files = new string[] {
            CoverageReportXmlFile
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