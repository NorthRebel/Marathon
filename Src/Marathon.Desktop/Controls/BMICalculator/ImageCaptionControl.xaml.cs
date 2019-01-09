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

namespace Marathon.Desktop.Controls.BMICalculator
{
    /// <summary>
    /// Interaction logic for ImageCaptionControl.xaml
    /// </summary>
    public partial class ImageCaptionControl : UserControl
    {
        #region Dependency Properties

        #region Caption of image

        public string Caption
        {
            get => (string)GetValue(CaptionProperty);
            set => SetValue(CaptionProperty, value);
        }

        public static readonly DependencyProperty CaptionProperty =
            DependencyProperty.Register(nameof(Caption), typeof(string), typeof(ImageCaptionControl),
                new PropertyMetadata(null, CaptionPropertyChanged));

        #endregion

        #region Font size of caption

        public double CaptionFontSize
        {
            get => (double)GetValue(CaptionFontSizeProperty);
            set => SetValue(CaptionFontSizeProperty, value);
        }

        public static readonly DependencyProperty CaptionFontSizeProperty =
            DependencyProperty.Register(nameof(CaptionFontSize), typeof(double), typeof(ImageCaptionControl), 
                new PropertyMetadata(12d, FontSizeChanged));

        #endregion

        #region Image
        
        public ImageSource ImageSrc
        {
            get => (ImageSource)GetValue(ImageSrcProperty);
            set => SetValue(ImageSrcProperty, value);
        }

        public static readonly DependencyProperty ImageSrcProperty =
            DependencyProperty.Register(nameof(ImageSrc), typeof(ImageSource), typeof(ImageCaptionControl), 
                new PropertyMetadata(null, ImageSrcChanged));


        #endregion

        #endregion

        public ImageCaptionControl()
        {
            InitializeComponent();
        }

        #region Dependency Helpers

        private static void CaptionPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ImageCaptionControl imgCaptionCtrl)
                imgCaptionCtrl.CaptionText.Text = (string) e.NewValue;
        }

        private static void FontSizeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ImageCaptionControl imgCaptionCtrl)
                imgCaptionCtrl.CaptionText.FontSize = (double) e.NewValue;
        }

        private static void ImageSrcChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ImageCaptionControl imgCaptionCtrl)
                imgCaptionCtrl.Img.Source = (ImageSource) e.NewValue;
        }

        #endregion
    }
}
