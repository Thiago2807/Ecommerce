
import 'package:mobx/mobx.dart';

part 'app_store.g.dart';

class AppStore = _AppStore with _$AppStore;

abstract class _AppStore with Store {
  @observable
  String token = "";

  @observable
  DateTime? expirationToken;

  @action
  void addCredential({required String token, required DateTime expirationToken}) {

    this.token = token;
    this.expirationToken = expirationToken;
  }
}