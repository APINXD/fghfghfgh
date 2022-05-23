using fghfghfgh.DataAccess.DataObjects;
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

namespace fghfghfgh
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void btn_reg_Click(object sender, RoutedEventArgs e)
        {
            //Проверяем корректность введёных данных
            int age = Convert.ToInt32(text_age.Text);
            if (text_name.Text.Length < 1)
            {
                MessageBox.Show("Name Error");
                return;
            }
            if (age < 1)
            {
                MessageBox.Show("Age Error");
                return;
            }
            if (text_pass.Text.Length < 4)
            {
                MessageBox.Show("Password should be at least 4 characters long");
                return;
            }
            //Добавляем в бд нового пользователя
            Users Adduser = new Users { Name = text_name.Text, Age =  age, Password = text_pass.Text};
            AddUser(Adduser);
            //Открывваем окно логина
            Login log = new Login();
            this.Close();
            log.Show();
        }

        private void AddUser(Users Adduser)
        {
            using (usersContext db = new usersContext())
            {
                // Добавление нового пользователя
                db.Users.Add(Adduser);
                db.SaveChanges();
            }
        }
    }
}
