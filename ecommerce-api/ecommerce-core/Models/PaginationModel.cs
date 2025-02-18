namespace ecommerce_core.Models;

public class PaginationModel
{
    public int Page { get; set; }
    public int PageSize { get; set; }
}

public class PaginationInputModel
{
    public int Page { get; set; }
    public int PageSize { get; set; }
    public long QtdTotal { get; set; }
    public object? Data { get; set; }
}

public class PaginationModelValidation : AbstractValidator<PaginationModel>
{
    public PaginationModelValidation()
    {
        RuleFor(x => x.Page)
            .NotEmpty().WithMessage("O parâmetro page não pode vazio.")
            .NotNull().WithMessage("O parâmetro page não pode nulo.")
            .Must(IsNotZero).WithMessage("O parâmetro page não pode ser menor ou igual a zero.");

        RuleFor(x => x.PageSize)
            .NotEmpty().WithMessage("O parâmetro pageSize não pode vazio.")
            .NotNull().WithMessage("O parâmetro pageSize não pode nulo.")
            .Must(IsNotZero).WithMessage("O parâmetro pageSize não pode ser menor ou igual a zero.");
    }

    private bool IsNotZero(int input) => input >= 0;
}