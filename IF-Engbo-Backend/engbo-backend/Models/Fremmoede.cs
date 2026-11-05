namespace engbo_backend.Models;

public class Fremmoede
{
    public int FremmoedeId { get; set; }
    public int AktivitetId { get; set; }
    //public Aktivitet? Aktivitet { get; set; }
    public int UserId { get; set; }
    //public User? User { get; set; }
    public FremmoedeStatus Status { get; set; }
}

public enum FremmoedeStatus 
{
    IkkeRegistreret,
    Fremmoedt,
    Fravaerende
}