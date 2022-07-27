namespace AuthorProblem
{
    using System;
    [Author("George")]
    public class StartUp
    {
        [Author("George")]
        [Author("Pesho")]
        static void Main()
        {
            var tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
        }
    }
}