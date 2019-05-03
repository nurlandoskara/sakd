using System.ComponentModel;

namespace SAKD
{
    public class Enums
    {
        public enum FileType
        {
            OrderAnketa = 0,
            Uniform = 1,
            FATCA = 2,
            Identity = 3
        }
        public enum SourceInfo
        {
            Advertisement = 0,
            Advice = 1
        }
        public enum ParentsStatus
        {
            Both = 0,
            Father = 1,
            Mother = 2
        }
        public enum FamilyStatus
        {
            NotMarried = 0,
            Married = 1
        }
        public enum RelationType
        {
            Parents = 0,
            Siblings = 1,
            Friends = 2,
            Colleagues = 3
        }
        public enum DocumentOrganization
        {
            MU = 0,
            MVD = 1
        }
        public enum DocumentType
        {
            Identity = 0,
            Passport = 1
        }
        public enum Sex
        {
            Male = 0,
            Female = 1
        }
        public enum Method
        {
            Annual = 0,
            Difference = 1
        }

        public enum Purpose
        {
            Consume = 0,
            Refinance = 1
        }
        public enum Product
        {
            [Description("Қолма қол несие")]
            Cash = 0,
            [Description("Халықаралық несие картасы")]
            InternationalCreditCard = 1,
        }
        public enum Program
        {
            [Description("Стандарт")]
            Standard = 0,
            [Description("Теміржол қызметкерлеріне")]
            ForRailwayEmployees = 1,
            [Description("Банк қызметкерлеріне")]
            ForBankEmployees = 2
        }
        public enum Status
        {
            All = 0,
            S1 = 1,
            S2 = 2,
            S3 = 3,
            S4 = 4,
            S5 = 5,
            S6 = 6,
            S7 = 7,
            S8 = 8,
            S81 = 9,
            S9 = 10,
            S10 = 11,
            S11 = 12,
            S12 = 13,
            S13 = 14,
            S14 = 15,
            S15 = 16,
            S16 = 17,
            S17 = 18,
            S18 = 19,
            Error1 = 20,
            Error2 = 21,
            Hot = 22,
            Warm = 23,
            Cold = 24,
            Accepted = 25,
            Cancelled = 26,
            CancelledByClient = 27,
            CancelledByThird = 28
        }
    }
}
