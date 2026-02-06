using System;
using System.Collections.Generic;

namespace Arac_Kiralama.API.Models;

public partial class Arac
{
    public string Plaka { get; set; } = null!;

    public string Marka { get; set; } = null!;

    public string ModelAdi { get; set; } = null!;

    public string ModelYili { get; set; } = null!;

    public string Renk { get; set; } = null!;

    public string Km { get; set; } = null!;

    public string Yakit { get; set; } = null!;

    public string Vites { get; set; } = null!;

    public int KiraUcreti { get; set; }

    public string Resim { get; set; } = null!;

    public string Durumu { get; set; } = null!;

    public string Tarih { get; set; } = null!;
}
