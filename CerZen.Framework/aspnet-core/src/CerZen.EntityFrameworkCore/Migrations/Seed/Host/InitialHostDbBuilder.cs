using CerZen.EntityFrameworkCore;

namespace CerZen.Migrations.Seed.Host
{
    public class InitialHostDbBuilder
    {
        private readonly CerZenDbContext _context;

        public InitialHostDbBuilder(CerZenDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            new DefaultEditionCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();

            _context.SaveChanges();
        }
    }
}
