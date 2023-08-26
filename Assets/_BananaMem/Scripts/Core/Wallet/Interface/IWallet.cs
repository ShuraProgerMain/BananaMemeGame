using ShuraGames.BananaMeme.Core.Currencies;
using ShuraGames.BananaMeme.Core.Currencies.Enums;

namespace ShuraGames.BananaMeme.Core.Wallet.Interface
{
    internal interface IWallet
    {
        public Currency GetCurrencyInfo(ECurrencyType currencyType);
        public bool Take(in Currency currency);
        public void Give(in Currency currency);
    }
}