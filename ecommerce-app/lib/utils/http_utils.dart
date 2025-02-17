import 'package:dio/dio.dart';
import 'package:flutter_dotenv/flutter_dotenv.dart';
import 'package:marketplace/services/interceptors/uauthorizedInterceptor.dart';

class HttpUtils {
  static late final Dio _dio;

  static final interceptors = [
    Uauthorizedinterceptor(),
  ];

  static Future<Dio> instance() async {
    if (!dotenv.isInitialized) {
      await dotenv.load(fileName: ".env");
    }
    final apiUrl = dotenv.env["API_URL"];

    if (apiUrl == null || apiUrl.isEmpty) {
      throw Exception("Não foi possível obter a URL base da aplicação.");
    }

    final BaseOptions options = BaseOptions(
      baseUrl: apiUrl,
      sendTimeout: const Duration(seconds: 15),
      connectTimeout: const Duration(seconds: 15),
      receiveTimeout: const Duration(seconds: 15),
      validateStatus: (status) =>
          true, // Tratar o retorno dos status em cada requisição
    );

    _dio = Dio(
      options,
    );

    _dio.interceptors.addAll(
      interceptors,
    );

    return _dio;
  }
}
