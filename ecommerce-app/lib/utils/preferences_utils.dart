import 'package:shared_preferences/shared_preferences.dart';

class PreferencesUtils {
  static final SharedPreferencesAsync _instance = SharedPreferencesAsync();

  static Future<String> insertAsync({
    required String key,
    required String value,
  }) async {
    try {
      await _instance.setString(key, value);

      return value;
    } catch (_) {
      return "";
    }
  }

  static Future<String> getAsync({
    required String key,
  }) async {
    try {
      final String response = await _instance.getString(key) ?? "";

      return response;
    } catch (_) {
      return "";
    }
  }

  static Future<bool> deleteAsync({
    required String key,
  }) async {
    try {
      await _instance.remove(key);

      return true;
    } catch (_) {
      return false;
    }
  }
}
