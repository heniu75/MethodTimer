using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

public class  DebugRunner
{

    public static List<string> CaptureDebug(Action action)
    {
        var myTraceListener = new MyTraceListener();
        try
        {
            Debug.Listeners.Add(myTraceListener);
            action();
            Thread.Sleep(1000);
        }
        finally
        {
            Debug.Listeners.Remove(myTraceListener);
        }
        return myTraceListener.messages;
    }

}