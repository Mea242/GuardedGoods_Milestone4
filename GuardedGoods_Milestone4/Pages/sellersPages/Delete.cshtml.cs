using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GuardedGoods_Milestone4.Model;

namespace GuardedGoods_Milestone4.Pages.sellersPages;

public class DeleteModel : PageModel
{
    private readonly GuardedGoods_Milestone4Context _context;

    public DeleteModel(GuardedGoods_Milestone4Context context)
    {
        _context = context;
    }

    [BindProperty]
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

    public async Task<IActionResult> OnPostAsync(string? seller_id)
    {
        if (seller_id is null)
        {
            return NotFound();
        }

        var sellers = await _context.sellers.FindAsync(seller_id);
        if (sellers != null)
        {
            Sellers = sellers;
            _context.sellers.Remove(Sellers);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
