import 'package:mobx/mobx.dart';

part 'store_view.g.dart';

class StoreView = _StoreView with _$StoreView;

abstract class _StoreView with Store {
  @observable
  bool addressOk = false;

  @action
  alterIndexView(bool input) {
    addressOk = input;
  }
} 