using System;

namespace Sam.Feature.UserCard.Areas.Feature.UserCard.Models.ViewModels
{
    public class UserCardViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Patronymic { get; set; }

        public string Surname { get; set; }

        public string Role { get; set; }
    }
}