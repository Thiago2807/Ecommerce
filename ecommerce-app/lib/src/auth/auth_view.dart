import 'package:flutter/material.dart';
import 'package:gap/gap.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:marketplace/core/colors.dart';
import 'package:flutter_mobx/flutter_mobx.dart';
import 'package:marketplace/src/auth/auth_handler.dart';
import 'package:marketplace/src/auth/store/auth_store.dart';
import 'package:provider/provider.dart';

import 'components/input_auth_components.dart';

class AuthView extends StatefulWidget {
  const AuthView({super.key});

  @override
  State<AuthView> createState() => _AuthViewState();
}

class _AuthViewState extends State<AuthView> {
  late final TextEditingController _emailController;
  late final TextEditingController _passwordController;
  late final AuthStore _state = Provider.of<AuthStore>(context, listen: true);

  late FocusNode _emailFocus;
  late FocusNode _passwordFocus;

  bool isLoading = false;

  @override
  void initState() {
    super.initState();

    _emailFocus = FocusNode();
    _passwordFocus = FocusNode();

    _emailController = TextEditingController();
    _passwordController = TextEditingController();
  }

  @override
  void dispose() {
    _emailFocus.dispose();
    _passwordFocus.dispose();

    _emailController.dispose();
    _passwordController.dispose();
    super.dispose();
  }

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
                    Text(
                      "Vamos fazer login na sua conta",
                      maxLines: 2,
                      overflow: TextOverflow.ellipsis,
                      textAlign: TextAlign.start,
                      style: GoogleFonts.roboto(
                        color: Color(ColorsApp.gray),
                        fontSize: 14,
                        fontWeight: FontWeight.w600,
                      ),
                    ),
                  ],
                ),
              ),
              const Gap(18),
              Form(
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.stretch,
                  children: [
                    inputAuthComponents(
                      context,
                      model: TextFormAuthModel(
                        focus: _emailFocus,
                        controller: _emailController,
                        isPassword: false,
                        prefixIcon: Icons.person,
                        label: "E-mail",
                        nextFocus: _passwordFocus,
                      ),
                    ),
                    const Gap(18),
                    Observer(
                      builder: (context) => inputAuthComponents(
                        context,
                        model: TextFormAuthModel(
                          focus: _passwordFocus,
                          controller: _passwordController,
                          isPassword: true,
                          label: "Senha",
                          stateViewPassword: !_state.viewPassword,
                          prefixIcon: Icons.password_rounded,
                          theLastForm: true,
                        ),
                      ),
                    ),
                    const Gap(6),
                    Text(
                      "Esqueceu sua senha?",
                      maxLines: 2,
                      overflow: TextOverflow.ellipsis,
                      textAlign: TextAlign.end,
                      style: GoogleFonts.roboto(
                        color: Color(ColorsApp.primary),
                        fontSize: 14,
                        fontWeight: FontWeight.w600,
                      ),
                    ),
                    const Gap(24),
                    GestureDetector(
                      onTap: () async {
                        try {
                          setState(() => isLoading = true);

                          if (isLoading) {
                            await AuthHandler.loginUser(
                              context,
                              email: _emailController,
                              password: _passwordController,
                            );
                          }
                        } finally {
                          setState(() => isLoading = false);
                        }
                      },
                      child: Container(
                        width: size.width,
                        height: size.height * .05,
                        decoration: BoxDecoration(
                          color: Color(ColorsApp.primary),
                          borderRadius: BorderRadius.circular(
                            size.width,
                          ),
                        ),
                        child: Align(
                          alignment: Alignment.center,
                          child: !isLoading
                              ? Text(
                                  "Login",
                                  style: GoogleFonts.inter(
                                    fontSize: 14,
                                    fontWeight: FontWeight.w600,
                                    color: Color(ColorsApp.white),
                                  ),
                                )
                              : const CircularProgressIndicator(
                                  color: Colors.white,
                                  strokeWidth: 1,
                                ),
                        ),
                      ),
                    ),
                    const Gap(18),
                    Row(
                      mainAxisAlignment: MainAxisAlignment.center,
                      children: [
                        Text(
                          "Não tem conta? ",
                          maxLines: 2,
                          overflow: TextOverflow.ellipsis,
                          style: GoogleFonts.roboto(
                            color: Color(ColorsApp.gray),
                            fontSize: 14,
                            fontWeight: FontWeight.w600,
                          ),
                        ),
                        Text(
                          "Inscrever-se",
                          maxLines: 2,
                          overflow: TextOverflow.ellipsis,
                          style: GoogleFonts.roboto(
                            color: Color(ColorsApp.primary),
                            fontSize: 14,
                            fontWeight: FontWeight.w600,
                          ),
                        ),
                      ],
                    )
                  ],
                ),
              )
            ],
          ),
        ),
      ),
    );
  }
}
