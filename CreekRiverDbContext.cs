using Microsoft.EntityFrameworkCore;
using CreekRiver.Models;

public class CreekRiverDbContext : DbContext
{

    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Campsite> Campsites { get; set; }
    public DbSet<CampsiteType> CampsiteTypes { get; set; }

    public CreekRiverDbContext(DbContextOptions<CreekRiverDbContext> context) : base(context)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    // seed data with campsite types
    modelBuilder.Entity<CampsiteType>().HasData(new CampsiteType[]
    {
        new CampsiteType {Id = 1, CampsiteTypeName = "Tent", FeePerNight = 15.99M, MaxReservationDays = 7},
        new CampsiteType {Id = 2, CampsiteTypeName = "RV", FeePerNight = 26.50M, MaxReservationDays = 14},
        new CampsiteType {Id = 3, CampsiteTypeName = "Primitive", FeePerNight = 10.00M, MaxReservationDays = 3},
        new CampsiteType {Id = 4, CampsiteTypeName = "Hammock", FeePerNight = 12M, MaxReservationDays = 7}
    });
    modelBuilder.Entity<Campsite>().HasData(new Campsite[]
    {
        new Campsite {Id = 1, CampsiteTypeId = 1, Nickname = "Barred Owl", ImageUrl="https://tnstateparks.com/assets/images/content-images/campgrounds/249/colsp-area2-site73.jpg"},
        new Campsite {Id = 2, CampsiteTypeId = 2, Nickname = "Funky Eagle", ImageUrl="https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.nationalgeographic.com%2Fadventure%2Farticle%2Fhow-to-pick-best-campsite&psig=AOvVaw1yzHgHLNPSJULUtOLIFvPW&ust=1714659448591000&source=images&cd=vfe&opi=89978449&ved=0CBIQjRxqFwoTCJiala7S7IUDFQAAAAAdAAAAABAE"},
        new Campsite {Id = 3, CampsiteTypeId = 3, Nickname="Yao Gaui Ridge", ImageUrl="https://www.gearo.com/wp-content/uploads/2018/09/campsite_concierge1.png"},
        new Campsite {Id = 4, CampsiteTypeId = 4, Nickname="Kagouti", ImageUrl="https://www.winfieldsoutdoors.co.uk/blog/wp-content/uploads/2015/12/campingtrips.jpg"},
        new Campsite {Id = 5, CampsiteTypeId = 1, Nickname="Yeoman", ImageUrl="https://i.pinimg.com/736x/49/62/af/4962aff65912aa017a4be27652583cde.jpg"},
        new Campsite {Id = 6, CampsiteTypeId = 2, Nickname="Stone River", ImageUrl="https://do.lolwot.com/wp-content/uploads/2015/08/20-of-the-funniest-camping-photos-of-all-time-20.jpg"}
    });
    modelBuilder.Entity<UserProfile>().HasData(new UserProfile[]
    {
        new UserProfile {Id = 1, FirstName="Josef", LastName="Yughisvli", Email="dotdot@dot.net"},
        new UserProfile {Id = 2, FirstName="Sandy", LastName="Denny", Email="Sdenny@gmail.com"}
    });
    modelBuilder.Entity<Reservation>().HasData(new Reservation[]
    {
        new Reservation {Id = 1, CampsiteId= 4, UserProfileId=1}
    });
}
}