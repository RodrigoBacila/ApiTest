namespace Hangfire
{
    public class FuncJobActivator : JobActivator
    {
        private readonly Func<Type, object> resolver;

        public FuncJobActivator(Func<Type, object> resolver)
        {
            this.resolver = resolver;
        }

        public override object ActivateJob(Type jobType) => resolver(jobType);
    }
}
