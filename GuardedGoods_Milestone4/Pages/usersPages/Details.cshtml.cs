using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GuardedGoods_Milestone4.Model;

namespace GuardedGoods_Milestone4.Pages.usersPages;

public class DetailsModel : PageModel
{
    private readonly GuardedGoods_Milestone4Context _context;
    public DetailsModel(GuardedGoods_Milestone4Context context)
    {
        _context = context;
    }

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
        else
        {
            Users = users;
        }

        return Page();
    }
}
