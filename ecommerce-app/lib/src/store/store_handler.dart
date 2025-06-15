import 'dart:convert';

import 'package:dio/dio.dart';
import 'package:flutter/material.dart';
import 'package:marketplace/shared/widgets/snackbar_custom.dart';
import 'package:marketplace/src/store/model/address_model.dart';

class StoreHandler {
  static final Dio dioCustom = Dio();

  static Future<AddressModel?> getAddress(
      BuildContext context, TextEditingController cepController) async {
    final resRequest = await dioCustom
        .get("https://viacep.com.br/ws/${cepController.text}/json/");

    if (resRequest.statusCode != 200) {
      snackBarCustom(
        context,
        content: "Não foi possível obter o endereço",
        color: Colors.redAccent,
        textColor: Colors.white,
      );
      return null;
    }

    final resData = AddressModel.fromJson(
      jsonDecode(resRequest.data),
    );

    return resData;
  }
}
