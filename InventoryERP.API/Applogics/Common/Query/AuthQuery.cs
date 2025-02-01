using Common.Identity;
using Common.Identity.Models;
using Common.Model;
using Common.Persistence;
using Dapper;
using InventoryERP.API.Models;
using MediatR;
using Newtonsoft.Json.Linq;
using System.Data;

namespace InventoryERP.API.Applogics.Common.Query
{
    public class AuthQuery : IRequest<ResponseModel>
    {
        public Login login { get; set; }
        protected class AuthQueryHandler : IRequestHandler<AuthQuery, ResponseModel>
        {
            private readonly IDal _dal;
            private readonly IIdentityService _identityService;
            public AuthQueryHandler(IDal dal, IIdentityService identityService)
            {
                _dal = dal;
                _identityService = identityService;
            }
            public async Task<ResponseModel> Handle(AuthQuery request, CancellationToken cancellationToken)
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@UserName", request.login.UserName);
                queryParameters.Add("@Password", request.login.Password);
                var response = await _dal.GetData<ResponseModel>("[dbo].[IsValidUser]", commandType: CommandType.StoredProcedure, parameters: queryParameters).ConfigureAwait(false);
                if (response.Code == 0)
                {
                    return new ResponseModel
                    {
                        Code = response.Code,
                        Message = response.Message,
                        Data = null
                    };
                }

                var RoleParameters = new DynamicParameters();
                RoleParameters.Add("@UserName", request.login.UserName);
                RoleParameters.Add("@Password", request.login.Password);
                string UserRole = await _dal.GetScalarStringData("[dbo].[GetUserRole]", commandType: CommandType.StoredProcedure, parameters: queryParameters).ConfigureAwait(false);
               
                var token = _identityService.GenerateJwtToken(new LoginModel { UserName = request.login.UserName, UserRole = UserRole });
                return new ResponseModel
                {
                    Code = 1,
                    Message = "Success",
                    Data = new Token
                    {
                        token = token.Result
                    }
                };
            }
        }
    }

}

public class Token
{
    public string token { get; set; }
}
