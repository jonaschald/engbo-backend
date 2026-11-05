namespace engbo_backend.Models;

public class Tilmelding
{
    public int TilmeldingId { get; set; }
    public int AktivitetId { get; set; }
    public Aktivitet? Aktivitet { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
    public TilmeldingsStatus Status { get; set; }
    public string? Kommentar { get; set; }
}

public enum TilmeldingsStatus
{
    IkkeBesvaret,
    Kommer,
    KommerIkke
}