import 'package:flutter/material.dart';
import 'package:gap/gap.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:marketplace/core/colors.dart';
import 'package:flutter_mobx/flutter_mobx.dart';
import 'package:marketplace/src/auth/auth_handler.dart';
import 'package:marketplace/src/auth/components/login_component.dart';
import 'package:marketplace/src/auth/components/register_component.dart';
import 'package:marketplace/src/auth/store/auth_store.dart';
import 'package:provider/provider.dart';

import 'components/input_auth_components.dart';

class AuthView extends StatefulWidget {
  const AuthView({super.key});

  @override
  State<AuthView> createState() => _AuthViewState();
}

class _AuthViewState extends State<AuthView> {
  late final AuthStore _state = Provider.of<AuthStore>(context, listen: true);

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
        child: SingleChildScrollView(
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.stretch,
            children: [
              Container(
                margin: const EdgeInsets.only(right: 32),
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.stretch,
                  children: [
                    Observer(
                      builder: (context) => Text(
                        _state.viewLogin ? "Faça login na sua conta" : "Crie sua conta",
                        maxLines: 2,
                        overflow: TextOverflow.ellipsis,
                        style: GoogleFonts.roboto(
                          color: Color(ColorsApp.black),
                          fontSize: 28,
                          fontWeight: FontWeight.w600,
                        ),
                      ),
                    ),
                    Observer(
                      builder: (context) => Text(
                        _state.viewLogin
                            ? "Vamos fazer login na sua conta"
                            : "Vamos criar sua conta aqui",
                        maxLines: 2,
                        overflow: TextOverflow.ellipsis,
                        textAlign: TextAlign.start,
                        style: GoogleFonts.roboto(
                          color: Color(ColorsApp.gray),
                          fontSize: 14,
                          fontWeight: FontWeight.w600,
                        ),
                      ),
                    ),
                  ],
                ),
              ),
              const Gap(18),
              Observer(
                builder: (context) => _state.viewLogin
                    ? const LoginComponent()
                    : const RegisterComponent(),
              )
            ],
          ),
        ),
      ),
    );
  }
}
