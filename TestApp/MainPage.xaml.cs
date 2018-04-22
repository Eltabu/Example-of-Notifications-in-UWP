
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Notifications;
using Microsoft.Toolkit.Uwp.Notifications;



namespace ExampleUWPNotification
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        static string title = "Title", subtitle = "Subtitle";
        private void tileButton_Click(object sender, RoutedEventArgs e)
        {
            TileNotification notification = new TileNotification(content.GetXml());
            TileUpdateManager.CreateTileUpdaterForApplication().Update(notification);
        }

        private void toastButton_Click(object sender, RoutedEventArgs e)  
        {
            ToastNotification toast = new ToastNotification(toastContent.GetXml());
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }

        TileContent content = new TileContent()  
        {
            Visual = new TileVisual()
            {
                TileMedium = new TileBinding()
                {
                    Content = new TileBindingContentAdaptive()
                    {
                        Children =
                        {
                            new AdaptiveText()
                            {  
                                Text = title,
                             },
                            new AdaptiveText()
                            {
                                Text = subtitle,
                                HintStyle = AdaptiveTextStyle.CaptionSubtle
                            },
                        }
                    }
                },
            }
        };


        ToastContent toastContent = new ToastContent()
        {
            Launch = "app-defined-string",
            Visual = new ToastVisual()
            {
                BindingGeneric = new ToastBindingGeneric()
                {
                    Children =
                    {
                     new AdaptiveText()
                    {
                     Text = title
                     },
                     new AdaptiveText()
                    {
                     Text = subtitle
                     }
                     },
                }
            },
            Actions = new ToastActionsCustom()
            {
                Buttons =
                 {
                    new ToastButton("Cancel", "Cancel")
                 },
            }
        };
    
}
}
