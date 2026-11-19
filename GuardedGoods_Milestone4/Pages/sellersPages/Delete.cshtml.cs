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

    public async Task<IActionResult> OnGetAsync(string? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var sellers = await _context.sellers.FirstOrDefaultAsync(m => m.seller_ID == id);
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

    public async Task<IActionResult> OnPostAsync()
    {
        if (Sellers is null || string.IsNullOrWhiteSpace(Sellers.seller_ID))
        {
            return NotFound();
        }

        var sellers = await _context.sellers.FindAsync(Sellers.seller_ID);
        if (sellers is null)
        {
            return NotFound();
        }

        sellers.is_active = false;
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
