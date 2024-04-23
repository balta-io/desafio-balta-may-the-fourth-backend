using MayTheFourth.Utils.Validation;

namespace MayTheFourth.Services.Interfaces
{
    public interface IErrorBaseService
    {
        List<ValidationViewModel> Validation { get; set; }
        void ClearValidation();
    }
}
