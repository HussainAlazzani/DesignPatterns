// Source: Mosh Design Patterns series in Java

namespace CSharpDesignPatterns
{
    /// <summary>
    /// Client
    /// </summary>
    public class ChainOfResponsibilityTest
    {
        public static void Run()
        {
            // We can add/remove handlers and change the order.
            // Authenticator -> Logger -> compressor
            var compressor = new Compressor(null);
            var logger = new Logger(compressor);
            var Authenticator = new Authenticator(logger);

            var webserver = new Webserver(Authenticator);
            // Valid user
            webserver.Handle(new HttpRequest("admin", "1234"));
            // False user
            System.Console.WriteLine();
            webserver.Handle(new HttpRequest("faker", "124"));
        }
    }

    internal class HttpRequest
    {
        internal HttpRequest(string username, string password)
        {
            Username = username;
            Password = password;
        }

        internal string Username { get; set; }
        internal string Password { get; set; }
    }
    internal class Webserver
    {
        private Handler handler;

        internal Webserver(Handler handler)
        {
            this.handler = handler;
        }
        internal void Handle(HttpRequest request)
        {
            handler.Handle(request);
        }
    }
    /// <summary>
    /// Abstract handler
    /// </summary>
    internal abstract class Handler
    {
        private Handler next;

        protected Handler(Handler next)
        {
            this.next = next;
        }
        internal void Handle(HttpRequest request)
        {
            if (DoHandle(request))
                return;
            if (next != null)
                next.Handle(request);
        }
        internal abstract bool DoHandle(HttpRequest request);
    }
    /// <summary>
    /// Concrete handler A
    /// </summary>
    internal class Authenticator : Handler
    {
        internal Authenticator(Handler next) : base(next) { }

        internal override bool DoHandle(HttpRequest request)
        {
            var isValid = (request.Username == "admin" && request.Password == "1234");
            System.Console.WriteLine("Authenticating...");
            // if the user is a valid user, then return false to continue through the request pipeline.
            // A value of true would stop the request chain becasue it won't link the next handler.
            return !isValid;
        }
    }
    /// <summary>
    /// Concrete handler B
    /// </summary>
    internal class Compressor : Handler
    {
        internal Compressor(Handler next) : base(next) { }

        internal override bool DoHandle(HttpRequest request)
        {
            System.Console.WriteLine("Compressing...");
            return false;
        }
    }
    /// <summary>
    /// Concrete handler C
    /// </summary>
    internal class Logger : Handler
    {
        internal Logger(Handler next) : base(next) { }

        internal override bool DoHandle(HttpRequest request)
        {
            System.Console.WriteLine("Logging request...");
            return false;
        }
    }
}