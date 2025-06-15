// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'store_view.dart';

// **************************************************************************
// StoreGenerator
// **************************************************************************

// ignore_for_file: non_constant_identifier_names, unnecessary_brace_in_string_interps, unnecessary_lambdas, prefer_expression_function_bodies, lines_longer_than_80_chars, avoid_as, avoid_annotating_with_dynamic, no_leading_underscores_for_local_identifiers

mixin _$StoreView on _StoreView, Store {
  late final _$addressOkAtom =
      Atom(name: '_StoreView.addressOk', context: context);

  @override
  bool get addressOk {
    _$addressOkAtom.reportRead();
    return super.addressOk;
  }

  @override
  set addressOk(bool value) {
    _$addressOkAtom.reportWrite(value, super.addressOk, () {
      super.addressOk = value;
    });
  }

  late final _$_StoreViewActionController =
      ActionController(name: '_StoreView', context: context);

  @override
  dynamic alterIndexView(bool input) {
    final _$actionInfo = _$_StoreViewActionController.startAction(
        name: '_StoreView.alterIndexView');
    try {
      return super.alterIndexView(input);
    } finally {
      _$_StoreViewActionController.endAction(_$actionInfo);
    }
  }

  @override
  String toString() {
    return '''
addressOk: ${addressOk}
    ''';
  }
}
