using ShuraGames.BananaMeme.Core.Currencies.Enums;

namespace ShuraGames.BananaMeme.Core.Currencies
{
    public readonly struct Currency
    {
        public readonly ECurrencyType CurrencyType;
        public readonly ulong Count;
        
        public Currency(ECurrencyType currencyType, ulong count)
        {
            CurrencyType = currencyType;
            Count = count;
        }
    }
}