

using Dapper;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MemberShipManagement_CleanArchitecture.Infrastructure.Members
{
    public class MemberRepository : IMemberRepository
    {
        
        private readonly ApplicationDbContext _context;
        private readonly IDapperDbContext _dapperContext;


        public MemberRepository(ApplicationDbContext dbContext, IDapperDbContext dapperDbContext)
        {
            _context = dbContext;
            _dapperContext = dapperDbContext;

        }


        public async Task CreateAsync(Member member)
        {
            await _context.Members.AddAsync(member);
        }


        public Task DeleteAsync(Member member)
        {
             _context.Members.Remove(member);
            return Task.CompletedTask;
        }

        public async void EmailAndPhoneValdator(string email, string phone)
        {

            using (var conn = _dapperContext.CreateConnection())
            {
                var emailQuery = "SELECT Email FROM Members WHERE Email = @Email";
                var phoneQuery = "SELECT PhoneNo FROM Members WHERE PhoneNo = @Phone";

                var existingEmail = await conn.QueryAsync<string>(emailQuery, new { Email = email });
                if (existingEmail.Any())
                {
                    throw new ArgumentException("This Email is Already Exists!");
                }

                var existingPhone = await conn.QuerySingleOrDefaultAsync<string>(phoneQuery, new { Phone = phone });
                if (existingPhone != null)
                {
                    throw new ArgumentException("This Phone Number is Already Exists!");
                }

            }
        }




        public async Task<Member> GetById(int a)
        {
            return await _context.Members.FirstOrDefaultAsync(m => m.MemberId == a);
        }



        public async Task<List<Membership>> GetDueMemberPackagesAsync()
        {
            var currentDate = DateTime.Now;

            var dueMemberPackages = await _context.Members
                .Include(m => m.Memberships)
                .ThenInclude(mp => mp.Package)
                .Where(m => m.Memberships.Any(mp => mp.EndDate < currentDate && !_context.Payments.Any(p => p.MembershipId == mp.MembershipId && p.PaymentDate.Date == currentDate.Date))).SelectMany(m => m.Memberships).ToListAsync();

            return dueMemberPackages;
        }


        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Member member)
        {
         
            _context.Entry(member).State = EntityState.Modified;
        }

      


        //private bool IsImageFileValid(string fileName)
        //{
        //    string extension = Path.GetExtension(fileName).ToLower();
        //    return extension == ".jpg" || extension == ".jpeg" || extension == ".png";
        //}


    }
}
