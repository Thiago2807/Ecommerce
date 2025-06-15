import 'package:flutter/material.dart';
import 'package:google_fonts/google_fonts.dart';

class AppSnackBar {
  static final GlobalKey<ScaffoldMessengerState> messengerKey =
      GlobalKey<ScaffoldMessengerState>();

  static void show({
    required String content,
    required Color color,
    required Color textColor,
  }) {
    messengerKey.currentState?.clearSnackBars();
    messengerKey.currentState?.showSnackBar(
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
}
