using System;

namespace million.api.Responses;

public class ApiResponse<T>
{
  public string message { get; set; }
  public T? data { get; set; }
  public int code { get; set; }


  public ApiResponse(string message, T? data, int code)
  {
    this.message = message;
    this.data = data;
    this.code = code;
  }

  public static ApiResponse<T> Success(string message, T data, int code = 200)
  {
    return new ApiResponse<T>(message, data, code);
  }

  public static ApiResponse<T> Fail(string message, int code = 400)
  {
    return new ApiResponse<T>(message, default, code);
  }

}
