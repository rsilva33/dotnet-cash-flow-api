using AutoMapper;

namespace CashFlow.Application.AutoMapper;

public class AutoMapping : Profile
{

    public AutoMapping()
    {
        RequestToEntity();
        EntityToResponse();
    }
    private void RequestToEntity()
    {
        // De onde vem, para onde vai
        CreateMap<RequestExpenseJson, Expense>();
        CreateMap<RequestRegisterUserJson, User>()
            .ForMember(dest => dest.Password, config => config.Ignore());
    }

    private void EntityToResponse()
    {
        CreateMap<Expense, ResponseRegisteredExpenseJson>();
        CreateMap<Expense, ResponseShortExpenseJson>();
        CreateMap<Expense, ResponseExpenseJson>();
    }
}
