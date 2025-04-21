import 'package:flutter/material.dart';
import 'package:gap/gap.dart';
import 'package:google_fonts/google_fonts.dart';

import '../../../core/colors.dart';

class AppBarHomeComponents extends StatefulWidget {
  const AppBarHomeComponents({super.key});

  @override
  State<AppBarHomeComponents> createState() => _AppBarHomeComponentsState();
}

class _AppBarHomeComponentsState extends State<AppBarHomeComponents> {
  @override
  Widget build(BuildContext context) {
    return Stack(
      children: [
        Container(
          decoration: BoxDecoration(
            color: Color(
              ColorsApp.primary,
            ),
            borderRadius: const BorderRadius.only(
              bottomLeft: Radius.elliptical(210, 50),
              bottomRight: Radius.elliptical(210, 50),
            ),
          ),
        ),
        SafeArea(
          child: Container(
            margin: const EdgeInsets.symmetric(
              horizontal: 12,
              vertical: 12,
            ),
            child: Row(
              children: [
                Expanded(
                  child: LayoutBuilder(
                    builder: (context, constraints) {
                      return Container(
                        padding: EdgeInsets.symmetric(
                          horizontal: constraints.maxWidth * .035,
                          vertical: constraints.maxHeight * .1,
                        ),
                        decoration: BoxDecoration(
                          color: Colors.white,
                          borderRadius:
                              BorderRadius.circular(constraints.maxWidth),
                        ),
                        child: Row(
                          children: [
                            Icon(
                              Icons.search_rounded,
                              color: Color(ColorsApp.black),
                            ),
                            const Gap(12),
                            Expanded(
                              child: TextField(
                                cursorColor: Color(ColorsApp.primary),
                                decoration: InputDecoration(
                                    isCollapsed: true,
                                    focusedBorder: InputBorder.none,
                                    enabledBorder: InputBorder.none,
                                    hintText: "Pesquise por \"Roupas\"",
                                    hintStyle: GoogleFonts.poppins(
                                        color: Colors.grey.shade400)),
                              ),
                            )
                          ],
                        ),
                      );
                    },
                  ),
                ),
                const Gap(12),
                CircleAvatar(
                  backgroundColor: Colors.white,
                  child: Icon(
                    Icons.shopping_cart_outlined,
                    size: 20,
                    color: Color(ColorsApp.black),
                  ),
                )
              ],
            ),
          ),
        ),
      ],
    );
  }
}
