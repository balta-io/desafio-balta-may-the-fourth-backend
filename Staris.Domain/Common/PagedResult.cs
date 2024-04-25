using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staris.Domain.Common
{
	public class PagedResult<TEntity> : List<TEntity>
	{
        public int ActualPage { get; set; }
		public int NumberOfPages { get; set; }
		public int NumberOfRecords { get; set; }

        public PagedResult(IEnumerable<TEntity> items, int count, int actualPage, int pageSize)
        {
			NumberOfRecords = count;
			ActualPage = actualPage;
			NumberOfPages = (int)Math.Ceiling((double) count / pageSize);

			this.AddRange(items);
        }

		public bool HasNextPage => NumberOfPages > ActualPage ? true : false;
		public bool HasPreviousPage => ActualPage > 1 ? true : false;

	}
}
