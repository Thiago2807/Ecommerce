import 'package:flutter/material.dart';
import 'package:marketplace/shared/model/response_request_model.dart';
import 'package:marketplace/shared/store/app_store.dart';
import 'package:marketplace/shared/widgets/snackbar_custom.dart';
import 'package:marketplace/src/profile/model/profile_model.dart';
import 'package:marketplace/utils/http_utils.dart';
import 'package:provider/provider.dart';

class ProfileHandler {
  static Future<ProfileModel> getUserData(BuildContext context) async {
    final AppStore store = Provider.of<AppStore>(context, listen: false);
    final client = await HttpUtils.instance();

    client.options.headers = {
      "Authorization": "Bearer ${store.token}"
    };

    final responseRequest = await client.get("/user/${store.idUser}");

    final responseFormat = ResponseRequestModel.toJson(responseRequest.data);

    if (context.mounted) {
      if (responseRequest.statusCode != 200 || (responseFormat.error ?? false)) {
        snackBarCustom(
          context,
          content: responseFormat.message ??
              "Não foi possível obter os dados do usuário",
          color: Colors.redAccent,
          textColor: Colors.white,
        );
      }
    }

    final response = ProfileModel.fromJson(responseFormat.data);

    return response;
  }
}
