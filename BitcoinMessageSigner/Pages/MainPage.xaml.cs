// <copyright company="Chris McGorty" author="Chris McGorty">
//     Copyright (c) 2024 All Rights Reserved
// </copyright>
using BitcoinMessageSigner.Services.Bitcoin;
using BitcoinMessageSigner.ViewModels;
using BitcoinMessageSigner.Resources.Strings;

namespace BitcoinMessageSigner.Pages;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
		BindingContext = new MainPageViewModel
		{
			MnemonicExplanation = AppResources.MnemonicExplanation,
			WifExplanation = AppResources.WifExplanation,
			LedgerExplanation = AppResources.LedgerExplanation
		};

		this.SignWif.Command = new Command(
		    execute: () => { OnSignWifMessage(); },
			canExecute: () => { return true; }
		);

		this.CopyWifSignedMessage.Command = new Command(
			execute: () => { OnCopySignedMessage(); },
			canExecute: () => { return true; }
		);

		this.SignMnemonic.Command = new Command(
		    execute: () => { OnSignMnemonicMessage(); },
			canExecute: () => { return true; }
		);

		this.CopyMnemonicSignedMessage.Command = new Command(
			execute: () => { OnCopySignedMessage(); },
			canExecute: () => { return true; }
		);

		this.SignLedger.Command = new Command(
		    execute: () => { OnSignLedgerMessage(); },
			canExecute: () => { return true; }
		);

		this.CopyLedgerSignedMessage.Command = new Command(
			execute: () => { OnCopySignedMessage(); },
			canExecute: () => { return true; }
		);
	}


	private void OnSignWifMessage()
	{
		if (BindingContext is MainPageViewModel viewModel)
		{
			try
			{
				viewModel.ErrorMessage = "";
				
				if (string.IsNullOrEmpty(viewModel.Wif)) throw new ArgumentException(AppResources.WifIsRequired);
				if (string.IsNullOrEmpty(viewModel.BitcoinAddress)) throw new ArgumentException(AppResources.BitcoinAddressIsRequired);
				if (string.IsNullOrEmpty(viewModel.Message)) throw new ArgumentException(AppResources.MessageIsRequired);

				if (!BitcoinServices.IsValidWif(viewModel.Wif)) throw new ArgumentException(AppResources.WifIsInvalid);
				if (!BitcoinServices.IsValidBitcoinAddress(viewModel.BitcoinAddress)) throw new ArgumentException(AppResources.BitcoinAddressIsInvalid);

				viewModel.SignedMessage = BitcoinServices.SignMessage(viewModel.BitcoinAddress, viewModel.Message, viewModel.Wif);
			}
			catch (Exception ex)
			{
				viewModel.ErrorMessage = ex.Message;
			}
		}
	}

	private void OnSignMnemonicMessage()
	{
		if (BindingContext is MainPageViewModel viewModel)
		{
			try
			{
				viewModel.ErrorMessage = "";

				if (string.IsNullOrEmpty(viewModel.Mnemonic)) throw new ArgumentException(AppResources.MnemonicIsRequired);
				if (string.IsNullOrEmpty(viewModel.BitcoinAddress)) throw new ArgumentException(AppResources.BitcoinAddressIsRequired);
				if (string.IsNullOrEmpty(viewModel.Message)) throw new ArgumentException(AppResources.MessageIsRequired);

				if (!BitcoinServices.IsValidMnemonicWordCount(viewModel.Mnemonic)) throw new ArgumentException(AppResources.MnemonicWordCount);
				if (!BitcoinServices.IsValidMnemonic(viewModel.Mnemonic)) throw new ArgumentException(AppResources.MnemonicIsInvalid);
				if (!BitcoinServices.IsValidBitcoinAddress(viewModel.BitcoinAddress)) throw new ArgumentException(AppResources.BitcoinAddressIsInvalid);

				viewModel.SignedMessage = BitcoinServices.SignMessage(viewModel.BitcoinAddress, viewModel.Message, viewModel.Mnemonic);
			}
			catch (Exception ex)
			{
				viewModel.ErrorMessage = ex.Message;
			}
		}
	}

	private void OnSignLedgerMessage()
	{
		if (BindingContext is MainPageViewModel viewModel)
		{
			try
			{
				if (string.IsNullOrEmpty(viewModel.BitcoinAddress)) throw new ArgumentException(AppResources.BitcoinAddressIsRequired);
				if (string.IsNullOrEmpty(viewModel.Message)) throw new ArgumentException(AppResources.MessageIsRequired);

				if (!BitcoinServices.IsValidBitcoinAddress(viewModel.BitcoinAddress)) throw new ArgumentException(AppResources.BitcoinAddressIsInvalid);

				//viewModel.SignedMessage = BitcoinServices.SignMessage(viewModel.BitcoinAddress, viewModel.Message, viewModel.Mnemonic);
			}
			catch (Exception ex)
			{
				viewModel.SignedMessage = ex.Message;
			}
		}
	}

	private async void OnCopySignedMessage()
	{
		if (BindingContext is MainPageViewModel viewModel)
		{
			if (!string.IsNullOrEmpty(viewModel.SignedMessage))
			{
				await Clipboard.Default.SetTextAsync(viewModel.SignedMessage);
				await DisplayAlert(AppResources.SignedMessage, AppResources.SignedMessageCopied, AppResources.OK);
			}
		}
	}
}

