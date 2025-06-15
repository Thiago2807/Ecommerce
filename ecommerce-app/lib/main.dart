import 'package:flutter/material.dart';
import 'package:get_it/get_it.dart';
import 'package:marketplace/app.dart';
import 'package:marketplace/core/providers.dart';
import 'package:marketplace/shared/store/app_store.dart';
import 'package:marketplace/src/auth/store/auth_store.dart';
import 'package:marketplace/src/default/store/default_store.dart';
import 'package:provider/provider.dart';

final getItInstancie = GetIt.instance;

void setup() {
  getItInstancie.registerSingleton<AppStore>(AppStore());
}

void main() {
  setup();

  runApp(
    MultiProvider(
      providers: providers,
      child: const App(),
    ),
  );
}
