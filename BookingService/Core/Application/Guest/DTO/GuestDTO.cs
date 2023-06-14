using Domain.Enums;
using Entities = Domain.Entities;
namespace Application.Guest.DTO
{
    public class GuestDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string IdNumber { get; set; } = string.Empty;
        public int IdTypeCode { get; set; }

        public static Entities.Guest MapToEntity(GuestDTO guestDTO)
        {
            return new Entities.Guest
            {
                Id = guestDTO.Id,
                Name = guestDTO.Name,
                Surname = guestDTO.Surname,
                Email = guestDTO.Email,
                DocumentId = new Domain.ValueObjects.PersonId
                {
                    IdNumber = guestDTO.IdNumber,
                    DocumentType = (DocumentTypes)guestDTO.IdTypeCode
                }
            };
        }

        public static GuestDTO MapToDto(Entities.Guest guestEntity)
        {
            return new GuestDTO
            {
                Id = guestEntity.Id,
                Name = guestEntity.Name,
                Surname = guestEntity.Surname,
                Email = guestEntity.Email,
                IdNumber = guestEntity.DocumentId.IdNumber,
                IdTypeCode = (int)guestEntity.DocumentId.DocumentType
            };
        }
    }
}
