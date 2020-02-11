using Microsoft.EntityFrameworkCore;
using WzHealthCard.Refactor.Api.DataAccess;
using WzHealthCard.Refactor.Api.DataAccess.Erhc;
using WzHealthCard.Refactor.Api.Services.WRefactor;

namespace WzHealthCard.Refactor.Api.Repositories.Erhc
{
    public class PersonSymbolRepository: BaseRepository<PersonSymbolEntity>
    {
        public PersonSymbolRepository(ErhcContext context) : base(context)
        {

        }
    }

}