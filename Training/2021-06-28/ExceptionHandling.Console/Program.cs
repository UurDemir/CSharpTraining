using System;
using System.Diagnostics;
using System.Runtime.ExceptionServices;

namespace ExceptionHandling.Consol
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        #region FailFast
        private static void TestFailFast()
        {
            try
            {
                TryCatchFinally(false);
            }
            catch (Exception)
            {

            }
            try
            {
                TryCatchFinally(true);
            }
            catch (Exception)
            {

            }
        }

        private static void TryCatchFinally(bool ignoreFinally)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception exception)
            {
                if (ignoreFinally) Environment.FailFast("Finally block will not run", exception);

                throw;
            }
            finally
            {
                Console.WriteLine("Finally Block");
            }


            Console.WriteLine("Other Block");
        } 
        #endregion

        #region ExceptionDispatchInfo
        private static void ThrowDispatch(ExceptionDispatchInfo dispatchInfo)
        {
            try
            {
                dispatchInfo.Throw();
            }
            catch (Exception exception)
            {

                throw;
            }
        }
        private static ExceptionDispatchInfo ExceptionDispatchInfoTest()
        {
            ExceptionDispatchInfo captureContext;
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception exception)
            {
                captureContext = ExceptionDispatchInfo.Capture(exception);
            }
            return captureContext;
        }

        private static void TestExceptionDispatchInfo()
        {
            var dispatchInfo = ExceptionDispatchInfoTest();
            ThrowDispatch(dispatchInfo);
        }

        #endregion

        #region  StackTrace
        private static int Method3()
        {
            int number = Method2();
            return number + 1;
        }
        private static int Method2()
        {
            int number = Method1();
            return number + 1;
        }
        private static int Method1()
        {
            int number = GetStackTrace();
            return number + 1;
        }

        private static int ThrowException()
        {
            try
            {
                throw new("Throwed Exception");
            }
            catch (Exception exception)
            {
                StackTrace stackTract = new(exception, true);
                StackFrame[] stackFrames = stackTract.GetFrames();

                foreach (var stackFrame in stackFrames)
                {

                }


                throw;
            }
            return 40;
        }



        private static int GetStackTrace()
        {
            StackTrace stackTract = new(true);
            StackFrame[] stackFrames = stackTract.GetFrames();

            foreach (var stackFrame in stackFrames)
            {

            }

            return 40;
        }
        #endregion
    }
}
