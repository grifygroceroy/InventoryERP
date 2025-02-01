using Common.Model;
using Common.Persistence;
using Dapper;
using InventoryERP.API.Models;
using MediatR;
using System.Data;

namespace InventoryERP.API.Applogics.Common.Command
{
    public class AddUnitMasterCommand : IRequest<ResponseModel>
    {
     
        public string BaseUnit { get; set; }
        public string SecondryUnit { get; set; }
        protected class AddUnitMasterCommandCommandHandler : IRequestHandler<AddUnitMasterCommand, ResponseModel>
        {
            private readonly IDal _dal;
            public AddUnitMasterCommandCommandHandler(IDal dal)
            {
                _dal = dal;
            }
            public async Task<ResponseModel> Handle(AddUnitMasterCommand request, CancellationToken cancellationToken)
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@BaseUnit", request.BaseUnit);
                queryParameters.Add("@SecondryUnit", request.SecondryUnit);
                var response = await _dal.GetData<ResponseModel>("[dbo].[AddUnityBaseMaster]", commandType: CommandType.StoredProcedure, parameters: queryParameters).ConfigureAwait(false);
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
