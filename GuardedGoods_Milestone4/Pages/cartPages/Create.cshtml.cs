using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GuardedGoods_Milestone4.Model;

namespace GuardedGoods_Milestone4.Pages.cartPages;

public class CreateModel : PageModel
{
    private readonly GuardedGoods_Milestone4Context _context;

    public CreateModel(GuardedGoods_Milestone4Context context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public cart Cart { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.cart.Add(Cart);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
