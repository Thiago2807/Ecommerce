import 'package:flutter/material.dart';
import 'package:marketplace/core/colors.dart';
import 'package:marketplace/shared/widgets/snackbar_custom.dart';

import 'core/routes.dart';

class App extends StatelessWidget {
  const App({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      debugShowCheckedModeBanner: false,
      initialRoute: RoutesName.splash,
      routes: routes,
      scaffoldMessengerKey: AppSnackBar.messengerKey,
      theme: ThemeData(
        scaffoldBackgroundColor: Color(
          ColorsApp.white,
        ),
      ),
    );
  }
}

