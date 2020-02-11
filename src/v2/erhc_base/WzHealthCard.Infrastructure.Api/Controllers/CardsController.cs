
namespace WzHealthCard.Infrastructure.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using WzHealthCard.Infrastructure.Api.DataAccess.Erhc;
    using WzHealthCard.Infrastructure.Api.Extensions;
    using WzHealthCard.Infrastructure.Api.Models;
    using WzHealthCard.Infrastructure.Api.Repositories.Erhc;
    using WzHealthCard.Infrastructure.Api.UnitOfWorks;

    [Route("api/v1/[controller]")]
    [ApiController]
    public class CardsController : BaseApi
    {
        private readonly ILogger<CardsController> logger;

        private readonly CardRepository cardRepo;
        private readonly CardExtendRepository cardExtRepo;
        private readonly ErhcUnitOfWork erhcUow;

        public CardsController(
            ILogger<CardsController> logger,
            CardRepository cardRepo,
            CardExtendRepository cardExtRepo,
            ErhcUnitOfWork erhcUow)
        {
            this.logger = logger;

            this.cardRepo = cardRepo;
            this.cardExtRepo = cardExtRepo;
            this.erhcUow = erhcUow;
        }

        private Func<CardEntity, CardExtendEntity, CardQueryResponse> QueryResultConverter = (card, extend) => new CardQueryResponse
        {
            address = card.Address,
            cardNo = card.ErhcCardNo,
            citizenship = card.Citizenship,
            createdAt = card.CreatedAt,
            empi = card.Empi,
            endDate = card.ErhcEndDate,
            id = card.Id,
            idCardNo = card.IdCardNo,
            idCardType = card.IdCardType,
            idCardValue = card.IdCardValue,
            isApply = card.IsApply,
            isClosed = card.IsClosed,
            orgCode = card.IssuerOrgCode,
            orgName = card.IssuerOrgName,
            name = card.Name,
            nationality = card.Nationality,
            qrCodeImageData = card.QrCodeImageData,
            qrCodeType = card.QrCodeType,
            sex = card.Sex,
            tel = card.Tel,
            updatedAt = card.UpdatedAt,
            userSign = card.UserSign,
            extend = new CardExtendQueryResponse
            {
                addr = new[] { extend.AddrLv0, extend.AddrLv1, extend.AddrLv2, extend.AddrLv3, extend.AddrLv4, extend.AddrLv5 },
                cardId = extend.ErhcCardId,
                createdAt = extend.CreatedAt,
                dAddr = new[] { extend.DAddrLv0, extend.DAddrLv1, extend.DAddrLv2, extend.DAddrLv3, extend.DAddrLv4, extend.DAddrLv5 },
                id = extend.Id,
                sQrCode = extend.StaticQrCode,
                updatedAt = extend.UpdatedAt
            }
        };

        [HttpGet, Route("query")]
        public async Task<ActionResult> Query(string name, string idCardType, string idCardValue)
        {
            var response = Execute(() =>
            {
                var query = from c in cardRepo.View
                            join e in cardExtRepo.View on c.Id equals e.ErhcCardId into cardExt
                            from ce in cardExt.DefaultIfEmpty()
                            select new
                            {
                                card = c,
                                extend = ce ?? new CardExtendEntity()
                            };

                if (string.IsNullOrEmpty(name) == false)
                {
                    query = query.Where(p => p.card.Name == name);
                }

                if (string.IsNullOrEmpty(idCardType) == false)
                {
                    query = query.Where(p => p.card.IdCardType == idCardType);
                }

                if (string.IsNullOrEmpty(idCardValue) == false)
                {
                    query = query.Where(p => p.card.IdCardValue == idCardValue);
                }

                var result = query?.ToArray().Select(p => QueryResultConverter(p.card, p.extend));

                return Ok(result);
            });

            return await Task.FromResult(response);
        }

        private CardEntity UpdateOrCreateCard(CardUpdateRequest request)
        {
            var isExists = true;

            //var qCard = cardRepo.View.FirstOrDefault(p => p.Name == request.name && p.IdCardType == request.idCardType && p.IdCardValue == request.idCardValue);
            var qCard = cardRepo.View.FirstOrDefault(p => p.IdCardType == request.idCardType && p.IdCardValue == request.idCardValue);

            logger.LogInformation($"Query {nameof(CardEntity)} Result: {qCard.GetJsonString()}");

            if (qCard == null || qCard.Id == 0)
            {
                isExists = false;

                qCard = new CardEntity
                {
                    CreatedAt = DateTime.Now
                };
            }

            qCard.Address = request.address;
            qCard.Citizenship = request.citizenship;
            qCard.Empi = request.empi;
            qCard.ErhcCardNo = request.cardNo;
            qCard.ErhcEndDate = request.endDate;
            //item.Id = arg.id;
            //qCard.IdCardNo = request.args?.idCardNo;
            qCard.IdCardType = request.idCardType;
            qCard.IdCardValue = request.idCardValue;
            //qCard.IsApply = request.args?.isApply;
            qCard.IsClosed = false;
            //qCard.IssuerOrgCode = request.args?.orgCode;
            //qCard.IssuerOrgName = request.args?.orgName;
            qCard.Name = request.name;
            qCard.Nationality = request.nationality;
            //qCard.QrCodeImageData = request.args?.qrCodeImageData;
            //qCard.QrCodeType = request.args?.qrCodeType;
            qCard.Sex = request.sex;
            qCard.Tel = request.tel;
            qCard.UpdatedAt = DateTime.Now;
            //qCard.UserSign = request.args?.userSign;

            if (isExists)
            {
                cardRepo.Update(qCard);
            }
            else
            {
                cardRepo.Insert(qCard);
            }

            logger.LogInformation($"Commit {nameof(CardEntity)} Record: {qCard.GetJsonString()}");

            var result = erhcUow.Commit();

            logger.LogInformation($"Commit {nameof(CardEntity)} Result: {result}");

            return qCard;
        }

        private void UpdateOrCreateCardExtend(CardExtendUpdateRequest extend, long cardId)
        {
            var isExists = true;

            var qExtend = cardExtRepo.View.FirstOrDefault(p => p.ErhcCardId == cardId);

            logger.LogInformation($"Query {nameof(CardExtendEntity)} Result: {qExtend.GetJsonString()}");

            if (qExtend == null || qExtend.Id == 0)
            {
                isExists = false;

                qExtend = new CardExtendEntity
                {
                    ErhcCardId = cardId,
                    CreatedAt = DateTime.Now
                };
            }

            qExtend.AddrLv0 = extend?.addr?.Length >= 1 ? extend.addr[0] : string.Empty;
            qExtend.AddrLv1 = extend?.addr?.Length >= 2 ? extend.addr[1] : string.Empty;
            qExtend.AddrLv2 = extend?.addr?.Length >= 3 ? extend.addr[2] : string.Empty;
            qExtend.AddrLv3 = extend?.addr?.Length >= 4 ? extend.addr[3] : string.Empty;
            qExtend.AddrLv4 = extend?.addr?.Length >= 5 ? extend.addr[4] : string.Empty;
            qExtend.AddrLv5 = extend?.addr?.Length >= 6 ? extend.addr[5] : string.Empty;

            qExtend.DAddrLv0 = extend?.dAddr?.Length >= 1 ? extend.dAddr[0] : string.Empty;
            qExtend.DAddrLv1 = extend?.dAddr?.Length >= 2 ? extend.dAddr[1] : string.Empty;
            qExtend.DAddrLv2 = extend?.dAddr?.Length >= 3 ? extend.dAddr[2] : string.Empty;
            qExtend.DAddrLv3 = extend?.dAddr?.Length >= 4 ? extend.dAddr[3] : string.Empty;
            qExtend.DAddrLv4 = extend?.dAddr?.Length >= 5 ? extend.dAddr[4] : string.Empty;
            qExtend.DAddrLv5 = extend?.dAddr?.Length >= 6 ? extend.dAddr[5] : string.Empty;

            //qExtend.ErhcCardId = qCard.Id;
            //qExtend.Id = "";
            //qExtend.StaticQrCode = extend?.sQrCode;
            qExtend.UpdatedAt = DateTime.Now;

            if (isExists)
            {
                cardExtRepo.Update(qExtend);
            }
            else
            {
                cardExtRepo.Insert(qExtend);
            }

            logger.LogInformation($"Commit {nameof(CardExtendEntity)} Record: {qExtend.GetJsonString()}");

            var result = erhcUow.Commit();

            logger.LogInformation($"Commit {nameof(CardExtendEntity)} Result: {result}");
        }

        [HttpPut, Route("update")]
        public async Task<ActionResult> Update([FromBody]CardUpdateRequest request)
        {
            var response = Execute(() =>
            {
                // step.1 update or insert card
                var card = UpdateOrCreateCard(request);

                // step.2 update or insert extend
                UpdateOrCreateCardExtend(request.extend, card.Id);

                return Accepted(new CardUpdateResponse { id = card.Id });
            });

            return await Task.FromResult(response);
        }
    }
}