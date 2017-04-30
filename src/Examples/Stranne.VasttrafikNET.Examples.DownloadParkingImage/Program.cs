using System;
using System.IO;

namespace Stranne.VasttrafikNET.Examples.DownloadParkingImage
{
    class Program
    {
        private const string DeviceId = "Download Parking Image Example";

        static void Main(string[] args)
        {
            if (args.Length < 4)
            {
                Console.WriteLine("Please enter which parking and camera id from where the image should be downloaded from.");
                Console.WriteLine("Usage: Parking id <number> Camera id <number> Västtrafik key <string> Västtrafik secret <string> Download directory <string|optional>");
                return;
            }

            var id = int.Parse(args[0]);
            var cameraId = int.Parse(args[1]);
            var vtKey = args[2];
            var vtSecret = args[3];
            var imagePath = args.Length >= 5
                ? args[4]
                : ".\\";

            imagePath = imagePath.TrimEnd('\\');
            if (!string.IsNullOrWhiteSpace(imagePath) && imagePath != ".")
                Directory.CreateDirectory(imagePath);
            var file = $@"{imagePath}\Vasttrafik_id-{id}_cameraId-{cameraId}_{DateTime.Now:yyyy-MM-dd_hh-mm}.gif";

            DownloadCameraImage(file, id, cameraId, vtKey, vtSecret);
            Console.WriteLine($"Camera image saved at {file}");
        }

        private static void DownloadCameraImage(string file, int id, int cameraId, string vtKey, string vtSecret)
        {
            using (var commuterParkingService = new CommuterParkingService(vtKey, vtSecret, DeviceId))
            {
                var stream = commuterParkingService.GetParkingImage(id, cameraId);
                using (var fileStream = File.Create(file))
                {
                    stream.Seek(0, SeekOrigin.Begin);
                    stream.CopyTo(fileStream);
                }
            }
        }
    }
}