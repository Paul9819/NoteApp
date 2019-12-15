using System;
using System.IO;
using System.Reflection;
using NUnit.Framework;


namespace NoteApp.UnitTests
{
	/// <summary>
	/// Юнит-тест для класса "ProjectManager".
	/// </summary>
	[TestFixture]
	public class ProjectManagerTest
	{
		/// <summary>
		/// Поле класса "ProjectManagerTest", содержащее объект класса "Note".
		/// </summary>
		private Note _testNote1;

		/// <summary>
		/// Поле класса "ProjectManagerTest", содержащее объект класса "Note".
		/// </summary>
		private Note _testNote2;

		/// <summary>
		/// Поле класса "ProjectManagerTest", содержащее объект класса "Project".
		/// </summary>
		private Project _testProject;

		[SetUp]
		public void Init()
		{
			DateTime CT = new DateTime(2019, 12, 10);
			DateTime MT = new DateTime(2019, 12, 11);

			_testProject = new Project();
			_testNote1 = new Note(CT, MT);
			_testNote2 = new Note(CT, MT);
		}

		[Test(Description = "Тест на сериализацию")]
		public void TestSaveToFile_CorrectValuе()
		{
			_testProject.Notes.Add(_testNote1);
			_testProject.Notes.Add(_testNote2);
			ProjectManager.SaveToFile(_testProject);

			string name = @"\NotesApp.notes";
			string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			string file = path + name;
			var actual = File.ReadAllText(file);

			path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			file = path + name;
			var expected = File.ReadAllText(file);

			Assert.AreEqual(expected, actual, "Ошибка сериализации");
		}

		[Test(Description = "Тест на десериализацию")]
		public void TestLoadFromFile_CorrectValue()
		{
			_testProject.Notes.Add(_testNote1);
			_testProject.Notes.Add(_testNote2);

			var expected = _testProject.Notes;
			var testProject = ProjectManager.LoadFromFile();
			var actual = testProject.Notes;

			for(var TestIndex = 0; TestIndex > expected.Count; TestIndex++)
			{
				Assert.AreEqual(expected[TestIndex], actual[TestIndex], "Ошибка десериализации");
			}
		}
	}
}
