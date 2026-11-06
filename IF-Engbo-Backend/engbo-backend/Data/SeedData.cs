using engbo_backend.Models;

namespace engbo_backend.Data;

public class SeedData
{
    public static void Initialize(EngboDbContext context)
    {
        // opret hold
        if (!context.Hold.Any())
        {
            Hold holdU13 = new Hold
            {
                HoldNavn = "U13"
            };
            context.Hold.Add(holdU13);
            Hold holdU17 = new Hold
            {
                HoldNavn = "U17"
            };
            context.Hold.Add(holdU17);
            Hold holdSenior = new Hold
            {
                HoldNavn = "Senior"
            };
            context.Hold.Add(holdSenior);
            context.SaveChanges();
        }
        
        // opret aktivitetskategorier
        if (!context.AktivitetsKategorier.Any())
        {
            AktivitetsKategori kamp = new AktivitetsKategori
            {
                AktivitetsType = "Kamp"
            };
            context.AktivitetsKategorier.Add(kamp);

            AktivitetsKategori træning = new AktivitetsKategori
            {
                AktivitetsType = "Træning"
            };
            context.AktivitetsKategorier.Add(træning);
            context.SaveChanges();
        }
        
        // opret banetyper
        if (!context.BaneTyper.Any())
        {
            BaneType hjemmebane = new BaneType
            {
                Banetype = "Hjemmebane"
            };
            context.BaneTyper.Add(hjemmebane);

            BaneType udebane = new BaneType
            {
                Banetype = "Udebane"
            };
            context.BaneTyper.Add(udebane);
            context.SaveChanges();
                
        }
        
        // opret en træner
        if (!context.Users.Any())
        {
            User Mette = new User
            {
                Name = "Mette Sørensen",
                Email = "mette@engbo.dk",
                PasswordHash = ""
            };
            context.Users.Add(Mette);
            context.SaveChanges();
        }
        
        // opret aktiviteter
        if (!context.Aktiviteter.Any())
        {
            // finder eksisterende data
            Hold holdU13 = context.Hold.First(h => h.HoldNavn == "U13");
            AktivitetsKategori kamp = context.AktivitetsKategorier.First(k => k.AktivitetsType == "Kamp");
            AktivitetsKategori træning = context.AktivitetsKategorier.First(t => t.AktivitetsType == "Træning");
            BaneType udebane  = context.BaneTyper.First(u => u.Banetype == "Udebane");
            BaneType hjemmebane  = context.BaneTyper.First(h => h.Banetype == "Hjemmebane");
            User mette = context.Users.First(u => u.Email == "mette@engbo.dk");
            
            // opret træning
            Aktivitet træning1 = new Aktivitet
            {
                AktivitetsKategoriId = træning.AktivitetsKategoriId,
                HoldId = holdU13.HoldId,
                Dato = new DateOnly(2026, 11, 22),
                Tid = new TimeOnly(19, 0),
                Varighed = 120,
                BaneTypeId = hjemmebane.BaneTypeId,
                Bane = "Engbo Kunstgræs",
                Adresse = "Holmevej 13, 6370 Engbo",
                UserId = mette.Id,
                Status = AktivitetStatus.Aktiv
            };
            context.Aktiviteter.Add(træning1);
            
            Aktivitet kamp1 = new Aktivitet
            {
                AktivitetsKategoriId = kamp.AktivitetsKategoriId,
                HoldId = holdU13.HoldId,
                Modstander = "FC Sønderborg",
                Dato = new DateOnly(2026, 11, 25),
                Tid = new TimeOnly(14, 0),
                Varighed = 90,
                BaneTypeId = hjemmebane.BaneTypeId,
                Bane = "Engbo Station",
                Adresse = "Holmevej 13, 6370 Engbo",
                UserId = mette.Id,
                Status = AktivitetStatus.Aktiv
            };
            context.Aktiviteter.Add(kamp1);
            context.SaveChanges();
        }
        
    } 
}