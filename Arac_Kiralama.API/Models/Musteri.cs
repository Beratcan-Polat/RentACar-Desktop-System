using System;
using System.Collections.Generic;

namespace Arac_Kiralama.API.Models;

public partial class Musteri
{
    public string Tc { get; set; } = null!;

    public string AdSoyad { get; set; } = null!;

    public string Telefon { get; set; } = null!;

    public string Adres { get; set; } = null!;

    public string Email { get; set; } = null!;
}
