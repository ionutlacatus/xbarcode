using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace barcodeapp
{
    class CourseMasterDetailDB : ContentPage
    {
        TodoItemManager manager;
        ListView list = new ListView();
        Button addButton = new Button { Text = "Adauga produs", IsEnabled = false };
        Button findButton = new Button { Text = "Cauta produs", IsEnabled = false };
        ObservableCollection<TodoItem> items;

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            items = await manager.GetTodoItemsAsync();
            list.ItemsSource = items;
            list.ItemTapped += List_ItemTapped;
            addButton.IsEnabled = true;
        }

        private void List_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Navigation.PushAsync(new CoursePageDB(e.Item as TodoItem));
        }

        public CourseMasterDetailDB()
        {
            manager = TodoItemManager.DefaultManager;
            addButton.Clicked += (o, e) =>
            { Navigation.PushAsync(new AddProductPage()); };

            var scanPage = new ZXingScannerPage();

            scanPage.OnScanResult += (result) => {
                // Stop scanning
                scanPage.IsScanning = false;

                // Pop the page and show the result
                Device.BeginInvokeOnMainThread(() => {
                    Navigation.PopAsync();
                    //DisplayAlert("Scanned Barcode", result.Text, "OK");
                    //entryBarcode.Text = result.Text;
                    TodoItem itm = manager.FindProduct(result.Text).Result;
                    Navigation.PushAsync(new CoursePageDB(itm));
                });
            };

            findButton.Clicked += (o, e) =>
            {
                findButton.IsEnabled = false;
                Navigation.PushAsync(scanPage);
            };

            Content = new StackLayout
            {
                Children = { list, addButton, findButton }
            };
        }

    }
}
