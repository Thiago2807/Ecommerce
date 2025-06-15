import 'package:flutter/material.dart';
import 'package:gap/gap.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:hugeicons/hugeicons.dart';
import 'package:marketplace/core/colors.dart';
import 'package:marketplace/core/const.dart';
import 'package:marketplace/core/routes.dart';
import 'package:marketplace/src/profile/components/button_profile_component.dart';
import 'package:marketplace/src/profile/model/profile_model.dart';
import 'package:marketplace/src/profile/model/store_list_model.dart';
import 'package:marketplace/src/profile/profile_handler.dart';
import 'package:marketplace/utils/preferences_utils.dart';

class ProfileView extends StatefulWidget {
  const ProfileView({super.key});

  @override
  State<ProfileView> createState() => _ProfileViewState();
}

class _ProfileViewState extends State<ProfileView> {
  late final Future<ProfileModel> getUserData;
  late final Future<StoreListModel?> getStoreList;

  @override
  void didChangeDependencies() {
    super.didChangeDependencies();
    getUserData = ProfileHandler.getUserData(context);
    getStoreList = ProfileHandler.getStoreList();
  }

  @override
  Widget build(BuildContext context) {
    final Size size = MediaQuery.sizeOf(context);

    return Scaffold(
      body: SafeArea(
        child: FutureBuilder<ProfileModel>(
          future: getUserData,
          builder: (context, snapshot) {
            if (snapshot.connectionState == ConnectionState.waiting ||
                snapshot.connectionState == ConnectionState.none) {
              return Center(
                child: CircularProgressIndicator(
                  color: Color(
                    ColorsApp.primary,
                  ),
                ),
              );
            }

            return Padding(
              padding: EdgeInsets.symmetric(
                vertical: 12,
                horizontal: size.width * .1,
              ),
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.stretch,
                mainAxisAlignment: MainAxisAlignment.start,
                children: [
                  Text(
                    "Meu Perfil",
                    textAlign: TextAlign.center,
                    style: GoogleFonts.poppins(
                        fontWeight: FontWeight.w500, fontSize: 14),
                  ),
                  const Gap(12),
                  CircleAvatar(
                    radius: size.width * .17,
                  ),
                  const Gap(6),
                  Text(
                    snapshot.data!.name,
                    textAlign: TextAlign.center,
                    maxLines: 1,
                    overflow: TextOverflow.ellipsis,
                    style: GoogleFonts.poppins(
                        fontWeight: FontWeight.w600, fontSize: 16),
                  ),
                  Text(
                    snapshot.data!.email,
                    textAlign: TextAlign.center,
                    style: GoogleFonts.poppins(
                        fontWeight: FontWeight.w500,
                        fontSize: 12,
                        color: Colors.grey.shade400),
                  ),
                  const Gap(16),
                  FutureBuilder(
                    future: getStoreList,
                    builder: (context, snapshotStore) {
                      if (snapshotStore.connectionState ==
                          ConnectionState.waiting) {
                        return Center(
                          child: CircularProgressIndicator(
                            color: Color(
                              ColorsApp.primary,
                            ),
                          ),
                        );
                      }

                      if (snapshotStore.data == null) {
                        return buttonProfileComponent(
                          icon: HugeIcons.strokeRoundedStore02,
                          text: "Crie a sua loja agora!",
                          click: () =>
                              Navigator.pushNamed(context, RoutesName.store),
                        );
                      } else {
                        return buttonProfileComponent(
                          icon: HugeIcons.strokeRoundedStore02,
                          text: "Sua loja: ${snapshotStore.data?.name ?? ""}",
                          click: () => Navigator.pushNamed(
                            context,
                            RoutesName.storeDetails,
                            arguments: snapshotStore.data?.id ?? ""
                          ),
                        );
                      }
                    },
                  ),
                  const Gap(12),
                  buttonProfileComponent(
                    icon: HugeIcons.strokeRoundedLogout03,
                    text: "Sair",
                    click: () async {
                      await PreferencesUtils.deleteAsync(key: userKey);
                      await PreferencesUtils.deleteAsync(key: credentialsKey);

                      if (context.mounted) {
                        Navigator.pushNamedAndRemoveUntil(
                          context,
                          RoutesName.splash,
                          (route) => false,
                        );
                      }
                    },
                  ),
                ],
              ),
            );
          },
        ),
      ),
    );
  }
}
