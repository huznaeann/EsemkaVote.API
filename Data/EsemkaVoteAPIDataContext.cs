using EsemkaVote.API.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace EsemkaVote.API.Data
{
    public class EsemkaVoteAPIDataContext(DbContextOptions option) : DbContext(option)
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<VotingHeader> VotingHeaders { get; set; }
        public DbSet<VotingCandidate> VotingCandidates { get; set; }
        public DbSet<VotingDetail> VotingDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<VotingCandidate>()
                .HasOne(x => x.Employee)
                .WithMany()
                .HasForeignKey(x => x.employeeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<VotingDetail>()
                .HasOne(x => x.Employee)
                .WithMany()
                .HasForeignKey(x => x.employeeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
