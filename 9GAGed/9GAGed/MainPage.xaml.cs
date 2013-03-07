using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using _9GAGed.Resources;
using System.Windows.Media.Imaging;

namespace _9GAGed
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            InitContent();
            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            InitContent();
        }

        private async void InitContent()
        {
           
            
            try{

            var client = new WebClient();
            string content="";
            
            content = await client.DownloadStringTask(new Uri("http://www.9gag.com/random"));
            string replaceWith = "";
            content = content.Replace("\r\n", replaceWith).Replace("\n", replaceWith).Replace("\r", replaceWith).Replace(" ", replaceWith);
            var s1 = content.Substring(content.IndexOf("img-wrap"));
            s1 = s1.Remove(0, 19);
            var  s2 = s1.Split('\"');

            ImageField.Source = new BitmapImage(new Uri("http:" + s2[0]));
            


          
                
                //titleBox.Text = jsonObject["title"].GetString();
                //string imgSource = "http:" + jsonObject["gag"].GetString();
                //var uri = new Uri(imgSource, UriKind.Absolute);
                //ImageField.Source = new BitmapImage(uri);
            }
            catch (Exception)
            {
                InitContent();
            }
            

        }
    }
}