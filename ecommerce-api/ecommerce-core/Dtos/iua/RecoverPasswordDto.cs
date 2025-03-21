namespace ecommerce_core.Dtos.Auth;

public sealed class RecoverPasswordDto
{
    public string Email { get; set; } = string.Empty;
}

public sealed class RecoverPasswordValidation : AbstractValidator<RecoverPasswordDto>
{
    public RecoverPasswordValidation()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("E-mail não pode ser vazio")
            .NotNull().WithMessage("O E-mail é obrigatório.");
    }
}
