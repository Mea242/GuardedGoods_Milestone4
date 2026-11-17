using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GuardedGoods_Milestone4.Model;

namespace GuardedGoods_Milestone4.Pages.usersPages;

public class EditModel : PageModel
{
    private readonly GuardedGoods_Milestone4Context _context;

    public EditModel(GuardedGoods_Milestone4Context context)
    {
        _context = context;
    }

    [BindProperty]
    public users Users { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(string? userid)
    {
        if (userid is null)
        {
            return NotFound();
        }

        var users = await _context.users.FirstOrDefaultAsync(m => m.userID == userid);
        if (users is null)
        {
            return NotFound();
        }
        Users = users;
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Attach(Users).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!usersExists(Users.userID))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index");
    }

    private bool usersExists(string userid)
    {
        return _context.users.Any(e => e.userID == userid);
    }
}
