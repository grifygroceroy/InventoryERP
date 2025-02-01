using Common.Model;
using Common.Persistence;
using Dapper;
using InventoryERP.API.Models;
using MediatR;
using System.Data;

namespace InventoryERP.API.Applogics.Common.Query
{
    public class GetRoleMasterQuery : IRequest<ResponseModel>
    {
        public string RoleType { get; set; }=string.Empty;
        protected class GetRoleMasterQueryHandler : IRequestHandler<GetRoleMasterQuery, ResponseModel>
        {
            private readonly IDal _dal;
            public GetRoleMasterQueryHandler(IDal dal)
            {
                _dal = dal;
            }
            public async Task<ResponseModel> Handle(GetRoleMasterQuery request, CancellationToken cancellationToken)
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@RoleType", request.RoleType);
                var queryResult = await _dal.RunMultipleQueryAsync("[dbo].[GetRoleMaster]", commandType: CommandType.StoredProcedure, parameters: queryParameters).ConfigureAwait(false);
                var Response = (List<RoleMasterModel>)await queryResult.Item2.ReadAsync<RoleMasterModel>() ?? new List<RoleMasterModel>();
                return new ResponseModel
                {
                    Code = 1,
                    Message = "Success",
                    Data = Response,
                };
            }
        }
    }

}
