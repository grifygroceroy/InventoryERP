using Common.Model;
using Common.Persistence;
using Dapper;
using MediatR;
using System.Data;

namespace InventoryERP.API.Applogics.Common.Command
{
    public class UpdateRoleMasterCommand : IRequest<ResponseModel>
    {
        public string RoleType { get; set; }
        public string Id { get; set; }
        protected class UpdateRoleMasterCommandHandler : IRequestHandler<UpdateRoleMasterCommand, ResponseModel>
        {
            private readonly IDal _dal;
            public UpdateRoleMasterCommandHandler(IDal dal)
            {
                _dal = dal;
            }
            public async Task<ResponseModel> Handle(UpdateRoleMasterCommand request, CancellationToken cancellationToken)
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@RoleType", request.RoleType);
                queryParameters.Add("@Id", request.Id);
                var response = await _dal.GetData<ResponseModel>("[dbo].[UpdateRoleMaster]", commandType: CommandType.StoredProcedure, parameters: queryParameters).ConfigureAwait(false);
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
