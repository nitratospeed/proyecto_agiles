using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Certificados.Queries.GetCertificados
{
    public class GetCertificadosQuery : IRequest<PaginatedList<CertificadoDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class GetCertificadosQueryHandler : IRequestHandler<GetCertificadosQuery, PaginatedList<CertificadoDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCertificadosQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<CertificadoDto>> Handle(GetCertificadosQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Certificados
                .ProjectTo<CertificadoDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);

            return result;
        }
    }
}
