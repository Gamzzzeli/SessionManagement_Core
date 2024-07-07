using System;
using System.Collections.Generic;

namespace OturumYonetimi_Core.Models;

public partial class Subeler
{
    public int Id { get; set; }

    public string? SubeAdi { get; set; }

    public string? Adres { get; set; }

    public int? CalisanSayisi { get; set; }
}
