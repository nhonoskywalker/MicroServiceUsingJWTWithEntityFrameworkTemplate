namespace BusinessCard.Insfrastructure.Processes
{
    using System.Threading.Tasks;

    public abstract class ProcessStep<T> : IProcessStep<T>
    {
        private IProcessStep<T> next;

        public IProcessStep<T> Next {
            get { return this.next; }
            private set { }
        }

        public abstract Task ProcessAsync();
      
        public void SetNext(IProcessStep<T> step)
        {
            if (this.Next == null)
            {
                this.next = step;
            }
            else
            {
                this.Next.SetNext(step);
            }
        }
    }
}
