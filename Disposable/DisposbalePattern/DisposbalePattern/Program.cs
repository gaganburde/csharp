using System;

namespace DisposbalePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    class DisposableSamaple : IDisposable
    {
        // if we forget to call dispose method we will implement finalizer
        ~DisposableSamaple()
        {
            Console.WriteLine("IN destructor");
            // we just need to release unmanaged reources
            Dispose(false);
        }
        // call dispose method directly=>to release manged and unmanged resource
        public void Dispose()
        {
            Dispose(true);
          // we need to avoid call finalizer for this object as it is already removed 
            GC.SuppressFinalize(this);
        }

        // this flag if user call dispose twice
        bool isDisposed = false;
        protected virtual void Dispose(bool isDisposing)
        {
            if(isDisposed)
            {
                return;
            }
            if(isDisposing)
            {
                // clean up managed resources
            }
            // clean up unmanged resource

            isDisposed = true;
        }

    }

}
