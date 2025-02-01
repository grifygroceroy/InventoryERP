using Common.Model;
using Common.Persistence;
using Dapper;
using InventoryERP.API.Models;
using MediatR;
using System.Data;

namespace InventoryERP.API.Applogics.Common.Command
{
    public class AddPurchaseItemCommand : IRequest<ResponseModel>
    {
        public AddPurchaseItem purchase { get; set; }
        protected class AddPurchaseItemCommandHandler : IRequestHandler<AddPurchaseItemCommand, ResponseModel>
        {
            private readonly IDal _dal;
            public AddPurchaseItemCommandHandler(IDal dal)
            {
                _dal = dal;
            }
            public async Task<ResponseModel> Handle(AddPurchaseItemCommand request, CancellationToken cancellationToken)
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@BillNo", request.purchase.BillNo);
                queryParameters.Add("@BillDate", request.purchase.BillDate);
                queryParameters.Add("@CompanyId", request.purchase.CompanyId);
                queryParameters.Add("@TaxTypeId", request.purchase.TaxTypeId);
                queryParameters.Add("@ItemId", request.purchase.ItemId);
                queryParameters.Add("@Quantity", request.purchase.Quantity);
                queryParameters.Add("@Price", request.purchase.Price);
                queryParameters.Add("@UnityId", request.purchase.UnityId);
                queryParameters.Add("@DiscountPer", request.purchase.DiscountPer);
                queryParameters.Add("@DiscountAMT", request.purchase.DiscountAMT);
                queryParameters.Add("@GSTTypeId", request.purchase.GSTTypeId);
                queryParameters.Add("@GSTPer", request.purchase.GSTPer);
                queryParameters.Add("@TotalAmount", request.purchase.TotalAmount);
                queryParameters.Add("@CreatedBy", request.purchase.CreatedBy);
                var response = await _dal.GetData<ResponseModel>("[dbo].[AddPurchaseItem]", commandType: CommandType.StoredProcedure, parameters: queryParameters).ConfigureAwait(false);
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
