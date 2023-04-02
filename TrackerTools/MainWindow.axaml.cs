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
        RedactedHttpClient.Instance.Initialize();
        OrpheusHttpClient.Instance.Initialize();
    }
    
    public async void button_Click(object? sender, RoutedEventArgs e)
    {
        //   var button = (Button)sender;
      //  button.Content = "Hello!!";

      var responseData = await RedactedHttpClient.Instance.AsyncGetIndex();
      if (responseData != null)
      {
          var codeDisplay = this.FindControl<TextBlock>("CodeDisplay");
          codeDisplay.Text = $"Redacted: ID = {responseData.Id} Username = {responseData.Username}";
      }
      else
      {
          Console.WriteLine("Internal server Error");
      }
      
      var orpheusResponseData = await OrpheusHttpClient.Instance.AsyncGetIndex();
      if (orpheusResponseData != null)
      {
          var codeDisplay = this.FindControl<TextBlock>("CodeDisplay");
          codeDisplay.Text += $"\nOrpheus: ID = {orpheusResponseData.Id} Username = {orpheusResponseData.Username}";
      }
      else
      {
          Console.WriteLine("Internal server Error");
      }
    }
}