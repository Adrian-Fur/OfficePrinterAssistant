﻿using AutoMapper;
using MediatR;
using OfficePrinterAssistant.ApplicationServices.API.Domain;
using OfficePrinterAssistant.DataAccess;
using OfficePrinterAssistant.DataAccess.CQRS.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.ApplicationServices.API.Handlers
{
    public class GetPrinterByIdHandler : IRequestHandler<GetPrinterByIdRequest, GetPrinterByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetPrinterByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetPrinterByIdResponse> Handle(GetPrinterByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetPrinterQuery()
            {
                Id = request.PrinterId
            };

            var printer = await this.queryExecutor.Execute(query);
            var mappedPrinter = this.mapper.Map<Domain.Models.Printer>(printer);
            var response = new GetPrinterByIdResponse()
            {
                Data = mappedPrinter
            };

            return response;
        }
    }
}
