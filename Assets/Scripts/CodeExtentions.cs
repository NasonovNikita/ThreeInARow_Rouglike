using System.Collections.Generic;
using System.Linq;

public class MyList<TYpe> : List<TYpe>
{
    public List<T> FindAndCast<T>()
    {
        return this.Where(log => log is T).Cast<T>().ToList();
    }
}