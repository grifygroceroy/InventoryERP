using Common.Model;
using Common.Persistence;
using Dapper;
using InventoryERP.API.Models;
using MediatR;
using System.Data;

namespace InventoryERP.API.Applogics.Common.Command
{
    public class AddRoleMasterCommand : IRequest<ResponseModel>
    {
        public AddRoleMaster AddRole { get; set; }
        protected class AddRoleMasterCommandHandler : IRequestHandler<AddRoleMasterCommand, ResponseModel>
        {
            private readonly IDal _dal;
            public AddRoleMasterCommandHandler(IDal dal)
            {
                _dal = dal;
            }
            public async Task<ResponseModel> Handle(AddRoleMasterCommand request, CancellationToken cancellationToken)
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@RoleType", request.AddRole.RoleType);
                var response = await _dal.GetData<ResponseModel>("[dbo].[AddRoleMaster]", commandType: CommandType.StoredProcedure, parameters: queryParameters).ConfigureAwait(false);
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
