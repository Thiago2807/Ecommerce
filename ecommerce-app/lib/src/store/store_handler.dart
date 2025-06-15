import 'dart:convert';

import 'package:dio/dio.dart';
import 'package:flutter/material.dart';
import 'package:marketplace/core/colors.dart';
import 'package:marketplace/core/routes.dart';
import 'package:marketplace/shared/model/response_request_model.dart';
import 'package:marketplace/shared/widgets/snackbar_custom.dart';
import 'package:marketplace/src/auth/auth_view.dart';
import 'package:marketplace/src/store/model/address_model.dart';
import 'package:marketplace/src/store/model/store_model.dart';
import 'package:marketplace/src/store/store/store_details/store_details.dart';
import 'package:marketplace/utils/http_utils.dart';
import 'package:provider/provider.dart';

class StoreHandler {
  static final Dio dioCustom = Dio();

  static Future getAddress(
      BuildContext context, TextEditingController cepController) async {
    final state = Provider.of<StoreDetails>(context, listen: false);

    final resRequest = await dioCustom
        .get("https://viacep.com.br/ws/${cepController.text}/json/");

    if (resRequest.statusCode != 200) {
      AppSnackBar.show(
        content: "Não foi possível obter o endereço",
        color: Colors.redAccent,
        textColor: Colors.white,
      );
      return null;
    }

    final Map<String, dynamic> resMap = resRequest.data as Map<String, dynamic>;

    if (resMap.containsKey("erro")) {
      state.initialize();
      state.addCep(cepController.text);

      AppSnackBar.show(
        content: "Endereço não encontrado.",
        color: Colors.redAccent,
        textColor: Colors.white,
      );

      return;
    }

    final resData = AddressModel.fromJson(
      resMap,
    );

    state.addFields(resData);
  }

  static Future insertStore(
    BuildContext context, {
    required TextEditingController nameController,
    required TextEditingController documentController,
  }) async {
    final state = Provider.of<StoreDetails>(context, listen: false);
    final dio = await HttpUtils.instance();

    final modelPost = StoreModel(
      name: nameController.text,
      document: documentController.text,
      address: state.getAddressModel(),
    );

    final result = await dio.post(
      "/store/add",
      data: modelPost.toJson(),
    );

    final resModel = ResponseRequestModel.toJson(result.data);

    if ((result.statusCode ?? 500) > 300) {
      AppSnackBar.show(
        content: resModel.message ?? "Não foi possível inserir o item",
        color: Colors.redAccent,
        textColor: Colors.white,
      );
      return;
    }

    if (context.mounted) {
      AppSnackBar.show(
        content: resModel.message ?? "Cadastrado com sucesso!",
        color: Colors.greenAccent,
        textColor: Colors.white,
      );
      Navigator.pushNamedAndRemoveUntil(
        context,
        RoutesName.profile,
        (route) => false,
      );
    }
  }
}
