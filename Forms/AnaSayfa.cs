﻿using StorkFlix.Classes;
using System;
using System.Windows.Forms;

namespace StorkFlix
{
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {
            InitializeComponent();
        }

        private bool IslemVarmi = false;
        private int Tur = 0;

        private void btnDizi_Click(object sender, EventArgs e)
        {
            if (IslemVarmi == false)
            {
                Tur = 1;
                this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
                pictureBox2.Visible = true;
                IslemVarmi = true;
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void btnFilm_Click(object sender, EventArgs e)
        {
            if (IslemVarmi == false)
            {
                Tur = 0;
                this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
                pictureBox2.Visible = true;
                IslemVarmi = true;
                backgroundWorker1.RunWorkerAsync();
            }
        }
        private Form activeForm = null;

        private void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void AnaSayfa_Load(object sender, EventArgs e)
        {
            this.Activate();
        }

        private void BackgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            StorkData listgetir = new StorkData();
            listgetir.ListeDoldur(Tur);
            listgetir.TurDoldur();
        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            IslemVarmi = false;
            pictureBox2.Visible = false;
            openChildForm(new FormProgramlar());
        }

        private void AnaSayfa_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}