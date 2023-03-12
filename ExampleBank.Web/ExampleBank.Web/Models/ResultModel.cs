namespace ExampleBank.Web.Models
{
    public class ResultModel<TResult>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public TResult Result { get; set; }

        public ResultModel() { }

        public ResultModel(bool success) : this(success, string.Empty, default) { }

        public ResultModel(bool success, TResult result) : this(success, string.Empty, result) { }

        public ResultModel(bool success, string message) : this(success, message, default) { }

        public ResultModel(bool success, string message, TResult result)
        {
            Success = success;
            Message = message;
            Result = result;
        }
    }

    public class ResultModel : ResultModel<object>
    {
        public ResultModel() { }

        public ResultModel(bool success) : base(success, string.Empty, default) { }

        public ResultModel(bool success, object result) : base(success, string.Empty, result) { }

        public ResultModel(bool success, string message) : base(success, message, default) { }

        public ResultModel(bool success, string message, object result) : base(success, message, result) { }
    }
}