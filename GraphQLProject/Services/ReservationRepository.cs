using GraphQLProject.Data;
using GraphQLProject.Interfaces;
using GraphQLProject.Models;

namespace GraphQLProject.Services
{
    public class ReservationRepository :IReservationRepository
    {
        private readonly GraphQLDbContext _dbContext;

        public ReservationRepository(GraphQLDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Reservation> GetReservations()
        {
            return _dbContext.Reservations.ToList();
        }

        public Reservation AddReservation(Reservation reservation)
        {
            _dbContext.Reservations.Add(reservation);
            _dbContext.SaveChanges();
            return reservation;
        }
    }
}
