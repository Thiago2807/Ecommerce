import 'package:flutter/material.dart';
import 'package:gap/gap.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:hugeicons/hugeicons.dart';
import 'package:marketplace/core/colors.dart';
import 'package:marketplace/core/const.dart';
import 'package:marketplace/core/routes.dart';
import 'package:marketplace/utils/preferences_utils.dart';

Widget buttonProfileComponent({
  required Function() click,
  required IconData icon,
  required String text,
}) {
  return GestureDetector(
    onTap: () async => click(),
    child: Container(
      decoration: BoxDecoration(
        color: Colors.white,
        boxShadow: const [
          BoxShadow(
            blurRadius: 5,
            offset: Offset(5, 3),
            color: Colors.black12,
          )
        ],
        borderRadius: BorderRadius.circular(12),
      ),
      child: LayoutBuilder(
        builder: (context, constraints) => Container(
          height: 46,
          padding: EdgeInsets.symmetric(
            vertical: 2,
            horizontal: constraints.maxWidth * .06,
          ),
          child: Row(
            children: [
              Icon(
                icon,
                color: Color(ColorsApp.primary),
              ),
              const Gap(12),
              Expanded(
                child: Text(
                  text,
                  style: GoogleFonts.poppins(
                    fontWeight: FontWeight.w400,
                    fontSize: 12,
                  ),
                ),
              ),
              Icon(
                HugeIcons.strokeRoundedArrowRight01,
                color: Colors.grey.shade500,
              ),
            ],
          ),
        ),
      ),
    ),
  );
}
