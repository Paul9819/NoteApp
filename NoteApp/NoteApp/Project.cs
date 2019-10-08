using System;
using System.Collections.Generic;
using System.Text;


namespace NoteApp
{
	/// <summary>
	/// Класс проекта, содержащий список всех заметок, созданных в приложении.
	/// </summary>
	public class Project
	{
		private List<Note> _notes = new List<Note>();

		/// <summary>
		/// Возвращает и создаёт список заметок.
		/// </summary>
		public List<Note> Notes
		{
			get
			{
				return _notes;
			}
			set
			{
				_notes = value;
			}
		}
	}
}
