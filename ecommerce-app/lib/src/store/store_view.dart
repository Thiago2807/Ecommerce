import 'package:flutter/material.dart';
import 'package:flutter_mobx/flutter_mobx.dart';
import 'package:gap/gap.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:marketplace/core/colors.dart';
import 'package:marketplace/src/store/components/input_component.dart';
import 'package:marketplace/src/store/store/store_details/store_details.dart';
import 'package:marketplace/src/store/store_handler.dart';
import 'package:mask_text_input_formatter/mask_text_input_formatter.dart';
import 'package:provider/provider.dart';

class StoreView extends StatefulWidget {
  const StoreView({super.key});

  @override
  State<StoreView> createState() => _StoreViewState();
}

class _StoreViewState extends State<StoreView> {
  late final stateDetails = Provider.of<StoreDetails>(context);

  final TextEditingController _numberController = TextEditingController();
  final FocusNode _numberFocus = FocusNode();

  final TextEditingController _complementController = TextEditingController();
  final FocusNode _complementFocus = FocusNode();

  final TextEditingController _nameController = TextEditingController();
  final FocusNode _nameFocus = FocusNode();

  final TextEditingController _documentController = TextEditingController();
  final FocusNode _documentFocus = FocusNode();

  final TextEditingController _cepController = TextEditingController();
  final FocusNode _cepFocus = FocusNode();

  final maskInputDocument = MaskTextInputFormatter(
    mask: '###.###.###-##',
    filter: {"#": RegExp(r'[0-9]')},
    type: MaskAutoCompletionType.lazy,
  );

  final maskInputCep = MaskTextInputFormatter(
    mask: '#####-###',
    filter: {"#": RegExp(r'[0-9]')},
    type: MaskAutoCompletionType.lazy,
  );

  @override
  void didChangeDependencies() {
    stateDetails.initialize();
    super.didChangeDependencies();
  }

  @override
  void dispose() {
    _numberController.dispose();
    _numberFocus.dispose();

    _complementController.dispose();
    _complementFocus.dispose();

    _nameController.dispose();
    _nameFocus.dispose();

    _documentController.dispose();
    _documentFocus.dispose();

    _cepController.dispose();
    _cepFocus.dispose();
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
                  nextFocus: _cepFocus,
                  maskTextInput: maskInputDocument,
                  keyboardType: TextInputType.number),
            ),
            const Gap(12),
            Observer(
              builder: (context) {
                return Column(
                  mainAxisSize: MainAxisSize.min,
                  children: [
                    if (stateDetails.street.isNotEmpty) ...[
                      Row(
                        children: [
                          Expanded(
                            flex: 2,
                            child: inputStoreComponents(
                              context,
                              model: TextFormStore(
                                controller: TextEditingController(),
                                isPassword: false,
                                label: "Logradouro: ",
                                focus: FocusNode(),
                                enabled: false,
                                initializeController: stateDetails.street,
                              ),
                            ),
                          ),
                          const Gap(12),
                          Expanded(
                            child: inputStoreComponents(
                              context,
                              model: TextFormStore(
                                controller: _numberController,
                                isPassword: false,
                                label: "Nº",
                                focus: _numberFocus,
                                nextFocus: _complementFocus,
                                keyboardType: TextInputType.text,
                                onChanged: (value) =>
                                    stateDetails.addNumber(value),
                              ),
                            ),
                          ),
                        ],
                      ),
                      const Gap(12),
                    ],
                    if (stateDetails.street.isNotEmpty) ...[
                      inputStoreComponents(
                        context,
                        model: TextFormStore(
                          controller: _complementController,
                          isPassword: false,
                          label: "Complemento",
                          focus: _complementFocus,
                          nextFocus: _cepFocus,
                          keyboardType: TextInputType.text,
                          onChanged: (value) =>
                              stateDetails.addComplement(value),
                        ),
                      ),
                      const Gap(12),
                    ],
                    Row(
                      children: [
                        Expanded(
                          child: inputStoreComponents(
                            context,
                            model: TextFormStore(
                                controller: _cepController,
                                isPassword: false,
                                label: "CEP",
                                focus: _cepFocus,
                                maskTextInput: maskInputCep,
                                keyboardType: TextInputType.number,
                                onChanged: (value) {
                                  if (value.length == 9) {
                                    StoreHandler.getAddress(
                                        context, _cepController);
                                  }
                                }),
                          ),
                        ),
                        if (stateDetails.neighborhood.isNotEmpty) ...[
                          const Gap(12),
                          Expanded(
                            child: inputStoreComponents(
                              context,
                              model: TextFormStore(
                                controller: TextEditingController(),
                                isPassword: false,
                                label: "Bairro",
                                focus: FocusNode(),
                                enabled: false,
                                initializeController: stateDetails.neighborhood,
                              ),
                            ),
                          ),
                        ]
                      ],
                    ),
                    const Gap(12),
                    Row(
                      children: [
                        if (stateDetails.city.isNotEmpty)
                          Expanded(
                            flex: 3,
                            child: inputStoreComponents(
                              context,
                              model: TextFormStore(
                                controller: TextEditingController(),
                                isPassword: false,
                                label: "Cidade",
                                focus: FocusNode(),
                                enabled: false,
                                initializeController: stateDetails.city,
                              ),
                            ),
                          ),
                        const Gap(12),
                        if (stateDetails.state.isNotEmpty)
                          Expanded(
                            child: inputStoreComponents(
                              context,
                              model: TextFormStore(
                                controller: TextEditingController(),
                                isPassword: false,
                                label: "Estado",
                                focus: FocusNode(),
                                enabled: false,
                                initializeController:
                                    stateDetails.stateAbbreviation,
                              ),
                            ),
                          ),
                      ],
                    ),
                  ],
                );
              },
            ),
            const Gap(24),
            GestureDetector(
              onTap: () async => await StoreHandler.insertStore(
                context,
                documentController: _documentController,
                nameController: _nameController,
              ),
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
