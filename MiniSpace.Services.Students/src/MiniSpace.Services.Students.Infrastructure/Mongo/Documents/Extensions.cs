using MiniSpace.Services.Students.Application.Dto;
using MiniSpace.Services.Students.Core.Entities;

namespace MiniSpace.Services.Students.Infrastructure.Mongo.Documents
{
    public static class Extensions
    {
        public static Student AsEntity(this StudentDocument document)
            => new Student(document.Id, document.Email, document.CreatedAt, document.FirstName,
                document.LastName, document.NumberOfFriends, document.ProfileImage,
                document.Description, document.DateOfBirth, document.EmailNotifications,
                document.IsBanned, document.CanBeOrganizer, document.State,
                document.InterestedInEvents, document.SignedUpEvents);

        public static StudentDocument AsDocument(this Student entity)
            => new StudentDocument()
            {
                Id = entity.Id,
                Email = entity.Email,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                NumberOfFriends = entity.NumberOfFriends,
                ProfileImage = entity.ProfileImage,
                Description = entity.Description,
                DateOfBirth = entity.DateOfBirth,
                EmailNotifications = entity.EmailNotifications,
                IsBanned = entity.IsBanned,
                CanBeOrganizer = entity.CanBeOrganizer,
                State = entity.State,
                CreatedAt = entity.CreatedAt,
                InterestedInEvents = entity.InterestedInEvents,
                SignedUpEvents = entity.SignedUpEvents
            };

        public static StudentDto AsDto(this StudentDocument document)
            => new StudentDto()
            {
                Id = document.Id,
                Email = document.Email,
                FirstName = document.FirstName,
                LastName = document.LastName,
                NumberOfFriends = document.NumberOfFriends,
                ProfileImage = document.ProfileImage,
                Description = document.Description,
                DateOfBirth = document.DateOfBirth,
                EmailNotifications = document.EmailNotifications,
                IsBanned = document.IsBanned,
                CanBeOrganizer = document.CanBeOrganizer,
                State = document.State.ToString().ToLowerInvariant(),
                CreatedAt = document.CreatedAt,
                InterestedInEvents = document.InterestedInEvents,
                SignedUpEvents = document.SignedUpEvents
            };
    }    
}
