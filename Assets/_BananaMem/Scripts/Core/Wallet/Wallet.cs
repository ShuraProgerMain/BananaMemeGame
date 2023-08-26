using ShuraGames.BananaMeme.Core.Currencies;
using ShuraGames.BananaMeme.Core.Currencies.Enums;
using ShuraGames.BananaMeme.Core.Data;
using ShuraGames.BananaMeme.Core.GameState;
using ShuraGames.BananaMeme.Core.Wallet.Interface;

namespace ShuraGames.BananaMeme.Core.Wallet
{
    internal sealed class Wallet : IWallet
    {
        private MainGameState _mainGameState;
        private WalletData WalletData => _mainGameState.WalletData;

        public Currency GetCurrencyInfo(ECurrencyType currencyType)
        {
            if (WalletData.Currencies.TryGetValue(currencyType, out var currency))
            {
                return new Currency(currencyType, currency);
            }
            else
            {
                WalletData.Currencies.Add(currencyType, 0);

                return new Currency(currencyType, 0);
            }
        }

        public bool Take(in Currency currency)
        {
            var currencyInWallet = GetCurrencyInfo(currency.CurrencyType);

            if (currencyInWallet.Count >= currency.Count)
            {
                WalletData.Currencies[currency.CurrencyType] -= currency.Count;
                return true;
            }

            return false;
        }

        public void Give(in Currency currency)
        {
            if (WalletData.Currencies.ContainsKey(currency.CurrencyType))
            {
                WalletData.Currencies[currency.CurrencyType] = currency.Count;
            }
        }
    }
}