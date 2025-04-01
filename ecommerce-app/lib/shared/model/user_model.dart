class UserModel {
  UserModel({
    required this.id,
    required this.email,
  });

  String id;
  String email;

  factory UserModel.fromMap(Map<String, dynamic> json) => UserModel(
        id: json["id"],
        email: json["email"],
      );

  factory UserModel.fromEmpty() => UserModel(
        id: "",
        email: "",
      );

  Map<String, dynamic> toJson() => {
        "id": id,
        "email": email,
      };
}
