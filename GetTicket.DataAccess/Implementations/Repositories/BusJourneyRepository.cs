using GetTicket.DataAccess.Implementations.EF.Contexts;
using GetTicket.DataAccess.Interfaces;
using GetTicket.Model.Dtos.BusDtos;
using GetTicket.Model.Dtos.BusJourneyDtos;
using GetTicket.Model.Entities;
using Infrastructure.DataAccess.EF;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GetTicket.DataAccess.Implementations.Repositories
{
    public class BusJourneyRepository : BaseRepositoryEf<BusJourney, TransportationContext>, IBusJourneyRepository
    {
        public async Task<List<BusJourneyDto>> GetBusJourneysWithSameInClientDataAsync(string departurePoint, string destinationPoint, DateTime departureTime)
        {
            var list = await GetAllWithoutParamsAsync(x => x.DeparturePoint == departurePoint && x.DestinationPoint == destinationPoint && x.DepartureTime.Date == departureTime.Date && x.isActive == true);
            return list;
        }

        public async Task<BusJourneyDto> GetByIdAsync(int id)
        {
            var list = await GetWithoutParamsAsync(p => p.BusJourneyID == id && p.isActive == true);
            return list;
        }

        public async Task<BusJourney> BaseGetByIdAsync(int id, params string[] includeList)
        {
            var list = await GetAsync(p => p.BusJourneyID == id && p.isActive == true);
            return list;
        }


        public async Task<List<BusJourneyDto>> GetAllWithoutParamsAsync(Expression<Func<BusJourneyDto, bool>> expression = null)
        {
            using var context = new TransportationContext();

            IQueryable<BusJourney> dbset = context.Set<BusJourney>();

            var query = from busJourney in context.Set<BusJourney>()
                        join bus in context.Buses on busJourney.BusID equals bus.BusID
                        join busFirm in context.BusFirms on bus.BusFirmID equals busFirm.BusFirmID
                        select new BusJourneyDto
                        {
                            BusJourneyID = busJourney.BusJourneyID,
                            DeparturePoint = busJourney.DeparturePoint,
                            DepartureTime = busJourney.DepartureTime,
                            DestinationPoint = busJourney.DestinationPoint,
                            Price = busJourney.Price,
                            isActive = busJourney.isActive,
                            BusDto = new GetBusDto
                            {
                                BusFirmName = busFirm.BusFirmName,
                                BusID = bus.BusID,
                                BusPlate = bus.BusPlate,
                                CapacityOfSeat = bus.CapacityOfSeat,
                                ModelOfBus = bus.ModelOfBus
                            }
                        };
            if (expression == null)
            {
                var list = await query.ToListAsync();
                return list;
            }

            return await query.Where(expression).ToListAsync();
        }

        public async Task<BusJourneyDto> GetWithoutParamsAsync(Expression<Func<BusJourneyDto, bool>> expression = null)
        {
            using var context = new TransportationContext();

            IQueryable<BusJourney> dbset = context.Set<BusJourney>();

            var query = from busJourney in context.Set<BusJourney>()
                        join bus in context.Buses on busJourney.BusID equals bus.BusID
                        join busFirm in context.BusFirms on bus.BusFirmID equals busFirm.BusFirmID
                        select new BusJourneyDto
                        {
                            BusJourneyID = busJourney.BusJourneyID,
                            DeparturePoint = busJourney.DeparturePoint,
                            DepartureTime = busJourney.DepartureTime,
                            DestinationPoint = busJourney.DestinationPoint,
                            Price = busJourney.Price,
                            isActive = busJourney.isActive,
                            BusDto = new GetBusDto
                            {
                                BusFirmName = busFirm.BusFirmName,
                                BusID = bus.BusID,
                                BusPlate = bus.BusPlate,
                                CapacityOfSeat = bus.CapacityOfSeat,
                                ModelOfBus = bus.ModelOfBus
                            }
                        };


            return await query.SingleOrDefaultAsync(expression);

        }
    }
}
