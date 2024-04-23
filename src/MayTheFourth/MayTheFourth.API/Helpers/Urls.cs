namespace MayTheFourth.API.Helpers
{
    public static class Urls
    {
        public static string GetMoviesList => "/Movies/All";
        public static string GetMovieById => "/Movies/{Id}";
        public static string PostMovie => "/Movies";
        public static string PutMovieById => "/Movies/{Id}";
        public static string DeleteMovieById => "/Movies/{Id}";
    }
}
