import 'package:flutter/material.dart';
import 'package:marketplace/core/const.dart';
import 'package:marketplace/core/routes.dart';
import 'package:marketplace/utils/preferences_utils.dart';

class HomeView extends StatefulWidget {
  const HomeView({super.key});

  @override
  State<HomeView> createState() => _HomeViewState();
}

class _HomeViewState extends State<HomeView> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Center(
        child: ElevatedButton(
          onPressed: () async {
            await PreferencesUtils.deleteAsync(key: credentialsKey);

            if (context.mounted) {
              Navigator.pushNamedAndRemoveUntil(
                context,
                RoutesName.splash,
                (route) => false,
              );
            }
          },
          child: Text("Aperta ai"),
        ),
      ),
    );
  }
}
