namespace BusinessCard.Insfrastructure.Processes
{
    using System.Threading.Tasks;

    public abstract class ProcessContext<TResult> : IProcessContext<TResult>
    {
        public TResult Result { get; set; }

        public abstract Task<TResult> ProcessAsync();
       
    }
}
