using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCleaner.CommonUtils
{
    internal class ProgressDialogResult
    {
        #region [ Properties ]

        public object Result { get; private set; }
        public bool Cancelled { get; private set; }
        public Exception Error { get; private set; }

        public bool OperationFailed
        {
            get { return Error != null; }
        }

        #endregion

        public ProgressDialogResult(RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
                Cancelled = true;
            else if (e.Error != null)
                Error = e.Error;
            else
                Result = e.Result;
        }
    }
}
