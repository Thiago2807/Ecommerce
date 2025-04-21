import 'package:flutter/material.dart';
import 'package:marketplace/src/auth/auth_view.dart';
import 'package:marketplace/src/default/default_view.dart';
import 'package:marketplace/src/home/home_view.dart';
import 'package:marketplace/src/profile/profile_view.dart';
import 'package:marketplace/src/splash/splash_view.dart';

Map<String, WidgetBuilder> routes = {
  RoutesName.splash: (_) => const SplashView(),
  RoutesName.login: (_) => const AuthView(),
  RoutesName.home: (_) => const HomeView(),
  RoutesName.defaultView: (_) => const DefaultView(),
  RoutesName.profile: (_) => const ProfileView(),
};

T getArguments<T>(BuildContext context) {
  final args = ModalRoute.of(context)!.settings.arguments as T;

  return args;
}

class RoutesName {
  static String get login => "/login";
  static String get splash => "/splash";
  static String get home => "/home";
  static String get defaultView => "/default";
  static String get profile => "/profile";
}
