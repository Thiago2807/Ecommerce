import 'package:flutter/material.dart';
import 'package:get_it/get_it.dart';
import 'package:marketplace/shared/model/response_request_model.dart';
import 'package:marketplace/shared/store/app_store.dart';
import 'package:marketplace/shared/widgets/snackbar_custom.dart';
import 'package:marketplace/src/profile/model/profile_model.dart';
import 'package:marketplace/src/profile/model/store_list_model.dart';
import 'package:marketplace/utils/http_utils.dart';
import 'package:provider/provider.dart';

class ProfileHandler {
  static Future<ProfileModel> getUserData(BuildContext context) async {
    late final AppStore store = GetIt.I.get<AppStore>();
    final client = await HttpUtils.instance();

    client.options.headers = {"Authorization": "Bearer ${store.token}"};

    final responseRequest = await client.get("/user/${store.idUser}");

    final responseFormat = ResponseRequestModel.toJson(responseRequest.data);

    if (context.mounted) {
      if (responseRequest.statusCode != 200 ||
          (responseFormat.error ?? false)) {
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

  static Future<StoreListModel?> getStoreList() async {
    late final AppStore store = GetIt.I.get<AppStore>();
    final client = await HttpUtils.instance();

    final responseRequest = await client.get("/store");

    if (responseRequest.statusCode == 404) return null;

    final responseFormat = ResponseRequestModel.toJson(responseRequest.data);

    final response = StoreListModel.fromJson(responseFormat.data);

    return response;
  }
}
