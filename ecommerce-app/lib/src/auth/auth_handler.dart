import 'package:flutter/material.dart';
import 'package:marketplace/core/const.dart';
import 'package:marketplace/core/endpoints.dart';
import 'package:marketplace/core/routes.dart';
import 'package:marketplace/shared/model/response_request_model.dart';
import 'package:marketplace/shared/store/app_store.dart';
import 'package:marketplace/shared/widgets/snackbar_custom.dart';
import 'package:marketplace/src/auth/model/auth_login_model.dart';
import 'package:marketplace/src/auth/store/auth_store.dart';
import 'package:marketplace/utils/http_utils.dart';
import 'package:marketplace/utils/preferences_utils.dart';
import 'package:provider/provider.dart';

class AuthHandler {
  static Future<void> loginUser(
    BuildContext context, {
    required TextEditingController email,
    required TextEditingController password,
  }) async {
    final dio = await HttpUtils.instance();

    final body = {
      "email": email.text.trim(),
      "password": password.text.trim(),
    };

    final response = await dio.post(
      Endpoints.loginEndpoint,
      data: body,
    );

    final responseModel = ResponseRequestModel.toJson(response.data);

    if (context.mounted) {
      if (response.statusCode != 200) {
        snackBarCustom(
          context,
          content: responseModel.message ?? "Não foi possível realizar o login",
          color: Colors.redAccent,
          textColor: Colors.white,
        );

        return;
      }

      // Guardar Dados do usuario
      await PreferencesUtils.insertAsync(
        key: credentialsKey,
        value: responseModel.data.toString(),
      );

      if (context.mounted) {
        Navigator.pushNamedAndRemoveUntil(
          context,
          RoutesName.home,
          (route) => false,
        );
      }
    }
  }

  static Future<void> registerUser(
    BuildContext context, {
    required TextEditingController name,
    required TextEditingController nickname,
    required TextEditingController email,
    required TextEditingController password,
    required TextEditingController confirmPassword,
  }) async {
    late final AuthStore state = Provider.of<AuthStore>(context, listen: false);
    
    if (password.text != confirmPassword.text) {
      snackBarCustom(
        context,
        content: "As senhas informadas não coincidem.",
        color: Colors.redAccent,
        textColor: Colors.white,
      );
      return;
    }
    final dio = await HttpUtils.instance();

    final body = {
      "name": name.text,
      "nickname": nickname.text,
      "email": email.text,
      "password": password.text
    };

    final response = await dio.post(
      Endpoints.registerEndpoint,
      data: body,
    );

    final responseModel = ResponseRequestModel.toJson(response.data);

    if (context.mounted) {
      if (response.statusCode != 200) {
        snackBarCustom(
          context,
          content: responseModel.message ?? "Não foi possível realizar o login",
          color: Colors.redAccent,
          textColor: Colors.white,
        );

        return;
      }

      state.alterView();
    }
  }
}
