using System;
using System.Collections.Generic;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DateTime DT = new DateTime();
        

        int count = 0, fails = 0;
        bool flag = false;
        Random rnd = new Random();
       public List<Button> allButtons=null;
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loadded;
            allButtons = GetVisualChilds<Button>(this.Content as DependencyObject);
            
        }

        public static List<T> GetVisualChilds<T>(DependencyObject parent) where T : DependencyObject
        {
            List<T> childs = new List<T>();
            int numVisuals = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < numVisuals; i++)
            {
                DependencyObject v = VisualTreeHelper.GetChild(parent, i);
                if (v is T)
                    childs.Add(v as T);
                childs.AddRange(GetVisualChilds<T>(v));
            }
            return childs;
        }


        private void MainWindow_Loadded(object sender, RoutedEventArgs e)
        {
            grid_button.IsEnabled = false;
            button_stop.IsEnabled = false;
            textBlock_string.IsEnabled = false;

        }

        private void grid_button_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key.ToString() == "LeftShift" || e.Key.ToString() == "RightShift")
            {
                foreach (var item in allButtons)
                {
                    item.Content = item.Content.ToString().ToUpper();
                }
            }

            if (e.Key.ToString() == "Capital")
            {
                if (flag == false)
                {
                    foreach (var item in allButtons)
                    {
                        item.Content = item.Content.ToString().ToUpper();
                    }
                    flag = true;
                   
                }
               else if (flag == true)
                {
                    foreach (var item in allButtons)
                    {
                        item.Content = item.Content.ToString().ToLower();
                    }
                    flag = false;
                }
            }
            if (e.Key.ToString() == "Back")
            {        
              textBlock_write.Text = textBlock_write.Text.Substring(0, textBlock_write.Text.Length - 1);
            }

              if (e.Key.ToString() == "Space")
            {
                textBlock_write.Text+=" ";
            }
           
            //MessageBox.Show(e.Key.ToString());
            foreach (var item in allButtons)
            {        
                if (item.Name.ToString() == e.Key.ToString().ToLower())
                {
                    
                                   
                    if (item.Tag.ToString() == "Violet")
                    {
                        item.Template = this.Resources["ButtonTemplate2NonBordered"] as ControlTemplate;
                        textBlock_write.Text += item.Content.ToString();
                                            
                    }
                   else if (item.Tag.ToString() == "DeepPink")
                    {
                        item.Template = this.Resources["ButtonTemplate1NonBordered"] as ControlTemplate;
                        textBlock_write.Text += item.Content.ToString();
                        
                    }
                    else if (item.Tag.ToString() == "LimeGreen")
                    {
                        item.Template = this.Resources["ButtonTemplate3NonBordered"] as ControlTemplate;
                        textBlock_write.Text += item.Content.ToString();
                        
                    }
                    else if (item.Tag.ToString() == "Yellow")
                    {
                        item.Template = this.Resources["ButtonTemplate4NonBordered"] as ControlTemplate;
                        textBlock_write.Text += item.Content.ToString();
                      
                    }
                    else if (item.Tag.ToString() == "Gray")
                    {
                        item.Template = this.Resources["ButtonTemplate5NonBordered"] as ControlTemplate;
                        textBlock_write.Text += item.Content.ToString();
                        
                    }
                    else if (item.Tag.ToString() == "BlueViolet")
                    {
                        item.Template = this.Resources["ButtonTemplate6NonBordered"] as ControlTemplate;
                        textBlock_write.Text += item.Content.ToString();
                        
                    }
                    else if (item.Tag.ToString() == "Brown")
                    {
                        item.Template = this.Resources["ButtonTemplate7NonBordered"] as ControlTemplate;
                        
                    }
                    string buf = textBlock_string.Text;
                    string buf1 = textBlock_write.Text;

                    if (buf[count] != buf1[count])
                    {
                        fails++;
                        textBlock_fails.Text = fails.ToString();
                    }
                    count++;

                    if (count.ToString() == textBlock_string_size.Text)
                    {
                        MessageBox.Show("Тест окончен!!!");
                    }
                }
               

            }
           
        }
        private void grid_button_KeyUp(object sender, KeyEventArgs e)
        {
           
            if (e.Key.ToString() == "LeftShift" || e.Key.ToString() == "RightShift")
            {
                foreach (var item in allButtons)
                {
                    item.Content = item.Content.ToString().ToLower();
                }
            }
          
            foreach (var item in allButtons)
            {
               
                if (item.Name.ToString() == e.Key.ToString().ToLower())
                {

                    if (item.Tag.ToString() == "Violet")
                    {
                        item.Template = this.Resources["ButtonTemplate2"] as ControlTemplate;
                        break;
                    }
                    else if (item.Tag.ToString() == "DeepPink")
                    {
                      
                        item.Template = this.Resources["ButtonTemplate1"] as ControlTemplate;
                        break;
                    }
                    else if (item.Tag.ToString() == "LimeGreen")
                    {
                        item.Template = this.Resources["ButtonTemplate3"] as ControlTemplate;
                        break;
                    }
                    else if (item.Tag.ToString() == "Yellow")
                    {
                        item.Template = this.Resources["ButtonTemplate4"] as ControlTemplate;
                        break;
                    }
                    else if (item.Tag.ToString() == "Gray")
                    {
                        item.Template = this.Resources["ButtonTemplate5"] as ControlTemplate;
                        break;
                    }
                    else if (item.Tag.ToString() == "BlueViolet")
                    {
                        item.Template = this.Resources["ButtonTemplate6"] as ControlTemplate;
                        break;
                    }
                    else if (item.Tag.ToString() == "Brown")
                    {
                        item.Template = this.Resources["ButtonTemplate7"] as ControlTemplate;
                        break;

                    }
                   
                    else { continue; }
                   
                }
               

            }
        }
       

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            tbl_slider.Text = Convert.ToUInt16(slider.Value).ToString();
        }

        private void window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            textBlock_string_size.Text =Convert.ToInt16( ((window.Width) / 10)).ToString();

        }

        public void Level()
        {
           
            List<string> Symbol = new List<string> { "`", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "-", "=","]","[","p","o","i","u","y","t","r","e","w","q","a","s","d","f","g","h","j","k","l","; ","'","/",".",",","m","n","b","v","c","x","z" };

            if (tbl_slider.Text == "0")
            {
                for (int i = 0; i < Convert.ToInt16(textBlock_string_size.Text); i++)
                {
                    if (checkBox_Upper.IsChecked == true)
                    {
                        int buf = rnd.Next(0, 2);
                        if (buf != 0)
                        {
                            textBlock_string.Text += Symbol[rnd.Next(15, 20)];
                        }
                        else
                        {
                            textBlock_string.Text += (Symbol[rnd.Next(15, 20)]).ToUpper();
                        }
                    }
                    else
                    {
                        textBlock_string.Text += Symbol[rnd.Next(15, 20)];
                    }
                }
            }
            if (tbl_slider.Text == "1")
            {
                for (int i = 0; i < Convert.ToInt16(textBlock_string_size.Text); i++)
                {
                    if (checkBox_Upper.IsChecked == true)
                    {
                        int buf = rnd.Next(0, 2);
                        if (buf != 0)
                        {
                            textBlock_string.Text += Symbol[rnd.Next(10, 20)];
                        }
                        else
                        {
                            textBlock_string.Text += (Symbol[rnd.Next(10, 20)]).ToUpper();
                        }
                    }
                    else
                    {
                        textBlock_string.Text += Symbol[rnd.Next(10, 20)];
                    }
                }
            }
            if (tbl_slider.Text == "2")
            {
                for (int i = 0; i < Convert.ToInt16(textBlock_string_size.Text); i++)
                {
                    if (checkBox_Upper.IsChecked == true)
                    {
                        int buf = rnd.Next(0, 2);
                        if (buf != 0)
                        {
                            textBlock_string.Text += Symbol[rnd.Next(0, 20)];
                        }
                        else
                        {
                            textBlock_string.Text += (Symbol[rnd.Next(0, 20)]).ToUpper();
                        }
                    }
                    else
                    {
                        textBlock_string.Text += Symbol[rnd.Next(0, 20)];
                    }
                }
            }
            if (tbl_slider.Text == "3")
            {
                for (int i = 0; i < Convert.ToInt16(textBlock_string_size.Text); i++)
                {
                    if (checkBox_Upper.IsChecked == true)
                    {
                        int buf = rnd.Next(0, 2);
                        if (buf != 0)
                        {
                            textBlock_string.Text += Symbol[rnd.Next(0, 30)];
                        }
                        else
                        {
                            textBlock_string.Text += (Symbol[rnd.Next(0, 30)]).ToUpper();
                        }
                    }
                    else
                    {
                        textBlock_string.Text += Symbol[rnd.Next(0, 30)];
                    }
                }
            }
            if (tbl_slider.Text == "4")
            {
                for (int i = 0; i < Convert.ToInt16(textBlock_string_size.Text); i++)
                {
                    if (checkBox_Upper.IsChecked == true)
                    {
                        int buf = rnd.Next(0, 2);
                        if (buf != 0)
                        {
                            textBlock_string.Text += Symbol[rnd.Next(0, 35)];
                        }
                        else
                        {
                            textBlock_string.Text += (Symbol[rnd.Next(0, 35)]).ToUpper();
                        }
                    }
                    else
                    {
                        textBlock_string.Text += Symbol[rnd.Next(0, 35)];
                    }
                }
            }
            if (tbl_slider.Text == "5")
            {
                for (int i = 0; i < Convert.ToInt16(textBlock_string_size.Text); i++)
                {
                    if (checkBox_Upper.IsChecked == true)
                    {
                        int buf = rnd.Next(0, 2);
                        if (buf != 0)
                        {
                            textBlock_string.Text += Symbol[rnd.Next(0, 46)];
                        }
                        else
                        {
                            textBlock_string.Text += (Symbol[rnd.Next(0, 46)]).ToUpper();
                        }
                    }
                    else
                    {
                        textBlock_string.Text += Symbol[rnd.Next(0, 46)];
                    }
                }
            }
            button_start.IsEnabled = false;
        }

        private void button_stop_Click(object sender, RoutedEventArgs e)
        {
            count = 0; fails = 0;
            textBlock_speed.Text = "0";
            textBlock_fails.Text = "0";
            tbl_slider.Text = "0";
            textBlock_string.Text = "";
            textBlock_write.Text = "";
            checkBox_Upper.IsChecked = false;
            button_start.IsEnabled = true;
            button_stop.IsEnabled = false;
        }
        private void button_start_Click(object sender, RoutedEventArgs e)
        {
            grid_button.IsEnabled = true;
            button_stop.IsEnabled = true;
            button_start.IsEnabled = false;
            Level();
            button_Focus.Focus();          
        }

        
    }
}
