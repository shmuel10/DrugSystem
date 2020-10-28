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
using DrugSystem.Command;
using DrugSystem.ViewModels;

namespace DrugSystem
{
    /// <summary>
    /// Interaction logic for FloatingControls.xaml
    /// </summary>
    public partial class FloatingControls : UserControl
    {
        public FloatingControls()
        {
            InitializeComponent();
            DataContext = new FloatingControlsVM();
        }

        public string ToolTipFirst {
            get { return (string)GetValue(ToolTipFirstProperty); }
            set { SetValue(ToolTipFirstProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ToolTipFirst.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ToolTipFirstProperty =
            DependencyProperty.Register("ToolTipFirst", typeof(string), typeof(FloatingControls), 
                new FrameworkPropertyMetadata("first",FrameworkPropertyMetadataOptions.AffectsRender, 
                    new PropertyChangedCallback(StateChangeedCallBack),new CoerceValueCallback(FixValueCallBack)));

        public string ToolTipSecond {
            get { return (string)GetValue(ToolTipSecondProperty); }
            set { SetValue(ToolTipSecondProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ToolTipFirst.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ToolTipSecondProperty =
            DependencyProperty.Register("ToolTipSecond", typeof(string), typeof(FloatingControls),
                new FrameworkPropertyMetadata("second", FrameworkPropertyMetadataOptions.AffectsRender,
                    new PropertyChangedCallback(StateChangeedCallBack), new CoerceValueCallback(FixValueCallBack)));
        public string ToolTipThird {
            get { return (string)GetValue(ToolTipThirdProperty); }
            set { SetValue(ToolTipThirdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ToolTipFirst.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ToolTipThirdProperty =
            DependencyProperty.Register("ToolTipThird", typeof(string), typeof(FloatingControls),
                new FrameworkPropertyMetadata("third", FrameworkPropertyMetadataOptions.AffectsRender,
                    new PropertyChangedCallback(StateChangeedCallBack), new CoerceValueCallback(FixValueCallBack)));
        public string ToolTipForth {
            get { return (string)GetValue(ToolTipForthProperty); }
            set { SetValue(ToolTipForthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ToolTipFirst.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ToolTipForthProperty =
            DependencyProperty.Register("ToolTipForth", typeof(string), typeof(FloatingControls),
                new FrameworkPropertyMetadata("forth", FrameworkPropertyMetadataOptions.AffectsRender,
                    new PropertyChangedCallback(StateChangeedCallBack), new CoerceValueCallback(FixValueCallBack)));

        private static void StateChangeedCallBack(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var result = d as FloatingControls;
            if (e.OldValue.Equals("first"))
            {
                result.First.ToolTip = e.NewValue.ToString();
            }else if (e.OldValue.Equals("second"))
            {
                result.Second.ToolTip = e.NewValue.ToString();
            }else if (e.OldValue.Equals("third"))
            {
                result.Third.ToolTip = e.NewValue.ToString();
            }else if (e.OldValue.Equals("forth"))
            {
                result.Forth.ToolTip = e.NewValue.ToString();
            }

        }

        private static object FixValueCallBack(DependencyObject d, object baseValue)
        {
            return baseValue;
        }
    }
}
