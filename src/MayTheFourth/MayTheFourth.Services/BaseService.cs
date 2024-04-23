using MayTheFourth.Entities;
using MayTheFourth.Repositories.Repositories.Interfaces;
using MayTheFourth.Services.Interfaces;
using MayTheFourth.Services.Mappers;
using MayTheFourth.Services.ViewModels;
using MayTheFourth.Utils.Paging;
using MayTheFourth.Utils.Validation;
using NetSwissTools.System;
using System.Linq.Expressions;

namespace MayTheFourth.Services
{
    public class BaseService<ViewModel, Model>(
            IBaseReaderRepository<Model> repositoryReader,
            IBaseWriterRepository<Model> repositoryWriter
        ) :
        IBaseReaderService<ViewModel, Model>,
        IBaseWriterService<ViewModel, Model>,
        IErrorBaseService
        where ViewModel : BaseViewModel<Model>
        where Model : BaseModel
    {
        public List<ValidationViewModel> Validation { get; set; } = [];

        public void ClearValidation() =>
            Validation.Clear();

        public async virtual Task<ViewModel?> CreateAsync(ViewModel value, CancellationToken cancellation)
        {
            ClearValidation();
            try
            {
                var vmValidation = value.IsValid();

                if (vmValidation.Error)
                {
                    Validation.Add(vmValidation);
                    return null;
                }

                var entity = value.GetEntity();

                if (entity == null)
                {
                    Validation.Add(ValidationViewModel.Create(
                        ValidationModelResult.Fail,
                        Utils.Properties.Resources.InvalidConversion));
                    return null;
                }
                entity.Id = Guid.NewGuid();
                entity.CreatedAt = DateTime.Now;
                entity.UpdatedAt = DateTime.Now;

                repositoryWriter.Add(entity);

                await repositoryWriter.SaveChangesAsync(cancellation);

                value.Id = entity.Id;
                return value;
            }
            catch (Exception ex)
            {
                Validation.Add(
                    ValidationViewModel.Create(ValidationModelResult.Fail,
                    ex)
                );
                return null;
            }
        }

        public async virtual Task<ViewModel?> ChangeAsync(ViewModel value, CancellationToken cancellation)
        {
            ClearValidation();
            try
            {
                var vmValidation = value.IsValid();

                if (vmValidation.Error)
                {
                    Validation.Add(vmValidation);
                    return null;
                }

                var EntityOld = await repositoryReader.GetByKeyAsync(
                    x => x.Id == value.Id, cancellation);

                if (EntityOld == null)
                {
                    Validation.Add(ValidationViewModel.Create(
                        ValidationModelResult.Fail,
                        Utils.Properties.Resources.RegisterNotFound));
                    return null;
                }

                var entity = value.GetEntity();

                if (entity == null)
                {
                    Validation.Add(ValidationViewModel.Create(
                        ValidationModelResult.Fail,
                        Utils.Properties.Resources.InvalidConversion));
                    return null;
                }

                EntityOld.CopyProperties(entity);
                EntityOld.UpdatedAt = DateTime.Now;

                repositoryWriter.Update(EntityOld);

                await repositoryWriter.SaveChangesAsync(cancellation);

                value.Id = EntityOld.Id;
                return value;
            }
            catch (Exception ex)
            {
                Validation.Add(
                    ValidationViewModel.Create(ValidationModelResult.Fail,
                    ex)
                );
                return null;
            }
        }

        public async virtual Task<ViewModel?> RemoveAsync(Guid key, CancellationToken cancellation)
        {
            ClearValidation();
            try
            {
                var EntityRemoved = await repositoryWriter
                    .RemoveByKeyAsync(x => x.Id == key, cancellation);

                if (EntityRemoved == null)
                {
                    Validation.Add(ValidationViewModel.Create(
                        ValidationModelResult.Fail,
                        Utils.Properties.Resources.RegisterNotFound));
                    return null;
                }

                await repositoryWriter.SaveChangesAsync(cancellation);

                return MapperModel.Map<Model, ViewModel>(EntityRemoved);
            }
            catch (Exception ex)
            {
                Validation.Add(
                    ValidationViewModel.Create(ValidationModelResult.Fail,
                    ex)
                );
                return null;
            }
        }

        public async virtual Task<PageListResult<ViewModel>> GetAllPagedAsync(int page, int pageSize, CancellationToken cancellation)
        {
            ClearValidation();
            try
            {
                var result = await repositoryReader.GetAllPagedAsync(page, pageSize, cancellation);

                return MapperModel.Map<PageListResult<Model>, PageListResult<ViewModel>>(result);
            }
            catch (Exception ex)
            {
                Validation.Add(
                    ValidationViewModel.Create(ValidationModelResult.Fail,
                    ex)
                );
                return new PageListResult<ViewModel>();
            }
        }

        public async virtual Task<PageListResult<ViewModel>> GetAllPagedFilteredAsync(int page, int pageSize, Expression<Func<Model, bool>> expr, CancellationToken cancellation)
        {
            ClearValidation();
            try
            {
                var result = await repositoryReader.GetAllPagedFilteredAsync(page, pageSize, expr, cancellation);

                return MapperModel.Map<PageListResult<Model>, PageListResult<ViewModel>>(result);
            }
            catch (Exception ex)
            {
                Validation.Add(
                    ValidationViewModel.Create(ValidationModelResult.Fail,
                    ex)
                );
                return new PageListResult<ViewModel>();
            }
        }

        public async virtual Task<ViewModel?> GetByKeyAsync(Expression<Func<Model, bool>> expr, CancellationToken cancellation)
        {
            ClearValidation();
            try
            {
                var Result = await repositoryReader.GetByKeyAsync(expr, cancellation);

                if (Result == null)
                    return null;

                return MapperModel.Map<Model, ViewModel>(Result);
            }
            catch (Exception ex)
            {
                Validation.Add(
                    ValidationViewModel.Create(ValidationModelResult.Fail,
                    ex)
                );
                return null;
            }
        }

        public void Dispose()
        {
            repositoryReader?.Dispose();
            repositoryWriter?.Dispose();
        }
    }
}
