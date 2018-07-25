using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WizardMVC.Models;
using WizardMVC.Utils;

namespace WizardMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
        public ActionResult WizStep1()
        {
            // user can come to this step from two different ways
            // 1. starting the wizard, 2. user came back from step 2
            CustomerInfo cinfo = null;
            if (SessionFacade.WIZSTEP1 == null) // starting from beginning
                cinfo = new CustomerInfo();
            else
                cinfo = SessionFacade.WIZSTEP1; // user is coming back from step
            
        return View(cinfo);
        }
        [HttpPost]
        public ActionResult WizStep1(CustomerInfo cinfo)
        {
            ModelState.Remove("StreetAddress");
            ModelState.Remove("City");
            ModelState.Remove("State");
            ModelState.Remove("Telephone");
            ModelState.Remove("CellPhone");
            ModelState.Remove("CustomerPin");
            ModelState.Remove("CardNum");
            ModelState.Remove("ExpDate");
            ModelState.Remove("Coach");
            ModelState.Remove("SoccerBall");
            ModelState.Remove("SoccerShoes");
            ModelState.Remove("EnergyDrinks");
            ModelState.Remove("SoccerJersy");

            if (ModelState.IsValid)
            {
                SessionFacade.WIZSTEP1 = cinfo;
                return RedirectToAction("WizStep2");
            }
            return View(cinfo);
        }
        public ActionResult WizStep2()
        {
            // some one can come to this step three different ways
            // 1. directly to this step without going through step 1
            // 2. From step1 to this step 2
            // 3. Back from step 3
            if (SessionFacade.WIZSTEP1 == null) // some one skipped step 1
                return RedirectToAction("WizStep1");
            else
            {
                CustomerInfo ci = null;
                if (SessionFacade.WIZSTEP2 != null) // coming back from step 3
                    ci = SessionFacade.WIZSTEP2;
                else
                    ci = SessionFacade.WIZSTEP1; // from step 1 to this step2
                return View(ci);
            }
        }
        [HttpPost]
        public ActionResult WizStep2(string btnPrev, string btnNext, CustomerInfo
       cinfo)
        {
            if (btnPrev != null)
            {
                if (btnPrev.ToUpper() == "PREV")
                {
                    SessionFacade.WIZSTEP2 = null; // remove data for step 2
                    return RedirectToAction("WizStep1");
                }
            }
            if (SessionFacade.WIZSTEP1 == null)
                return RedirectToAction("WizStep1");
            else
            {
                CustomerInfo ci = SessionFacade.WIZSTEP1;
                ModelState.Remove("FirstName");
                ModelState.Remove("LastName");
                ModelState.Remove("Email");
                ModelState.Remove("Telephone");
                ModelState.Remove("CellPhone");
                ModelState.Remove("CustomerPin");
                ModelState.Remove("CardNum");
                ModelState.Remove("ExpDate");
                ModelState.Remove("SoccerField");
                ModelState.Remove("SoccerBall");
                ModelState.Remove("SoccerShoes");
                ModelState.Remove("EnergyDrinks");
                ModelState.Remove("SoccerJersy");


                if (ModelState.IsValid)
                {
                    if (btnNext != null)
                    {
                        if (btnNext.ToUpper() == "NEXT")
                        {
                            ci.StreetAddress = cinfo.StreetAddress;
                            ci.City = cinfo.City;
                            ci.State = cinfo.State;
                            SessionFacade.WIZSTEP2 = ci;
                            return RedirectToAction("WizStep3");
                        }
                    }
                }
            }
            return View(cinfo);
        }
        public ActionResult WizStep3()
        {
            // 3 ways some one can come to this step
            if (SessionFacade.WIZSTEP2 == null)
                return RedirectToAction("WizStep2");
            else
            {
                CustomerInfo ci = null;
                if (SessionFacade.WIZSTEP3 != null) // from prev
                    ci = SessionFacade.WIZSTEP3;
                else
                    ci = SessionFacade.WIZSTEP2;
                return View(ci);
            }
        }
        [HttpPost]
        public ActionResult WizStep3(string btnPrev, string btnNext, CustomerInfo
       cinfo)
        {
            if (btnPrev != null)
            {
                if (btnPrev.ToUpper() == "PREV")
                {
                    SessionFacade.WIZSTEP3 = null; // remove data for step 2
                    return RedirectToAction("WizStep2");
                }
            }
            if (SessionFacade.WIZSTEP2 == null)
                return RedirectToAction("WizStep2");
            else
            { // normal flow from step 2 to step 3
                CustomerInfo ci = SessionFacade.WIZSTEP2;
                ModelState.Remove("FirstName");
                ModelState.Remove("LastName");
                ModelState.Remove("Email");
                ModelState.Remove("StreetAddress");
                ModelState.Remove("City");
                ModelState.Remove("State");
                ModelState.Remove("CardNum");
                ModelState.Remove("ExpDate");
                ModelState.Remove("SoccerField");
                ModelState.Remove("Coach");
                ModelState.Remove("CustomerPin");

                if (ModelState.IsValid)
                {
                   if (btnNext != null)
                    {
                        if (btnNext.ToUpper() == "NEXT")
                        { 
                            ci.Telephone = cinfo.Telephone;
                            ci.CellPhone = cinfo.CellPhone;
                            ci.SoccerBall = cinfo.SoccerBall;
                            ci.SoccerShoes = cinfo.SoccerShoes;
                            ci.EnergyDrinks = cinfo.EnergyDrinks;
                            ci.SoccerJersy = cinfo.SoccerJersy;

                            SessionFacade.WIZSTEP3 = ci;
                            return RedirectToAction("WizStep4");
                        }
                    }
                }
            }
            return View(cinfo);
        }
        public ActionResult WizStep4()
        {
            // 3 ways some one can come to this step
            if (SessionFacade.WIZSTEP3 == null)
                return RedirectToAction("WizStep3");
            else if (SessionFacade.WIZSTEP2 == null)
            {
                return RedirectToAction("WizStep2");
            }
            else
            {
                CustomerInfo ci = null;
                if (SessionFacade.WIZSTEP4 != null) // from prev
                    ci = SessionFacade.WIZSTEP4;
                else
                {
                    if (SessionFacade.WIZSTEP3 != null)
                        ci = SessionFacade.WIZSTEP3;
                    else
                        ci = SessionFacade.WIZSTEP2;
                }

                return View(ci);
            }
        }
        [HttpPost]
        public ActionResult WizStep4(string btnPrev, string btnNext, CustomerInfo
       cinfo)
        {
            if (btnPrev != null)
            {
                if (btnPrev.ToUpper() == "PREV")
                {
                    SessionFacade.WIZSTEP4 = null; // remove data for step 3
                    return RedirectToAction("WizStep3");
                }
            }
            if (SessionFacade.WIZSTEP3 == null)
                return RedirectToAction("WizStep3");
            else if (SessionFacade.WIZSTEP2 == null)
                return RedirectToAction("WizStep2");
            else
            { // normal flow from step 2 to step 4

                CustomerInfo ci = SessionFacade.WIZSTEP3;

                ModelState.Remove("FirstName");
                ModelState.Remove("LastName");
                ModelState.Remove("Email");
                ModelState.Remove("StreetAddress");
                ModelState.Remove("City");
                ModelState.Remove("State");
                ModelState.Remove("Telephone");
                ModelState.Remove("CellPhone");
                ModelState.Remove("SoccerField");
                ModelState.Remove("Coach");
                ModelState.Remove("SoccerBall");
                ModelState.Remove("SoccerShoes");
                ModelState.Remove("EnergyDrinks");
                ModelState.Remove("SoccerJersy");

                if (ModelState.IsValid)
                {
                    if (btnNext != null)
                    {
                        if (btnNext.ToUpper() == "NEXT")
                        {

                            int Total= (Convert.ToInt32(ci.SoccerBall)*50 + Convert.ToInt32(ci.SoccerShoes)*100 + Convert.ToInt32(ci.SoccerJersy)*200 + Convert.ToInt32(ci.EnergyDrinks)*10);
                            ci.TotalCost = Total.ToString();
                            ci.CardNum = cinfo.CardNum;
                            ci.ExpDate = cinfo.ExpDate;
                            ci.CustomerPin = cinfo.CustomerPin;
                            SessionFacade.WIZSTEP4 = ci;
                            return RedirectToAction("Confirm");
                        }
                    }
                }
            }
            return View(cinfo);
        }
        public ActionResult Confirm()
        {
            if (SessionFacade.WIZSTEP4 == null)
                return RedirectToAction("WizStep4");
            else if (SessionFacade.WIZSTEP3 == null)
            {
                return RedirectToAction("WizStep3");
            }
            else if(SessionFacade.WIZSTEP2 == null)
                return RedirectToAction("WizStep2");
            else
            {
                CustomerInfo ci = SessionFacade.WIZSTEP4;
                return View(ci);

            }
        }
        [HttpPost]
        public ActionResult Confirm(string btnPrev, string btnFinish)
        {

            if (SessionFacade.WIZSTEP4 == null)
                return RedirectToAction("WizStep4");
            else if (SessionFacade.WIZSTEP3 == null)
                return RedirectToAction("WizStep3");
            else if (SessionFacade.WIZSTEP2 == null)
                return RedirectToAction("WizStep2");
            else
            {
                // normal flow - cae here from step 3
                CustomerInfo ci = null;
                if (btnFinish != null)
                {
                    if (btnFinish.ToUpper() == "FINISH")
                    {
                        ci = SessionFacade.WIZSTEP4;
                        
                        // write ci to DB
                        string CustomerInfo_sql = "insert into CustomerInfo(FirstName,LastName,Email,StreetAddress,City,State,Telephone,CellPhone)" +
                                "values ("+ci.FirstName+","+ ci.LastName + "," + ci.Email + "," + ci.StreetAddress + "," + ci.City + "," + ci.State + "," + ci.Telephone + "," + ci.CellPhone+")";

                        string CardDetails_sql = "insert into CardDetails(CardNum,ExpDate,CustomerPin,TotalCost)" +
                            "values (" + ci.CardNum+ "," + ci.ExpDate+ "," + ci.CustomerPin+ "," + ci.TotalCost+ ")";

                        string Equipments_sql = "insert into Equipments(SoccerBall,SoccerShoes,SoccerJersy,EnergyDrinks, Coach)" +
                            "values (" + ci.SoccerBall + "," + ci.SoccerShoes + "," + ci.SoccerJersy + "," + ci.EnergyDrinks + "," + ci.Coach +")";


                        int CustomerInfo_success = DataAccess.InsertUpdateDelete(CustomerInfo_sql, null);
                        int CardDetails_success = DataAccess.InsertUpdateDelete(CardDetails_sql, null);
                        int Equipments_success = DataAccess.InsertUpdateDelete(Equipments_sql, null);


                        if((CustomerInfo_success > 0) && (CardDetails_success > 0) && (Equipments_success > 0))
                            ViewBag.Msg = "Customer registered successfully..";
                        else
                            ViewBag.Msg = "Value Insert Failed..";
                    }
                }
                if (btnPrev != null)
                {
                    if (btnPrev.ToUpper() == "PREV")
                        return RedirectToAction("WizStep4");
                }
                return View(ci);
            }
        }
    }
}