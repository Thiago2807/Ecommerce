class ProfileModel {
  ProfileModel({
    required this.ative,
    required this.blocked,
    required this.dateBirth,
    required this.email,
    required this.name,
  });

  String name;
  String email;
  bool blocked;
  bool ative;
  DateTime? dateBirth;

  factory ProfileModel.fromJson(Map<String, dynamic> json) => ProfileModel(
        ative: bool.tryParse(json["ative"].toString()) ?? false,
        blocked: bool.tryParse(json["blocked"].toString()) ?? false,
        dateBirth: DateTime.tryParse(json["dateBirth"]),
        email: json["email"] as String,
        name: json["name"] as String,
      );
}
