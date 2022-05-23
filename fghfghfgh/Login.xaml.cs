using fghfghfgh.DataAccess.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
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
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }


        private void bth_log_Click(object sender, RoutedEventArgs e)
        {
            bool Checked = false;
            using(usersContext db = new usersContext())
            {
                //Получаем список пользователей из бд
                var users = db.Users.ToList();
                foreach (Users u in users)
                {
                    //Если введенные данные соответсвуют какому либу пользователю, открываем окно теста
                    if (u.Name == text_name.Text && u.Password == text_pass.Text)
                    {
                        MainWindow main = new MainWindow();
                        main.Show();
                        this.Close();
                        Checked = true;
                        break;
                    }
                }
                if(Checked == false) MessageBox.Show("Name or password where wrong");
            }
        }

        private void btn_reg_Click(object sender, RoutedEventArgs e)
        {
            //Создаём объект класс окно регистрации, закрываем текущее окно и открываем регистрацию
            Registration reg = new Registration();
            this.Close();
            reg.Show();
        }
    }
}
