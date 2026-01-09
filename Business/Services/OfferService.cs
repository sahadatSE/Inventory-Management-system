using System.Linq;
using Database.Context;
using Database.Model;

namespace Business.Services
{
    public class OfferService
    {
        public IMSContext context = new();

        public Result AddOffer(Offer offer)
        {
            context.Offer.Add(offer);
            return Result.DBcommit(context, "Offer added successfully");
        }
        public Result UpdateOffer(Offer offer)
        {
            context.Offer.Update(offer);
            return Result.DBcommit(context, "Offer updated successfully");
        }
        public Result DeleteOffer(Offer offer)
        {
            context.Offer.Remove(offer);
            return Result.DBcommit(context, "Offer deleted successfully");
        }
        public Result GetAllOffer()
        {
            var offers = context.Offer.ToList();
            return new Result(true, "Offers retrieved successfully", offers);
        }
        public Result GetOffer(int id)
        {
            var offer = context.Offer.Find(id);

            if (offer == null)
                return new Result(false, "Offer not found");

            return new Result(true, "Offer retrieved successfully", offer);
        }
    }
}

