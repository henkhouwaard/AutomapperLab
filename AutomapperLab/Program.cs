using System;
using System.Collections.Generic;

using AutoMapper;

using ConsoleApplication4;

namespace AutomapperLab
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var groupDto = new GroupDto
                        {
                            MainShop = new ShopDto {Name = "Mainshop"},
                            SubShops = new List<ShopDto>
                                       {
                                           new ShopDto {Name = "Subshop 1"},
                                           new ShopDto {Name = "Subshop 2"},
                                           new ShopDto {Name = "Subshop 3"}
                                       }
                        };

            Mapper.CreateMap<GroupDto,Group>();
            Mapper.CreateMap<ShopDto, Shop>()
                  .ForMember(dest => dest.Id, opt => opt.ResolveUsing<CustomResolver>());
     

            var groupCopy = Mapper.Map<Group>(groupDto);

            Console.WriteLine(groupCopy.MainShop.ShopDto.Name);
            foreach (var shop in groupCopy.SubShops)
            {
                Console.WriteLine("\tID: {0} Name: {1}",shop.Id, shop.ShopDto.Name);
            }
            Console.ReadLine();
        }
    }

    public class CustomResolver : ValueResolver<ShopDto,int>
    {
        private static int _i = 0;

        protected override int ResolveCore(ShopDto source)
        {
            return _i++;
        }
    }
}