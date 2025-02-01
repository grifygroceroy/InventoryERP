using Common.Model;
using Common.Persistence;
using Dapper;
using MediatR;
using System.Data;

namespace InventoryERP.API.Applogics.Common.Command
{
    public class DeleteRoleMasterCommand : IRequest<ResponseModel>
    {
        public int Id { get; set; }
        protected class DeleteRoleMasterCommandHandler : IRequestHandler<DeleteRoleMasterCommand, ResponseModel>
        {
            private readonly IDal _dal;
            public DeleteRoleMasterCommandHandler(IDal dal)
            {
                _dal = dal;
            }
            public async Task<ResponseModel> Handle(DeleteRoleMasterCommand request, CancellationToken cancellationToken)
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Id", request.Id);
                var response = await _dal.GetData<ResponseModel>("[dbo].[DeleteRoleMaster]", commandType: CommandType.StoredProcedure, parameters: queryParameters).ConfigureAwait(false);
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
