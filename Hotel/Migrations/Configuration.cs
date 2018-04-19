using Hotel.Models;

namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Hotel.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Hotel.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.ApTypes.AddOrUpdate(new ApType()
            {
                TypeId = 1,
                Description = "���� ����������� ���������� - ����������� ����� � ��������: ������� � �������� ���������, ������� ������ � ����������� ����� ������� ��������: �����, ����������, �����, ���, �������. ��������� ��������, ������������ ������ � ������� ����. ����������� �����������, ��������, �����������, ������������ ��������, �������.",
                Name = "��������",
                NumOfPerson = 2,
                Price = 1800M
            });
            context.ApTypes.AddOrUpdate(new ApType()
            {
                TypeId = 2,
                Description = "���� ����������� ���������� - ����������� ����� � ��������: ������� � �������� ���������, ������� ������ � ����������� ����� ������� ��������: �����, ����������, �����, ���, �������. ��������� ��������, ������������ ������ � ������� ����. ����������� �����������, ��������, �����������, ������������ ��������, �������.",
                Name = "�������� ����",
                NumOfPerson = 2,
                Price = 1800M
            });
            context.ApTypes.AddOrUpdate(new ApType()
            {
                TypeId = 3,
                Description = "���� ����������� ���������� - ����������� ����� � ��������: ������� � �������� ���������, ������� ������ � ����������� ����� ������� ��������: �����, ����������, �����, ���, �������. ��������� ��������, ������������ ������ � ������� ����. ����������� �����������, ��������, �����������, ������������ ��������, �������.",
                Name = "��������",
                NumOfPerson = 2,
                Price = 1800M
            });
            context.ApTypes.AddOrUpdate(new ApType()
            {
                TypeId = 4,
                Description = "���� ����������� ���������� - ����������� ����� � ��������: ������� � �������� ���������, ������� ������ � ����������� ����� ������� ��������: �����, ����������, �����, ���, �������. ��������� ��������, ������������ ������ � ������� ����. ����������� �����������, ��������, �����������, ������������ ��������, �������.",
                Name = "����",
                NumOfPerson = 2,
                Price = 1800M
            });
        }
    }
}
