﻿using PawAndCollar.Web.ViewModels.Review;

namespace PawAndCollarServices.Interfaces
{
    public interface IReviewService
    {
        Task<ReviewViewModel> GetReviewByProductIdAsync(int productId, string userId);

        Task<ReviewViewModel> GetReviewByIdAsync(string userId, int reviewId);
    }
}
