namespace Application.DTOs
{

    public class Result
    {
        public bool IsSuccess { get; init; }
        public string? Message { get; init; }

        public static Result Success()
        {
            var res = new Result()
            {
                IsSuccess = true,
            };

            return res;
        }

        public static Result Failure(string message)
        {
            var res = new Result()
            {
                IsSuccess = false,
                Message = message,
            };

            return res;
        }

    }

    public class Result<TData>
        where TData : class
    {
        public bool IsSuccess { get; init; }
        public TData? Data { get; init; }
        public string? Message { get; init; }

        public static Result<TData> Success(TData data)
        {
            var res = new Result<TData>()
            {
                IsSuccess = true,
                Data = data
            };

            return res;
        }

        public static Result<TData> Failure(string message)
        {
            var res = new Result<TData>()
            {
                IsSuccess = false,
                Data = null,
                Message = message,
            };

            return res;
        }

    }
}
