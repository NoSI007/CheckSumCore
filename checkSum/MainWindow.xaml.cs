using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace checkSum
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {



        public int RESULT
        {
            get { return (int)GetValue(RESULTProperty); }
            set { SetValue(RESULTProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RESULT.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RESULTProperty =
            DependencyProperty.Register("RESULT", typeof(int), typeof(MainWindow), new PropertyMetadata(0));


        ComputeAHash ComputedHASH = new ComputeAHash();
        BackgroundWorker bg1 = new BackgroundWorker();

        OpenFileDialog ofd = new OpenFileDialog();




        public MainWindow()
        {
            InitializeComponent();
            init();
        }



        private void init()
        {
            RESULT = 0;
            DataContext = this;
            bg1.DoWork += new DoWorkEventHandler(bg1_DoWork);
            bg1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bg1_RunWorkerCompleted);
        }

        void bg1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            z_computed.Text = ComputedHASH.Hashvalue;
            //if (string.IsNullOrWhiteSpace(this.z_expected.Text) == false )
            ShowResult();
            showbtns();
        }

        private void showbtns()
        {
            this.z_open.Visibility = System.Windows.Visibility.Visible;
            this.Compute.Visibility = System.Windows.Visibility.Visible;
        }

        void bg1_DoWork(object sender, DoWorkEventArgs e)
        {

            switch (e.Argument.ToString())
            {
                case "SHA1":
                    ComputedHASH.SHA1(ofd.FileName);
                    break;
                case "MD5":
                    ComputedHASH.MD5(ofd.FileName);
                    break;
                case "RIPEMD160"://skip for now.
                    //ComputedHASH.RIPEMD160(ofd.FileName);
                    break;
                case "SHA512":
                    ComputedHASH.SHA512(ofd.FileName);
                    break;
                case "SHA256":
                    ComputedHASH.SHA256(ofd.FileName);
                    break;
                case "SHA384":
                    ComputedHASH.SHA384(ofd.FileName);
                    break;
            }
        }





        private void z_open_Click(object sender, RoutedEventArgs e)
        {
            OpenFile();

        }

        private void OpenFile()
        {
            ofd.Multiselect = false;
            if (ofd.ShowDialog(this) != false)
            {
                z_file.Text = ofd.FileName;
            }
            RESULT = 0;
        }



        private void ShowResult()
        {
            if (string.IsNullOrWhiteSpace(z_expected.Text) == false)
            {
                string computed = z_computed.Text.ToLower();
                string expected = z_expected.Text.ToLower();
                if (string.Compare(computed, expected) == 0)
                {
                    RESULT = 1;
                    return;
                }
            }

            RESULT = 999;
        }



        private void CompTheHash()
        {

            bg1.RunWorkerAsync(z_hash.Text);
            HideBtns();
        }

        private void HideBtns()
        {
            this.z_open.Visibility = System.Windows.Visibility.Hidden;
            this.Compute.Visibility = System.Windows.Visibility.Hidden;
        }



        private void Compute_Click(object sender, RoutedEventArgs e)
        {
            CompTheHash();
        }





    }
}
