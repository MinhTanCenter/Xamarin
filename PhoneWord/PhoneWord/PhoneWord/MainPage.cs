using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PhoneWord
{
    public partial class MainPage : ContentPage
    {
        Entry phoneNumberText;
        Button translateButton;
        Button callButton;
        string translatedNumber;
        public MainPage()
        {
            this.Padding = new Thickness(20, 20, 20, 20);
            
            StackLayout panel = new StackLayout
            {
                Spacing = 15
            };

            panel.Children.Add(new Label
            {
                Text = "Nhập mã/ số điện thoại:",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            });

            panel.Children.Add(phoneNumberText = new Entry
            {
                Text = "84-MinhTanCenter"
            });

            panel.Children.Add(translateButton = new Button
            {
                Text = "Chuyển đổi"
            });

            panel.Children.Add(callButton = new Button
            {
                Text = "Gọi",
                IsEnabled = false
            });

            translateButton.Clicked += OnTranslate;
            callButton.Clicked += OnCall;
            this.Content = panel;
        }

        private void OnTranslate(object sender, EventArgs e)
        {
            string enteredNumber = phoneNumberText.Text;
            translatedNumber = Core.PhonewordTranslator.ToNumber(enteredNumber);
            if (!string.IsNullOrEmpty(translatedNumber))
            {
                callButton.IsEnabled = true;
                callButton.Text = "Call " + translatedNumber;
            }
            else
            {
                callButton.IsEnabled = false;
                callButton.Text = "Call";
            }
        }

        async void OnCall(object sender, System.EventArgs e)
        {
            if (await this.DisplayAlert(
                "Gọi điện thoại",
                "Bạn có muốn gọi số  " + translatedNumber + " không?",
                "Đồng ý",
                "Không"))
            {
                // Call
            }
        }
    }
}
