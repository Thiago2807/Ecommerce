import 'package:flutter/material.dart';
import 'package:flutter_mobx/flutter_mobx.dart';
import 'package:gap/gap.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:hugeicons/hugeicons.dart';
import 'package:marketplace/core/colors.dart';
import 'package:marketplace/src/home/home_view.dart';
import 'package:marketplace/src/profile/profile_view.dart';
import 'package:provider/provider.dart';

import 'store/default_store.dart';

class DefaultView extends StatefulWidget {
  const DefaultView({super.key});

  @override
  State<DefaultView> createState() => _DefaultViewState();
}

class _DefaultViewState extends State<DefaultView> {
  late final DefaultStore store = Provider.of<DefaultStore>(context);

  final views = [const HomeView(), const ProfileView()];

  @override
  Widget build(BuildContext context) {
    final Size size = MediaQuery.sizeOf(context);

    return Scaffold(
      bottomNavigationBar: SizedBox(
        width: size.width,
        height: size.height * .08,
        child: LayoutBuilder(
          builder: (context, constraints) => Observer(
            builder: (context) => Row(
              mainAxisAlignment: MainAxisAlignment.spaceAround,
              crossAxisAlignment: CrossAxisAlignment.center,
              children: [
                Expanded(
                  child: GestureDetector(
                    onTap: () => store.alterIndexView(0),
                    child: Column(
                      mainAxisSize: MainAxisSize.min,
                      children: [
                        Icon(
                          HugeIcons.strokeRoundedHome12,
                          color: Color(ColorsApp.primary).withOpacity(
                            store.indexView == 0 ? 1 : .6,
                          ),
                          size: constraints.maxWidth * .05,
                        ),
                        const Gap(2),
                        Text(
                          "Início",
                          style: GoogleFonts.poppins(
                            fontSize: constraints.maxWidth * .025,
                            color: Color(ColorsApp.primary).withOpacity(
                              store.indexView == 0 ? 1 : .6,
                            ),
                            fontWeight: FontWeight.w600,
                          ),
                        ),
                      ],
                    ),
                  ),
                ),
                Expanded(
                  child: GestureDetector(
                    onTap: () => store.alterIndexView(1),
                    child: Column(
                      mainAxisSize: MainAxisSize.min,
                      children: [
                        Icon(
                          HugeIcons.strokeRoundedUserList,
                          color: Color(ColorsApp.primary).withOpacity(
                            store.indexView == 1 ? 1 : .6,
                          ),
                          size: constraints.maxWidth * .05,
                        ),
                        const Gap(2),
                        Text(
                          "Perfil",
                          style: GoogleFonts.poppins(
                            fontSize: constraints.maxWidth * .025,
                            color: Color(ColorsApp.primary).withOpacity(
                              store.indexView == 1 ? 1 : .6,
                            ),
                            fontWeight: FontWeight.w600,
                          ),
                        ),
                      ],
                    ),
                  ),
                ),
              ],
            ),
          ),
        ),
      ),
      body: Observer(
        builder: (context) => views[store.indexView],
      ),
    );
  }
}
