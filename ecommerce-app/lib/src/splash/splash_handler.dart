import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:get_it/get_it.dart';
import 'package:marketplace/core/const.dart';
import 'package:marketplace/core/routes.dart';
import 'package:marketplace/shared/model/user_model.dart';
import 'package:marketplace/shared/store/app_store.dart';
import 'package:marketplace/src/auth/model/auth_login_model.dart';
import 'package:marketplace/utils/preferences_utils.dart';
import 'package:provider/provider.dart';

class SplashHandler {
  static Future<void> initializeApp(BuildContext context) async {
    await Future.delayed(
      const Duration(seconds: 2),
    );

    final responsePreferences =
        await PreferencesUtils.getAsync(key: credentialsKey);

    // Não tem dados salvos
    if (responsePreferences.isEmpty) {
      if (context.mounted) {
        Navigator.pushNamedAndRemoveUntil(
          context,
          RoutesName.login,
          (route) => false,
        );
      }
      return;
    }

    String jsonString = responsePreferences
        .replaceAllMapped(
            RegExp(r'([{\s,])(\w+):'), (match) => '${match[1]}"${match[2]}":')
        .replaceAll("'", '"');

    // Adiciona aspas duplas ao redor do valor do token
    jsonString = jsonString.replaceAllMapped(RegExp(r'":\s*([^",}]+)([,}])'),
        (match) => '": "${match[1]}"${match[2]}');

    final modelCredentials = AuthLoginModel.fromJson(
      jsonDecode(jsonString),
    );

    // Credenciais expiraram
    if (modelCredentials.expiration.isBefore(DateTime.now())) {
      await PreferencesUtils.deleteAsync(key: credentialsKey);

      if (context.mounted) {
        Navigator.pushNamedAndRemoveUntil(
          context,
          RoutesName.login,
          (route) => false,
        );
      }

      return;
    } else {
      final responsePreferencesUser =
          await PreferencesUtils.getAsync(key: userKey);

      if (context.mounted) {
        late final AppStore appStore = GetIt.I.get<AppStore>();

        final user = UserModel.fromMap(jsonDecode(responsePreferencesUser));

        appStore.addIdUser(user.id);

        appStore.addCredential(
          token: modelCredentials.token,
          expirationToken: modelCredentials.expiration,
        );

        Navigator.pushNamedAndRemoveUntil(
          context,
          RoutesName.defaultView,
          (route) => false,
        );
      }
      return;
    }
  }
}
