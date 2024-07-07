using System;
using System.Collections.Generic;

namespace OturumYonetimi_Core.Models;

public partial class Kullanicilar
{
    public int Id { get; set; }

    public string? KullaniciAdi { get; set; }

    public string? Sifre { get; set; }
}
