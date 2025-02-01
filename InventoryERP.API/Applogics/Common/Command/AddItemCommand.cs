using Common.Model;
using Common.Persistence;
using Dapper;
using InventoryERP.API.Models;
using MediatR;
using System.Data;

namespace InventoryERP.API.Applogics.Common.Command
{
 
    public class AddItemCommand : IRequest<ResponseModel>
    {
        public ItemModel Item { get; set; }

        protected class AddItemCommandHandler : IRequestHandler<AddItemCommand, ResponseModel>
        {
            private readonly IDal _dal;
            public AddItemCommandHandler(IDal dal)
            {
                _dal = dal;
            }
            public async Task<ResponseModel> Handle(AddItemCommand request, CancellationToken cancellationToken)
            {
                var queryParameters = new DynamicParameters();
                var itemTable = new DataTable();
                itemTable.Columns.Add("ItemCode", typeof(string));
                itemTable.Columns.Add("ItemName", typeof(string));
                itemTable.Columns.Add("CompanyName", typeof(string));
                itemTable.Columns.Add("PurchasePrice", typeof(decimal));
                itemTable.Columns.Add("PurDiscPer", typeof(decimal));
                itemTable.Columns.Add("PurDiscAMT", typeof(decimal));
                itemTable.Columns.Add("SalesPrice", typeof(decimal));
                itemTable.Columns.Add("SalesDiscPer", typeof(decimal));
                itemTable.Columns.Add("SalesDiscAMT", typeof(decimal));
                itemTable.Columns.Add("Discount", typeof(decimal));
                itemTable.Columns.Add("GSTNo", typeof(string));
                itemTable.Columns.Add("HSNCODE", typeof(string));
                itemTable.Columns.Add("BATCHNO", typeof(string));
                itemTable.Columns.Add("UnityId", typeof(int));
                itemTable.Columns.Add("Taxes", typeof(decimal));

                itemTable.Rows.Add(
                    request.Item.ItemCode,
                    request.Item.ItemName,
                    request.Item.CompanyName,
                    request.Item.PurchasePrice,
                    request.Item.PurDiscPer,
                    request.Item.PurDiscAMT,
                    request.Item.SalesPrice,
                    request.Item.SalesDiscPer,
                    request.Item.SalesDiscAMT,
                    request.Item.Discount,
                    request.Item.GSTNo,
                    request.Item.HSNCODE,
                    request.Item.BATCHNO,
                    request.Item.UnityId,
                    request.Item.Taxes
                );

                var unityTable = new DataTable();
                unityTable.Columns.Add("Box", typeof(int));
                unityTable.Columns.Add("Piece", typeof(int));
                unityTable.Rows.Add(request.Item.unitylist.Box, request.Item.unitylist.Piece);

                queryParameters.Add("@ItemMasterData", itemTable.AsTableValuedParameter("dbo.ItemMasterType"));
                queryParameters.Add("@UnityMasterData", unityTable.AsTableValuedParameter("dbo.UnityMasterType"));

                var response = await _dal.GetData<ResponseModel>("[dbo].[InsertItemMaster]", commandType: CommandType.StoredProcedure, parameters: queryParameters).ConfigureAwait(false);
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
