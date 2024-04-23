using MayTheFourth.Entities;
using MayTheFourth.Utils.Validation;

namespace MayTheFourth.Services.ViewModels
{
    public class BaseViewModel<T> where T : BaseModel
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual T GetEntity() => 
            throw new NotImplementedException("Falta criar a conversão da classe");

        public virtual ValidationViewModel IsValid() =>
            ValidationViewModel.Create(ValidationModelResult.Success);

    }
}
