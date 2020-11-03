using System;

namespace CarPricer
{
    public class PriceDeterminator
    {
        public decimal DetermineCarPrice(Car car)
        {
            decimal adjustedPrice = AdjustPriceForAge(car.AgeInMonths, car.PurchaseValue);
            adjustedPrice = AdjustPriceForMiles(car.NumberOfMiles, adjustedPrice);
            adjustedPrice = AdjustPriceForCollision(car.NumberOfCollisions, adjustedPrice);
            adjustedPrice = AdjustPriceForPreviousOwnerReducing(car.NumberOfPreviousOwners, adjustedPrice);
            adjustedPrice = AdjustPriceForReliability(car.Make, adjustedPrice);
            adjustedPrice = AdjustPriceForPreviousOwnerAdding(car.NumberOfPreviousOwners, adjustedPrice);
            adjustedPrice = AdjustPriceForProfitability(car.PurchaseValue, adjustedPrice);

            return adjustedPrice;
        }

        private decimal AdjustPriceForAge(int ageInMonths, decimal carPrice)
        {
            int tenYearsInMonths = 10 * 12;
            decimal adjustedPrice = carPrice - carPrice / 100 * 0.5m * Math.Min(ageInMonths, tenYearsInMonths);

            return adjustedPrice;
        }

        private decimal AdjustPriceForMiles(int numberOfMiles, decimal carPrice)
        {
            int limitOfMiles = 150000;
            decimal adjustedPrice = carPrice - carPrice / 100 * 0.2m * Math.Min(numberOfMiles, limitOfMiles) / 1000;

            return adjustedPrice;
        }

        private decimal AdjustPriceForCollision(int numberOfCollisions, decimal carPrice)
        {
            int limitOfCollisions = 5;
            decimal adjustedPrice = carPrice - carPrice / 100 * 2 * Math.Min(numberOfCollisions, limitOfCollisions);

            return adjustedPrice;
        }

        private decimal AdjustPriceForPreviousOwnerReducing(int numberOfPreviousOwners, decimal carPrice)
        {
            decimal adjustedPrice = carPrice;

            int criticalNumberOfPreviousOwners = 2;
            int criticalReducingPercent = 25;

            if (numberOfPreviousOwners > criticalNumberOfPreviousOwners)
            {
                adjustedPrice = carPrice - carPrice / 100 * criticalReducingPercent;
            }

            return adjustedPrice;
        }

        private decimal AdjustPriceForPreviousOwnerAdding(int numberOfPreviousOwners, decimal carPrice)
        {
            decimal adjustedPrice = carPrice;

            int noPreviousOwners = 0;
            int addingPercent = 10;

            if (numberOfPreviousOwners == noPreviousOwners)
            {
                adjustedPrice = carPrice + carPrice / 100 * addingPercent;
            }

            return adjustedPrice;
        }

        private decimal AdjustPriceForReliability(string make, decimal carPrice)
        {
            if (string.IsNullOrWhiteSpace(make))
                return carPrice;

            decimal adjustedPrice = carPrice;

            string makeToyota = "Toyota";
            int ToyotaReliabilityPercent = 5;

            if (make.Equals(makeToyota, StringComparison.OrdinalIgnoreCase))
            {
                adjustedPrice = carPrice + carPrice / 100 * ToyotaReliabilityPercent;
            }

            string makeFord = "Ford";
            int FordReliabilitySubtractSum = 500;

            if (make.Equals(makeFord, StringComparison.OrdinalIgnoreCase))
            {
                adjustedPrice = carPrice - FordReliabilitySubtractSum;
            }

            return adjustedPrice;
        }

        private decimal AdjustPriceForProfitability(decimal purchaseValue, decimal carPrice)
        {
            decimal adjustedPrice = carPrice;

            int profitabilityPercent = 90;
            decimal profitabilityPrice = purchaseValue / 100 * profitabilityPercent;

            if (carPrice > profitabilityPrice)
            {
                adjustedPrice = profitabilityPrice;
            }

            return adjustedPrice;
        }
    }
}
