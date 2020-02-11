
namespace WzHealthCard.Infrastructure.Api.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    //public class CardQueryRequestArgs
    //{
    //    public string name { get; set; }

    //    public string idCardType { get; set; }

    //    public string idCardValue { get; set; }
    //}

    //public class CardQueryRequest : BaseRequestModel<CardQueryRequestArgs> { }

    public class CardExtendQueryResponse
    {
        public long id { get; set; }

        public string[] addr { get; set; }

        public string[] dAddr { get; set; }

        public DateTime createdAt { get; set; }

        public DateTime updatedAt { get; set; }

        public long cardId { get; set; }

        public string sQrCode { get; set; }
    }

    public class CardQueryResponse
    {
        public long id { get; set; }

        public string empi { get; set; }

        public string cardNo { get; set; }

        public string name { get; set; }

        public string sex { get; set; }

        public string idCardNo { get; set; }

        public string idCardType { get; set; }

        public string idCardValue { get; set; }

        public string citizenship { get; set; }

        public string nationality { get; set; }

        public string tel { get; set; }

        public string address { get; set; }

        public string orgCode { get; set; }

        public string orgName { get; set; }

        public string endDate { get; set; }

        public string qrCodeType { get; set; }

        public string qrCodeImageData { get; set; }

        public string userSign { get; set; }

        public string isApply { get; set; }

        public bool? isClosed { get; set; }

        public DateTime createdAt { get; set; }

        public DateTime updatedAt { get; set; }

        public CardExtendQueryResponse extend { get; set; }
    }

    public class CardExtendUpdateRequest
    {
        //public long id { get; set; }

        public string[] addr { get; set; }

        public string[] dAddr { get; set; }

        //public DateTime createdAt { get; set; }

        //public DateTime updatedAt { get; set; }

        public long cardId { get; set; }

        //public string sQrCode { get; set; }
    }

    public class CardUpdateRequest
    {
        //public long id { get; set; }

        public string empi { get; set; }

        public string cardNo { get; set; }

        [Required]
        public string name { get; set; }

        public string sex { get; set; }

        //public string idCardNo { get; set; }

        [Required]
        public string idCardType { get; set; }

        [Required]
        public string idCardValue { get; set; }

        public string citizenship { get; set; }

        public string nationality { get; set; }

        public string tel { get; set; }

        public string address { get; set; }

        //public string orgCode { get; set; }

        //public string orgName { get; set; }

        public string endDate { get; set; }

        //public string qrCodeType { get; set; }

        //public string qrCodeImageData { get; set; }

        //public string userSign { get; set; }

        //public string isApply { get; set; }

        //public bool? isClosed { get; set; }

        //public DateTime createdAt { get; set; }

        //public DateTime updatedAt { get; set; } = DateTime.Now;

        public CardExtendUpdateRequest extend { get; set; }
    }

    //public class CardUpdateRequest : BaseRequestModel<CardUpdateRequestArgs> { }

    public class CardUpdateResponse
    {
        public long id { get; set; }
    }
}
