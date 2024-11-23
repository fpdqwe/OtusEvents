namespace OtusEvents
{
	internal class Program
	{
		private static List<Task> _tasks = new List<Task>();
		static void Main(string[] args)
		{
			ImageDownloader downloader = new ImageDownloader();
			downloader.ImageStarted += OnImageStart;
			downloader.ImageCompleted += OnImageComleted;

			for (int i = 0; i <= 9; i++)
			{
				_tasks.Add(downloader.DownloadAsync(i));
			}
			while (true)
			{
				Console.WriteLine("Нажмите клавишу A для выхода или любую другую клавишу для проверки статуса скачивания");
				var reply = Console.ReadLine();
				if (reply == "A")
				{
					break;
				}
				else
				{
					LogTasksStatus();
				}
			}
			downloader.ImageStarted -= OnImageStart;
			downloader.ImageCompleted -= OnImageComleted;
		}

		private static void LogTasksStatus()
		{
			int i = 1;
			foreach (Task task in _tasks)
			{
				Console.WriteLine($"Image {i}: {task.IsCompleted}, {task.Status}");
				i++;
			}
		}
		private static void OnImageStart(string message)
		{
			Console.WriteLine(message);
		}
		private static void OnImageComleted(string message)
		{
			Console.WriteLine(message);
		}
	}
}
