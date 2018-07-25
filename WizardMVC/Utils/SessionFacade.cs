using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WizardMVC.Models;

namespace WizardMVC.Utils
{
    public class SessionFacade
    {
        static readonly string wizstep1 = "WIZSTEP1";
        public static CustomerInfo WIZSTEP1
        {
            get
            {
                if (HttpContext.Current.Session[wizstep1] != null)
                    return (CustomerInfo)HttpContext.Current.Session[wizstep1];
                else
                    return null;
            }
            set
            {
                HttpContext.Current.Session[wizstep1] = value;
            }
        }
        static readonly string wizstep2 = "WIZSTEP2";
        public static CustomerInfo WIZSTEP2
        {
            get
            {
                if (HttpContext.Current.Session[wizstep2] != null)
                    return (CustomerInfo)HttpContext.Current.Session[wizstep2];
                else
                    return null;
            }
            set
            {
                HttpContext.Current.Session[wizstep2] = value;
            }
        }
        static readonly string wizstep3 = "WIZSTEP3";
        public static CustomerInfo WIZSTEP3
        {
            get
            {
                if (HttpContext.Current.Session[wizstep3] != null)
                    return (CustomerInfo)HttpContext.Current.Session[wizstep3];
                else
                    return null;
            }
            set
            {
                HttpContext.Current.Session[wizstep3] = value;
            }
        }
        static readonly string wizstep4 = "WIZSTEP4";
        public static CustomerInfo WIZSTEP4
        {
            get
            {
                if (HttpContext.Current.Session[wizstep4] != null)
                    return (CustomerInfo)HttpContext.Current.Session[wizstep4];
                else
                    return null;
            }
            set
            {
                HttpContext.Current.Session[wizstep4] = value;
            }
        }
    }
}