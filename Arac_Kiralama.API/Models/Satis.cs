using System;
using System.Collections.Generic;

namespace Arac_Kiralama.API.Models;

public partial class Satis
{
    public int Id { get; set; }

    public string Tc { get; set; } = null!;

    public string Adsoyad { get; set; } = null!;

    public string Telefon { get; set; } = null!;

    public string Ehliyetno { get; set; } = null!;

    public string ETarih { get; set; } = null!;

    public string Plaka { get; set; } = null!;

    public string Marka { get; set; } = null!;

    public string Modeladi { get; set; } = null!;

    public string Modelyili { get; set; } = null!;

    public string Renk { get; set; } = null!;

    public string Kirasekli { get; set; } = null!;

    public int Kiraucreti { get; set; }

    public int Gun { get; set; }

    public int Tutar { get; set; }

    public string Ctarih { get; set; } = null!;

    public string Dtarih { get; set; } = null!;
}
