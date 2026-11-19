using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GuardedGoods_Milestone4.Model;

namespace GuardedGoods_Milestone4.Pages.cartPages;

public class DeleteModel : PageModel
{
    private readonly GuardedGoods_Milestone4Context _context;

    public DeleteModel(GuardedGoods_Milestone4Context context)
    {
        _context = context;
    }

    [BindProperty]
    public cart Cart { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(string? cart_id)
    {
        if (cart_id is null)
        {
            return NotFound();
        }

        var cart = await _context.cart.FirstOrDefaultAsync(m => m.cart_ID == cart_id);
        if (cart is null)
        {
            return NotFound();
        }
        else
        {
            Cart = cart;
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(string? cart_id)
    {
        if (cart_id is null)
        {
            return NotFound();
        }

        var cart = await _context.cart.FindAsync(cart_id);
        if (cart != null)
        {
            Cart = cart;
            _context.cart.Remove(Cart);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
