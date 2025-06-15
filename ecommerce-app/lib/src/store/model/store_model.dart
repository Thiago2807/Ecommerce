import 'package:marketplace/src/store/model/address_model.dart';

class StoreModel {
  final String name;
  final String document;
  final AddressModel address;

  StoreModel({
    required this.name,
    required this.document,
    required this.address,
  });

  factory StoreModel.fromJson(Map<String, dynamic> json) => StoreModel(
        name: json['name'] as String,
        document: json['document'] as String,
        address: AddressModel.fromJson(json['address'] as Map<String, dynamic>),
      );

  Map<String, dynamic> toJson() => {
        'name': name,
        'document': document,
        'address': address.toJson(),
      };
}