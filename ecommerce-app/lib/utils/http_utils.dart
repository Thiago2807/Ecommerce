import 'dart:io';

import 'package:dio/dio.dart';
import 'package:dio/io.dart';
import 'package:flutter_dotenv/flutter_dotenv.dart';
import 'package:marketplace/services/interceptors/uauthorizedInterceptor.dart';

class HttpUtils {
  // Alterar para um tipo nullable
  static Dio? _dio;

  static final interceptors = [
    Uauthorizedinterceptor(),
  ];

  static Future<Dio> instance() async {
    // Carrega as variáveis de ambiente, se necessário
    if (!dotenv.isInitialized) {
      await dotenv.load(fileName: ".env");
    }
    final apiUrl = dotenv.env["API_URL"];

    if (apiUrl == null || apiUrl.isEmpty) {
      throw Exception("Não foi possível obter a URL base da aplicação.");
    }

    if (_dio != null) return _dio!;

    final BaseOptions options = BaseOptions(
      baseUrl: apiUrl,
      sendTimeout: const Duration(seconds: 15),
      connectTimeout: const Duration(seconds: 15),
      receiveTimeout: const Duration(seconds: 15),
      validateStatus: (status) => true,
    );

    _dio = Dio(options);

    _dio!.interceptors.addAll(interceptors);

    _dio?.httpClientAdapter = IOHttpClientAdapter(
      createHttpClient: () {
        final HttpClient client = HttpClient();
        client.badCertificateCallback =
            (X509Certificate cert, String host, int port) => true;
        return client;
      },
    );
    return _dio!;
  }
}
