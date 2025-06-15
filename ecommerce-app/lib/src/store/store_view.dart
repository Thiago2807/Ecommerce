import 'package:flutter/material.dart';
import 'package:gap/gap.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:marketplace/core/colors.dart';
import 'package:marketplace/src/store/components/input_component.dart';
import 'package:mask_text_input_formatter/mask_text_input_formatter.dart';

class StoreView extends StatefulWidget {
  const StoreView({super.key});

  @override
  State<StoreView> createState() => _StoreViewState();
}

class _StoreViewState extends State<StoreView> {
  final TextEditingController _nameController = TextEditingController();
  final FocusNode _nameFocus = FocusNode();

  final TextEditingController _documentController = TextEditingController();
  final FocusNode _documentFocus = FocusNode();

  final maskInputDocument = MaskTextInputFormatter(
    mask: '###.###.###-##',
    filter: {"#": RegExp(r'[0-9]')},
    type: MaskAutoCompletionType.lazy,
  );

  @override
  void dispose() {
    _nameController.dispose();
    _nameFocus.dispose();

    _documentController.dispose();
    _documentFocus.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    final Size size = MediaQuery.sizeOf(context);

    return Scaffold(
      appBar: AppBar(
        title: Align(
          alignment: Alignment.centerRight,
          child: Text(
            "Cadastro de Loja",
            style: GoogleFonts.inter(
              fontSize: 18,
              fontWeight: FontWeight.w600,
              color: Color(ColorsApp.primary),
            ),
          ),
        ),
      ),
      body: Padding(
        padding: const EdgeInsets.symmetric(
          vertical: 12,
          horizontal: 24,
        ),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.stretch,
          children: [
            inputStoreComponents(
              context,
              model: TextFormStore(
                controller: _nameController,
                isPassword: false,
                label: "Nome da loja",
                focus: _nameFocus,
                nextFocus: _documentFocus,
              ),
            ),
            const Gap(12),
            inputStoreComponents(
              context,
              model: TextFormStore(
                controller: _documentController,
                isPassword: false,
                label: "Documento",
                focus: _documentFocus,
                maskTextInput: maskInputDocument,
              ),
            ),
            const Gap(24),
            GestureDetector(
              onTap: () async {},
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
                  child: Text(
                    "Registrar",
                    style: GoogleFonts.inter(
                      fontSize: 14,
                      fontWeight: FontWeight.w600,
                      color: Color(ColorsApp.white),
                    ),
                  ),
                ),
              ),
            ),
          ],
        ),
      ),
    );
  }
}
