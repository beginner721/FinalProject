using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IDataResult<T>:IResult
    {
        //mesaj ve işlem sonucu (true veya false) IResult'dan alınacak, ek olarak T türünde bir data almalıyız
        T Data { get; }
    }
}
