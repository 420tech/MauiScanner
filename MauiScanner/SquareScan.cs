using System;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace MauiScanner;

public class SquareScan : ValueChangedMessage<String>
{
	public SquareScan(string value) : base(value)
	{
	}
}

