using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
using static System.Net.Mime.MediaTypeNames;

namespace stablediffusionGUI
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

        private void getseed_Click_1(object sender, RoutedEventArgs e)
        {
            Random s1 = new System.Random();
            int s2 =s1.Next(1, 255);
            string s3 =s2.ToString();
            textseed.Text = s3;
        }

        private void textseed_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            textwhich.Text = "scripts / txt2img.py";
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            textwhich.Text = "optimizedSD/optimized_txt2img.py";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           textout.Text = "/C call " + textactivatepath.Text + " && cd " + textdiffusionpath.Text + " && activate ldm && python " + textwhich.Text + " --prompt \"" + textdescription.Text + "\" --H " + textheight.Text + " --W " + textwidth.Text + " --seed " + textseed.Text + " --n_iter " + textiter.Text + " --n_samples " + textsample.Text + " --ddim_steps " + textddimsteps.Text + " && exit";
           System.Diagnostics.Process.Start("CMD.exe", textout.Text);
        }
        

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.textheight = textheight.Text;
            Properties.Settings.Default.textwidth = textwidth.Text;
            Properties.Settings.Default.textseed = textseed.Text;
            Properties.Settings.Default.textiter = textiter.Text;
            Properties.Settings.Default.textsample = textsample.Text;
            Properties.Settings.Default.textddimsteps = textddimsteps.Text;
            Properties.Settings.Default.textactivatepath = textactivatepath.Text;
            Properties.Settings.Default.textdiffusionpath = textdiffusionpath.Text;
            Properties.Settings.Default.textwhich = textwhich.Text;
            Properties.Settings.Default.textdescription = textdescription.Text;
            Properties.Settings.Default.Save();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            textheight.Text = Properties.Settings.Default.textheight;
            textwidth.Text = Properties.Settings.Default.textwidth;
            textseed.Text = Properties.Settings.Default.textseed;
            textiter.Text = Properties.Settings.Default.textiter;
            textsample.Text = Properties.Settings.Default.textsample;
            textddimsteps.Text = Properties.Settings.Default.textddimsteps;
            textactivatepath.Text = Properties.Settings.Default.textactivatepath;
            textdiffusionpath.Text = Properties.Settings.Default.textdiffusionpath;
            textwhich.Text = Properties.Settings.Default.textwhich;
            textdescription.Text = Properties.Settings.Default.textdescription;
        }
    }
}
