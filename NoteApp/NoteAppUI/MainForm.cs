using System;
using System.Windows.Forms;
using NoteApp;


namespace NoteAppUI
{
	public partial class MainForm : Form
	{
		/// <summary>
		/// Экземпляр класса Project, содержащий список заметок.
		/// </summary>
		private Project _project = new Project();

		/// <summary>
		/// Экземпляр формы AboutForm.
		/// </summary>
		AboutForm aboutForm = new AboutForm();

		public MainForm()
		{
			InitializeComponent();

			ShowCategoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

			exitToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.F4;
			aboutToolStripMenuItem.ShortcutKeys = Keys.F1;
			addNoteToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
			removeNoteToolStripMenuItem.ShortcutKeys = Keys.Delete;

			var values = Enum.GetValues(typeof(NoteType));
			foreach (var value in values)
			{
				ShowCategoryComboBox.Items.Add(value);
			}
			ShowCategoryComboBox.Items.Insert(0, "All");
			ShowCategoryComboBox.SelectedIndex = 0;
		}

		private void AddButton_Click(object sender, EventArgs e)
		{
			AddNote();
		}

		private void EditButton_Click(object sender, EventArgs e)
		{
			EditNote();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			aboutForm.ShowDialog();
		}

		private void addNoteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AddNote();
		}

		private void NotesListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			var selectedIndex = NotesListBox.SelectedIndex;
			if(selectedIndex != -1)
			{
				var selectedNote = _project.Notes[selectedIndex];

				TitleLabel.Text = selectedNote.Title;
				CategoryLabel.Text = selectedNote.Type.ToString("g");
				TextRichTextBox.Text = selectedNote.Text;
				CreateDateTimePicker.Value = selectedNote.CreationTime;
				ModifiedDateTimePicker.Value = selectedNote.ModifiedTime;
			}
			else
			{
				TitleLabel.Text = "Название заметки";
				CategoryLabel.Text = NoteType.Stuff.ToString("g");
				TextRichTextBox.Text = "";
			}
		}

		private void editNoteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			EditNote();
		}

		private void RemoveButton_Click(object sender, EventArgs e)
		{
			RemoveNote();
		}

		private void removeNoteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			RemoveNote();
		}

		/// <summary>
		/// Создание новой заметки.
		/// </summary>
		private void AddNote()
		{
			Note note = new Note();

			var noteForm = new NoteForm();
			noteForm.Note = note;
			noteForm.ShowDialog();
			var updateNote = noteForm.Note;

			if (noteForm.DialogResult == DialogResult.OK)
			{
				_project.Notes.Add(updateNote);
				NotesListBox.Items.Add(updateNote.Title);
			}
		}

		/// <summary>
		/// Редактирование заметки.
		/// </summary>
		private void EditNote()
		{
			var selectedIndex = NotesListBox.SelectedIndex;
			if (NotesListBox.Items.Count == 0)
			{
				MessageBox.Show("Заметок нет.", "Ошибка!",
								MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else if (selectedIndex != -1)
			{
				var selectedNote = _project.Notes[selectedIndex];

				var noteForm = new NoteForm();
				noteForm.Note = selectedNote;
				noteForm.ShowDialog();
				var updateNote = noteForm.Note;

				NotesListBox.Items.RemoveAt(selectedIndex);
				_project.Notes.RemoveAt(selectedIndex);

				_project.Notes.Insert(selectedIndex, updateNote);
				var title = updateNote.Title;
				NotesListBox.Items.Insert(selectedIndex, title);
			}
			else
			{
				MessageBox.Show("Выберите заметку для редактирования!", "Ошибка!",
								MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// Удаление заметки.
		/// </summary>
		private void RemoveNote()
		{
			var selectedIndex = NotesListBox.SelectedIndex;
			if (NotesListBox.Items.Count == 0)
			{
				MessageBox.Show("Заметок нет.", "Ошибка!",
								MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else if (selectedIndex != -1)
			{
				var selectedNote = _project.Notes[selectedIndex];

				var noteForm = new NoteForm();
				noteForm.Note = selectedNote;

				NotesListBox.Items.RemoveAt(selectedIndex);
				_project.Notes.RemoveAt(selectedIndex);
			}
			else
			{
				MessageBox.Show("Выберите заметку для удаления!", "Ошибка!",
								MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void ShowCategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			NoteType selectedType;
			selectedType = (NoteType)ShowCategoryComboBox.SelectedIndex;

			NotesListBox.Items.Clear();
			var notes = _project.Notes;
			foreach (var note in notes)
			{
				if (note.Type == selectedType | selectedType == 0)
				{
					NotesListBox.Items.Add(note.Title);
				}
			}
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			_project = ProjectManager.LoadFromFile(ProjectManager._file);
			var notes = _project.Notes;
			foreach (var note in notes)
			{
				NotesListBox.Items.Add(note.Title);
			}
		}

		private void MainForm_Deactivate(object sender, EventArgs e)
		{
			ProjectManager.SaveToFile(_project, ProjectManager._file);
		}
	}
}