import 'package:flutter/material.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:marketplace/core/colors.dart';
import 'package:marketplace/src/splash/splash_handler.dart';

class SplashView extends StatefulWidget {
  const SplashView({super.key});

  @override
  State<SplashView> createState() => _SplashViewState();
}

class _SplashViewState extends State<SplashView> {
  @override
  void didChangeDependencies() {
    SplashHandler.initializeApp(context);
    super.didChangeDependencies();
  }

  @override
  Widget build(BuildContext context) {
    final Size size = MediaQuery.sizeOf(context);

    return Scaffold(
      backgroundColor: Color(ColorsApp.primary),
      body: Stack(
        children: [
          Positioned(
            right: -120,
            top: -130,
            child: Transform.rotate(
              angle: -120,
              child: Container(
                decoration: BoxDecoration(
                  gradient: LinearGradient(
                    colors: [
                      Color(ColorsApp.secondary),
                      Color(ColorsApp.primary),
                    ],
                    begin: Alignment.topLeft,
                    end: Alignment.bottomRight,
                  ),
                ),
                height: size.height * .6,
                width: size.width * .7,
              ),
            ),
          ),
          Center(
            child: Text(
              "E-COMMERCE",
              style: GoogleFonts.roboto(
                color: Color(ColorsApp.white),
                fontSize: 32,
                fontWeight: FontWeight.w600,
              ),
            ),
          ),
          Align(
            alignment: Alignment.bottomCenter,
            child: LinearProgressIndicator(
              color: Color(ColorsApp.secondary),
              backgroundColor: Color(ColorsApp.white),
            ),
          )
        ],
      ),
    );
  }
}
