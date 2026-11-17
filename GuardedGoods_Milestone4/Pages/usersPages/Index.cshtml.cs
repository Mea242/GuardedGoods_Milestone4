using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GuardedGoods_Milestone4.Model;

namespace GuardedGoods_Milestone4.Pages.usersPages;

public class IndexModel : PageModel
{
    private readonly GuardedGoods_Milestone4Context _context;

    public IndexModel(GuardedGoods_Milestone4Context context)
    {
        _context = context;
    }

    public IList<users> Users { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Users = await _context.users.ToListAsync();
    }
}
