namespace Exercices
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public Employee employee { get; set; }   
        public MainWindow()
        {
            this.employee = new Employee()
            {
                Age = 45,
                LastName = "Seemann",
                Name = "Mark",
                PicturePath = "images/brebi.jpg"
            };
            InitializeComponent();
            
            /*
            var pictureBinding = new Binding()
            {
                Source = employee,
                Path = new PropertyPath("PicturePath")
            };

            EmployeePicture.SetBinding(Image.SourceProperty, pictureBinding);*/
        }
    }
}