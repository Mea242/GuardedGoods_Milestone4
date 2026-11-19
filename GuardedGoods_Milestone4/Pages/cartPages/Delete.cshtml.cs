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

    public async Task<IActionResult> OnGetAsync(string? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var cart = await _context.cart.FirstOrDefaultAsync(m => m.cart_ID == id);
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

    public async Task<IActionResult> OnPostAsync()
    {
        if (Cart is null || string.IsNullOrWhiteSpace(Cart.cart_ID))
        {
            return NotFound();
        }

        var cart = await _context.cart.FindAsync(Cart.cart_ID);
        if (cart != null)
        {
            cart.is_active = false;
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
