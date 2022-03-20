﻿using Microsoft.EntityFrameworkCore;
using shop.Core.Domain;
using shop.Core.Dtos;
using shop.Core.ServiceInterface;
using shop.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop.ApplicatonServices.Services
{
    public class SpaceshipServices : ISpaceshipService
    {
        private readonly shopDbContext _context;

        public SpaceshipServices
               (
                   shopDbContext context
               )
        {
            _context = context;
        }
        public async Task<Spaceship> Delete(Guid id)
        {

            var spaceshipId = await _context.Spaceship
                .FirstOrDefaultAsync(x => x.Id == id);


            _context.Spaceship.Remove(spaceshipId);
            await _context.SaveChangesAsync();

            return spaceshipId;
        }
        public async Task<Spaceship> Add(SpaceshipDto dto)
        {
            Spaceship spaceship = new Spaceship();
            FileToDatabase file = new FileToDatabase();

            spaceship.Id = Guid.NewGuid();
            spaceship.Name = dto.Name;
            spaceship.Type = dto.Type;
            spaceship.Mass = dto.Mass;
            spaceship.Prise = dto.Prise;
            spaceship.Crew = dto.Crew;
            spaceship.Constructed = DateTime.Now;
            spaceship.ModifiedAt = DateTime.Now;
            spaceship.CreatedAt = DateTime.Now;

            if (dto.Files != null)
            {
                file.ImageData = UploadFile(dto, spaceship);
            }

            await _context.Spaceship.AddAsync(spaceship);
            await _context.SaveChangesAsync();

            return spaceship;
        }
        public async Task<Spaceship> GetAsync(Guid id)
        {
            var result = await _context.Spaceship
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;

        }
        public async Task<Spaceship> Update(SpaceshipDto dto)
        {
            Spaceship spaceship = new Spaceship();
            FileToDatabase file = new FileToDatabase();

            spaceship.Id = dto.Id;
            spaceship.Name = dto.Name;
            spaceship.Type = dto.Type;
            spaceship.Mass = dto.Mass;
            spaceship.Prise = dto.Prise;
            spaceship.Crew = dto.Crew;
            spaceship.Constructed = dto.Constructed;
            spaceship.ModifiedAt = DateTime.Now;
            spaceship.CreatedAt = dto.CreatedAt;

            if (dto.Files != null)
            {
                file.ImageData = UploadFile(dto, spaceship);
            }

            _context.Spaceship.Update(spaceship);
            await _context.SaveChangesAsync();

            return spaceship;
        }

        public byte[] UploadFile(SpaceshipDto dto, Spaceship spaceship)
        {

            if (dto.Files != null && dto.Files.Count > 0)
            {
                foreach (var photo in dto.Files)
                {
                    using (var target = new MemoryStream())
                    {
                        FileToDatabase files = new FileToDatabase
                        {
                            Id = Guid.NewGuid(),
                            ImageTitle = photo.FileName,
                            SpaceshipId = spaceship.Id
                        };

                        photo.CopyTo(target);
                        files.ImageData = target.ToArray();

                        _context.FileToDatabase.Add(files);
                    }
                }
            }
            return null;
        }

    }
}
