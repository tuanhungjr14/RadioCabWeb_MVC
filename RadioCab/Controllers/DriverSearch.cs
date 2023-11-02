using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RadioCab.DataAccess.Data;

namespace RadioCab.Controllers
{
    public class DriverSearch
    {
        private readonly ApplicationDbContext _context;

        public DriverSearch(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<IdentityUser> GetUsers()
        {
            // Thực hiện truy vấn từ DbContext
            var usersFromDb = _context.Users.ToList();

            // Chuyển đổi dữ liệu từ cơ sở dữ liệu thành UserModel
            var users = usersFromDb.Select(u => new IdentityUser
            {
                Id = u.Id,
                PhoneNumber = u.PhoneNumber,
                // Sao chép các giá trị khác từ 'u' sang UserModel
            }).ToList();

            return users;
        }
    }

}
