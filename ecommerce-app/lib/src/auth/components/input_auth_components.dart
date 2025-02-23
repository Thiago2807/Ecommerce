import 'package:flutter/material.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:marketplace/core/colors.dart';
import 'package:marketplace/src/auth/store/auth_store.dart';
import 'package:provider/provider.dart';

class TextFormAuthModel {
  TextFormAuthModel({
    required this.controller,
    required this.isPassword,
    required this.prefixIcon,
    this.stateViewPassword = false,
    required this.label,
    required this.focus,
    this.theLastForm = false,
    this.nextFocus,
  });

  final TextEditingController controller;
  final bool isPassword;
  final IconData prefixIcon;
  final bool stateViewPassword;
  final String label;
  final FocusNode focus;
  final bool theLastForm;
  final FocusNode? nextFocus;
}

TextFormField inputAuthComponents(
  BuildContext context, {
  required TextFormAuthModel model,
}) {
  final AuthStore authStore = Provider.of<AuthStore>(context, listen: false);
  final Size size = MediaQuery.sizeOf(context);

  return TextFormField(
    cursorWidth: 1.5,
    focusNode: model.focus,
    controller: model.controller,
    obscureText: model.isPassword ? model.stateViewPassword : false,
    cursorColor: Color(ColorsApp.primary),
    cursorRadius: Radius.circular(size.width),
    decoration: decorationInput(
      size: size,
      label: model.label,
      prefixIcon: model.prefixIcon,
      isPassword: model.isPassword,
      actionViewPassword: authStore.alterViewPassword,
      stateViewPassword: model.stateViewPassword,
    ),
    onFieldSubmitted: (_) {
      if (model.theLastForm) {
        FocusScope.of(context).unfocus();
      } 
      else {
        FocusScope.of(context).requestFocus(model.nextFocus);
      }
    },
  );
}

OutlineInputBorder borderInput({required String type, required Size size}) {
  return OutlineInputBorder(
    borderRadius: BorderRadius.circular(size.width),
    borderSide: BorderSide(
      width: .5,
      color: type == "focus" ? Color(ColorsApp.primary) : Color(ColorsApp.gray),
    ),
  );
}

InputDecoration decorationInput({
  required Size size,
  required IconData prefixIcon,
  required bool isPassword,
  required void Function() actionViewPassword,
  required String label,
  bool stateViewPassword = false,
}) {
  return InputDecoration(
    label: Text(
      label,
      style: GoogleFonts.inter(
        fontSize: 12,
        color: Color(ColorsApp.gray),
      ),
    ),
    focusedBorder: borderInput(type: "focus", size: size),
    enabledBorder: borderInput(type: "enabled", size: size),
    contentPadding: const EdgeInsets.symmetric(horizontal: 16),
    prefixIcon: Icon(
      prefixIcon,
      color: Color(ColorsApp.gray),
    ),
    suffixIcon: GestureDetector(
      onTap: () => isPassword ? actionViewPassword() : null,
      child: isPassword
          ? Icon(
              stateViewPassword
                  ? Icons.visibility_rounded
                  : Icons.visibility_off_rounded,
              color: Color(ColorsApp.gray),
            )
          : const Icon(
              Icons.abc,
              color: Colors.transparent,
            ),
    ),
  );
}
