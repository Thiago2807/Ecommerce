
import 'package:mobx/mobx.dart';

import '../model/user_model.dart';

part 'app_store.g.dart';

class AppStore = _AppStore with _$AppStore;

abstract class _AppStore with Store {
  @observable
  String token = "";

  @observable
  DateTime? expirationToken;

  @observable
  UserModel user = UserModel.fromEmpty();

  @action
  void addCredential({required String token, required DateTime expirationToken}) {

    this.token = token;
    this.expirationToken = expirationToken;
  }

  @action
  void addUser(UserModel input) {
    user = input;
  }
}