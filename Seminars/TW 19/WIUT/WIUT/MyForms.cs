namespace WIUT
{
    internal class MyForms
    {
        public static T GetForm<T>() where T : Form, new()
        {
            return Application.OpenForms.OfType<T>().FirstOrDefault() ?? new T();
        }
    }
}
