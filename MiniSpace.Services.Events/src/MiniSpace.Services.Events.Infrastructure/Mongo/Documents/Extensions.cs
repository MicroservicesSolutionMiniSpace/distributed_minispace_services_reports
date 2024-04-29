﻿using System;
using System.Linq;
using MiniSpace.Services.Events.Application.DTO;
using MiniSpace.Services.Events.Core.Entities;

namespace MiniSpace.Services.Events.Infrastructure.Mongo.Documents
{
    public static class Extensions
    {
        public static EventDto AsDto(this EventDocument document, Guid studentId)
            => new ()
            {
                Id = document.Id,
                Name = document.Name,
                Description = document.Description,
                Organizer = document.Organizer.AsDto(),
                StartDate = document.StartDate,
                EndDate = document.EndDate,
                Location = document.Location.AsDto(),
                InterestedStudents = document.InterestedStudents.Count(),
                SignedUpStudents = document.SignedUpStudents.Count(),
                Capacity = document.Capacity,
                Fee = document.Fee,
                Category = document.Category.ToString(),
                Status = document.State.ToString(),
                PublishDate = document.PublishDate,
                IsSignedUp = document.SignedUpStudents.Any(x => x.StudentId == studentId),
                IsInterested = document.InterestedStudents.Any(x => x.StudentId == studentId),
                HasRated = document.Ratings.Any(x => x.StudentId == studentId)
            };
        
        public static Event AsEntity(this EventDocument document)
            => new (document.Id, document.Name, document.Description, document.StartDate, document.EndDate,
                document.Location, document.Capacity, document.Fee, document.Category, document.State, document.PublishDate,
                document.Organizer, document.InterestedStudents, document.SignedUpStudents, document.Ratings);
        
        public static EventDocument AsDocument(this Event entity)
            => new ()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Organizer = entity.Organizer,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                Location = entity.Location,
                InterestedStudents = entity.InterestedStudents,
                SignedUpStudents = entity.SignedUpStudents,
                Capacity = entity.Capacity,
                Fee = entity.Fee,
                Category = entity.Category,
                State = entity.State,
                PublishDate = entity.PublishDate,
                Ratings = entity.Ratings
            };

        public static AddressDto AsDto(this Address entity)
            => new ()
            {
                BuildingName = entity.BuildingName,
                Street = entity.Street,
                BuildingNumber = entity.BuildingNumber,
                ApartmentNumber = entity.ApartmentNumber,
                City = entity.City,
                ZipCode = entity.ZipCode
            };
        
        public static Address AsEntity(this AddressDto dto)
            => new (dto.BuildingName, dto.Street, dto.BuildingNumber, dto.ApartmentNumber, dto.City, dto.ZipCode);
        
        public static OrganizerDto AsDto(this Organizer entity)
            => new ()
            {
                Id = entity.Id,
                Name = entity.Name,
                Email = entity.Email,
                OrganizationId = entity.OrganizationId,
                OrganizationName = entity.OrganizationName
            };
        
        public static StudentDocument AsDocument(this Student entity)
            => new ()
            {
                Id = entity.Id,
            };
        
        public static Student AsEntity(this StudentDocument document)
            => new (document.Id);
    }
}