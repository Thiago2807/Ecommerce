import 'package:flutter/material.dart';
import 'package:get_it/get_it.dart';

import '../../shared/store/app_store.dart';
import 'components/appbar_home_components.dart';

class HomeView extends StatefulWidget {
  const HomeView({super.key});

  @override
  State<HomeView> createState() => _HomeViewState();
}

class _HomeViewState extends State<HomeView> {
  late final AppStore appStore = GetIt.I.get<AppStore>();

  @override
  Widget build(BuildContext context) { 
    final Size size = MediaQuery.sizeOf(context);

    return Scaffold(
      appBar: PreferredSize(
        preferredSize: Size(size.width, size.height * .13),
        child: const AppBarHomeComponents(),
      ),
      body: Container(
        margin: EdgeInsets.symmetric(
          vertical: 12,
          horizontal: size.width * .05,
        ),
        child: Column(
          children: [
            Container(
              height: size.height * .1,
              width: size.width,
              decoration: BoxDecoration(
                borderRadius: BorderRadius.circular(12),
                gradient: const LinearGradient(
                  colors: [
                    Color(0XFFC05530),
                    Color(0XFFAB3F18)
                  ],
                ),
              ),
              child: Column(
                children: [
                ],
              ),
            )
          ],
        ),
      ),
    );
  }
}
