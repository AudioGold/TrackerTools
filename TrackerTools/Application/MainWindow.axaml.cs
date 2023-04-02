using System;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace TrackerTools;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        
        Config.Instance.Load();
    }
    
    public async void button_Click(object? sender, RoutedEventArgs e)
    {
        var redactedClient = HttpClientFactory.GetClient(Tracker.Redacted);
        var orpheusClient = HttpClientFactory.GetClient(Tracker.Orpheus);

        try
        {
            var redactedResponse = (IndexResponseData)await redactedClient.AsyncGetActionResponse(HttpClientAction.Index);
            var orpheusResponse = (IndexResponseData)await orpheusClient.AsyncGetActionResponse(HttpClientAction.Index);
            
            var codeDisplay = this.FindControl<TextBlock>("CodeDisplay");
            codeDisplay.Text = $"Redacted: ID = {redactedResponse.Id} Username = {redactedResponse.Username}";
            codeDisplay.Text += $"\nOrpheus: ID = {orpheusResponse.Id} Username = {orpheusResponse.Username}";
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            throw;
        }
    }
}