namespace Okapia.Domain
{
    public static class ValidationMessages
    {
        public const string Required = "این فیلد نمی تواند خالی باشد";
        public const string ProvinceRange = "لطفا استان را انتخاب کنید";
        public const string CityRange = "لطفا شهر را انتخاب کنید";
        public const string DistrictRange = "لطفا منطقه را انتخاب کنید";
        public const string NeighborhoodRange = "لطفا محله را انتخاب کنید";
        public const string CategoryRange = "لطفا دسته بندی شغل را انتخاب کنید";
        public const string NationalCodeStringLength = "طول کد ملی ۱۰ رقم است";
        public const string CardStringLength = "طول شماره کارت ۱۶ رقم است";
    }
}