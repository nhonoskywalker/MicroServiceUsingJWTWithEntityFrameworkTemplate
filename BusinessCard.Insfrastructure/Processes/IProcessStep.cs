namespace BusinessCard.Insfrastructure.Processes
{
    using System.Threading.Tasks;

    public interface IProcessStep<TResult>
    {
        Task ProcessAsync();

        void SetNext(IProcessStep<TResult> step);

    }
}
