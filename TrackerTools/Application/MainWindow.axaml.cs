using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using TrackerTools.RestApi.Actions;
using TrackerTools.RestApi.ApiResponses.Common;
using TrackerTools.RestApi.ApiResponses.Common.Inbox;
using TrackerTools.RestApi.ApiResponses.Common.Index;
using TrackerTools.RestApi.ApiResponses.Orpheus;
using TrackerTools.RestApi.ApiResponses.Redacted;
using TrackerTools.RestApi.Clients;

namespace TrackerTools.Application;

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
            var redactedIndexResponse = await redactedClient.AsyncGetActionResponse<IndexApiResponse>(new IndexHttpClientActionData());
            if (redactedIndexResponse == null)
                return;
            
            var redactedUserResponse = await redactedClient.AsyncGetActionResponse<RedactedUserApiResponse>(new UserHttpClientActionData(redactedIndexResponse.Response.Id));
            if (redactedUserResponse == null)
                return;
            
            var orpheusIndexResponse = await orpheusClient.AsyncGetActionResponse<IndexApiResponse>(new IndexHttpClientActionData());
            if (orpheusIndexResponse == null)
                return;
        
            var orpheusUserResponse = await orpheusClient.AsyncGetActionResponse<OrpheusUserApiResponse>(new UserHttpClientActionData(orpheusIndexResponse.Response.Id));
            if (orpheusUserResponse == null)
                return;
            
            var redactedInboxResponse = await redactedClient.AsyncGetActionResponse<InboxApiResponse>(
                new InboxHttpClientActionData(1,
                    InboxHttpClientActionData.Type.Inbox,
                    "unread",
                    "",
                    InboxHttpClientActionData.SearchType.Subject));
            if (redactedInboxResponse == null)
                return;
            
            var orpheusInboxResponse = await orpheusClient.AsyncGetActionResponse<InboxApiResponse>(
                new InboxHttpClientActionData(1,
                    InboxHttpClientActionData.Type.Inbox,
                    "unread",
                    "",
                    InboxHttpClientActionData.SearchType.Subject));
            if (orpheusInboxResponse == null)
                return;
            
            var codeDisplay = this.FindControl<TextBlock>("CodeDisplay");
            codeDisplay.Text = $"Redacted: ID = {redactedIndexResponse.Response.Id} Username = {redactedIndexResponse.Response.Username}";
            codeDisplay.Text += $"\nRedacted User: Avatar = {redactedUserResponse.Response.Avatar} Downloaded = {redactedUserResponse.Response.Ranks.Downloaded}";
            
            codeDisplay.Text += $"\nOrpheus: ID = {orpheusIndexResponse.Response.Id} Username = {orpheusIndexResponse.Response.Username}";
            codeDisplay.Text += $"\nOrpheus User: Avatar = {orpheusUserResponse.Response.Avatar} Downloaded = {orpheusUserResponse.Response.Ranks.Downloaded}";
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            throw;
        }
    }
}