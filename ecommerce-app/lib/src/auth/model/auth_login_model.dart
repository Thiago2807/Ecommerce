class AuthLoginModel {
  AuthLoginModel({
    required this.expiration,
    required this.token,
  });

  String token;
  DateTime expiration;

  factory AuthLoginModel.fromJson(Map<String, dynamic> json) => AuthLoginModel(
        expiration: (DateTime.tryParse(json["expiration"]) as DateTime).toLocal(),
        token: json["token"] as String,
      );
}
