namespace ecommerce_core.Dtos.pct;

public class CategoryDTO
{
    public string? Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}

public class CategoryValid : AbstractValidator<CategoryDTO>
{
    public CategoryValid()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Nome não pode ser vazio")
            .NotNull().WithMessage("O nome é obrigatório.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("A descrição não pode ser vazio")
            .NotNull().WithMessage("A descrição é obrigatório.");
    }
}