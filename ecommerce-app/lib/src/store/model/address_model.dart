class AddressModel {
  AddressModel({
    required this.areaCode,
    required this.city,
    required this.complement,
    required this.giaCode,
    required this.ibgeCode,
    required this.neighborhood,
    required this.postalCode,
    required this.region,
    required this.siafiCode,
    required this.state,
    required this.stateAbbreviation,
    required this.street,
    required this.unit,
  });

  String postalCode;
  String street;
  String complement;
  String unit;
  String neighborhood;
  String city;
  String stateAbbreviation;
  String state;
  String region;
  String ibgeCode;
  String giaCode;
  String areaCode;
  String siafiCode;

  factory AddressModel.fromJson(Map<String, dynamic> json) => AddressModel(
        postalCode: json["cep"] as String, // Código postal
        street: json["logradouro"] as String, // Rua
        complement: json["complemento"] as String, // Complemento
        unit: json["unidade"] as String, // Unidade
        neighborhood: json["bairro"] as String, // Bairro
        city: json["localidade"] as String, // Cidade
        stateAbbreviation: json["uf"] as String, // Sigla do Estado
        state: json["estado"] as String, // Nome do Estado
        region: json["regiao"] as String, // Região
        ibgeCode: json["ibge"] as String, // Código IBGE
        giaCode: json["gia"] as String, // Código GIA
        areaCode: json["ddd"] as String, // DDD
        siafiCode: json["siafi"] as String, // Código SIAFI
      );

  Map<String, dynamic> toJson() => {
        'postalCode': postalCode,
        'street': street,
        'complement': complement,
        'unit': unit,
        'neighborhood': neighborhood,
        'city': city,
        'stateAbbreviation': stateAbbreviation,
        'state': state,
        'region': region,
        'ibgeCode': ibgeCode,
        'giaCode': giaCode,
        'areaCode': areaCode,
        'siafiCode': siafiCode,
      };
}
