using System;

namespace Heroes.Icons.Models
{
    [Flags]
    public enum MVPAwardColor
    {
        Blue = 0,
        Red = 1 << 0,
        Gold = 1 << 1,
    }
}
