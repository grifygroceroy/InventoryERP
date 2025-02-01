using Common.Model;
using Common.Persistence;
using Dapper;
using InventoryERP.API.Models;
using MediatR;
using System.Data;

namespace InventoryERP.API.Applogics.Common.Command
{
    public class AddUserMasterCommand : IRequest<ResponseModel>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string RoleId { get; set; }
        protected class AddUserMasterCommandCommandHandler : IRequestHandler<AddUserMasterCommand, ResponseModel>
        {
            private readonly IDal _dal;
            public AddUserMasterCommandCommandHandler(IDal dal)
            {
                _dal = dal;
            }
            public async Task<ResponseModel> Handle(AddUserMasterCommand request, CancellationToken cancellationToken)
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@UserName", request.UserName);
                queryParameters.Add("@Password", request.Password);
                queryParameters.Add("@RoleId", request.RoleId);
                var response = await _dal.GetData<ResponseModel>("[dbo].[AddLoginMaster]", commandType: CommandType.StoredProcedure, parameters: queryParameters).ConfigureAwait(false);
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
