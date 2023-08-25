using GetTicket.DataAccess.Implementations.EF.Contexts;
using GetTicket.DataAccess.Interfaces;
using GetTicket.Model.Dtos.BusDtos;
using GetTicket.Model.Dtos.BusJourneyDtos;
using GetTicket.Model.Dtos.JourneyDtos;
using GetTicket.Model.Dtos.PassengerDtos;
using GetTicket.Model.Entities;
using Infrastructure.DataAccess.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GetTicket.DataAccess.Implementations.Repositories
{
    public class JourneyRepository : BaseRepositoryEf<Journey, TransportationContext>, IJourneyRepository
    {
        public async Task<List<GetJourneyDto>> GetJourneysWithSameInClientDataAsync(string departurePoint, string destinationPoint, DateTime departureTime)
        {
            var list = await GetAllWithoutParamsAsync(x => x.BusJourneyDto.DeparturePoint == departurePoint && x.BusJourneyDto.DestinationPoint == destinationPoint && x.BusJourneyDto.DepartureTime.Date == departureTime.Date && x.IsActive == true);
            return list;
        }

        public async Task<Journey> GetByBusJourneyAndSeatAsync(int busJourneyID, int seatNo, params string[] includeList)
        {
            return await GetAsync(x => x.BusJourneyID == busJourneyID && x.SeatNo == seatNo && x.IsActive == true);
        }

        public async Task<GetJourneyDto> GetByIdAsync(int id)
        {
            var list = await GetWithoutParamsAsync(p => p.JourneyID == id && p.IsActive == true);
            return list;
        }

        public async Task<Journey> BaseGetByIdAsync(int id, params string[] includeList)
        {
            var list = await GetAsync(p => p.JourneyID == id && p.IsActive == true);
            return list;
        }


        public async Task<List<GetJourneyDto>> GetByPassengerIdAsync(int id)
        {
            var list = await GetAllWithoutParamsAsync(p => p.GetPassengerDto.PassengerID == id && p.IsActive == true);
            return list;
        }


        public async Task<List<GetJourneyDto>> GetAllWithoutParamsAsync(Expression<Func<GetJourneyDto, bool>> expression = null)
        {
            using var context = new TransportationContext();

            IQueryable<Journey> dbset = context.Set<Journey>();

            var query = from getJourney in context.Set<Journey>()
                        join busJourney in context.BusJourneys on getJourney.BusJourneyID equals busJourney.BusJourneyID
                        join getBus in context.Buses on busJourney.BusID equals getBus.BusID
                        join getBusFirm in context.BusFirms on getBus.BusFirmID equals getBusFirm.BusFirmID
                        join getPassenger in context.Passengers on getJourney.PassengerID equals getPassenger.PassengerID
                        select new GetJourneyDto
                        {
                            SeatNo = getJourney.SeatNo,
                            IsActive = getJourney.IsActive,
                            JourneyID= getJourney.JourneyID,
                            GetPassengerDto = new GetPassengerDto
                            {
                                Email = getPassenger.Email,
                                Gender = getPassenger.Gender,
                                IDNumber = getPassenger.IDNumber,
                                PassengerID = getPassenger.PassengerID,
                                PassengerLastName = getPassenger.PassengerLastName,
                                PassengerName = getPassenger.PassengerName,
                                Password = getPassenger.Password,
                                Phone = getPassenger.Phone,
                                RegisterTime = getPassenger.RegisterTime
                                
                            },
                            BusJourneyDto = new BusJourneyDto
                            {
                                BusJourneyID = busJourney.BusJourneyID,
                                DeparturePoint = busJourney.DeparturePoint,
                                DepartureTime = busJourney.DepartureTime,
                                DestinationPoint = busJourney.DestinationPoint,
                                Price = busJourney.Price,
                                isActive=busJourney.isActive,
                                BusDto = new GetBusDto
                                {
                                    BusFirmName = getBusFirm.BusFirmName,
                                    BusID = getBus.BusID,
                                    BusPlate = getBus.BusPlate,
                                    CapacityOfSeat = getBus.CapacityOfSeat,
                                    ModelOfBus = getBus.ModelOfBus
                                }
                            }


                        };

            if (expression == null)
            {
                var list = await query.ToListAsync();
                return list;
            }

            return await query.Where(expression).ToListAsync();
        }




        public async Task<GetJourneyDto> GetWithoutParamsAsync(Expression<Func<GetJourneyDto, bool>> expression = null)
        {
            using var context = new TransportationContext();

            IQueryable<Journey> dbset = context.Set<Journey>();

            var query = from getJourney in context.Set<Journey>()
                        join busJourney in context.BusJourneys on getJourney.BusJourneyID equals busJourney.BusJourneyID
                        join getBus in context.Buses on busJourney.BusID equals getBus.BusID
                        join getBusFirm in context.BusFirms on getBus.BusFirmID equals getBusFirm.BusFirmID
                        join getPassenger in context.Passengers on getJourney.PassengerID equals getPassenger.PassengerID
                        select new GetJourneyDto
                        {
                            SeatNo = getJourney.SeatNo,
                            IsActive = getJourney.IsActive,
                            JourneyID = getJourney.JourneyID,
                            GetPassengerDto = new GetPassengerDto
                            {
                                Email = getPassenger.Email,
                                Gender = getPassenger.Gender,
                                IDNumber = getPassenger.IDNumber,
                                PassengerID = getPassenger.PassengerID,
                                PassengerLastName = getPassenger.PassengerLastName,
                                PassengerName = getPassenger.PassengerName,
                                Password = getPassenger.Password,
                                Phone = getPassenger.Phone,
                                RegisterTime = getPassenger.RegisterTime

                            },
                            BusJourneyDto = new BusJourneyDto
                            {
                                BusJourneyID = busJourney.BusJourneyID,
                                DeparturePoint = busJourney.DeparturePoint,
                                DepartureTime = busJourney.DepartureTime,
                                DestinationPoint = busJourney.DestinationPoint,
                                Price = busJourney.Price,
                                isActive = busJourney.isActive,
                                BusDto = new GetBusDto
                                {
                                    BusFirmName = getBusFirm.BusFirmName,
                                    BusID = getBus.BusID,
                                    BusPlate = getBus.BusPlate,
                                    CapacityOfSeat = getBus.CapacityOfSeat,
                                    ModelOfBus = getBus.ModelOfBus
                                }
                            }


                        };

            return await query.SingleOrDefaultAsync(expression);

        }
    }
}
