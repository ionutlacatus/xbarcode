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
        Button addButton = new Button { Text = "Add product", IsEnabled = false };
        Button findButton = new Button { Text = "Find product info", IsEnabled = false };
        ObservableCollection<TodoItem> items;
        ZXingScannerPage scanPage;

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            items = await manager.GetTodoItemsAsync();
            list.ItemsSource = items;
            list.ItemTapped += List_ItemTapped;
            addButton.IsEnabled = true;
            findButton.IsEnabled = true;
        }

        private void List_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Navigation.PushAsync(new CoursePageDB(e.Item as TodoItem));
        }

        public CourseMasterDetailDB()
        {
            Title = "Products";
            manager = TodoItemManager.DefaultManager;
            addButton.Clicked += (o, e) =>
            { Navigation.PushAsync(new AddProductPage()); };

            scanPage = new ZXingScannerPage();

            scanPage.OnScanResult += ScanPage_OnScanResult;

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

        private async void ScanPage_OnScanResult(ZXing.Result result)
        {

                scanPage.IsScanning = false;

                // Pop the page and show the result
                Device.BeginInvokeOnMainThread(async () => {
                    Navigation.PopAsync();
                    //DisplayAlert("Scanned Barcode", result.Text, "OK");
                    //entryBarcode.Text = result.Text;
                    TodoItem itm = await manager.FindProduct(result.Text);
                    Navigation.PushAsync(new CoursePageDB(itm));
                });
        }
    }
}
