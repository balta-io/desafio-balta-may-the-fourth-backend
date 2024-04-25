using Microsoft.EntityFrameworkCore;
using Staris.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staris.Infra.Helpers
{
	public static class PagedResultExtention
	{
		public static async Task<PagedResult<TEntity>> ToPagedResultAsync<TEntity>(this IQueryable<TEntity> queryable, int actualPage = 1, int pageSize = 10)
		{
			if (actualPage == 0) actualPage = 1;
			if (pageSize == 0) pageSize = 10;

			var skip = (actualPage - 1)*pageSize;
			var count = await queryable.CountAsync();

			var records = await queryable.Skip(skip) 
									.Take(pageSize)
									.ToListAsync();

			return new PagedResult<TEntity>(records, count, actualPage, pageSize);
		}
	}
}
