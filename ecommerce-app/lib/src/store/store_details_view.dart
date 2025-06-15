import 'package:flutter/material.dart';
import 'package:gap/gap.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:marketplace/core/colors.dart';
import 'package:marketplace/src/store/components/input_component.dart';

class StoreDetailsView extends StatefulWidget {
  const StoreDetailsView({
    super.key,
    required this.id,
  });

  final String id;

  @override
  State<StoreDetailsView> createState() => _StoreDetailsViewState();
}

class _StoreDetailsViewState extends State<StoreDetailsView> {
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
            // inputStoreComponents(
            //   context,
            //   model: TextFormStore(
            //     controller: _nameController,
            //     isPassword: false,
            //     label: "Nome da loja",
            //     focus: _nameFocus,
            //     nextFocus: _documentFocus,
            //   ),
            // ),
            Text(widget.id),
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
