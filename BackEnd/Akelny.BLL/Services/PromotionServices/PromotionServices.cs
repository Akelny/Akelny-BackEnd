﻿using Akelny.BLL.Dto.PromotionDto;
using Akelny.DAL.Models;
using Akelny.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akelny.BLL.Services.PromotionServices
{
    public class PromotionServices : IPromotionServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public PromotionServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
   
        public Promotion Add(PromotionDto PromotionDto)
        {
            var promotion = new Promotion
            {
               
                Description = PromotionDto.Description,
                Title = PromotionDto.Title,
                date = PromotionDto.date,
                days = PromotionDto.days,
                Hours = PromotionDto.Hours,
                Minutes = PromotionDto.Minutes,
                Seconds = PromotionDto.Seconds,
                PriceAfter = PromotionDto.PriceAfter,
                PriceBefore = PromotionDto.PriceBefore,
                ImageUrl = PromotionDto.ImageUrl,
            };

            _unitOfWork.PromotionRepo.Add(promotion);
            _unitOfWork.PromotionRepo.SaveChanges();

            return promotion;
        }

        public void Delete(int id)
        {
           Promotion? promotion = _unitOfWork.PromotionRepo.GetById(id);

            if (promotion is null) { return; }

            _unitOfWork.PromotionRepo.Delete(promotion);
            _unitOfWork.PromotionRepo.SaveChanges();
        }

        public void Edit(int id, PromotionDto promotionDto)
        {
            Promotion? promotion = _unitOfWork.PromotionRepo.GetById(id);
            if (promotion == null) { return; }

            promotion.Title = promotionDto.Title;
            promotion.Description = promotionDto.Description;
            promotion.date = promotionDto.date;
            promotion.days = promotionDto.days;
            promotion.Hours = promotionDto.Hours;
            promotion.Minutes = promotionDto.Minutes;
            promotion.Seconds = promotionDto.Seconds;
            promotion.PriceBefore = promotionDto.PriceBefore;
            promotion.PriceAfter = promotionDto.PriceAfter;

            _unitOfWork.PromotionRepo.Update(promotion);
            _unitOfWork.PromotionRepo.SaveChanges();
        }

        public List<PromotionDto> GetAll()
        {
            List<Promotion> Promotions = _unitOfWork.PromotionRepo.GetAll();
            return Promotions
                .Select(d => new PromotionDto
                {
                    Id = d.Id,
                    Description = d.Description,
                    Title= d.Title,
                    date=d.date,
                    days = d.days,
                    Hours= d.Hours,
                    Minutes=d.Minutes,
                    Seconds= d.Seconds,
                    PriceAfter= d.PriceAfter,
                    PriceBefore= d.PriceBefore,
                    ImageUrl= d.ImageUrl,
                    

                })
                .ToList();
        }

       
    }
}
