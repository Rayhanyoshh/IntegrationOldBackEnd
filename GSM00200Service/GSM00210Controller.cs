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
            R_Exception loException = new R_Exception();
            IAsyncEnumerable<GSM00210DTOnon> loRtn = null;
            GSM00210Cls loCls;
            List<GSM00210DTOnon> loRtnTemp;
            try
            {
                //string lcCompId = R_BackGlobalVar.COMPANY_ID;
                string lcCompId = R_Utility.R_GetStreamingContext<string>(GSM00210Constant.CCOMPANY_ID);
                string lcTableId = R_Utility.R_GetStreamingContext<string>(GSM00210Constant.CTABLE_ID);
                loCls = new GSM00210Cls();
                loRtnTemp = loCls.GetTableDTList(lcCompId, lcTableId);
                loRtn = GetGSM00210Stream(loRtnTemp);
            }
            catch (Exception ex)
            {
                loException.Add(ex);
            }
            loException.ThrowExceptionIfErrors();
            return loRtn;
        }

        [HttpPost]
        public R_ServiceDeleteResultDTO R_ServiceDelete(R_ServiceDeleteParameterDTO<GSM00210DTO> poParameter)
        {
            R_Exception loException = new R_Exception();
            R_ServiceDeleteResultDTO loRtn = null;
            GSM00210Cls loCls;
            try
            {
                loCls = new GSM00210Cls();
                loCls.R_Delete(poParameter.Entity);

            }
            catch (Exception ex)
            {
                loException.Add(ex);
            }
            loException.ThrowExceptionIfErrors();
            return loRtn;
        }

        [HttpPost]
        public R_ServiceGetRecordResultDTO<GSM00210DTO> R_ServiceGetRecord(R_ServiceGetRecordParameterDTO<GSM00210DTO> poParameter)
        {
            R_Exception loException = new R_Exception();
            R_ServiceGetRecordResultDTO<GSM00210DTO> loRtn = null;
            GSM00210Cls loCls;
            try
            {
                loCls = new GSM00210Cls();
                loRtn = new R_ServiceGetRecordResultDTO<GSM00210DTO>();
                loRtn.data = loCls.R_GetRecord(poParameter.Entity);
            }
            catch (Exception ex)
            {
                loException.Add(ex);
            }
            loException.ThrowExceptionIfErrors();
            return loRtn;
        }

        [HttpPost]
        public R_ServiceSaveResultDTO<GSM00210DTO> R_ServiceSave(R_ServiceSaveParameterDTO<GSM00210DTO> poParameter)
        {
            R_Exception loException = new R_Exception();
            R_ServiceSaveResultDTO<GSM00210DTO> loRtn = null;
            GSM00210Cls loCls;
            try
            {
                loCls = new GSM00210Cls();
                loRtn = new R_ServiceSaveResultDTO<GSM00210DTO>();
                loRtn.data = loCls.R_Save(poParameter.Entity, poParameter.CRUDMode);
            }
            catch (Exception ex)
            {
                loException.Add(ex);
            }
            loException.ThrowExceptionIfErrors();
            return loRtn;
        }

        #region "Helper"
        private async IAsyncEnumerable<GSM00210DTOnon> GetGSM00210Stream(List<GSM00210DTOnon> poParameter)
        {
            foreach (GSM00210DTOnon item in poParameter)
            {
                yield return item;
            }
        }
        #endregion

    }
}
