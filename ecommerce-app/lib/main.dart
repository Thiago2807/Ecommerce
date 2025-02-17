import 'package:flutter/material.dart';
import 'package:marketplace/app.dart';
import 'package:marketplace/shared/store/app_store.dart';
import 'package:marketplace/src/auth/store/auth_store.dart';
import 'package:provider/provider.dart';

void main() {
  runApp(
    MultiProvider(
      providers: <Provider>[
        Provider<AppStore>(
          create: (_) => AppStore(),
        ),
        Provider<AuthStore>(
          create: (_) => AuthStore(),
        ),
      ],
      child: const App(),
    ),
  );
}
