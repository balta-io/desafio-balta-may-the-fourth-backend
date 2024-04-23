namespace MayTheFourth.Utils.Paging
{
    public abstract class BasePagedResult
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public bool HasNext { get; set; }

        public int FirstRowOnPage
        {

            get { return (CurrentPage - 1) * PageSize + 1; }
        }

        public int LastRowOnPage
        {
            get { return CurrentPage * PageSize; }
        }
    }
}
