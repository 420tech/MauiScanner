using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.Messaging;

namespace MauiScanner;

public partial class MainPage : ContentPage, IRecipient<SquareScan>
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
		WeakReferenceMessenger.Default.Register<SquareScan>(this);
	}

    public void Receive(SquareScan message)
    {
		MainThread.BeginInvokeOnMainThread(() =>
		{
            upcText.Text = message.Value;
		});
    }

    private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}

    void scannerButton_Clicked(System.Object sender, System.EventArgs e)
    {
		App.Current.MainPage.ShowPopupAsync(new ScannerPopup());
    }
}


