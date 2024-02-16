using WIUT.DAL;

namespace WIUT
{
    public partial class ParentForm : Form
    {
        public ParentForm()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutForm().ShowDialog();
        }

        private void allApplicantsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyForms.GetForm<ApplicantListForm>().Show();
        }

        private void allCoursesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyForms.GetForm<CourseListForm>().Show();
        }

        private void newCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new CourseEditForm().CreateNewCourse();
        }

        private void newApplicantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ApplicantEditForm().CreateNewApplicant();
        }
    }
}
