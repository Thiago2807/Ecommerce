import 'package:email_validator/email_validator.dart';
import 'package:flutter/material.dart';
import 'package:flutter/material.dart';
import 'package:flutter_mobx/flutter_mobx.dart';
import 'package:gap/gap.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:marketplace/core/colors.dart';
import 'package:marketplace/src/auth/auth_handler.dart';
import 'package:marketplace/src/auth/components/input_auth_components.dart';
import 'package:marketplace/src/auth/store/auth_store.dart';
import 'package:password_strength/password_strength.dart';
import 'package:provider/provider.dart';

class RegisterComponent extends StatefulWidget {
  const RegisterComponent({super.key});

  @override
  State<RegisterComponent> createState() => _RegisterComponentState();
}

class _RegisterComponentState extends State<RegisterComponent> {
  final _formKey = GlobalKey<FormState>();
  late final TextEditingController _nameController;
  late final TextEditingController _nicknameController;
  late final TextEditingController _emailController;
  late final TextEditingController _passwordController;
  late final TextEditingController _confirmPasswordController;
  late final AuthStore _state = Provider.of<AuthStore>(context, listen: true);

  late FocusNode _nameFocus;
  late FocusNode _nicknameFocus;
  late FocusNode _emailFocus;
  late FocusNode _passwordFocus;
  late FocusNode _confirmPasswordFocus;

  bool isLoading = false;

  @override
  void initState() {
    super.initState();

    _nameFocus = FocusNode();
    _nicknameFocus = FocusNode();
    _emailFocus = FocusNode();
    _passwordFocus = FocusNode();
    _confirmPasswordFocus = FocusNode();

    _nameController = TextEditingController();
    _nicknameController = TextEditingController();
    _emailController = TextEditingController();
    _passwordController = TextEditingController();
    _confirmPasswordController = TextEditingController();
  }

  @override
  void dispose() {
    _nameFocus.dispose();
    _nicknameFocus.dispose();
    _emailFocus.dispose();
    _passwordFocus.dispose();
    _confirmPasswordFocus.dispose();

    _nameController.dispose();
    _nicknameController.dispose();
    _emailController.dispose();
    _passwordController.dispose();
    _confirmPasswordController.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    final Size size = MediaQuery.sizeOf(context);

    return Form(
      key: _formKey,
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.stretch,
        children: [
          inputAuthComponents(
            context,
            model: TextFormAuthModel(
              focus: _nameFocus,
              controller: _nameController,
              isPassword: false,
              prefixIcon: Icons.person,
              label: "Nome",
              nextFocus: _nicknameFocus,
            ),
            validation: (value) {
              if (value == null || value.trim().isEmpty) {
                return "Campo obrigatório";
              }
            }
          ),
          const Gap(18),
          inputAuthComponents(
            context,
            model: TextFormAuthModel(
              focus: _nicknameFocus,
              controller: _nicknameController,
              isPassword: false,
              prefixIcon: Icons.face,
              label: "Nickname",
              nextFocus: _emailFocus,
            ),
            validation: (value) {
              if (value == null || value.trim().isEmpty) {
                return "Campo obrigatório";
              }
            }
          ),
          const Gap(18),
          inputAuthComponents(
            context,
            model: TextFormAuthModel(
              focus: _emailFocus,
              controller: _emailController,
              isPassword: false,
              prefixIcon: Icons.mail_outline,
              label: "E-mail",
              nextFocus: _passwordFocus,
            ),
            validation: (value) {
              if (value == null || value.trim().isEmpty) {
                return "Campo obrigatório";
              }
              bool isValidEmail = EmailValidator.validate(_emailController.text);

              if (!isValidEmail) {
                return "E-mail inválido";
              }
            }
          ),
          const Gap(18),
          inputAuthComponents(
            context,
            model: TextFormAuthModel(
              focus: _passwordFocus,
              controller: _passwordController,
              isPassword: false,
              prefixIcon: Icons.lock,
              label: "Senha",
              nextFocus: _confirmPasswordFocus,
            ),
            validation: (value) {
              if (value == null || value.trim().isEmpty) {
                return "Campo obrigatório";
              }
              double strength = estimatePasswordStrength(_passwordController.text);

              if (strength < 0.5) {
                return "Senha fraca";
              }
            }
          ),
          const Gap(18),
          inputAuthComponents(
            context,
            model: TextFormAuthModel(
              focus: _confirmPasswordFocus,
              controller: _confirmPasswordController,
              isPassword: false,
              prefixIcon: Icons.lock_outline,
              label: "Confirmar senha",
            ),
            validation: (value) {
              if (value == null || value.trim().isEmpty) {
                return "Campo obrigatório";
              }
              if (_passwordController.text != _confirmPasswordController.text) {
                return "As senhas informadas não coincidem";
              }
            }
          ),
          const Gap(24),
          GestureDetector(
            onTap: () async {
              try {
                if (!_formKey.currentState!.validate()) {
                  return;
                }

                setState(() => isLoading = true);

                if (isLoading) {
                  await AuthHandler.registerUser(
                    context,
                    name: _nameController,
                    nickname: _nicknameController,
                    email: _emailController,
                    password: _passwordController,
                    confirmPassword: _confirmPasswordController,
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
                        "Registrar",
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
                "Lembrou da sua conta? ",
                maxLines: 2,
                overflow: TextOverflow.ellipsis,
                style: GoogleFonts.roboto(
                  color: Color(ColorsApp.gray),
                  fontSize: 14,
                  fontWeight: FontWeight.w600,
                ),
              ),
              GestureDetector(
                onTap: _state.alterView,
                child: Text(
                  "Faça o login",
                  maxLines: 2,
                  overflow: TextOverflow.ellipsis,
                  style: GoogleFonts.roboto(
                    color: Color(ColorsApp.primary),
                    fontSize: 14,
                    fontWeight: FontWeight.w600,
                  ),
                ),
              ),
            ],
          )
        ],
      ),
    );
  }
}
