//using System.Collections.Generic;
//using Vidly.Models;

//namespace Vidly.Migrations
//{
//    using System;
//    using System.Data.Entity.Migrations;
    
//    public partial class PopulateMembershipTypes : DbMigration
//    {
//        private readonly VidlyDbContext _vidlyDbContext;
//        public PopulateMembershipTypes( VidlyDbContext vidlyDbContext)
//        {
//            _vidlyDbContext = vidlyDbContext;
//        }
       
//        public override void Up()
//        {
//            var  membership= new List< MembershipType>
//            {
//                new MembershipType{Id = 1,
//                  SignUpFree = 0,
//                  DiscountRate = 0,
//                  DurationInMonths = 0},
//                new MembershipType
//                {
//                    Id = 2,
//                    SignUpFree = 30,
//                    DurationInMonths = 1,
//                    DiscountRate = 10
//                },
//                new MembershipType
//                {
//                    Id = 3,
//                    SignUpFree = 90,
//                    DurationInMonths = 3,
//                    DiscountRate = 15
//                },
//                new MembershipType
//                {
//                    Id = 4,
//                    SignUpFree = 300,
//                    DurationInMonths = 12,
//                    DiscountRate = 20
//                }
//            };
//            var  mMbership = _vidlyDbContext.m
//            Sql($"INSERT INTO MembershipType {membership}");
//        }
        
//        public override void Down()
//        {
//        }
//    }
//}
