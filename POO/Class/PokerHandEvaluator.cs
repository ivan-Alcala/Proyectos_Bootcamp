using System.Collections.Generic;
using System.Linq;

namespace POO.Class
{
    public static class PokerHandEvaluator
    {
        public static eHandRank EvaluateHand(List<Card> hand)
        {
            var sortedHand = hand.OrderByDescending(c => c.Value).ToList();
            bool isFlush = sortedHand.All(card => Card.CompareSuits(card, sortedHand.First()));
            bool isStraight = IsStraight(sortedHand);

            if (isFlush && isStraight)
                return sortedHand.First().Value == 14 ? eHandRank.RoyalFlush : eHandRank.StraightFlush;

            var valueGroups = sortedHand.GroupBy(card => card.Value).OrderByDescending(g => g.Count()).ToList();

            if (valueGroups[0].Count() == 4)
                return eHandRank.FourOfAKind;
            if (valueGroups[0].Count() == 3 && valueGroups[1].Count() == 2)
                return eHandRank.FullHouse;
            if (isFlush)
                return eHandRank.Flush;
            if (isStraight)
                return eHandRank.Straight;
            if (valueGroups[0].Count() == 3)
                return eHandRank.ThreeOfAKind;
            if (valueGroups[0].Count() == 2 && valueGroups[1].Count() == 2)
                return eHandRank.TwoPair;
            if (valueGroups[0].Count() == 2)
                return eHandRank.OnePair;

            return eHandRank.HighCard;
        }

        private static bool IsStraight(List<Card> hand)
        {
            for (int i = 0; i < hand.Count - 1; i++)
            {
                if (hand[i].Value != hand[i + 1].Value + 1)
                    return false;
            }
            return true;
        }
    }

    public enum eHandRank
    {
        RoyalFlush,
        StraightFlush,
        FourOfAKind,
        FullHouse,
        Flush,
        Straight,
        ThreeOfAKind,
        TwoPair,
        OnePair,
        HighCard
    }
}
