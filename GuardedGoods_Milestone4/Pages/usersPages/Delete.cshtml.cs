using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GuardedGoods_Milestone4.Model;

namespace GuardedGoods_Milestone4.Pages.usersPages;

public class DeleteModel : PageModel
{
    private readonly GuardedGoods_Milestone4Context _context;

    public DeleteModel(GuardedGoods_Milestone4Context context)
    {
        _context = context;
    }

    [BindProperty]
    public users Users { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(string? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var users = await _context.users.FirstOrDefaultAsync(m => m.userID == id);
        if (users is null)
        {
            return NotFound();
        }
        else
        {
            Users = users;
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (Users is null || string.IsNullOrWhiteSpace(Users.userID))
        {
            return NotFound();
        }

        var users = await _context.users.FindAsync(Users.userID);
        if (users != null)
        {
            Users = users;
            _context.users.Remove(Users);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
