// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'default_store.dart';

// **************************************************************************
// StoreGenerator
// **************************************************************************

// ignore_for_file: non_constant_identifier_names, unnecessary_brace_in_string_interps, unnecessary_lambdas, prefer_expression_function_bodies, lines_longer_than_80_chars, avoid_as, avoid_annotating_with_dynamic, no_leading_underscores_for_local_identifiers

mixin _$DefaultStore on _DefaultStore, Store {
  late final _$indexViewAtom =
      Atom(name: '_DefaultStore.indexView', context: context);

  @override
  int get indexView {
    _$indexViewAtom.reportRead();
    return super.indexView;
  }

  @override
  set indexView(int value) {
    _$indexViewAtom.reportWrite(value, super.indexView, () {
      super.indexView = value;
    });
  }

  late final _$_DefaultStoreActionController =
      ActionController(name: '_DefaultStore', context: context);

  @override
  dynamic alterIndexView(int newIndex) {
    final _$actionInfo = _$_DefaultStoreActionController.startAction(
        name: '_DefaultStore.alterIndexView');
    try {
      return super.alterIndexView(newIndex);
    } finally {
      _$_DefaultStoreActionController.endAction(_$actionInfo);
    }
  }

  @override
  String toString() {
    return '''
indexView: ${indexView}
    ''';
  }
}
