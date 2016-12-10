using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace barcodeapp
{
    class CourseMasterDetailDB : ContentPage
    {
        TodoItemManager manager;
        ListView list = new ListView();
        Button addButton = new Button { Text = "Add product", IsEnabled = false };
        ObservableCollection<TodoItem> items;

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            items = await manager.GetTodoItemsAsync();
            list.ItemsSource = items;
            addButton.IsEnabled = true;
        }

        public CourseMasterDetailDB()
        {
            manager = TodoItemManager.DefaultManager;
            addButton.Clicked += (o, e) =>
            { Navigation.PushAsync(new AddProductPage()); };
            Content = new StackLayout
            {
                Children = { list, addButton }
            };
        }

    }
}
