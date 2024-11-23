using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OtusEvents
{
	public delegate void DownloadHanlder(string message);
	internal class ImageDownloader
	{
		private readonly string[] _remoteUris =
		{
			"https://webneel.com/daily/sites/default/files/images/daily/08-2018/1-nature-photography-spring-season-mumtazshamsee.jpg",
			"https://webneel.com/daily/sites/default/files/images/daily/08-2014/21-cat-drawing-dinotomic.jpg",
			"https://webneel.com/daily/sites/default/files/images/daily/07-2020/15-3d-model-character-design-woman-back-pose-soufiane-idrassi.jpg",
			"https://webneel.com/daily/sites/default/files/images/daily/10-2022/beautiful-nature-photography-canada-elizabeth.jpg",
			"https://webneel.com/daily/sites/default/files/images/daily/10-2022/aerial-photography-wat-samphran-temple-thailand-harimaolee.jpg",
			"https://webneel.com/daily/sites/default/files/images/daily/09-2013/spray-pen-drive-design.jpg",
			"https://webneel.com/daily/sites/default/files/images/daily/08-2020/32-kinetic-sculpture-steel-david-cerny.jpg",
			"https://webneel.com/daily/sites/default/files/images/project/pencil-lead-sculpture%20(18).jpg",
			"https://webneel.com/daily/sites/default/files/images/daily/03-2013/16-gorilla-photography.jpeg",
			"https://webneel.com/daily/sites/default/files/images/daily/12-2018/6-silhouette-photography-sunset-alex-goh-chun-seong.jpg",
			"https://webneel.com/daily/sites/default/files/images/daily/06-2013/11-best-yellow-themed-photography.jpg"
		};
		private readonly string _imgPath = @"C:\Users\fpdcore\source\repos\OtusEvents\OtusEvents\Images\";
		private readonly string _fileExtension = ".jpg";
		private readonly string _fileName = "image";

		public event DownloadHanlder ImageStarted;
		public event DownloadHanlder ImageCompleted;
		public async Task DownloadAsync(int index)
		{
			ImageStarted?.Invoke($"Качаю \"{index + 1}\" из \"{_remoteUris.Length}\"");

			var client = new WebClient();
			await client.DownloadFileTaskAsync(_remoteUris[index], $"{_imgPath}{_fileName}{index + 1}{_fileExtension}");
			client.Dispose();
			ImageCompleted?.Invoke($"Успешно скачал \"{index + 1}\" из \"{_remoteUris.Length}\"");
		}
	}
}
