namespace ecommerce_core.Dtos.loj;

public sealed class StoreRegisterDTO
{
    public string Name { get; set; } = string.Empty;
    public string Document { get; set; } = string.Empty;
    public List<StoreContactRegisterDTO> Contacts { get; set; } = [];

    public StoreAddressRegisterDTO? Address { get; set; }
}

public sealed class StoreContactRegisterDTO
{
    public string Type { get; set; } = string.Empty;
    public string Contact { get; set; } = string.Empty;
}

public sealed class StoreAddressRegisterDTO
{
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
}

public sealed class StoreRegisterValid : AbstractValidator<StoreRegisterDTO>
{
    public StoreRegisterValid()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Nome não pode ser vazio")
            .NotNull().WithMessage("O nome é obrigatório.");

        RuleFor(x => x.Document)
            .NotEmpty().WithMessage("Documento não pode ser vazio")
            .NotNull().WithMessage("O Documento é obrigatório.")
            .Must(ValidationHelp.IsValidDocument).WithMessage("Documento inválido, verifique e tente novamente");

        RuleFor(x => x.Address)
            .NotEmpty().WithMessage("Endereço não pode ser vazio")
            .NotNull().WithMessage("O endereço é obrigatório.");
    }
}

public sealed class StoreRegisterContactsValid : AbstractValidator<StoreContactRegisterDTO>
{
    public StoreRegisterContactsValid()
    {
        RuleFor(x => x.Type)
            .NotEmpty().WithMessage("Tipo não pode ser vazio")
            .NotNull().WithMessage("O tipo é obrigatório.");

        RuleFor(x => x.Contact)
            .NotEmpty().WithMessage("Contato não pode ser vazio")
            .NotNull().WithMessage("O contato é obrigatório.");
    }
}