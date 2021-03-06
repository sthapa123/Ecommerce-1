using System;
using MrCMS.Events;
using MrCMS.Helpers;
using MrCMS.Web.Apps.Ecommerce.Entities.Orders;
using MrCMS.Web.Apps.Ecommerce.Entities.RewardPoints;
using MrCMS.Web.Apps.Ecommerce.Settings;
using NHibernate;

namespace MrCMS.Web.Apps.Ecommerce.Events
{
    public class AwardRewardPoints : IOnUpdated<Order>
    {
        private readonly EcommerceSettings _ecommerceSettings;
        private readonly RewardPointSettings _rewardPointSettings;
        private readonly ISession _session;

        public AwardRewardPoints(EcommerceSettings ecommerceSettings, RewardPointSettings rewardPointSettings, ISession session)
        {
            _ecommerceSettings = ecommerceSettings;
            _rewardPointSettings = rewardPointSettings;
            _session = session;
        }

        public void Execute(OnUpdatedArgs<Order> args)
        {
            if (!_ecommerceSettings.RewardPointsEnabled)
                return;

            var order = args.Item;

            if (order.User == null)
                return;

            if (order.OrderStatus != _rewardPointSettings.StatusToAward)
                return;

            var pointsToAward = PointsToAward(order);
            if (pointsToAward <= 0)
                return;

            var alreadyAwarded = _session.QueryOver<PointsAwarded>().Where(awarded => awarded.Order.Id == order.Id).Any();
            if (alreadyAwarded)
                return;

            _session.Transact(session => session.Save(new PointsAwarded
            {
                Points = pointsToAward,
                User = order.User,
                Order = order,
            }));
        }

        private int PointsToAward(Order order)
        {
            var value = order.TotalPaid;
            if (_rewardPointSettings.PointsPerPurchaseAmount <= 0)
                return 0;

            var each = Math.Floor(value/_rewardPointSettings.PointsPerPurchaseAmount);

            return (int) (each*_rewardPointSettings.PointsPerPurchasePoints);
        }
    }
}