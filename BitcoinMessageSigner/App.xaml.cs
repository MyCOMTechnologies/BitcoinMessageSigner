// <copyright company="Chris McGorty" author="Chris McGorty">
//     Copyright (c) 2024 All Rights Reserved
// </copyright>
using BitcoinMessageSigner.Pages;

namespace BitcoinMessageSigner;

public partial class App : Application
{
	public App()
	{
		this.UserAppTheme = AppTheme.Light;

		InitializeComponent();
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
		var window = new Window
		{
			Page = new MainPage()
		};

		return window;
	}
}
