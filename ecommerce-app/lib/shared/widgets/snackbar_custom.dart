import 'package:flutter/material.dart';
import 'package:google_fonts/google_fonts.dart';

void snackBarCustom(
  BuildContext context, {
  required String content,
  required Color color,
  required Color textColor,
}) {
  ScaffoldMessenger.of(context).clearSnackBars();

  ScaffoldMessenger.of(context).showSnackBar(
    SnackBar(
      behavior: SnackBarBehavior.floating,
      duration: const Duration(seconds: 2),
      showCloseIcon: true,
      backgroundColor: color,
      content: Text(
        content,
        style: GoogleFonts.inter(
          fontSize: 12,
          color: textColor,
        ),
      ),
    ),
  );
}
