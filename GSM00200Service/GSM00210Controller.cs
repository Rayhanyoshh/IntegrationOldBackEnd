using System;
using R_Common;
using R_BackEnd;
using R_CommonFrontBackAPI;
using Microsoft.AspNetCore.Mvc;

using GSM00200Common;
using GSM00200Back;

namespace GSM00200Service
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GSM00210Controller : ControllerBase, IGSM00210
    {
        [HttpPost]
        public IAsyncEnumerable<GSM00210DTOnon> GetTableDTList()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public R_ServiceDeleteResultDTO R_ServiceDelete(R_ServiceDeleteParameterDTO<GSM00210DTO> poParameter)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public R_ServiceGetRecordResultDTO<GSM00210DTO> R_ServiceGetRecord(R_ServiceGetRecordParameterDTO<GSM00210DTO> poParameter)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public R_ServiceSaveResultDTO<GSM00210DTO> R_ServiceSave(R_ServiceSaveParameterDTO<GSM00210DTO> poParameter)
        {
            throw new NotImplementedException();
        }


    }
}
