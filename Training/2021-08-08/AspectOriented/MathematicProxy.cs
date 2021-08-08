using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.Text;
using System.Threading.Tasks;

namespace AspectOriented
{
    public class MathematicProxy : RealProxy
    {
        private readonly Mathematic math;

        public MathematicProxy(Mathematic math) : base(math.GetType())
        {
            this.math = math;
        }

        public override IMessage Invoke(IMessage msg)
        {
            IMethodCallMessage methodMessage = msg as IMethodCallMessage;

            if (methodMessage != null)
            {
                for (int i = 0; i < methodMessage.InArgs.Length; i++)
                {
                    object item = methodMessage.InArgs[i];
                    Console.WriteLine("Parametre" + i + ": " + item);
                }
                Stopwatch sw = new Stopwatch();
                sw.Start();
                var result = methodMessage.MethodBase.Invoke(math, methodMessage.InArgs);
                sw.Stop();

                Console.WriteLine(sw.ElapsedTicks);

                return new ReturnMessage(result, null, 0, methodMessage.LogicalCallContext, methodMessage);
            }

            return null;
        }
    }
}
