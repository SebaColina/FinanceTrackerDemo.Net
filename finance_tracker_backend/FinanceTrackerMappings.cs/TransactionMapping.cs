using AutoMapper;

public class TransactionMapping : Profile
{
    public TransactionMapping()
    {
        CreateMap<Transaction, TransactionDto>();
    }
}
