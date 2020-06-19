namespace BusinessCard.Insfrastructure.Processes
{
    using System.Threading.Tasks;

    public interface IProcessStep<TResult>
    {
        Task ProcessAsync();

        IProcessStep<TResult> Next { get; set; }

        void SetNext(IProcessStep<TResult> step);

    }
}
