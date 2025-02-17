import 'package:flutter/material.dart';
import 'package:marketplace/core/colors.dart';

import 'core/routes.dart';

class App extends StatelessWidget {
  const App({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      debugShowCheckedModeBanner: false,
      initialRoute: RoutesName.splash,
      routes: routes,
      theme: ThemeData(
        scaffoldBackgroundColor: Color(
          ColorsApp.white,
        ),
      ),
    );
  }
}
