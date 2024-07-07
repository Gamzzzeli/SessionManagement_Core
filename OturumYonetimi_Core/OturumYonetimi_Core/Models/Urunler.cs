using System;
using System.Collections.Generic;

namespace OturumYonetimi_Core.Models;

public partial class Urunler
{
    public int Id { get; set; }

    public string? UrunAd { get; set; }

    public int? Adet { get; set; }

    public decimal? Fiyat { get; set; }
}
