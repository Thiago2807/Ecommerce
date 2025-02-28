import 'package:mobx/mobx.dart';

part 'auth_store.g.dart';

class AuthStore = _AuthStore with _$AuthStore;

abstract class _AuthStore with Store {
  @observable
  bool viewPassword = false;

  @observable
  bool viewLogin = true;

  void alterViewPassword() {
    viewPassword = !viewPassword;
  }

  void alterView() {
    viewLogin = !viewLogin;
  }
}
