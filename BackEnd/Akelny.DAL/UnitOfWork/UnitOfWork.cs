﻿using Akelny.DAL.Models;
using Akelny.DAL.Repo.MealRepo;
using Akelny.DAL.Repo.PromotionRepo;
using Akelny.DAL.Repo.ResturantRepo;
using Akelny.DAL.Repo.SectionRepo;
using Akelny.DAL.Repo.SubRepo;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akelny.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IPromotionRepo PromotionRepo { get; }
        public ISectionRepo SectionRepo { get; }
        public IMealRepo MealRepo { get; }
        public IResturantRepo ResturantRepo { get; }

        public ISubRepo Subrepo { get; }
        public UnitOfWork( ISubRepo subRepo , IPromotionRepo promotionRepo, ISectionRepo sectionRepo, IMealRepo mealRepo, IResturantRepo resturantRepo)
        {
            PromotionRepo = promotionRepo;
            SectionRepo = sectionRepo;
            MealRepo = mealRepo;
            ResturantRepo = resturantRepo;
            Subrepo = subRepo;
        }

        public string SaveImageMethod(IFormFile? image)
        {
            var extension = Path.GetExtension(image!.FileName);
            var newName = $"{Guid.NewGuid()}{extension}";
            var newPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", newName);

            using (var steam = new FileStream(newPath, FileMode.Create))
            {
                image!.CopyTo(steam);
            }

            return newName;

        }
    }
}
