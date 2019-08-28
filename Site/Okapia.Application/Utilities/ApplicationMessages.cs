namespace Okapia.Application.Utilities
{
    public static class ApplicationMessages
    {
        public const string DuplicatedRecord = "امکان ثبت رکورد تکراری وجود ندارد. این رکورد قبلا ثبت شده است.";
        public const string OperationSuccess = "اطلاعات با موفقیت ثبت شد";
        public const string SystemFailure = "خطایی رخ داده است لطفا با مدیر سیستم تماس بگیرید";
        public const string EntityNotExists = "اطلاعات درخواست شده یافت نشد. لطفا پس از بروزرسانی صفحه دوباره تلاش کنید";
        public const string DuplicatedUser = "نام کاربری تکراری است. لطفا نام کاربری جدید انتخاب کنید";
        public const string DuplicatedNationalCode = "کاربر با این کدملی قبلا ثبت نام شده است";
        public const string DuplicatedJob = "نام کاربری برای این شغل تکراری است";
        public const string DuplicatedListCard = "ورود کارت تکراری مجاز نمی باشد";
        public const string DuplicatedDatabaseCard = "کارت قبلا در سیستم ثبت شده است";
        public const string UserNotExists = "نام کاربری اشتباه است. لطفا دوباره تلاش کنید";
        public const string UserMobileNotExists = "شماره موبایلی که وارد کردید در سیستم ثبت نشده است.";
        public const string UserEmailNotExists = "ایمیلی که وارد کردید در سیستم ثبت نشده است.";
        public const string WrongVerificationCode = "کد احراز هویت وارد شده اشتباه است.";
        public const string IncorrectPassword = "کلمه رمز اشتباه است. لطفا دوباره تلاش کنید";
        public const string DuplicatedSlug = "اسلاگ نمی تواند تکراری باشد";
        public const string DuplicatedJobName = "نام شغل نمی تواند تکراری باشد";
        public const string DuplicatedEmployee = "کارمند دیگری با این نام کاربری ثبت شده است";
        public const string PictureIsRequired = "ایجاد یک عکس برای شغل اجراری است. لطفا عکس اول را پر کنید";
        public const string DuplicatedCategoryName = "نام گروه شغل نمی تواند تکراری باشد";
        public const string WrongUrlFormat = "فرمت آدرس وارد شده صحیح نیست";
        public static string NotSamePassword = "کلمه رمز و تکرار آن با هم برابر نیستند. لطفا دوباره تلاش کنید";
        public static string StartEndDateIsRequired = "تاریخ شروع و پایان اجراری است";
        public static string InvalidNationalCode = "کدملی وارد شده صحیح نیست";
        public static string IntroducingLimitation = "اعضای معرفی شده از حد مجاز بالاتر رفته است. لطفا با مدیر سیستم تماس بگیرید";

        //WebService Messages
        public static string UserAlreadyRegistered = "امکان ثبت نام وجود ندارد. کاربر با این کدملی قبلا در سیستم ثبت شده است";

        //SmsService Message
        public static string VerificationCodeSent = "کد احراز هویت برای شما ارسال شد";
    }
}
