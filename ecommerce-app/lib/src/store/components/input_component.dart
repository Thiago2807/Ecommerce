import 'package:flutter/material.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:marketplace/core/colors.dart';
import 'package:marketplace/src/auth/store/auth_store.dart';
import 'package:mask_text_input_formatter/mask_text_input_formatter.dart';
import 'package:provider/provider.dart';

class TextFormStore {
  TextFormStore({
    required this.controller,
    required this.isPassword,
    this.prefixIcon,
    this.stateViewPassword = false,
    required this.label,
    required this.focus,
    this.theLastForm = false,
    this.nextFocus,
    this.maskTextInput,
    this.keyboardType,
    this.onChanged,
  });

  final TextEditingController controller;
  final bool isPassword;
  final IconData? prefixIcon;
  final bool stateViewPassword;
  final String label;
  final FocusNode focus;
  final bool theLastForm;
  final FocusNode? nextFocus;
  Function(String)? onChanged;
  TextInputType? keyboardType = TextInputType.text;
  MaskTextInputFormatter? maskTextInput = MaskTextInputFormatter();
  bool? enabled;
}

TextFormField inputStoreComponents(
  BuildContext context, {
  required TextFormStore model,
  Function(String?)? validation,
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
    validator: validation == null ? null : (value) => validation(value),
    inputFormatters: model.maskTextInput == null ? null : [model.maskTextInput!],
    keyboardType: model.keyboardType ?? TextInputType.text,
    enabled: model.enabled ?? true,
    onChanged: model.onChanged,
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
      } else {
        FocusScope.of(context).requestFocus(model.nextFocus);
      }
    },
  );
}

OutlineInputBorder borderInput({
  required String type,
  required Size size,
  Color? colorBorder,
  required bool error,
}) {
  if (type == "focus") {
    colorBorder = error ? Colors.redAccent : Color(ColorsApp.primary);
  } else {
    colorBorder = error ? Colors.redAccent.shade400 : Color(ColorsApp.gray);
  }

  return OutlineInputBorder(
    borderRadius: BorderRadius.circular(size.width),
    borderSide: BorderSide(
      width: error ? 1 : .5,
      color: colorBorder,
    ),
  );
}

InputDecoration decorationInput({
  required Size size,
  required IconData? prefixIcon,
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
    focusedBorder: borderInput(type: "focus", size: size, error: false),
    enabledBorder: borderInput(type: "enabled", size: size, error: false),
    errorBorder: borderInput(type: "enabled", size: size, error: true),
    focusedErrorBorder: borderInput(type: "enabled", size: size, error: true),
    contentPadding: const EdgeInsets.symmetric(horizontal: 16),
    prefixIcon: prefixIcon == null ? null : Icon(
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
    errorStyle: GoogleFonts.inter(
      fontSize: 12,
      color: Colors.red, // defina a cor desejada para o erro
      fontWeight: FontWeight.w500,
    ),
    errorMaxLines: 1,
  );
}
