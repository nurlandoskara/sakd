using System;

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
        public Citizenship Citizenship { get; set; }
        public string BirthPlace { get; set; }
        public DateTime? BirthDate { get; set; }
        public Enums.Sex Sex { get; set; }
        public bool IsNameChanged { get; set; }
        public string Education { get; set; }
        public bool IsMilitaryOrPension { get; set; }
        public int? SocialStatusId { get; set; }
        public SocialStatus SocialStatus { get; set; }
        public int? DocumentId { get; set; }
        public Document Document { get; set; }
        public bool IsLivingAddressRegistration { get; set; }
        public int? RegistrationAddressId { get; set; }
        public Address RegistrationAddress { get; set; }
        public int? LivingAddressId { get; set; }
        public Address LivingAddress { get; set; }
        public string MobilePhone { get; set; }
        public string HomePhone { get; set; }
        public string Email { get; set; }
        public string SmsCode { get; set; }
        public int? ContactPersonId { get; set; }
        public ContactPerson ContactPerson { get; set; }
        public int? FamilyId { get; set; }
        public Family Family { get; set; }
        public int? ParentsId { get; set; }
        public Parents Parents { get; set; }
        public int? JobId { get; set; }
        public Job Job { get; set; }
        public int? AdditionalInfoId { get; set; }
        public AdditionalInfo AdditionalInfo { get; set; }
        public bool IsFatca { get; set; }
    }

}
