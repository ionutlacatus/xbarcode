using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace barcodeapp
{
    public partial class AddProductPage : ContentPage
    {
        TodoItemManager manager;

        public AddProductPage()
        {
            manager = TodoItemManager.DefaultManager;
            InitializeComponent();

            doneButton.Clicked += (o, e) =>
            {
                doneButton.IsEnabled = false;
                TodoItem itemToAdd = new TodoItem
                {
                    Name = entryName.Text
                };
                manager.SaveTaskAsync(itemToAdd, () => {
                    Navigation.PushAsync(new CourseMasterDetailDB());
                });

                
            };

            var scanPage = new ZXingScannerPage();

            scanPage.OnScanResult += (result) => {
                // Stop scanning
                scanPage.IsScanning = false;

                // Pop the page and show the result
                Device.BeginInvokeOnMainThread(() => {
                    Navigation.PopAsync();
                    DisplayAlert("Scanned Barcode", result.Text, "OK");
                });
            };

            scanButton.Clicked += (o, e) =>
            {
                scanButton.IsEnabled = false;
                Navigation.PushAsync(scanPage);
            };
        }
    }
}
