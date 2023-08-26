using System.Collections.Generic;
using ShuraGames.BananaMeme.Core.Currencies.Enums;

namespace ShuraGames.BananaMeme.Core.Data
{
    internal sealed class WalletData
    {
        public Dictionary<ECurrencyType, ulong> Currencies = new(); // Может можно в ньютонсофте сделать это место ридонли и инитить через конструктор? 
    }
}