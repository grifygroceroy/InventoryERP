using Common.Model;
using Common.Persistence;
using Dapper;
using InventoryERP.API.Models;
using MediatR;
using System.Data;

namespace InventoryERP.API.Applogics.Common.Command
{
    public class AddPartyCommand : IRequest<ResponseModel>
    {
        public AddPartyModel Party { get; set; }
        protected class AddPartyCommandHandler : IRequestHandler<AddPartyCommand, ResponseModel>
        {
            private readonly IDal _dal;
            public AddPartyCommandHandler(IDal dal)
            {
                _dal = dal;
            }
            public async Task<ResponseModel> Handle(AddPartyCommand request, CancellationToken cancellationToken)
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@PartyName", request.Party.PartyName);
                queryParameters.Add("@State", request.Party.State);
                queryParameters.Add("@Country", request.Party.Country);
                queryParameters.Add("@City", request.Party.City);
                queryParameters.Add("@Address", request.Party.Address);
                queryParameters.Add("@GSTNo", request.Party.GSTNo);
                queryParameters.Add("@PhoneNo", request.Party.PhoneNo);
                queryParameters.Add("@WhatsAppNo", request.Party.WhatsAppNo);
                queryParameters.Add("@EmailID", request.Party.EmailID);
                queryParameters.Add("@AAdharCardNo", request.Party.AAdharCardNo);
                queryParameters.Add("@PanCardNo", request.Party.PanCardNo);
                queryParameters.Add("@AdditionField", request.Party.AdditionField);
                queryParameters.Add("@OpeningBalance", request.Party.OpeningBalance);
                queryParameters.Add("@OpeningBalanceDate", request.Party.OpeningBalanceDate);
                queryParameters.Add("@PartyType", request.Party.PartyType);
                queryParameters.Add("@CreatedBy","Admin");
                var response = await _dal.GetData<ResponseModel>("[dbo].[AddPartiesMaster]", commandType: CommandType.StoredProcedure, parameters: queryParameters).ConfigureAwait(false);
                return new ResponseModel
                {
                    Code = response.Code,
                    Message = response.Message,
                    Data = null,
                };
            }
        }
    }
}
