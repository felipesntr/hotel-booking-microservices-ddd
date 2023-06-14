using Domain.Exceptions;
using Domain.Ports;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Guest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public PersonId DocumentId { get; set; }

        private void ValidateState()
        {
            if (string.IsNullOrEmpty(DocumentId.IdNumber) || DocumentId.IdNumber.Length <= 3 || DocumentId.DocumentType == 0)
                throw new InvalidPersonDocumentIdException();
            if (Name == null || Surname == null || Email == null)
                throw new MissingRequiredInformation();
            if (!Utils.ValidateEmail(Email))
                throw new Exception("Invalid email");
        }

        public async Task Save(IGuestRepository guestRepository)
        {
            this.ValidateState();
            if (this.Id == 0)
            {
                this.Id = await guestRepository.Save(this);
            }
            else
            {
                //await guestRepository.Update(this);
            }

        }
    }
}
