﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var context = new AppDbContext();
            if (context.Users.SingleOrDefault(x => x.Login == TB_Aut_Log.Text && x.Password == TB_Aut_Reg.Text) is null)
            {
                MessageBox.Show("Неправильный логин и/или пароль");
            }
            else
            {
                MessageBox.Show("Здравствуйте " + TB_Aut_Log.Text);
                var id = context.Users.Where(x => x.Login == TB_Aut_Log.Text).SingleOrDefault().Id;
                Katalog katalog = new Katalog(id);
                katalog.Show();
                this.Hide();
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Reg reg = new Reg();
            reg.Show();
            this.Hide();
        }
    }
}