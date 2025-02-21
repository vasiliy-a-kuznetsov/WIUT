using WIUT.DAL;

namespace WIUT
{
    public partial class ApplicantEditForm : Form
    {
        public ApplicantEditForm()
        {
            InitializeComponent();
        }

        public Applicant Applicant { get; set; }

        public FormMode Mode { get; set; }

        public void CreateNewApplicant()
        {
            Mode = FormMode.CreateNew;
            Applicant = new Applicant();
            InitializeControls();
            MdiParent = MyForms.GetForm<ParentForm>();
            Show();
        }

        public void UpdateApplicant(Applicant applicant)
        {
            Mode = FormMode.Update;
            Applicant = applicant;
            InitializeControls();
            ShowApplicantInControls();
            MdiParent = MyForms.GetForm<ParentForm>();
            Show();
        }

        private void InitializeControls()
        {
            cbxCourse.DataSource = new CourseManager().GetAll();
        }

        private void ShowApplicantInControls()
        {
            tbxName.Text = Applicant.Name;
            tbxSurname.Text = Applicant.Surname;
            tbxAddress.Text = Applicant.Address;
            dtpDoB.Value = Applicant.DoB;
            chbIsMarried.Checked = Applicant.IsMarried;
            tbxPassportNo.Text = Applicant.PassportNo;
            cbxCourse.SelectedValue = Applicant.Course.Id;
        }

        private void GrabUserInput()
        {
            Applicant.Name = tbxName.Text;
            Applicant.Surname = tbxSurname.Text;
            Applicant.Address = tbxAddress.Text;
            Applicant.DoB = dtpDoB.Value;
            Applicant.IsMarried = chbIsMarried.Checked;
            Applicant.PassportNo = tbxPassportNo.Text;
            Applicant.Course = (Course)cbxCourse.SelectedItem;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                GrabUserInput();
                var manager = new ApplicantManager();
                if (Mode == FormMode.CreateNew)
                    manager.Create(Applicant);
                else
                    manager.Update(Applicant);

                MyForms.GetForm<ApplicantListForm>().LoadData();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
