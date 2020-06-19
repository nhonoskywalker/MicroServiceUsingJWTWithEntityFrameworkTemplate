namespace BusinessCard.Insfrastructure.Processes
{
    using System.Threading.Tasks;

    public interface IProcessContext<TResult>
    {
        TResult Result { get; set; }
    }
}
