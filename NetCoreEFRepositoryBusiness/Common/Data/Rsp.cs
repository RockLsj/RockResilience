namespace Common.Data
{
    public class Rsp
    {
        public Rsp()
            : this(null)
        { }

        public Rsp(string content, bool success = true, object data = null)
            : this(content, data, success)
        { }

        public Rsp(string content, object data, bool success = true)
        {
            Success = success;
            Content = content;
            Data = data;
        }

        public bool Success { get; set; }

        public string Content { get; set; }

        public object Data { get; set; }
    }
}
