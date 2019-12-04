using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NoteApp;


namespace NoteAppUI
{
	public partial class NoteForm : Form
	{
		private Note _note;

		public Note Note
		{
			get
			{
				return _note;
			}
			set
			{
				_note = value;
				if (_note != null)
				{
					TitleTextBox.Text = "Без названия";
					CategoryComboBox.SelectedItem = NoteType.Stuff;
					NoteTextBox.Text = "";
				}
			}
		}
		public NoteForm()
		{
			InitializeComponent();
			var values = Enum.GetValues(typeof(NoteType));
			foreach(var value in values)
			{
				CategoryComboBox.Items.Add(value);
			}
		}

		private void TitleTextBox_TextChanged(object sender, EventArgs e)
		{
			if (TitleTextBox.Text.Length > 50)
			{
				this.TitleTextBox.ForeColor = Color.Red;
				MessageBox.Show("Название не должно превышать 50 символов.");
			}
			else
			{
				this.TitleTextBox.ForeColor = Color.Black;
			}
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		private void OkButton_Click(object sender, EventArgs e)
		{
			_note.Title = TitleTextBox.Text;
			_note.Type = (NoteType)CategoryComboBox.SelectedItem;
			_note.Text = NoteTextBox.Text;
			DialogResult = DialogResult.OK;
		}
	}
}