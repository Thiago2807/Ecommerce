import 'package:dio/dio.dart';
import 'package:flutter/material.dart';
import 'package:marketplace/shared/widgets/snackbar_custom.dart';

class ErrorServerInterceptor extends Interceptor {
  @override
  void onRequest(RequestOptions options, RequestInterceptorHandler handler) {
    handler.next(options);
  }

  @override
  void onError(DioException err, ErrorInterceptorHandler handler) {
    AppSnackBar.show(
      content: "Desculpe, mas ocorreu um erro no servidor, tente novamente mais tarde.",
      color: Colors.redAccent,
      textColor: Colors.white,
    );
    handler.next(err);
  }

  @override
  void onResponse(Response response, ResponseInterceptorHandler handler) {
    handler.next(response);
  }
}
