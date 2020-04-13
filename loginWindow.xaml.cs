using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for loginWindow.xaml
    /// </summary>
    public partial class loginWindow : Window
    {
        public loginWindow()
        {
            InitializeComponent();
        }
        static void MyErrorMessage(String err)
        {
            UserLogin.LoginValidation.errorText = err;
            Console.WriteLine("!!!!" + err + "!!!!");
        }


        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            UserLogin.LoginValidation new1 = new UserLogin.LoginValidation(txtLogName.Text, txtLogPass.Text, MyErrorMessage);
            UserLogin.User us1 = new UserLogin.User();
            if (new1.ValidateUserInput(ref us1) == true) {
                Student newStudent = StudentValidation.GetStudentDataByUser(us1);
                MainWindow mw = new MainWindow();
                mw.showStudentInfo(newStudent);
                mw.Show();
                
            }


        }
    }
}
