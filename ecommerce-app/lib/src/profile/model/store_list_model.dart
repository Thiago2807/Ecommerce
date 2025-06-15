class StoreListModel {
  StoreListModel({
    required this.document,
    required this.id,
    required this.name,
  });

  final String id;
  final String name;
  final String document;

  factory StoreListModel.fromJson(Map<String, dynamic> json) => StoreListModel(
        id: json["id"] as String,
        document: json["document"] as String,
        name: json["name"] as String,
      );
}
