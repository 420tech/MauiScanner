using System.Diagnostics;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.Messaging;
using ZXing.Net.Maui;

namespace MauiScanner;

public partial class ScannerPopup : Popup
{
	public ScannerPopup()
	{
		InitializeComponent();
        barcodeReader.Options = new BarcodeReaderOptions
        {
            Formats = BarcodeFormats.OneDimensional,
            AutoRotate = true,
            Multiple = false
        };
	}

    void cancelButton_Clicked(System.Object sender, System.EventArgs e)
    {
		Close();
    }

    void barcodeReader_BarcodesDetected(System.Object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
    {
        WeakReferenceMessenger.Default.Send(new SquareScan(e.Results[0].Value));
        Debug.WriteLine("Scan worked");
        Task.Delay(1000);
        Close();
    }
}
