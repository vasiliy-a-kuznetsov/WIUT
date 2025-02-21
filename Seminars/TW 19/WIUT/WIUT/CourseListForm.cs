using WIUT.DAL;

namespace WIUT
{
    public partial class CourseListForm : Form
    {
        public CourseListForm()
        {
            InitializeComponent();
        }

        private void CourseListForm_Load(object sender, EventArgs e)
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
            dgv.DataSource = new CourseManager().GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new CourseEditForm().CreateNewCourse();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0)
                MessageBox.Show("Please select a course");
            else
            {
                var c = (Course)dgv.SelectedRows[0].DataBoundItem;
                new CourseEditForm().UpdateCourse(c);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0)
                MessageBox.Show("Please select a course");
            else
            {
                var c = (Course)dgv.SelectedRows[0].DataBoundItem;
                new CourseManager().Delete(c.Id);
                LoadData();
            }
        }
    }
}
