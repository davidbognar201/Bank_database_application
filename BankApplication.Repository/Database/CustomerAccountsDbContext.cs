using BankApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Repository
{
    public class CustomerAccountsDbContext : DbContext
    {
        public DbSet<BankCard> BankCardDb { get; set; }
        public DbSet<Customer> CustomerDb { get; set; }
        public DbSet<CurrentAccount> CurrentAccountDb { get; set; }

        public CustomerAccountsDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().UseInMemoryDatabase("CurrentAccountDb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<Customer>(customer => customer
            //            .HasMany(customer => customer.CustomerAccounts)
            //            .WithOne(account => account.AccountOwner)
            //            .HasForeignKey(customer => customer.OwnerId)
            //            .OnDelete(DeleteBehavior.Cascade)
            //        );

            //modelBuilder.Entity<CurrentAccount>(account => account
            //            .HasMany(account => account.AttachedCards)
            //            .WithOne(card => card.AttachedAccount)
            //            .HasForeignKey(account => account.AttachedAccountId)
            //            .OnDelete(DeleteBehavior.Cascade)
            //        );

            modelBuilder.Entity<BankCard>(x => x
                        .HasOne(x => x.AttachedAccount)
                        .WithMany(x => x.AttachedCards)
                        .HasForeignKey(x => x.AttachedAccountId)
                        .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<CurrentAccount>(x => x
                           .HasOne(x => x.AccountOwner)
                           .WithMany(x => x.CustomerAccounts)
                           .HasForeignKey(x => x.OwnerId)
                           .OnDelete(DeleteBehavior.Cascade));


            modelBuilder.Entity<Customer>().HasData(new Customer[]
            {
                new Customer(1, "Kovács Attila", 1995, 4, 321000, "Iran"),
                new Customer(2, "Dr. Kiss Béla", 1998, 2, 635212, "Hungary"),
                new Customer(3, "Kiss Géza", 2001, 8, 133000, "Croatia"),
                new Customer(4, "Bognár Dávid", 1965, 3, 10000, "Hungary"),
                new Customer(5, "Nagy Árpád", 2002, 6, 321000, "France")
            });
            modelBuilder.Entity<CurrentAccount>().HasData(new CurrentAccount[]
            {
                new CurrentAccount(1, 2, "HUF", 3),
                new CurrentAccount(2, 100, "EUR", 4),
                new CurrentAccount(3, 50, "GBP", 5),
                new CurrentAccount(4, 3000, "RUB", 1),
                new CurrentAccount(5, 3200, "EUR", 1),
                new CurrentAccount(6, 0, "HUF", 2)
            });
            modelBuilder.Entity<BankCard>().HasData(new BankCard[]
            {
                new BankCard(1, "6438-4235-2353-2234", "Visa", false, 2),
                new BankCard(2, "2443-7543-2334-3233", "Mastercard", false, 1),
                new BankCard(3, "7655-3434-2424-4242", "Mastercard", false, 4),
                new BankCard(4, "2276-4545-3532-4243", "Visa", false, 3),
                new BankCard(5, "5355-1545-3418-5422", "Visa", false, 5),
                new BankCard(6, "4343-1653-4324-9743", "Visa", false, 2)
            });

        }
    }
}
