# PoC to investigate StackOverflow exception in Azure FunctionApp


### Capture a StackOverflowException and make a dump 0xc00000fd

https://blogs.msdn.microsoft.com/benjaminperkins/2017/06/28/capture-a-stackoverflowexception-and-make-a-dump-0xc00000fd/

---

### Preparation

1. Azure Subscription for below resources.
1. FunctionApp
1. Storage (for the function)
1. Create local.settings.json file (local.settings.sample.json is an example)
1. Deploy the functions

---

### Step
1. Run "Function1" to know Process ID
1. Move to the function's "Kidu"
1. Select "Process explorer" tab to remember Process ID of w3wp.exe (non scm instance)
1. Select "Debug console" tab.
1. make a new directory in LogFiles then move current folder to it.
1. Execute below command (*1) to listen a stack overflow exception.
1. Run "Function2" to throw stack overflow exception.
1. Wait for crush dump created completely.
1. Download the crush dump file
1. Investigate the dump file with WinDbg.

#### *1 Command  
d:\devtools\sysinternals\procdump -accepteula -e 1 -f C00000FD.STACK_OVERFLOW -g -ma ***process id***
