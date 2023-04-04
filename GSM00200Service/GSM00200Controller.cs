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

    public class GSM00200Controller : ControllerBase, IGSM00200
    {
        [HttpPost]
        public IAsyncEnumerable<GSM00200DTOnon> GetTableHDList()
        {
            R_Exception loException = new R_Exception();
            IAsyncEnumerable<GSM00200DTOnon> loRtn = null;
            GSM00200Cls loCls;
            List<GSM00200DTOnon> loRtnTemp;
            string loCompId;


            try
            {
                loCompId = R_Utility.R_GetStreamingContext<string>(GSM00200Constant.CCOMPANY_ID);
                loCls = new GSM00200Cls();

                loRtnTemp = loCls.GetTableHDList(loCompId);
                loRtn = GetGSM00200(loRtnTemp);
            }
            catch (Exception ex)
            {
                loException.Add(ex);
            };
        EndBlock:
            loException.ThrowExceptionIfErrors();

            return loRtn;
        }

        [HttpPost]
        public R_ServiceDeleteResultDTO R_ServiceDelete(R_ServiceDeleteParameterDTO<GSM00200DTO> poParameter)
        {
            R_Exception loException = new R_Exception();
            R_ServiceDeleteResultDTO loRtn = null;
            GSM00200Cls loCls;

            try
            {
                loCls = new GSM00200Cls();
                loRtn = new R_ServiceDeleteResultDTO();
                loCls.R_Delete(poParameter.Entity);
            }
            catch (Exception ex)
            {
                loException.Add(ex);
            };
        EndBlock:
            loException.ThrowExceptionIfErrors();

            return loRtn;
        }


        [HttpPost]
        public R_ServiceGetRecordResultDTO<GSM00200DTO> R_ServiceGetRecord(R_ServiceGetRecordParameterDTO<GSM00200DTO> poParameter)
        {
            R_Exception loException = new R_Exception();
            R_ServiceGetRecordResultDTO<GSM00200DTO> loRtn = null;
            GSM00200Cls loCls;

            try
            {
                loCls = new GSM00200Cls();
                loRtn = new R_ServiceGetRecordResultDTO<GSM00200DTO>();
                loRtn.data = loCls.R_GetRecord(poParameter.Entity);
            }
            catch (Exception ex)
            {
                loException.Add(ex);
            };
        EndBlock:
            loException.ThrowExceptionIfErrors();

            return loRtn;
        }

        [HttpPost]
        public R_ServiceSaveResultDTO<GSM00200DTO> R_ServiceSave(R_ServiceSaveParameterDTO<GSM00200DTO> poParameter)
        {
            R_Exception loException = new R_Exception();
            R_ServiceSaveResultDTO<GSM00200DTO> loRtn = null;
            GSM00200Cls loCls;

            try
            {
                loCls = new GSM00200Cls();
                loRtn = new R_ServiceSaveResultDTO<GSM00200DTO>();
                loRtn.data = loCls.R_Save(poParameter.Entity, poParameter.CRUDMode);
            }
            catch (Exception ex)
            {
                loException.Add(ex);
            };
        EndBlock:
            loException.ThrowExceptionIfErrors();

            return loRtn;
        }

        //class helper
        private async IAsyncEnumerable<GSM00200DTOnon> GetGSM00200(List<GSM00200DTOnon> poParameter)
        {
            foreach (var item in poParameter)
            {
                yield return item;
            }
        }
    }
}
