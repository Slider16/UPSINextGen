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
using System.Windows.Shapes;

namespace Utilities.wpf.ViewModels
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Handle window sizing for varying screen resolutions
            double workHeight = SystemParameters.WorkArea.Height;
            double workWidth = SystemParameters.WorkArea.Width;
            this.Top = (workHeight - this.Height) / 2;
            this.Left = (workWidth - this.Width) / 2;
        }

        #region Custom Window Resize and Move Events

        bool isWiden = false;
        private void window_initiateWiden(object sender, MouseEventArgs e)
        {
            isWiden = true;
        }

        private void window_Widen(object sender, MouseEventArgs e)
        {
            Rectangle rect = (Rectangle)sender;
            if (isWiden)
            {
                rect.CaptureMouse();
                double newWidth = e.GetPosition(this).X + 5;
                if (newWidth > 0)
                {
                    this.Width = newWidth;
                }
            }
        }

        private void window_endWiden(object sender, MouseEventArgs e)
        {
            isWiden = false;

            // Make sure mouse capture is released.
            Rectangle rect = (Rectangle)sender;
            rect.ReleaseMouseCapture();
        }

        bool isHeighten = false;
        private void window_initiateHeighten(object sender, MouseEventArgs e)
        {
            isHeighten = true;
        }

        private void window_Heighten(object sender, MouseEventArgs e)
        {
            Rectangle rect = (Rectangle)sender;
            if (isHeighten)
            {
                rect.CaptureMouse();
                double newHeight = e.GetPosition(this).Y + 5;
                if (newHeight > 0)
                {
                    this.Height = newHeight;
                }
            }
        }

        private void window_endHeighten(object sender, MouseEventArgs e)
        {
            isHeighten = false;

            // Make sure mouse capture is released.
            Rectangle rect = (Rectangle)sender;
            rect.ReleaseMouseCapture();
        }

        private void titleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        #endregion // Custom Window Resize and Move Events

    }
}
