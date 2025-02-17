import 'package:flutter/material.dart';
import 'package:marketplace/src/auth/auth_view.dart';
import 'package:marketplace/src/splash/splash_view.dart';

Map<String, WidgetBuilder> routes = {
  RoutesName.splash: (_) => const SplashView(),
  RoutesName.login: (_) => const AuthView(),
};

T getArguments<T>(BuildContext context) {
  final args = ModalRoute.of(context)!.settings.arguments as T;

  return args;
}

class RoutesName {
  static String get login => "/login";
  static String get splash => "/splash";
}
