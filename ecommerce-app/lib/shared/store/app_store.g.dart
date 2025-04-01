// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'app_store.dart';

// **************************************************************************
// StoreGenerator
// **************************************************************************

// ignore_for_file: non_constant_identifier_names, unnecessary_brace_in_string_interps, unnecessary_lambdas, prefer_expression_function_bodies, lines_longer_than_80_chars, avoid_as, avoid_annotating_with_dynamic, no_leading_underscores_for_local_identifiers

mixin _$AppStore on _AppStore, Store {
  late final _$tokenAtom = Atom(name: '_AppStore.token', context: context);

  @override
  String get token {
    _$tokenAtom.reportRead();
    return super.token;
  }

  @override
  set token(String value) {
    _$tokenAtom.reportWrite(value, super.token, () {
      super.token = value;
    });
  }

  late final _$expirationTokenAtom =
      Atom(name: '_AppStore.expirationToken', context: context);

  @override
  DateTime? get expirationToken {
    _$expirationTokenAtom.reportRead();
    return super.expirationToken;
  }

  @override
  set expirationToken(DateTime? value) {
    _$expirationTokenAtom.reportWrite(value, super.expirationToken, () {
      super.expirationToken = value;
    });
  }

  late final _$userAtom = Atom(name: '_AppStore.user', context: context);

  @override
  UserModel get user {
    _$userAtom.reportRead();
    return super.user;
  }

  @override
  set user(UserModel value) {
    _$userAtom.reportWrite(value, super.user, () {
      super.user = value;
    });
  }

  late final _$_AppStoreActionController =
      ActionController(name: '_AppStore', context: context);

  @override
  void addCredential(
      {required String token, required DateTime expirationToken}) {
    final _$actionInfo = _$_AppStoreActionController.startAction(
        name: '_AppStore.addCredential');
    try {
      return super
          .addCredential(token: token, expirationToken: expirationToken);
    } finally {
      _$_AppStoreActionController.endAction(_$actionInfo);
    }
  }

  @override
  void addUser(UserModel input) {
    final _$actionInfo =
        _$_AppStoreActionController.startAction(name: '_AppStore.addUser');
    try {
      return super.addUser(input);
    } finally {
      _$_AppStoreActionController.endAction(_$actionInfo);
    }
  }

  @override
  String toString() {
    return '''
token: ${token},
expirationToken: ${expirationToken},
user: ${user}
    ''';
  }
}
