using System.ComponentModel;

namespace SAKD
{
    public class Enums
    {
        public enum Education
        {
            [Description("Жоқ")]
            None = 0,
            [Description("Арнайы орта")]
            College = 1,
            [Description("Бакалавр")]
            Bachelor = 2,
            [Description("Магистр")]
            Master = 3
        }

        public enum Currency
        {
            [Description("Тенге")]
            Tenge = 0,
            [Description("Рубль")]
            Rubl = 1,
            [Description("Доллар")]
            Dollar = 3
        }
        public enum Visibilities
        {
            None = 0,
            Search = 1,
        }

        public enum SearchByParam
        {
            [Description("ИИН")]
            Iin = 0,
            [Description("Филиал")]
            Branch = 1,
            [Description("Тегі")]
            Lastname = 2,
        }


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
            [Description("Ер")]
            Male = 0,
            [Description("Әйел")]
            Female = 1
        }
        public enum Method
        {
            [Description("Аннуитивті")]
            Annual = 0,
            [Description("Дифференциалды")]
            Difference = 1
        }

        public enum Purpose
        {
            [Description("Тұтынушы")]
            Consume = 0,
            [Description("Қайтадан қаржыландыру")]
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
            [Description("Барлығы")]
            All = 0,
            [Description("Калькуляторды толтыру")]
            S1 = 1,
            [Description("Құжаттарды басып шығару және қол қою 1")]
            S2 = 2,
            [Description("Автоматты өңдеу")]
            S3 = 3,
            [Description("Поведенческий скоринг")]
            S4 = 4,
            [Description("Отчетті сұрау")]
            S5 = 5,
            [Description("ПКБ. Рефинансирование")]
            S6 = 6,
            [Description("Запрос отчета ГЦВП")]
            S7 = 7,
            [Description("Скоринг 2")]
            S8 = 8,
            [Description("Алдын ала есептеу")]
            S81 = 9,
            [Description("Скоринг 3")]
            S9 = 10,
            [Description("Тексеру")]
            S10 = 11,
            [Description("УЛ шешім қабылдау")]
            S11 = 12,
            [Description("Хабарлау және клиенттің шешімі")]
            S12 = 13,
            [Description("Келісім шартты тіркеу")]
            S13 = 14,
            [Description("Құжаттарды басып шығару және қол қою 2")]
            S14 = 15,
            [Description("Акцепт")]
            S15 = 16,
            [Description("Келісімшартты мақұлдау")]
            S16 = 17,
            [Description("Несие досьесін қабылдау")]
            S17 = 18,
            [Description("Жетілдіру")]
            S18 = 19,
            [Description("ПКБ қатесімен")]
            Error1 = 20,
            [Description("ГЦВП қатесімен")]
            Error2 = 21,
            [Description("Ыстық")]
            Hot = 22,
            [Description("Жылы")]
            Warm = 23,
            [Description("Салқын")]
            Cold = 24,
            [Description("Қабылданғандар")]
            Accepted = 25,
            [Description("Қайтарылғандар")]
            Cancelled = 26,
            [Description("Клиент бас тартуы")]
            CancelledByClient = 27,
            [Description("Үшінші бас тарту")]
            CancelledByThird = 28
        }

        public enum Pension
        {
            [Description("Нет")]
            None = 0,
            [Description("Зейнеткер")]
            Pension = 1,
            [Description("Әскери қызметкер")]
            Military = 2
        }

        public enum SocialStatus
        {
            
        }

    }
}
