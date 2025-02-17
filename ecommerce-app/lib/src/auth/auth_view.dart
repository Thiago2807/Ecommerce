import 'package:flutter/material.dart';
import 'package:gap/gap.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:marketplace/core/colors.dart';

class AuthView extends StatefulWidget {
  const AuthView({super.key});

  @override
  State<AuthView> createState() => _AuthViewState();
}

class _AuthViewState extends State<AuthView> {
  @override
  Widget build(BuildContext context) {
    final Size size = MediaQuery.sizeOf(context);

    return Scaffold(
      appBar: AppBar(
        title: Row(
          mainAxisAlignment: MainAxisAlignment.end,
          children: [
            Text(
              "E-COMMERCE",
              style: GoogleFonts.roboto(
                color: Color(ColorsApp.primary),
                fontSize: 14,
                fontWeight: FontWeight.w600,
              ),
            ),
          ],
        ),
      ),
      body: Padding(
        padding: EdgeInsets.symmetric(horizontal: size.width * .08),
        child: Column(
          children: [
            Text(
              "Faça login na sua conta",
              maxLines: 2,
              overflow: TextOverflow.ellipsis,
              style: GoogleFonts.roboto(
                color: Color(ColorsApp.black),
                fontSize: 28,
                fontWeight: FontWeight.w600,
              ),
            ),
            const Gap(12),
            Form(
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
