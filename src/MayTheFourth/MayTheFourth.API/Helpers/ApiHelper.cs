using MayTheFourth.Entities;
using MayTheFourth.Services.Interfaces;
using MayTheFourth.Services.ViewModels;
using MayTheFourth.Utils.Paging;
using System.Linq.Expressions;
using System.Net;

namespace MayTheFourth.API.Helpers
{
    public static class ApiHelper
    {
        public static bool IsSuccessResponse(HttpStatusCode code)
        {
            if (IsInformational(code))
                return true;
            else if (IsSuccess(code))
                return true;
            else if (IsRedirect(code))
                return true;
            else if (IsClientError(code))
                return false;
            else if (IsServerError(code))
                return false;

            return false;
        }

        public static bool IsInformational(HttpStatusCode code)
        {
            return (int)code >= 100 && (int)code <= 199;
        }

        public static bool IsRedirect(HttpStatusCode code)
        {
            return (int)code >= 300 && (int)code <= 399;
        }

        public static bool IsSuccess(HttpStatusCode code)
        {
            return (int)code >= 200 && (int)code <= 299;
        }

        public static bool IsClientError(HttpStatusCode code)
        {
            return (int)code >= 400 && (int)code <= 499;
        }

        public static bool IsServerError(HttpStatusCode code)
        {
            return (int)code >= 500 && (int)code <= 599;
        }

        public static IResult ResultErrorOperation(
            Exception ex,
            HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            return Results.BadRequest(new
            {
                Error = IsSuccessResponse(statusCode),
                Status = (int)statusCode,
                Detail = new string[] {
                    $"{ex.Message} {ex.InnerException?.Message} {ex.InnerException?.InnerException?.Message}"
                }
            });
        }

        public static IResult ResultPagedOperation<ViewModel, Model>(
           PageListResult<ViewModel> OkResult,
           IErrorBaseService service)
            where ViewModel : BaseViewModel<Model>
            where Model : BaseModel
        {
            if (service.Validation.Any())
                return Results.BadRequest(new
                {
                    Error = IsSuccessResponse(HttpStatusCode.BadRequest),
                    Status = (int)HttpStatusCode.BadRequest,
                    Detail = service.Validation.Select(x => string.Join(" ", x.Messages)).ToArray()
                });

            return Results.Ok(new
            {
                Error = IsSuccessResponse(HttpStatusCode.OK),
                Status = (int)HttpStatusCode.OK,
                Data = OkResult
            });
        }

        public static IResult ResultOperation<ViewModel, Model>(
            ViewModel? OkResult,
            IErrorBaseService service)
            where ViewModel : BaseViewModel<Model>
            where Model : BaseModel
        {
            if (service.Validation.Any() || OkResult == null)
                return Results.BadRequest(new
                {
                    Error = IsSuccessResponse(HttpStatusCode.BadRequest),
                    Status = (int)HttpStatusCode.BadRequest,
                    Detail = service.Validation.Select(x => string.Join(" ", x.Messages)).ToArray()
                });

            return Results.Ok(new
            {
                Error = IsSuccessResponse(HttpStatusCode.OK),
                Status = (int)HttpStatusCode.OK,
                Data = OkResult
            });
        }

        public static IResult ResultListOperation<ViewModel, Model>(
            IEnumerable<ViewModel> OkResult,
            IErrorBaseService service)
            where ViewModel : BaseViewModel<Model>
            where Model : BaseModel
        {
            if (service.Validation.Any())
                return Results.BadRequest(new
                {
                    Error = IsSuccessResponse(HttpStatusCode.BadRequest),
                    Status = (int)HttpStatusCode.BadRequest,
                    Detail = service.Validation.Select(x => string.Join(" ", x.Messages)).ToArray()
                });

            return Results.Ok(new
            {
                Error = IsSuccessResponse(HttpStatusCode.OK),
                Status = (int)HttpStatusCode.OK,
                Data = OkResult
            });
        }

        public static async Task<IResult> GetByKeyAsync<ViewModel, Model>(
            IBaseReaderService<ViewModel, Model> service,
            Expression<Func<Model, bool>> expr,
            CancellationToken cancellationToken
            )
            where ViewModel : BaseViewModel<Model>
            where Model : BaseModel
        {
            service.ClearValidation();
            try
            {
                var result = await service.GetByKeyAsync(expr, cancellationToken);

                return ResultOperation<ViewModel, Model>(result, service);
            }
            catch (Exception ex)
            {
                return ResultErrorOperation(ex);
            }
        }

        public static async Task<IResult> GetAllPagedAsync<ViewModel, Model>(
            IBaseReaderService<ViewModel, Model> service,
            int page,
            int limit,
            CancellationToken cancellationToken)
            where ViewModel : BaseViewModel<Model>
            where Model : BaseModel
        {
            service.ClearValidation();
            try
            {
                var result = await service.GetAllPagedAsync(
                    page, limit, cancellationToken);

                return ResultPagedOperation<ViewModel, Model>(result, service);
            }
            catch (Exception ex)
            {
                return ResultErrorOperation(ex);
            }
        }

        public static async Task<IResult> GetAllPagedFilteredAsync<ViewModel, Model>(
            IBaseReaderService<ViewModel, Model> service,
            int page,
            int limit,
            Expression<Func<Model, bool>> expr,
            CancellationToken cancellationToken
            )
            where ViewModel : BaseViewModel<Model>
            where Model : BaseModel
        {
            service.ClearValidation();
            try
            {
                var result = await service.GetAllPagedFilteredAsync(
                    page, limit, expr, cancellationToken);
                return ResultPagedOperation<ViewModel, Model>(result, service);
            }
            catch (Exception ex)
            {
                return ResultErrorOperation(ex);
            }
        }

        public static async Task<IResult> RemoveByIdAsync<ViewModel, Model>(
            IBaseWriterService<ViewModel, Model> service,
            Guid id,
            CancellationToken cancellationToken
         )
            where ViewModel : BaseViewModel<Model>
            where Model : BaseModel
        {
            service.ClearValidation();
            try
            {
                var result = await service.RemoveAsync(id, cancellationToken);

                return ResultOperation<ViewModel, Model>(result, service);
            }
            catch (Exception ex)
            {
                return ResultErrorOperation(ex);
            }
        }
    }
}
