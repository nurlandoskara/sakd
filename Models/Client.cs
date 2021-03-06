﻿using System;

namespace SAKD.Models
{
    public class Client: BaseDbObject
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PatronymicName { get; set; }
        public string DisplayString => $"{LastName} {FirstName} {PatronymicName}";
        public string Iin { get; set; }
        public int? CitizenshipId { get; set; }
        public virtual Citizenship Citizenship { get; set; }
        public string BirthPlace { get; set; }
        public DateTime? BirthDate { get; set; }
        public Enums.Sex Sex { get; set; }
        public bool IsNameChanged { get; set; }
        public Enums.Education Education { get; set; }
        public Enums.Pension Pension { get; set; }
        public Enums.SocialStatus SocialStatus { get; set; }
        public int? DocumentId { get; set; }
        public virtual Document Document { get; set; }
        public bool IsLivingAddressRegistration { get; set; }
        public int? RegistrationAddressId { get; set; }
        public virtual Address RegistrationAddress { get; set; }
        public int? LivingAddressId { get; set; }
        public virtual Address LivingAddress { get; set; }
        public string MobilePhone { get; set; }
        public string HomePhone { get; set; }
        public string Email { get; set; }
        public string SmsCode { get; set; }
        public int? ContactPersonId { get; set; }
        public virtual ContactPerson ContactPerson { get; set; }
        public int? FamilyId { get; set; }
        public virtual Family Family { get; set; }
        public int? ParentsId { get; set; }
        public virtual Parents Parents { get; set; }
        public int? JobId { get; set; }
        public virtual Job Job { get; set; }
        public int? AdditionalInfoId { get; set; }
        public virtual AdditionalInfo AdditionalInfo { get; set; }
        public bool IsFatca { get; set; }
    }

}
