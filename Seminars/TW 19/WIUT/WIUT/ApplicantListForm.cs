﻿using WIUT.DAL;

namespace WIUT
{
    public partial class ApplicantListForm : Form
    {
        public ApplicantListForm()
        {
            InitializeComponent();
        }

        private void ApplicantListForm_Load(object sender, EventArgs e)
        {
            MdiParent = MyForms.GetForm<ParentForm>();
            LoadData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadData()
        {
            dgv.DataMember = "";
            dgv.DataSource = null;
            dgv.DataSource = new ApplicantManager().GetAll();
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            if (cbxSort.SelectedIndex < 0)
                MessageBox.Show("Select an attribute to sort by");
            else
            {
                ByAttribute selectedAttribute;
                if (cbxSort.SelectedIndex == 0)
                    selectedAttribute = ByAttribute.Name;
                else if (cbxSort.SelectedIndex == 1)
                    selectedAttribute = ByAttribute.Surname;
                else if (cbxSort.SelectedIndex == 2)
                    selectedAttribute = ByAttribute.DoB;
                else
                    selectedAttribute = ByAttribute.Course;

                dgv.DataMember = "";
                dgv.DataSource = null;
                dgv.DataSource = new ApplicantManager().Sort(selectedAttribute);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cbxSearch.SelectedIndex < 0)
                MessageBox.Show("Select an attribute to search by");
            else if (string.IsNullOrWhiteSpace(tbxSearch.Text))
                MessageBox.Show("Provide the search term");
            else
            {
                var selectedAttribute = cbxSearch.SelectedIndex == 0 ? ByAttribute.Name : ByAttribute.Surname;

                dgv.DataMember = "";
                dgv.DataSource = null;
                dgv.DataSource = new ApplicantManager().Search(tbxSearch.Text, selectedAttribute);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new ApplicantEditForm().CreateNewApplicant();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0)
                MessageBox.Show("Please select an applicants");
            else
            {
                var c = (Applicant)dgv.SelectedRows[0].DataBoundItem;
                new ApplicantEditForm().UpdateApplicant(c);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0)
                MessageBox.Show("Please select a applicant");
            else
            {
                var c = (Applicant)dgv.SelectedRows[0].DataBoundItem;
                new ApplicantManager().Delete(c.Id);
                LoadData();
            }
        }
    }
}
