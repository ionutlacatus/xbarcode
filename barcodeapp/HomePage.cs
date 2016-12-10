using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace barcodeapp
{
    class HomePage : ContentPage
    {

        TodoItemManager manager;
        bool authenticated = false;

        async void loginButton_Clicked(object sender, EventArgs e)
        {
            if (App.Authenticator != null)
                authenticated = await App.Authenticator.Authenticate();

            // Set syncItems to true to synchronize the data on startup when offline is enabled.
            if (authenticated == true)
                Navigation.PushAsync(new CourseMasterDetailDB());
        }

        public HomePage()
        {
            manager = TodoItemManager.DefaultManager;
            Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 0);
            Title = "XBarCode";

            var button3 = new Button { Text = "Login with Azure AD" };
            button3.Clicked += loginButton_Clicked;

              


            Content = new StackLayout
            {
                Spacing = 10,
                Children = { button3 }
            };
        }
    }
}
