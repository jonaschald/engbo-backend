namespace engbo_backend.Models;

public class KampResultat
{
    public int KampResultatId { get; set; }
    public int AktivitetId { get; set; }
    public Aktivitet? Aktivitet { get; set; }
    public int HjemmeholdMaal { get; set; }
    public int UdeholdMaal { get; set; }
    public KampResultatStatus Status { get; set; }
}

public enum KampResultatStatus
{
    IkkeRegistreret,
    Registreret
}