using ERP.Web.Models.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace ERP.Web.Areas.HopLong.Controllers
{
    public class ImportExcelController : Controller
    {
        int so_dong_thanh_cong;
        int dong;
        HOPLONG_DATABASEEntities db = new HOPLONG_DATABASEEntities();
        // GET: HopLong/ImportExcel

        #region "Import Hàng Hóa"
        public ActionResult Import_Hanghoa()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Import_Hanghoa(HttpPostedFileBase file)
        {
            try
            {
                DataSet ds = new DataSet();
                if (Request.Files["file"].ContentLength > 0)
                {
                    string fileExtension = System.IO.Path.GetExtension(Request.Files["file"].FileName);

                    if (fileExtension == ".xls" || fileExtension == ".xlsx")
                    {
                        string fileLocation = Server.MapPath("~/Content/") + Request.Files["file"].FileName;
                        if (System.IO.File.Exists(fileLocation))
                        {

                            //System.IO.File.Delete(fileLocation);
                        }
                        Request.Files["file"].SaveAs(fileLocation);
                        string excelConnectionString = string.Empty;
                        excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileLocation + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                        //connection String for xls file format.
                        if (fileExtension == ".xls")
                        {
                            excelConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileLocation + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
                        }
                        //connection String for xlsx file format.
                        else if (fileExtension == ".xlsx")
                        {

                            excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileLocation + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                        }
                        //Create Connection to Excel work book and add oledb namespace
                        OleDbConnection excelConnection = new OleDbConnection(excelConnectionString);
                        excelConnection.Open();
                        DataTable dt = new DataTable();

                        dt = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                        if (dt == null)
                        {
                            return null;
                        }

                        String[] excelSheets = new String[dt.Rows.Count];
                        int t = 0;
                        //excel data saves in temp file here.
                        foreach (DataRow row in dt.Rows)
                        {
                            excelSheets[t] = row["TABLE_NAME"].ToString();
                            t++;
                        }
                        OleDbConnection excelConnection1 = new OleDbConnection(excelConnectionString);


                        string query = string.Format("Select * from [{0}]", excelSheets[0]);
                        using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, excelConnection1))
                        {
                            dataAdapter.Fill(ds);
                        }
                    }
                    if (fileExtension.ToString().ToLower().Equals(".xml"))
                    {
                        string fileLocation = Server.MapPath("~/Content/") + Request.Files["FileUpload"].FileName;
                        if (System.IO.File.Exists(fileLocation))
                        {
                            System.IO.File.Delete(fileLocation);
                        }

                        Request.Files["FileUpload"].SaveAs(fileLocation);
                        XmlTextReader xmlreader = new XmlTextReader(fileLocation);
                        // DataSet ds = new DataSet();
                        ds.ReadXml(xmlreader);
                        xmlreader.Close();
                    }
                    so_dong_thanh_cong = 0;
                    dong = 0;
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        DM_HANG_HOA HH = new DM_HANG_HOA();
                        HH.MA_HANG_HT = ds.Tables[0].Rows[i][0].ToString();
                        HH.MA_HANG_NHAP = ds.Tables[0].Rows[i][1].ToString();
                        HH.TEN_HANG = ds.Tables[0].Rows[i][2].ToString();
                        HH.MA_NHOM_HANG = ds.Tables[0].Rows[i][3].ToString();
                        HH.SERI = ds.Tables[0].Rows[i][4].ToString();
                        HH.DON_VI_TINH = ds.Tables[0].Rows[i][5].ToString();
                        HH.XUAT_XU = ds.Tables[0].Rows[i][6].ToString();
                        HH.MODEL_DAC_BIET= Convert.ToBoolean(ds.Tables[0].Rows[i][7]);
                        HH.HINH_ANH = ds.Tables[0].Rows[i][8].ToString();
                        HH.DAC_TINH = ds.Tables[0].Rows[i][9].ToString();
                        HH.GHI_CHU = ds.Tables[0].Rows[i][10].ToString();
                        HH.TK_HACH_TOAN_KHO = Convert.ToInt32(ds.Tables[0].Rows[i][11]);
                        HH.TK_DOANH_THU = Convert.ToInt32(ds.Tables[0].Rows[i][12]);
                        HH.TK_CHI_PHI = Convert.ToInt32(ds.Tables[0].Rows[i][13]);

                        db.DM_HANG_HOA.Add(HH);

                        db.SaveChanges();
                        so_dong_thanh_cong++;
                        dong = i;
                    }

                }
            }
            catch (Exception Ex)
            {
                ViewBag.Error = " Đã xảy ra lỗi, Liên hệ ngay với admin. " + Environment.NewLine + " Thông tin chi tiết về lỗi:" + Environment.NewLine + Ex;
                ViewBag.Information = "Lỗi tại dòng thứ: " + dong;
                
            }
            finally
            {
                ViewBag.Message = "Đã import thành công " + so_dong_thanh_cong + " dòng";
            }

            return View();
        }

        #endregion

        #region "Import Tồn kho hãng"
        public ActionResult Import_TonKhoHang()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Import_TonKhoHang(HttpPostedFileBase file)
        {
            try
            {
                DataSet ds = new DataSet();
                if (Request.Files["file"].ContentLength > 0)
                {
                    string fileExtension = System.IO.Path.GetExtension(Request.Files["file"].FileName);

                    if (fileExtension == ".xls" || fileExtension == ".xlsx")
                    {
                        string fileLocation = Server.MapPath("~/Content/") + Request.Files["file"].FileName;
                        if (System.IO.File.Exists(fileLocation))
                        {

                            //System.IO.File.Delete(fileLocation);
                        }
                        Request.Files["file"].SaveAs(fileLocation);
                        string excelConnectionString = string.Empty;
                        excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileLocation + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                        //connection String for xls file format.
                        if (fileExtension == ".xls")
                        {
                            excelConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileLocation + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
                        }
                        //connection String for xlsx file format.
                        else if (fileExtension == ".xlsx")
                        {

                            excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileLocation + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                        }
                        //Create Connection to Excel work book and add oledb namespace
                        OleDbConnection excelConnection = new OleDbConnection(excelConnectionString);
                        excelConnection.Open();
                        DataTable dt = new DataTable();

                        dt = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                        if (dt == null)
                        {
                            return null;
                        }

                        String[] excelSheets = new String[dt.Rows.Count];
                        int t = 0;
                        //excel data saves in temp file here.
                        foreach (DataRow row in dt.Rows)
                        {
                            excelSheets[t] = row["TABLE_NAME"].ToString();
                            t++;
                        }
                        OleDbConnection excelConnection1 = new OleDbConnection(excelConnectionString);


                        string query = string.Format("Select * from [{0}]", excelSheets[0]);
                        using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, excelConnection1))
                        {
                            dataAdapter.Fill(ds);
                        }
                    }
                    if (fileExtension.ToString().ToLower().Equals(".xml"))
                    {
                        string fileLocation = Server.MapPath("~/Content/") + Request.Files["FileUpload"].FileName;
                        if (System.IO.File.Exists(fileLocation))
                        {
                            System.IO.File.Delete(fileLocation);
                        }

                        Request.Files["FileUpload"].SaveAs(fileLocation);
                        XmlTextReader xmlreader = new XmlTextReader(fileLocation);
                        // DataSet ds = new DataSet();
                        ds.ReadXml(xmlreader);
                        xmlreader.Close();
                    }
                    so_dong_thanh_cong = 0;
                    dong = 0;
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        DM_TONKHO_HANG HH = new DM_TONKHO_HANG();
                        HH.MA_HANG_HT = ds.Tables[0].Rows[i][0].ToString();
                        HH.MA_NHOM_HANG = ds.Tables[0].Rows[i][1].ToString();
                        HH.SL_TON = Convert.ToInt32(ds.Tables[0].Rows[i][2]);

                        db.DM_TONKHO_HANG.Add(HH);

                        db.SaveChanges();
                        so_dong_thanh_cong++;
                        dong = i;
                    }

                }
            }
            catch (Exception Ex)
            {
                ViewBag.Error = " Đã xảy ra lỗi, Liên hệ ngay với admin. " + Environment.NewLine + " Thông tin chi tiết về lỗi:" + Environment.NewLine + Ex;
                ViewBag.Information = "Lỗi tại dòng thứ: " + dong;

            }
            finally
            {
                ViewBag.Message = "Đã import thành công " + so_dong_thanh_cong + " dòng";
            }

            return View();
        }

        #endregion
    }
}