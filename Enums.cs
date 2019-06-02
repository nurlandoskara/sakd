using System.ComponentModel;
using System.Security.Cryptography;

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
            [Description("Жарнама")]
            Advertisement = 0,
            [Description("Кеңес арқылы")]
            Advice = 1
        }
        public enum ParentsStatus
        {
            [Description("Әке-шешесі")]
            Both = 0,
            [Description("Әкесі")]
            Father = 1,
            [Description("Анасы")]
            Mother = 2
        }
        public enum FamilyStatus
        {
            [Description("Тұрмыс құрмаған")]
            NotMarried = 0,
            [Description("Тұрмыс құрған")]
            Married = 1
        }
        public enum RelationType
        {
            [Description("Ата-анасы")]
            Parents = 0,
            [Description("Бауырлары")]
            Siblings = 1,
            [Description("Достары")]
            Friends = 2,
            [Description("Жұмыстастары")]
            Colleagues = 3
        }
        public enum DocumentOrganization
        {
            [Description("ӘМ")]
            MU = 0,
            [Description("ІІМ")]
            MVD = 1
        }
        public enum DocumentType
        {
            [Description("Жеке басын куәләндіру куәлігі")]
            Identity = 0,
            [Description("Паспорт")]
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
            [Description("1.Калькуляторды толтыру")]
            S1 = 1,
            [Description("2.Құжаттарды басып шығару және қол қою 1")]
            S2 = 2,
            [Description("3.Автоматты өңдеу")]
            S3 = 3,
            [Description("4.Поведенческий скоринг")]
            S4 = 4,
            [Description("5.Отчетті сұрау")]
            S5 = 5,
            [Description("6.ПКБ. Рефинансирование")]
            S6 = 6,
            [Description("7.Запрос отчета ГЦВП")]
            S7 = 7,
            [Description("8.Скоринг 2")]
            S8 = 8,
            [Description("8.1.Алдын ала есептеу")]
            S81 = 9,
            [Description("9.Скоринг 3")]
            S9 = 10,
            [Description("10.Тексеру")]
            S10 = 11,
            [Description("11.УЛ шешім қабылдау")]
            S11 = 12,
            [Description("12.Хабарлау және клиенттің шешімі")]
            S12 = 13,
            [Description("13.Келісім шартты тіркеу")]
            S13 = 14,
            [Description("14.Құжаттарды басып шығару және қол қою 2")]
            S14 = 15,
            [Description("15.Акцепт")]
            S15 = 16,
            [Description("16.Келісімшартты мақұлдау")]
            S16 = 17,
            [Description("17.Несие досьесін қабылдау")]
            S17 = 18,
            [Description("18.Жетілдіру")]
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
