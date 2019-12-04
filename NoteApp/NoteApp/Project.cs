using System.Collections.Generic;


namespace NoteApp
{
	/// <summary>
	/// Класс проекта, содержащий список всех заметок, созданных в приложении.
	/// </summary>
	public class Project
	{
		/// <summary>
		/// Поле класса "Project", содержащее список заметок.
		/// </summary>
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
