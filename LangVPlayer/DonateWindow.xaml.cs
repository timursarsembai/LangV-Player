using System.Diagnostics;
using System.Windows;
using LangVPlayer.Resources;

namespace LangVPlayer;

public partial class DonateWindow : Window
{
    private const string DonationAlertsUrl = "https://www.donationalerts.com/r/timursarsembai";
    private const string LiberapayUrl = "https://liberapay.com/timursarsembai/donate";

    public DonateWindow()
    {
        InitializeComponent();
        ApplyLocalization();
    }

    private void ApplyLocalization()
    {
        Title = Strings.DonateTitle;
        TitleText.Text = Strings.DonateTitle;
        DescriptionText.Text = Strings.DonateDescription;
        DonateViaText.Text = Strings.DonateVia;
        
        // Update close button text
        if (CloseButton.Template.FindName("text", CloseButton) is System.Windows.Controls.TextBlock textBlock)
        {
            textBlock.Text = Strings.Close;
        }
    }

    private void DonationAlertsButton_Click(object sender, RoutedEventArgs e)
    {
        OpenUrl(DonationAlertsUrl);
    }

    private void LiberapayButton_Click(object sender, RoutedEventArgs e)
    {
        OpenUrl(LiberapayUrl);
    }

    private void CloseButton_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private static void OpenUrl(string url)
    {
        try
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }
        catch
        {
            // Ignore errors opening URL
        }
    }
}
