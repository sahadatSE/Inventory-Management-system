using System.Linq;
using Database.Context;
using Database.Model;

namespace Business.Services
{
    public class OfferService(IMSContext context)
    {
        private readonly IMSContext _context = context;

        public Result AddOffer(Offer offer)
        {
            _context.Offer.Add(offer);
            return Result.DBcommit(_context, "Offer added successfully");
        }
        public Result UpdateOffer(Offer offer)
        {
            _context.Offer.Update(offer);
            return Result.DBcommit(_context, "Offer updated successfully");
        }
        public Result DeleteOffer(Offer offer)
        {
            _context.Offer.Remove(offer);
            return Result.DBcommit(_context, "Offer deleted successfully");
        }
        public Result GetAllOffer()
        {
            var offers = _context.Offer.ToList();
            return new Result(true, "Offers retrieved successfully", offers);
        }
        public Result GetOffer(int id)
        {
            var offer = _context.Offer.Find(id);

            if (offer == null)
                return new Result(false, "Offer not found");

            return new Result(true, "Offer retrieved successfully", offer);
        }
    }
}

