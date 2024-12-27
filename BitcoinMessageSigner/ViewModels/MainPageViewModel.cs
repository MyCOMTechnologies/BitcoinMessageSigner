// <copyright company="Chris McGorty" author="Chris McGorty">
//     Copyright (c) 2024 All Rights Reserved
// </copyright>

namespace BitcoinMessageSigner.ViewModels;

public class MainPageViewModel : BaseViewModel
{
    private string? _Wif;
    public string? Wif 
    { 
        get => _Wif;
        set
        {
            _Wif = value;
            OnPropertyChanged(nameof(Wif));
        }
    }

    private string? _Mnemonic;
    public string? Mnemonic
    { 
        get => _Mnemonic;
        set
        {
            _Mnemonic = value;
            OnPropertyChanged(nameof(Mnemonic));
        }
    }

    private string? _MnemonicExplanation;
    public string? MnemonicExplanation
    { 
        get => _MnemonicExplanation;
        set
        {
            _MnemonicExplanation = value;
            OnPropertyChanged(nameof(MnemonicExplanation));
        }
    }

    private string? _WifExplanation;
    public string? WifExplanation
    { 
        get => _WifExplanation;
        set
        {
            _WifExplanation = value;
            OnPropertyChanged(nameof(WifExplanation));
        }
    }

    private string? _LedgerExplanation;
    public string? LedgerExplanation
    { 
        get => _LedgerExplanation;
        set
        {
            _LedgerExplanation = value;
            OnPropertyChanged(nameof(LedgerExplanation));
        }
    }

    private string? _BitcoinAddress;    
    public string? BitcoinAddress
    {
        get => _BitcoinAddress;
        set
        {
            _BitcoinAddress = value;
            OnPropertyChanged(nameof(BitcoinAddress));
        }
    }

    private string? _Message;
    public string? Message 
    { 
        get => _Message;
        set
        {
            _Message = value;
            OnPropertyChanged(nameof(Message));
        }
    }

    private string? _SignedMessage;
    public string? SignedMessage
    {
        get => _SignedMessage;
        set
        {
            _SignedMessage = value;
            OnPropertyChanged(nameof(SignedMessage));
        }
    }

    private string? _ErrorMessage;
    public string? ErrorMessage 
    { 
        get => _ErrorMessage;
        set
        {
            _ErrorMessage = value;
            OnPropertyChanged(nameof(ErrorMessage));
        }
    }

}
