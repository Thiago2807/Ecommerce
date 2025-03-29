namespace ecommerce_core.Dtos.loj;

public sealed class StoreUpdateDTO
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Document { get; set; } = string.Empty;
    public DateTime UpdatedIn { get; set; } = DateTime.UtcNow;
}

public sealed class StoreAddUpdateContactDTO
{
    public string? Id { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Contact { get; set; } = string.Empty;
    public string StoreId { get; set; } = string.Empty;
    public DateTime UpdatedIn { get; set; } = DateTime.UtcNow;
}

public sealed class StoreUpdateAddressDTO
{
    public string Id { get; set; } = string.Empty;
    // Código Postal (CEP) do endereço.
    public string PostalCode { get; set; } = string.Empty;

    // Nome da rua.
    public string Street { get; set; } = string.Empty;

    // Complemento do endereço (por exemplo, apartamento, bloco, etc.).
    public string Complement { get; set; } = string.Empty;

    // Número ou unidade do endereço.
    public string Unit { get; set; } = string.Empty;

    // Bairro.
    public string Neighborhood { get; set; } = string.Empty;

    // Cidade.
    public string City { get; set; } = string.Empty;

    // Sigla do estado (por exemplo, SP, RJ).
    public string StateAbbreviation { get; set; } = string.Empty;

    // Nome do estado.
    public string State { get; set; } = string.Empty;

    // Região do país (por exemplo, Sudeste, Nordeste).
    public string Region { get; set; } = string.Empty;

    // Código do IBGE, que identifica o município.
    public string IbgeCode { get; set; } = string.Empty;

    // Código GIA, utilizado para determinados processos fiscais (mais comum em SP).
    public string GiaCode { get; set; } = string.Empty;

    // Código de área telefônica (DDD).
    public string AreaCode { get; set; } = string.Empty;

    // Código SIAFI, utilizado para identificar municípios no sistema financeiro do governo.
    public string SiafiCode { get; set; } = string.Empty;
    public DateTime UpdatedIn { get; set; } = DateTime.UtcNow;
}

public sealed class StoreUpdateValid : AbstractValidator<StoreUpdateDTO>
{
    public StoreUpdateValid()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id não pode ser vazio")
            .NotNull().WithMessage("O id é obrigatório.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Nome não pode ser vazio")
            .NotNull().WithMessage("O nome é obrigatório.");

        RuleFor(x => x.Document)
            .NotEmpty().WithMessage("Documento não pode ser vazio")
            .NotNull().WithMessage("O Documento é obrigatório.")
            .Must(ValidationHelp.IsValidDocument).WithMessage("Documento inválido, verifique e tente novamente");
    }
}

public sealed class StoreContactUpdateValid : AbstractValidator<StoreAddUpdateContactDTO>
{
    public StoreContactUpdateValid()
    {
        RuleFor(x => x.Type)
            .NotEmpty().WithMessage("Tipo não pode ser vazio")
            .NotNull().WithMessage("O tipo é obrigatório.");

        RuleFor(x => x.Contact)
            .NotEmpty().WithMessage("Contato não pode ser vazio")
            .NotNull().WithMessage("O contato é obrigatório.");

        RuleFor(x => x.StoreId)
            .NotEmpty().WithMessage("StoreId não pode ser vazio")
            .NotNull().WithMessage("O storeId é obrigatório.");
    }
}