namespace engbo_backend.Models;

public class Aktivitet
{
    public int AktivitetId { get; set; }
    public int AktivitetsKategoriId { get; set; }
    public AktivitetsKategori? AktivitetsKategori { get; set; }
    public int HoldId { get; set; }
    //public Hold? Hold { get; set; }
    public string? Modstander { get; set; }
    public DateOnly Dato { get; set; }
    public TimeOnly Tid { get; set; }
    public int Varighed { get; set; }
    public int BaneTypeId { get; set; }
    //public BaneType? BaneType { get; set; }
    public string Bane { get; set; } = string.Empty;
    public string Adresse { get; set; } = string.Empty;
    public int UserId { get; set; }
    //public User? User { get; set; }
    public AktivitetStatus Status { get; set; } 
}

public enum AktivitetStatus
{
    Aktiv, 
    Igang,
    Afsluttet, 
    Aflyst
}