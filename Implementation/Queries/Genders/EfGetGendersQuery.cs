using Application.DataTransfer;
using Application.Queries;
using AutoMapper;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.Genders
{
    public class EfGetGendersQuery : IGetGendersQuery
    {
        private readonly ShoeStoreContext _context;
        private readonly IMapper _mapper;

        public EfGetGendersQuery(ShoeStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 403;

        public string Name => "Show Genders using Ef";

        public IEnumerable<GenderDto> Execute()
        {
            var gender = _context.Genders.ToList();
            return _mapper.Map<IEnumerable<GenderDto>>(gender);
        }
    }
}
