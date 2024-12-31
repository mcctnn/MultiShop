using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
    public class DiscountManager : IDiscountService
    {
        private readonly DapperContext _dapperContext;

        public DiscountManager(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task CreateCouponAsync(CreateCouponDto createCouponDto)
        {
            var query = "INSERT INTO Coupons (Code, Rate, IsActive,ValidDate) VALUES (@Code, @Rate, @IsActive,@ValidDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@Code", createCouponDto.Code);
            parameters.Add("@Rate", createCouponDto.Rate);
            parameters.Add("@IsActive", createCouponDto.IsActive);
            parameters.Add("@ValidDate", createCouponDto.ValidDate);
            using (var con = _dapperContext.CreateConnection())
            {
                await con.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteCouponAsync(int id)
        {
            var query = "DELETE FROM Coupons WHERE CouponId = @CouponId";
            var parameters = new DynamicParameters();
            parameters.Add("@CouponId", id);
            using (var con = _dapperContext.CreateConnection())
            {
                await con.ExecuteAsync(query, parameters);
            }
        }

        public async Task<GetByIdCouponDto> GetCouponByIdAsync(int id)
        {
            string query = "SELECT * FROM Coupons WHERE CouponId = @CouponId";
            var parameters = new DynamicParameters();
            parameters.Add("@CouponId", id);
            using (var con = _dapperContext.CreateConnection())
            {
               return await con.QueryFirstOrDefaultAsync<GetByIdCouponDto>(query,parameters);
            }
        }

        public async Task<List<ResultCouponDto>> GetCouponsAsync()
        {
            string query = "SELECT * FROM Coupons";
            using (var con = _dapperContext.CreateConnection())
            {
                var values=await con.QueryAsync<ResultCouponDto>(query);
                return values.ToList(); 
            }
        }

        public async Task UpdateCouponAsync(UpdateCouponDto updateCouponDto)
        {
            string query = "UPDATE Coupons SET Code = @Code, Rate = @Rate, IsActive = @IsActive, ValidDate = @ValidDate WHERE CouponId = @CouponId";
            var parameters = new DynamicParameters();
            parameters.Add("@Code", updateCouponDto.Code);
            parameters.Add("@Rate", updateCouponDto.Rate);
            parameters.Add("@IsActive", updateCouponDto.IsActive);
            parameters.Add("@ValidDate", updateCouponDto.ValidDate);
            parameters.Add("@CouponId", updateCouponDto.CouponId);
            using (var con = _dapperContext.CreateConnection())
            {
                await con.ExecuteAsync(query,parameters);
            }
        }
    }
}
