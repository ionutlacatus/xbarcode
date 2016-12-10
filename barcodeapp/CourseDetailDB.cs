using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace barcodeapp
{
    class CoursePageDB : ContentPage
    {
        public CoursePageDB(TodoItem item)
        {
            Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 0);
            BackgroundColor = Color.Gray;

            this.Title = item.Name;
            //this.SetBinding(ContentPage.TitleProperty, "Name");

            var titleLabel = new Label
            {
                Text = "Nume: " + item.Name,
                Font = Font.SystemFontOfSize(NamedSize.Large)
            };
            //titleLabel.SetBinding(Label.TextProperty, "Name");


            var descriptionLabel = new Label
            {
                Text = "Descriere: " + item.Description,
                Font = Font.SystemFontOfSize(NamedSize.Medium)
            };
            //descriptionLabel.SetBinding(Label.TextProperty, "Description");

            var priceLabel = new Label
            {
                Text = "Pret: " + item.Price.ToString(),
                Font = Font.SystemFontOfSize(NamedSize.Medium)
            };
            //priceLabel.SetBinding(Label.TextProperty, "Price");

            var barcodeLabel = new Label
            {
                Text = "Cod: " + item.Code,
                Font = Font.SystemFontOfSize(NamedSize.Medium)
            };
            //barcodeLabel.SetBinding(Label.TextProperty, "Code");


            var stockLabel = new Label
            {
                Text = "Stoc disponibil: " + item.Stock.ToString() + " buc",
                Font = Font.SystemFontOfSize(NamedSize.Medium)
            };
            //stockLabel.SetBinding(Label.TextProperty, "Stock");


            var sizeLabel = new Label
            {
                Text = "Marime: " + item.Size,
                Font = Font.SystemFontOfSize(NamedSize.Medium)
            };
            //sizeLabel.SetBinding(Label.TextProperty, "Size");



            Content = new ScrollView
            {
                Content = new StackLayout
                {
                    Spacing = 10,
                    Children = { titleLabel, descriptionLabel, priceLabel, barcodeLabel, stockLabel, sizeLabel }
                }
            };
        }
    }
}
