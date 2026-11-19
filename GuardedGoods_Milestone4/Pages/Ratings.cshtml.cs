using GuardedGoods_Milestone4.Model;
using GuardedGoods_Milestone4.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuardedGoods_Milestone4.Pages;

public class RatingsModel(MongoDBServices mongoDBServices) : PageModel
{
    public IReadOnlyList<Ratings> Ratings { get; private set; } = [];

    public async Task OnGetAsync(CancellationToken cancellationToken)
    {
        Ratings = await mongoDBServices.GetRatingsAsync(cancellationToken);
    }
}
