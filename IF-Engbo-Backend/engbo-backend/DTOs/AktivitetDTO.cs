using engbo_backend.Models;

namespace engbo_backend.DTOs;

public class AktivitetDTO
{
    public int AktivitetId { get; set; }
    public string AktivitetsType { get; set; } = string.Empty;
    public string HoldNavn { get; set; } = string.Empty;
    public string? Modstander { get; set; }
    public DateOnly Dato { get; set; }
    public TimeOnly Tid { get; set; }
    public int Varighed { get; set; }
    public string BaneType { get; set; } = string.Empty;
    public string Bane { get; set; } = string.Empty;
    public string Adresse { get; set; } = string.Empty;
    public string TraenerNavn { get; set; } = string.Empty;
    public AktivitetStatus Status { get; set; }
}