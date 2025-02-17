namespace ecommerce_core.Dtos.Auth;

public sealed class AuthInsertDto
{
    public string Name { get; set; } = string.Empty;
    public string NickName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

public sealed class AuthInsertValidation : AbstractValidator<AuthInsertDto>
{
    public AuthInsertValidation()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Nome não pode ser vazio")
            .NotNull().WithMessage("O nome é obrigatório.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("E-mail não pode ser vazio")
            .NotNull().WithMessage("O E-mail é obrigatório.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Senha não pode ser vazio")
            .NotNull().WithMessage("A senha é obrigatório.");
    }
}