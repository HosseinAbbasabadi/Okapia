﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Okapia.Domain.Models;

namespace Okapia.Repository.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.HasKey(e => e.UserId);

            builder.Property(e => e.UserAddress).HasMaxLength(500);

            builder.Property(e => e.UserBirthDate).HasColumnType("datetime");

            builder.Property(e => e.UserEmail).HasMaxLength(50);

            builder.Property(e => e.UserFirstName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.UserLastName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.UserNationalCode)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(e => e.UserPhoneNumber)
                .IsRequired()
                .HasMaxLength(13);

            builder.Property(e => e.UserPostalCode).HasMaxLength(20);

            builder.Property(e => e.UserRegistrationDate).HasColumnType("datetime");
        }
    }
}