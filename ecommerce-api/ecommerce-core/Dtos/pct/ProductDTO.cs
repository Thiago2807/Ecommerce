namespace ecommerce_core.Dtos.pct;

public class ProductDTO
{
    public string? Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Sku { get; set; } = string.Empty;
    public string StoreId { get; set; } = string.Empty;
}

public class ProductValid : AbstractValidator<ProductDTO>
{
    public ProductValid()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("O nome não pode ser vazio")
            .NotNull().WithMessage("O nome é obrigatório.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("A descrição não pode ser vazio")
            .NotNull().WithMessage("A descrição é obrigatório.");

        RuleFor(x => x.Price)
            .NotEmpty().WithMessage("O preço não pode ser vazio")
            .NotNull().WithMessage("O preço é obrigatório.");

        RuleFor(x => x.Sku)
            .NotEmpty().WithMessage("O SKU não pode ser vazio")
            .NotNull().WithMessage("O SKU é obrigatório.");

        RuleFor(x => x.StoreId)
            .NotEmpty().WithMessage("O código da loja não pode ser vazio")
            .NotNull().WithMessage("O código da loja é obrigatório.");
    }
}