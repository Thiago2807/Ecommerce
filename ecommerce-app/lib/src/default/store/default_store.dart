import 'package:mobx/mobx.dart';

part 'default_store.g.dart';

class DefaultStore = _DefaultStore with _$DefaultStore;

abstract class _DefaultStore with Store {
  @observable
  int indexView = 0;

  @action
  alterIndexView(int newIndex) {
    indexView = newIndex;
  }
} 