using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository;

public class GuestRepository : IGuestRepository
{
    private readonly RepositoryContext _context;

    public GuestRepository(RepositoryContext context)
    {
        _context = context;
    }

    public async Task<Guest?> GetGuestByUniqueIdentifiersAsync(string email, string phoneNumber, string pin)
    {
        return await _context.Guests
            .FirstOrDefaultAsync(g =>
                g.Email == email || g.PhoneNumber == phoneNumber || g.PIN == pin);
    }

    public async Task AddGuestAsync(Guest guest)
    {
        _context.Guests.Add(guest);
        await _context.SaveChangesAsync();
    }
}