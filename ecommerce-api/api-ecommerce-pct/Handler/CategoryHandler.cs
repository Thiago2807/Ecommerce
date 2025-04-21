using api_ecommerce_pct.Interfaces.Handler;
using api_ecommerce_pct.Interfaces.Repository;

namespace api_ecommerce_pct.Handler;

public class CategoryHandler (ICategoryRepository categoryRepository)
    : ICategoryHandler
{
}
