// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'auth_store.dart';

// **************************************************************************
// StoreGenerator
// **************************************************************************

// ignore_for_file: non_constant_identifier_names, unnecessary_brace_in_string_interps, unnecessary_lambdas, prefer_expression_function_bodies, lines_longer_than_80_chars, avoid_as, avoid_annotating_with_dynamic, no_leading_underscores_for_local_identifiers

mixin _$AuthStore on _AuthStore, Store {
  late final _$viewPasswordAtom =
      Atom(name: '_AuthStore.viewPassword', context: context);

  @override
  bool get viewPassword {
    _$viewPasswordAtom.reportRead();
    return super.viewPassword;
  }

  @override
  set viewPassword(bool value) {
    _$viewPasswordAtom.reportWrite(value, super.viewPassword, () {
      super.viewPassword = value;
    });
  }

  late final _$viewLoginAtom =
      Atom(name: '_AuthStore.viewLogin', context: context);

  @override
  bool get viewLogin {
    _$viewLoginAtom.reportRead();
    return super.viewLogin;
  }

  @override
  set viewLogin(bool value) {
    _$viewLoginAtom.reportWrite(value, super.viewLogin, () {
      super.viewLogin = value;
    });
  }

  @override
  String toString() {
    return '''
viewPassword: ${viewPassword},
viewLogin: ${viewLogin}
    ''';
  }
}
