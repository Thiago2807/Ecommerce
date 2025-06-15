import 'package:flutter/material.dart';
import 'package:marketplace/src/auth/auth_view.dart';
import 'package:marketplace/src/default/default_view.dart';
import 'package:marketplace/src/home/home_view.dart';
import 'package:marketplace/src/profile/profile_view.dart';
import 'package:marketplace/src/splash/splash_view.dart';
import 'package:marketplace/src/store/store_details_view.dart';
import 'package:marketplace/src/store/store_view.dart';

Map<String, WidgetBuilder> routes = {
  RoutesName.splash: (_) => const SplashView(),
  RoutesName.login: (_) => const AuthView(),
  RoutesName.home: (_) => const HomeView(),
  RoutesName.defaultView: (_) => const DefaultView(),
  RoutesName.profile: (_) => const ProfileView(),
  RoutesName.store: (_) => const StoreView(),
  RoutesName.storeDetails: (context) => StoreDetailsView(
        id: getArguments<String>(context),
      ),
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
  static String get store => "/store";
  static String get storeDetails => "/store-details";
}
