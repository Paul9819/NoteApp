using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;


namespace NoteApp
{
	/// <summary>
	/// Класс менеджера проекта, хранящий метод сохранения объекта "Проект"
	/// в файл и загрузки проекта из файла.
	/// </summary>
	public static class ProjectManager
	{
		private const string _name = @"\NotesApp.notes";
		private static string _path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
		private static string _file = _path + _name;

		/// <summary>
		/// Реализует сохранение объекта "Проект" в файл.
		/// </summary>
		/// <param name="project">Указание проекта, который нужно сохранить.</param>
		public static void SaveToFile(Project project)
		{
			//Создаём экземпляр сериализатора.
			JsonSerializer serializer = new JsonSerializer();
			serializer.Formatting = Formatting.Indented;

			//Открываем поток для записи в файл с указанием пути.
			using (StreamWriter sw = new StreamWriter(_file))
			using (JsonWriter writer = new JsonTextWriter(sw))
			{
				//Вызываем сериализацию и передаём объект, который хотим сериализовать.
				serializer.Serialize(writer, project);
			}
		}

		/// <summary>
		/// Реализует загрузку объекта "Проект" из файла.
		/// </summary>
		/// <param name="project">Указание нужного проекта, который нужно загрузить.</param>
		public static void LoadFromFile(Project project)
		{
			//Создаём экземпляр сериализатора.
			JsonSerializer serializer = new JsonSerializer();
			serializer.Formatting = Formatting.Indented;

			//Открываем поток для чтения из файла с указанием пути.
			using (StreamReader sr = new StreamReader(_file))
			using (JsonReader reader = new JsonTextReader(sr))
			{
				//Вызываем десериализацию и явно преобразуем результат в целевой тип данных
				project = (Project)serializer.Deserialize<Project>(reader);
			}
		}
	}
}