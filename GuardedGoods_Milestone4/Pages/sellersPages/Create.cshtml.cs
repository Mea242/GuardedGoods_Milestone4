using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GuardedGoods_Milestone4.Model;

namespace GuardedGoods_Milestone4.Pages.sellersPages;

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
    public sellers Sellers { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        if (await _context.sellers.AnyAsync(s => s.seller_ID == Sellers.seller_ID))
        {
            ModelState.AddModelError("Sellers.seller_ID", "This seller ID already exists.");
            return Page();
        }

        _context.sellers.Add(Sellers);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
