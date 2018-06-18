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
        public List<Button> buttons;
        Trigger tr = new Trigger();
        List<Button> allButtons=null;
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

        }
       
        private void grid_button_KeyDown(object sender, KeyEventArgs e)
        {
          
            //MessageBox.Show(e.Key.ToString());
            foreach (var item in allButtons)
            {
               
                if (item.Name.ToString() == e.Key.ToString().ToLower())
                {
                    textBlock1.Text += item.Content.ToString();

                    item.FocusVisualStyle = null;
                    item.Focus();
                    break;
                }
            }

        }
        private void grid_button_KeyUp(object sender, KeyEventArgs e)
        {
            foreach (var item in allButtons)
            {

                if (item.Name.ToString() == e.Key.ToString().ToLower())
                {

                    GR.Focus();

                }
            }
        }
        private void button_start_Click(object sender, RoutedEventArgs e)
        {
            
            grid_button.IsEnabled = true;
            button_stop.IsEnabled = true;
            btn_enter.Focus();

        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            tbl_slider.Text = Convert.ToUInt16(slider.Value).ToString();
        }

        private void window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            textBlock_string_size.Text =Convert.ToInt16( ((window.Width - 26) / 10.6)).ToString();

        }

       
    }
}
