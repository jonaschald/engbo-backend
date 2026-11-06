using engbo_backend.Data;
using engbo_backend.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace engbo_backend.Controllers;

[ApiController]
[Route("api/[controller]")]

public class AktiviteterController : Controller
{
    private readonly EngboDbContext _context;
    
    public AktiviteterController(EngboDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<AktivitetDTO>>> GetAktiviteter()
    {
        var aktiviteter = await _context.Aktiviteter
            .Include(a => a.AktivitetsKategori)
            .Include(a => a.Hold)
            .Include(a => a.BaneType)
            .Include(a => a.User)
            .Select(a => new AktivitetDTO
            {
                AktivitetId =  a.AktivitetId,
                AktivitetsType = a.AktivitetsKategori!.AktivitetsType,
                HoldNavn = a.Hold!.HoldNavn, 
                Modstander =  a.Modstander,
                Dato = a.Dato,
                Tid = a.Tid,
                Varighed = a.Varighed,
                BaneType = a.BaneType!.Banetype,
                Bane = a.Bane,
                Adresse = a.Adresse,
                TraenerNavn = a.User!.Name,
                Status = a.Status
            }).ToListAsync();
        return Ok(aktiviteter);
    }
}