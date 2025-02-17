import 'package:flutter/material.dart';
import 'package:marketplace/core/routes.dart';

class SplashHandler {
  static Future<void> initializeApp(BuildContext context) async {
    await Future.delayed(
      const Duration(seconds: 2),
    );

    if (context.mounted) {
      Navigator.pushNamedAndRemoveUntil(
        context,
        RoutesName.login,
        (route) => false,
      );
    }
  }
}
