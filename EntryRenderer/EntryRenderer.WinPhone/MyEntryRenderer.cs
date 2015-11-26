using System.Windows;
using System.Windows.Controls;
using Microsoft.Phone.Controls;
using System.Windows.Media;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;
using EntryRenderer;
using EntryRenderer.WinPhone;
using Color = Windows.UI.Color;
using Thickness = System.Windows.Thickness;

[assembly: ExportRenderer(typeof(MyEntry), typeof(MyEntryRenderer))]
namespace EntryRenderer.WinPhone
{
    public class MyEntryRenderer : Xamarin.Forms.Platform.WinPhone.EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            
            if (e.OldElement == null)
            {
                var nativePhoneTextBox = (PhoneTextBox)Control.Children[0];
                //var nativePasswordBox = (PhoneTextBox)Control.Children[1];
                nativePhoneTextBox.Background = new SolidColorBrush(Colors.Yellow);
                nativePhoneTextBox.BorderBrush = new SolidColorBrush(Colors.Transparent);
                nativePhoneTextBox.Height = 100;
                nativePhoneTextBox.Margin = new System.Windows.Thickness(2,-10,2,5);
                nativePhoneTextBox.BorderThickness = new Thickness(0);
                nativePhoneTextBox.GotFocus += GotFocusaAction;
                nativePhoneTextBox.LostFocus += LostFocusAction;

                var border = new Border();
                border.CornerRadius = new CornerRadius(25);
                border.BorderThickness = new System.Windows.Thickness(1);
                border.BorderBrush = new SolidColorBrush(Colors.Brown);
                border.Background = new SolidColorBrush(Colors.Yellow);
                border.Margin = new System.Windows.Thickness(10);
                
                var parent = nativePhoneTextBox.Parent as System.Windows.Controls.Grid;
                if (parent != null)
                {
                    parent.Children.Remove(nativePhoneTextBox);
                    parent.Children.Add(border);
                    border.Child = nativePhoneTextBox;
                }
            }
        }

        private void GotFocusaAction(object sender, System.Windows.RoutedEventArgs e)
        {
            var textbox = sender as PhoneTextBox;
            if (textbox != null)
            {
                textbox.Background = new SolidColorBrush(Colors.Yellow);
                textbox.BorderBrush = new SolidColorBrush(Colors.Yellow);
            }
            
        }

        private void LostFocusAction(object sender, System.Windows.RoutedEventArgs e)
        {
            var textbox = sender as PhoneTextBox;
            if (textbox != null)
            {
                textbox.Background = new SolidColorBrush(Colors.Yellow);
                textbox.BorderBrush = new SolidColorBrush(Colors.Yellow);
            }
        }
    }
}
