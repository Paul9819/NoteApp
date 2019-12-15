using System;
using NUnit.Framework;


namespace NoteApp.UnitTests
{
	/// <summary>
	/// Юнит-тест класса Note.
	/// </summary>
	[TestFixture]
	public class NoteTest
	{
		/// <summary>
		/// Поле класса "NoteTest", содержащее экземпляр класса "Note".
		/// </summary>
		private Note _note;

		[SetUp]
		public void InitNote()
		{
			_note = new Note();
		}

		[Test(Description = "Позитивный тест геттера Title")]
		public void TestTitleGet_CorrectValue()
		{
			var expected = "Note1";
			_note.Title = expected;
			var actual = _note.Title;

			Assert.AreEqual(expected, actual, "Геттер Title возвращает неправильное название");
		}

		[Test (Description = "Присвоение правильного названия заметки")]
		public void TestTitleSet_NoLonger50Symbols()
		{
			var rightTitle = "Thistitleisright";
			_note.Title = rightTitle;
			var actual = _note.Title;

			Assert.AreEqual(rightTitle, actual, "Название не длиннее 50 символов");
		}

		[TestCase("", "Должно возникать исключение, если название заметки - пустая строка",
			TestName = "Присвоение пустой строки в качестве названия заметки")]
		[TestCase("Thisiswrongtitle-Thisiswrongtitle-Thisiswrongtitle!",
			"Должно возникать исключение, если название длиннее 50 символов")]
		public void TestTitleSet_ArgumentException(string wrongTitle, string message)
		{
			Assert.Throws<ArgumentException>(
				() => { _note.Title = wrongTitle; }, message);
		}

		[Test(Description = "Позитивный тест геттера Type")]
		public void TestTypeGet_CorrectValue()
		{
			var expected = NoteType.Documents;
			_note.Type = expected;
			var actual = _note.Type;

			Assert.AreEqual(expected, actual, "Геттер Title возвращает неправильное название");
		}

		[Test(Description = "Позитивный тест геттера Text")]
		public void TestTextGet_CorrectValue()
		{
			var expected = "Text1";
			_note.Text = expected;
			var actual = _note.Text;

			Assert.AreEqual(expected, actual, "Геттер Title возвращает неправильное название");

		}

		//[Ignore("Не работает")]
		[Test(Description = "Тест создания копии заметки")]
		public void TestClone()
		{
			var expected = _note;
			bool IsClone = false;

			var actual = (Note)expected.Clone();

			if (expected.Title == actual.Title &
				expected.Type == actual.Type &
				expected.Text == actual.Text &
				expected.CreationTime == actual.CreationTime &
				expected.ModifiedTime == actual.ModifiedTime)
			{
				IsClone = true;
			}

			Assert.IsTrue(IsClone);
		}
	}
}
