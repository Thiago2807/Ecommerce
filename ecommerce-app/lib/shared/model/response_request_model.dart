class ResponseRequestModel {
  ResponseRequestModel({
    required this.data,
    required this.error,
    required this.message,
  });

  final String? message;
  final bool? error;
  final dynamic data;

  factory ResponseRequestModel.toJson(Map<String, dynamic> json) => ResponseRequestModel(
        data: json["data"],
        error: json["error"],
        message: json["message"],
      );
}
