namespace PawAndCollar.Common
{
    public static class EntittyValidationConstants
    {
        public static class Product
        {
            public const int NameMaxLength = 50;
            public const int NameMinLength = 10;
            public const int DescriptionMaxLength = 5000;
            public const int DescriptionMinLength = 150;
            public const int ImageUrlMaxLength = 2048;
            public const int ImageUrlMinLength = 20;
            public const int ColorMaxLength = 15;
            public const int ColorMinLength = 3;
            public const string PriceMinValue = "0";
            public const string PriceMaxValue = "1000";
            public const int QuantityMinValue = 0;
            public const int QuantityMaxValue = int.MaxValue;
            public const int MaterialMaxLength = 25;
            public const int MaterialMinLength = 5;
        }

        public static class Creator
        {
            public const int PhoneNumberMaxLength = 15;
            public const int PhoneNumberMinLength = 7;
        }
        public static class Category
        {
            public const int NameMaxLength = 50;
            public const int NameMinLength = 10;
        }

        public static class Order
        {
            public const int ShippingAddressMaxLength = 250;
            public const int ShippingAddressMinLength = 0;
            public const int CustomerNameMaxLength = 50;
            public const int CustomerNameMinLength = 5;
            public const int PhoneNumberMaxLength = 15;
            public const int PhoneNumberMinLength = 7;
        }

        public static class OrderItem
        {
            public const int MinQuantity = 1;
            public const int MaxQuantity = 100000;
        }
        public static class Cart
        {
			public const string MinTotalPrice = "0";
			public const string MaxTotalPrice = "9999.99";
		}
    }
}
