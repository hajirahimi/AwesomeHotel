using AwesomeHotel_HotelAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AwesomeHotel_HotelAPI.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions <ApplicationDbContext> options) : base(options)
        {
        }
        public  DbSet<Hotel> Hotels { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel 
                {
                Id = 1,
                Name = "NewOceanView",
                Occupancy = 3,
                Area = 30,
                Rate =120,
                Details ="Best room for couples",
                ImageUrl = "www.awesomehotels.com/OceanView.jpg",
                Amenities ="Air condition, natural light",
                CreatedDate = DateTime.Now,
                }
                , new Hotel
                {
                    Id = 2,
                    Name = "StreetView",
                    Occupancy = 2,
                    Area = 25,
                    Rate = 100,
                    Details = "Best room for business",
                    ImageUrl = "www.awesomehotels.com/StreetView.jpg",
                    Amenities = "Air condition, smoking area",
                    CreatedDate = DateTime.Now,
                }
                , new Hotel
                {
                    Id = 3,
                    Name = "Penthouse",
                    Occupancy = 5,
                    Area = 50,
                    Rate = 150,
                    Details = "Best room for large familes",
                    ImageUrl = "www.awesomehotels.com/Penthouse.jpg",
                    Amenities = "Air condition, free coffee",
                    CreatedDate = DateTime.Now,
                },
                new Hotel
                {
                    Id = 4,
                    Name = "Presidential",
                    Occupancy = 3,
                    Area = 50,
                    Rate = 200,
                    Details = "Most exclusive room",
                    ImageUrl = "www.awesomehotels.com/Presidential.jpg",
                    Amenities = "Air condition, free drink, extra security",
                    CreatedDate = DateTime.Now,
                }
            );
        }
    }
}