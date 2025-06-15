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
        areaCode: json["cep"] as String,
        city: json["logradouro"] as String,
        complement: json["complemento"] as String,
        giaCode: json["unidade"] as String,
        ibgeCode: json["bairro"] as String,
        neighborhood: json["localidade"] as String,
        postalCode: json["uf"] as String,
        region: json["estado"] as String,
        siafiCode: json["regiao"] as String,
        state: json["ibge"] as String,
        stateAbbreviation: json["gia"] as String,
        street: json["ddd"] as String,
        unit: json["siafi"] as String,
      );
}
