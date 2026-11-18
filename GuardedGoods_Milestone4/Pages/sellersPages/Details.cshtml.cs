using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GuardedGoods_Milestone4.Model;

namespace GuardedGoods_Milestone4.Pages.sellersPages;

public class DetailsModel : PageModel
{
    private readonly GuardedGoods_Milestone4Context _context;
    public DetailsModel(GuardedGoods_Milestone4Context context)
    {
        _context = context;
    }

    public sellers Sellers { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(string? seller_id)
    {
        if (seller_id is null)
        {
            return NotFound();
        }

        var sellers = await _context.sellers.FirstOrDefaultAsync(m => m.seller_ID == seller_id);
        if (sellers is null)
        {
            return NotFound();
        }
        else
        {
            Sellers = sellers;
        }

        return Page();
    }
}
