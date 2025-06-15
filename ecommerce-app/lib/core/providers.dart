import 'package:marketplace/src/auth/store/auth_store.dart';
import 'package:marketplace/src/default/store/default_store.dart';
import 'package:marketplace/src/store/store/store_details/store_details.dart';
import 'package:provider/provider.dart';

final providers = [
  Provider<AuthStore>(
    create: (_) => AuthStore(),
  ),
  Provider<DefaultStore>(
    create: (_) => DefaultStore(),
  ),
  Provider<StoreDetails>(
    create: (_) => StoreDetails(),
  ),
];
