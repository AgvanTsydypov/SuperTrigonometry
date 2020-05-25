using System;
using System.Windows.Forms;

namespace SuperTrigonometry
{
    public partial class EditForm : Form
    {
        public EditForm()
        {
            InitializeComponent();
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ExitBtn_MouseEnter(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(ExitBtn, "Выход из приложения");
        }

        private void StrBtn_MouseEnter(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(StrBtn, "Начать обучение");
        }

        private void StrBtn_Click(object sender, EventArgs e)
        {
            EducationForm ComboMombo = new EducationForm();
            Hide();
            ComboMombo.ShowDialog();
            Show();
        }
    }
}
