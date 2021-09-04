using DataFactory;
using ModelFactory.Users;
using System.Linq;

namespace BusinessFactory.Users
{
    public class BALDimMbr : IBALDimMbr
    {
        MyOwnContext objMyOwnMedContext;

        public BALDimMbr(MyOwnContext _MyOwnMedContext)
        {
            objMyOwnMedContext = _MyOwnMedContext;
        }

        public DimMbr GetMember(int _MemverId)
        {
            return objMyOwnMedContext.entDimMbr.Where(F => F.MbrId == _MemverId).FirstOrDefault();
        }
    }
}
