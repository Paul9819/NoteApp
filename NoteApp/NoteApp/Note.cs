using System;
using System.Collections.Generic;
using System.Text;


namespace NoteApp
{
	/// <summary>
	/// Класс заметки, хранящий информацию о её названии, категории, тексте,
	/// времени создания, времени последнего изменения.
	/// </summary>
	public class Note : ICloneable
	{
		private string _title = "Без названия";
		private NoteType _type = NoteType.Stuff;
		private string _text = "";
		private DateTime _creationTime = DateTime.Now;
		private DateTime _modifiedTime = DateTime.Now;


		/// <summary>
		/// Возвращает и задаёт время изменения заметки.
		/// </summary>
		public DateTime ModifiedTime
		{
			get
			{
				return _modifiedTime;
			}

			private set
			{
				value = DateTime.Now;
				_modifiedTime = value;
			}
		}

		/// <summary>
		/// Возвращает и задаёт название заметки (не более 50 символов).
		/// </summary>
		public string Title
		{
			get
			{
				return _title;
			}

			set
			{
				if (Title.Length > 50)
				{
					throw new ArgumentException("Название не должно превышать 50 символов.\n" +
						" Количество символов: " + Title.Length);
				}
				else
				{
					_title = value;
					this.ModifiedTime = DateTime.Now;
				}
			}
		}

		/// <summary>
		/// Возвращает и задаёт категорию заметки.
		/// </summary>
		public NoteType Type
		{
			get
			{
				return _type;
			}
			set
			{
				_type = value;
				this.ModifiedTime = DateTime.Now;
			}
		}

		/// <summary>
		/// Возвращает и задаёт текст заметки.
		/// </summary>
		public string Text
		{
			get
			{
				return _text;
			}
			set
			{
				_text = value;
				this.ModifiedTime = DateTime.Now;
			}
		}

		/// <summary>
		/// Возвращает дату создания заметки (доступно только для чтения).
		/// </summary>
		public DateTime CreationTime
		{
			get
			{
				return _creationTime;
			}
			private set
			{
				_creationTime = value;
			}
		}

		/// <summary>
		/// Реализует возможность создавать заметки с одинаковыми именами.
		/// </summary>
		/// <returns>Возвращает новую заметку с существующим названием.</returns>
		public object Clone()
		{
			return new Note
			{
				Title = this.Title,
				Type = this.Type,
				Text = this.Text,
				CreationTime = this.CreationTime,
				ModifiedTime = this.ModifiedTime
			};
		}
	}

	///// <summary>
	///// Интерфейс, поддерживающий копирование, при котором создаётся новый
	///// экземпляр класса с тем же значением, что и существующего экземпляра.
	///// </summary>
	//public interface ICloneable
	//{
	//	object Clone();
	//}
}