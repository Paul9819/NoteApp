﻿using System;
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
		/// Поле класса "NoteTest", содержащее объект класса "Note".
		/// </summary>
		private Note _testNote;

		[SetUp]
		public void InitNote()
		{
			_testNote = new Note();
		}

		[Test(Description = "Позитивный тест геттера Title")]
		public void TestTitleGet_CorrectValue()
		{
			var expected = "Note1";
			_testNote.Title = expected;
			var actual = _testNote.Title;

			Assert.AreEqual(expected, actual, "Геттер Title возвращает неправильное название");
		}

		[TestCase("Thistitleisright", "Название длиннее 50 символов",
			TestName = "Присвоение правильного названия заметки")]
		[TestCase("IsNotNull", "Название заметки - пустая строка",
			TestName = "Присвоение названию заметки не пустой строки")]
		public void TestTitleSet_RightArgument(string rightTitle, string message)
		{
			_testNote.Title = rightTitle;
			var actual = _testNote.Title;

			Assert.AreEqual(rightTitle, actual, message);
		}

		[TestCase("", "Должно возникать исключение, если название заметки - пустая строка",
			TestName = "Присвоение пустой строки в качестве названия заметки")]
		[TestCase("Thisiswrongtitle-Thisiswrongtitle-Thisiswrongtitle!",
			"Должно возникать исключение, если название длиннее 50 символов",
			TestName = "Присвоение неправильной заметки больше 50 символов")]
		public void TestTitleSet_ArgumentException(string wrongTitle, string message)
		{
			Assert.Throws<ArgumentException>(
				() => { _testNote.Title = wrongTitle; }, message);
		}

		[Test(Description = "Позитивный тест геттера Type")]
		public void TestTypeGet_CorrectValue()
		{
			var expected = NoteType.Documents;
			_testNote.Type = expected;
			var actual = _testNote.Type;

			Assert.AreEqual(expected, actual, "Геттер Title возвращает неправильное название");
		}

		[Test(Description = "Позитивный тест геттера Text")]
		public void TestTextGet_CorrectValue()
		{
			var expected = "Text1";
			_testNote.Text = expected;
			var actual = _testNote.Text;

			Assert.AreEqual(expected, actual, "Геттер Title возвращает неправильное название");

		}

		[Test(Description = "Тест создания копии заметки")]
		public void TestClone()
		{
			var expected = _testNote;
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
